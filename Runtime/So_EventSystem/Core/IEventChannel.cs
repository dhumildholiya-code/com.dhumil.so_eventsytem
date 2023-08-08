namespace EventChannelSystem.Core
{
    public interface IEventChannel<T>
    {
        void AddListener(IEventListener<T> listener);
        void RemoveListener(IEventListener<T> listener);
        void RaiseEvent(T eventData);
    }
}