<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加词条
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        为
        <%:ViewData["word"] %> 添加词条</h2>
    <% using (Html.BeginForm("add", "editword", FormMethod.Post))
       { %>
    
        <input name="word" type="text" value="<%:ViewData["word"] %>" readonly="readonly">
        <p>
        <textarea name="content" class="fortextarea"></textarea></p>
    <input title="Search" value="确定" type="submit" />
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
