<%@ Page Title="团队作品修改" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="WorkTuanDuiEdit.aspx.cs" Inherits="admin_WorkTuanDuiEdit" %>

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
            box-shadow: 0 0 15px rgba(0, 91, 172, 0.2);
            width: 90%;
            max-width: 800px;
            margin: 40px auto;
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
            display: block;
            color: #003366;
            margin-bottom: 6px;
            font-size: 18px;
        }

        .form-group input[type="text"],
        .form-group textarea {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 6px;
            box-sizing: border-box;
        }

        .form-group textarea {
            resize: vertical;
        }

        .form-group input[type="file"] {
            margin-top: 4px;
        }

        .btn-submit {
            background-color: #005bac;
            color: white;
            border: none;
            padding: 12px;
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
        <h2>修改团队作品</h2>

        <div class="form-group">
            <label>团队名称</label>
            <asp:TextBox ID="txtTdmc" runat="server" />
        </div>

        <div class="form-group">
            <label>作品名称</label>
            <asp:TextBox ID="txtWorkName" runat="server" />
        </div>

        <div class="form-group">
            <label>类别</label>
            <asp:TextBox ID="txtWorkCate" runat="server" />
        </div>

        <div class="form-group">
            <label>作品描述</label>
            <asp:TextBox ID="txtWorkDes" runat="server" TextMode="MultiLine" Rows="4" />
        </div>

        <div class="form-group">
            <label>组长学号</label>
            <asp:TextBox ID="txtUser1" runat="server" />
            <label>组长工作</label>
            <asp:TextBox ID="txtUser1Des" runat="server" TextMode="MultiLine" Rows="2" />
        </div>

        <div class="form-group">
            <label>组员1学号</label>
            <asp:TextBox ID="txtUser2" runat="server" />
            <label>组员1工作</label>
            <asp:TextBox ID="txtUser2Des" runat="server" TextMode="MultiLine" Rows="2" />
        </div>

        <div class="form-group">
            <label>组员2学号</label>
            <asp:TextBox ID="txtUser3" runat="server" />
            <label>组员2工作</label>
            <asp:TextBox ID="txtUser3Des" runat="server" TextMode="MultiLine" Rows="2" />
        </div>

        <div class="form-group">
            <label>作品图片</label>
            <asp:FileUpload ID="fuImage" runat="server" />
        </div>

        <div class="form-group">
            <label>作品视频</label>
            <asp:FileUpload ID="fuVideo" runat="server" />
        </div>

        <div class="form-group">
            <label>源码压缩包</label>
            <asp:FileUpload ID="fuZip" runat="server" />
        </div>

        <asp:Button ID="btnSave" runat="server" Text="保存修改" OnClick="btnSave_Click" CssClass="btn-submit" />
        <asp:Label ID="lblMsg" runat="server" CssClass="status-message" />
    </div>
</asp:Content>



