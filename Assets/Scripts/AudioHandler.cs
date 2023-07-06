using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{ 
    private AudioSource _audioSource;

    [SerializeField]private AudioClip _audioRotationClip;
    [SerializeField]private AudioClip _audioThurstClip;
    [SerializeField]private AudioClip _audioWinningClip;
    [SerializeField]private AudioClip _audioCrashClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) )
        {
            //_audioSource.clip = _audioThurstClip;
            if (!_audioSource.isPlaying ) 
            {
                
                _audioSource.PlayOneShot(_audioThurstClip);
            }
        }
        if (Input.GetKey (KeyCode.A) || (Input.GetKey(KeyCode.D)) ) 
        {
            //_audioSource.clip = _audioRotationClip;
            if (!_audioSource.isPlaying)
            {
                
                _audioSource.PlayOneShot(_audioRotationClip);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Finish") && (_audioWinningClip != null))
        {
            //_audioSource.clip = _audioWinningClip;
            _audioSource.PlayOneShot(_audioWinningClip);
        }
        else if ( (collision.gameObject.tag == "Enemy") && (_audioCrashClip != null)) 
        {
            _audioSource.PlayOneShot(_audioCrashClip);
        }
    }
}
