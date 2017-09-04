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
                                <div class="row">
                                    <div class="col-md-1">
                                        <select id="In_Hour" name="NHour" runat="server" class="selectpicker" data-title="小时" data-style="btn-default btn-block" data-menu-style="dropdown-blue">
                                            <option value="00">00</option><option value="01">01</option><option value="02">02</option><option value="03">03</option><option value="04">04</option><option value="05">05</option><option value="06">06</option><option value="07">07</option><option value="08" selected="selected">08</option><option value="09">09</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option>                                        
                                        </select> 
                                    </div>
                                    <div class="col-md-1">
                                        <select id="In_Minutes" name="NMinutes" runat="server" class="selectpicker" data-title="分钟" data-style="btn-default btn-block" data-menu-style="dropdown-blue">
                                            <option value="00" selected="selected">00</option><option value="01">01</option><option value="02">02</option><option value="03">03</option><option value="04">04</option><option value="05">05</option><option value="06">06</option><option value="07">07</option><option value="08">08</option><option value="09">09</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option>                                
                                        </select>
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

