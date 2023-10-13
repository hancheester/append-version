## Append Version
[![Package Version](https://img.shields.io/nuget/v/AppendVersion?label=Latest%20Version)](https://www.nuget.org/packages/AppendVersion/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/AppendVersion?label=Downloads)](https://www.nuget.org/packages/AppendVersion/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/hancheester/append-version/blob/master/LICENSE)

## About
An URL extension helper to append version to content URL for files such as js, css, json, etc for **cache busting** for ASP.NET MVC applications. Version is computed as SHA256 hash of the content and cached for the lifetime of the request cache `HttpContext.Cache`.

## Installation
**AppendVersion** is available on [NuGet](https://www.nuget.org/packages/AppendVersion).
```sh
dotnet add package AppendVersion
```
## Usage
```html
<script type="text/javascript" src="@Url.AppendVersion("~/Scripts/jquery.validate.js")"></script>
```
