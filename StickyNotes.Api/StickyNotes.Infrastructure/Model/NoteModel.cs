using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes.Infrastructure.Model
{
    public class NoteModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NoteHeading { get; set; }
        public string NoteText { get; set; }
        public string Color { get; set; }
        public bool IsDeleted { get; set; }
        //public object NotesModel { get; set; }
    }
}
