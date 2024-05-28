<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage.Master" AutoEventWireup="true" CodeBehind="Vista3.aspx.cs" Inherits="PoryectoFinalDeGestionDelConocimiento.Vistas.Vista3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">
        <form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
            <div class="input-group">
                <asp:TextBox runat="server" type="text" class="form-control form-control-lg" ID="search" placeholder="Ingresa el Codigo del curso..."></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button runat="server" class="btn btn-primary" Text="Buscar" OnClick="searchOntology" />
                </div>
            </div>
        </form>
    </nav>

    <div class="card shadow mb-4">

        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">NIVELES</h6>
        </div>

        <div class="card-body">
            <div class="table-responsive">
                <div class="row">

                    <div class="card-body table-responsive p-0">
                        <table class="table table-bordered table-striped" id="table1">
                            <thead class="thead-danger">
                                <tr>
                                    <th>NIVEL</th>
                                    <th>CURSO</th>
                                    <th>ESTUDIANTE</th>
                                    <th>N° ESTUDIANTES</th>
                                    <th>CODIGO</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView runat="server" ID="ListViewResult">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("NIVEL")%></td>
                                            <td><%#Eval("CURSO")%></td>
                                            <td><%#Eval("ESTUDIANTE")%></td>
                                            <td><%#Eval("Numeroestudiantes")%></td>
                                            <td><%#Eval("codigo")%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
