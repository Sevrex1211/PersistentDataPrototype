using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public TMP_InputField NameInputField;
    public Button StartButton;
    public Button QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartNewGame);
        QuitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartNewGame()
    {
        var instance = PersistentData.Instance;
        instance.playerName = 
            (string) NameInputField.text;
        instance.LoadPlayerName();

        SceneManager.LoadScene(1);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
