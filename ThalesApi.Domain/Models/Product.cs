using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesApi.Domain.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int id { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public List<string> images { get; set; }
        public DateTime creationAt { get; set; }
        public DateTime updatedAt { get; set; }

        public int categoryId { get; set; }
        public virtual Category category { get; set; }
    }
}
