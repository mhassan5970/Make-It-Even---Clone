using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public float x_Start, y_Start;
    public int columnLength, rowLength;
    public float x_Space, y_Space;
    public GameObject prefab;

    void Start()
    {
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(prefab, new Vector3(x_Space * (i % columnLength), y_Space * (i / columnLength)), Quaternion.identity);
        }
    }
}