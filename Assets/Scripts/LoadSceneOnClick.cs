using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene (sceneIndex);
    }

    public void Reset()
    {
        Time.timeScale = 1;
        EvandriaUpdate.level = 1;
        EvandriaUpdate.score = 0;
        HealthBarScript.health = 50;
        int[] temp = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        CandidateLoader.availableCandidates = temp;
        SceneManager.LoadScene(0);
    }
}
