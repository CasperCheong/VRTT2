using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPaddle : MonoBehaviour
{
    [SerializeField]
    public GameObject Paddle;
    private string currentCollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision){
        currentCollision = collision.gameObject.name;
        if (currentCollision == "Paddle"){
            Paddle.transform.position = new Vector3(-0.5577216f,0.8150033f, -0.1922162f);
            Paddle.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
