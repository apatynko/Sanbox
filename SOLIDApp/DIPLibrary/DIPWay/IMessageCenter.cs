namespace DIPLibrary.DIPWay
{
    public interface IMessageCenter
    {
        void SendMessage(IPerson person, string message);
    }
}