using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;

    void Awake()
    {
        Instance = this;

    }

    public void HandlePlayerDestroyed()
    {
        if(EnemyShipSpawner.Instance.currentWave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", EnemyShipSpawner.Instance.currentWave);
        }
        StartCoroutine(EndSession());
    }

    private IEnumerator EndSession()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
