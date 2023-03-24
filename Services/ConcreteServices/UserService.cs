using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Data.RepositoriesAbstractions;
using Services.ServicesAbstractions;
using Utils.Dtos.Contact;
using Utils.Dtos.User;

namespace Services.ConcreteServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(CreateUserRequestDto createUserDto)
        {
            var newUser = new User()
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                CreatedAt = DateTime.Now
            };

            _userRepository.Create(newUser);

            await _userRepository.SaveChangesAsync();
        }

        public async Task<List<UserResponseDto>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();

            var userDtos = new List<UserResponseDto>();

            foreach (var user in users)
            {
                userDtos.Add(
                    new UserResponseDto()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Contacts = GetContactDtosList(user.Contacts)
                    }
                );
            }

            return userDtos;
        }

        public async Task Update(int userId, UpdateUserRequestDto updatedUser)
        {
            var existingUser = _userRepository.GetById(userId);

            if (existingUser != null) 
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.UpdatedAt = DateTime.Now;

                _userRepository.Update(existingUser);

                await _userRepository.SaveChangesAsync();
            }
        }

        public async Task Delete(int userId)
        {
            var existingUser = _userRepository.GetById(userId);

            if (existingUser != null) 
            {
                _userRepository.Delete(existingUser);

                await _userRepository.SaveChangesAsync();
            }
        }

        private List<BaseContactDto> GetContactDtosList(List<Contact> contactModels) 
        {
            var contactDtos = new List<BaseContactDto>();

            foreach (var model in contactModels)
            {
                contactDtos.Add(
                    new BaseContactDto() 
                    {
                        Name = model.Name,
                        Phone = model.Phone
                    }
                );
            }

            return contactDtos;
        }
    }
}