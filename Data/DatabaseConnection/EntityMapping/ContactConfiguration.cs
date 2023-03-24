using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DatabaseConnection.EntityMapping
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            // define o nome da tabela no banco de dados
            builder.ToTable("Contacts");

            // define o mapeamento das propriedades
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(15).IsRequired();

            // define o relacionamento com a tabela de User
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Contacts)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}