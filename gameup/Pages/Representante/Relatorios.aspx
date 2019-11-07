<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRepresentante.master" AutoEventWireup="true" CodeFile="Relatorios.aspx.cs" Inherits="Pages_Representante_Relatorios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
        <h3 class="m-0 font-weight-bold text-dark">Relatórios</h3>
    </div>
    <div class="row">
        <div class="col-12 col-md-5">
            <!-- Pie Chart -->
                <div class="card shadow mb-4 ">
                    <!-- Card Header - Dropdown -- Desempenho Geral - Missões -->
                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                        <h5 class="m-0 font-weight-bold text-bold">Desempenho Geral - Missões</h5>
                        <div class="dropdown no-arrow">
                            <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fas fa-ellipsis-v fa-sm fa-fw text-gray-400"></i>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in" aria-labelledby="dropdownMenuLink">
                                <div class="dropdown-header">Dropdown Header:</div>
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Something else here</a>
                            </div>
                        </div>
                    </div>
                    <!-- Card Body -->
                    <div class="card-body">
                        <div class="chart-pie pt-4 pb-2">
                            <canvas id="myPieChart"></canvas>
                        </div>
                        <div class="mt-4 text-center small">
                            <span class="mr-2">
                                <i class="fas fa-circle text-primary"></i>Direct
                            </span>
                            <span class="mr-2">
                                <i class="fas fa-circle text-success"></i>Social
                            </span>
                            <span class="mr-2">
                                <i class="fas fa-circle text-info"></i>Referral
                            </span>
                        </div>
                    </div>
                </div>
                <!-- Pie Chart -->
                <div class="card shadow mb-4">
                    <!-- Card Header - Dropdown -- Colaboradores - Assiduidade -->
                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                        <h5 class="m-0 font-weight-bold text-bold">Colaboradores - Assiduidade</h5>
                        <div class="dropdown no-arrow">
                            <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fas fa-ellipsis-v fa-sm fa-fw text-gray-400"></i>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in" aria-labelledby="dropdownMenuLink">
                                <div class="dropdown-header">Dropdown Header:</div>
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Something else here</a>
                            </div>
                        </div>
                    </div>
                    <!-- Card Body -->
                    <div class="card-body">
                        <div class="chart-pie pt-4 pb-2">
                            <canvas id="myPieChart2"></canvas>
                        </div>
                        <div class="mt-4 text-center small">
                            <span class="mr-2">
                                <i class="fas fa-circle text-primary"></i>Direct
                            </span>
                            <span class="mr-2">
                                <i class="fas fa-circle text-success"></i>Social
                            </span>
                            <span class="mr-2">
                                <i class="fas fa-circle text-info"></i>Referral
                            </span>
                        </div>
                    </div>
                </div>
            </div>


        <div class=" col-12 col-md-7  ">
            <!-- Desempenho -->
            <div class="card shadow mb-4 h-100 ">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h5 class="m-0 font-weight-bold text-bold">Desempenho - Conclusão de Missões</h5>
                    <div class="dropdown no-arrow">
                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="fas fa-ellipsis-v fa-sm fa-fw text-gray-400"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in" aria-labelledby="dropdownMenuLink">
                            <div class="dropdown-header">Dropdown Header:</div>
                            <a class="dropdown-item" href="#">Action</a>
                            <a class="dropdown-item" href="#">Another action</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Something else here</a>
                        </div>
                    </div>
                </div>
                <!-- Card Body -->
                <div class=" card-body ">
                    <div class="row">
                        <div class="form col-12 col-md-6">
                            <div class="form-group col-md-9 ">
                                <label for="inputEmail4">Setores</label>
                                <input type="date" class="form-control" id="inputEmail4" placeholder="Data de início">
                            </div>
                            <div class="form-group col-md-9 ">
                                <label for="inputEmail4">Período incial</label>
                                <input type="date" class="form-control" id="inputEmail4" placeholder="Data de início">
                            </div>
                        </div>
                        <div class="form-check  col-12 col-md-6">

                            <div class="form-group col-md-9 ">
                                <label for="inputPassword4">Período final</label>
                                <input type="date" class="form-control" id="inputPassword4" placeholder="Data final">
                            </div>
                            <div class="form-group col-md-9">
                                <label for="exampleFormControlSelect1">Graficos</label>
                                <select class="form-control" id="exampleFormControlSelect1">
                                    <option>Grafico Pizza</option>
                                    <option>Grafico Torre</option>
                                    <option>Grafico em linha</option>
                                </select>
                            </div>

                        </div>
                        <div class="mt-4 form-check  col-12">
                            <div class="   form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="opcao1">
                                <label class="form-check-label" for="inlineRadio1">Mensal</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="opcao2">
                                <label class="form-check-label" for="inlineRadio2">Semestral</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" value="opcao2">
                                <label class="form-check-label" for="inlineRadio2">Anual</label>
                            </div>

                        </div>

                    </div>
                </div>
                <div class=" card-body">
                    <div class="chart-area">
                        <canvas id="myAreaChart"></canvas>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>

