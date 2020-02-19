using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeEndChat : MonoBehaviour
{
    [SerializeField] public GameObject chatPre;
    [SerializeField] public Transform parent;
    [SerializeField] public List<UserDate> chat_list = new List<UserDate>();
    private int count = 0;
    private Vector3 prev_pos = new Vector3(50,-100,0);

    public IEnumerator makechat(string name , string text)
    {
        GameObject chat = Instantiate(chatPre, transform.position, Quaternion.identity, parent);
        chat.transform.localPosition = prev_pos + new Vector3(0,-50,0);

        Text _name = chat.transform.Find("Name").GetComponent<Text>();
        Text _text = chat.transform.Find("Text").GetComponent<Text>();

        _name.text = name;
        _text.text = "";

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
