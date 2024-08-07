using Microsoft.AspNetCore.Mvc;
using wlogit.Data;
using wlogit.Models;

namespace wlogit.Controllers
{
    public class AdminController : Controller
    {


        private readonly AppDbContext db;
        public AdminController(AppDbContext _db)
        {
            db = _db;
        }


        public IActionResult Index()
        {
            return View();





        }
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Post myPost)
        {
            db.Tbl_Post.Add(myPost);
            db.SaveChanges();
            return View();
        }


        public IActionResult AllPosts()
        {
            var myAllposts = db.Tbl_Post;
            return View(myAllposts);
        }

    }
}
