using Microsoft.AspNetCore.Mvc;
using wlogit.Data;
using wlogit.Models;
using wlogit.ViewModel;

namespace wlogit.Controllers
{
    public class AdminController : Controller
    {

        IWebHostEnvironment env;

        private readonly AppDbContext db;
        public AdminController(AppDbContext _db, IWebHostEnvironment environment)
        {
            db = _db;
            env = environment;
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
        public IActionResult AddPost(PostVM myPost)
        {
            if (ModelState.IsValid)

            {
                string ImageName = myPost.Image.FileName.ToString();
                var FolderPath = Path.Combine(env.WebRootPath, "images");
                var CompletePicPath = Path.Combine(FolderPath, ImageName);
                myPost.Image.CopyTo(new FileStream(CompletePicPath, FileMode.Create));


                Post post = new Post();
                post.Title = myPost.Title;
                post.SubTitle = myPost.SubTitle;
                post.Date=myPost.Date;
                post.Slug = myPost.Slug;
                post.Content = myPost.Content;
                post.Image = ImageName;
                db.Tbl_Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index","Home");

            
            
            }
        
            return View();

        }


        public IActionResult AllPosts()
        {
            var myAllposts = db.Tbl_Post;
            return View(myAllposts);
        }


        public IActionResult DeletePost(int Id)

        {

            var PostToDelete = db.Tbl_Post.Find(Id);

            if (PostToDelete != null)
            { 
                db.Remove(PostToDelete);
                db.SaveChanges();
            
            }

            return RedirectToAction("AllPosts", "Admin");
        
        }

        public IActionResult UpdatePost(int Id)
        {
            var PosttoUpdate = db.Tbl_Post.Find(Id);

            return View(PosttoUpdate);
        }


        [HttpPost]
        public IActionResult UpdatePost(Post post)
        {
            db.Tbl_Post.Update(post);
            db.SaveChanges();
            return RedirectToAction("AllPosts", "Admin");

  
        }

    }
}
