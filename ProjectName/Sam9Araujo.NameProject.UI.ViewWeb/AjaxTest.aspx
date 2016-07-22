<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="AjaxTest.aspx.cs" Inherits="Laboris.Cosan.UI.ViewWeb.AjaxTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="NossosParceiros.ascx" tagname="NossosParceiros" tagprefix="uc1" %>
<%@ Register src="AjaxUserControlExampleNossosParceiros.ascx" tagname="AjaxUserControlExampleNossosParceiros" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <uc2:AjaxUserControlExampleNossosParceiros ID="AjaxUserControlExampleNossosParceiros1" runat="server" />
</asp:Content>
