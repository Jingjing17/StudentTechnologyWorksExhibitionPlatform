<%@ Page Title="团队作品管理" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="WorkTuanDuiList.aspx.cs" Inherits="admin_WorkTuanDuiList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        .btn {
            padding: 4px 10px;
            border-radius: 4px;
            background-color: #005bac;
            color: white;
            text-decoration: none;
        }
        .btn:hover {
            background-color: #003e7e;
        }
    </style>
    <script>
        function confirmDelete() {
            return confirm("你确定要删除这条团队作品吗？");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align:center; color:#005bac;">学生团队作品管理</h2>

    <asp:GridView ID="gvTeamWorks" runat="server" AutoGenerateColumns="False"
        CssClass="gridview" DataKeyNames="WorkID"
        OnRowDeleting="gvTeamWorks_RowDeleting">
        <Columns>
            <asp:BoundField DataField="WorkID" HeaderText="作品编号">
                <HeaderStyle Width="60px" />
                <ItemStyle Width="60px" />
            </asp:BoundField>

            <asp:BoundField DataField="tdmc" HeaderText="团队名称">
                <HeaderStyle Width="120px" />
                <ItemStyle Width="120px" />
</asp:BoundField>

            <asp:BoundField DataField="WorkName" HeaderText="作品名称">
                <HeaderStyle Width="120px" />
                <ItemStyle Width="120px" />
</asp:BoundField>

            <asp:BoundField DataField="WorkCate" HeaderText="类别">
                <HeaderStyle Width="80px" />
                <ItemStyle Width="80px" />
</asp:BoundField>

            <asp:BoundField DataField="WorkDes" HeaderText="描述">
                <HeaderStyle Width="150px" />
                <ItemStyle Width="150px" />
</asp:BoundField>

            <asp:BoundField DataField="WorkTime" HeaderText="上传时间">
                <HeaderStyle Width="100px" />
                <ItemStyle Width="100px" />
</asp:BoundField>

            <asp:TemplateField HeaderText="作品分工">
                <HeaderStyle Width="100px" />
                <ItemStyle Width="100px" />
    <ItemTemplate>
        <%# Eval("UserNumber_1") + " " + Eval("UserName_1") + "：" %><br />
        <%# Eval("UserNumber_1_des") %><br /><br />

        <%# Eval("UserNumber_2") + " " + Eval("UserName_2") + "：" %><br />
        <%# Eval("UserNumber_2_des") %><br /><br />

        <%# Eval("UserNumber_3") + " " + Eval("UserName_3") + "：" %><br />
        <%# Eval("UserNumber_3_des") %><br />
    </ItemTemplate>
</asp:TemplateField>


            <asp:TemplateField HeaderText="作品图片">
                <HeaderStyle Width="100px" />
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <img src='<%# ResolveUrl(Eval("WorkPicUrl").ToString()) %>' class="img-preview" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="作品视频">
                <HeaderStyle Width="160px" />
                <ItemStyle Width="160px" />
                <ItemTemplate>
                    <video width="160" height="100" controls>
                        <source src='<%# ResolveUrl(Eval("WorkUrl").ToString()) %>' type="video/mp4" />
                        浏览器不支持视频播放
                    </video>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="源码下载">
                <HeaderStyle Width="60px" />
                <ItemStyle Width="60px" />
                <ItemTemplate>
                    <a href='<%# ResolveUrl(Eval("WorkZipUrl").ToString()) %>' target="_blank">下载压缩包</a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="操作">
                <HeaderStyle Width="160px" />
                <ItemStyle Width="160px" />
                <ItemTemplate>
                    <a class="btn" href='WorkTuanDuiEdit.aspx?WorkID=<%# Eval("WorkID") %>'>修改</a>
                    &nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete"
                        Text="删除" CssClass="btn" OnClientClick="return confirmDelete();" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

