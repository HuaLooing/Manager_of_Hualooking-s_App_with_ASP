<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Manager_of_Hualooking_s_App_with_ASP_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>主页</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <!--这里主要修改激活的项目-->
    <li class="active">
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
        <a href="member.aspx">
            <i class="pe-7s-users"></i>
            <p>管理成员</p>
        </a>
    </li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12">
        <div class="card ">
            <div class="header">
                <h4 class="title">活动状态</h4>
                <p class="category">所有活动概览</p>
            </div>
            <div class="content">
            </div>
        </div>
    </div>
</asp:Content>


