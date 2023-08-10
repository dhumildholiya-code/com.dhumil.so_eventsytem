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

        [SerializeField] private string folderPath = "_Project/Scripts/Custom Events";
        [SerializeField] private string dataType;

        private string _dirPath;
        private string _editorDirPath;
        private string _fileName;
        private string _eventClassName;
        private string _captialDataType;

        private void OnWizardCreate()
        {
            _dirPath = Path.Combine(Application.dataPath, folderPath);
            _editorDirPath = Path.Combine(Application.dataPath, folderPath + "/Editor");
            _captialDataType = char.ToUpper(dataType[0]) + dataType.Substring(1);
            CreateEventFile();
            CreateEditorFile();
            CreateListenerFile();
            AssetDatabase.ImportAsset(Path.Combine("Assets", _dirPath));
            AssetDatabase.Refresh();
        }

        private void CreateEventFile()
        {
            _fileName = $"{_captialDataType}EventChannel.cs";
            _eventClassName = _fileName.Split('.')[0];
            string filePath = Path.Combine(_dirPath, _fileName);

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
            sb.AppendLine($"    [CreateAssetMenu(fileName = \"{_captialDataType} EventChannel\", menuName = \"Events / {_captialDataType} EventChannel\")]");
            sb.AppendLine($"    public class {_eventClassName} : BaseEventChannel<{dataType}>");
            sb.AppendLine(" {");
            sb.AppendLine(" }");
            sb.AppendLine("}");

            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
            }

            // writes the class and imports it so it is visible in the Project window
            File.Delete(filePath);
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private void CreateListenerFile()
        {
            _fileName = $"{_captialDataType}EventListener.cs";
            string className = _fileName.Split('.')[0];
            string filePath = Path.Combine(_dirPath, _fileName);

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

            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
            }

            // writes the class and imports it so it is visible in the Project window
            File.Delete(filePath);
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
        private void CreateEditorFile()
        {
            _fileName = $"{_captialDataType}ChannelInspector.cs";
            string className = _fileName.Split('.')[0];
            string filePath = Path.Combine(_editorDirPath, _fileName);

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

            if (!Directory.Exists(_editorDirPath))
            {
                Directory.CreateDirectory(_editorDirPath);
            }

            // writes the class and imports it so it is visible in the Project window
            File.Delete(filePath);
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
#endif
}