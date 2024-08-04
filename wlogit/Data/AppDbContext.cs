using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using wlogit.Models;


namespace wlogit.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }



        public DbSet <Post>Tbl_Post { get; set; }
        public DbSet <Profile>Tbl_Profile{ get; set; }

    }

    


}
