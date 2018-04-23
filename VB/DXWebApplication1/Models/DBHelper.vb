Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace DXWebApplication1.Models

	Public Class DBHelper

		Private Const NorthwindDataContextKey As String = "DXNorthwindDataContext"

		Public Shared ReadOnly Property DB() As NwindDataClassesDataContext
			Get
				If HttpContext.Current.Items(NorthwindDataContextKey) Is Nothing Then
					HttpContext.Current.Items(NorthwindDataContextKey) = New NwindDataClassesDataContext()
				End If
				Return CType(HttpContext.Current.Items(NorthwindDataContextKey), NwindDataClassesDataContext)
			End Get
		End Property

		Public Shared Function GetKeyIdByDisplayIndex(ByVal displayIndex As Nullable(Of Integer)) As Integer
			Dim model = DB.Products
			Dim rowKey = model.Where(Function(q) q.DisplayIndex.Equals(displayIndex)).Select(Function(q) q.ProductID).FirstOrDefault()
			Return rowKey
		End Function

		Public Shared Sub UpdateDisplayIndex(ByVal rowKey As Nullable(Of Integer), ByVal displayIndex As Nullable(Of Integer))
			Dim model = DB.Products
			Dim product = model.Where(Function(q) q.ProductID.Equals(rowKey)).FirstOrDefault()
			product.DisplayIndex = displayIndex
			DB.SubmitChanges()
		End Sub
	End Class
End Namespace