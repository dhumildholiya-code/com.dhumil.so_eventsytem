//using System.IO;
//using System.Text;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif
//using UnityEngine;

//namespace Project_Setup
//{
//#if UNITY_EDITOR
//    public class CreateCustomEvent : ScriptableWizard
//    {
//        [MenuItem("Dhumil Tools / Create Custom Event")]
//        private static void CreateWizard()
//        {
//            DisplayWizard<CreateCustomEvent>("Create Custom Event");
//        }

//        [SerializeField] private string folderPath = "_Project/Scripts/Custom Events";
//        [SerializeField] private string dataType;

//        private string _dirPath;
//        private string _fileName;
//        private string _eventClassName;
//        private string _captialDataType;

//        private void OnWizardCreate()
//        {
//            _dirPath = Path.Combine(Application.dataPath, folderPath);
//            _captialDataType = char.ToUpper(dataType[0]) + dataType.Substring(1);
//            CreateEventFile();
//            CreateListenerFile();
//            AssetDatabase.ImportAsset(Path.Combine("Assets", _dirPath));
//            AssetDatabase.Refresh();
//        }

//        private void CreateEventFile()
//        {
//            _fileName = $"{_captialDataType}EventSo.cs";
//            _eventClassName = _fileName.Split('.')[0];
//            string filePath = Path.Combine(_dirPath, _fileName);

//            StringBuilder sb = new StringBuilder();
//            sb.AppendLine("// ===========================================================");
//            sb.AppendLine("//           This class is Auto Generated");
//            sb.AppendLine("// ===========================================================");
//            sb.AppendLine("");
//            sb.AppendLine("using UnityEngine;");
//            sb.AppendLine("");
//            sb.AppendLine("namespace Project_Setup.So_EventSystem");
//            sb.AppendLine("{");
//            sb.AppendLine($"    [CreateAssetMenu(fileName = \"{_captialDataType} Event\", menuName = \"Events / {_captialDataType} Event\")]");
//            sb.AppendLine($"    public class {_eventClassName} : BaseEventSo<{dataType}>");
//            sb.AppendLine(" {");
//            sb.AppendLine(" }");
//            sb.AppendLine("}");

//            if (!Directory.Exists(_dirPath))
//            {
//                Directory.CreateDirectory(_dirPath);
//            }

//            // writes the class and imports it so it is visible in the Project window
//            File.Delete(filePath);
//            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
//        }

//        private void CreateListenerFile()
//        {
//            _fileName = $"{_captialDataType}EventListener.cs";
//            string className = _fileName.Split('.')[0];
//            string filePath = Path.Combine(_dirPath, _fileName);

//            StringBuilder sb = new StringBuilder();
//            sb.AppendLine("// ===========================================================");
//            sb.AppendLine("//           This class is Auto Generated");
//            sb.AppendLine("// ===========================================================");
//            sb.AppendLine("");
//            sb.AppendLine("namespace Project_Setup.So_EventSystem");
//            sb.AppendLine("{");
//            sb.AppendLine($"    public class {className} : BaseEventListener<{dataType}, {_eventClassName}>");
//            sb.AppendLine(" {");
//            sb.AppendLine(" }");
//            sb.AppendLine("}");

//            if (!Directory.Exists(_dirPath))
//            {
//                Directory.CreateDirectory(_dirPath);
//            }

//            // writes the class and imports it so it is visible in the Project window
//            File.Delete(filePath);
//            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
//        }
//    }
//#endif
//}