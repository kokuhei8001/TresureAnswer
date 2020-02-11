using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    private GameObject now_screen = null;
    [SerializeField]
    private Vector2 screen_pos = new Vector2(3000,3000);

    //チャット画面を切り替える関数
    public void change_screen(GameObject screen)
    {
        if (screen != now_screen)
        {
            screen.transform.position = now_screen.transform.position;
            now_screen.transform.localPosition = screen_pos;

            now_screen = screen;
        }
    }

    //----------------------------------------------------------------------------------------------------------------------

    /*　プレハブのリンク一覧　*/
    [SerializeField] private Transform parent = null;
    [SerializeField] private GameObject Jhon_pre = null;
    [SerializeField] private GameObject YOU_pre = null;
    [SerializeField] private GameObject Answer_pre = null;

    private int page = 0; //現在のチャット画面遷移数
    public List<Question_> question_list = new List<Question_>(); //質問のリスト
    public List<string> Answer = new List<string>(); //プレイヤーの回答記録

    private GameObject Tmp_Jhon_chat = null;
    public GameObject Tmp_YOU_answer = null;
    public GameObject Tmp_Select_answer = null;
    [SerializeField] private float novelSpeed = 0.1f; //文字の表示速度

    //Jhonのチャットを作る関数
    public IEnumerator MakeJhonChat(string text , bool isquestion)
    {
        Tmp_Jhon_chat = Instantiate(Jhon_pre , transform.position , Quaternion.identity , parent);
        Tmp_Jhon_chat.transform.localPosition = new Vector3(-45, -60, 0);
        Text _text = Tmp_Jhon_chat.transform.Find("Jhon_text").GetComponent<Text>();
        _text.text = "";//初期化

        int messageCount = 0; //現在表示中の文字数
        while (text.Length > messageCount)//文字をすべて表示していない場合ループ
        {
            _text.text += text[messageCount];//一文字追加
            messageCount++;//現在の文字数
            yield return new WaitForSeconds(novelSpeed);//任意の時間待つ
        }

        if (isquestion)
        {
            MakeYOUChat("");
            MakeAnswerSelect(GetComponent<Question>());
        }
    }

    //YOUのチャットを作る関数
    public void MakeYOUChat(string text)
    {
        if (Tmp_YOU_answer == null)
        {
            Tmp_YOU_answer = Instantiate(YOU_pre, transform.position, Quaternion.identity, parent);
            Tmp_YOU_answer.transform.localPosition = new Vector3(-45, -120, 0);
            Tmp_YOU_answer.transform.Find("YOU_text").GetComponent<Text>().text = text;
        }
        else
        {
            Tmp_YOU_answer.transform.Find("YOU_text").GetComponent<Text>().text = text;
        }
    }

    //回答選択肢を出す関数
    public void MakeAnswerSelect(Question num)
    {
        Tmp_Select_answer = Instantiate(Answer_pre, transform.position, Quaternion.identity, parent);
        Tmp_Select_answer.transform.localPosition = new Vector3(150,-270,0);

        for (int i = 0; i < 4; i++)
        {
            string name = "Answer" + i.ToString();
            var obj = Tmp_Select_answer.transform.Find(name);

            if (num.question_list[page].answer_Image[i] != null)
            {
                obj.GetComponent<Image>().sprite = num.question_list[page].answer_Image[i];
            }
            if (num.question_list[page].answer_text[i] != null)
            {
                obj.GetComponent<Answer_button>().Answer = num.question_list[page].answer_text[i];
            }
        }
    }

    //プレイヤーの回答を記録する
    public void SaveAnswer(string answer)
    {
        Debug.Log(answer);
        Answer.Add(answer);
    }

    //現在の画面を消して次の画面を出す準備
    public void NextPage()
    {
        Destroy(Tmp_Jhon_chat);
        Destroy(Tmp_YOU_answer);

        page++;
        if (page < question_list.Count)
        {
            NewPage(page);
        }
        else
        {
            CheckCorrect();
        }
    }

    //新しいページをつくる
    private void NewPage(int num)
    {
        if (question_list[num].ask_txt != null)
        {
            StartCoroutine(MakeJhonChat(question_list[num].ask_txt , true));
        }
    }

    private void Start()
    {
        NewPage(page);
    }


    //画面遷移にかかる時間とタイマースイッチ
    public bool count = false;
    private float timer = 0.0f;

    private void Update()
    {
        if (count)
        {
            timer += Time.deltaTime;
            if (timer >= 2.0f)
            {
                NextPage();

                count = false;
                timer = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //初期化ボタンEscape
        {
            SceneManager.LoadScene("Main");
        }
    }

    //正解率を出す関数
    private void CheckCorrect()
    {
        int i = 0;
        int hit = 0;
        List<string> Correct = GetComponent<Question>().question_answer;

        while (question_list.Count > i)
        {
            if (Answer[i] == Correct[i])
            {
                hit++;
            }
            i++;
        }

        float seikairitu = (float)(hit) / i * 100;
        StartCoroutine(MakeJhonChat("君の正解率は" + (int)seikairitu + "%", false));

        if (seikairitu == 100)
        {
            //満点だったら褒めちぎる
            var aaa = GetComponent<MakeEndChat>();
            StartCoroutine(aaa.makechat(aaa.chat_list[0].name, aaa.chat_list[0].text));
        }
        else if (seikairitu > 50)
        {
            //正解率が高かったら（ギリ正解）
        }
        else
        {
            //正解率が低かったら
        }
    }
}
