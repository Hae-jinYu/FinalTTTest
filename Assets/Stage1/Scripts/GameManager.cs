using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public int stage;
    public int enemywlof;

    public GameObject GamePanel;
    public GameObject OverPanel;
    public GameObject MenuPanel;

    public Text enemytxt;
    public Text playerHealth;

    public Image weaponImg;
    public Image weaponImg1;

    public void NextstageStart()
    {
        //SceneManager.LoadScene();
    }

    public void stageEnd()
    {
        stage++;

    }
    public void GameOver()
    {
        GamePanel.SetActive(false);
        OverPanel.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Menu()
    {
        GamePanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void MenuButton()
    {
        Menu();
    }
    private void LateUpdate()
    {
        
        playerHealth.text = "["+player.health + "]";

        weaponImg.color = new Color(1, 1, 1, player.hasItem[0] ? 1 : 0);
        weaponImg1.color = new Color(1, 1, 1, player.hasItem[6] ? 1 : 0);
        enemytxt.text = enemywlof.ToString();
    }
}
