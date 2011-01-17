<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<englishsnsVS10.datacontext.wordsbook>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	单词本
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>单词本</h2>
    <table>
        <tr>
            <th></th>
            <th>
                CommentId
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("查看", "index", "lookup", new { queryWord = item.wordname }, new { })%>
            </td>
            <td>
                <%: item.wordname %>
            </td>

        </tr>
    
    <% } %>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
