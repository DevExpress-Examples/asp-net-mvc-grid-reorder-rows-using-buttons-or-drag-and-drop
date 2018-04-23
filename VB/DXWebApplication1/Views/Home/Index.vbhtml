@Code
    ViewBag.Title = "Index"
End Code

<h2>Index</h2>

<style>
    .hover {
        background-color: lightblue;
    }

    .activeHover {
        background-color: lightgray;
    }

    .ui-draggable-dragging {
        background-color: lightgreen;
        color: White;
    }
</style>

<script type="text/javascript">
    MVCxClientGlobalEvents.AddControlsInitializedEventHandler(InitalizejQuery);

    function InitalizejQuery() {
        $('.draggable').draggable({
            helper: 'clone',
            start: function (ev, ui) {
                var $draggingElement = $(ui.helper);
                $draggingElement.width(gridView.GetWidth());
            }
        });
        $('.draggable').droppable({
            activeClass: "hover",
            tolerance: "intersect",
            hoverClass: "activeHover",
            drop: function (event, ui) {
                var draggingSortIndex = ui.draggable.attr("displayIndex");
                var targetSortIndex = $(this).attr("displayIndex");
                gridView.PerformCallback(
                    {
                        draggingIndex: draggingSortIndex,
                        targetIndex: targetSortIndex,
                        command: "DRAGROW"
                    });
            }
        });
    }
    function UpdatedGridViewButtonsState(grid) {
        btMoveUp.SetEnabled(grid.cpbtMoveUp_Enabled);
        btMoveDown.SetEnabled(grid.cpbtMoveDown_Enabled);
    }

    function gridView_Init(s, e) {
        UpdatedGridViewButtonsState(s);
    }

    function gridView_EndCallback(s, e) {
        UpdatedGridViewButtonsState(s);
        s.AdjustControl();
    }

    function btMoveUp_Click(s, e) {
        gridView.PerformCallback(
            {
                focusedRowIndex: gridView.GetFocusedRowIndex(),
                command: "MOVEUP"
            });
    }

    function btMoveDown_Click(s, e) {
        gridView.PerformCallback(
            {
                focusedRowIndex: gridView.GetFocusedRowIndex(),
                command: "MOVEDOWN"
            });
    }
</script>

<table>
    <tr>
        <td rowspan="2">
            @Html.Action("GridViewPartial")
        </td>
        <td style="vertical-align: bottom">
            @Html.DevExpress().Button(
            Sub(settings)
                    settings.Name = "btMoveUp"
                    settings.Text = "Up"
                    settings.Width = Unit.Pixel(100)
                    settings.UseSubmitBehavior = False
                    settings.ClientSideEvents.Click = "btMoveUp_Click"
            End Sub).GetHtml()
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            @Html.DevExpress().Button(
            Sub(settings)
                    settings.Name = "btMoveDown"
                    settings.Text = "Down"
                    settings.Width = Unit.Pixel(100)
                    settings.UseSubmitBehavior = False
                    settings.ClientSideEvents.Click = "btMoveDown_Click"
            End Sub).GetHtml()
        </td>
    </tr>
</table>