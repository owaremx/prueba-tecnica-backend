﻿using System.ComponentModel.DataAnnotations;

namespace data_access.model
{
    public class Estados
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; } 
    } 
}
