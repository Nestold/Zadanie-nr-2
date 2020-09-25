using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public BtnWithVFX startBtn, optionsBtn, exitBtn;
    public GameObject optionsPanel;

    private void Start()
    {
        Globals.instance.CreateCurtain(CurtainType.cin);
        startBtn.AddListener(Start_OnClick);
        optionsBtn.AddListener(Options_OnClick);
        exitBtn.AddListener(Exit_OnClick);
    }

    private void Start_OnClick()
    {
        Globals.instance.CreateCurtain(CurtainType.cout, "Level_0");
    }
    private void Options_OnClick()
    {
        var optionsPanel = Instantiate(Resources.Load<OptionsManager>("Prefabs/OptionsPanel"), GameObject.Find("Canvas").transform, false);
        optionsPanel.UpdateData();
    }
    private void Exit_OnClick()
    {
        Application.Quit();
    }
}
