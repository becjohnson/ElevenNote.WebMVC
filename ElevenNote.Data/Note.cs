using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        [Display(Name = "Your Note")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
        public bool IsStarred { get; set; }
        public DateTimeOffset? CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
