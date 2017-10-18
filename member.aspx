<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="member.aspx.cs" Inherits="member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>管理成员</title>
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
        <a data-toggle="collapse" href="#componentsExamples">
            <i class="pe-7s-users"></i>
            <p>
                成员管理<b class="caret"></b>
            </p>
        </a>
        <div class="collapse in" id="componentsExamples" aria-expanded="true">
            <ul class="nav">
                <li><a href="member_add.aspx">管理员管理</a></li>
                <li class="active"><a href="member.aspx">各班信息查询及管理</a></li>
            </ul>
        </div>
    </li>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="header">
                    <h4 class="title">各班成员信息查询</h4>
                    <p class="category">选择班级</p>
                </div>
                <form class="form-group" runat="server">
                    <fieldset>
                        <div class="form-group">
                            <div class="col-sm-5">
                                <asp:TextBox ID="In_Class" runat="server" type="text" class="form-control"></asp:TextBox>
                            </div>
                            <asp:Button ID="Submit" runat="server" class="btn btn-fill btn-info" Text="查询班级" OnClick="Submit_Click" />
                        </div>
                    </fieldset>
                </form>


                    <div class="content table-responsive">
                        <asp:Table ID="Table1" runat="server" CssClass="table table-hover table-striped">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell Width="15%">学号</asp:TableHeaderCell>
                                <asp:TableHeaderCell Width="20%">姓名</asp:TableHeaderCell>
                                <asp:TableHeaderCell Width="20%">已获学分</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>

            </div>
        </div>

    </div>

</asp:Content>

