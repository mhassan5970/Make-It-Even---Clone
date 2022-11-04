using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTheGameOverCheck : MonoBehaviour
{
    public static IsTheGameOverCheck Instance;
    public List<GameObject> AllGridCubes;
    bool isNext;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOverCheck()
    {
        int a = AllGridCubes[0].GetComponent<GridCubeValue>().MyValue;
        for (int i = 0; i < AllGridCubes.Count; i++)
        {
            if (AllGridCubes[i].GetComponent<GridCubeValue>().MyValue != a)
            {
                isNext = false;

                if (SelectCubesSort.Instance.GetSelectCubesCount() == 0 & isNext == false)
                {
                    StartCoroutine(GoEnd());
                }
                return;
            }
        }

        isNext = true;
        StartCoroutine(GoEnd());
    }

    IEnumerator GoEnd()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.EndGame(isNext);
    }
}