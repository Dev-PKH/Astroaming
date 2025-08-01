﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : UISelector
{
    /*[Header("버튼")]
    [SerializeField] private Button gameplayButton;
    [SerializeField] private Button keyBindingButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button LanguageButton;
    */
    public event EventHandler OnMainMenuEnter;

    private void Start()
    {
        //UIManager.Instance.AddPanel(this);
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {

        }*/
    }

    public void ResumeButton()
    {
        //UIManager.Instance.ChangePanel(UIManager.Instance.gameplayPanel);
        UIManager.Instance.TopPaneHide(); // 일시정지 비활성화
        GameManager.Instance.PauseChange();
        Debug.Log("계속하기");
    }

    public void SettingButton()
    {
        UIManager.Instance.ChangePanel(UIManager.Instance.SettingPanel);
        Debug.Log("셋팅");
    }

    public void MainMenuButton()
    {
        OnMainMenuEnter?.Invoke(this, EventArgs.Empty);
    }

    public override void Back()
    {
        UIManager.Instance.TopPaneHide();
        //base.Back();
    }
}
