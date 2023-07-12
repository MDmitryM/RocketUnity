using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    private static int _currentSceneIndex;
    private static int _nextSceneIndex;
    private static int _previousSceneIndex;
    private static int _firstSceneIndex;

    private static float _timeBeforeRestartLevel;
    private static float _timeBeforeLoadNexLevel;
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
        _timeBeforeRestartLevel = 0.5f;
        _timeBeforeLoadNexLevel = 1.5f;
    }
    public static IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(_timeBeforeLoadNexLevel);
        if (_nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_nextSceneIndex, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(_firstSceneIndex, LoadSceneMode.Single);
        }
    }
    public static IEnumerator LoadPreviousSceneWithDelay()
    {
        yield return new WaitForSeconds(_timeBeforeLoadNexLevel);
        SceneManager.LoadScene(_previousSceneIndex, LoadSceneMode.Single);
    }
    public static IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(_timeBeforeRestartLevel);
        SceneManager.LoadScene(_currentSceneIndex, LoadSceneMode.Single);
    }
}
