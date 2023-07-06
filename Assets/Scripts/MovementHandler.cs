using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private Vector3 _rotationSpeed = new Vector3(0,0,75);


    [SerializeField]private float _thurstVol = 100f;


    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void MovementInput() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space");
            _rigidbody.AddRelativeForce(Vector3.up * _thurstVol * Time.deltaTime);
        }
        _rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            _transform.Rotate(-(_rotationSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            _transform.Rotate(_rotationSpeed * Time.deltaTime);
        }
        _rigidbody.freezeRotation = false;
    }
}
