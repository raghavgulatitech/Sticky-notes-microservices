using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes.DAL.Models
{
    public partial class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
