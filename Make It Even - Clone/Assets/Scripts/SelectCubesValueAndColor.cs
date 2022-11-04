using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectCubesValueAndColor : MonoBehaviour
{
    public enum Calculations
    {
        /*topla*/
        add,
        /*çýkar*/
        subtract,
        /*çarp*/
        multiply,
        /*böl*/
        divide
    }

    public Calculations calculations;

    [HideInInspector] public int a;
    [HideInInspector] public int b;

    public int MyValue;
    public TextMeshPro MyAmount;

    void Start()
    {
        int randomNumber = Random.Range(0, 9);
        GetComponent<MeshRenderer>().material = ColorFactory.Instance.GetMaterialByIndex(randomNumber);

        switch (calculations)
        {
            case Calculations.add:
                MyAmount.text = "+" + MyValue;
                break;
            case Calculations.subtract:
                MyAmount.text = "-" + MyValue;
                break;
            case Calculations.multiply:
                MyAmount.text = "X" + MyValue;
                break;
            case Calculations.divide:
                MyAmount.text = "/" + MyValue;
                break;
            default:
                break;
        }
    }

    public void TakeAction()
    {
        a = RayCastController.Instance.Hit.collider.GetComponent<GridCubeValue>().MyValue; // alttaki küpün dönceki deðeri
        b = a;

        switch (calculations)
        {
            case Calculations.add:
                b += MyValue;

                break;
            case Calculations.subtract:
                b -= MyValue;

                break;
            case Calculations.multiply:
                b = a * MyValue;

                break;
            case Calculations.divide:
                b /= MyValue;

                break;
            default:
                break;
        }

        if (b < 0)
        return;

        RayCastController.Instance.Hit.collider.GetComponent<GridCubeValue>().BeforeAfterValue(a, b);
    }
}