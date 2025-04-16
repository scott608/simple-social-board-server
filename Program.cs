using Microsoft.EntityFrameworkCore;
using simple_social_board_server.Data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

//新增服務註冊
builder.Services.AddControllersWithViews();

Env.Load();

var mainServer = Environment.GetEnvironmentVariable("Main_DB_Server");
var mainDb = Environment.GetEnvironmentVariable("Main_DB_NAME");
var mainUser = Environment.GetEnvironmentVariable("Main_DB_user");
var mainPassword = Environment.GetEnvironmentVariable("Main_DB_password");

var mainConnStr  = $"server={mainServer};database={mainDb};user={mainUser};password={mainPassword};port=3306;";

//註冊 DbContext
builder.Services.AddDbContext<MainDbContext>(options =>
    // 使用 MySQL 資料庫
    options.UseMySql(
        // 這邊的 connection string 是從 appsettings.json 讀取的
        // 你可以改成你要的連線字串
        mainConnStr,
        // 改成你要的版本
        new MySqlServerVersion(new Version(8, 0, 41))
    ));

// 建立 App
var app = builder.Build();

// 設定 HTTP 請求管道
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
