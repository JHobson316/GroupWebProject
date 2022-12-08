using GroupWebProject.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupWebProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //      Get /User
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
            return View(users);
        }
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Details(string id)
        {
            var user = _unitOfWork.User.GetUser(id);
                return View(user);
        }
    }
}
