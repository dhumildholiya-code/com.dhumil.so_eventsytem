namespace Project_Setup.So_EventSystem
{
    public interface IBaseEventListener<T>
    {
        void OnEventRaised(T eventData);
    }
}