using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcast : MonoBehaviour
{
    RaycastHit hit;
    void Start()
    {

    }


    void Update()
    {
        Physics.BoxCast(transform.position, transform.lossyScale / 2, Vector3.down, out hit, transform.rotation, Mathf.Infinity);

        //Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
        if (hit.collider == null) return;
        //Debug.DrawRay(asd, transform.TransformDirection(Vector3.down) * Hit.distance, Color.red);



        Debug.Log(hit.collider.name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.down * hit.distance, transform.localScale);

    }
}