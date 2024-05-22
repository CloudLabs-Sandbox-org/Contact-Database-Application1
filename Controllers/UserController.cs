using CRUD_application_2.Interfaces;
using CRUD_application_2.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        //private IUserService userService;
        private IList<User> users = new List<User>() { new Models.User() { Id = 1, Email = "test@email.com", Name = "John"} } ; 

        public UserController()//IUserService userService)
        {
            //this.userService = userService;
        }

        [HttpGet]
        // GET: User
        public ActionResult Index()
        {
            // Return the Index view with the list of users
            return View(users);
        }

        // GET: User/Details/5
        [HttpGet]
        [Route("User/Details")]
        public ActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("Details", user);
        }

        // GET: User/Create
        [HttpGet]
        [Route("User/Create")]
        public ActionResult Create() 
        {
            return View("Create");
        }
        // POST: User/Create
        [HttpPost]
        [Route("User/Create")]
        public ActionResult Create(User user)
        {
            // Add the user to the userlist
            users.Add(user);

            return View();
        }
        // GET: User/Edit/5
        [HttpGet]
        [Route("User/Edit")]
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("Edit", user);
        }

        // GET: User/Delete/5
        [HttpGet]
        [Route("User/Delete")]
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            var user = users.FirstOrDefault(u => u.Id == id);
            users.Remove(user);

            return View("Delete");
        }
    }
}
