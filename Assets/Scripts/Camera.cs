using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, 0);

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();   
    }

    private void Update()
    {
        _transform.LookAt(target);

        Vector3 targetPosition = target.transform.position;
        Vector3 selfPosition = _transform.position;

        _transform.position = new Vector3(
            targetPosition.x + offset.x,
            offset.y,
            targetPosition.z + offset.z
        );
    }
}
