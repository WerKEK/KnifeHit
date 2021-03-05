using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text RecordText;
    public Text AppleText;
    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Update()
    {
        RecordText.text = PlayerPrefs.GetInt("Record").ToString();
        AppleText.text = PlayerPrefs.GetInt("Apple").ToString();
    }

    public void DelKeys()
    {
        PlayerPrefs.DeleteAll();
    }
}
