using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class RowNode
    {
        public int RowNodeId { get; set; }

        //public string RowNodeName { get; set; }

        public List<Node> Nodes { get; set; } = new List<Node>();
        
        //[MaxLength(64)]
        //public string RowNodeName { get; set; } 
    }
}