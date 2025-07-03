<%@ Page Title="学生管理" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="StudentList.aspx.cs" Inherits="admin_StudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        .gridview th {
            padding: 8px;
            border: 1px solid #ccc;
            text-align: center;
            font-size: 18px;
            background-color: #003366;
            color: white;
        }
        .gridview td {
            padding: 8px;
border: 1px solid #ccc;
text-align: center;
            font-size: 16px;
        }
        .form-container {
            background: #f8fbff;
            padding: 20px;
            border: 1px solid #ddd;
            width: 80%;
            margin: auto;
            border-radius: 8px;
        }
        .form-container input {
            margin: 5px;
            padding: 6px;
            width: 180px;
        }
        .btn {
            background-color: #005bac;
            color: white;
            border: none;
            padding: 6px 14px;
            cursor: pointer;
            border-radius: 6px;
            font-size: 16px;
        }
        .btn:hover {
            background-color: #003e7e;
        }
        .btn-bold {
    font-weight: bold;
    font-size: 18px;
}
        .gridview {
    width: 100%;
    table-layout: fixed;
    word-wrap: break-word;
}
.gridview td input {
    width: 95%;
    box-sizing: border-box;
}
.gridview th, .gridview td {
    max-width: 150px;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
}
.form-container {
    background: #ffffff;
    padding: 40px;
    border: 1px solid #ccc;
    border-radius: 12px;
    width: 400px;
    margin: 40px auto;
    box-shadow: 0 0 12px rgba(0, 91, 172, 0.1);
    text-align: center;
}

.form-title {
    color: #005bac;
    margin-bottom: 25px;

    font-weight: bold;
}

.form-input-full {
    width: 100%;
    padding: 10px;
    margin-bottom: 14px;
    border: 1px solid #ccc;
    border-radius: 6px;
    font-size: 16px;
    box-sizing: border-box;
}

.status-msg {
    color: red;
    font-size: 14px;
    margin-bottom: 12px;
    display: block;
}
/* 移除 GridView 中的 LinkButton 下划线 */
.gridview .btn {
    text-decoration: none !important;
}

/* 鼠标悬停时也不出现下划线 */
.gridview .btn:hover {
    text-decoration: none !important;
}


    </style>
    <script>
        function confirmDelete() {
            return confirm('你确定要删除这位学生吗？');
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align:center; color:#005bac;">学生信息管理</h2>

    <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" CssClass="gridview"
        Style="table-layout:fixed; width:100%;"
        OnRowEditing="gvStudent_RowEditing"
        OnRowCancelingEdit="gvStudent_RowCancelingEdit"
        OnRowUpdating="gvStudent_RowUpdating"
        OnRowDeleting="gvStudent_RowDeleting"
        DataKeyNames="UserID">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="编号">
    <HeaderStyle Width="60px" />
    <ItemStyle Width="60px" />
</asp:BoundField>

            <asp:BoundField DataField="UserName" HeaderText="姓名" />
            <asp:BoundField DataField="UserSex" HeaderText="性别" />
            <asp:BoundField DataField="UserNumber" HeaderText="学号" />
            <asp:BoundField DataField="UserPass" HeaderText="密码" />
            <asp:BoundField DataField="UserXy" HeaderText="学院" />
            <asp:BoundField DataField="UserZy" HeaderText="专业" />
            <asp:BoundField DataField="UserBj" HeaderText="班级" />
            <asp:BoundField DataField="UserAddTime" HeaderText="添加时间" />

            <asp:TemplateField HeaderText="操作">
    <HeaderStyle Width="160px" />
    <ItemStyle Width="160px" />
    <ItemTemplate>
        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="编辑" CssClass="btn" />
        &nbsp;
        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="删除"
            OnClientClick="return confirm('你确定要删除这位学生吗？');"
            CssClass="btn btn-red" />
    </ItemTemplate>
    <EditItemTemplate>
        <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="更新" CssClass="btn" />
        &nbsp;
        <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="取消" CssClass="btn" />
    </EditItemTemplate>
</asp:TemplateField>





        </Columns>
    </asp:GridView>

    <div class="form-container">
    <h2 class="form-title">新增学生信息</h2>

    <asp:Label ID="lblMsg" runat="server" CssClass="status-msg" />

    <asp:TextBox ID="txtName" runat="server" CssClass="form-input-full" Placeholder="姓名" /><br />
    <asp:TextBox ID="txtSex" runat="server" CssClass="form-input-full" Placeholder="性别" /><br />
    <asp:TextBox ID="txtNumber" runat="server" CssClass="form-input-full" Placeholder="学号" /><br />
    <asp:TextBox ID="txtPass" runat="server" CssClass="form-input-full" Placeholder="密码" /><br />
    <asp:TextBox ID="txtXy" runat="server" CssClass="form-input-full" Placeholder="学院" /><br />
    <asp:TextBox ID="txtZy" runat="server" CssClass="form-input-full" Placeholder="专业" /><br />
    <asp:TextBox ID="txtBj" runat="server" CssClass="form-input-full" Placeholder="班级" /><br />

    <div style="text-align:center; margin-top: 20px;">
        <asp:Button ID="btnAdd" runat="server" Text="新增学生" CssClass="btn btn-bold" OnClick="btnAdd_Click" />

    </div>
</div>


</asp:Content>
