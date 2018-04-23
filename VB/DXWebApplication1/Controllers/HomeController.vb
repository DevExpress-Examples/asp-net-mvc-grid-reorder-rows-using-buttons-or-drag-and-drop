Imports Microsoft.VisualBasic
Imports DXWebApplication1.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc

Namespace DXWebApplication1.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		<ValidateInput(False)> _
		Public Function GridViewPartial(ByVal focusedRowIndex As Nullable(Of Integer), ByVal draggingIndex As Nullable(Of Integer), ByVal targetIndex As Nullable(Of Integer), ByVal command As String) As ActionResult
			Dim model = DBHelper.DB.Products.OrderBy(Function(q) q.DisplayIndex).Take(10)

			If command = "MOVEUP" OrElse command = "MOVEDOWN" Then
				Dim index As Integer = focusedRowIndex.Value
				Dim focusedRowKey As Integer = DBHelper.GetKeyIdByDisplayIndex(index)
				Dim newIndex As Integer = index
				If command = "MOVEUP" Then
					newIndex = If((index = 0), index, index - 1)
				End If
				If command = "MOVEDOWN" Then
					newIndex = If((index = model.Count()), index, index + 1)
				End If
				Dim rowKey As Integer = DBHelper.GetKeyIdByDisplayIndex(newIndex)
				DBHelper.UpdateDisplayIndex(focusedRowKey, newIndex)
				DBHelper.UpdateDisplayIndex(rowKey, index)
				ViewBag.VisibleIndex = newIndex
			End If
			If command = "DRAGROW" Then
				Dim draggingRowKey As Integer = DBHelper.GetKeyIdByDisplayIndex(draggingIndex)
				Dim targetRowKey As Integer = DBHelper.GetKeyIdByDisplayIndex(targetIndex)
				Dim draggingDirection As Integer = If((targetIndex < draggingIndex), 1, -1)
				For rowIndex As Integer = 0 To model.Count() - 1
					Dim rowKey As Integer = DBHelper.GetKeyIdByDisplayIndex(rowIndex)
					If (rowIndex > Math.Min(targetIndex.Value, draggingIndex.Value)) AndAlso (rowIndex < Math.Max(targetIndex.Value, draggingIndex.Value)) Then
						DBHelper.UpdateDisplayIndex(rowKey, rowIndex + draggingDirection)
					End If
				Next rowIndex
				DBHelper.UpdateDisplayIndex(draggingRowKey, targetIndex)
				DBHelper.UpdateDisplayIndex(targetRowKey, targetIndex + draggingDirection)
			End If

			Return PartialView("_GridViewPartial", model)
		End Function
	End Class
End Namespace
