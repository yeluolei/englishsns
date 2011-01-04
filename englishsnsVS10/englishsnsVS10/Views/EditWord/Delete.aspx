<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.datacontext.explanation>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">wordname</div>
        <div class="display-field"><%: Model.wordname %></div>
        
        <div class="display-label">expcontent</div>
        <div class="display-field"><%: Model.expcontent %></div>
        
        <div class="display-label">id</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">modifier</div>
        <div class="display-field"><%: Model.modifier %></div>
        
        <div class="display-label">createdata</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.createdata) %></div>
        
        <div class="display-label">reference</div>
        <div class="display-field"><%: Model.reference %></div>
        
        <div class="display-label">active</div>
        <div class="display-field"><%: Model.active %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

