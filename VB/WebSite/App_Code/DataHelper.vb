﻿Imports System
Imports System.Data.OleDb
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Internal

''' <summary>
''' Summary description for DataHelper
''' </summary>
Public Module DataHelper
	Public Sub SetupDefaultMappings(ByVal control As ASPxScheduler)
		SetupDefaultMappingsSiteMode(control)

	End Sub
	'
	Public Sub SetupCustomEventsMappings(ByVal control As ASPxScheduler)
		SetupDefaultMappingsSiteMode(control)
	End Sub
	Private Sub SetupDefaultMappingsSiteMode(ByVal control As ASPxScheduler)
		Dim storage As ASPxSchedulerStorage = control.Storage
		storage.BeginUpdate()
		Try
			Dim resourceMappings As ASPxResourceMappingInfo = storage.Resources.Mappings
			resourceMappings.ResourceId = "Id"
			resourceMappings.Caption = "Caption"

			Dim appointmentMappings As ASPxAppointmentMappingInfo = storage.Appointments.Mappings
			appointmentMappings.AppointmentId = "Id"
			appointmentMappings.Start = "StartTime"
			appointmentMappings.End = "EndTime"
			appointmentMappings.Subject = "Subject"
			appointmentMappings.AllDay = "AllDay"
			appointmentMappings.Description = "Description"
			appointmentMappings.Label = "Label"
			appointmentMappings.Location = "Location"
			appointmentMappings.RecurrenceInfo = "RecurrenceInfo"
			appointmentMappings.ReminderInfo = "ReminderInfo"
			appointmentMappings.ResourceId = "OwnerId"
			appointmentMappings.Status = "Status"
			appointmentMappings.Type = "EventType"

			Dim mapping As New ASPxAppointmentCustomFieldMapping("Price", "Price")
			storage.Appointments.CustomFieldMappings.Add(mapping)
		Finally
			storage.EndUpdate()
		End Try
	End Sub
	Public Sub ProvideRowInsertion(ByVal control As ASPxScheduler, ByVal dataSource As DataSourceControl)
		Dim objectDataSource As ObjectDataSource = TryCast(dataSource, ObjectDataSource)
		If objectDataSource IsNot Nothing Then
			Dim provider As New ObjectDataSourceRowInsertionProvider()
			provider.ProvideRowInsertion(control, objectDataSource)
		End If
	End Sub
End Module
Public Class ObjectDataSourceRowInsertionProvider

	Public Sub ProvideRowInsertion(ByVal control As ASPxScheduler, ByVal dataSource As ObjectDataSource)
		AddHandler control.AppointmentInserting, AddressOf ControlOnAppointmentInserting
	End Sub
	Protected Sub ControlOnAppointmentInserting(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)
		Dim storage As ASPxSchedulerStorage = DirectCast(sender, ASPxSchedulerStorage)
		Dim apt As Appointment = CType(e.Object, Appointment)
		storage.SetAppointmentId(apt, "a" & apt.GetHashCode())
	End Sub
End Class

