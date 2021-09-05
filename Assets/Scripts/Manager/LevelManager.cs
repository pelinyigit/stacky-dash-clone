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
        
        PlayerPrefs.DeleteAll();
        level = PlayerPrefs.GetInt("C_Level");
        Debug.Log(level);
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