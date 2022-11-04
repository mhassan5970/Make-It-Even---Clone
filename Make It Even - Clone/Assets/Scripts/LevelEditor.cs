using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEditor : MonoBehaviour
{
    public static LevelEditor Instance;
    [SerializeField] private TextMeshProUGUI _moves;
    [SerializeField] private TextMeshProUGUI _levelText;
    public List<GameObject> Alllevel;
    private int _currentLevel = 0;
    private int _levelCounter;

    public List<GameObject> MoveCount;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _currentLevel = PlayerPrefs.GetInt("currentLevel");

        Alllevel[_currentLevel].gameObject.SetActive(true);

        _levelCounter = _currentLevel + 1;
        _levelText.text = "LEVEL " + _levelCounter;
        SetMovesText();
    }

    public void NextLevel()
    {
        if (_currentLevel == 9)
            _currentLevel = 0;
        else
            _currentLevel++;

        PlayerPrefs.SetInt("currentLevel", _currentLevel);
        SceneManager.LoadScene(0);
    }

    public void SetMovesText()
    {
        SelectCubesSort selectCubesSort = MoveCount[_currentLevel].gameObject.GetComponent<SelectCubesSort>();
        _moves.text = selectCubesSort.GetSelectCubesCount().ToString();
    }

    public void SelectCubeSetActive()
    {
        SelectCubesSort _selectCubeSort = MoveCount[_currentLevel].GetComponent<SelectCubesSort>();

        for (int i = 0; i < _selectCubeSort.GetSelectCubesCount(); i++)
        {
            _selectCubeSort.SelectCubes[i].GetComponent<BoxCollider>().enabled = false;
        }
    }
}