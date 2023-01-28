using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float cameraFollowSpeed = 5f;
    private Vector3 offsetVector;
    // Start is called before the first frame update
    void Start()
    {
        offsetVector = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {       
        Vector3 targetToMove = target.position + offsetVector;
        transform.position = Vector3.Lerp(transform.position, targetToMove, cameraFollowSpeed * Time.deltaTime);
        }
    }
}