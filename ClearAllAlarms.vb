
' ScriptType: ServerScript
' ScriptLanguage: VB

Imports System
Imports System.Diagnostics
Imports System.Collections.Generic
Imports log4net
Imports Bosch.Vms.Core
Imports Bosch.Vms.SDK

' TenGbps Added Imports
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Text
Imports System.IO

<BvmsScriptClass()> _
Public Class ServerScript 
    Implements IDisposable
    Private Shared Logger As ILog
    Private Shared Api As IServerApi 

    Sub New(api As IServerApi)
        Me.Logger = LogManager.GetLogger("ServerScript")
        Me.Api = api
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Use this method to cleanup any resources here (consider fully implementing the Dispose pattern).
        ' For example, stop and dispose any started timers. Ensure that all threads that were started are stopped here.
        ' DO NOT BLOCK in this method for a very long time, as this may block the applications current activity.
    End Sub

    <Scriptlet("30088a27-4314-4551-b073-a9cf2d744497")> _
    Public Sub ClearAllAlarms(e As EventData)
        For Each Alarm As AlarmData In Api.AlarmManager.GetAlarms()
			Api.AlarmManager.Accept(Alarm)
			Api.AlarmManager.Clear(Alarm)
		Next
    End Sub
End Class
