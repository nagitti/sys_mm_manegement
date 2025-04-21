using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mm_manegement.Models
{
    public class Schudule
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public required IdentityUser User { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public ScheduleTag tag { get; set; }
        public DataType StartTime { get; set; }
        public DataType EndTime { get; set; }
        public DataType CreatedAt { get; set; }
        public DataType UpdatedAt { get; set; }
    }
    public enum ScheduleTag
    {
        Trpg,
        MurderMystery,
        Private,
    }
}
