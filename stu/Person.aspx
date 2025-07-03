<%@ Page Title="个人信息管理" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeFile="Person.aspx.cs" Inherits="stu_Person" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .info-box {
            background-color: #ffffff;
            border: 2px solid #d9e2ec;
            border-radius: 12px;
            width: 60%;
            margin: 30px auto;
            padding: 30px;
            font-family: "Microsoft YaHei", sans-serif;
            box-shadow: 0 0 12px rgba(0, 0, 0, 0.05);
        }

        .info-box h2 {
            text-align: center;
            color: #005bac;
            margin-bottom: 20px;
        }

        .info-item {
            margin-bottom: 18px;
            font-size: 18px;
        }

        .info-label {
            font-weight: bold;
            color: #003366;
            display: inline-block;
            width: 100px;
        }

        .info-value {
            color: #333;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="info-box">
        <h2>当前学生信息</h2>

        <div class="info-item">
            <span class="info-label">姓名：</span>
            <asp:Label ID="lblName" runat="server" CssClass="info-value" />
        </div>

        <div class="info-item">
            <span class="info-label">性别：</span>
            <asp:Label ID="lblSex" runat="server" CssClass="info-value" />
        </div>

        <div class="info-item">
            <span class="info-label">学号：</span>
            <asp:Label ID="lblNumber" runat="server" CssClass="info-value" />
        </div>

        <div class="info-item">
            <span class="info-label">学院：</span>
            <asp:Label ID="lblXy" runat="server" CssClass="info-value" />
        </div>

        <div class="info-item">
            <span class="info-label">专业：</span>
            <asp:Label ID="lblZy" runat="server" CssClass="info-value" />
        </div>

        <div class="info-item">
            <span class="info-label">班级：</span>
            <asp:Label ID="lblBj" runat="server" CssClass="info-value" />
        </div>
    </div>
</asp:Content>



