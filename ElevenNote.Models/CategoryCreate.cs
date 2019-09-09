using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(3, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(25, ErrorMessage = "There are too many characters in this field.")]
        public string CategoryName { get; set; }
    }
}
