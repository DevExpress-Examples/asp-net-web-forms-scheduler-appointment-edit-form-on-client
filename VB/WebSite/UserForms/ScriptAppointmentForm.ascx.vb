Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports DevExpress.Web.Internal
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.XtraScheduler

Partial Public Class UserForms_ScriptAppointmentForm
	Inherits ASPxSchedulerClientFormBase

	#Region "Fields"
'INSTANT VB NOTE: The field labelDataSource was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private labelDataSource_Conflict As IEnumerable
'INSTANT VB NOTE: The field statusDataSource was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private statusDataSource_Conflict As IEnumerable
'INSTANT VB NOTE: The field resourceDataSource was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private resourceDataSource_Conflict As IEnumerable
'INSTANT VB NOTE: The field scheduler was renamed since Visual Basic does not allow fields to have the same name as other class members:
	Private scheduler_Conflict As ASPxScheduler
	#End Region

	#Region "Properties"
	Public Overrides ReadOnly Property ClassName() As String
		Get
			Return "ASPxClientAppointmentForm"
		End Get
	End Property
	Private ReadOnly Property Scheduler() As ASPxScheduler
		Get
			If scheduler_Conflict Is Nothing Then
				Me.scheduler_Conflict = TryCast(FindControlById(SchedulerId), ASPxScheduler)
			End If
			Return scheduler_Conflict
		End Get
	End Property
	Protected ReadOnly Property LabelDataSource() As IEnumerable
		Get
			If labelDataSource_Conflict Is Nothing Then
				Me.labelDataSource_Conflict = ASPxSchedulerFormDataHelper.CreateLabelDataSource(Scheduler)
			End If
			Return labelDataSource_Conflict
		End Get
	End Property
	Protected ReadOnly Property StatusDataSource() As IEnumerable
		Get
			If statusDataSource_Conflict Is Nothing Then
				Me.statusDataSource_Conflict = ASPxSchedulerFormDataHelper.CreateStatusesDataSource(Scheduler)
			End If
			Return statusDataSource_Conflict
		End Get
	End Property
	Protected ReadOnly Property ResourceDataSource() As IEnumerable
		Get
			If resourceDataSource_Conflict Is Nothing Then
				Me.resourceDataSource_Conflict = ASPxSchedulerFormDataHelper.CreateResourceDataSource(Scheduler)
			End If
			Return resourceDataSource_Conflict
		End Get
	End Property
	#End Region 

	Protected Overrides Function GetChildControls() As Control()
'INSTANT VB NOTE: The variable controls was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim controls_Conflict() As Control = { edtStartDate, edtEndDate, tbSubject, tbDescription, tbLocation, edtLabel, edtStatus, chkAllDay, chkRecurrence, edtResource, recurrenceControl, btnOk, btnCancel, btnDelete, edtPrice }
		Return controls_Conflict
	End Function
End Class

