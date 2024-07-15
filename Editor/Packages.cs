using System.IO;
using static UnityEngine.Application;
using System.Threading.Tasks;
using System.Net.Http;

namespace Wyczyn
{
    public static class Packages
    {
        public static async Task ReplacePackageFromGist(string id = "a4469a8bc2269592db5b1c306147758e", string user = "Wyczynn")
        {
            string url = GetGistUrl(id, user);
            string contents = await GetContents(url);

            ReplacePackageFile(contents);
        }

        public static void InstallUnityPackage(string packageName)
        {
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
        }


        private static string GetGistUrl(string id, string user) => $"https://gist.github.com/{user}/{id}/raw";

        private static async Task<string> GetContents(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private static void ReplacePackageFile(string contents)
        {
            string existing = Path.Combine(dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }
    }
}
