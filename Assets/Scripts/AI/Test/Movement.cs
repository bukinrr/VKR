using System;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Movement : Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(-10, transform.localPosition.y, -10);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        float moveSpeed = 0.5f;
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Столкновение с игроком");
    //         SetReward(+1f);
    //         EndEpisode();
    //     }
    //     if (collision.gameObject.CompareTag("Wall"))
    //     {
    //         Debug.Log("Столкновение с игроком");
    //         SetReward(+1f);
    //         EndEpisode();
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Pl>(out Pl pl))
        {
            Debug.Log("Столкновение с игроком");
            SetReward(+1f);
            floorMeshRenderer.material = winMaterial;
            EndEpisode();
        }

        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            Debug.Log("Столкновение со стеной");
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }

        // Debug.Log("Кусок кала работает");
        // if (other.gameObject.CompareTag("Player"))
        // {
        //     Debug.Log("Столкновение с игроком");
        //     SetReward(+1f);
        //     EndEpisode();
        // }

        // if (other.gameObject.CompareTag("Wall"))
        // {
        //     Debug.Log("Столкновение со стеной");
        //     SetReward(-1f);
        //     EndEpisode();
        // }
    }
}