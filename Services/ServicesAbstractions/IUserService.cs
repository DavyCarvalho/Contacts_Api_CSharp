using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.Dtos.User;

namespace Services.ServicesAbstractions
{
    public interface IUserService
    {
        public Task Create(CreateUserRequestDto newUser);
        public Task<List<UserResponseDto>> GetAll();
        public Task Update(int userId, UpdateUserRequestDto updatedUser);
        public Task Delete(int id);
    }
}