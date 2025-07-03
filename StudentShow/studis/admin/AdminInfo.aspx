<%@ Page Title="系统账号管理" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminInfo.aspx.cs" Inherits="admin_AdminInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    body {
        font-family: "Microsoft YaHei", sans-serif;
        background-color: #f5faff;
    }

    .section {
        background: #ffffff;
        border-radius: 12px;
        padding: 30px;
        margin: 40px auto;
        width: 90%;
        max-width: 900px;
        box-shadow: 0 0 15px rgba(0, 91, 172, 0.08);
    }

    .section h2 {
        color: #005bac;

        margin-bottom: 20px;
        text-align: center;
    }

    .table-container {
        width: 100%;
        border-collapse: collapse;
    }

    .table-container th {
        border: 1px solid #ccc;
        padding: 10px;
        text-align: center;
        font-weight: bold;
        background-color: #003366;
color: white;
font-size: 18px;
    }

    .table-container td {
        border: 1px solid #ccc;
padding: 10px;
text-align: center;
font-size: 16px;
    }

    .btn {
    background-color: #005bac;
    color: white;
    border: none;
    padding: 6px 14px;
    border-radius: 6px;
    cursor: pointer;
    font-size: 16px;
    margin: 2px;
    text-decoration: none;
}

    /* 只针对新增按钮加粗 */
.btn-bold {
    font-weight: bold;
    font-size: 18px !important;
}

    .btn:hover {
        background-color: #003e7e;
    }

    .form-inline {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        gap: 15px;
        margin-bottom: 20px;
    }

    .form-inline input {
        padding: 8px;
        width: 240px;
        border: 1px solid #ccc;
        border-radius: 6px;
        font-size: 16px;
    }

    .status-msg {
        color: red;
        text-align: center;
        margin-top: 10px;
    }
    .section h3 {
    color: #005bac;
    font-weight: bold;     /* ✅ 保持加粗 */
    margin-bottom: 20px;
    text-align: center;
}

</style>
<script>
    function confirmDelete() {
        return confirm('你确定要删除这个管理员账号吗？');
    }
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 系统账号列表 -->
<div class="section">
    <h2>系统账号列表</h2>
    <asp:GridView ID="gvAdminList" runat="server" AutoGenerateColumns="False" CssClass="table-container"
        DataKeyNames="AdminID"
        OnRowCommand="gvAdminList_RowCommand">
        <Columns>
            <asp:BoundField DataField="AdminID" HeaderText="编号" ReadOnly="True" />
            <asp:BoundField DataField="AdminName" HeaderText="用户名" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:LinkButton ID="btnChangePwd" runat="server" CommandName="ChangePwd" CommandArgument='<%# Eval("AdminID") %>' Text="修改密码" CssClass="btn" />
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("AdminID") %>' CssClass="btn" OnClientClick="return confirmDelete();" Text="删除" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<!-- 新增管理员账号 -->
<div class="section">
    <h2>新增管理员账号</h2>
    <div class="form-inline">
        <asp:TextBox ID="txtNewAdminName" runat="server" Placeholder="用户名" />
        <asp:TextBox ID="txtNewAdminPass" runat="server" Placeholder="密码" TextMode="Password" />
        <asp:Button ID="btnAddAdmin" runat="server" Text="新增管理员" CssClass="btn btn-bold" OnClick="btnAddAdmin_Click" />
    </div>
    <asp:Label ID="lblMsg" runat="server" CssClass="status-msg" />
</div>

</asp:Content>



