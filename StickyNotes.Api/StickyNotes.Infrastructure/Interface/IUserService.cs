using StickyNotes.DAL.Models;
using StickyNotes.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes.Infrastructure.Interface
{
    public interface IUserService
    {
        Task SaveUser(UserModel model);

        Task<Users> GetUserByEmail(string email, string password);

        Task SaveNote(NoteModel model);
        Task<List<NoteModel>> GetNotesbyUserId(int Id);

        Task DeleteNote(int noteId);
    }
}
