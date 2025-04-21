using Microsoft.AspNetCore.Identity;

namespace mm_manegement.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GroupMembership> GroupMemberships { get; set; }
    }
}
