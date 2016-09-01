<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" 
                    SortExpression="username" />
                <asp:BoundField DataField="firstname" HeaderText="firstname" 
                    SortExpression="firstname" />
                <asp:BoundField DataField="lastname" HeaderText="lastname" 
                    SortExpression="lastname" />
                <asp:BoundField DataField="CHECKTIME" HeaderText="CHECKTIME" 
                    SortExpression="CHECKTIME" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ATTBACKUPSQLConnectionString3 %>" 
            SelectCommand="SELECT userlogin.username, userlogin.firstname, userlogin.lastname, CHECKINOUT.CHECKTIME FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
