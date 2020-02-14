using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextPagebutton : MonoBehaviour
{
    public void Onclick()
    {
        var chatMoov = GameObject.Find("GameManager").GetComponent<ChatMooving>();
        var makeChat = GameObject.Find("GameManager").GetComponent<MakeChat>();

        Destroy(makeChat.Tmp_Jhon_chat);
        chatMoov.Next();
    }
}
