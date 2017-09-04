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
        <a href="member.aspx">
            <i class="pe-7s-users"></i>
            <p>管理成员</p>
        </a>
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
                            功能完善中01
                            <asp:Table ID="Table1" runat="server"></asp:Table>
                        </div>
                        <div id="history" class="tab-pane">
                            功能完善中02
                        </div>
                        <div id="exam" class="tab-pane">
                            功能完善中03
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
