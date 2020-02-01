using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMana : MonoBehaviour
{
    [SerializeField] GameObject obj = null;

    private string txt = "ルパン三世風のチャット";
    private Text text = null;

    [SerializeField] float novelSpeed = 0;//一文字一文字の表示する速さ

    void Start()
    {
        text = obj.GetComponent<Text>();
        StartCoroutine(Novel());
    }


    private IEnumerator Novel()
    {
        int messageCount = 0; //現在表示中の文字数
        text.text = ""; //テキストのリセット
        while (txt.Length > messageCount)//文字をすべて表示していない場合ループ
        {
            text.text += txt[messageCount];//一文字追加
            messageCount++;//現在の文字数
            yield return new WaitForSeconds(novelSpeed);//任意の時間待つ
        }
        Debug.Log("終了");
    }
}
