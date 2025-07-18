using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public UISelector postUISelector;
    public UISelector curUISelector;

    [Header("Panels")]
    [SerializeField] private UISelector pausePanel;
    [SerializeField] private UISelector settingPanel;
    public UISelector PausePanel => pausePanel;
    public UISelector SettingPanel => settingPanel;

    private Stack<UISelector> panelStack = new Stack<UISelector>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    /// <summary>
    /// panelStack에 현재 패널을 추가합니다.
    /// </summary>
    public void AddPanel(UISelector newSelector)
    {
        panelStack.Push(newSelector);
    }

    /// <summary>
    /// 패널 카운트 반환
    /// </summary>
    /// <returns></returns>
    public int PannelCount()
    {
        return panelStack.Count;
    }

    /// <summary>
    ///  최상단 패널 활성화
    /// </summary>
    public void TopPanelShow()
    {
        if (panelStack.Count <= 0) return;
        panelStack.Peek().Show();
    }

    /// <summary>
    ///  최상단 패널 비활성화
    /// </summary>
    public void TopPaneHide()
    {
        if (panelStack.Count != 1) return;
        panelStack.Peek().Hide();
    }

    /// <summary>
    /// 현재 패널을 숨기고 새로운 패널을 활성화
    /// </summary>
    /// <param name="newSelector">새로운 패널</param>

    public void ChangePanel(UISelector newSelector)
    {
        /*postUISelector?.Hide();
        postUISelector = curUISelector;
        curUISelector = newSelector;
        curUISelector?.Show();*/

        if (panelStack.Count > 0) panelStack?.Peek().Hide();
        AddPanel(newSelector);
        panelStack.Peek().Show();
    }

    /// <summary>
    /// 현재 패널을 숨기고 이전 패널을 활성화
    /// </summary>
    public void BackPannel()
    {
        if (panelStack.Count == 0) return; // 현재 활성화된 패널이 없으면 실행 x
        panelStack.Pop().Hide();
        if (panelStack.Count > 0)
            panelStack.Peek().Show();
    }

    /// <summary>
    /// 패널을 전부 초기화
    /// </summary>
    public void InitializePannel()
    {
        while(panelStack.Count > 0)  
            panelStack.Pop().Hide();
    }
}
