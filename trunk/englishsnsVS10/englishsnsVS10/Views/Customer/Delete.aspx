<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.UserModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>
    <div>
    <p>Please confirm you want to let him or her just to be a usual customer :
    <i><%=Html.Encode(Model.userId) %></i>
    <i><%=Html.Encode(Model.username) %></i>
    <i><%=Html.Encode(Model.name) %>?</i>
    </p>
    </div>
    <%using (Html.BeginForm())
      { %>
    <input name="confirmButton"type="submit"value="Delete"/>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
