using e_commerce.DataAccess.Dtos;
using e_commerce.DataAccess.Repository;
using e_commerce.DataAccess.Repository.IRepository;
using e_commerce.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registering MongoService
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<MongoService>();

// Repository Pattern
//builder.Services.AddScoped<ICategoryRepository, ICategoryRepository>();

// Changing repository pattern to Unit of Work pattern
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
// Serve static files from wwwroot
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
    // Its the default route pattern for MVC applications, where the default controller is "Home" and the default action is "Index".
    // The "{id?}" part means that the "id" parameter is optional.


app.Run();
