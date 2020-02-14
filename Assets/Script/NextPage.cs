using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPage : MonoBehaviour
{
    private ChatMooving chatMoov; 

    private void Start()
    {
        chatMoov = GameObject.Find("GameManager").GetComponent<ChatMooving>();
    }

    public void OnClick()
    {
        chatMoov.Next();
    }
}
