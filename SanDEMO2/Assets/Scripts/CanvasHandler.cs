using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasHandler : MonoBehaviour
{
    //It puts timer and removes texts after sometime

    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] TextMeshProUGUI WLText;
    [SerializeField] TextMeshProUGUI THText;
    float textTimer;

    private void Start()
    {
        textTimer = 0f;
    }
    void Update()
    {
        timerText.text = Time.timeSinceLevelLoad.ToString("0.0");
        textTimer += Time.deltaTime;

        if (SceneManager.GetActiveScene().name == "SplitLevel")
        {
            if (textTimer > 3)
            {
                WLText.text = "";
                THText.text = "";
            }
        }
        if (SceneManager.GetActiveScene().name == "Level1WL")
        {
            if (textTimer > 3)
            {
                WLText.text = "";
            }

        }
        if (SceneManager.GetActiveScene().name == "Level1TH")
        {
            if (textTimer > 3)
            {
                THText.text = "";
            }

        }



    }
}
