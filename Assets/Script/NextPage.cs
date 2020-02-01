using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPage : MonoBehaviour
{
    private GameManager _gamemanager;

    private void Start()
    {
        _gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnClick()
    {
        _gamemanager.SaveAnswer(_gamemanager.Tmp_YOU_answer.transform.Find("YOU_text").GetComponent<Text>().text);

        Destroy(_gamemanager.Tmp_Select_answer);
        _gamemanager.count = true;
    }
}
