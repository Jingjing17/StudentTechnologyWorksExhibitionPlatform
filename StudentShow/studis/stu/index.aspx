<%@ Page Title="" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="stu_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .welcome-box {
            background-color: #eaf4ff;
            padding: 30px;
            border-radius: 8px;
            text-align: center;
            font-size: 22px;
            font-weight: bold;
            color: #005bac;
            margin-top: 40px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="welcome-box">
        欢迎进入学生端首页！<br />
        请选择左侧菜单进行操作。
    </div>
</asp:Content>

