using System.ComponentModel.DataAnnotations;

namespace ButlerApp.Models
{
    public class Address
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

    }
}
