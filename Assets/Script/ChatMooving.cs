using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Status
{
    None,
    Question,
    Answer,
    Action
}


public class ChatMooving : MonoBehaviour
{
    [HideInInspector] public List<Root> question_root = new List<Root>();
    [HideInInspector] public MakeChat makeChat;

    //[SerializeField] private float moovSpeed = 1.0f;  //次のチャットが表示されるまでの時間

    [HideInInspector] public Status now_status = Status.None;

    [SerializeField] private int page = 0; // 現在の質問数(デバッグ用にinspectorに表示させる。)
    [HideInInspector] public int players_answer = 0; 
    private int clear_count = 0;  // プレイヤーが正解した数

    private void Awake()
    {
        makeChat = GetComponent<MakeChat>();
    }
    //次のチャットを表示させる。
    public void Next()
    {
        switch (now_status)
        {
            case Status.None:
                StartCoroutine(makeChat.MakeJhonChat(question_root[page].question_text));
                now_status = Status.Question;
                break;
                
            case Status.Question:

                makeChat.MakeYOUChat("");
                makeChat.MakeAnswerSelect(question_root[page].image, question_root[page].text);

                now_status = Status.Answer;
                break;

            case Status.Answer:
                Destroy(makeChat.Tmp_Jhon_chat);
                Destroy(makeChat.Tmp_You_chat);
                Destroy(makeChat.Tmp_select);

                if (question_root[page].answer_num == players_answer)
                {
                    StartCoroutine(makeChat.MakeJhonChat(question_root[page].clear_txet));

                    if (page == question_root.Count - 1)
                    {
                        makeChat.MakeClearImage();
                    }
                    clear_count++;
                }
                else
                {
                    StartCoroutine(makeChat.MakeJhonChat(question_root[page].over_txet));
                }

                now_status = Status.Action;
                break;

            case Status.Action:
                page++;

                if (question_root.Count != page)
                {
                    makeChat.MakeNextButton();
                }
                else
                {
                    float count = (float)clear_count / (float)question_root.Count * 100;
                    makeChat.MakeNormalChat("君の解読率は " + count + " ％だ。");
                }

                now_status = Status.None;
                break;
        }
    }


    //画面遷移にかかる時間とタイマースイッチ
    public bool count = false;
    private float timer = 0.0f;
    public float nextchat_count_time = 1.0f;

    private void Update()
    {
        if (count)
        {
            timer += Time.deltaTime;
            if (timer >= nextchat_count_time)
            {
                //次への処理
                //

                count = false;
                timer = 0f;
            }
        }
    }
}
