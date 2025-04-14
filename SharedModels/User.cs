using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeMudBlazor8.Models
{
    [Table("users")] // Nombre exacto de la tabla en la base de datos
    public class User
    {
        [Key]
        [Column("user_id")] // Nombre exacto de la columna en MySQL
        public int UserId { get; set; }

        [Column("first_name")] // Nombre exacto de la columna en MySQL
        public string FirstName { get; set; }

        [Column("last_name")] // Nombre exacto de la columna en MySQL
        public string LastName { get; set; }
    }
}