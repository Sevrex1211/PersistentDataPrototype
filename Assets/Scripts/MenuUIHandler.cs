using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
}
