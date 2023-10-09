using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        public byte MembershipTypeId { get; set; }
        [ForeignKey("MembershipTypeId")]
        public virtual MembershipType? MembershipType { get; set; }
    }
}
