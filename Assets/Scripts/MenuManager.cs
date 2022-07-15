using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI warningText;
    private string currentPlayerName;

    private void Awake()
    {
        warningText.enabled = false;
    }

    public void SetPlayerName(string name)
    {
        currentPlayerName = name;
    }

    public void LoadGame()
    {
        if (currentPlayerName != null)
        {
            DataManager.instance.playerName = currentPlayerName;
            SceneManager.LoadScene(1);
        }
        else
        {
            warningText.enabled = true;
        }
    }

    public void ResetGameData()
    {
        DataManager.instance.ResetGameData();
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
