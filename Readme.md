<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128551862/14.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T191258)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Grid View for ASP.NET MVC - Reorder grid rows using buttons and drag-and-drop
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/128551862/)**
<!-- run online end -->

This example demonstrates how to use buttons and jQuery drag-and-drop functionality to reorder grid rows.

## Overview

Set up the grid and create an invisible column that stores row order indices. Sort the grid by this column and disable sorting at the control level.

```cshtml
@Html.DevExpress().GridView(settings => {
    settings.Name = "gridView";
    settings.SettingsBehavior.AllowSort = false;
    settings.Columns.Add(column => {
        column.FieldName = "DisplayIndex";
        column.Visible = false;
        column.SortOrder = ColumnSortOrder.Ascending;
    });
}).Bind(Model).GetHtml()
```

When a user clicks the button or drags and drops a row, the grid sends a callback to the server, sets the invisible column value to a new row order index, and updates grid data.

To enable jQuery drag-and-drop functionality, add a jQuery UI component to your project. Use one of the following approaches:

1. Add the `ThirdParty` attribute to the `resources` section and add a reference to the jQuery UI library to the `head` section after extension scripts.

    ```cs
    <resources>
        <add type="ThirdParty" />
    </resources>
    ```

    ```cs
    <head>
        <title>@ViewBag.Title</title>
        @Html.DevExpress().GetStyleSheets(
            new StyleSheet { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
            new StyleSheet { ExtensionSuite = ExtensionSuite.Editors },
            new StyleSheet { ExtensionSuite = ExtensionSuite.GridView }
        )
        @Html.DevExpress().GetScripts(
            new Script { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
            new Script { ExtensionSuite = ExtensionSuite.Editors },
            new Script { ExtensionSuite = ExtensionSuite.GridView }
        )
        <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"
            type="text/javascript"></script>
    </head>
    ```

2. Make the `resources` section empty and add the jQuery UI libraries before extension scripts.

    ```cs
    <resources>
    </resources>
    ```

    ```html
    <head>
        <title>@ViewBag.Title</title>
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"
            type="text/javascript"></script>
        @Html.DevExpress().GetStyleSheets(
            new StyleSheet { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
            new StyleSheet { ExtensionSuite = ExtensionSuite.Editors },
            new StyleSheet { ExtensionSuite = ExtensionSuite.GridView }
        )
        @Html.DevExpress().GetScripts(
            new Script { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
            new Script { ExtensionSuite = ExtensionSuite.Editors },
            new Script { ExtensionSuite = ExtensionSuite.GridView }
        )
    </head>
    ```

## Files to Review

* [HomeController.cs](./CS/DXWebApplication1/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication1/Controllers/HomeController.vb))
* [DBHelper.cs](./CS/DXWebApplication1/Models/DBHelper.cs) (VB: [DBHelper.vb](./VB/DXWebApplication1/Models/DBHelper.vb))
* [_GridViewPartial.cshtml](./CS/DXWebApplication1/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/DXWebApplication1/Views/Home/Index.cshtml)

## Documentation

* [Draggable](https://jqueryui.com/draggable/)
* [Droppable](https://jqueryui.com/droppable/)

## More Examples

* [Grid View for ASP.NET Web Forms - Reorder grid rows using buttons and drag-and-drop](https://github.com/DevExpress-Examples/asp-net-web-forms-grid-reorder-rows-using-buttons-or-drag-and-drop)
