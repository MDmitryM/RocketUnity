using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    static private int _CURRENT_SCENE_INDEX;
    static private int _NEXT_SCENE_INDEX;
    static private int _PREVIOUS_SCENE_INDEX;
    static private int _FIRST_SCENE_INDEX;
    private void Awake()
    {
        _FIRST_SCENE_INDEX = 0;
        _CURRENT_SCENE_INDEX = SceneManager.GetActiveScene().buildIndex;
        _NEXT_SCENE_INDEX = _CURRENT_SCENE_INDEX + 1;
        _PREVIOUS_SCENE_INDEX = _CURRENT_SCENE_INDEX - 1;
    }
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Debug.Log("Enemy");
                CrashSeq();
                break;
            case "Friend":
                Debug.Log("Friend");
                break;
            case "Start":
                Debug.Log("Start");
                break;
            case "Finish":
                Debug.Log("Finish");
                WinSeq();
                break;
            case "Boost":
                Debug.Log("Boost");
                break;


            default:
                Debug.Log("XZ");
                CrashSeq();
                break;
        }
    }

    private void CrashSeq()
    {
        GetComponent<MovementHandler>().enabled = false;
        Invoke("ReloadScene",0.5f);
    }

    private void WinSeq()
    {
        
        GetComponent<MovementHandler>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Invoke("LoadNextScene", 1.5f);
    }

    private void LoadNextScene()
    {
        if (_NEXT_SCENE_INDEX < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_NEXT_SCENE_INDEX, LoadSceneMode.Single);
        }
        else
        {
            LoadFirstScene();
        }
    }

    private static void LoadFirstScene()
    {
        SceneManager.LoadScene(_FIRST_SCENE_INDEX, LoadSceneMode.Single);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(_CURRENT_SCENE_INDEX, LoadSceneMode.Single);
    }
}


