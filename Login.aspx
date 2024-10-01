<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExamenPromerica.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>   
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
           <table class="Titulo" id="Table1" style="HEIGHT: 26px" cellspacing="1" cellpadding="1"
					width="60%" align="center" border="0">
					<tr>
						<td align="center">Ingreso al Sistema</td>
					</tr>
		    </table>
            <br/>                   
            <table class="Normal" id="Table2" cellspacing="1" cellpadding="1" width="30%" align="center"
					border="0">
					<tr>
						<td style="WIDTH: 20%">
							<div style="DISPLAY: inline; WIDTH: 100%; HEIGHT: 19px" align="right" ms_positioning="FlowLayout">Usuario:</div>
						</td>
						<td style="WIDTH: 50%">
                            <asp:TextBox ID="txtUsuario" runat="server" Width ="50%" ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator runat="server" ID="rfvUsuario" ControlToValidate="txtUsuario" ErrorMessage="Usuario Requerido" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>--%>
                        </td> 
					</tr>
					<tr>
						<td style="WIDTH: 20%">
							<div style="DISPLAY: inline; WIDTH: 100%; HEIGHT: 16px" align="right" ms_positioning="FlowLayout">Contrase&ntilde;a:</div>
						</td>
						<td style="WIDTH: 50%">
                            <asp:TextBox ID="txtPassword" runat="server" Width ="50%" TextMode="Password"></asp:TextBox>   
                             
                        </td>
					</tr>
				</table>
            	<br/>
				<table class="Normal" id="Aceptar" style="WIDTH: 283px; HEIGHT: 30px" cellspacing="1" cellpadding="1"
					width="283" align="center" border="0" runat="server">
					<tr>
						<td width="50%">
                            <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" Width ="95%" OnClick="BtnAceptar_Click"/>
                        </td>
						<td width="50%">
                               <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Width ="95%"/>
						</td>
					</tr>
				</table>
        </div>
    </form>
</body>
</html>
