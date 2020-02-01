using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//回答のボタンに付けられるコンポーネント
public class Answer_button : MonoBehaviour
{
    private GameManager manager;
    //public int Answer_num = 0;
    public string Answer;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnClick()
    {
        //manager.SaveAnswer(Answer_num);
        manager.MakeYOUChat(Answer);
    }
}
