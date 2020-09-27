using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.Api.Model;
using StickyNotes.Infrastructure.Interface;
using StickyNotes.Infrastructure.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StickyNotes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        [Route("getuser")]
        public async Task<IActionResult> GetUserById(string email, string password)
        {
            ResultModel result = new ResultModel();
            try
            {
                var user = await _userService.GetUserByEmail(email, password);
                result.Success = true;
                result.Data = user;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return Ok(result);
        }


        [HttpPost]
        [Route("saveuser")]
        public async Task<IActionResult> SaveUser([FromBody]UserModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                await _userService.SaveUser(model);
                result.Success = true;
                //result.Data = user;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("savenote")]
        public async Task<IActionResult> SaveNote([FromBody]NoteModel model)
        {
            ResultModel result = new ResultModel();
            try
            {
                await _userService.SaveNote(model);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("getnotes")]
        public async Task<IActionResult> GetNotes(int id)
        {
            ResultModel result = new ResultModel();
            try
            {
                result.Data = await _userService.GetNotesbyUserId(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("deletenote")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            ResultModel result = new ResultModel();
            try
            {
                await _userService.DeleteNote(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return Ok(result);
        }

    }
}
