using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
     private int _currentSceneIndex;
     private int _nextSceneIndex;
     private int _previousSceneIndex;
     private int _firstSceneIndex;

    private static bool _isAlive;

    private ParticleHandler _particleHandler;

    private void Awake()
    {
        _isAlive = true;
        _firstSceneIndex = 0;
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _nextSceneIndex = _currentSceneIndex + 1;
        _previousSceneIndex = _currentSceneIndex - 1;

        _particleHandler = GetComponent<ParticleHandler>();
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
        SetAliveFalse();
        _particleHandler.CrashingParticle();
        GetComponent<MovementHandler>().enabled = false;
        Invoke("ReloadScene",0.5f);
    }

    private void WinSeq()
    {
        if (IsAlive())
        {
            _particleHandler.WinningParticle();
            GetComponent<MovementHandler>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Invoke("LoadNextScene", 1.5f);
        }
    }

    public static void SetAliveFalse() 
    {
        _isAlive = false;
    }

    public static bool IsAlive() 
    {
        return _isAlive;
    }

    private void LoadNextScene()
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

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(_firstSceneIndex, LoadSceneMode.Single);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(_currentSceneIndex, LoadSceneMode.Single);
    }
}


