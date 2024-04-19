using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class text : MonoBehaviour {
  
    

    public GameObject text_score2;


    // Use this for initialization
    void Start () {
      
        
}
    void Update (){
        text_score2.GetComponent<UnityEngine.UI.Text>().text = "TESTING";
    }
}