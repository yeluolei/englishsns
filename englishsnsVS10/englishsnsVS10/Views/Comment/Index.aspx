<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	评论
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>评论</h2>
        <% using (Html.BeginForm("Index", "Comment", FormMethod.Post))
       { %>
    <p><textarea name="content" style="width:300px; height:150px"></textarea></p>
    <input title="Search" value="确定" type="submit" />
    <% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
