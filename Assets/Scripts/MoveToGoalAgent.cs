using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MoveToGoalAgent : Agent {
    private InputData _inputData;
    public GameObject ball;
    public GameObject enemyPaddle;
    public BoxCollider enemypaddleBox;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
        Debug.Log("Started inputData 2: " + _inputData);
    }
    public override void OnEpisodeBegin(){
        // transform.localPosition = new Vector3(Random.Range(-0.65f,+0.65f),0,Random.Range(-0.55f,0));
        transform.localPosition = new Vector3(0,0,0);
        // targetTransform.localPosition = new Vector3(Random.Range(-1.8f,+0.4f),Random.Range(-0.2f,+0f),Random.Range(-1.7f,+0.3f));
    }

    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions){
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        // float moveZ = actions.ContinuousActions[2];
        
        float moveSpeed = 5.0f;
        if (ballbounce.state == ballbounce.gameState.playerPaddle || (ballbounce.state == ballbounce.gameState.playerSide && ballbounce.serving == 1))
        {
            
        transform.localPosition = transform.localPosition + new Vector3(moveX,0,moveZ) * Time.deltaTime * moveSpeed;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut){
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 mValue))
        {
            
            // Debug.Log("moveValue: " + mValue);
            // Debug.Log("Horizontal:" +mValue.x);
            // Debug.Log("Vertical:" +mValue.y);
            continuousActions[0] = mValue.x;
            continuousActions[1] = mValue.y;
            
            
            
        }

        
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "Ball"){
            Debug.Log("Touch Ball");
            transform.position = new Vector3(-0.4317181f, -0.4110286f, 0.3494308f);
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 3, -5f);
            SetReward(100f);
            floorMeshRenderer.material = winMaterial;
            EndEpisode();
        }
        if (other.gameObject.name == "Cube" || other.gameObject.name == "Cube (1)" || other.gameObject.name == "Cube (2)" || other.gameObject.name == "Cube (3)"|| other.gameObject.name == "Cube (4)"
        || other.gameObject.name == "Cube (5)"){
            Debug.Log("Touch Wall");
            SetReward(-1f);
            
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
        
    }
    
    void Update(){
//         if (Mathf.Approximately(transform.position.z, -2f)) {
//     transform.localPosition = new Vector3(0, 0, 0);
// }
        //     enemypaddleBox = enemyPaddle.GetComponent<BoxCollider>();

        //     Vector3 closestPointEnemy = enemypaddleBox.ClosestPointOnBounds(ball.transform.position);
        //     float enemydistance = Vector3.Distance(closestPointEnemy, ball.transform.position);

        //     if (enemydistance < 0.8f)
        //     {
        //         SetReward(21f);
        //         EndEpisode();
        //         Vector3 fromPaddleToBall = ball.transform.position - enemyPaddle.transform.position;
        //         if (Vector3.Dot(fromPaddleToBall, enemyPaddle.transform.up) > 0)
        //         {
                
        //         ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 3, -5f);
        //         }
        //         else
        //         {
                    
        //             ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);

        //         }
        // }
    }
}