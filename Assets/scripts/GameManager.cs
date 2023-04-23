using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int health;
    public static int shield;
    public GameObject shield1, shield2, shield3;
    public GameObject heart1, heart2, heart3;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

        shield = 3;
        shield1.gameObject.SetActive(true);
        shield2.gameObject.SetActive(true);
        shield3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                
                Time.timeScale = 0;
                break;
        }

        if (shield > 3)
            shield = 3;

        switch (shield)
        {
            case 3:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(true);
                break;
            case 2:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(true);
                shield3.gameObject.SetActive(false);
                break;
            case 1:
                shield1.gameObject.SetActive(true);
                shield2.gameObject.SetActive(false);
                shield3.gameObject.SetActive(false);
                break;
            case 0:
                shield1.gameObject.SetActive(false);
                shield2.gameObject.SetActive(false);
                shield3.gameObject.SetActive(false);
                break;
        }
    }
}
