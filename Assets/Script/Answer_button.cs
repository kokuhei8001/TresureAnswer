using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//回答のボタンに付けられるコンポーネント
public class Answer_button : MonoBehaviour
{
    [SerializeField] AudioClip Sound = null;
    private MakeChat mana;
    private ChatMooving chatMoov;
    [HideInInspector] public string Answer;

    public int answer_num;

    private GameManager manager;

    private void Start()
    {
        if (GameObject.Find("GameManager").GetComponent<MakeChat>() != null)
        {
            mana = GameObject.Find("GameManager").GetComponent<MakeChat>();
        }
        else { Debug.Log("MakeChatがありませんでした。"); }

        chatMoov = GameObject.Find("GameManager").GetComponent<ChatMooving>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    public void OnClick()
    {
        manager.AudioPlay(Sound);
        if (mana != null) { mana.MakeYOUChat(Answer); }
        chatMoov.players_answer = answer_num;
    }
}
