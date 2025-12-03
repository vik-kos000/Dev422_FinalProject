using System.ComponentModel.DataAnnotations;

namespace PlayerService.Model
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool IsDrafted { get; set; } = false;
        public int? TeamId { get; set; } = null;
    }
}
