<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuManage.aspx.cs" Inherits="admin_StuManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WorkDataBaseConnectionString %>" SelectCommand="SELECT * FROM [StudentInfo]" DeleteCommand="DELETE FROM [StudentInfo] WHERE [UserID] = @original_UserID" InsertCommand="INSERT INTO [StudentInfo] ([UserName], [UserSex], [UserNumber], [UserPass], [UserXy], [UserZy], [UserBj], [UserAddTime]) VALUES (@UserName, @UserSex, @UserNumber, @UserPass, @UserXy, @UserZy, @UserBj, @UserAddTime)" UpdateCommand="UPDATE [StudentInfo] SET [UserName] = @UserName, [UserSex] = @UserSex, [UserNumber] = @UserNumber, [UserPass] = @UserPass, [UserXy] = @UserXy, [UserZy] = @UserZy, [UserBj] = @UserBj, [UserAddTime] = @UserAddTime WHERE [UserID] = @original_UserID" OldValuesParameterFormatString="original_{0}">
                <DeleteParameters>
                    <asp:Parameter Name="original_UserID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="UserName" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="TextBox2" Name="UserSex" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="TextBox3" Name="UserNumber" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="TextBox4" Name="UserPass" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="TextBox5" Name="UserXy" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="TextBox6" Name="UserZy" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="TextBox7" Name="UserBj" PropertyName="Text" Type="String" />
                    <asp:Parameter Name="UserAddTime" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="UserName" Type="String" />
                    <asp:Parameter Name="UserSex" Type="String" />
                    <asp:Parameter Name="UserNumber" Type="String" />
                    <asp:Parameter Name="UserPass" Type="String" />
                    <asp:Parameter Name="UserXy" Type="String" />
                    <asp:Parameter Name="UserZy" Type="String" />
                    <asp:Parameter Name="UserBj" Type="String" />
                    <asp:Parameter Name="UserAddTime" Type="String" />
                    <asp:Parameter Name="original_UserID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="学生编号" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                    <asp:BoundField DataField="UserName" HeaderText="学生姓名" SortExpression="UserName" />
                    <asp:BoundField DataField="UserSex" HeaderText="学生性别" SortExpression="UserSex" />
                    <asp:BoundField DataField="UserNumber" HeaderText="学生学号" SortExpression="UserNumber" />
                    <asp:BoundField DataField="UserPass" HeaderText="学生登录密码" SortExpression="UserPass" />
                    <asp:BoundField DataField="UserXy" HeaderText="学生所在学院" SortExpression="UserXy" />
                    <asp:BoundField DataField="UserZy" HeaderText="学生所在专业" SortExpression="UserZy" />
                    <asp:BoundField DataField="UserBj" HeaderText="学生所在班级" SortExpression="UserBj" />
                    <asp:BoundField DataField="UserAddTime" HeaderText="学生账号添加日期" SortExpression="UserAddTime" />
                    
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">编辑</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" OnClientClick="return confirm('是否确定删除？')">删除</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update">更新</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">取消</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            <br />
            <br />
            姓名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            性别：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            学号：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
            登录密码：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
            学院：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
            专业：<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />
            班级：<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="新增" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
