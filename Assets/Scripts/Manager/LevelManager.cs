using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int level;

    void Awake()
    {
        StartCoroutine(LoadAsyncOperation());
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {

        //level = PlayerPrefs.GetInt("C_Level");
        Debug.Log(level);
    }
 
    IEnumerator LoadAsyncOperation()
    {
        if (PlayerPrefs.GetInt("isFirst") == 0)
        {
            AsyncOperation gameLevel0 = SceneManager.LoadSceneAsync(1);
            PlayerPrefs.SetInt("isFirst", 1);
            PlayerPrefs.SetInt("C_Level", 1);

            while (gameLevel0.progress < 1)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            AsyncOperation gameLevel = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("C_Level"));

            while (gameLevel.progress < 1)
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void OnEnable()
    {
        EventManager.OnCurrentLevel.AddListener(GetLevel);
        EventManager.OnNextLevel.AddListener(NextLevel);
    }

    private void OnDisable()
    {
        EventManager.OnCurrentLevel.RemoveListener(GetLevel);
        EventManager.OnNextLevel.RemoveListener(NextLevel);
    }

    public void GetLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("C_Level"));
    }

    public void NextLevel()
    {
        level += 1;
        PlayerPrefs.SetInt("C_Level", level);

        SceneManager.LoadScene(PlayerPrefs.GetInt("C_Level"));
    }
}