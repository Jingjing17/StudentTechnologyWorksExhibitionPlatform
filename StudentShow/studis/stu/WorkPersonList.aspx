<%@ Page Title="个人作品列表" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeFile="WorkPersonList.aspx.cs" Inherits="stu_WorkPersonList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .gridview {
            margin: 20px auto;
            width: 95%;
            border-collapse: collapse;
        }
        .gridview th {
            padding: 10px;
            border: 1px solid #ccc;
            text-align: center;
            font-size: 18px;
            background-color: #003366;
color: white;
        }
        .gridview td {
            padding: 10px;
border: 1px solid #ccc;
text-align: center;
            font-size: 16px;
        }
        .gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        .img-preview {
            height: 80px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 style="text-align:center; color:#005bac;">我的上传作品</h2>

    <asp:GridView ID="gvWorks" runat="server" AutoGenerateColumns="False" CssClass="gridview">
        <Columns>
            <asp:BoundField DataField="WorkID" HeaderText="作品编号" />
            <asp:BoundField DataField="WorkName" HeaderText="作品名称" />
            <asp:BoundField DataField="WorkCate" HeaderText="类别" />
            <asp:BoundField DataField="WorkDes" HeaderText="作品描述" />
            <asp:BoundField DataField="WorkTime" HeaderText="上传时间" />

                       <asp:TemplateField HeaderText="作品图片">
    <ItemTemplate>
        <img src='<%# ResolveUrl(Eval("WorkPicUrl").ToString()) %>' alt="作品图片" style="max-height: 80px;" />
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="作品视频">
    <ItemTemplate>
        <video width="160" height="100" controls>
            <source src='<%# ResolveUrl(Eval("WorkUrl").ToString()) %>' type="video/mp4" />
            您的浏览器不支持 video 标签。
        </video>
    </ItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="源码下载">
    <ItemTemplate>
        <a href='<%# ResolveUrl(Eval("WorkZipUrl").ToString()) %>' target="_blank">下载压缩包</a>
    </ItemTemplate>
</asp:TemplateField>


            
        </Columns>
    </asp:GridView>
</asp:Content>

