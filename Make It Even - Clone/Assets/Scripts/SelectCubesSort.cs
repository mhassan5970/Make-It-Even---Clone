using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectCubesSort : MonoBehaviour
{
    public static SelectCubesSort Instance;

    [SerializeField] public List<GameObject> SelectCubes;
    //public bool Input;
    public bool AgainInput = true;
    public Transform _lerpPos;
    public float Distance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetOtherCubesRotAndScale();
    }

    //private void Update()
    //{
    //    //TurnBack();
    //}

    //private void TurnBack()
    //{
    //    if (SelectCubes.Count == 0) return;

    //    if (_rayCastController.IsHitNull & !_rayCastController.Input)
    //    {
    //        if (SelectCubes.Count == 0) return;

    //        float timeDuration = .1f;
    //        float elapsedTime = 0f;

    //        while (elapsedTime < timeDuration)
    //        {
    //            elapsedTime += Time.deltaTime;
    //            SelectCubes[0].transform.localPosition = Vector3.Lerp(SelectCubes[0].transform.localPosition, _lerpPos.position, elapsedTime * 5f);
    //            return;
    //        }
    //        _rayCastController.IsHitNull = false;
    //    }
    //}

    public void SetPos()
    {
        if (GetSelectCubesCount() == 0)
            return;

        for (int i = 0; i < GetSelectCubesCount(); i++)
        {
            Vector3 lerpPos = new(_lerpPos.position.x + (i * Distance), SelectCubes[i].transform.position.y, SelectCubes[i].transform.position.z);
            AgainSetRotAndScale();
            StartCoroutine(GoPos(lerpPos, SelectCubes[i].transform));
        }
    }

    public IEnumerator GoPos(Vector3 position, Transform cube)
    {
        float timeDuration = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < timeDuration)
        {
            elapsedTime += Time.deltaTime;
            cube.position = Vector3.Lerp(cube.position, position, elapsedTime * 0.3f);
            yield return null;
        }
    }

    private void AgainSetRotAndScale()
    {
        SetOtherCubesRotAndScale();

        GameObject FirstCube = SelectCubes[0];
        FirstCube.transform.rotation = Quaternion.Euler(40, 0, 0);
        FirstCube.transform.localScale = new(1.2f, 3.26f, 0.95f);
    }

    private void SetOtherCubesRotAndScale()
    {
        for (int i = 0; i < GetSelectCubesCount(); i++)
        {
            if (i == 0)
                continue;
            if (i == 1)
            {
                SelectCubes[i].transform.localScale = new(1.6f, 1.5f, 1.29f);
                SelectCubes[i].transform.position = new(SelectCubes[i].transform.position.x, 2, -18.35f);
            }

            else
            {
                SelectCubes[i].transform.transform.position = new(SelectCubes[i].transform.transform.position.x, 1.5f, -18.65f);
                SelectCubes[i].transform.rotation = Quaternion.Euler(40, 0, 0);
                SelectCubes[i].transform.localScale = new(1.54f, 1.32f, 1.32f);
            }
        }
    }

    public int GetSelectCubesCount()
    {
        return SelectCubes.Count;
    }
}