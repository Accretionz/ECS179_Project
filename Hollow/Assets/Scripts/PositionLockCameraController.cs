using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PositionLockCameraController : MonoBehaviour
{
    [SerializeField] public GameObject target;

    private Camera managedCamera;

    private void Awake()
    {
        managedCamera = gameObject.GetComponent<Camera>();
    }

  
    void LateUpdate()
    {
        var targetPosition = target.transform.position;
        var cameraPosition = managedCamera.transform.position;

        managedCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);
    }
}

