using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Project_Setup
{
#if UNITY_EDITOR
    public static class ProjectSetup
    {
        [MenuItem("Dhumil Tools/Setup/Create Default Folders", priority = 0)]
        public static void SetupProject()
        {
            CreateFolderStructure("_Project", new[] {"Scripts", "Art", "Models", "Materials", "Prefabs", "Scenes"});
            // SetupSceneFile();
        }

        // [MenuItem("Dhumil Tools/Setup/Update Scene Items", priority = 1)]
        // public static void SetupSceneFile()
        // {
        //     var dirPath = Path.Combine(Application.dataPath, "_Project/Editor/Generated");
        //     var filePath = Path.Combine(dirPath, "GeneratedMenuItems.cs");
        //     const string folderToSearch = "Assets/_Project/Scenes";
        //
        //     var guids = AssetDatabase.FindAssets("", new[] {folderToSearch});
        //     var sceneNames = new List<string>();
        //     var scenePaths = new List<string>();
        //     foreach (var guid in guids)
        //     {
        //         var path = AssetDatabase.GUIDToAssetPath(guid);
        //         var pathSubStrings = path.Split('/');
        //         scenePaths.Add(path);
        //         sceneNames.Add(pathSubStrings[pathSubStrings.Length - 1].Split('.')[0]);
        //     }
        //
        //     StringBuilder sb = new StringBuilder();
        //     sb.AppendLine("// This class is Auto-Generated");
        //     sb.AppendLine("using UnityEngine;");
        //     sb.AppendLine("using UnityEditor;");
        //     sb.AppendLine("using UnityEditor.SceneManagement;");
        //     sb.AppendLine("");
        //     sb.AppendLine("  public static class GeneratedMenuItems {");
        //     sb.AppendLine("");
        //
        //     // loops though the array and generates the menu items
        //     for (var i = 0; i < sceneNames.Count; i++)
        //     {
        //         sb.AppendLine($"    [MenuItem(\"Dhumil Tools/Scenes/{sceneNames[i]}\")]");
        //         sb.AppendLine($"    private static void MenuItem{i}()");
        //         sb.AppendLine("     {");
        //         sb.AppendLine($"        EditorSceneManager.OpenScene(\"{scenePaths[i]}\");");
        //         sb.AppendLine("     }");
        //         sb.AppendLine("");
        //     }
        //
        //     sb.AppendLine("");
        //     sb.AppendLine("}");
        //
        //     if (!Directory.Exists(dirPath))
        //     {
        //         Directory.CreateDirectory(dirPath);
        //     }
        //
        //     // writes the class and imports it so it is visible in the Project window
        //     File.Delete(filePath);
        //     File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        //
        //     AssetDatabase.ImportAsset(Path.Combine("Assets", dirPath));
        //     AssetDatabase.Refresh();
        // }

        private static void CreateFolderStructure(string root, params string[] children)
        {
            string parentFolderPath = Path.Combine(Application.dataPath, root);
            foreach (var child in children)
            {
                var path = Path.Combine(parentFolderPath, child);
                Directory.CreateDirectory(path);
            }

            AssetDatabase.Refresh();
        }
    }
#endif
}