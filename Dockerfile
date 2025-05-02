# -----build------ 
# 使用 dotnet 8.0 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnet-build
# 設定工作目錄為 /src (build 暫存區)
WORKDIR /src

# 複製配置文件 並install依賴
COPY *.csproj .
RUN dotnet restore

# 複製所有檔案並編譯
COPY . .
RUN dotnet publish -c Release -o /app/publish

# -----run------ 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS dotnet-run
# 設定工作目錄為 /app (執行區)
WORKDIR /app
    
# 從 build 階段複製出來的 DLL 結果
COPY --from=dotnet-build /app/publish .
    
# 設定啟動指令（請確認 DLL 名稱無誤）
ENTRYPOINT ["dotnet", "simple-social-board-server.dll"]


# docker build -t social-server:1.0.0  .
# docker run --env-file .env -p 18080:80 --name social-api social-server:1.0.0

# docker run -p 18080:80 social-server
