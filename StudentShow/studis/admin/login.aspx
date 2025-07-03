<%@ Page Title="管理员登录" Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员登录</title>
    <style>
    body {
        margin: 0;
        padding: 0;
        background: linear-gradient(to bottom, rgba(0,0,0,0.3), rgba(0,0,0,0.3)),
                    url('../images/2.jpg') no-repeat center center fixed;
        background-size: cover;
        background-blend-mode: overlay;
        font-family: "Microsoft YaHei", sans-serif;
        height: 100vh;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }

    .login-box {
    background-color: rgba(255, 255, 255, 0.15);
    padding: 40px;
    border-radius: 12px;
    box-shadow: 0 0 20px rgba(0,0,0,0.5);
    width: 320px;
    text-align: center;
    color: white;
    height: 250px; /* ✅ 关键：固定高度 */
    position: relative; /* 为后续绝对定位准备 */
}

    .login-box h2 {
        margin-bottom: 20px;
        font-size: 22px;
    }

    .login-box input {
        width: 100%;
        padding: 10px;
        margin-bottom: 15px;
        border: none;
        border-radius: 6px;
        font-size: 16px;
    }

    .btn {
        background-color: #005bac;
        color: white;
        border: none;
        padding: 10px;
        width: 100%;
        border-radius: 6px;
        font-size: 18px;
        font-weight: bold;
        cursor: pointer;
    }

    .btn:hover {
        background-color: #004080;
    }

        .msg {
        position: absolute;
bottom: 44px;         /* 可根据实际视觉微调 */
left: 0;
width: 100%;
text-align: center;
color: yellow;
font-size: 14px;
line-height: 20px;
height: 20px;
overflow: hidden;

    }

    .footer {
        margin-top: 30px;
        color: #ddd;
        font-size: 14px;
        text-align: center;
    }
    .input-box {
        width: 100%;
        padding: 10px;
        margin-bottom: 15px;
        border: none;
        border-radius: 6px;
        font-size: 14px;
        box-sizing: border-box; /* ✅ 防止超出边框 */
    }

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <h2>管理员登录</h2>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="input-box" Placeholder="请输入账号" />
            <asp:TextBox ID="txtUserPass" runat="server" CssClass="input-box" TextMode="Password" Placeholder="请输入密码" />
            <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="btn" OnClick="btnLogin_Click" />    
            <asp:Label ID="lblMsg" runat="server" CssClass="msg" />
                            <div style="margin-top: 15px;">
    <a href="../index.aspx" style="color: #fff; font-size: 14px; text-decoration: underline;">
        返回登录选择界面
    </a>
</div>
        </div>

        <div class="footer">
            版权所有 © 2025 学生科技作品展示平台
        </div>
    </form>
</body>
</html>

