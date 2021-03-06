﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Game
    {
        public int GameId { get; set; }
        
        public User Player1 { get; set; } = new User();
        public User Player2 { get; set; } = new User();
        
        [MaxLength(64)]
        public string GameName { get; set; }

        [MaxLength(3)]
        [MinLength(2)]
        [RegularExpression(@"[A-Ja-j]{1}[1-9]{1}[0]?", ErrorMessage = "Shoot like A1")]
        public string GMove { get; set; }
    }
}