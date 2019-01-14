using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Board
    {
        public int BoardId { get; set; }

        public string BoardName { get; set; }

        public List<RowNode> RowNodes { get; set; } = new List<RowNode>();
    }
}