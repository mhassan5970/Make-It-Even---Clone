using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public bool CloseInput;

    [SerializeField] private GameObject _betweenScreen;
    [SerializeField] public GameObject FirstScreen;
    [SerializeField] private GameObject _levelComplete;
    [SerializeField] private GameObject _levelFail;

    [SerializeField] private TextMeshProUGUI _fpsCounter;
    private int _fpsf;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _betweenScreen.SetActive(true);

        if (PlayerPrefs.GetInt("firstStart") == 0)
        {
            FirstScreen.SetActive(true);
            PlayerPrefs.SetInt("firstStart", 1);
        }
    }

    private void Update()
    {
        FpsCounter();
    }

    public void EndGame(bool a)
    {
        if (a)
        {
            CloseInput = true;
            _levelComplete.SetActive(true);
            _betweenScreen.SetActive(false);
            LevelEditor.Instance.SelectCubeSetActive();
        }
        else
        {
            CloseInput = true;
            _levelFail.SetActive(true);
            _betweenScreen.SetActive(false);
            LevelEditor.Instance.SelectCubeSetActive();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("firstStart", 0);
    }

    private void FpsCounter()
    {
        _fpsf = (int)(1f / Time.unscaledDeltaTime);
        _fpsCounter.SetText($"Fps : {_fpsf}");
    }
}