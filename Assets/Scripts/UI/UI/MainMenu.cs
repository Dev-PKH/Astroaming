﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UISelector
{
    [Header("버튼")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;

    public event EventHandler OnIngameEnter;

    private void Start()
    {
        UIManager.Instance.AddPanel(this);
    }


    public void NewStartButton()
    {
        OnIngameEnter?.Invoke(this, EventArgs.Empty);

        //LoadSceneManager.Instance.ChangeScene(SceneName.Ingame, SceneName.MainMenu); // 메인 메뉴 만들면 이거 실행

        Debug.Log("NewStartButton");
    }

    public void ContinueButton()
    {
        // LoadSceneManager.Instance.LoadScene();
        //UIManager.Instance.BackPannel(); // 현재 MainMenuPanel 제거 (실제 인게임 진입 시 주석 제거)
        Debug.Log("ContinueButton");
    }

    public void SettingButton()
    {
        UIManager.Instance.ChangePanel(UIManager.Instance.SettingPanel);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("게임 종료");
    }

    public override void Back()
    {
        Debug.Log("Back 지원 안함");
    }
}
