using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementEnemy();
        DestroyEnemy();
    }

    private void MovementEnemy()
    {
        _rigidbody.AddForceAtPosition((player.transform.position - transform.position).normalized * Speed,
            player.transform.position);
    }

    private void DestroyEnemy()
    {
        if (Health == 0)
        {
            Destroy(gameObject);
            Debug.Log($"У объекта {gameObject.name} закончилось здоровье, поэтому он уничтожен ");
        }
    }
}