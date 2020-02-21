using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeChat : MonoBehaviour
{
    private ChatMooving chatMoov;

    [SerializeField] private Transform originObj = null;
    [SerializeField] private GameObject JhonPre = null;
    [SerializeField] private GameObject YouPre = null;
    [SerializeField] private GameObject AnswerPre = null;
    [SerializeField] private GameObject ChatPre = null;
    [SerializeField] private GameObject NextButtonPre = null;
    [SerializeField] private GameObject ClearImage = null;
    [SerializeField] private AudioClip ClearSound = null;

    [SerializeField] private Vector3 JhonPos = new Vector3(-45,-60,0);
    [SerializeField] private Vector3 YouPos = new Vector3(-45, -120, 0);
    [SerializeField] private Vector3 AnswerPos = new Vector3(150, -270, 0);
    [SerializeField] private Vector3 NextButtonPos = new Vector3(300, -300, 0);

    [SerializeField] private float novelSpeed = 0.1f; //文字が表示される速度

    [HideInInspector] public GameObject Tmp_Jhon_chat = null;
    [HideInInspector] public GameObject Tmp_You_chat = null;
    [HideInInspector] public GameObject Tmp_select = null;

    private void Awake()
    {
        chatMoov = GetComponent<ChatMooving>();
    }

    //Jhonのチャットを作る
    public IEnumerator MakeJhonChat(string text)
    {
        Tmp_Jhon_chat = Instantiate(JhonPre, transform.position, Quaternion.identity, originObj);
        Tmp_Jhon_chat.transform.localPosition = JhonPos;
        Text _text = Tmp_Jhon_chat.transform.Find("Jhon_text").GetComponent<Text>(); 
        _text.text = "";//初期化

        int messageCount = 0;
        while (text.Length > messageCount)
        {
            _text.text += text[messageCount];
            messageCount++;
            yield return new WaitForSeconds(novelSpeed);
        }

        //next処理
        chatMoov.Next();
    }

    //YOUのチャットを作る
    public void MakeYOUChat(string text)
    {
        if (Tmp_You_chat == null)
        {
            Tmp_You_chat = Instantiate(YouPre, transform.position, Quaternion.identity, originObj);
            Tmp_You_chat.transform.localPosition = YouPos;
            Tmp_You_chat.transform.Find("YOU_text").GetComponent<Text>().text = text;
        }
        else
        {
            Tmp_You_chat.transform.Find("YOU_text").GetComponent<Text>().text = text;
        }
    }


    //回答の選択肢を作る
    public void MakeAnswerSelect( Sprite[] image, string[] text)
    {
        Tmp_select = Instantiate(AnswerPre, transform.position, Quaternion.identity, originObj);
        Tmp_select.transform.localPosition = AnswerPos;

        for (int i = 0; i < 4; i++)
        {
            string name = "Answer" + i.ToString();
            var obj = Tmp_select.transform.Find(name);

            obj.GetComponent<Image>().sprite = image[i];
            obj.GetComponent<Answer_button>().Answer = text[i];
            obj.GetComponent<Answer_button>().answer_num = i;
        }
    }

    public void MakeNextButton()
    {
        var obj = Instantiate(NextButtonPre, transform.position, Quaternion.identity, originObj);
        obj.transform.localPosition = NextButtonPos;
    }

    public void MakeClearImage()
    {
        var obj = Instantiate(ClearImage, transform.position, Quaternion.identity, originObj);
        obj.transform.localPosition = new Vector3(350, -225, 0);
        GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(ClearSound);
    }

    public void MakeNormalChat(string _text)
    {
        var obj = Instantiate(ChatPre , transform.position , Quaternion.identity , originObj);
        obj.transform.localPosition = new Vector3(200, -400, 0);

        obj.transform.Find("Text").GetComponent<Text>().text = _text;
    }
}
