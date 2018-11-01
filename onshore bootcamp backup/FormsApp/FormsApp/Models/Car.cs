using System;
using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(1870d, 2100d)]
        public Int16 Year { get; set; }
        
        [Range(0d, 350d)]
        [Display(Name = "Top Speed:")]
        public Int16 topSpeed { get; set; }

        //public string displaySpeed
        //{
        //    get
        //    {
        //        return (topSpeed.ToString() + " MPH");
        //    }
        //}

        [Required]
        public string Color { get; set; }
    }
}