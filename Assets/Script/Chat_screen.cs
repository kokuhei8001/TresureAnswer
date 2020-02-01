using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//12.17
//class名をScroll_chat_txetに変更したい
public class Chat_screen : MonoBehaviour
{
    [SerializeField]
    private float scroll_speed = 40;


    Vector2 pos;
    private float scroll;

    private void Start()
    {
        pos = this.transform.position;
    }

    private void Update()
    {
        transform.position = pos;
        scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0)
        {
            pos.y -= scroll_speed;
        }
        if (scroll < 0)
        {
            pos.y += scroll_speed;
        }
    }
}
