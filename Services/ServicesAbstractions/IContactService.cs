using System.Collections.Generic;
using Services.Dtos;

namespace Services.ServicesAbstractions
{
    public interface IContactService
    {
        public string Create(Contact contato);
        public List<ContactResponseDto> GetAll(string senha);
        public string Update(Contact contato);
        public string Delete(Contact contato);
    }
}