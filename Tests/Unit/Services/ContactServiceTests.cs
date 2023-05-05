using Xunit;

namespace Tests
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactRepository> _contactRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IContactService _contactService;

        public ContactServiceTests()
        {
            _contactRepositoryMock = new Mock<IContactRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _contactService = new ContactService(_contactRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_WhenUserDoesNotExist_ShouldNotAddContact()
        {
            // Arrange
            var userId = 1;
            var createContactDto = new CreateContactRequestDto()
            {
                Name = "John",
                Phone = "123456789",
                UserId = userId
            };
            _userRepositoryMock.Setup(repo => repo.GetById(userId)).ReturnsAsync((User)null);

            // Act
            await _contactService.Create(createContactDto);

            // Assert
            _contactRepositoryMock.Verify(repo => repo.Create(It.IsAny<Contact>()), Times.Never);
            _contactRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task Create_WhenUserExists_ShouldAddContact()
        {
            // Arrange
            var userId = 1;
            var user = new User() { Id = userId };
            var createContactDto = new CreateContactRequestDto()
            {
                Name = "John",
                Phone = "123456789",
                UserId = userId
            };
            _userRepositoryMock.Setup(repo => repo.GetById(userId)).ReturnsAsync(user);

            // Act
            await _contactService.Create(createContactDto);

            // Assert
            _contactRepositoryMock.Verify(repo => repo.Create(It.IsAny<Contact>()), Times.Once);
            _contactRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfContactResponseDto()
        {
            // Arrange
            var contacts = new List<Contact>()
            {
                new Contact() { Id = 1, Name = "John", Phone = "123456789", UserId = 1 },
                new Contact() { Id = 2, Name = "Jane", Phone = "987654321", UserId = 1 }
            };
            _contactRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(contacts);

            // Act
            var result = await _contactService.GetAll();

            // Assert
            Assert.IsType<List<ContactResponseDto>>(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("John", result[0].Name);
            Assert.Equal("123456789", result[0].Phone);
            Assert.Equal(1, result[0].UserId);
            Assert.Equal(2, result[1].Id);
            Assert.Equal("Jane", result[1].Name);
            Assert.Equal("987654321", result[1].Phone);
            Assert.Equal(1, result[1].UserId);
        }
    }
}
