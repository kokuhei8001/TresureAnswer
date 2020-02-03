using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMana : MonoBehaviour
{
    private void Start()
    {
        var aaa = GetComponent<MakeEndChat>();
        StartCoroutine(aaa.makechat(aaa.chat_list[0].name , aaa.chat_list[0].text));
    }
}
