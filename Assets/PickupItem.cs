using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public float distanceCast = 0.5f;

    public LayerMask itemMask;

    public Transform holdPos;

    private RaycastHit hit;

    private GameObject itemBeingHeld;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (itemBeingHeld != null && Input.GetKeyDown(KeyCode.Mouse1))
        {
            itemBeingHeld.GetComponent<Rigidbody>().useGravity = true;
            itemBeingHeld.GetComponent<Rigidbody>().isKinematic = false;
            itemBeingHeld.transform.parent = null;
            itemBeingHeld = null;
        }

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceCast, itemMask))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                itemBeingHeld = hit.collider.gameObject;
                itemBeingHeld.GetComponent<Rigidbody>().useGravity = false;
                itemBeingHeld.GetComponent<Rigidbody>().isKinematic = true;
                itemBeingHeld.transform.position = holdPos.position;
                itemBeingHeld.transform.parent = GameObject.Find("HoldPos").transform;
            }
        }
    }
}
