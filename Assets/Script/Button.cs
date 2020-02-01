using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//画面切り替え用ボタン
public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject screen = null;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnClick()
    {
        gameManager.change_screen(screen);
    }
}
