using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Node
    {
        public int NodeId { get; set; }
        
        //public int RowNodeId { get; set; }
        //public RowNode RowNode { get; set; }
        
        [MaxLength(64)]
        public string NodeValue { get; set; } = "\x25A2";
    }
}