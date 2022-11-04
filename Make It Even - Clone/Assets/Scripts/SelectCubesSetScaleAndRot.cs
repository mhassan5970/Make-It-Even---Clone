using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectCubesSetScaleAndRot : MonoBehaviour
{
    public static SelectCubesSetScaleAndRot Instance;
    private Vector3 _setScale;
    private Vector3 _onMouseScale;
    private Quaternion _qua;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _setScale = new(1.85f, 5f, 1.45f);
        _onMouseScale = new(1.7f, 1f, 1.8f);
        _qua = Quaternion.Euler(40, 0, 0);

        StartSetSubeRot();
    }

    public void SetWeHoldCubeRotAndScale()
    {
        GameObject FirstCube = SelectCubesSort.Instance.SelectCubes[0];
        Vector3 FirstCubePos = new(SelectCubesSort.Instance.SelectCubes[0].transform.position.x, 4f, SelectCubesSort.Instance.SelectCubes[0].transform.position.z);
        FirstCube.transform.SetPositionAndRotation(FirstCubePos, Quaternion.Euler(5, 0, 0));
        FirstCube.transform.localScale = _onMouseScale;
    }
    public void AgainSetCubeRot()
    {
        if (SelectCubesSort.Instance.SelectCubes.Count == 0)
            return;

        GameObject FirstCube = SelectCubesSort.Instance.SelectCubes[0];
        FirstCube.transform.rotation = _qua;
        FirstCube.transform.DOScale(_setScale, .2f);
    }
    public void StartSetSubeRot()
    {
        GameObject FirstCube = SelectCubesSort.Instance.SelectCubes[0];
        FirstCube.transform.rotation = _qua;
        FirstCube.transform.localScale = _setScale;
    }
}