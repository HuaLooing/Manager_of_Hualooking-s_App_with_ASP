<%@ Page Language="C#" AutoEventWireup="true" CodeFile="event_m.aspx.cs" Inherits="event_m" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改活动</title>
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
    <div class="content">
        <div class="col-md-12">
            <div class="card">
                <div class="header">
                    <legend>修改/删除活动</legend>
                </div>
                <div class="content">
                    <form class="form-horizontal" runat="server">
                        <fieldset>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">活动名称：</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="In_Name" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>

                        <fieldset>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">活动学分：</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="In_Grade" runat="server" type="text" class="form-control" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">活动日期：</label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="In_Date" runat="server" type="text" class="form-control" OnClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>

                        <fieldset>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">参与年级：</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="g1" runat="server" Text="" class="checkbox checkbox-inline">
                                        <asp:CheckBox ID="grade1" runat="server" data-toggle="checkbox" />大一
                                    </asp:Label>

                                    <asp:Label ID="g2" runat="server" Text="" class="checkbox checkbox-inline">
                                        <asp:CheckBox ID="grade2" runat="server" data-toggle="checkbox" />大二
                                    </asp:Label>

                                    <asp:Label ID="g3" runat="server" Text="" class="checkbox checkbox-inline">
                                        <asp:CheckBox ID="grade3" runat="server" data-toggle="checkbox" />大二
                                    </asp:Label>
                                    <asp:Label ID="g4" runat="server" Text="" class="checkbox checkbox-inline">
                                        <asp:CheckBox ID="grade4" runat="server" data-toggle="checkbox" />大四
                                    </asp:Label>

                                </div>
                            </div>
                        </fieldset>

                        <fieldset>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">人数限制：</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="In_Limit" runat="server" type="text" placeholder="默认无限制" class="form-control" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>

                        <fieldset>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">负责人：</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="In_Hoster" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>

                        <fieldset>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">活动内容：</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="In_Content" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">活动种类：</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="In_Kind" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>
                        <asp:Button ID="Submit" runat="server" class="btn btn-fill btn-info" Text="提交" OnClick="Submit_Click" />

                        <asp:Button ID="Cancel" runat="server" class="btn btn-fill btn-danger" Text="放弃" OnClick="Cancel_Click" />
                    </form>
                </div>


            </div>
        </div>

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
