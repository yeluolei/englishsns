<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<englishsnsVS10.Models.ShareModels>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>
    <h2>
        欢迎来到英语学习社区</h2>
    <%if (Request.IsAuthenticated)
      { %>
    <table>
        <%for (int i = 0; i < Model.Count; ++i)
          {
              int cnt = 0;
              foreach (var temp in Model[i].shares)
              {%>
        <tr>
            <td>
                <%:Html.Encode(Model[i].userName[cnt]) %>分享了
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
                <%:Html.Encode(Model[i].explanations[cnt].expcontent) %>
                 <div style="margin-top: 20px">评论：<br /><%:Html.Encode(temp.sharecontent) %></div>
                 <div style="margin-top: 20px"><%:Html.ActionLink("我要评论", "Index", "Comment", new { id = temp.id }, new { })%></div>
                 <div style="margin-top: 20px"><%:Html.ActionLink("查看评论", "GetComments", "Comment", new { id = temp.id }, new { })%></div>
            </td>
            <td>
               &nbsp   
            </td>
        </tr>
        <%++cnt;
              }
          } %>
    </table>
    <%} %>>
</asp:Content>
