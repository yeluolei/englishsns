<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.LookUpWordResult>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/LookUpResult.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    查询结果
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
            <td style="width:80px">
                <%:Html.ActionLink("分享", "Index", "Share", new { id = exp.id.ToString() }, new { })%>
            </td>
            <td style="width:80px">
                <%:Html.ActionLink("查看历史", "history", "EditWord", new { id = exp.id.ToString() }, new { })%>
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
    <%if (Request.IsAuthenticated)
        { %>
    <td style="width:80px">
        <%:Html.ActionLink("我来添加", "Add", "EditWord", new { word = Model.queryWord }, new { })%>
    </td>
    <%} %>

</asp:Content>
