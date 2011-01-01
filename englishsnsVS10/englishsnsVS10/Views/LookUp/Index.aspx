<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.LookUpWordResult>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/LookUpResult.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- <h2>Index</h2> -->
    <!--        { %> -->
    <!--     <div> -->
    <!--         <center> -->
    <!--             <input size="69" maxlength="250" name="queryWord" type="text" /> -->
    <!--             <input title="Search" value="Look Up" type="submit" /> -->
    <!--         </center> -->
    <!--     </div> -->
    <h2>
        <%=Html.Label(Model.queryWord) %></h2>
    <% var result = Model.explanations;
       int i = 1;
       if (result != null)
       {%>
    <table class="WordResult">
        <%
            foreach (var exp in result)
            {
        %>
        <tr>
            <td class="number">
                <%= Html.Label(i.ToString())%>.
            </td>
            <td>
                <p>
                    <%=Html.Encode(exp.expcontent)%>
                </p>
            </td>
            <td>
                <%:Html.ActionLink("分享", "Index", "Share", new { id = exp.id.ToString() }, new { })%>>
            </td>
        </tr>
        <%    i++;
} %>
    </table>
    <%}
           else
           {%>
    Sorry, the word is not in our database now.
    <%} %>
    <%--    <div>
        <%: Html.ActionLink("查看词条", "Index", "EditWords", new { queryWord = Model.queryWord }, new { })%>
    </div>--%>
</asp:Content>
