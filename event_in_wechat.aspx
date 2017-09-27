<%@ Page Language="C#" AutoEventWireup="true" CodeFile="event_in_wechat.aspx.cs" Inherits="event_in_wechat" %>

<!DOCTYPE html>

<html>
<head>
    <title>活动列表</title>

    <meta charset="utf-8" />
    <link rel="icon" type="image/png" href="../assets/img/favicon.ico">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <!-- Bootstrap core CSS     -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />

    <!--  Light Bootstrap Dashboard core CSS    -->
    <link href="../css/light-bootstrap-dashboard.css" rel="stylesheet" />

    <!--     Fonts and icons     -->
    <link href="../css/font-awesome.min.css" rel="stylesheet">
    <link href="../css/685fd913f1e14aebad0cc9d3713ee469.css" rel="stylesheet">
    <link href="../css/pe-icon-7-stroke.css" rel="stylesheet" />

    <link rel="stylesheet" href="../css/weui.css" />
    <link rel="stylesheet" href="../css/example.css" />


</head>

<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="sidebar" data-color="red" data-image="../image/full-screen-image-1.jpg">
                <!--

            Tip 1: you can change the color of the sidebar using: data-color="blue | azure | green | orange | red | purple"
            Tip 2: you can also add an image using data-image tag

        -->
                <div class="logo">
                    <a href="#" class="logo-text">华罗庚学院
                    </a>
                </div>
                <div class="logo logo-mini">
                    <a href="#" class="logo-text">华罗庚
                    </a>
                </div>

                <div class="sidebar-wrapper">
                    <div class="user">
                        <div class="photo">
                            <img src="image/default_image.jpg" />
                        </div>
                        <div class="info">
                            <a data-toggle="collapse" href="#collapseExample" class="collapsed">

                                <asp:Label ID="Label1" runat="server" Text="Label">姓名</asp:Label>
                            </a>
                        </div>
                    </div>

                    <ul class="nav">
                        <!--这里主要修改激活的项目-->
                        <li class="active">
                            <a href="event_in_wechat.aspx">
                                <i class="pe-7s-graph"></i>
                                <p>活动主页</p>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="main-panel">
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                        <div class="navbar-minimize">
                            <button id="minimizeSidebar" class="btn btn-warning btn-fill btn-round btn-icon">
                                <i class="fa fa-ellipsis-v visible-on-sidebar-regular"></i>
                                <i class="fa fa-navicon visible-on-sidebar-mini"></i>
                            </button>
                        </div>
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse">
                                <span class="sr-only">切换导航</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand" href="#">活动列表</a>
                        </div>
                    </div>
                </nav>

                <div class="content">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="header">
                                    <h4 class="title">管理活动</h4>
                                    <p class="category">切换标签选择不同表格</p>
                                </div>
                                <div class="content">
                                    <div class="container-fluid">
                                        <ul role="tablist" class="nav nav-tabs">
                                            <li role="presentation" class="active">
                                                <a href="#list" data-toggle="tab">可报名活动列表</a>
                                            </li>
                                            <li>
                                                <a href="#history" data-toggle="tab">参加的活动</a>
                                            </li>

                                        </ul>

                                        <div class="tab-content">
                                            <div id="list" class="tab-pane active">
                                                <asp:Table ID="Table1" runat="server" CssClass="table table-hover table-striped">
                                                    <asp:TableHeaderRow>
                                                        <asp:TableHeaderCell Width="15%">名称</asp:TableHeaderCell>
                                                        <asp:TableHeaderCell Width="20%">时间</asp:TableHeaderCell>
                                                        <asp:TableHeaderCell Width="20%">活动类别</asp:TableHeaderCell>
                                                        <asp:TableHeaderCell Width="20%">主办</asp:TableHeaderCell>
                                                        <asp:TableHeaderCell Width="10%">学分</asp:TableHeaderCell>
                                                        <asp:TableHeaderCell Width="15%">操作</asp:TableHeaderCell>
                                                    </asp:TableHeaderRow>
                                                </asp:Table>


                                            </div>
                                            <div id="history" class="tab-pane">
                                                <asp:Table ID="Table2" runat="server" CssClass="table table-hover table-striped">
                                                    <asp:TableHeaderRow>
                                                        <asp:TableHeaderCell Width="10%">名称</asp:TableHeaderCell>
                                                        <asp:TableHeaderCell Width="20%">时间</asp:TableHeaderCell>
                                                        <asp:TableHeaderCell Width="10%">学分</asp:TableHeaderCell>
                                                        <asp:TableHeaderCell Width="40%">状态</asp:TableHeaderCell>
                                                    </asp:TableHeaderRow>
                                                </asp:Table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
    <!--BEGIN toast-->
    <div id="toast" style="display: none;">
        <div class="weui-mask_transparent"></div>
        <div class="weui-toast">
            <i class="weui-icon-success-no-circle weui-icon_toast"></i>
            <p class="weui-toast__content">已完成</p>
        </div>
    </div>

    <script type="text/javascript">
        // toast
        $(function () {
            var $toast = $('#toast');
            $('#showToast').on('click', function () {
                if ($toast.css('display') != 'none') return;

                $toast.fadeIn(100);
                setTimeout(function () {
                    $toast.fadeOut(100);
                }, 2000);
            });
        });

        // loading
        $(function () {
            var $loadingToast = $('#loadingToast');
            $('#showLoadingToast').on('click', function () {
                if ($loadingToast.css('display') != 'none') return;

                $loadingToast.fadeIn(100);
                setTimeout(function () {
                    $loadingToast.fadeOut(100);
                }, 2000);
            });
        });
    </script>

    <!--end toast-->

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
