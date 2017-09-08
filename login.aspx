<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <meta charset="utf-8" />
    <title>登录</title>
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <!-- Bootstrap core CSS     -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />

    <!--  Light Bootstrap Dashboard core CSS    -->
    <link href="css/light-bootstrap-dashboard.css" rel="stylesheet" />

    <!--     Fonts and icons     -->
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href='css/685fd913f1e14aebad0cc9d3713ee469.css' rel='stylesheet' type='text/css' />
    <link href="css/pe-icon-7-stroke.css" rel="stylesheet" />

    <link href="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/6.6.9/sweetalert2.css" rel="stylesheet" type="text/css" />
    
    
</head>



<body>
    <nav class="navbar navbar-transparent navbar-absolute">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand">常州大学华罗庚学院荣誉学分管理系统</a>
                <br>
                <a href="Table.html">表结构！！！！！</a>
            </div>      
        </div>
    </nav>

    <div class="wrapper wrapper-full-page">
        <div class="full-page login-page" data-color="black">
            <!--   使用 data-color="blue | azure | green | orange | red | purple" 更改主题颜色-->

            <div class="content">
                <div class="container">
                    <div class="row">
                        <div class="col-md-4 col-sm-6 col-md-offset-4 col-sm-offset-3">
                            <form runat="server">


                                <div class="card">
                                    <div class="header text-center">管理员登录</div>
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

            <footer class="footer footer-transparent">
                <div class="container">
                    <p class="copyright pull-right">
                        &copy; 2017 <a href="#">Weicheng97.cn </a>
                    </p>
                </div>
            </footer>
          
            <!--更换背景地址-->
            <div class="full-page-background" style="background-image: url(&quot;image/full-screen-image-1.jpg&quot;); display: block;"></div>
        </div>

    </div>


</body>

<!--   Core JS Files and PerfectScrollbar library inside jquery.ui   -->
<script src="../js/jquery.min.js" type="text/javascript"></script>
<script src="../js/jquery-ui.min.js" type="text/javascript"></script>
<script src="../js/bootstrap.min.js" type="text/javascript"></script>

<script src="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/6.6.9/sweetalert2.min.js" type="text/javascript"></script>

    
</html>
