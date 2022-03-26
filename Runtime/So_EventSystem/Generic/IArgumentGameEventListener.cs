namespace Project_Setup.So_EventSystem.Generic
{
    public interface IArgumentGameEventListener<in TArg>
    {
        void OnEventRaised(TArg arg);
    }
}