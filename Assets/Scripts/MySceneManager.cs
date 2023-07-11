using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    private int _currentSceneIndex;
    private int _nextSceneIndex;
    private int _previousSceneIndex;
    private int _firstSceneIndex;

    private float timeBeforeRestartLevel;
    private float timeBeforeLoadNexLevel;

    private void Awake()
    {
        _firstSceneIndex = 0;
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _nextSceneIndex = _currentSceneIndex + 1;
        

        switch (_currentSceneIndex) 
        {
            case 0:
                _previousSceneIndex = 0;
                break;
            default:
                _previousSceneIndex = _currentSceneIndex - 1;
                break; 
        }

        timeBeforeRestartLevel = 0.5f;
        timeBeforeLoadNexLevel = 1.5f;
    }

    public void LoadNextScene()
    {
        if (_nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {

            SceneManager.LoadScene(_nextSceneIndex, LoadSceneMode.Single);
        }
        else
        {
            LoadFirstScene();
        }
    }
    public void LoadPreviousSceneWithDelay()
    {
        SceneManager.LoadScene(_previousSceneIndex, LoadSceneMode.Single);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(_firstSceneIndex, LoadSceneMode.Single);
    }

    public void ReloadScene()
    {

        SceneManager.LoadScene(_currentSceneIndex, LoadSceneMode.Single);
    }

    public float DelayBeforeReloadLevel() 
    {
        return timeBeforeRestartLevel;
    }

    public float DelayBeforeLoadNextLevel()
    {
        return timeBeforeLoadNexLevel;
    }

}
