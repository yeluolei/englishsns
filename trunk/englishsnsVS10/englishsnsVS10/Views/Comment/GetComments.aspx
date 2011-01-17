<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<englishsnsVS10.datacontext.comment>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	GetComments
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GetComments</h2>

    <table>
        <tr>
            <th>
                CommentId
            </th>
            <th>
                CommentContent
            </th>
            <th>
                time
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.user.name %>
            </td>
            <td>
                <%: item.comment1 %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.time) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
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

