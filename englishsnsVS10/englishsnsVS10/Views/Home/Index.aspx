<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<englishsnsVS10.Models.ShareModels>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>
    <h2>
        欢迎来到英语学习社区</h2>
    <% using (Html.BeginForm("getTranslate", "Translation", FormMethod.Post))
       { %>
    <p>
        <input class="editor-field" size="69" maxlength="250" name="Sentence" type="text" /></p>
    <p>
        <input name="languagechoose" type="radio" value="ZH_EN" />中文->英文</p>
    <p>
        <input name="languagechoose" type="radio" value="EN_ZH" checked="true" />英文->中文</p>
    <input title="Search" value="整句翻译" type="submit" />
    <% } %>
    <%if(Request.IsAuthenticated){ %>
    <table>
        <%for (int i = 0; i < Model.Count;++i )
        {
            int cnt = 0;
            foreach(var temp in Model[i].shares){%>
        <tr>
            <td>
                <%:Html.Encode(Model[i].userName[cnt]) %>
            </td>
            <td>
                <%:Html.Encode(temp.sharecontent) %>>
            </td>
            <td>
                 <%:Html.Encode(Model[i].explanations[cnt].expcontent) %>>   
            </td>
        </tr>
            <%++cnt;
            }
       } %>
    </table>
    <%} %>>
</asp:Content>
