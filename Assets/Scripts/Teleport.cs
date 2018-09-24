using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    [SerializeField] private Transform point;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject canvas;


    private void OnTriggerStay(Collider other)
    {
        canvas.SetActive(true);
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(MoveToPoint(other.gameObject));
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
    }

    private IEnumerator MoveToPoint(GameObject go)
    {

        canvas.SetActive(false);

        particle.Play();
        go.SetActive(false);

        yield return new WaitForSeconds(3);

        go.SetActive(true);
        go.transform.position = point.position;
        point.GetComponentInChildren<ParticleSystem>().Play();
        go.SetActive(false);

        yield return new WaitForSeconds(2);

        go.SetActive(true);
        go.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }

}
