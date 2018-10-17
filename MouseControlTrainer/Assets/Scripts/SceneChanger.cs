using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartDelayToLoadLevel(float delay, string newSceneName)
    {
        StartCoroutine(LoadLevelAfterDelay(delay, newSceneName));
    }

    public IEnumerator LoadLevelAfterDelay(float delay, string newSceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(newSceneName);
    }

    public void StartDelayToLoadLevel(float delay, int newSceneIndex)
    {
        StartCoroutine(LoadLevelAfterDelay(delay, newSceneIndex));
    }

    public IEnumerator LoadLevelAfterDelay(float delay, int newSceneIndex)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(newSceneIndex);
    }
}
