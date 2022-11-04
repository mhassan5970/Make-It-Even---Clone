using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipNextCube : MonoBehaviour
{
    public static SkipNextCube Instance;

    public bool IsNext;
    
    private void Awake()
    {
        IsNext = true;
        Instance = this;
    }

    public bool NextCubeBool()
    {
        return IsNext;
    }
}