﻿using System.ComponentModel.DataAnnotations;

namespace com.portfolio2.web.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
