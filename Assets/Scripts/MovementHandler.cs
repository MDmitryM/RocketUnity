using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private Vector3 _rotationSpeed = new Vector3(0,0,75);


    [SerializeField]private float _thurstVol = 100f;


    private Rigidbody _rigidbody;

    private ParticleHandler _particleHandler;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _particleHandler = GetComponent<ParticleHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementThurst();
        MovementRotation();
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
}
