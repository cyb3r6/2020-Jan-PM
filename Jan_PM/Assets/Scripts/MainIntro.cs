using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainIntro : MonoBehaviour
{
    public void LaunchVRScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LaunchVRScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }


}
