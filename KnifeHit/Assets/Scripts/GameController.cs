using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public int knifeCount;
    public Vector2 knifeSpawnPosition;
    public GameObject knifeObject;
    public UI UI { get; private set; }
    int Score = 0;
    int Record = 0;
    Thrower thrower;
    
    private void Awake()
    {
        Instance = this;
        UI = GetComponent<UI>();
    }
    private void Start()
    {
        UI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife(); 
    }
    public void Update()
    {

    }

    public void OnSuccsessKnifeHit()
    {
        if (knifeCount > 0)
        {

            if (PlayerPrefs.HasKey("Score"))
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("Score", 1);
            }

            Score++;
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }
    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", win);
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            /* if (PlayerPrefs.HasKey("Score"))
             {
                 PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + GetScore() +1);
             }
             else
             {
                 PlayerPrefs.SetInt("Score", GetScore() +1);
             }
             */
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
            Handheld.Vibrate();
            yield return new WaitForSecondsRealtime(0.6f);
            RestartGame();

        }
        else
        {
            if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("Record"))
                PlayerPrefs.SetInt("Record", PlayerPrefs.GetInt("Score"));
            else
                PlayerPrefs.SetInt("Record", PlayerPrefs.GetInt("Record"));
            PlayerPrefs.SetInt("Score", 0);

            yield return new WaitForSecondsRealtime(0.3f);
            UI.ShowRestartButton();
        }
    }    

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public int GetScore()
    {
        return Score;
    }
    public int GetRecord()
    {
        return Record;
    }
    public void OpenMenu()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(0);
    }
}