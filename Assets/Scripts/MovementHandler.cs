using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    
    [SerializeField] private Vector3 _rotationSpeed = new Vector3(0,0,75);
    [SerializeField]private float _thurstVol = 100f;

    private Transform _transform;

    private Rigidbody _rigidbody;

    private CapsuleCollider _collider;

    private ParticleHandler _particleHandler;

void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _particleHandler = GetComponent<ParticleHandler>();

    }

    void Update()
    {
        MovementThurst();
        MovementRotation();
        CheatCodes();
    }

    private void MovementThurst()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space");
            if (!_particleHandler.IsMiddleParticlePlaying())
            {
                _particleHandler.MiddleParticleStart();
            }
            _rigidbody.AddRelativeForce(Vector3.up * _thurstVol * Time.deltaTime);
        }
        else 
        {
            _particleHandler.MiddleParticleStop();
        }
        
    }
    private void MovementRotation()
    {
        _rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            if (!_particleHandler.IsRightParticlePlaying())
            {
                _particleHandler.RightRotationParticleStart();
            }
            _transform.Rotate(-(_rotationSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            if (!_particleHandler.IsLeftParticlePlaying())
            {
                _particleHandler.LeftRotationParticleStart();
            }
            _transform.Rotate(_rotationSpeed * Time.deltaTime);
        }
        else
        {
            _particleHandler.LeftRotationParticleStop();
            _particleHandler.RightRotationParticleStop();
        }
        _rigidbody.freezeRotation = false;
        
    }

    private void CheatCodes()
    {
        if (Input.GetKeyDown(KeyCode.N)) 
        {
            StartCoroutine(MySceneManager.LoadNextScene());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            switch (_collider.enabled) 
            {
                case true:
                    _collider.enabled = false;
                    break;
                case false:
                    _collider.enabled = true;
                    break;
            }
        }
    }
}
