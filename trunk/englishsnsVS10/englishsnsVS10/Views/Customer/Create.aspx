<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.UserModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <p>
                <label for="CustomerID">Customer ID:</label>
                <%=Html.TextArea("CustomerID") %>
                <%=Html.ValidationMessage("CustomerID","*") %>
            </p>
            <p>
                <label for="Username">Username:</label>
                <%=Html.TextArea("Username") %>
                <%=Html.ValidationMessage("Username","*") %>
            </p>
            <p>
                <label for="Name">Name:</label>
                <%=Html.TextArea("Name") %>
                <%=Html.ValidationMessage("Name","*") %>
            </p>

            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

