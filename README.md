## Append Version
An URL extension helper to append version to content URL for files such as js, css, json, etc for **cache busting**. Version is computed as SHA256 hash of the content and cached for the lifetime of the request cache `HttpContext.Cache`.

## Install
Install-Package AppendVersion

## Usage
```html
<script type="text/javascript" src="@Url.AppendVersion("~/Scripts/jquery.validate.js")"></script>
```
