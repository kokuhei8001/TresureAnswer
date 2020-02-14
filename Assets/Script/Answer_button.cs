using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//回答のボタンに付けられるコンポーネント
public class Answer_button : MonoBehaviour
{
    private GameManager manager;
    private MakeChat mana;
    private ChatMooving chatMoov;
    public string Answer;

    public int answer_num;

    private void Start()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>() != null)
        {
            manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        else { Debug.Log("GameManagerがありませんでした。"); }

        if (GameObject.Find("GameManager").GetComponent<MakeChat>() != null)
        {
            mana = GameObject.Find("GameManager").GetComponent<MakeChat>();
        }
        else { Debug.Log("TestManaがありませんでした。"); }


        chatMoov = GameObject.Find("GameManager").GetComponent<ChatMooving>();
    }

    public void OnClick()
    {
        //if(manager != null) manager.MakeYOUChat(Answer);

        if (mana != null) { mana.MakeYOUChat(Answer); }
        chatMoov.players_answer = answer_num;
        Debug.Log(answer_num);
    }
}
