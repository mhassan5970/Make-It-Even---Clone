using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragAndDrop : MonoBehaviour
{
    private SelectCubesValueAndColor _selectObjectsValueAndColor;
    [SerializeField] private SelectCubesSort _sortCubes;

    //private Vector3 mOffset;
    private float _mZCoord;
    public Vector3 mousepos;

    private void Start()
    {
        _selectObjectsValueAndColor = GetComponent<SelectCubesValueAndColor>();
        FirstCubeTurnBack();
    }

    /*void OnMouseDown()
    {
    _raycastController.Input = true;
    mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
    mOffset = transform.position - GetMouseAsWorldPoint();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
    Vector3 mousePoint = Input.mousePosition;
    mousePoint.z = mZCoord;
    return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
    transform.position = GetMouseAsWorldPoint() + mOffset ;
    if (UIManager.Instance.CloseInput) return;

    //_raycastController.Input = true;

    }
    */

    void OnMouseDrag()
    {
        if (!SkipNextCube.Instance.IsNext)
            return;

        ObjectDrag();

        RayCastController.Instance.SendRaycast();
        RayCastController.Instance.GetGetUp();
    }

    private void OnMouseUp()
    {
        if (RayCastController.Instance.Hit.collider == null)
        {
            RayCastController.Instance.IsHitNull = true;
        }
        OnMouseUpEvent();
    }

    private void OnMouseUpEvent()
    {
        if (RayCastController.Instance.IsHitNull)
        {
            FirstCubeTurnBack();
            SelectCubesSetScaleAndRot.Instance.AgainSetCubeRot();
            return;
        }

        _selectObjectsValueAndColor.TakeAction();
        if (_selectObjectsValueAndColor.b < 0)
        {
            RayCastController.Instance.Hit.collider.GetComponent<GetUpCubes>().GetDown();
            SelectCubesSetScaleAndRot.Instance.AgainSetCubeRot();
            FirstCubeTurnBack();
            return;
        }

        RayCastController.Instance.Hit = new RaycastHit();

        _sortCubes.SelectCubes[0].SetActive(false);

        if (_sortCubes.GetSelectCubesCount() > 0)
            _sortCubes.SelectCubes[0].GetComponent<BoxCollider>().enabled = false;

        _sortCubes.SelectCubes.RemoveAt(0);

        SelectCubesSetScaleAndRot.Instance.AgainSetCubeRot();

        LevelEditor.Instance.SetMovesText();
        FirstCubeTurnBack();
        _sortCubes.SetPos();
        //_sortCubes.Input = true;

        if (_sortCubes.GetSelectCubesCount() == 0)
            return;
    }

    private void FirstCubeTurnBack()
    {
        if (_sortCubes.GetSelectCubesCount() == 0)
            return;

        _sortCubes.SelectCubes[0].transform.DOMove(_sortCubes._lerpPos.position, 0.2f);
    }

    private void ObjectDrag()
    {
        SelectCubesSetScaleAndRot.Instance.SetWeHoldCubeRotAndScale();
        UIManager.Instance.FirstScreen.SetActive(false);
        _sortCubes.SelectCubes[0].transform.DOKill();
        _mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mousepos = Input.mousePosition;
        mousepos.z = _mZCoord;
        mousepos.y = mousepos.y + 120;
        transform.position = Camera.main.ScreenToWorldPoint(mousepos);

        RayCastController.Instance.IsHitNull = false;
    }
}