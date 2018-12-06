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
        SceneManager.LoadScene(scene);
    }

    IEnumerator SceneLoad(string scene)
    {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(scene);
        while (!sceneLoad.isDone)
        {
            Bar.currentPercent = sceneLoad.progress;
           
            yield return null;
        }
    }

}
