<%@ Page Title="Cadastrar Viagem" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ViagemForm.aspx.cs" Inherits="Client.ViagemForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="https://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#<%= txtData.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta',
                    'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho',
                    'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago',
                    'Set', 'Out', 'Nov', 'Dez']
            });
        });
    </script>
    <div class="container">
        <form id="form" runat="server">
            <div class="row">
                <div class="col-12">
                    <div class="form-group">
                        <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <div class="form-group">
                        <asp:Label ID="lblId" runat="server" Text="ID"></asp:Label>
                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtId" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-5">
                    <div class="form-group">
                        <asp:Label ID="lblDescricao" runat="server" Text="Descrição"></asp:Label>
                        <asp:TextBox class="form-control" MaxLength="100" ID="txtDescricao" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-5">
                    <div class="form-group">
                        <asp:Label ID="lblData" runat="server" Text="Data"></asp:Label>
                        <asp:TextBox class="form-control" name="txtData" ID="txtData"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="form-group">
                        <asp:Button class="btn btn-primary" ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                        <asp:Button class="btn btn-warning" ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
