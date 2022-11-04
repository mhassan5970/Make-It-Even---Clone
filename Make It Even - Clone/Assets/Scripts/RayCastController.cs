using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    public GetUpCubes _lastSelected;
    public static RayCastController Instance;
    private SelectCubesSort _sortCubes;
    public bool Input = false;
    public RaycastHit Hit;
    public bool IsHitNull;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _sortCubes = SelectCubesSort.Instance;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(_sortCubes.SelectCubes[0].transform.position + Vector3.down * Hit.distance,
    //       _sortCubes.SelectCubes[0].transform.localScale);
    //}

    public void SendRaycast()
    {
        Vector3 mainPos = _sortCubes.SelectCubes[0].transform.position;
        float boxcastZ = _sortCubes.SelectCubes[0].transform.position.z + .7f;
        Vector3 boxcastPos = new(mainPos.x, mainPos.y, boxcastZ);
        Physics.BoxCast(boxcastPos, _sortCubes.SelectCubes[0].transform.lossyScale / 2, Vector3.down, out Hit, transform.rotation, Mathf.Infinity);
    }

    public void GetGetUp()
    {
        if (Hit.collider == null & _lastSelected != null)
        {
            _lastSelected.GetDown();
            _lastSelected = null;
            return;
        }

        if (Hit.collider == null)
            return;

        GetUpCubes getupCubes = Hit.collider.GetComponent<GetUpCubes>();
        if (getupCubes != null)
        {
            if (!getupCubes.IsUp)
            {
                if (_lastSelected != null)
                    _lastSelected.GetDown();

                _lastSelected = getupCubes;
                _lastSelected.GetUp();
            }
        }
    }
}