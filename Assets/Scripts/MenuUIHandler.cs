using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] Text bestScoreText;
    [SerializeField] InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score : " + GameManager.Instance.PlayerName + " : " + GameManager.Instance.BestScore;
    }

    public void GetCurrentPlayerName()
    {
        GameManager.Instance.CurrentPlayerName = playerNameInput.text;
    }

    public void StartNew()
    {
        GetCurrentPlayerName();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
