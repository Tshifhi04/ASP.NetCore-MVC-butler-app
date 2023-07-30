using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ButlerApp.Models
{
    public class Butler
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string skillSet { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("Address")]
        public string AddressId { get; set; }

        public Address Address { get; set; }
        public string image { get; set; }
        public string status { get; set; }
    }
}
