using armyTec.Models;
using armyTec.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string con = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<ArmyTechTaskContext>(optionBuider =>
{
    optionBuider.UseSqlServer(con);
});
builder.Services.AddScoped<IInvoice, IInvoiceRepo>();
//CacherRepo : ICacher
//
builder.Services.AddScoped<ICacher, CacherRepo>();
//branchRepo : Ibranch
builder.Services.AddScoped<Ibranch, branchRepo>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
