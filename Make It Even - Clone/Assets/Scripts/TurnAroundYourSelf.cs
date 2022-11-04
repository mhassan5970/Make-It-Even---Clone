using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurnAroundYourSelf : MonoBehaviour
{
    private GridCubeValue _gridCubeValue;
    private int _beforeValue;
    private readonly Sequence _seq;

    private float _counter;

    private void Start()
    {
        _gridCubeValue = GetComponent<GridCubeValue>();
        _beforeValue = _gridCubeValue.MyValue;
    }

    public void TurnSelf()
    {
        SkipNextCube.Instance.IsNext = false;

        _seq.Append(transform.DORotate(new Vector3(0, 360, 0), 0.3f, RotateMode.FastBeyond360).OnComplete(() =>
        {
            _beforeValue = _gridCubeValue.MyValue;
        }
       ));

        _counter = 0;
        DOTween.To(() => _counter, x => _counter = x, 360, .9f)
            .OnComplete(() =>
            {
                IsTheGameOverCheck.Instance.GameOverCheck();
                SkipNextCube.Instance.IsNext = true;
                SelectCubesSort.Instance.SelectCubes[0].GetComponent<BoxCollider>().enabled = true;
                //Debug.Log("acýldým");
                //Debug.Log(SelectCubesSort.Instance.SelectCubes[0].gameObject.name);
            });
    }
}