<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/datepicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="col-md-12">
                <div class="card">
                    <div class="header">
                        <legend>添加活动</legend>
                    </div>
                    <div class="content">

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
                                    <label class="col-sm-2 control-label">活动日期：</label>
                                    <div class="col-sm-5">
                                        <asp:TextBox ID="In_Date" runat="server" type="text" class="form-control" OnClick="WdatePicker()"></asp:TextBox>
                                    </div>
                                </div>
                            </fieldset>

                            <fieldset>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">活动时间：</label>
                                    <div class="col-sm-10">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <asp:TextBox ID="In_Hour" runat="server" type="text" placeholder="小时" class="form-control" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false"></asp:TextBox>
                                            </div>

                                            <div class="col-md-2">
                                                <asp:TextBox ID="In_Minutes" runat="server" type="text" placeholder="分钟" class="form-control" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </fieldset>


                            <fieldset>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">参与年级：</label>
                                    <div class="col-sm-10">
                                        <label class="checkbox checkbox-inline">
                                            <asp:CheckBox ID="grade1" runat="server" data-toggle="checkbox" />大一
                                        </label>

                                        <label class="checkbox checkbox-inline">
                                            <asp:CheckBox ID="grade2" runat="server" data-toggle="checkbox" />大二
                                        </label>

                                        <label class="checkbox checkbox-inline">
                                            <asp:CheckBox ID="grade3" runat="server" data-toggle="checkbox" />大三
                                        </label>

                                        <label class="checkbox checkbox-inline">
                                            <asp:CheckBox ID="grade4" runat="server" data-toggle="checkbox" />大四
                                        </label>

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

                            <asp:Button ID="Submit" runat="server" class="btn btn-fill btn-info" Text="提交" Width="50px" OnClick="Submit_Click" />
                        
                    </div>
                </div>
            </div>
        </div>      
    </form>
</body>
</html>
