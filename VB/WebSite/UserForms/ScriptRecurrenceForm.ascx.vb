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
Imports DevExpress.Web.ASPxScheduler

Partial Public Class UserForms_ScriptRecurrenceForm
	Inherits ASPxSchedulerClientFormBase

	Public Overrides ReadOnly Property ClassName() As String
		Get
			Return "ASPxClientRecurrenceAppointmentForm"
		End Get
	End Property

	Protected Overrides Function GetChildControls() As Control()
'INSTANT VB NOTE: The variable controls was renamed since Visual Basic does not handle local variables named the same as class members well:
		Dim controls_Conflict() As Control = { edtDailyRecurrenceControl, edtWeeklyRecurrenceControl, edtMonthlyRecurrenceControl, edtYearlyRecurrenceControl, edtRecurrenceTypeEdit, edtRecurrenceRangeControl}
		Return controls_Conflict
	End Function
End Class
