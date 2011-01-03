<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.LookUpWordResult>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	History
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        <%=Html.Label(Model.queryWord) %></h2>
        <%if (Request.IsAuthenticated)
          { %>
        <%:Html.ActionLink("加入单词簿", "Add", "wordsbook", new { wd = Model.queryWord }, new { })%>
        <%} %>
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
            <%if (Request.IsAuthenticated)
              { %>
            <td style="width:80px">
                <%:Html.ActionLink("我来修改", "index", "EditWord", new { id = exp.id }, new { })%>
            </td>
            <%} %>
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

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
