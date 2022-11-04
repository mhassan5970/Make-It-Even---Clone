using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMyFriend : MonoBehaviour
{
    GridCubeValue gridCubeValue;
    public List<GameObject> MyFriend;
    private Vector3[] directions = new Vector3[] {
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private void Awake()
    {
        gridCubeValue = GetComponent<GridCubeValue>();
    }
    private void Start()
    {
        AgainSendRayCast();
    }

    private void SendRayCast(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, 3);

        if (hit.collider != null)
        {
            MyFriend.Add(hit.collider.gameObject); 
        }
    }

    public void AgainSendRayCast()
    {
        foreach (Vector3 direction in directions)
        {
            SendRayCast(direction);
        }
    }
}