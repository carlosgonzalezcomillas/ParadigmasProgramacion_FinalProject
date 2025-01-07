using UnityEngine;

public class MessageLogger : IMessageWritter
{
    public string WriteMessage(string customMessage)
    {
        Debug.Log(customMessage);
        return customMessage;
    }
}

public interface IMessageWritter
{
    string WriteMessage(string customMessage);
}
