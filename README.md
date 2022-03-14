# com.dhumil.project_setup
This is small tool for initializing project sturcture and required common editor functionlaity for project. 
- It has Scriptable Object Event System which is very handy to keep your code clean and handle depedency easily across scens.
- It has Scriptable object state machine integrated with event system to handle core game loop for your game.

## Create Custom Events
You can create custom events two way. 
- one is manually where you have to inherit from `BaseEvent<T>` and `BaseEventListener<T, TE>` where `T is custom DataType` and `TE is your customEvent class`.
  ```
  using UnityEngine;

  namespace Project_Setup.So_EventSystem
  {
    [CreateAssetMenu(fileName = "String Event", menuName = "Events / String Event")]
    public class StringEventSo : BaseEventSo<string>
    {
    }
  }
  ```
  ```
  namespace Project_Setup.So_EventSystem
  {
    public class StringEventListener : BaseEventListener<string, StringEventSo>
    {
    }
  }
  ```
- second is through editor menu which is located at `Dhumil Toos / Create Custom Event`. Then pass your custom `DataType` as `string` value and it wil autogenerate both class for you. 
- This will create both file in path `_Project/Scripts/Custom Events`.

     ![image](https://user-images.githubusercontent.com/66100811/158128520-d869764e-634c-4c94-8c8b-39a21f4f2e99.png) ![image](https://user-images.githubusercontent.com/66100811/158129041-2f3a242a-4186-4a9b-8c7e-4def17a88a58.png)

