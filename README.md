
# 簡易社交留言板伺服器

這是一個基於 **.NET Core MVC** 的專案，用於實現簡易的社交留言板伺服器。該應用程式提供基本的貼文與使用者管理功能。

## 功能

- 使用者身份驗證與授權
- 貼文的 CRUD 操作
- RESTful API 端點
- 使用 Entity Framework Core 進行資料庫管理
- 透過依賴注入進行服務管理

## 先決條件

- [.NET Core SDK](https://dotnet.microsoft.com/download)（版本 6.0 或更高）
- 一個資料庫系統（例如 SQL Server、PostgreSQL 或 SQLite）

## 快速開始

### 1. 複製此專案

```bash
git clone https://github.com/scott608/simple-social-board-server.git
cd simple-social-board-server
```

### 2. 配置資料庫

更新 `appsettings.json` 檔案中的資料庫連線字串：

```json
"ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionString"
}
```

### 3. 應用遷移

執行以下命令以應用資料庫遷移：

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. 啟動應用程式

使用以下命令啟動應用程式：

```bash
dotnet run
```

應用程式將可於 `https://localhost:5001` 存取。

swagger http://localhost:5182/swagger/index.html

## 專案結構

- **Controllers**: 處理 HTTP 請求與回應。
- **Models**: 包含資料模型與驗證邏輯。
- **Views**: 用於渲染 UI 的 Razor 視圖。
- **Data**: 資料庫上下文與遷移。
- **Services**: 業務邏輯與可重用元件。

## API 端點

| 方法   | 端點               | 描述                |
|--------|-------------------|--------------------|
| GET    | /api/posts        | 獲取所有貼文        |
| POST   | /api/posts        | 建立新貼文          |
| PUT    | /api/posts/{id}   | 更新貼文            |
| DELETE | /api/posts/{id}   | 刪除貼文            |

## 貢獻

歡迎貢獻！請 fork 此專案並提交 pull request。

## 授權

此專案採用 [MIT 授權](LICENSE)。

## 聯絡方式

如有問題或反饋，請聯絡 [qazz6411@gmail.com]。