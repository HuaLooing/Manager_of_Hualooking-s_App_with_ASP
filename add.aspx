<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="add" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>添加活动</title>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <!--这里主要修改激活的项目-->
    <li>
        <a href="index.aspx">
            <i class="pe-7s-graph"></i>
            <p>主页</p>
        </a>
    </li>

    <li class="active">
        <a href="add.aspx">
            <i class="pe-7s-note"></i>
            <p>添加活动</p>
        </a>
    </li>
    <li>
        <a href="manage.aspx">
            <i class="pe-7s-note2"></i>
            <p>管理活动</p>
        </a>
    </li>
    <li>
        <a href="member.aspx">
            <i class="pe-7s-users"></i>
            <p>管理成员</p>
        </a>
    </li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12">
        <div class="card">
            <div class="header">
                <legend>添加活动</legend>
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
                    <asp:Button ID="Submit" runat="server" class="btn btn-fill btn-info" Text="提交" OnClick="Submit_Click" />
                </form>
            </div>


        </div>
    </div>
    <!-- end card -->

    <!-- end col-md-12 -->

</asp:Content>

