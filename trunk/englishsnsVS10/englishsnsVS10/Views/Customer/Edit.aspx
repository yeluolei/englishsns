<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.UserModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
<%--            <p>
                <label for="CustomerID">Customer ID:</label>
                <%=Html.TextBox("CustomerID",Model.userId)%>
                <%=Html.ValidationMessage("CustomerID","*") %>
            </p>
            <p>
                <label for="Username">Username:</label>
                <%=Html.TextBox("Username",Model.username) %>
                <%=Html.ValidationMessage("Username","*") %>
            </p>--%>
            <p>UserName:<%=Model.username%></p>
            <p>UserID:<%=Model.userId %></p>
            <p>
                <label for="Name">Name:</label>
                <%=Html.TextBox("Name",Model.name) %>
                <%=Html.ValidationMessage("Name","*") %>
            </p>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

