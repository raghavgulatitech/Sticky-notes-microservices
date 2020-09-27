using StickyNotes.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes.DAL.Interface
{
    public interface IUserRepository
    {
        Task SaveUser(Users user);
        Task<Users> GetUserByEmail(string email, string password);

        Task SaveNote(Note model);

        Task<List<Note>> GetNotesByUserId(int Id);

        Task DeleteNote(int noteId);
    }
}