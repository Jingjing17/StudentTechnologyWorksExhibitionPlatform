<%@ Page Title="上传作品" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeFile="WorkPersonInfo.aspx.cs" Inherits="stu_WorkPersonInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f5faff;
            font-family: "Microsoft YaHei", sans-serif;
            color: #333;
        }

        .form-container {
            background-color: #ffffff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 12px rgba(0, 91, 172, 0.2);
            width: 85%;
            max-width: 800px;
            margin: 30px auto;
        }

        .form-container h2 {
            color: #005bac;
            text-align: center;
            margin-bottom: 30px;
        }

        .form-group {
            margin-bottom: 18px;
        }

        .form-group label {
            font-weight: bold;
            margin-bottom: 5px;
            display: block;
            color: #003366;
            font-size: 18px;
        }

        .form-group input[type="text"],
        .form-group textarea {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
            font-size: 16px;
        }

        .form-group textarea {
            resize: vertical;
        }

        .form-group input[type="file"] {
            border: none;
            font-size: 16px;
        }

        .btn-upload {
            background-color: #005bac;
            color: white;
            border: none;
            padding: 10px 20px;
            font-size: 18px;
            font-weight: bold;
            border-radius: 6px;
            cursor: pointer;
            width: 100%;
            transition: background 0.3s ease;
        }

        .btn-upload:hover {
            background-color: #004080;
        }

        .status-message {
            text-align: center;
            color: red;
            font-size: 14px;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>上传个人作品</h2>

        <asp:Label ID="lblMsg" runat="server" CssClass="status-message" />

        <div class="form-group">
            <label>作品名称</label>
            <asp:TextBox ID="txtWorkName" runat="server" />
        </div>

        <div class="form-group">
            <label>作品类别</label>
            <asp:TextBox ID="txtWorkCate" runat="server" />
        </div>

        <div class="form-group">
            <label>作品描述</label>
            <asp:TextBox ID="txtWorkDes" runat="server" TextMode="MultiLine" Rows="4" />
        </div>

        <div class="form-group">
            <label>上传视频（mp4）</label>
            <asp:FileUpload ID="fuVideo" runat="server" />
        </div>

        <div class="form-group">
            <label>上传图片（jpg/png）</label>
            <asp:FileUpload ID="fuImage" runat="server" />
        </div>

        <div class="form-group">
            <label>上传源码说明（zip/rar）</label>
            <asp:FileUpload ID="fuZip" runat="server" />
        </div>

        <asp:Button ID="btnUpload" runat="server" Text="上传作品" CssClass="btn-upload" OnClick="btnUpload_Click" />
    </div>
</asp:Content>


