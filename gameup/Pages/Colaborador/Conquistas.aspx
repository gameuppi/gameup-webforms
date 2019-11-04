<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="Conquistas.aspx.cs" Inherits="Pages_Colaborador_Conquistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Conquistas</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            
              <div class="card mb-4 py-1 border-bottom-primary">
                <div class="card-body py-1">
                  As conquistas define seus pontos fortes como funcionário, conquiste-as e mostre que é capaz

                </div>
              </div>
        </div>
    </div>


    <div class="row">
        <div class="col-md-3">
            <!-- Collapsable Card Example -->
            <div class="card shadow mb-4">
                <!-- Card Header - Accordion -->
                <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
                    <h4 class="m-0 font-weight-bold text-center">Minhas
                        <br />
                        conquistas</h4>
                </a>
                <!-- Card Content - Collapse -->
                <div class="collapse show" id="collapseCardExample">
                    <div class="card-body">
                        <nav class="navbar navbar-light bg-light">
                            <div class="form-inline">
                                <input class="form-control mr-sm-2" type="search" placeholder="Pesquisar" aria-label="Pesquisar">
                            </div>
                        </nav>
                        <hr />
                        <!-- Conquistas  -->
                        <!-- Conquistas  1 -->
                        <div class="card mb-4 py-2 border-left-primary">
                            <div class=" row  card-body py-2 col-12">
                                <i class="text-center fas fa-globe-africa fa-lg col-3 " style="font-size: 2rem !important"></i>
                                <h6 class="font-weight-bold col-9 ">Dedicação</h6>
                            </div>
                        </div>
                        <!-- Conquistas 2  -->
                        <div class="card mb-4 py-2 border-left-warning ">
                            <div class=" row  card-body py-2 col-12">
                                <i class="text-center fas fa-globe-africa fa-lg col-3 " style="font-size: 2rem !important"></i>
                                <h6 class="font-weight-bold col-9 ">Flexibilidade</h6>
                            </div>
                        </div>
                        <!-- Conquistas  3 -->
                        <div class="card mb-4 py-2 border-left-success">
                            <div class=" row  card-body py-2 col-12">
                                <i class="text-center fas fa-globe-africa fa-lg col-3 " style="font-size: 2rem !important"></i>
                                <h6 class="font-weight-bold col-9 ">Iniciativa</h6>
                            </div>
                        </div>
                        <!-- Conquistas 4 -->
                        <div class="card mb-4 py-2 border-left-primary">
                            <div class=" row  card-body py-2 col-12">
                                <i class="text-center fas fa-globe-africa fa-lg col-3 " style="font-size: 2rem !important"></i>
                                <h6 class="font-weight-bold col-9 ">Competitividade</h6>
                            </div>
                        </div>
                        <!-- Conquistas 5 -->
                        <div class="card mb-4 py-2 border-left-warning ">
                            <div class=" row  card-body py-2 col-12">
                                <i class="text-center fas fa-globe-africa fa-lg col-3 " style="font-size: 2rem !important"></i>
                                <h6 class="font-weight-bold col-9 ">Liderança</h6>
                            </div>
                        </div>
                        <!-- Conquistas 6 -->
                        <div class="card mb-4 py-2 border-left-success">
                            <div class=" row  card-body py-2 col-12">
                                <i class="text-center fas fa-globe-africa fa-lg col-4 " style="font-size: 2rem !important"></i>
                                <h6 class="font-weight-bold col-8 ">Persuasão</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container col-md-9">
            <!--Conquista cards -->

            <div class="row">
                <!--Card 1 -->
                <div class="container col-mb-4 col-md-4">
                    <div class="row ">
                        <div class="card shadow ">
                            <!--Card Cabeça -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <i class="fas fa-circle fa-lg" style="font-size: 2rem !important"></i>
                                <i class="fas fa-question-circle fas fa-lg fa-fw text-gray-400"></i>
                            </div>
                            <!--Card Corpo -->
                            <div class="card-body text-center">
                                <img src="http://www.myiconfinder.com/uploads/iconsets/128-128-65bfae99db3348882d06ea9c2c660822.png" class="img-thumbnail border-0" />
                                <h4 class="font-weight-bold">Dedicação</h4>
                                <hr class="sidebar-divider d-none d-md-block" />
                                <p>Logue no sitema por 5 dias seguidos</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Card 2 -->
                <div class="container col-mb-4 col-md-4">
                    <div class="row ">
                        <div class="card shadow ">
                            <!--Card Cabeça -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <i class="fas fa-circle fa-lg" style="font-size: 2rem !important"></i>
                                <i class="fas fa-question-circle fa-lg fa-fw text-gray-400"></i>
                            </div>
                            <!--Card Corpo -->
                            <div class="card-body text-center">
                                <img src="http://www.myiconfinder.com/uploads/iconsets/128-128-65bfae99db3348882d06ea9c2c660822.png" class="img-thumbnail border-0" />
                                <h4 class="font-weight-bold">Flexibilidade</h4>
                                <hr class="sidebar-divider d-none d-md-block" />
                                <p>Logue no sitema por 5 dias seguidos</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Card 3 -->
                <div class="container col-mb-4 col-md-4">
                    <div class="row ">
                        <div class="card shadow ">
                            <!--Card Cabeça -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <i class="fas fa-circle fa-lg" style="font-size: 2rem !important"></i>
                                <i class="fas fa-question-circle fa-lg fa-fw text-gray-400"></i>
                            </div>
                            <!--Card Corpo -->
                            <div class="card-body text-center">
                                <img src="http://www.myiconfinder.com/uploads/iconsets/128-128-65bfae99db3348882d06ea9c2c660822.png" class="img-thumbnail border-0" />
                                <h4 class="font-weight-bold">Iniciativa</h4>
                                <hr class="sidebar-divider d-none d-md-block" />
                                <p>Logue no sitema por 5 dias seguidos</p>
                            </div>
                        </div>
                    </div>
                    <br />
                </div>

                <!--Card 4 -->
                <div class="container col-mb-4 col-md-4">
                    <div class="row ">
                        <div class="card shadow ">
                            <!--Card Cabeça -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <i class="fas fa-circle fa-lg" style="font-size: 2rem !important"></i>
                                <i class="fas fa-question-circle fa-lg fa-fw text-gray-400"></i>
                            </div>
                            <!--Card Corpo -->
                            <div class="card-body text-center">
                                <img src="http://www.myiconfinder.com/uploads/iconsets/128-128-65bfae99db3348882d06ea9c2c660822.png" class="img-thumbnail border-0" />
                                <h4 class="font-weight-bold">Competitividade</h4>
                                <hr class="sidebar-divider d-none d-md-block" />
                                <p>Logue no sitema por 5 dias seguidos</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Card 5 -->
                <div class="container col-mb-4 col-md-4">
                    <div class="row ">
                        <div class="card shadow ">
                            <!--Card Cabeça -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <i class="fas fa-circle fa-lg" style="font-size: 2rem !important"></i>
                                <i class="fas fa-question-circle fa-lg fa-fw text-gray-400"></i>
                            </div>
                            <!--Card Corpo -->
                            <div class="card-body text-center">
                                <img src="http://www.myiconfinder.com/uploads/iconsets/128-128-65bfae99db3348882d06ea9c2c660822.png" class="img-thumbnail border-0" />
                                <h4 class="font-weight-bold">Liderança</h4>
                                <hr class="sidebar-divider d-none d-md-block" />
                                <p>Logue no sitema por 5 dias seguidos</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Card 6 -->
                <div class="container col-mb-4 col-md-4">
                    <div class="row ">
                        <div class="card shadow ">
                            <!--Card Cabeça -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <i class="fas fa-circle fa-lg" style="font-size: 2rem !important"></i>
                                <i class="fas fa-question-circle fa-lg fa-fw text-gray-400"></i>
                            </div>
                            <!--Card Corpo -->
                            <div class="card-body text-center">
                                <img src="http://www.myiconfinder.com/uploads/iconsets/128-128-65bfae99db3348882d06ea9c2c660822.png" class="img-thumbnail border-0" />
                                <h4 class="font-weight-bold">Persuasão</h4>
                                <hr class="sidebar-divider d-none d-md-block" />
                                <p>Logue no sitema por 5 dias seguidos</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>






</asp:Content>

