<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<englishsnsVS10.Models.EditWordResult>" %>

<asp:Content ID="Content4" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/LookUpResult.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%=Html.Label(Model.queryWord) %></h2>   
    <table class="WordResult">
    <% 
           for (int i = 0; i < Model.sentence.Count(); ++ i )
           {
    %>
    <tr>
    <td class="number">
     <%= Html.Label((i+1).ToString())%>.
     </td>
     <td>
     <%=Html.Label(Model.sentence[i])%>.
     <br />
     <%=Html.Label(Model.translate[i]) %>
     </td>
     <td>
     <%=Html.ActionLink("编辑词条", "Edit", new { id = Model.ids[i] })%>
     </td>
     </tr>
    <%
           }%>
      </table>
</asp:Content>

