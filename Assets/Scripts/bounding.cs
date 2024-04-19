using UnityEngine;

public class ZPositionConstraint : MonoBehaviour
{
    // Define the maximum Z position
    public float maxZPosition = -1.2f;

    void Update()
    {
        // Check if the Z position exceeds the maximum
        if (transform.position.z < maxZPosition)
        {
            // If it does, clamp it back to the maximum
            
            transform.position = new Vector3(-0.49f,-0.4110286f,-0.3600001f);
        }
    }
}