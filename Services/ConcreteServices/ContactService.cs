using System.Collections.Generic;
using Services.Dtos;
using Services.ServicesAbstractions;

namespace Services.ConcreteServices
{
    public class ContactService : IContactService
    {
        public string Create(Contact contato)
        {
            if (contato.Nome != "Jubiscleiton" && contato.Idade < 100)
            {
                var novoContato = new Contact() { Id = contato.Id, Nome = contato.Nome, Idade = contato.Idade };

                return "Contato criado";
            }
            else
            {
                return "O Contato não foi criado!";
            }
        }

        public List<ContactResponseDto> GetAll(string senha)
        {
            var listaDeContatos = new List<Contact>()
            {
                new Contact() { Id = 1, Nome = "Professor Davy", Idade = 24, SenhaDoCartao = "123cba" },
                new Contact() { Id = 2, Nome = "Tio Julio", Idade = 46, SenhaDoCartao = "321abc" }
            };

            if (senha == "123passatudo")
            {
                var listaDeDtosDeContatos = new List<ContactResponseDto>();

                foreach (var contato in listaDeContatos)
                {
                    listaDeDtosDeContatos.Add(
                        new ContactResponseDto()
                        {
                            Id = contato.Id,
                            Nome = contato.Nome,
                            Idade = contato.Idade
                        }
                    );
                }

                return listaDeDtosDeContatos;
            }
            else
            {
                return new List<ContactResponseDto>();
            }
        }

        public string Update(Contact contato)
        {
            var contatoVazio = new Contact();

            if (contato.Nome.Length > 0 && contato.Idade > 0)
            {
                contatoVazio.Id = contato.Id;
                contatoVazio.Nome = contato.Nome;
                contatoVazio.Idade = contato.Idade;

                return "Contato atualizado";
            }
            else
            {
                return "O Contato não foi atualizado!";
            }
        }

        public string Delete(Contact contato)
        {
            var contatoParaDeletar = new Contact() { Id = 1, Nome = "João deletado", Idade = 35 };

            if (contato.Nome == contatoParaDeletar.Nome &&
                contato.Idade == contatoParaDeletar.Idade)
            {
                contatoParaDeletar = null;

                return "Contato apagado";
            }
            else
            {
                return "O Contato não foi apagado!";
            }
        }
    }
}