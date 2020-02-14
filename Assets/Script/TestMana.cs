using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMana : MonoBehaviour
{
    private void Start()
    {
        ChatMooving chatMoov = GetComponent<ChatMooving>();

        chatMoov.Next();
    }
}
