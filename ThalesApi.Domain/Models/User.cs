using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesApi.Domain.Models
{
    [Table("User")]
    public class User : Auditory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Username")]
        [StringLength(50)]
        public string Username { get; set; }

        [Column("PasswordHash")]
        [StringLength(600)]
        public string PasswordHash { get; set; }
    }
}
