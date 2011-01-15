<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.SentenceModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	翻译结果
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>翻译结果for:</h2>
    <p><%=Html.Label(Model.TranslateSource)%></p>
    <hr />
    <br />
    <br />
    <h3>来自Google的翻译结果</h3>
    <p><%=Html.Label(Model.GoogleTranslateResult)%></p>
    <br />
    <h3>来自Bing的翻译结果</h3>
    <p><%=Html.Label(Model.BingTranslateResult)%></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    p
    {
        padding-left:50px;
        font-size:18px;
        }
    hr
    {
        border-style:dotted;
        color:#C9D7F1;
        width:100%;
        size:2px;
        }
</style>
</asp:Content>
