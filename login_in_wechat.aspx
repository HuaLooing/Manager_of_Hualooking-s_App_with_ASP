<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login_in_wechat.aspx.cs" Inherits="login_in_wechat" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <title>登录</title>
    <link rel="icon" type="image/png" href="../assets/img/favicon.ico" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <!-- Bootstrap core CSS     -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />

    <!--  Light Bootstrap Dashboard core CSS    -->
    <link href="../css/light-bootstrap-dashboard.css" rel="stylesheet" />

    <!--     Fonts and icons     -->
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/685fd913f1e14aebad0cc9d3713ee469.css" rel="stylesheet" />
    <link href="../css/pe-icon-7-stroke.css" rel="stylesheet" />

    <link rel="stylesheet" href="../css/weui.css" />
    <link rel="stylesheet" href="../css/example.css" />
    <link href="../Libraries/sweetalert/css/sweetalert2.css" rel="stylesheet" />

    <script src="../Libraries/sweetalert/js/sweetalert2.js"></script>


</head>

<body>
    <nav class="navbar navbar-transparent navbar-absolute">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand">华罗庚学院荣誉学分管理系统</a>
            </div>
        </div>
    </nav>

    <div class="wrapper wrapper-full-page">
        <div class="full-page login-page" data-color="red">
            <!--   使用 data-color="blue | azure | green | orange | red | purple" 更改主题颜色-->

            <div class="content">
                <div class="container">
                    <div class="row">
                        <div class="col-md-4 col-sm-6 col-md-offset-4 col-sm-offset-3">
                            <form runat="server">


                                <div class="card">
                                    <div class="header text-center">学号绑定</div>

                                    <div class="content">
                                        <div class="form-group">
                                            <label>账号</label>
                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>密码</label>
                                            <asp:TextBox ID="TextBox2" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="footer text-center">
                                        <asp:Button ID="Button1" runat="server" Text="登录" class="btn btn-fill btn-warning btn-wd" OnClick="Button1_Click" />
                                    </div>
                                </div>

                            </form>

                        </div>
                    </div>
                </div>
            </div>
            <!--更换背景地址-->
            <!--div class="full-page-background" style="background-image: url(&quot;image/full-screen-image-1.jpg&quot;); display: block;"></div-->
        </div>

    </div>


</body>

<!--   Core JS Files and PerfectScrollbar library inside jquery.ui   -->
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
</html>
