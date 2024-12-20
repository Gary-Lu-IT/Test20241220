# DB檔
資料庫名稱：Test
(1)使用資料庫還原功能還原Test20241220.bak檔；(2)SQL Server內建立使用者gslog，密碼也是gslog並可存取Test資料庫即可。
# 程式碼
使用Visual Studio 2022 Community開發，.Net版本8.0，在與執行Test資料庫的機器上直接編譯執行。
# 程式碼使用套件
Microsoft.EntityFrameworkCore.Tools  
Microsoft.EntityFrameworkCore.SqlServer
# 處理進度
WEBAPI端測試過可以執行，Swagger頁面可以開啟。  
唯預儲程序部分因接觸不多而技術不純熟，目前存取資料庫方式乃API內控制器直接對資料庫表格進行存取。
