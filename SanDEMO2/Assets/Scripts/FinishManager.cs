using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    //This script handles with Game over or Game finish scenes

    public int objectNum;
    public int count;

    private float menuSceneLoadTime;
    private float gameOvrSceneLoadTime;

    [SerializeField] CarControl carControl;
    [SerializeField] CarControl carControlWL;
    [SerializeField] CarControl carControlTH;
    
    void Start()
    {
        count = 0;
        menuSceneLoadTime = 0;
    }

   
    void Update()
    {
        GameFinished();
        GameOver();
    }

    void GameFinished()
    {
        if(count==objectNum) // If ount is equal to numbers of objects
        {
            Debug.Log("GameFinished"); // Game finished

            menuSceneLoadTime += Time.deltaTime;
            if (menuSceneLoadTime > 2)
            {
                SceneManager.LoadScene("ThankyouScene");
            }
            
        }
    }

    void GameOver()
    {
        if(SceneManager.GetActiveScene().name != "SplitLevel") // Since there is split level different scenarios for gas and game over
        {
            if (GameObject.Find("WLCar") != null)
            {
                if (carControl.gassTankWL <= 0)
                {
                    gameOvrSceneLoadTime += Time.deltaTime;
                    if (gameOvrSceneLoadTime > 2)
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
            if (GameObject.FindGameObjectWithTag("THCar") != null)
            {
                if (carControl.gassTankTH <= 0)
                {
                    gameOvrSceneLoadTime += Time.deltaTime;
                    if (gameOvrSceneLoadTime > 2)
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
        }
        if(SceneManager.GetActiveScene().name == "SplitLevel")
        {
            if (GameObject.Find("WLCar") != null)
            {
                if (carControlWL.gassTankWL <= 0)
                {
                    gameOvrSceneLoadTime += Time.deltaTime;
                    if (gameOvrSceneLoadTime > 2)
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
            if (GameObject.FindGameObjectWithTag("THCar") != null)
            {
                if (carControlTH.gassTankTH <= 0)
                {
                    gameOvrSceneLoadTime += Time.deltaTime;
                    if (gameOvrSceneLoadTime > 2)
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
        }
       
    }
}
