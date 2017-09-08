<%@ Page Language="C#" AutoEventWireup="true" CodeFile="event_list.aspx.cs" Inherits="event_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>当前活动报名列表</title>
    <meta charset="utf-8" />
    <link rel="icon" type="image/png" href="../assets/img/favicon.ico">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />

    <!-- Bootstrap core CSS     -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!--  Light Bootstrap Dashboard core CSS    -->
    <link href="css/light-bootstrap-dashboard.css" rel="stylesheet" />

    <!--     Fonts and icons     -->
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href='css/685fd913f1e14aebad0cc9d3713ee469.css' rel='stylesheet' type='text/css'>
    <link href="css/pe-icon-7-stroke.css" rel="stylesheet" />
</head>
<body>
    <div class="col-md-12">
        <form runat="server">
            <div class="card card-plain">
                <div class="header">
                    <h4 class="title">活动参与列表</h4>
                    <p class="category">管理报名人员和签到情况</p>
                </div>

                <fieldset>
                    <asp:Label ID="Label1" runat="server" Text="调试label"></asp:Label>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">ID：</label><asp:Label ID="LID" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">名称：</label><asp:Label ID="LName" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">时间：</label><asp:Label ID="LTime" runat="server" Text="Label"></asp:Label>
                    </div>
                </fieldset>
                <div class="content">
                    <div class="container-fluid">
                        <ul role="tablist" class="nav nav-tabs">
                            <li role="presentation" class="active">
                                <a href="#sucess" data-toggle="tab">成功参与</a>
                            </li>
                            <li>
                                <a href="#fail" data-toggle="tab">未签到</a>
                            </li>
                            <li>
                                <a href="#all" data-toggle="tab">所有成员</a>
                            </li>
                        </ul>

                        <div class="tab-content">
                            <div id="sucess" class="tab-pane active">
                                <asp:Table ID="Table1" runat="server" CssClass="table table-hover">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell Width="20%">学号</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">姓名</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">班级</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="40%">签到情况</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div id="fail" class="tab-pane">
                                <asp:Table ID="Table2" runat="server" CssClass="table table-hover table-striped">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell Width="20%">学号</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">姓名</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">班级</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="40%">签到情况</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div id="all" class="tab-pane">
                                <asp:Table ID="Table3" runat="server" CssClass="table table-hover table-striped">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell Width="20%">学号</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">姓名</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">班级</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="40%">签到情况</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>

    </div>

</body>
<script src="../js/jquery.min.js" type="text/javascript"></script>
<script src="../js/jquery-ui.min.js" type="text/javascript"></script>
<script src="../js/bootstrap.min.js" type="text/javascript"></script>

<!--  Forms Validations Plugin -->
<script src="../js/jquery.validate.min.js"></script>

<!--  Select Picker Plugin -->
<script src="../js/bootstrap-selectpicker.js"></script>

<!--  Checkbox, Radio, Switch and Tags Input Plugins -->
<script src="../js/bootstrap-checkbox-radio-switch-tags.js"></script>

<!--  Charts Plugin -->
<script src="../js/chartist.min.js"></script>

<!--  Notifications Plugin    -->
<script src="../js/bootstrap-notify.js"></script>

<!-- Wizard Plugin    -->
<script src="../js/jquery.bootstrap.wizard.min.js"></script>

<!--  Bootstrap Table Plugin    -->
<script src="../js/bootstrap-table.js"></script>

<!--  Plugin for DataTables.net  -->
<script src="../js/jquery.datatables.js"></script>

<!-- Light Bootstrap Dashboard Core javascript and methods -->
<script src="../js/light-bootstrap-dashboard.js"></script>

<!--   Sharrre Library    -->
<script src="../js/jquery.sharrre.js"></script>

<!--   日期选择器    -->
<script src="js/datepicker/WdatePicker.js"></script>
</html>
