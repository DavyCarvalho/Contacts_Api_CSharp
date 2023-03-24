using System.Collections.Generic;
using Utils.Dtos.Contact;

namespace Utils.Dtos.User
{
    public class UserResponseDto : BaseUserDto
    {
        public int Id { get; set; }
        public List<BaseContactDto> Contacts { get; set; }
    }
}