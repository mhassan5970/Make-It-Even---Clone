using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GetUpCubes : MonoBehaviour
{
    private GridCubeValue _gridCubeValue;
    FindMyFriend _findMyFriend;
    public bool IsUp;

    private Sequence seq;

    private void Start()
    {
        _findMyFriend = GetComponent<FindMyFriend>();
        _gridCubeValue = GetComponent<GridCubeValue>();
    }

    public void GetUp()
    {
        if (!IsUp)
        {
            transform.DOKill();
            transform.DOMoveY(0, 0.5f);
        }

        if (IsUp) 
            return;

        transform.DOKill();
        transform.DOMoveY(transform.position.y + 1, 0.2f);

        IsUp = true;

        CheckMyFriends();
    }

    private void CheckMyFriends()
    {
        for (int i = 0; i < _findMyFriend.MyFriend.Count; i++)
        {
            if (_gridCubeValue.MyValue != _findMyFriend.MyFriend[i].GetComponent<GridCubeValue>().MyValue)
            {  
                continue;
            }

            if (IsUp)
            {
                _findMyFriend.MyFriend[i].GetComponent<GetUpCubes>().GetUp();// kalkarkenhepsini kaldýrýyor
            }
            else
            {
                _findMyFriend.MyFriend[i].GetComponent<GetUpCubes>().GetDown();// inerken hepsini indiriyor
            }
        }
    }

    public void GetDown()
    {
        if (!IsUp) 
            return;

        IsUp = false;

        seq.Append(transform.DOMoveY(0, 0.5f))
            .OnComplete(() =>
            {
                Debug.Log("in in in ");
            }
        );

        CheckMyFriends();
    }
}