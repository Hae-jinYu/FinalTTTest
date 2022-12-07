using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;
    [SerializeField] float maxTime = 10f;
    float timeLeft;
	 Image timeBar;

    // Start is called before the first frame update
    void Awake()
    {
        gameOverText.SetActive(false);
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
		if (timeLeft > 0)
		{
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
		}
		else
		{
            gameOverText.SetActive(true);
			Time.timeScale = 0;
		}
        
    }
}
