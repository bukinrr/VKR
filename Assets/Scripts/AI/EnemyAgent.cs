using UnityEngine;
using Unity.MLAgents;
using Random = UnityEngine.Random;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class EnemyAgent : Agent
{
    private Enemy _enemy;
    private Rigidbody _rigidbody;
    [SerializeField] private float speed;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        speed = _enemy.Speed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Transform target;

    // public override void OnEpisodeBegin()
    // {
    //     _rigidbody.angularVelocity = Vector3.zero;
    //     _rigidbody.velocity = Vector3.zero;
    //     transform.localPosition = TrainPosition();
    //     //transform.localPosition = new Vector3(Random.Range(-Random.Range(10,24), Random.Range(Random.Range(10,24))));
    // }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(target.localPosition);
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(_rigidbody.velocity.x);
        sensor.AddObservation(_rigidbody.velocity.z);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actions.ContinuousActions[0];
        controlSignal.z = actions.ContinuousActions[1];

        Quaternion targetRotation = Quaternion.LookRotation(controlSignal);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
        _rigidbody.AddForce(controlSignal * speed * Time.deltaTime);
        _rigidbody.MoveRotation(targetRotation);

        float distanceToTarget = Vector3.Distance(transform.localPosition, target.localPosition);
        if (distanceToTarget <= 15f)
        {
            var reward = 0.000001f * 15f - distanceToTarget;
            AddReward(reward);
        }

        if (distanceToTarget < 1f)
        {
            //Debug.Log("Подошел к 1");
            AddReward(0.5f);
            EndEpisode();
        }
        else if (distanceToTarget >=30)
        {
            AddReward(-0.01f);
            EndEpisode();
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
            AddReward(-0.03f);
        }
        else if (other.CompareTag("Bullet"))
        {
            AddReward(-0.01f);
        }
    }
}