using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject LevelPanel;

    public void clickOnSolo()
    {
        StartPanel.gameObject.SetActive(false);
        LevelPanel.gameObject.SetActive(true);
    }
    public void backFromSolo()
    {
        StartPanel.gameObject.SetActive(true);
        LevelPanel.gameObject.SetActive(false);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("level1");
    }
}
