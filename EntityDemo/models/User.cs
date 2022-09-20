using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityDemo.models
{

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string? Firstname { get; set; }

        [MaxLength(50)]
        public string? Lastname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public DateTime AccountCreation { get; set; }

        [Required]
        public Role UserRole { get; set; }

        public User()
        {
            Id = new Guid();
        }

    }
}
