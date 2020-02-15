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


    ChatMooving chatMoov = null;

    private void Start()
    {
        chatMoov = transform.GetComponent<ChatMooving>();
        chatMoov.Next();
    }
}
