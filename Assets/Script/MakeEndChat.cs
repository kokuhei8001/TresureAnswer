using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeEndChat : MonoBehaviour
{
    [SerializeField] public GameObject chatPre;
    [SerializeField] public Transform parent;
    [SerializeField] public List<UserDate> chat_list = new List<UserDate>();
    [SerializeField] private Vector3 startPos = new Vector3(0,0,0);
    [SerializeField] private float kannkaku = -50;

    [SerializeField] private AudioClip[] sound = null;

    private int count = 0;
    private Vector3 prev_pos;

    private GameManager gameManager = null;
    private void Start()
    {
        prev_pos = startPos;
        gameManager = GetComponent<GameManager>();
    }

    public IEnumerator makechat(string name , string text)
    {
        GameObject chat = Instantiate(chatPre, transform.position, Quaternion.identity, parent);
        chat.transform.localPosition = prev_pos + new Vector3(0,kannkaku,0);

        Text _name = chat.GetComponent<Text>();
        Text _text = chat.transform.Find("Comment").GetComponent<Text>();

        _name.text = name;
        _text.text = "";

        gameManager.AudioPlay(sound[count]);

        int messageCont = 0;
        while (text.Length > messageCont)
        {
            _text.text += text[messageCont];
            messageCont++;
            yield return new WaitForSeconds(0.05f);
        }

        if (count+1 < chat_list.Count)
        {
            count++;
            prev_pos = chat.transform.localPosition;
            StartCoroutine(makechat(chat_list[count].name, chat_list[count].text));
        }
    }
}

[System.Serializable]
public class UserDate
{
    public string name;
    public string text;
}
