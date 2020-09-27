using StickyNotes.DAL.Interface;
using StickyNotes.DAL.Models;
using StickyNotes.Infrastructure.Interface;
using StickyNotes.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveUser(UserModel model)
        {
            Users user = new Users();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.CreatedOn = DateTime.Now;
            user.IsActive = true;
            await _userRepository.SaveUser(user);
        }

        public async Task<Users> GetUserByEmail(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email, password);
            return user;
        }

        public async Task SaveNote(NoteModel model)
        {
            Note note = new Note();
            note.UserId = model.UserId;
            note.NoteHeading = model.NoteHeading;
            note.NoteText = model.NoteText;
            note.IsDeleted = false;
            //note.NoteModel = model.NotesModel;
            await _userRepository.SaveNote(note); 
        }

        public async Task<List<NoteModel>>GetNotesbyUserId(int Id)
        {
            return (await _userRepository.GetNotesByUserId(Id)).Select(x => new NoteModel()
            {
                Id=x.Id,
                UserId = x.UserId,
                NoteHeading = x.NoteHeading,
                NoteText = x.NoteText
            }).ToList();
        }

        public async Task DeleteNote(int noteId)
        {
            await _userRepository.DeleteNote(noteId);
        }
    }
}
