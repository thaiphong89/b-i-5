using BookCRUD.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ MVC cho các controller và view
builder.Services.AddControllersWithViews();

// Đăng ký BookRepository để DI (Dependency Injection)
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Nếu không ở chế độ phát triển, xử lý lỗi và sử dụng HSTS (HTTP Strict Transport Security)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Sử dụng HTTPS Redirection và phục vụ các tệp tĩnh (static files)
app.UseHttpsRedirection();
app.UseStaticFiles();

// Thiết lập routing cho ứng dụng
app.UseRouting();

// Sử dụng xác thực (authorization)
app.UseAuthorization();

// Định nghĩa route mặc định cho ứng dụng
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");

// Chạy ứng dụng
app.Run();