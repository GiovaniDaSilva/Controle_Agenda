Imports System.Text

Public Class clsHTMLComum
    Public Shared Function retornaMenuPagina() As String
        Dim locMenu As new StringBuilder()

        locMenu.Append("
        <nav class=""navbar navbar-dark bg-primary"">            
                <div >
                    <a href=""Home"" id=""btn_home"" class=""btn btn-primary btn-outline-light "" >Home</a>
                    <a href=""Grafico"" id=""btn_grafico"" class=""btn btn-primary btn-outline-light my-2 my-sm-0"" >Grafico</a>
                    <a href=""Versoes"" id=""bt_versoes"" class=""btn btn-primary btn-outline-light my-2 my-sm-0"" >Versões</a>            
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

    Public Shared Function RetornaStyleComumPagina() As String
        Dim locMenu As New StringBuilder()

        locMenu.Append("
        .Titulo {
            color: darkblue;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .TituloPrincipal {
            color: darkblue;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            text-align: center;
            border-radius: 4px;
        }

        .Atualizacao {
            color: black;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .Fundo {
            background-color: lightblue;
        }

         ")
        Return locMenu.ToString
    End Function

    Public Shared Function RetornLinksComnsPagina() As String
        Dim texto As New StringBuilder

        texto.Append("
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

            <!--icone da agenda-->
            <link rel=""icon"" href=""https://image.flaticon.com/icons/png/512/124/124050.png"">
            <link rel=""stylesheet"" href=""https://fonts.googleapis.com/icon?family=Material+Icons"">
        ")
        Return texto.ToString
    End Function
    Public shared sub TrataParametrosComuns(ByRef pagina As string)
        pagina = pagina.Replace("{p_menu_pagina}", retornaMenuPagina)
        pagina = pagina.Replace("{p_titulo_pagina}", RetornaTituloPagina)
        pagina = pagina.Replace("[p_style_comum_pagina]", RetornaStyleComumPagina)
        pagina = pagina.Replace("{p_links_comum_pagina}", RetornLinksComnsPagina)

    End sub
End Class
