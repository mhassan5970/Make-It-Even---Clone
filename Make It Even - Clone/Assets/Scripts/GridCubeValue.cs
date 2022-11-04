using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridCubeValue : MonoBehaviour
{
    private readonly float _delay = 0.025f;

    private FindMyFriend _findMyFriend;
    public int MyValue;
    public TextMeshPro MyAmount;

    void Start()
    {
        _findMyFriend = GetComponent<FindMyFriend>();
        SetMaterial(ColorFactory.Instance.Materials[MyValue]);

        MyAmount.text = MyValue.ToString();
    }

    public void BeforeAfterValue(int a, int b)
    {
        if (MyValue != a)
            return;

        else
            MyValue = b;

        Material newmaterial = ColorFactory.Instance.GetMaterialByIndex(MyValue % ColorFactory.Instance.Materials.Count);
        SetMaterial(newmaterial);

        MyAmount.text = MyValue.ToString();

        StartCoroutine(ChangeValuesWithDelay(a, b));
    }

    IEnumerator ChangeValuesWithDelay(int a, int b)
    {
        for (int i = 0; i < _findMyFriend.MyFriend.Count; i++)
        {
            yield return new WaitForSeconds(_delay);
            _findMyFriend.MyFriend[i].GetComponent<GridCubeValue>().BeforeAfterValue(a, b);
            GetComponent<TurnAroundYourSelf>().TurnSelf();
            GetComponent<GetUpCubes>().GetDown();
        }
    }

    public void SetMaterial(Material newMaterial)
    {
        GetComponent<MeshRenderer>().material = newMaterial;
    }
}