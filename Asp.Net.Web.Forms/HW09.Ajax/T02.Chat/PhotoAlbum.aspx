<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="PhotoAlbum.aspx.cs"
    Inherits="T02.Chat.PhotoAlbum"
    MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager" runat="server" />

    <script type="text/javascript">
        function uploadComplete(sender) {
            $get("<%=LabelMessage.ClientID%>").innerHTML = "File Uploaded Successfully";
        }
        function uploadError(sender) {
            $get("<%=LabelMessage.ClientID%>").innerHTML = "File upload failed.";
        }
    </script>

    <h1>Photo Album</h1>
    <hr />

    <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>

    <ajaxToolkit:AsyncFileUpload
        runat="server"
        OnClientUploadError="uploadError"
        OnClientUploadComplete="uploadComplete"
        ID="AsyncFileUploadField"
        Width="400px"
        UploaderStyle="Modern"
        CompleteBackColor="White"
        UploadingBackColor="#CCFFFF"
        OnUploadedComplete="AsyncFileUploadField_OnUploadedComplete"></ajaxToolkit:AsyncFileUpload>


    <div class="row">
    </div>

    <div class="text-center">
        <br />
        <br />
        <br />
        <a href="~/Default.aspx" runat="server" class="btn-lg btn-default">Go To Chat App</a>
    </div>
</asp:Content>
