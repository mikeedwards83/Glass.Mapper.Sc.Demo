<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebFormsSublayout.ascx.cs" Inherits="Glass.Mapper.Sc.Demo.Layouts.Sugnl.WebFormsSublayout" %>
<h1>
    <%=Editable(x=>x.IPageTitlesLongTitle) %>
    <% if (!string.IsNullOrEmpty(Model.IPageTitleSubTitle) || IsInEditingMode)
       { %>
        <small class="on-right"> <%= Editable(x => x.IPageTitleSubTitle) %></small>
    <% } %>
</h1>

<div class="grid">
    <div class="row">
        <div class="span10">
            <%=Editable(x=>x.IFeatureImage, new {h=200, @class="rounded polaroid margin10", style="float:right"}) %>
            <%=Editable(x=>x.LandingContent) %>
        </div>
    </div>
</div>