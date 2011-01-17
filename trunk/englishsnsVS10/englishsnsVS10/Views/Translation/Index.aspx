<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	整句翻译
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>整句翻译</h2>
        <% using (Html.BeginForm("TranslateResult", "Translation", FormMethod.Post))
       { %>
        <center><p>
        <input class="editor-field" size="69" maxlength="250" name="Sentence" type="text" /><input title="Search" value="整句翻译" type="submit" /></p>
        <input name="languagechoose" type="radio" value="ZH_EN" />中文->英文&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input name="languagechoose" type="radio" value="EN_ZH" checked="true"/>英文->中文
        </center>
    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
