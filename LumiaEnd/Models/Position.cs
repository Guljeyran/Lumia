﻿using System.ComponentModel.DataAnnotations;

namespace LumiaEnd.Models
{
    public class Position
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30)]
        public string Name { get; set; }
        public List<Team>? Teams { get; set; }
    }
}
