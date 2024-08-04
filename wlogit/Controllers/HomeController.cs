using Microsoft.AspNetCore.Mvc;
using wlogit.Data;
using wlogit.Models;

namespace wlogit.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        public HomeController(AppDbContext _db)
        {
            db = _db;
        }


        public IActionResult Index()
        {

            IEnumerable<Post> myPost = db.Tbl_Post;
            return View(myPost);
        }


        [Route("Home/Post/{Slug}")]
        public IActionResult Post(string Slug)
        {
            var DetailedPost = db.Tbl_Post.Where(x=>x.Slug==Slug).FirstOrDefault();
            return View(DetailedPost);
        }


    }
}
