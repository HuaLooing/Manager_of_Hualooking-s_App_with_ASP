<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Manage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>管理活动</title>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <!--这里主要修改激活的项目-->
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
    <li class="active">
        <a href="manage.aspx">
            <i class="pe-7s-note2"></i>
            <p>管理活动</p>
        </a>
    </li>
    <li>
        <a data-toggle="collapse" href="#componentsExamples">
            <i class="pe-7s-users"></i>
            <p>
                成员管理<b class="caret"></b>
            </p>
        </a>
        <div class="collapse" id="componentsExamples">
            <ul class="nav">
                <li><a href="member_add.aspx">管理员管理</a></li>
                <li><a href="member.aspx">各班信息查询及管理</a></li>
            </ul>
        </div>
    </li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <a href="#list" data-toggle="tab">列表</a>
                            </li>
                            <li>
                                <a href="#history" data-toggle="tab">历史</a>
                            </li>
                            <li>
                                <a href="#exam" data-toggle="tab">审核</a>
                            </li>
                        </ul>

                        <div class="tab-content">
                            <div id="list" class="tab-pane active">
                                <asp:Table ID="Table1" runat="server" CssClass="table table-hover table-striped">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell Width="5%">编号</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="10%">名称</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%">时间</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">参与年级</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">容量</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="10%">学分</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="10%">活动类别</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">编辑</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>


                            </div>
                            <div id="history" class="tab-pane">
                                <asp:Table ID="Table2" runat="server" CssClass="table table-hover table-striped">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell Width="5%">编号</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="10%">名称</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="20%">时间</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">参与年级</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">容量</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="10%">学分</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="10%">活动类别</asp:TableHeaderCell>
                                        <asp:TableHeaderCell Width="15%">编辑</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>

                            <div id="exam" class="tab-pane">
                                功能完善中，尚未开放！
                            <!--<asp:Table ID="Table3" runat="server" CssClass="table table-hover table-striped">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell Width="5%">ID</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Width="15%">名称</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Width="25%">时间</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Width="20%">状态</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Width="10%">举办者</asp:TableHeaderCell>
                                    <asp:TableHeaderCell Width="5%">编辑</asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                                <asp:TableRow>
                                    <asp:TableCell>1</asp:TableCell>
                                    <asp:TableCell>人文之光</asp:TableCell>
                                    <asp:TableCell>YYYY:MM:DD HH:MM</asp:TableCell>
                                    <asp:TableCell>报名中(50/52)</asp:TableCell>
                                    <asp:TableCell>Weicheng</asp:TableCell>
                                    <asp:TableCell CssClass="text-right">
                                        <a href="#" class="btn btn-simple btn-warning btn-icon edit"><i class="fa fa-edit" onclick=""></i></a>
                						<a href="#" class="btn btn-simple btn-danger btn-icon remove"><i class="fa fa-times"></i></a></asp:TableCell>
                                    </asp:TableRow>
                            </asp:Table>
                          </div> -->

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
