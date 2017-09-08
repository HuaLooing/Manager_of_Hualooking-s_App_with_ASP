<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="member_add.aspx.cs" Inherits="member_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <li>
        <a href="index.aspx">
            <i class="pe-7s-graph"></i>
            <p>主页</p>
        </a>
    </li>

    <li>
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
        <a data-toggle="collapse" href="#componentsExamples" aria-expanded="true">
            <i class="pe-7s-users"></i>
            <p>
                成员管理<b class="caret"></b>
            </p>
        </a>
        <div class="collapse in" id="componentsExamples">
            <ul class="nav">
                <li class="active"><a href="member_add.aspx">管理员管理</a></li>
                <li><a href="member.aspx">各班信息查询及管理</a></li>
            </ul>
        </div>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="header">
                    <h4 class="title">管理成员</h4>
                    <p class="category">此功能仅向超级管理员开放</p>
                </div>
                <div class="content">
                    <div class="container-fluid">
                        <ul role="tablist" class="nav nav-tabs">
                            <li id="ContentPlaceHolder1_tab1" role="presentation" class="active">
                                <a href="#add" data-toggle="tab">添加管理员</a>

                            </li>
                            <li id="ContentPlaceHolder1_tab2">
                                <a href="#list" data-toggle="tab">管理员列表</a>
                            </li>
                        </ul>

                        <div class="tab-content">
                             <div id="add" class="tab-pane active">
                                <div class="col-md-12">

                                    <div class="header">
                                        <legend>仅能添加普通管理员，需要添加超级管理员请与网站管理员联系</legend>
                                    </div>
                                    <div class="content">
                                        <form class="form-horizontal" runat="server">

                                            <fieldset>
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">账号：</label>
                                                    <div class="col-sm-5">
                                                        <asp:TextBox ID="In_ID" runat="server" type="text" class="form-control" MaxLength="8"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </fieldset>

                                            <fieldset>
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">姓名：</label>
                                                    <div class="col-sm-3">
                                                        <asp:TextBox ID="In_Name" runat="server" type="text" placeholder="默认无限制" class="form-control" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57)) event.returnValue=false" MaxLength="10"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </fieldset>

                                            <fieldset>
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">密码：</label>
                                                    <div class="col-sm-5">
                                                        <asp:TextBox ID="In_Code1" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </fieldset>
                                            <fieldset>
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">确认密码：</label>
                                                    <div class="col-sm-5">
                                                        <asp:TextBox ID="In_Code2" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                                        <asp:Label ID="Label1" runat="server" class="error" ForeColor="#FB404B"></asp:Label>
                                                    </div>
                                                </div>
                                            </fieldset>

                                            <asp:Button ID="Submit" runat="server" class="btn btn-fill btn-info" Text="提交" OnClick="Submit_Click" />
                                        </form>
                                    </div>


                                </div>
                            </div>
                            <div id="list" class="tab-pane">
                                <asp:Table ID="Table1" runat="server" CssClass="table table-hover table-striped" Visible="true">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell Width="20%">登录账号</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="30%">姓名</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%">密码</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%">权限</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="10%">编辑</asp:TableHeaderCell>

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

</asp:Content>

