using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 4;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
    }


    void Update()
    {
        var horizontal = Input.GetAxis("Vertical");
        var vertical = Input.GetAxis("Horizontal");
        _rigidbody.AddForce(Vector3.right * speed * horizontal);
        _rigidbody.AddForce(Vector3.forward * speed * vertical);
    }
}