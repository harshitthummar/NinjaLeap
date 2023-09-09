using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playercam;

    [Header("Camera Config")]
    [SerializeField] private float AheadDistance;
    [SerializeField] private float CameraSpeed;

    private float LookAhead;
    // Update is called once per frame
    private void Update()
    {
       // transform.position = new Vector3(playercam.position.x /* * AheadDistance*/,playercam.position.y,transform.position.z);
    
        transform.position = new Vector3(playercam.position.x + LookAhead, transform.position.y,transform.position.z);
        LookAhead = Mathf.Lerp(LookAhead, (AheadDistance * playercam.localScale.x),Time.deltaTime * CameraSpeed);
    }
}
