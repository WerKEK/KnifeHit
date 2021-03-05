using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject restartButtom;
    public GameObject panelKnifes;
    public GameObject iconKnife;
    public Color knifeColor;
    public Text ScoreText;
    public Text AppleText;
    public Thrower thrower;
    public GameController gameController;
    public void ShowRestartButton()
    {
        restartButtom.SetActive(true);
    }
    public void SetInitialDisplayedKnifeCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconKnife, panelKnifes.transform);
    }
    private int knifeIconIndexToChange = 0;
    public void DecrementDisplayedKnifeCount()
    {
        panelKnifes.transform.GetChild(knifeIconIndexToChange++).GetComponent<Image>().color = knifeColor;
        
    }

    public void Update()
    {
        AppleText.text = PlayerPrefs.GetInt("Apple").ToString();
        ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

}
