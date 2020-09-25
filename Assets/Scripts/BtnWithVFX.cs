using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BtnWithVFX : MonoBehaviour
{
    private Button button;
    private new AudioSource audio;

    private void Awake()
    {
        button = GetComponent<Button>();
        audio = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void AddListener(UnityAction unityAction)
    {
        button.onClick.AddListener(unityAction);
        button.onClick.AddListener(() =>
        {
            audio.volume = Globals.instance.game.vfx;
            audio.Play();
        });
    }
}
