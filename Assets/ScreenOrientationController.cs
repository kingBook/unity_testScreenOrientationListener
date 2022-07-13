using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 屏幕旋转侦听器
/// <para> 注意: </para>
/// <para> 1. 在进入第一帧之后开始侦听 </para>
/// </summary>
public class ScreenOrientationController : MonoBehaviour {

    /// <summary>
    /// 屏幕旋转完成事件，回调函数格式: <code> void OnScreenRotatedHandler(ScreenOrientation orientation) </code>
    /// </summary>
    public event System.Action<ScreenOrientation> onScreenRotatedEvent;

    private ScreenOrientation m_oldScreenOrientation;
    private int m_oldScreenWidth;
    private bool m_onRotatedResumeAutoRotation;

    public void SetOrientation(ScreenOrientation orientation, bool rotatedResumeAutoRotation) {
        Screen.orientation = orientation;
        m_onRotatedResumeAutoRotation = rotatedResumeAutoRotation;
    }

    private void Awake() {
        StartCoroutine(InitCoroutine());
    }

    private IEnumerator InitCoroutine() {
        yield return null;
        m_oldScreenOrientation = Screen.orientation;
        m_oldScreenWidth = Screen.width;
    }

    private void Update() {
        if (m_oldScreenOrientation == 0) return;
        if (m_oldScreenOrientation == Screen.orientation) return;
        if (m_oldScreenWidth == Screen.width) return;

        // 记录上一次的屏幕朝向与屏幕宽
        m_oldScreenOrientation = Screen.orientation;
        m_oldScreenWidth = Screen.width;

        // 屏幕旋转完成后恢复自动旋转
        if (m_onRotatedResumeAutoRotation) {
            m_onRotatedResumeAutoRotation = false;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        // 派发完成事件
        onScreenRotatedEvent?.Invoke(Screen.orientation);

        
    }

}
