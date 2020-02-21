using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMana : MonoBehaviour
{
    private void Start()
    {
        MakeEndChat end = GetComponent<MakeEndChat>();

        StartCoroutine(end.makechat(end.chat_list[0].name , end.chat_list[0].text));
    }
}
