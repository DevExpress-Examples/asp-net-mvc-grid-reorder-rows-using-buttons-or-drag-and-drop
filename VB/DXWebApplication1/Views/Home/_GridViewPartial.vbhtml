@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "gridView"
            settings.CallbackRouteValues = New With { _
                Key .Controller = "Home", _
                Key .Action = "GridViewPartial" _
            }
            settings.KeyFieldName = "ProductID"
            settings.SettingsBehavior.AllowFocusedRow = True
            settings.SettingsBehavior.ProcessFocusedRowChangedOnServer = True
            settings.SettingsBehavior.AllowSort = False
            settings.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
            settings.Columns.Add("ProductID")
            settings.Columns.Add("ProductName")
            settings.Columns.Add("UnitPrice")
            settings.Columns.Add(
                Sub(column)
                        column.FieldName = "DisplayIndex"
                        column.Visible = False
                        column.SortOrder = ColumnSortOrder.Ascending
                End Sub)

            settings.ClientSideEvents.Init = "gridView_Init"
            settings.ClientSideEvents.EndCallback = "gridView_EndCallback"
            settings.Styles.Row.CssClass = "draggable"
            settings.CustomJSProperties =
                Sub(s, e)
                        Dim gridView = DirectCast(s, MVCxGridView)
                        gridView.JSProperties("cpbtMoveUp_Enabled") = gridView.FocusedRowIndex > 0
                        gridView.JSProperties("cpbtMoveDown_Enabled") = gridView.FocusedRowIndex < (gridView.VisibleRowCount - 1)
                End Sub
            settings.HtmlRowPrepared =
                Sub(s, e)
                        If e.RowType = GridViewRowType.Data Then
                            Dim displayIndex As Object = e.GetValue("DisplayIndex")
                            If displayIndex IsNot Nothing Then
                                e.Row.Attributes.Add("displayIndex", displayIndex.ToString())
                            End If
                        End If
                End Sub
            settings.BeforeGetCallbackResult =
                Sub(s, e)
                        If ViewBag.VisibleIndex Is Nothing Then
                            Return
                        End If
                        Dim gridView = DirectCast(s, MVCxGridView)
                        gridView.FocusedRowIndex = ViewBag.VisibleIndex
                End Sub
    End Sub).Bind(Model).GetHtml()