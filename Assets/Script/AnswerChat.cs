using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerChat : MonoBehaviour
{
    [SerializeField] public List<Root> Question_root = new List<Root>();

    private void Awake()
    {
        GetComponent<ChatMooving>().question_root = this.Question_root;
    }
}

[System.Serializable]
public class Root
{
    public string question_text;

    public string[] text = new string[4];
    public Sprite[] image = new Sprite[4];

    public int answer_num;

    public string clear_txet;
    public string over_txet;
}
