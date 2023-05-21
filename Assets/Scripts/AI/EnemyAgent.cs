using System;
using UnityEngine;
using Unity.MLAgents;
using Random = UnityEngine.Random;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class EnemyAgent : Agent
{
    private Enemy _enemy;
    private Rigidbody _rigidbody;
    [SerializeField] private Transform targetTransform;

    private Vector3 _startPosition;

    //private Quaternion _targetRotation;
    [SerializeField] private float speed;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        speed = _enemy.Speed;
        _rigidbody = GetComponent<Rigidbody>();
        //_targetRotation = Quaternion.identity;
        _startPosition = transform.localPosition;
    }

    // public override void OnEpisodeBegin()
    // {
    //     _rigidbody.angularVelocity = Vector3.zero;
    //     _rigidbody.velocity = Vector3.zero;
    //     transform.localPosition = TrainPosition();
    //     //transform.localPosition = new Vector3(Random.Range(-Random.Range(10,24), Random.Range(Random.Range(10,24))));
    // }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(targetTransform.localPosition);
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(_rigidbody.velocity.x);
        sensor.AddObservation(_rigidbody.velocity.z);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 movementSignal = Vector3.zero;
        movementSignal.x = actions.ContinuousActions[0];
        movementSignal.z = actions.ContinuousActions[1];

        Quaternion targetRotation = Quaternion.LookRotation(movementSignal);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
        
        

        _rigidbody.AddForce(movementSignal * speed * Time.deltaTime);
        _rigidbody.MoveRotation(targetRotation);


        float distanceToTarget = Vector3.Distance(transform.localPosition, targetTransform.localPosition);
        float previousDistance = Vector3.Distance(_startPosition, targetTransform.localPosition);
        if (distanceToTarget < previousDistance)
        {
            var reward = 0.00001f;
            AddReward(reward);
        }
        else
        {
            AddReward(-0.001f);
        }

        if (distanceToTarget < 3.6f)
        {
            //Debug.Log("Подошел к 1");
            AddReward(2f);
        }
        else if (distanceToTarget >= 22)
        {
            AddReward(-1f);
        }
    }

    // public Vector3 TrainPosition()
    // {
    //     float rndX = Random.Range(minBorder, maxBorder);
    //     float rndZ = Random.Range(minBorder, maxBorder);
    //     float rndXMinus = -Random.Range(minBorder, maxBorder);
    //     float rndZMinus = -Random.Range(minBorder, maxBorder);
    //     
    //     return new Vector3(Random.Range(rndXMinus, rndX), 0f, Random.Range(rndZMinus, rndZ));
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            AddReward(-0.05f);
        }

        // if (other.CompareTag("Bullet"))
        // {
        //     AddReward(-0.03f);
        // }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            SetReward(-100f);
            Debug.Log("Стоит у стены");
            Destroy(gameObject);
        }
    }
}