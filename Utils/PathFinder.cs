using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.Utils
{
    public static class PathFinder
    {
        public static T Find<T>(string path)
        {
            path = path.TrimStart('/').TrimEnd('/');
            string file = Path.Combine("Public", path);

            if (File.Exists(file))
            {
                string extension = Path.GetExtension(file).ToLower();

                if (extension == ".html" || extension == ".txt" || extension == ".css" ||
                    extension == ".js" || extension == ".json" || extension == ".xml")
                {
                    return (T)(object)File.ReadAllText(file);
                }

                return (T)(object)File.ReadAllBytes(file);
            }

            return (T)(object)File.ReadAllText(Path.Combine("Public", "ROOT.html"));
        }
    }
}
