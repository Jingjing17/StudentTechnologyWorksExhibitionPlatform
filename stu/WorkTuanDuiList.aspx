<%@ Page Title="查看团队作品" Language="C#" MasterPageFile="~/stu/MasterPage.master" AutoEventWireup="true" CodeFile="WorkTuanDuiList.aspx.cs" Inherits="stu_WorkTuanDuiList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .gridview {
            margin: 20px auto;
            width: 96%;
            border-collapse: collapse;
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
        .gridview tr:nth-child(even) {
            background-color: #f3f3f3;
        }
        .img-preview {
            height: 80px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 style="text-align:center; color:#005bac;">我的团队作品</h2>

    <asp:GridView ID="gvTeamWorks" runat="server" AutoGenerateColumns="False" CssClass="gridview">
        <Columns>
            <asp:BoundField DataField="WorkID" HeaderText="作品编号" />
            <asp:BoundField DataField="tdmc" HeaderText="团队名称" />
            <asp:BoundField DataField="WorkName" HeaderText="作品名称" />
            <asp:BoundField DataField="WorkCate" HeaderText="类别" />
            <asp:BoundField DataField="WorkDes" HeaderText="作品描述" />
            <asp:BoundField DataField="WorkTime" HeaderText="上传时间" />

            <asp:TemplateField HeaderText="作品分工">
    <ItemTemplate>
        <%# Eval("UserNumber_1") + " " + Eval("UserName_1") + "：" + Eval("UserNumber_1_des") %><br />
        <%# Eval("UserNumber_2") + " " + Eval("UserName_2") + "：" + Eval("UserNumber_2_des") %><br />
        <%# Eval("UserNumber_3") + " " + Eval("UserName_3") + "：" + Eval("UserNumber_3_des") %>
    </ItemTemplate>
</asp:TemplateField>



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


