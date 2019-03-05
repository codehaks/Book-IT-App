using System.ComponentModel.DataAnnotations.Schema;

namespace Bookit.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        public int Count { get; set; }
    }
}