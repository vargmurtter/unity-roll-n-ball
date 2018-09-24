using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.GetComponent<Rigidbody>();
            rb.velocity *= 3f;
        }
    }

}
