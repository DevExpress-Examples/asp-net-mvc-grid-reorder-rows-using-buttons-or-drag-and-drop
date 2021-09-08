<!DOCTYPE html>

<html>
<head>
    <title>@ViewBag.Title</title>

    @Html.DevExpress().GetStyleSheets(
                    New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView},
                    New StyleSheet With {.ExtensionSuite = ExtensionSuite.PivotGrid},
                    New StyleSheet With {.ExtensionSuite = ExtensionSuite.HtmlEditor},
                    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
                    New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
                    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Chart},
                    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Scheduler},
                    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Report})
    
    @Html.DevExpress().GetScripts(
                            New Script With {.ExtensionSuite = ExtensionSuite.GridView},
                            New Script With {.ExtensionSuite = ExtensionSuite.PivotGrid},
                            New Script With {.ExtensionSuite = ExtensionSuite.HtmlEditor},
                            New Script With {.ExtensionSuite = ExtensionSuite.Editors},
                            New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
                            New Script With {.ExtensionSuite = ExtensionSuite.Chart},
                            New Script With {.ExtensionSuite = ExtensionSuite.Scheduler},
                            New Script With {.ExtensionSuite = ExtensionSuite.Report})

    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"
            integrity="sha256-VazP97ZCwtekAsvgPBSUwPFKdrwD3unUfSGVYrahUqU="
            crossorigin="anonymous"></script>
</head>

<body>
    @RenderBody()
</body>
</html>