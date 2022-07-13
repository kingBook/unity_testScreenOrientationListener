using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTest : MonoBehaviour {

    [SerializeField] private Text m_text;

    private ScreenOrientationController m_screenOrientationListener;

    #region Editor References
    public void OnClickButtonLandscape() {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void OnClickButtonPortrait() {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void OnClickButtonClear() {
        m_text.text = "";
    }
    #endregion

    private void Log(string str) {
        Debug.Log(str);
        m_text.text += $"{str}\n";
    }

    private void OnScreenRotatedHandler(ScreenOrientation orientation) {
        //Log($"onRotated Screen.orientation:{Screen.orientation}, Screen.width:{Screen.width}, Screen.height:{Screen.height}");
    }

    private void Start() {
        m_text.text = "";
        m_screenOrientationListener = GetComponent<ScreenOrientationController>();
        m_screenOrientationListener.onScreenRotatedEvent += OnScreenRotatedHandler;
    }

    private void Update() {
        Log($"Screen.orientation:{Screen.orientation}, Screen.width:{Screen.width}, Screen.height:{Screen.height}");
    }


}
