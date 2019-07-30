<!-- default file list -->
*Files to look at*:

* **[HomeController.cs](./CS/DXWebApplication1/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication1/Controllers/HomeController.vb))**
* [DBHelper.cs](./CS/DXWebApplication1/Models/DBHelper.cs) (VB: [DBHelper.vb](./VB/DXWebApplication1/Models/DBHelper.vb))
* [_GridViewPartial.cshtml](./CS/DXWebApplication1/Views/Home/_GridViewPartial.cshtml)
* [Index.cshtml](./CS/DXWebApplication1/Views/Home/Index.cshtml)
<!-- default file list end -->
# How to reorder GridView rows using buttons or drag-and-drop
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t191258/)**
<!-- run online end -->


This example demonstrates how to move GridView rows using buttons or jQuery UI  <a href="http://jqueryui.com/draggable/">Draggable</a> and <a href="http://jqueryui.com/droppable/">Droppable</a> plug-ins. To keep the order of rows, it is necessary to set up an extra column to store row order indexes. Then, sort GridView by this column and deny sorting by other columns.<br>
<p><strong>Important</strong>. The GridView extension doesn't refer to any jQuery UI component. So, it's necessary to add it manually.<br>There are two ways to do this:<br><strong>1. Add only the jQuery UI library.</strong><br>a. Add the resources section with the ThirdParty attribute set to true:</p>


```cs
<resources>
  <add type="ThirdParty" />
</resources>
```


<p>b. Add a reference to the jQuery UI library into the head section after adding our scripts:</p>


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
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js" type="text/javascript"></script>
</head>
```


<p><strong>2. Prevent our default adding of jQuery libraries and add everything manually.</strong><br>a. Make the resource section empty:</p>


```cs
<resources>
</resources>
```


<p>b. Add necessary libraries before our scripts:</p>


```html
<head>
    <title>@ViewBag.Title</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js" type="text/javascript"></script>
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


<p>c. Note that if you need a validation functionality, you will also need to add the following libraries: jquery.validate.min.js, jquery.validate.unobtrusive.min.js, jquery.unobtrusive-ajax.min.js (3.2.4). </p>
<br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/E4582">E4582 - How to reorder ASPxGridView rows using buttons or drag-and-drop</a>

<br/>


