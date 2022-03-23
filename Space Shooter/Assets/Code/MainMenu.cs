using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI highestWaveText;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        int highestWave = PlayerPrefs.GetInt("HighestWave");
        highestWaveText.SetText("Highest Wave: " + highestWave);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
