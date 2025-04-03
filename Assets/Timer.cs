using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public GameObject GameOverCanvas;
    public GameObject playerCamera;
    public GameObject Crosshair;

    private void Start()
    {
        GameOverCanvas.SetActive(false);
        playerCamera.SetActive(true);
        Crosshair.SetActive(true);
    }
    void Update()
    {
        if (remainingTime > 0) 
        { 
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 1;
            timerText.color = Color.red; // colour is red when time is 0:00
            GameOverCanvas.SetActive(true);  //game over
            Time.timeScale = 0; //stops player movement
            playerCamera.SetActive(false); //stops players camera movement
            Crosshair.SetActive(false); //turns off crossahir
        }

        remainingTime -= Time.deltaTime; //created timer
        int minutes = Mathf.FloorToInt(remainingTime / 60); //deviding the timer into minutes and seconds
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}" , minutes, seconds); //Text
    }
}
