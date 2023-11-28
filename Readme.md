<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1547)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->


# How to implement a client-side appointment editing form with custom fields
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1547/)**
<!-- run online end -->

This example demonstrates how to use client appointment objects and methods to implement an appointment edit forms with custom fields that operate via client scripts.

In this example, popup menu commands are intercepted by JavaScript functions, which create the <a href="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxSchedulerScriptsASPxClientAppointmenttopic">ASPxClientAppointment</a> for the selected interval and resource or use the client Scheduler’s <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerScriptsASPxClientScheduler_GetSelectedAppointmentIdstopic">GetSelectedAppointmentIds</a> and <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerScriptsASPxClientScheduler_GetAppointmentByIdtopic">GetAppointmentById</a> methods to obtain the client appointment. Then, the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerScriptsASPxClientScheduler_RefreshClientAppointmentPropertiestopic">RefreshClientAppointmentProperties</a> method updates the client appointment properties and invokes the scripting appointment form.<br />
The scripting appointment editing form consists of two templates – ScriptAppointmentForm.ascx and ScriptRecurrenceForm.ascx. Their code implements the logic required to populate the form’s controls and update the appointment with new values. 
  
When a user clicks a button on the form, one of the following methods is called: [UpdateAppointment](https://docs.devexpress.com/AspNet/js-ASPxClientScheduler.UpdateAppointment(apt)), [InsertAppointment](https://docs.devexpress.com/AspNet/js-ASPxClientScheduler.InsertAppointment(apt)), or [DeleteAppointment](https://docs.devexpress.com/AspNet/js-ASPxClientScheduler.DeleteAppointment(apt)). These methods perform a callback and initiate server processing of the appointment.

## Files to Review

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [ScriptAppointmentForm.ascx](./CS/WebSite/UserForms/ScriptAppointmentForm.ascx) (VB: [ScriptAppointmentForm.ascx](./VB/WebSite/UserForms/ScriptAppointmentForm.ascx))
* [ScriptRecurrenceForm.ascx](./CS/WebSite/UserForms/ScriptRecurrenceForm.ascx) (VB: [ScriptRecurrenceForm.ascx](./VB/WebSite/UserForms/ScriptRecurrenceForm.ascx))
