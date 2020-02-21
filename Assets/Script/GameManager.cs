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
    AudioSource audioSouce = null;

    private void Start()
    {
        chatMoov = transform.GetComponent<ChatMooving>();
        if (chatMoov != null)
        {
            chatMoov.Next();
        }
        audioSouce = GetComponent<AudioSource>();
    }

    //シーンをリロードするための処理
    [SerializeField]
    private string Scene1 = null;
    [SerializeField]
    private string Scene2 = null;
    [SerializeField]
    private string Scene3 = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Scene1 != null)
            {
                SceneManager.LoadScene(Scene1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Scene2 != null)
            {
                SceneManager.LoadScene(Scene2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Scene3 != null)
            {
                SceneManager.LoadScene(Scene3);
            }
        }
    }

    public void AudioPlay(AudioClip sound)
    {
        audioSouce.PlayOneShot(sound);
    }

}
