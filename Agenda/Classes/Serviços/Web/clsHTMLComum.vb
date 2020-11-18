Imports System.Text

Public Class clsHTMLComum
    Public Shared Function retornaMenuPagina() As String
        Dim locMenu As new StringBuilder()

        locMenu.Append("
        <nav class=""navbar navbar-dark bg-primary"">            
                <div >
                    <a href=""Home"" id=""btn_home"" class=""btn btn-primary btn-outline-light ""><i class=""material-icons"">home</i>Home</a>
                    <a href=""Grafico"" id=""btn_grafico"" class=""btn btn-primary btn-outline-light my-2 my-sm-0"" ><i class=""material-icons"">pie_chart</i>&nbsp;Gráfico</a>
                    

                     <div class=""btn-group"">
			          <button type=""button"" class=""btn btn-primary btn-outline-light my-2 my-sm-0 dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
				        <i class=""material-icons"">print</i>&nbsp;Impressão 
			          </button>
			          <div class=""dropdown-menu"">
				        <a class=""dropdown-item"" href=""ImpressaoAtividade""><i class=""material-icons"">format_paint</i>&nbsp;Atividades</a>
				        <a class=""dropdown-item"" href=""ImpressaoPonto""><i class=""material-icons"">watch</i>&nbsp;Ponto</a>				
			          </div>
			        </div>

                    <a href=""ControlePonto"" id=""bt_controlePonto"" class=""btn btn-primary btn-outline-light my-2 my-sm-0"" ><i class=""material-icons"">query_builder</i>&nbsp;Ponto</a>            

                   
                     <div class=""btn-group"">
			          <button type=""button"" class=""btn btn-primary btn-outline-light my-2 my-sm-0 dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
				        <i class=""material-icons"">build</i>&nbsp;Configurações 
			          </button>
			          <div class=""dropdown-menu"">
				        <a class=""dropdown-item"" href=""Configuracao""><i class=""material-icons"">build_circle</i>&nbsp; Configuração do Sistema</a>
				        <a class=""dropdown-item"" href=""CadastroTipo""><i class=""material-icons"">read_more</i>&nbsp; Cadastro Tipo de Atividade</a>				
			          </div>
			        </div>

                    <a href=""Versoes"" id=""bt_versoes"" class=""btn btn-primary btn-outline-light my-2 my-sm-0"" ><i class=""material-icons"">live_help</i>&nbsp;Versões</a>                                
                </div>
                <div class=""float-right"">
                    <span class=""agenda"">Agenda</span>  <span style=""color: White;"" >v. {p_versao_sistema}</span>                       
                    <img  src=""favicon.ico"""" width=""50"" height=""50""> </img>                                         
                </div>
        </nav>")
        Return locMenu.ToString

    End Function

    Public Shared Function RetornaTituloPagina() As String
        Dim locMenu As New StringBuilder()

        locMenu.Append("
            <title>Agenda</title>
         ")
        Return locMenu.ToString
    End Function


    Public Shared Function RetornaFuncoesAtalhoFiltros() As String
        Dim texto As New StringBuilder()


        texto.Append("
        
        function FiltroLimpar() {
            AplicarFiltros(null, null, true)
        }

        function PeriodoMes(d) {
            var primeiroDia = new Date(d.getFullYear(), d.getMonth(), 1);
            var ultimoDia = new Date(d.getFullYear(), d.getMonth() + 1, 0);

            AplicarFiltros(primeiroDia, ultimoDia, false);
        }

        function FiltroUltimosDias(n) {
            var d = new Date();
            d.setDate(d.getDate() - n);

            AplicarFiltros(d, null, false);
        }

        function FiltroMesAtual() {
            var d = new Date();
            PeriodoMes(d);
        }

        function AplicarFiltros(ini, ate, limparTipo) {
            document.getElementById(""data_ini"").valueAsDate = ini;
            document.getElementById(""data_ate"").valueAsDate = ate;

            if (limparTipo) {
                document.getElementById(""cbTipo"").selectedIndex = 0;
            }
        }

        ")

        Return texto.ToString
    End Function

    Public Shared Function RetornaStyleComumPagina() As String
        Dim locMenu As New StringBuilder()

        locMenu.Append("
        .Titulo {
            color: darkblue;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-weight: bold; 
            font-size: 20px; 
        }

        .TituloPrincipal {
            color: darkblue;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            text-align: center;
            border-radius: 4px;
            font-size: 20px; 
        }

        .Atualizacao {
            color: black;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .Fundo {
            background-color: #aecff2;
        }
        
		.material-icons {
			vertical-align: -5px; /*Correção para a posição do ícone verticalmente*/
		}
    
        .agenda{
           font-size: 30px; 
           font-family: Comic Sans MS, Comic Sans, cursive; 
            color: White;
        }
         
        .label {
            font-weight: bold;  
            color: black;
        }

         ")
        Return locMenu.ToString
    End Function

    Public Shared Function RetornLinksComnsPagina() As String
        Dim texto As New StringBuilder

        texto.Append("
            <meta charset=""UTF-8"">

            <!--Grafico JQuery-->
            <script src=""https://code.jquery.com/jquery-3.4.1.js"" integrity=""sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU="" crossorigin=""anonymous""></script>
            <script src=""https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"" integrity=""sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo"" crossorigin=""anonymous""></script>
            <script src=""https://cdn.jsdelivr.net/npm/chart.js@2.9.3/dist/Chart.min.js""></script>

            <!--bootstrap-->
            <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"" integrity=""sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"" crossorigin=""anonymous"">
            <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"" integrity=""sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6"" crossorigin=""anonymous""></script>

            <!--Funcionar DataTable-->
            <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css"">
            <script src=""https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js""></script>
            <script src=""https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js""></script>

            <!--icone botao-->         
            <link rel=""stylesheet"" href=""https://fonts.googleapis.com/icon?family=Material+Icons"">
               
            <script src=""https://cdn.jsdelivr.net/npm/gasparesganga-jquery-loading-overlay@2.1.7/dist/loadingoverlay.min.js""></script>
        ")

        Return texto.ToString
    End Function
    Public Shared Sub TrataParametrosComuns(ByRef pagina As String)
        pagina = pagina.Replace("{p_menu_pagina}", retornaMenuPagina)
        pagina = pagina.Replace("{p_titulo_pagina}", RetornaTituloPagina)
        pagina = pagina.Replace("[p_style_comum_pagina]", RetornaStyleComumPagina)
        pagina = pagina.Replace("{p_links_comum_pagina}", RetornLinksComnsPagina)
        pagina = pagina.Replace("[p_funcao_calcula_diferencao_horas]", RetornaFuncaoCalculaDiferencaHoras)
        pagina = pagina.Replace("[p_funcao_calcula_soma_horas]", RetornaFuncaoCalculaSomaHoras)
        pagina = pagina.Replace("[p_funcao_retorna_data_atual]", RetornaFuncaoRetornaDataAtual)
        pagina = pagina.Replace("[p_funcao_retorna_hora_atual]", RetornaFuncaoRetornaHoraAtual)
        pagina = pagina.Replace("[p_funcao_ajax_loading]", RetornaFuncaoAjaxLoading)
        pagina = pagina.Replace("{p_versao_sistema}", clsVersaoSistema.Versao)

    End Sub

    Private Shared Function RetornaFuncaoAjaxLoading() As String
        Dim texto As New StringBuilder(vbNullString)

        texto.Append("
                    $(document).ajaxStart(function () {
			            $.LoadingOverlay(""show"", { fade: false, background: '' });
		            });
		            $(document).ajaxStop(function () {
			            $.LoadingOverlay(""hide"");
                    }); ")

        Return texto.ToString
    End Function

    Public Shared Function RetornaFuncaoRetornaHoraAtual() As String
        Dim texto As New StringBuilder(vbNullString)


        texto.Append("
                 function retornaHoraAtual() {

                            var dNow = new Date();

                            var min = dNow.getMinutes()
                            var hor = dNow.getHours()

                            min = min.toString().length == 2 ? min : (""0"" + min);
                            hor = hor.toString().length == 2 ? hor : (""0"" + hor);

                            return hor + ':' + min;
                        }
                ")
        Return texto.ToString()
    End Function

    Public Shared Function RetornaFuncaoCalculaSomaHoras() As String
        Dim texto As New StringBuilder(vbNullString)

        texto.Append("
            //Função para somar duas horas
            //http://www.cesar.inf.br/blog/?cat=173
            function somaHora(hrA, hrB, zerarHora) {
                if (hrA.length != 5 || hrB.length != 5) return ""00:00"";

                temp = 0;
                nova_h = 0;
                novo_m = 0;

                hora1 = hrA.substr(0, 2) * 1;
                hora2 = hrB.substr(0, 2) * 1;
                minu1 = hrA.substr(3, 2) * 1;
                minu2 = hrB.substr(3, 2) * 1;

                temp = minu1 + minu2;
                while (temp > 59) {
                    nova_h++;
                    temp = temp - 60;
                }
                novo_m = temp.toString().length == 2 ? temp : (""0"" + temp);

                temp = hora1 + hora2 + nova_h;
                while (temp > 23 && zerarHora) {
                    temp = temp - 24;
                }
                nova_h = temp.toString().length == 2 ? temp : (""0"" + temp);

                return nova_h + ':' + novo_m;
            };
        ")
        Return texto.ToString
    End Function


    Public Shared Function RetornaFuncaoCalculaDiferencaHoras() As String
        Dim texto As New StringBuilder(vbNullString)

        texto.Append("
            //Calcula a diferença entre as horas
            //https://stackoverflow.com/questions/10804042/calculate-time-difference-with-javascript
            function diff(start, end) {
                start = start.split("":"");
                end = end.split("":"");                
                var startDate = new Date(0, 0, 0, start[0], start[1], 0);
                var endDate = new Date(0, 0, 0, end[0], end[1], 0);
                var diff = endDate.getTime() - startDate.getTime();
                var hours = Math.floor(diff / 1000 / 60 / 60);
                diff -= hours * 1000 * 60 * 60;
                var minutes = Math.floor(diff / 1000 / 60);

                // If using time pickers with 24 hours format, add the below line get exact hours
                if (hours < 0)
                    hours = hours + 24;

                return (hours <= 9 ? ""0"" : """") + hours + "":"" + (minutes <= 9 ? ""0"" : """") + minutes;
            };
        ")
        Return texto.ToString
    End Function



    Public Shared Function RetornaFuncaoRetornaDataAtual() As String
        Dim texto As New StringBuilder(vbNullString)

        texto.Append("
                function RetornaDataAtual() {
                // Obtém a data/hora atual
                var data = new Date();

                // Guarda cada pedaço em uma variável
                var dia = data.getDate();           // 1-31
                
                if (dia.toString().length == 1){
                    dia = ""0"" + dia;
                }                
              
                var mes = (""0"" + (data.getMonth() + 1)).slice(-2);  // 0-11 (zero=janeiro)
                var ano4 = data.getFullYear();       // 4 dígitos

                // Formata a data e a hora (note o mês + 1)
                var str_data = ano4 + '-' + (mes) + '-' + dia;

                return str_data;
            };
        ")
        Return texto.ToString
    End Function

    Public Shared Function RetornaTiposAtividadesFiltro(pTipo As Integer) As String
        Dim retorno As New StringBuilder(vbNullString)
        Dim selected As String = "selected"
        Dim tipos As List(Of clsTipo)

        tipos = New clsAdicionarDAO().CarregaTipos()

        retorno.AppendFormat("<option value = ""{0}"" {1}> {2}</Option>", 0, IIf(pTipo = 0, selected, ""), "Todos")

        For Each tipo In tipos
            retorno.AppendFormat("<option value = ""{0}"" {1}> {2}</Option>", tipo.ID, IIf(pTipo = tipo.ID, selected, ""), tipo.DESCRICAO)
        Next
        Return retorno.ToString

    End Function

    Public Shared Function RetornaTabelaPeriodosDia(pData As Date) As String
        Const SEM_PERIODO = "<tr><td colspan=""4"">Sem período cadastrado</td></tr>"

        Dim listaAtividadesPeriodos As New List(Of clsPeriodosAtividades)
        Dim linhasPeriodo As String = vbNullString

        listaAtividadesPeriodos = New clsAdicionarDAO().retornaPeriodoAtividades(pData)


        For Each periodo In listaAtividadesPeriodos
            Dim linha = New List(Of clsColunasTabela)
            linha.Add(New clsColunasTabela(periodo.descricao_tipo))
            linha.Add(New clsColunasTabela(periodo.codigo_atividade))
            linha.Add(New clsColunasTabela(periodo.hora_inicial))
            linha.Add(New clsColunasTabela(periodo.hora_final))
            linhasPeriodo &= clsHTMLTools.funLinhaTabela(linha)
        Next

        If linhasPeriodo = vbNullString Then
            linhasPeriodo = SEM_PERIODO
        End If

        Return RetornaTabelaPeriodosDia(linhasPeriodo)
    End Function

    Public Shared Function RetornaTabelaPeriodosDia(pLinhas As String) As String
        Dim texto As New StringBuilder(vbNullString)
        'display table nowrap table-hover table-info table-striped table-sm
        texto.AppendFormat("
                <table id=""tablePeriodosDia"" class=""table table-bordered table-sm table-hover table-primary table-striped"" cellspacing=""0"" name=""tablePeriodosDia"">
                <thead>
                    <tr>
                        <th>Tipo</th>
                        <th>Código</th>
                        <th>De</th>
                        <th>Ate</th>
                    </tr>
                </thead>
                <tbody>
                    {0}
                </tbody>
            </table>
            ", pLinhas)
        Return texto.ToString
    End Function

    Public Shared Function RetornaMesesCombo(pMesFiltro As Integer) As String
        Dim retorno As New StringBuilder(vbNullString)
        Dim selected As String = "selected"

        retorno.AppendFormat("<option value = ""1"" {0}> Janeiro</Option>", IIf(pMesFiltro = 1, selected, ""))
        retorno.AppendFormat("<option value = ""2"" {0}> Fevereiro</Option>", IIf(pMesFiltro = 2, selected, ""))
        retorno.AppendFormat("<option value = ""3"" {0}> Março</Option>", IIf(pMesFiltro = 3, selected, ""))
        retorno.AppendFormat("<option value = ""4"" {0}> Abril</Option>", IIf(pMesFiltro = 4, selected, ""))
        retorno.AppendFormat("<option value = ""5"" {0}> Maio</Option>", IIf(pMesFiltro = 5, selected, ""))
        retorno.AppendFormat("<option value = ""6"" {0}> Junho</Option>", IIf(pMesFiltro = 6, selected, ""))
        retorno.AppendFormat("<option value = ""7"" {0}> Julho</Option>", IIf(pMesFiltro = 7, selected, ""))
        retorno.AppendFormat("<option value = ""8"" {0}> Agosto</Option>", IIf(pMesFiltro = 8, selected, ""))
        retorno.AppendFormat("<option value = ""9"" {0}> Setembro</Option>", IIf(pMesFiltro = 9, selected, ""))
        retorno.AppendFormat("<option value = ""10"" {0}> Outubro</Option>", IIf(pMesFiltro = 10, selected, ""))
        retorno.AppendFormat("<option value = ""11"" {0}> Novembro</Option>", IIf(pMesFiltro = 11, selected, ""))
        retorno.AppendFormat("<option value = ""12"" {0}> Dezembro</Option>", IIf(pMesFiltro = 12, selected, ""))

        Return retorno.ToString

    End Function

End Class
