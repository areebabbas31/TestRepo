using System;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class New
    {
        [Key]
        public int NewId { get; set; }

        public int Number { get; set; }
    }
}