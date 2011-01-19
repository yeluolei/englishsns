﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<englishsnsVS10.datacontext.user>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	用户管理
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>用户管理</h2>

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
            <th class="style4">
                type
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { username = item.username })%> |
                <%: Html.ActionLink("Details", "Details", new { username = item.username })%> |
                <%: Html.ActionLink("Create", "Create", new { username = item.username })%> |
                <%: Html.ActionLink("Delete", "Delete", new { username = item.username })%>
            </td>
            <td class="style1">
                <%: item.id %>
            </td>
            <td class="style2">
                <%: item.username %>
            </td>
            <td class="style3">
                <%: item.name %>
            </td>
            <td class="style4">
            <%: Roles.IsUserInRole(item.username, "admin")?"admin":"customer" %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Add New", "Index") %>
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
