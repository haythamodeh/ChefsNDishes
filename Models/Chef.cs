using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
      [Key]
      public int ChefID { get; set; }

      [Required(ErrorMessage = "Input is required")]
      [MinLength(2, ErrorMessage = "Must be longer than 2 characters")]
      public string FirstName { get; set; }

      [Required(ErrorMessage = "Input is required")]
      [MinLength(2, ErrorMessage = "Must be longer than 2 characters")]
      public string LastName { get; set; }

      [Required(ErrorMessage = "Input is required")]
      public DateTime DateOfBirth { get; set; }

      public List<Dish> DishesMade {get;set;}

      [Required]
      public DateTime created_at { get; set; } = DateTime.Now;

      [Required]
      public DateTime updated_at { get; set; } = DateTime.Now;
    }
}