using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }

        [Required(ErrorMessage = "Input is required")]
        [MaxLength(45, ErrorMessage = "Max Length is 45")]
        public string DishName { get; set; }

        [Required(ErrorMessage = "Input is required")]
        [Range(1,5, ErrorMessage = "Tastiness must be between 1 and 5")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "Input is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number needs to be between greater than 0")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Input is required")]
        public string Description { get; set; }

        [Required]
        public DateTime created_at { get; set; } = DateTime.Now;

        [Required]
        public DateTime updated_at { get; set; } = DateTime.Now;

        public Chef Chef { get; set; }

        public int ChefID { get; set; }

    }
}