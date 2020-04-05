using System.IO;
using System.Security.Cryptography;
using System.Web.Caching;

namespace System.Web.Mvc
{
    public static class AppendVersionExtension
    {
        public static string AppendVersion(this UrlHelper urlHelper, string contentPath)
        {
            var physicalPath = urlHelper.RequestContext.HttpContext.Server.MapPath(contentPath);
            var version = TryGetCachedVersion(contentPath, physicalPath, urlHelper.RequestContext.HttpContext.Cache);

            if (version != null)
            {
                var relativePath = urlHelper.Content(contentPath);
                return AppendHash(relativePath, version);
            }

            return urlHelper.Content(contentPath);
        }

        public static string AppendHash(string relativePath, string version)
        {
            var divider = "?";

            if (relativePath.Contains("?"))
                divider = "&";

            return relativePath + divider + version;
        }

        public static string TryGetCachedVersion(string contentPath, string physicalPath, Cache cache)
        {
            if (!File.Exists(physicalPath))
                return null;

            var version = cache[contentPath] as string;

            if (string.IsNullOrEmpty(version))
            {
                version = ComputeHash(physicalPath);
                cache.Insert(contentPath, version, new CacheDependency(physicalPath));
            }

            return version;
        }

        public static string ComputeHash(string physicalPath)
        {
            using (var stream = File.OpenRead(physicalPath))
            using (var sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(stream));
            }
        }
    }
}