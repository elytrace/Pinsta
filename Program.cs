using CloudinaryDotNet;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pinsta.Models;

var builder = WebApplication.CreateBuilder(args);

// Configs
JsonConvert.DefaultSettings = () => new JsonSerializerSettings {
    Formatting = Formatting.Indented,
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
};

// Cloudinary credentials
DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
Console.WriteLine(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
cloudinary.Api.Secure = true;

// Database
// builder.Services.Add(new ServiceDescriptor(typeof(MyDbContext), 
//     new MyDbContext(
//         builder.Configuration.GetConnectionString("DefaultConnection")
//     )
// ));

builder.Services.AddDbContext<OurDbContext>(ServiceLifetime.Transient, ServiceLifetime.Transient);

 OurDbContext.DeleteDatabase().Wait();
OurDbContext.CreateDatabase().Wait();
 OurDbContext.InsertSampleData().Wait();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "",
    pattern: "{controller=Profile}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();