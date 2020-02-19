using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextPagebutton : MonoBehaviour
{
    [SerializeField] private AudioClip sound1 = null;


    public void Onclick()
    {
        GameObject gameManager = GameObject.Find("GameManager");

        var chatMoov = gameManager.GetComponent<ChatMooving>();
        var makeChat = gameManager.GetComponent<MakeChat>();
        var audio = gameManager.GetComponent<AudioSource>();

        audio.PlayOneShot(sound1);
        Destroy(makeChat.Tmp_Jhon_chat);
        chatMoov.Next();

        Destroy(this.gameObject);
    }
}
