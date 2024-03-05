using AppMvc.Net.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // dang ky dinh vu goi den razor

// builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
builder.Services.AddSingleton<PlanetService>();

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

app.UseAuthentication(); // xac dinh danh tinh
app.UseAuthorization();  // xac dinh quyen truy cap

// URL: /{controller=Home}/{action=Index}/{id?}
// Abc/Xyz => Controller=Abc, goi method Xyz
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
