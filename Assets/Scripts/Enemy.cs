using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Объект к которому будет притягиваться текущий объект")] [SerializeField]
    private GameObject Player;

    private Rigidbody _rigidbody;

    private float speed = 0.1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _rigidbody.AddForceAtPosition((Player.transform.position - transform.position) * speed,
            Player.transform.position);
    }
}