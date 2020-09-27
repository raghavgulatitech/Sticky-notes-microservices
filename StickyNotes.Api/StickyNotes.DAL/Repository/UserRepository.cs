using StickyNotes.DAL.Interface;
using StickyNotes.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace StickyNotes.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StickyNotesContext _context;
        public UserRepository(StickyNotesContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<Users> GetUserByEmail(string email, string password)
        {
            return (from usr in _context.Users where usr.Email == email && usr.Password == password select usr).FirstOrDefault();
        }

        public async Task SaveNote(Note model)
        {
            _context.Note.Add(model);
            _context.SaveChanges();
        }

        public async Task<List<Note>> GetNotesByUserId(int Id)
        {
            return (from note in _context.Note where note.UserId == Id && !note.IsDeleted select note).ToList();
        }

        public async Task DeleteNote(int noteId)
        {
            var note = (from n in _context.Note where n.Id == noteId select n).FirstOrDefault();
            if (note != null)
            {
                note.IsDeleted = true;
                _context.Note.Update(note);
                _context.SaveChanges();
            }
        }
    }
}
