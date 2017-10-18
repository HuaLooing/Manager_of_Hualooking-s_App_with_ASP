<%@ Page Language="C#" AutoEventWireup="true" CodeFile="log_check.aspx.cs" Inherits="log_check" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

                        <asp:Table ID="Table1" runat="server">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell >id</asp:TableHeaderCell>
                                <asp:TableHeaderCell >logaction</asp:TableHeaderCell>
                                <asp:TableHeaderCell >logcont</asp:TableHeaderCell>
                                <asp:TableHeaderCell >ip</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
        </div>
    </form>
</body>
</html>
