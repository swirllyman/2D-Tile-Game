using System.Collections.Generic;
using TMPro;
using TwitchChatConnect.Client;
using TwitchChatConnect.Config;
using TwitchChatConnect.Data;
using UnityEngine;

public class TwitchChat : MonoBehaviour
{
    [SerializeField] private Transform messagePanel;
    [SerializeField] private Transform commandsPanel;
    [SerializeField] private GameObject chatTextPrefab;
    [SerializeField] private GameObject commandTextPrefab;

    List<TMP_Text> chatText;
    List<TMP_Text> commandText;

    const int totalCommandTextLength = 30;
    const int totalChatTextLength = 30;

    void Start()
    {

        chatText = new List<TMP_Text>();
        commandText = new List<TMP_Text>();
        TwitchChatClient.instance.Init(() =>
        {
            TwitchChatClient.instance.onChatMessageReceived += ShowMessage;
            TwitchChatClient.instance.onChatCommandReceived += ShowCommand;
            TwitchChatClient.instance.onChatRewardReceived += ShowReward;

        },
            message =>
            {
                // Error when initializing.
                Debug.LogError(message);
            });
    }

    void ShowCommand(TwitchChatCommand chatCommand)
    {
        TwitchConnectData a = ScriptableObject.CreateInstance<TwitchConnectData>();
        //string parameters = string.Join(" - ", chatCommand.Parameters);
        //string message =
        //    $"Command: '{chatCommand.Command}' - Username: {chatCommand.User.DisplayName} - Bits: {chatCommand.Bits} - Sub: {chatCommand.User.IsSub} - Parameters: {parameters}";

        

        TwitchChatClient.instance.SendChatMessage($"Hello {chatCommand.User.DisplayName}! I received your message.");
        TwitchChatClient.instance.SendChatMessage(
            $"Hello {chatCommand.User.DisplayName}! This message will be sent in 5 seconds.", 5);

        string message = $"{chatCommand.User.DisplayName}: {chatCommand.Command}";
        TMP_Text newText = Instantiate(commandTextPrefab, commandsPanel).GetComponent<TMP_Text>();
        newText.text = message;
        commandText.Add(newText);
        if(commandText.Count > totalCommandTextLength)
        {
            GameObject g = commandText[0].gameObject;
            commandText.RemoveAt(0);
            Destroy(g);
        }
    }

    void ShowReward(TwitchChatReward chatReward)
    {
        string message = $"Reward unlocked by {chatReward.User.DisplayName} - Reward ID: {chatReward.CustomRewardId} - Message: {chatReward.Message}";
        //AddText(message);
    }


    void ShowMessage(TwitchChatMessage chatMessage)
    {
        //string message = $"Message by {chatMessage.User.DisplayName} - Bits: {chatMessage.Bits} - Sub: {chatMessage.User.IsSub} - Message: {chatMessage.Message}";

        string message = $"{chatMessage.User.DisplayName}: {chatMessage.Message}";
        TMP_Text newText = Instantiate(chatTextPrefab, messagePanel).GetComponent<TMP_Text>();
        newText.text = message;
        chatText.Add(newText);

        if (chatText.Count > totalChatTextLength)
        {
            GameObject g = chatText[0].gameObject;
            chatText.RemoveAt(0);
            Destroy(g);
        }
    }

    //private void AddText(string message)
    //{
    //    GameObject newText = Instantiate(chatTextPrefab, messagePanel);
    //    newText.GetComponent<TMP_Text>().text = message;
    //}


    void DetermineCommand(string command)
    {
        command = command.ToLower();
        switch (command)
        {
            case "up":
                break;
            case "down":
                break;
            case "left":
                break;
            case "right":
                break;
        }
    }
}