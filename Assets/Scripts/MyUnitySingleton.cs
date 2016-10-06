using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MyUnitySingleton : MonoBehaviour
{

    private static MyUnitySingleton instance = null;
    public static MyUnitySingleton Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Destroy(this.gameObject);
        }
    }
}