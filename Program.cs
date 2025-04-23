using Microsoft.EntityFrameworkCore;
using SimpleSocialBoardServer.Data;
using DotNetEnv;
using SimpleSocialBoardServer.Areas.Member.Services;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SimpleSocialBoardServer.Core.auth.Services;
using SimpleSocialBoardServer.Settings;

var builder = WebApplication.CreateBuilder(args);

//新增服務註冊， 只註冊 API Controlle
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    // 啟用 Enum 的字串轉換支援
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddScoped<UserService>(); 
builder.Services.AddScoped<AuthService>();

// Swagger 文件註冊
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // 設定 Swagger 的標題、版本、描述等資訊
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "請輸入 JWT，例如：Bearer xxxxx.yyyyy.zzzzz"
    });
    // 設定 Swagger 的安全性要求
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

Env.Load();

//註冊Jwt驗證服務
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // 設定 Token 驗證參數
        // 這邊的 TokenValidationParameters 是用來驗證 JWT 的參數設定
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = JwtSettings.Issuer,
            ValidAudience = JwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Key)),
        };
    });

var mainServer = Environment.GetEnvironmentVariable("Main_DB_Server");
var mainDb = Environment.GetEnvironmentVariable("Main_DB_Name");
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

// 僅開發環境下開啟 Swagger
if (app.Environment.IsDevelopment())
{
    // 開啟 Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
} 

//HTTPS 
app.UseHttpsRedirection();
// app.UseStaticFiles();  //靜態資源

app.UseRouting();
// 啟用身分驗證，⚠️ 非常重要，需先於 Authorization
app.UseAuthentication(); 
//啟用授權
app.UseAuthorization();
//把API Controller 連接（Mapping）到路由系統
app.MapControllers();

app.Run();
