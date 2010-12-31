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
    <table class="WordResult">
        <% var result = Model.explanations;
           int i = 1;
           if (result!=null)
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
                
                <h1>ID:</h1>
                <%=exp.id.ToString() %>
                
            </td>
            <%    i++;
               }
           else
           {%>
            Sorry, the word is not in our database now.
            <%} %>
        </tr>
    </table>
<%--    <div>
        <%: Html.ActionLink("查看词条", "Index", "EditWords", new { queryWord = Model.queryWord }, new { })%>
    </div>--%>
</asp:Content>
