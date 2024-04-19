using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class gameplay : MonoBehaviour {
  
    public static int playerPaddleCollision = 0;
    public static int enemyPaddleCollision = 0;

    public GameObject playerside;
    public GameObject enemyside;
    public GameObject playerballspawn;
    

    private GameObject right_hand;
    private GameObject left_hand;

    public GameObject paddle;

    public GameObject ball;

    public BoxCollider paddleBox;
    public BoxCollider enemypaddleBox;

    public GameObject text_score;

    public GameObject enemyPaddle;

    public float speed;
    private float horizontal;
    // Use this for initialization
    void Start () {
      
        
}
	
	// Update is called once per frame
	void Update () {
        
        if (ballbounce.enemyFlag)
        {
            // follow_ball();
        }
        if (ballbounce.resetFlag)
        {
            reset_enemy_paddle();
        }

        if (ballbounce.state == ballbounce.gameState.playerStart)
        {
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            ball.transform.position = playerballspawn.transform.position;
            
        }
        // if (ballbounce.followPlayer == 1)

        //         {
        //           follow_ball();
                    
        //         }
            
        paddleBox = paddle.GetComponent<BoxCollider>();
        Vector3 closestPoint = paddleBox.ClosestPointOnBounds(ball.transform.position);
        float distance = Vector3.Distance(closestPoint, ball.transform.position);

        if (distance < 0.3)
        {

            
            Vector3 fromPaddleToBall = ball.transform.position - paddle.transform.position;
            float horizontalDirection = ball.transform.position.x - paddle.transform.position.x;
            float verticalDirection = ball.transform.position.y - paddle.transform.position.y;
            if (ballbounce.state == ballbounce.gameState.playerStart){
                if (horizontalDirection > 0)
            {
                float leftHit = -1f ;
                if (verticalDirection > 0){
                    ball.GetComponent<Rigidbody>().velocity = new Vector3(leftHit, 4, 5f);
                }
                else {
                    ball.GetComponent<Rigidbody>().velocity = new Vector3(leftHit, 4, -5f);
                }

                
            }
            else{
                float rightHit = 1f  ;
                if (verticalDirection > 0){
                   ball.GetComponent<Rigidbody>().velocity = new Vector3(rightHit, 4, 5f);
                }
                else {
                   ball.GetComponent<Rigidbody>().velocity = new Vector3(rightHit, 4, -5f);
                }
                
            }
            }
            else{
                if (horizontalDirection > 0)
            {
                float leftHit = -1f ;
                if (verticalDirection > 0){
                    ball.GetComponent<Rigidbody>().velocity = new Vector3(leftHit, 3, 4f);
                }
                else {
                    ball.GetComponent<Rigidbody>().velocity = new Vector3(leftHit, -5, 4f);
                }

                
            }
            else{
                float rightHit = 1f  ;
                 if (verticalDirection > 0){
                    ball.GetComponent<Rigidbody>().velocity = new Vector3(rightHit, 3, 4f);
                }
                else {
                    ball.GetComponent<Rigidbody>().velocity = new Vector3(rightHit, -5, 4f);
                }
                
            }
            }
            
            
            

            Debug.Log("PPC=1");
            playerPaddleCollision = 1;
        }

        }

        
            
        

/*
        if(ballbounce.followPlayer == 0)
        {

            Debug.Log("AI in Action");
            speed = 5.0f;
            //track ball smoothly until it crosses the halfway line on the table (or another arbitrary point) and then instantaneously towards ball position 
            // dont follow ball position until a.p., follow ball in (x+a, y+b, z+c) translated to the end of the table where (x, y, z) are coordinates of current ball position.
            float step = speed * Time.deltaTime;
            enemyPaddle.transform.position = Vector3.MoveTowards(enemyPaddle.transform.localPosition, ball.transform.localPosition, step);
        }


    */

    
    public void follow_ball()
    {
        if (ballbounce.followPlayer == 0)
        {

            Debug.Log("AI in Action");
            speed = 5.0f;
            //track ball smoothly until it crosses the halfway line on the table (or another arbitrary point) and then instantaneously towards ball position 
            // dont follow ball position until a.p., follow ball in (x+a, y+b, z+c) translated to the end of the table where (x, y, z) are coordinates of current ball position.
            float step = speed * Time.deltaTime;
            
            enemyPaddle.transform.position = Vector3.MoveTowards(enemyPaddle.transform.localPosition, ball.transform.localPosition, step);

            enemypaddleBox = enemyPaddle.GetComponent<BoxCollider>();

            Vector3 closestPointEnemy = enemypaddleBox.ClosestPointOnBounds(ball.transform.position);
            float enemydistance = Vector3.Distance(closestPointEnemy, ball.transform.position);

            if (enemydistance < 0.2)
            {


                Vector3 fromPaddleToBall = ball.transform.position - enemyPaddle.transform.position;
                if (Vector3.Dot(fromPaddleToBall, enemyPaddle.transform.up) > 0)
                {
                
                ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 3, -5f);
                }
                else
                {
                    
                    ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);

                }
                


                enemyPaddleCollision = 1;
            }
        }

    }

    public void reset_enemy_paddle()
    {
        enemyPaddle.transform.position = new Vector3(-0.6131034f,0.970994f, 4.129431f);
    }

}

