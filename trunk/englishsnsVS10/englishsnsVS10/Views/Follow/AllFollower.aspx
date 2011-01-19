<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<englishsnsVS10.datacontext.follower>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AllFollower
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AllFollower</h2>

    <table>
        <tr>
            <th></th>
            <th>
                id
            </th>
            <th>
                username
            </th>
            <th>
                name
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.id })%>
            </td>
            <td>
                <%: item.user.id %>
            </td>
            <td>
                <%: item.user.name %>
            </td>
            <td>
                <%: item.user.id %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

