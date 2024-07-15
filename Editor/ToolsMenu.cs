using UnityEditor;
using UnityEngine;
using static UnityEditor.AssetDatabase;

namespace Wyczyn
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDeafultFolders()
        {
            Folders.CreateDirectories("_Project", "Animations", "Audio", "Assets", "Scenes", "ScriptableObjects", "Scripts");
            Folders.CreateDirectories("_Project/Scripts", "Managers", "UI", "Visual", "ScriptableObjectScripts");
            Refresh();
        }


        [MenuItem("Tools/Setup/Import|Delete Packages")]
        public static async void LoadNewManifest()
        {
            await Packages.ReplacePackageFromGist("a4469a8bc2269592db5b1c306147758e");
        }

        [MenuItem("Tools/Setup/Add Packages/Post Processing")]
        public static void AddPostProcessing()
        {
            Packages.InstallUnityPackage("postprocessing");
        }

    }
}
