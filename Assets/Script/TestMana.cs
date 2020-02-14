using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMana : MonoBehaviour
{
    private void Start()
    {
        var bbb = GetComponent<AnswerChat>();
        var aaa = GetComponent<MakeChat>();

        StartCoroutine(aaa.MakeJhonChat(bbb.Question_root[0].question_text));

        aaa.MakeAnswerSelect(bbb.Question_root[0].image, bbb.Question_root[0].text);

    }
}
