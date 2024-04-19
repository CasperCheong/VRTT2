using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using TMPro;
using UnityEngine.SceneManagement;


public class quit : MonoBehaviour
{
    

    private InputData _inputData;
  
    private float triggerValue;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
        Debug.Log("Started inputData: " + _inputData);
    }
    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            
            Debug.Log("triggerValue: " + triggerValue);
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
        {
            
            
            
            Debug.Log("A button: " + Abutton);
            if ( Abutton) {
                SceneManager.LoadScene("TT", LoadSceneMode.Single);
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool Bbutton))
        {
            
            Debug.Log("B button: " + Bbutton);
            if ( Bbutton) {
                SceneManager.LoadScene("VRT", LoadSceneMode.Single);
            }
        }

        //triggerValue = ((float)_inputData._leftController.characteristics);
        //Debug.Log("triggerValue is: " + triggerValue);

        //if (_inputData._leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        //{
        //    _leftMaxScore = Mathf.Max(leftVelocity.magnitude, _leftMaxScore);
        //    leftScoreDisplay.text = _leftMaxScore.ToString("F2");
        //}
        //if (_inputData._rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        //{
        //    _rightMaxScore = Mathf.Max(rightVelocity.magnitude, _rightMaxScore);
        //    rightScoreDisplay.text = _rightMaxScore.ToString("F2");
        //}
    }
}
