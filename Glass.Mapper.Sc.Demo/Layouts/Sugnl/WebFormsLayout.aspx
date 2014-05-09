<%@ Import Namespace="StackExchange.Profiling" %>
<html>
<head>
    <link href="/Content/metro-ui/css/metro-bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/Site.less" rel="stylesheet" />
        <script src="/Scripts/jquery-1.10.2.min.js"></script>

</head>
    <body class="metro">
        
        <div class="container">
            <sc:Placeholder runat="server" Key="header"/>
            <div class="grid">
                <div class="row">
                    <div class="span10 offset2">
                         <sc:Placeholder ID="Placeholder1" runat="server" Key="main"/>
                    </div>
                </div>
            </div>

        </div>

        <script src="/Scripts/metro-ui/jquery.ui.widget.js"></script>
        <script src="/Scripts/metro-ui/metro.min.js"></script>
        <script src="/Scripts/knockout-3.1.0.js"></script>
        <%=MiniProfiler.RenderIncludes() %>
    </body>
</html>
