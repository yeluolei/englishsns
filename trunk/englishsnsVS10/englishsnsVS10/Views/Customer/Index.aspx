<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<englishsnsVS10.Models.UserModels>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th class="style1">
                userId
            </th>
            <th class="style2">
                username
            </th>
            <th class="style3">
                name
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Create", "Create", new { username = item.username })%> |
                <%: Html.ActionLink("Delete", "Delete", new { username = item.username })%>
            </td>
            <td class="style1">
                <%: item.userId %>
            </td>
            <td class="style2">
                <%: item.username %>
            </td>
            <td class="style3">
                <%: item.name %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 180px;
        }
        .style2
        {
            width: 208px;
        }
        .style3
        {
            width: 232px;
        }
    </style>
</asp:Content>

