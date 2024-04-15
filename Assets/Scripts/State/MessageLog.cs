using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageLog : MonoBehaviour
{
    public static MessageLog Instance;

    private RectTransform myRect;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Sprite earthIcon;
    [SerializeField] private GameObject playerMessagePref;
    [SerializeField] private GameObject alienMessagePref;
    [SerializeField] private float messageHeight = 38;

    public List<Message> MessageList = new List<Message>();

    private void Awake()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;
        myRect = GetComponent<RectTransform>();
    }

    public void AddMessage()
    {
        GameObject newMessageObj = Instantiate(playerMessagePref);
        newMessageObj.transform.SetParent(transform, false);
        Message newMessage = newMessageObj.GetComponent<Message>();
        newMessage.SetSenderIcon(earthIcon);
        MessageList.Add(newMessage);

        UpdateScrollRectHeight();
    }

    public void AddMessage(Species sender)
    {
        GameObject newMessageObj = Instantiate(alienMessagePref);
        newMessageObj.transform.SetParent(transform, false);
        Message newMessage = newMessageObj.GetComponent<Message>();
        newMessage.SetSenderIcon(sender.MessageIcon);
        MessageList.Add(newMessage);

        UpdateScrollRectHeight();
    }

    public Message GetBottomMessage()
    {
        return MessageList[MessageList.Count - 1];
    }

    private void UpdateScrollRectHeight()
    {
        myRect.sizeDelta = new Vector2(myRect.sizeDelta.x, messageHeight * MessageList.Count);
        scrollRect.normalizedPosition = new Vector2(0, 0);
    }
}
