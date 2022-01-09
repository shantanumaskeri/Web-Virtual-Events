using System.Runtime.InteropServices;
using UnityEngine;

public class RuntimePlatform : MonoBehaviour
{

    public MouseCamera mouseCamera;
    public TouchCamera touchCamera;

    [DllImport("__Internal")]
    private static extern bool IsOnMobilePlatform();

    public bool CheckWebGLPlatform()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
             return IsOnMobilePlatform();
        #endif
            return false;
    }

    private void Start()
    {
        bool isRunningOnMobile = CheckWebGLPlatform();
        if (isRunningOnMobile)
        {
            mouseCamera.enabled = false;
            touchCamera.enabled = true;
        }
        else
        {
            mouseCamera.enabled = true;
            touchCamera.enabled = false;
        }
    }

}
