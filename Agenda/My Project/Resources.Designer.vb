﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:4.0.30319.42000
'
'     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
'     o código for gerado novamente.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    'através de uma ferramenta como ResGen ou Visual Studio.
    'Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    'com a opção /str, ou recrie o projeto do VS.
    '''<summary>
    '''  Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
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
        '''  Substitui a propriedade CurrentUICulture do thread atual para todas as
        '''  pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
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
        '''  Consulta uma cadeia de caracteres localizada semelhante a     &lt;html&gt;
        '''    &lt;head&gt;
        '''		&lt;style&gt;
        '''			.Titulo{                                            
        '''                color: darkblue;
        '''                font-family: &apos;Segoe UI&apos;, Tahoma, Geneva, Verdana, sans-serif;
        '''                
        '''			}
        '''
        '''            .TituloPrincipal{     
        '''                color: darkblue;
        '''                font-family: &apos;Segoe UI&apos;, Tahoma, Geneva, Verdana, sans-serif;                                                       
        '''                text-align: center;
        '''                border-radius: 4px;
        '''			 [o restante da cadeia de caracteres foi truncado]&quot;;.
        '''</summary>
        Friend ReadOnly Property Versoes() As String
            Get
                Return ResourceManager.GetString("Versoes", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
