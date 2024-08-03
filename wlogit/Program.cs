using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using wlogit.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddMvc();
var myConString = builder.Configuration.GetConnectionString("myString");
builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlServer(myConString));

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler();
    app.UseHsts();
}



app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
