using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Note
{
    public class NoteCreate
    {
        [Required]
        public string Title { get; set; }
        [Display(Name = "My Note")]
        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
