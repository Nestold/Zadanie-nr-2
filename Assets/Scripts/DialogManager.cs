using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text content;
    float timeScale;
    int indexer = 0;
    string[] messages;
    string from;
    public void Init(string[] messages, string from)
    {
        this.messages = messages;
        timeScale = Time.timeScale;
        Time.timeScale = 0f;
        content.text = messages[indexer];
        this.from = from;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (indexer == messages.Length - 1)
            {
                Time.timeScale = timeScale;
                Destroy(gameObject);
            }
            else
            {
                indexer++;
                content.text = messages[indexer];
            }
        }
    }
}
