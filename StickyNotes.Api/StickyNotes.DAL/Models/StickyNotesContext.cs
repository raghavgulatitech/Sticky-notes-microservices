using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes.DAL.Models
{
    public partial class StickyNotesContext : DbContext
    {
        public StickyNotesContext(DbContextOptions<StickyNotesContext> options)
           : base(options)
        {
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Note> Note { get; set; }
    }
}
