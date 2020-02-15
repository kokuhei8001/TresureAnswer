using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//回答のボタンに付けられるコンポーネント
public class Answer_button : MonoBehaviour
{
    private MakeChat mana;
    private ChatMooving chatMoov;
    public string Answer;

    public int answer_num;

    private void Start()
    {
        if (GameObject.Find("GameManager").GetComponent<MakeChat>() != null)
        {
            mana = GameObject.Find("GameManager").GetComponent<MakeChat>();
        }
        else { Debug.Log("TestManaがありませんでした。"); }


        chatMoov = GameObject.Find("GameManager").GetComponent<ChatMooving>();
    }

    public void OnClick()
    {
        if (mana != null) { mana.MakeYOUChat(Answer); }
        chatMoov.players_answer = answer_num;
    }
}
