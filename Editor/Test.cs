//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using Project_Setup.So_EventSystem;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.Events;

//namespace Project_Setup
//{
//    public class Test : EditorWindow
//    {
//        [MenuItem("Dhumil Tools/Test")]
//        private static void ShowWindow()
//        {
//            var window = GetWindow<Test>();
//            window.titleContent = new GUIContent("Test");
//            window.Show();
//        }

//        private List<MethodInfo> _methods = new List<MethodInfo>();
//        private List<GameObject> _goGameObjects = new List<GameObject>();

//        private void OnEnable()
//        {
//            var monos = FindObjectsOfType<MonoBehaviour>();
//            foreach (var mono in monos)
//            {
//                var monoType = mono.GetType();
//                var methods = monoType.GetMethods();
//                foreach (var methodInfo in methods)
//                {
//                    if (methodInfo.GetCustomAttributes().Any())
//                    {
//                        HookEventAttribute attribute = methodInfo.GetCustomAttribute<HookEventAttribute>();
//                        if (attribute != null)
//                        {
//                            _methods.Add(methodInfo);
//                            _goGameObjects.Add(mono.gameObject);

//                            Type eventDataType = methodInfo.GetParameters()[0].GetType();  

//                            IBaseEventListener eventListener =
//                                mono.gameObject.AddComponent(attribute.EventListener) as IBaseEventListener;
//                            UnityEvent response = eventListener.Callback as UnityEvent; 
//                            // response.AddListener((() => methodInfo.Invoke(mono, null)));
//                        }
//                    }
//                }
//            }
//        }

//        private void OnGUI()
//        {
//            for (int i = 0; i < _methods.Count; i++)
//            {
//                EditorGUILayout.LabelField($"{_methods[i].Name} -> {_goGameObjects[i].name}");
//            }
//        }
//    }
//}