<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.terms>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>编辑</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>编辑词条</legend>
            
            <div class="editor-label">
                <%: Html.Label("英文例句") %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.sentence) %>
                <%: Html.ValidationMessageFor(model => model.sentence) %>
            </div>
            
            <div class="editor-label">
                <%: Html.Label("中文翻译") %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.translate) %>
                <%: Html.ValidationMessageFor(model => model.translate) %>
            </div>
            
            <p>
                <input type="submit" value="保存修改" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("返回", "Index", new { queryWord = Model.word.theWord})%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

