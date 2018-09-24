using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layerMask;

    private Rigidbody rb;
    private Transform _transform;
    private Vector3 checkPoint = Vector3.zero;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            SetCheckPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
            MoveToCheckPoint();
    }

    private void Movement()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0f, moveV);

        rb.AddForce(move * speed);
    }

    private void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(_transform.position, Vector3.down, out hit, 1.5f, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.Space))
                rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    private void SetCheckPoint()
    {
        checkPoint = _transform.position;
    }

    private void MoveToCheckPoint()
    {
        rb.velocity = Vector3.zero;
        _transform.position = checkPoint;
    }

}
