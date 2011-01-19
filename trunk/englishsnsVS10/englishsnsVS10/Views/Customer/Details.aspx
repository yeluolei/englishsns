<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.datacontext.user>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">userId:</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">username:</div>
        <div class="display-field"><%: Model.username %></div>
        
        <div class="display-label">name:</div>
        <div class="display-field"><%: Model.name %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { username = Model.username })%> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

