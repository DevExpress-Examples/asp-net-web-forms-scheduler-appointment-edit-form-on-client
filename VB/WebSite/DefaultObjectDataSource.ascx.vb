Imports System
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxScheduler

Partial Public Class DefaultObjectDataSource
	Inherits System.Web.UI.UserControl

'INSTANT VB NOTE: The field sessionName was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private sessionName_Conflict As String = "CustomEvents"
	Private rnd As New Random()


	Public ReadOnly Property AppointmentDataSource() As ObjectDataSource
		Get
			Return objAppointmentDataSource
		End Get
	End Property
	Public ReadOnly Property ResourceDataSource() As ObjectDataSource
		Get
			Return objResourceDataSource
		End Get
	End Property
	Public Property SessionName() As String
		Get
			Return sessionName_Conflict
		End Get
		Set(ByVal value As String)
			sessionName_Conflict = value
		End Set
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Public Sub AttachTo(ByVal control As ASPxScheduler)
		control.AppointmentDataSource = Me.AppointmentDataSource
		control.ResourceDataSource = Me.ResourceDataSource
		control.DataBind()
	End Sub
	Protected Sub resourcesDataSource_ObjectCreated(ByVal sender As Object, ByVal e As ObjectDataSourceEventArgs)
		Dim resources As CustomResourceList = GetCustomResources()
		e.ObjectInstance = New CustomResourceDataSource(resources)
	End Sub
	Protected Sub appointmentsDataSource_ObjectCreated(ByVal sender As Object, ByVal e As ObjectDataSourceEventArgs)
'INSTANT VB NOTE: The variable events was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim events_Conflict As CustomEventList = GetCustomEvents()
		e.ObjectInstance = New CustomEventDataSource(events_Conflict)
	End Sub
	Private resourceIdList() As Object = { 0, 1, 2 }
	Private resourceCaptionList() As String = { "Sarah Brighton", "Ryan Fischer", "Andrew Miller" }
	Private Function GetCustomResources() As CustomResourceList
'INSTANT VB NOTE: The variable sessionName was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim sessionName_Conflict As String = "R" & SessionName
		Dim resources As CustomResourceList = TryCast(Session(sessionName_Conflict), CustomResourceList)
		If resources IsNot Nothing Then
			Return resources
		End If
		resources = New CustomResourceList()
		PopulateResourceList(resources)
		Session(sessionName_Conflict) = resources
		Return resources
	End Function
	Private Sub PopulateResourceList(ByVal resources As CustomResourceList)
		Dim count As Integer = resourceIdList.Length
		For i As Integer = 0 To count - 1
			Dim resource As New CustomResource()
			resource.Id = resourceIdList(i)
			resource.Caption = resourceCaptionList(i)
			resources.Add(resource)
		Next i
	End Sub
	Protected Function GetCustomEvents() As CustomEventList
'INSTANT VB NOTE: The variable sessionName was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim sessionName_Conflict As String = "A" & SessionName
'INSTANT VB NOTE: The variable events was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim events_Conflict As CustomEventList = TryCast(Session(sessionName_Conflict), CustomEventList)
		If events_Conflict IsNot Nothing Then
			Return events_Conflict
		End If
		events_Conflict = New CustomEventList()
		PopulateEventList(events_Conflict)
		Session(sessionName_Conflict) = events_Conflict
		Return events_Conflict
	End Function
	Protected Sub PopulateEventList(ByVal eventList As CustomEventList)
		Dim count As Integer = Me.resourceIdList.Length
		For i As Integer = 0 To count - 1
			Dim resourceId As Object = Me.resourceIdList(i)
			Dim resourceCaption As String = Me.resourceCaptionList(i)
			eventList.Add(CreateEvent(resourceId, resourceCaption & " meeting", 2, 2))
			eventList.Add(CreateEvent(resourceId, resourceCaption & " travel", 3, 0))
			eventList.Add(CreateEvent(resourceId, resourceCaption & " time off", 0, 1))
		Next i
	End Sub
	Private Function CreateEvent(ByVal resourceId As Object, ByVal subject As String, ByVal status As Integer, ByVal label As Integer) As CustomEvent
		Dim customEvent As New CustomEvent()
		customEvent.Subject = subject
		customEvent.OwnerId = resourceId
		Dim rangeInHours As Integer = 48
		customEvent.StartTime = DateTime.Today.Add(TimeSpan.FromHours(rnd.Next(0, rangeInHours)))
		customEvent.EndTime = customEvent.StartTime.Add(TimeSpan.FromHours(rnd.Next(0, rangeInHours \ 8)))
		customEvent.Status = status
		customEvent.Label = label
		customEvent.Id = "ev" & customEvent.GetHashCode()
		Return customEvent
	End Function
	Public Sub Clear()
'INSTANT VB NOTE: The variable events was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim events_Conflict As New CustomEventList()
		Session(SessionName) = events_Conflict
	End Sub
End Class
