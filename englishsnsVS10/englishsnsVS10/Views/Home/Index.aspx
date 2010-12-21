<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        欢迎来到英语学习社区</h2>
    <% using (Html.BeginForm("getTranslate", "Translation", FormMethod.Post))
       { %>
    <input class="text" size="69" maxlength="250" name="Sentence" type="text" />
    <input name="languagechoose" type="radio" value="ZH_EN"/><p>中文->英文</p>
    <input name="languagechoose" type="radio" value="EN_ZH" checked="true"/><p>英文->中文</p>
    <input title="Search" value="整句翻译" type="submit" />
    <% } %>
</asp:Content>
