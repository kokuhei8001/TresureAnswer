using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPage : MonoBehaviour
{
    private ChatMooving chatMoov;

    [SerializeField] private AudioClip sound1 = null;

    private void Start()
    {
        chatMoov = GameObject.Find("GameManager").GetComponent<ChatMooving>();
    }

    public void OnClick()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().AudioPlay(sound1);
        chatMoov.Next();
    }
}
