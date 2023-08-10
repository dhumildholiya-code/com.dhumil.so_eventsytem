using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace EventChannelSystem
{
#if UNITY_EDITOR
    public class CreateCustomEvent : ScriptableWizard
    {
        [MenuItem("Dhumil Tools / Create Custom Event")]
        private static void CreateWizard()
        {
            DisplayWizard<CreateCustomEvent>("Create Custom Event");
        }

        private const string folderKey = "folderKey";
        private const string editorFolderKey = "editorFolderKey";
        private string dataType;

        private string _folderPath;
        private string _editorfolderPath;
        private string _fileName;
        private string _eventClassName;
        private string _captialDataType;

        private void OnGUI()
        {
            _editorfolderPath = EditorPrefs.GetString(editorFolderKey, "");
            _folderPath = EditorPrefs.GetString(folderKey, "");
            GUILayout.Label("Create Custom Event Channels");
            EditorGUILayout.Space(10);
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("Folder Path", GUILayout.MaxWidth(130));
                if (GUILayout.Button($"{_folderPath}"))
                {
                    _folderPath = EditorUtility.OpenFolderPanel("Select Folder", "", "");
                    EditorPrefs.SetString(folderKey, _folderPath);
                    if (_folderPath == string.Empty)
                    {
                        _folderPath = EditorPrefs.GetString(folderKey, "");
                    }
                }
            }
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("Editor Folder Path", GUILayout.MaxWidth(130));
                if (GUILayout.Button($"{_editorfolderPath}"))
                {
                    _editorfolderPath = EditorUtility.OpenFolderPanel("Select Folder", "", "");
                    EditorPrefs.SetString(editorFolderKey, _editorfolderPath);
                    if (_editorfolderPath == string.Empty)
                    {
                        _editorfolderPath = EditorPrefs.GetString(editorFolderKey, "");
                    }
                }
            }
            EditorGUILayout.Space(10);
            dataType = EditorGUILayout.TextField("DataType", dataType);
            EditorGUILayout.Space(10);
            if(GUILayout.Button("Create Events Scripts"))
            {
                CreateScripts();
            }
        }
        private void CreateScripts()
        {
            _captialDataType = char.ToUpper(dataType[0]) + dataType.Substring(1);
            CreateEventFile();
            CreateEditorFile();
            CreateListenerFile();
            AssetDatabase.ImportAsset(Path.Combine("Assets", _folderPath));
            AssetDatabase.Refresh();
        }

        private void CreateEventFile()
        {
            _fileName = $"{_captialDataType}EventChannel.cs";
            _eventClassName = _fileName.Split('.')[0];
            string filePath = Path.Combine(_folderPath, _fileName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("// ===========================================================");
            sb.AppendLine("//           This class is Auto Generated");
            sb.AppendLine("// ===========================================================");
            sb.AppendLine("");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine("using EventChannelSystem.Core;");
            sb.AppendLine("");
            sb.AppendLine("namespace EventChannelSystem.CustomEvent");
            sb.AppendLine("{");
            sb.AppendLine($"    [CreateAssetMenu(fileName = \"{_captialDataType} EventChannel\", menuName = \"Event Channel/ {_captialDataType}\")]");
            sb.AppendLine($"    public class {_eventClassName} : BaseEventChannel<{dataType}>");
            sb.AppendLine(" {");
            sb.AppendLine(" }");
            sb.AppendLine("}");

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            // writes the class and imports it so it is visible in the Project window
            File.Delete(filePath);
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private void CreateListenerFile()
        {
            _fileName = $"{_captialDataType}EventListener.cs";
            string className = _fileName.Split('.')[0];
            string filePath = Path.Combine(_folderPath, _fileName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("// ===========================================================");
            sb.AppendLine("//           This class is Auto Generated");
            sb.AppendLine("// ===========================================================");
            sb.AppendLine("");
            sb.AppendLine("using EventChannelSystem.Core;");
            sb.AppendLine("");
            sb.AppendLine("namespace EventChannelSystem.CustomEvent");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {className} : BaseEventListener<{dataType}>");
            sb.AppendLine(" {");
            sb.AppendLine(" }");
            sb.AppendLine("}");

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            // writes the class and imports it so it is visible in the Project window
            File.Delete(filePath);
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
        private void CreateEditorFile()
        {
            _fileName = $"{_captialDataType}ChannelInspector.cs";
            string className = _fileName.Split('.')[0];
            string filePath = Path.Combine(_editorfolderPath, _fileName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("// ===========================================================");
            sb.AppendLine("//           This class is Auto Generated");
            sb.AppendLine("// ===========================================================");
            sb.AppendLine("");
            sb.AppendLine($"using EventChannelSystem.CustomEvent;");
            sb.AppendLine("using UnityEditor;");
            sb.AppendLine("");
            sb.AppendLine("namespace EventChannelSystem.CustomEventEditors");
            sb.AppendLine("{");
            sb.AppendLine($"[CustomEditor(typeof({_eventClassName}))]");
            sb.AppendLine($"    public class {className} : BaseEventChannelInspector<{dataType}>");
            sb.AppendLine(" {");
            sb.AppendLine(" }");
            sb.AppendLine("}");

            if (!Directory.Exists(_editorfolderPath))
            {
                Directory.CreateDirectory(_editorfolderPath);
            }

            // writes the class and imports it so it is visible in the Project window
            File.Delete(filePath);
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
#endif
}