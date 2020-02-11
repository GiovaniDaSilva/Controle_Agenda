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




    Public shared sub TrataParametrosComuns(ByRef pagina As string)
        pagina = pagina.Replace("{p_menu_pagina}",retornaMenuPagina)
    End sub
End Class
