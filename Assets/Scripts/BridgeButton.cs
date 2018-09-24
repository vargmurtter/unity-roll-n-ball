using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour {
    
    [SerializeField] private Material greenMaterial;
    [SerializeField] private GameObject[] floors;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rend.material = greenMaterial;
            ActivateBridge();
        }
    }

    private void ActivateBridge()
    {
        for (int i = 0; i < floors.Length; i++)
        {
            floors[i].SetActive(true);
        }
    }
}
