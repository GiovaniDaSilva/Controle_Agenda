﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Agenda.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        '''</summary>
        Friend ReadOnly Property Agenda() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("Agenda", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html lang=&quot;pr-bt&quot;&gt;
        '''&lt;head&gt;
        '''    &lt;meta name=&quot;viewport&quot; content=&quot;width=device-width, initial-scale=1&quot;&gt;
        '''    {p_links_comum_pagina}
        '''
        '''
        '''    &lt;!--Seleção da linha da tabela--&gt;
        '''    &lt;script src=&quot;https://cdn.datatables.net/select/1.3.1/js/dataTables.select.min.js&quot;&gt;&lt;/script&gt;
        '''    &lt;link rel=&quot;stylesheet&quot; href=&quot;https://cdn.datatables.net/select/1.3.1/css/select.bootstrap4.min.css&quot; /&gt;
        '''
        '''    &lt;!--Converte Tabela em Json--&gt;
        '''    &lt;script src=&quot;https://cdn.jsdelivr.net/npm/table-to-json@1.0.0/lib/jquery.tabletojson.min.js [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property CadastroAtividade() As String
            Get
                Return ResourceManager.GetString("CadastroAtividade", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html&gt;
        '''&lt;head&gt;
        '''
        '''    {p_links_comum_pagina}
        '''
        '''
        '''    &lt;!--Seleção da linha da tabela--&gt;
        '''    &lt;script src=&quot;https://cdn.datatables.net/select/1.3.1/js/dataTables.select.min.js&quot;&gt;&lt;/script&gt;
        '''    &lt;link rel=&quot;stylesheet&quot; href=&quot;https://cdn.datatables.net/select/1.3.1/css/select.bootstrap4.min.css&quot; /&gt;
        '''
        '''    &lt;!--Converte Tabela em Json--&gt;
        '''    &lt;script src=&quot;https://cdn.jsdelivr.net/npm/table-to-json@1.0.0/lib/jquery.tabletojson.min.js&quot; integrity=&quot;sha256-H8xrCe0tZFi/C2CgxkmiGksqVaxhW0PFcUKZJZo1yNU=&quot; crossorigin=&quot;anonym [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property CadastroTipo() As String
            Get
                Return ResourceManager.GetString("CadastroTipo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html&gt;
        '''&lt;head&gt;
        '''
        '''    {p_links_comum_pagina}
        '''
        '''    &lt;!--Converte Tabela em Json--&gt;
        '''    &lt;script src=&quot;https://cdn.jsdelivr.net/npm/table-to-json@1.0.0/lib/jquery.tabletojson.min.js&quot; integrity=&quot;sha256-H8xrCe0tZFi/C2CgxkmiGksqVaxhW0PFcUKZJZo1yNU=&quot; crossorigin=&quot;anonymous&quot;&gt;&lt;/script&gt;
        '''
        '''    &lt;!-- CSS dependencies --&gt;
        '''    &lt;link rel=&quot;stylesheet&quot; type=&quot;text/css&quot; href=&quot;bootstrap.min.css&quot;&gt;
        '''
        '''    &lt;!-- JS dependencies --&gt;
        '''    &lt;script src=&quot;https://cdnjs.cloudflare.com/ajax/libs/bootbox.js/5.4.0/bootbox.min.js&quot;&gt;&lt;/script [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property Configuracao() As String
            Get
                Return ResourceManager.GetString("Configuracao", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html lang=&quot;pr-bt&quot;&gt;
        '''&lt;head&gt;
        '''    &lt;meta name=&quot;viewport&quot; content=&quot;width=device-width, initial-scale=1&quot;&gt;
        '''    {p_links_comum_pagina}
        '''
        '''
        '''    &lt;!--Seleção da linha da tabela--&gt;
        '''    &lt;script src=&quot;https://cdn.datatables.net/select/1.3.1/js/dataTables.select.min.js&quot;&gt;&lt;/script&gt;
        '''    &lt;link rel=&quot;stylesheet&quot; href=&quot;https://cdn.datatables.net/select/1.3.1/css/select.bootstrap4.min.css&quot; /&gt;
        '''
        '''    &lt;!--Converte Tabela em Json--&gt;
        '''    &lt;script src=&quot;https://cdn.jsdelivr.net/npm/table-to-json@1.0.0/lib/jquery.tabletojson.min.js [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property ControlePonto() As String
            Get
                Return ResourceManager.GetString("ControlePonto", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Engrenagem() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Engrenagem", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;!DOCTYPE html&gt;
        '''
        '''&lt;html&gt;
        '''&lt;head&gt;
        '''
        '''    {p_links_comum_pagina}
        '''
        '''
        '''    &lt;!--https://br.freepik.com/icones-gratis/caderno_928989.htm#page=2&amp;query=agenda&amp;position=30--&gt;
        '''
        '''    &lt;style&gt;
        '''
        '''        [p_style_comum_pagina]
        '''
        '''        .FormMes {
        '''            margin-bottom: 50px;
        '''        }
        '''    &lt;/style&gt;
        '''
        '''    {p_titulo_pagina}
        '''&lt;/head&gt;
        '''
        '''
        '''&lt;body class=&quot;Fundo&quot;&gt;
        '''    &lt;header&gt;
        '''        {p_menu_pagina}        
        '''    &lt;/header&gt;
        '''    
        '''    
        '''    &lt;h1 class=&quot;TituloPrincipal&quot;&gt;Gráfico de Atividades&lt;/h1&gt;&lt;br /&gt;
        '''    &lt;p class= [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property GraficoAtividades() As String
            Get
                Return ResourceManager.GetString("GraficoAtividades", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Historicos() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Historicos", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html lang=&quot;pr-bt&quot;&gt;
        '''&lt;head&gt;
        '''    &lt;meta name=&quot;viewport&quot; content=&quot;width=device-width, initial-scale=1&quot;&gt;
        '''    {p_links_comum_pagina}
        '''
        '''
        '''    &lt;!--Seleção da linha da tabela--&gt;
        '''    &lt;script src=&quot;https://cdn.datatables.net/select/1.3.1/js/dataTables.select.min.js&quot;&gt;&lt;/script&gt;
        '''    &lt;link rel=&quot;stylesheet&quot; href=&quot;https://cdn.datatables.net/select/1.3.1/css/select.bootstrap4.min.css&quot; /&gt;
        '''
        '''    &lt;!--Ordenação por Data--&gt;
        '''    &lt;script src=&quot;https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.4/moment.min.js&quot;&gt;&lt;/script&gt;
        '''   [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property Home() As String
            Get
                Return ResourceManager.GetString("Home", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html&gt;
        '''&lt;head&gt;
        '''
        '''    {p_links_comum_pagina}
        '''
        '''    &lt;style&gt;
        '''        [p_style_comum_pagina]
        '''
        '''        .estiloTitulo {
        '''            color: black;
        '''            font-weight: bold;
        '''            font-size: 12px;
        '''            font-family: &apos;Segoe UI&apos;, Tahoma, Geneva, Verdana, sans-serif;
        '''        }
        '''
        '''        .estiloTituloDestaque {
        '''            color: darkblue;
        '''            font-weight: bold;
        '''            text-decoration: underline;
        '''            font-size: 14px;
        '''            font-family: &apos;Segoe UI&apos;, Tahoma, Gene [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property ImpressaoAtividade() As String
            Get
                Return ResourceManager.GetString("ImpressaoAtividade", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html&gt;
        '''&lt;head&gt;
        '''
        '''    {p_links_comum_pagina}
        '''
        '''    &lt;style&gt;
        '''        [p_style_comum_pagina]
        '''
        '''        .estiloTitulo {
        '''            color: black;
        '''            font-weight: bold;
        '''            font-size: 12px;
        '''            font-family: &apos;Segoe UI&apos;, Tahoma, Geneva, Verdana, sans-serif;
        '''        }
        '''
        '''        .estiloTituloDestaque {
        '''            color: darkblue;
        '''            font-weight: bold;
        '''            text-decoration: underline;
        '''            font-size: 14px;
        '''            font-family: &apos;Segoe UI&apos;, Tahoma, Gene [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property ImpressaoPonto() As String
            Get
                Return ResourceManager.GetString("ImpressaoPonto", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html&gt;
        '''&lt;head&gt;
        '''
        '''    {p_links_comum_pagina}
        '''
        '''    &lt;style&gt;
        '''        [p_style_comum_pagina]
        '''    &lt;/style&gt;
        '''
        '''    {p_titulo_pagina}
        '''
        '''&lt;/head&gt;
        '''
        '''
        '''&lt;body class=&quot;Fundo&quot;&gt;
        '''    &lt;header&gt;
        '''        {p_menu_pagina}  
        '''    &lt;/header&gt;
        '''
        '''    &lt;h1 class=&quot;TituloPrincipal&quot;&gt;{p_titulo}&lt;/h1&gt;
        '''
        '''    &lt;div class=&quot;container-fluid&quot;&gt;
        '''        &lt;img src=&quot;https://image.flaticon.com/icons/svg/1603/1603229.svg&quot; style=&quot;width:100px; height: 100px; position: center &quot; /&gt;
        '''        {p_mensagem}
        '''    &lt;/div&gt;
        '''
        '''    
        '''
        '''&lt;/body&gt;
        '''
        '''
        '''&lt;/html&gt;.
        '''</summary>
        Friend ReadOnly Property Pagina_Não_Encontrada() As String
            Get
                Return ResourceManager.GetString("Pagina_Não_Encontrada", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html&gt;
        '''&lt;head&gt;
        '''
        '''    {p_links_comum_pagina}
        '''
        '''    &lt;style&gt;
        '''        [p_style_comum_pagina]
        '''    &lt;/style&gt;
        '''
        '''    {p_titulo_pagina}
        '''&lt;/head&gt;
        '''
        '''
        '''&lt;body class=&quot;Fundo&quot;&gt;
        '''    &lt;header&gt;
        '''        {p_menu_pagina}        
        '''    &lt;/header&gt;
        '''
        '''    &lt;h1 class=&quot;TituloPrincipal&quot;&gt;Atualizações&lt;/h1&gt;
        '''
        '''    &lt;div class=&quot;container-fluid&quot;&gt;
        '''
        '''        &lt;h2 class=&quot;Titulo&quot;&gt;v.2.4&lt;/h2&gt;
        '''        &lt;p class=&quot;Atualizacao&quot;&gt;
        '''            &lt;ul&gt;
        '''                &lt;li&gt;Adicionado novos parametros no sistema.&lt;/li&gt;
        '''                &lt;ul&gt;
        '''              [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property Versoes() As String
            Get
                Return ResourceManager.GetString("Versoes", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
