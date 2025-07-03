<%@ Page Title="个人作品管理" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="WorkPersonList.aspx.cs" Inherits="admin_WorkPersonList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .gridview th {
            padding: 8px;
            border: 1px solid #ccc;
            text-align: center;
            background-color: #003366;
            color: white;
            font-size: 18px;
        }
        .gridview td {
            padding: 8px;
            border: 1px solid #ccc;
            text-align: center;
            font-size: 16px;
        }
        .btn {
            background-color: #005bac;
            color: white;
            padding: 4px 10px;
            text-decoration: none;
            border-radius: 4px;
        }
        .btn:hover {
            background-color: #003e7e;
        }
    </style>
    <script type="text/javascript">
        function confirmDelete() {
            return confirm("确认删除该作品吗？");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align:center; color:#005bac;">学生个人作品管理</h2>

    <asp:GridView ID="gvWorks" runat="server" AutoGenerateColumns="False" CssClass="gridview"
        DataKeyNames="WorkID" OnRowDeleting="gvWorks_RowDeleting">
        <Columns>
            <asp:BoundField DataField="WorkID" HeaderText="作品编号" />
            <asp:BoundField DataField="UserNumber" HeaderText="学生学号" />
            <asp:BoundField DataField="UserName" HeaderText="学生姓名" />
            <asp:BoundField DataField="WorkName" HeaderText="作品名称" />
            <asp:BoundField DataField="WorkCate" HeaderText="作品类别" />
            <asp:BoundField DataField="WorkDes" HeaderText="作品描述" />
            <asp:BoundField DataField="WorkTime" HeaderText="提交时间" />
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


            <asp:TemplateField HeaderText="操作"> 
    <ItemTemplate>
        <a class="btn" href='WorkPersonEdit.aspx?WorkID=<%# Eval("WorkID") %>'>修改</a>
        &nbsp;
        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" 
            Text="删除" CssClass="btn" 
            OnClientClick="return confirmDelete();" />
    </ItemTemplate>
</asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>




