using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFactory : MonoBehaviour
{
    public static ColorFactory Instance;

    public List<Material> Materials;

    private void Awake()
    {
        Instance = this;
    }

    public Material GetMaterialByIndex(int value)
    {
        return Materials[value];
    }
}