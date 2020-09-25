using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public BtnWithVFX cancelBtn, applyBtn;
    public Slider musicSlider, vfxSlider;

    private void Start()
    {
        cancelBtn.AddListener(Cancel_OnClick);
        applyBtn.AddListener(Apply_OnClick);
        musicSlider.maxValue = 1;
        vfxSlider.maxValue = 1;
    }

    public void UpdateData()
    {
        musicSlider.value = Globals.instance.game.music;
        vfxSlider.value = Globals.instance.game.vfx;
    }

    private void Cancel_OnClick()
    {
        Destroy(gameObject);
    }
    private void Apply_OnClick()
    {
        Globals.instance.game.music = musicSlider.value;
        Globals.instance.game.vfx = vfxSlider.value;
        Globals.instance.game.Save();
    }
}
