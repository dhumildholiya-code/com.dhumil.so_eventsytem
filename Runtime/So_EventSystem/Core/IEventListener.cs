namespace EventChannelSystem.Core
{
    public interface IEventListener<T>
    {
        void OnEventRaised(T eventData);
    }
}