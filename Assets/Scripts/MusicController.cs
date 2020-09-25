using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    List<AudioSource> audios;
    public static MusicController instance;
    public int selectedClip;
    public int clipsCount
    {
        get
        {
            return transform.childCount;
        }
    }

    private void Start()
    {
        if (instance == null)
        {
            selectedClip = Globals.instance.random.Next(0, clipsCount);
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);

        audios = new List<AudioSource>();
        for (int i = 0; i < clipsCount; i++)
        {
            audios.Add(transform.GetChild(i).GetComponent<AudioSource>());
        }
        audios[selectedClip].Play();
    }
    private void FixedUpdate()
    {
        audios[selectedClip].volume = Globals.instance.game.music;
        if (Globals.instance.game.music > 0)
        {
            if (!audios[selectedClip].isPlaying)
            {
                selectedClip = Globals.instance.random.Next(0, clipsCount);
                audios[selectedClip].Play();
            }
        }
    }
}
