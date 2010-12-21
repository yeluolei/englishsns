<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.SentenceModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	getTranslate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>getTranslate</h2>
    <p><%=Html.Label(Model.TranslateSource)%></p>
    <p><%=Html.Label(Model.GoogleTranslateResult)%></p>
    <p><%=Html.Label(Model.BingTranslateResult)%></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
