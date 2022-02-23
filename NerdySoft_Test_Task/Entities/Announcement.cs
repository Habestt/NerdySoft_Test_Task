using System.ComponentModel.DataAnnotations;

namespace NerdySoft_Test_Task.Entities
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
