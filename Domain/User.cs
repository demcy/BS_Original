using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        
        public Board SelfBoard { get; set; } = new Board();
        public Board OppenentBoard { get; set; } = new Board(); 
    }
}