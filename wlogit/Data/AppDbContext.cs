using Microsoft.EntityFrameworkCore;


namespace wlogit.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        
            
        


    }
}
