<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生科技作品展示平台</title>
    <style>
        /* 背景图 + 渐变遮罩 */
        body {
            margin: 0;
            padding: 0;
            background: linear-gradient(to bottom, rgba(0,0,0,0.3), rgba(0,0,0,0.3)),
                url('images/2.jpg') no-repeat center center fixed;
            background-size: cover;
            background-blend-mode: overlay;
            font-family: "Microsoft YaHei", sans-serif;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            color: #fff;
        }

        .container {
            background-color: rgba(255, 255, 255, 0.1);
            padding: 60px;
            border-radius: 15px;
            text-align: center;
            box-shadow: 0 0 30px rgba(0, 0, 0, 0.4);
        }

        h1 {
            font-size: 36px;
            margin-bottom: 40px;
            color: #ffffff;
            text-shadow: 1px 1px 4px rgba(0,0,0,0.6);
        }

        .btn {
            display: inline-block;
            padding: 14px 30px;
            margin: 15px;
            font-size: 18px;
            font-weight: bold;
            background-color: #005bac;
            color: white;
            border: none;
            border-radius: 8px;
            text-decoration: none;
            cursor: pointer;
            transition: background 0.3s ease, transform 0.2s ease;
        }

        .btn:hover {
            background-color: #004080;
            transform: translateY(-2px);
        }

        .footer {
            margin-top: 30px;
            font-size: 14px;
            color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>学生科技作品展示平台</h1>
            <a href="stu/login.aspx" class="btn">学生登录入口</a>
            <a href="admin/login.aspx" class="btn">管理员登录入口</a>
            <div class="footer">版权所有 &copy; 2025 学生科技作品展示平台</div>
        </div>
    </form>
</body>
</html>


