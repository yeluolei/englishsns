<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>分享</h2>
        <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>添加</legend>
                <div><label>评论</label></div>
                <div><textarea name="comment" style="width:400px; height:150px" ></textarea></div>        
            </fieldset>
        </div>
        <input type ="submit" />
    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
