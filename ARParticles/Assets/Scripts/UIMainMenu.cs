using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour {

    public GameObject UI;
    public GameObject Load;
    public ProgressBar Bar;
	public void ChangeScene(string scene)
    {
        UI.SetActive(false);
        Load.SetActive(true);
        StartCoroutine(SceneLoad(scene));
    }

    IEnumerator SceneLoad(string scene)
    {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(scene);
        
        while (sceneLoad.progress <0.9)
        {
            Bar.currentPercent = sceneLoad.progress*100;
           
            yield return null;
        }
        
    }


    public void ChangeSceneTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
