<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shake_in_wechat.aspx.cs" Inherits="shake_in_wechat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0">
    <link href="../css/weui.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>活动签到</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="page">
                <div id="div1" class="weui-msg" runat="server">
                    <div class="weui-msg__icon-area"><i class="weui-icon-success weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">签到成功</h2>
                        <p class="weui-msg__desc">欢迎参加<asp:Label ID="Label1" runat="server" Text="本次活动"></asp:Label><br/>开始时间:<asp:Label ID="Label2" runat="server" Text="Null"></asp:Label>
                    </div>
                    
                </div>

                <div id="div2" class="weui-msg" runat="server">
                    <div class="weui-msg__icon-area"><i class="weui-icon-warn weui-icon_msg"></i></div>
                    <div class="weui-msg__text-area">
                        <h2 class="weui-msg__title">签到失败</h2>
                        <p class="weui-msg__desc">没有可签到的活动
                    </div>
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
