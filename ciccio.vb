Imports Microsoft.VisualBasic
Imports RestSharp
Public Class ControllerFornitori
    Inherits GecassioController
    Sub New(EndPoint As String)
        MyBase.New(EndPoint)
    End Sub
    Public Function GetFornitori(categoria As String) As Fornitori.Root
        Return Me.Send(Of Fornitori.Root)("GET", "/IX_CLIEN?tipooperazione=T&filtrocat=" & categoria)
    End Function

    Public Function GetFornitoriByIva(iva As String) As FornitoriFull.Root
        Return Me.Send(Of FornitoriFull.Root)("GET", "/IX_CLIEN?TipoOperazione=P&PivaCliente=" & iva)
        'Dim Rest As New RestClient(Me.EndPoint)
        'Dim request As New RestRequest(")
        ''Dim request = New RestRequest("statuses/home_timeline.json", DataFormat.Json);
        'Dim Resp As RestSharp.RestResponse = Rest.Get(request)
        'Dim forn = Newtonsoft.Json.JsonConvert.DeserializeObject(Of FornitoriFull.Root)(Resp.Content)
        'Return forn
    End Function

    Public Function GetFornitoriByRagSoc(ragSoc As String) As FornitoriFull.Root
        Return Me.Send(Of FornitoriFull.Root)("GET", "/IX_CLIEN?TipoOperazione=S&ragsoc=" & ragSoc)
        'Dim Rest As New RestClient(Me.EndPoint)
        'Dim request As New RestRequest("/IX_CLIEN?TipoOperazione=S&ragsoc=" & ragSoc)
        ''Dim request = New RestRequest("statuses/home_timeline.json", DataFormat.Json);
        'Dim Resp As RestSharp.RestResponse = Rest.Get(request)
        'Dim forn = Newtonsoft.Json.JsonConvert.DeserializeObject(Of FornitoriFull.Root)(Resp.Content)
        'Return forn
    End Function

End Class
