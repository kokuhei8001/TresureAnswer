using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]
    public List<Question_> question_list = new List<Question_>(); //質問と回答の画像、文字

    [SerializeField]
    public List<string> question_answer = new List<string>(); //正解の文字（完全に一致させる必要がある）

    [SerializeField]
    public List<string> seikai = new List<string>();
    [SerializeField]
    public List<string> fuseikai = new List<string>();

    private void Awake()
    {
        GetComponent<GameManager>().question_list = this.question_list;
    }
}

//質問と答えのクラス
[System.Serializable]
public class Question_
{
    public string ask_txt;

    public List<Sprite> answer_Image = new List<Sprite>();
    public List<string> answer_text = new List<string>();
}