<%@ Page Language="C#" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();
        Response.Expires = -1;
        Response.Write("ok");
        Response.End();        
    }
</script>
