﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="MeuPerfil.aspx.cs" Inherits="Pages_Colaborador_MeuPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Meu Perfil</h1>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm">Salvar alterações &nbsp; <i class="fas fa-save fa-sm text-white-50"></i></a>
    </div>

    <div class="row">

        <div class="col-lg-6">
            <div class="row">

                <div class="col-12">

                    <!-- Infomações perfil -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-dark">Informações Básicas</h6>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-12 col-md-4">
                                    <img src="../../Assets/Imagens/perfil.jpg" class="img-fluid mb-2 rounded" />
                                    <input type="text" class="form-control" id="formGroupExampleInput" placeholder="Nome de usuário">
                                </div>
                                <div class="col-12 col-md-8">
                                    <div class="form-group">
                                        <input type="text" class="form-control" id="formGroupExampleInput" placeholder="Nome">
                                    </div>
                                    <div class="form-group">
                                        <input type="text" class="form-control" readonly="true" id="formGroupExampleInput2" placeholder="Data de Nascimento">
                                    </div>
                                    <div class="form-group">
                                        <input type="text" class="form-control" readonly="true" id="formGroupExampleInput2" placeholder="E-mail">
                                    </div>
                                    <a href="#" data-toggle="modal" data-target="#exampleModalCenter">Alterar senha</a>

                                    <!-- Modal -->
                                    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                        <div class="modal-dialog modal-dialog-centered" role="document">
                                            <div class="modal-content p-4">
                                                <div class="modal-header">
                                                    <h4 class="modal-title text-dark font-weight-bold" id="exampleModalLongTitle">Alteração de Senha</h4>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="form-group">
                                                        <label for="exampleFormControlInput1">Senha Atual</label>
                                                        <input type="password" class="form-control" id="exampleFormControlInput1" placeholder="Digite sua senha atual">
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleFormControlInput1">Nova Senha</label>
                                                        <input type="password" class="form-control" id="exampleFormControlInput1" placeholder="Digite a nova senha">
                                                        <small id="passwordHelpBlock" class="form-text text-info">A senha deve conter de 4 a 8 caracteres.
                                                        </small>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleFormControlInput1">Repetir Nova Senha</label>
                                                        <input type="password" class="form-control" id="exampleFormControlInput1" placeholder="Repita a nova senha">
                                                        <small id="passwordHelpBlock" class="form-text text-danger">As senhas devem coincidir
                                                        </small>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                                                    <button type="button" class="btn btn-success">Salvar alterações</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Fim informacoes perfil -->

                <!-- Moedas -->
                <div class="col-12 col-md-6 mb-4">
                    <div class="card border-left-success shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-success text-uppercase mb-1">Moedas de ouro</div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">135</div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-coins fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Pontos de habilidade -->
                <div class="col-12 col-md-6 mb-4">
                    <div class="card border-left-warning shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-warning text-uppercase mb-1">Pontos de habilidade</div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">2340</div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-star fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Experiencia -->
                <div class="col-12 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="form-group col-md-8">
                                        <select id="inputState" class="form-control">
                                            <option selected>Jovem peregrino da alvorada</option>
                                            <option>...</option>
                                        </select>
                                        <div class="progress mb-1 mt-4">
                                            <div class="progress-bar bg-success" role="progressbar" style="width: 20%" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                        <div class="text-xs font-weight-bold text-info text-uppercase">300 XP</div>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-meteor fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Avatar -->
        <div class="col-lg-6">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-dark">Avatar</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-12">
                            <center>
                                <i class="fas fa-user-circle fa-10x"></i>
                            </center>
                        </div>
                        <div class="col-12 mt-4">
                            <div class="header">
                                <h6 class="font-weight-bold">Chapéu</h6>
                            </div>
                            <div class="col-12 bg-light">
                                <br />
                                <br />
                            </div>
                        </div>
                        <div class="col-12 mt-4">
                            <div class="header">
                                <h6 class="font-weight-bold">Vestuário</h6>
                            </div>
                            <div class="col-12 bg-light">
                                <br />
                                <br />
                            </div>
                        </div>
                        <div class="col-12 mt-4 mb-2">
                            <div class="header">
                                <h6 class="font-weight-bold">Cor de pele</h6>
                            </div>
                            <div class="col-12 bg-light">
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Fim avatar -->

        <!-- Medalhas -->
        <div class="col-lg-12">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-dark">Medalhas</h6>
                </div>
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="col-12 bg-light">
                                <br />
                                <br />
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-medal fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Fim avatar -->


        <!-- /.container-fluid -->
</asp:Content>
