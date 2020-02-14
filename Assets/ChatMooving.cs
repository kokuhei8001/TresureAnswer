using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatMooving : MonoBehaviour
{
    private int now_question = 0; // 現在の質問数
    private int clear_count = 0;  // プレイヤーが正解した数

    [HideInInspector]
    public List<Root> question_root = new List<Root>();

    [SerializeField] private float moovSpeed = 1.0f;  //次のチャットが表示されるまでの時間


    /*
     
     ＝＝フロー図＝＝
     
    ジョンの質問
        (瞬間表示)

    選択肢の表示
        (瞬時表示)

    あなたの回答を送信
        (moovSpeed)

    ジョンによる成否判定チャット
        (次へボタン？時間？)
     */




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

    //次のチャットを表示させる。
    private void Next()
    {
        


    }




}
