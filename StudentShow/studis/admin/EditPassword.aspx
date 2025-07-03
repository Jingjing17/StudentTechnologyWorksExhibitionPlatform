<%@ Page Title="修改管理员密码" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="EditPassword.aspx.cs" Inherits="admin_EditPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f5faff;
            font-family: "Microsoft YaHei", sans-serif;
        }

        .form-container {
            background-color: #ffffff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 15px rgba(0, 91, 172, 0.1);
            width: 90%;
            max-width: 600px;
            margin: 40px auto;
        }

        .form-container h2 {
            text-align: center;
            color: #005bac;
            margin-bottom: 30px;
        }

        .form-group {
            margin-bottom: 18px;
        }

        .form-group label {
            font-weight: bold;
            display: block;
            color: #003366;
            margin-bottom: 6px;
            font-size: 18px;
        }

        .form-group input[type="text"],
        .form-group input[type="password"] {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
        }

        .btn-submit {
            background-color: #005bac;
            color: white;
            border: none;
            padding: 10px;
            width: 100%;
            border-radius: 6px;
            font-size: 18px;
            font-weight: bold;
            cursor: pointer;
            margin-top: 10px;
        }

        .btn-submit:hover {
            background-color: #004080;
        }

        .status-message {
            text-align: center;
            color: red;
            font-size: 14px;
            margin-top: 15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>修改管理员密码</h2>

        <div class="form-group">
            <label>修改用户名（可选）</label>
            <asp:TextBox ID="txtUsername" runat="server" />
        </div>

        <div class="form-group">
            <label>当前密码</label>
            <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" />
        </div>

        <div class="form-group">
            <label>新密码</label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" />
        </div>

        <div class="form-group">
            <label>确认新密码</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
        </div>

        <asp:Button ID="btnUpdatePassword" runat="server" Text="提交修改" CssClass="btn-submit" OnClick="btnUpdatePassword_Click" />

        <asp:Label ID="lblPasswordStatus" runat="server" CssClass="status-message" />
    </div>
</asp:Content>
