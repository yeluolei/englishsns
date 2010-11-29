<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<string>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- <h2>Index</h2> -->
   
    <!--        { %> -->
    <!--     <div> -->
    <!--         <center> -->
    <!--             <input size="69" maxlength="250" name="queryWord" type="text" /> -->
    <!--             <input title="Search" value="Look Up" type="submit" /> -->
    <!--         </center> -->
    <!--     </div> -->
   
    <% List<String> result = Model as List<String>;
       if (result != null)
           foreach (String s in result)
           {
    %><p>
        <%=Html.Label(s)%>
    </p>
    <%      } %>
</asp:Content>
