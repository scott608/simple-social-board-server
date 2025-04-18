using Microsoft.EntityFrameworkCore;
using SimpleSocialBoardServer.Data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

//新增服務註冊， 只註冊 API Controlle
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
// Swagger 文件註冊
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

if (app.Environment.IsDevelopment())
{
    // 開啟 Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
} 

//HTTPS 
app.UseHttpsRedirection();
// app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();


app.MapControllers();

app.Run();
