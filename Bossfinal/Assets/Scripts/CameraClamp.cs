using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;


    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(
           Mathf.Clamp(targetToFollow.position.x,-5f,45f),
           Mathf.Clamp(targetToFollow.position.y,-14f,7f),
           transform.position.z); 
    }
}
