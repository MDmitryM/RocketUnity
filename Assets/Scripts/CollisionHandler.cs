using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private static bool _isAlive;

    private ParticleHandler _particleHandler;

    //private MySceneManager _sceneManager;

    private void Awake()
    {
        _isAlive = true;
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

        StartCoroutine(MySceneManager.ReloadScene());

    }

    private void WinSeq()
    {
        if (IsAlive())
        {
            _particleHandler.WinningParticle();
            GetComponent<MovementHandler>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;


            StartCoroutine(MySceneManager.LoadNextScene());
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
}


