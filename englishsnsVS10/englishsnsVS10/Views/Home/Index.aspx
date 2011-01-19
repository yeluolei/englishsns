    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<englishsnsVS10.Models.ShareModels>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    主页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>--%>
    <%if (Request.IsAuthenticated)
      { %>
       <h2>
        <%:Page.User.Identity.Name%>,欢迎您回来!</h2>
    <table>
        <%for (int i = 0; i < Model.Count; ++i)
          {
              int cnt = 0;
              foreach (var temp in Model[i].shares)
              {%>
        <tr>
            <td>
                <%:Html.Encode(Model[i].userName[cnt])%>分享了
            </td>
            <td>
                <%:Html.Encode(Model[i].explanations[cnt].wordname)%>
            </td>
            <td>
            &nbsp
            </td>
        </tr>
        <tr>
        <td>
        &nbsp
        </td>
            <td>
                <%:Html.Encode(Model[i].explanations[cnt].expcontent)%>
                <hr/>
                 <div style="margin-top: 20px">评论：<br /><%:Html.Encode(temp.sharecontent)%></div>
                 <div style="margin-top: 20px"><%:Html.ActionLink("我要评论", "Index", "Comment", new { id = temp.id }, new { })%>
                        <%:Html.ActionLink("查看评论", "GetComments", "Comment", new { id = temp.id }, new { })%>
                 </div>
            </td>
            <td>
               &nbsp   
            </td>
        </tr>
        <%++cnt;
              }
          } %>
    </table>
    <%} %>
    <%else
        { %>
        <h1>
        欢迎来到EnglishSNS!</h1>
        <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    table td
    {
        min-width:80px;
        }
    hr
    {
        margin-top:10px;
        border-style:solid;
        color:#C9D7F1;
        width:100%;
        font-size:1px;
        border-top:1px;
    }
</style>
</asp:Content>