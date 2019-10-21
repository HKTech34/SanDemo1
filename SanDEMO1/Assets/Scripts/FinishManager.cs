using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    //This script handles with Game over or Game finish scenes

    public int redObjNum;
    public int blueObjNum;
    public int yellowObjNum;
    public int greenObjNum;

    public int redObjCount;
    public int blueObjCount;
    public int yellowObjCount;
    public int greenObjCount;

    private float menuSceneLoadTime;
    private float gameOvrSceneLoadTime;

    [SerializeField] CarControl carControl;
    [SerializeField] CarControl carControlWL;
    [SerializeField] CarControl carControlTH;
    
    void Start()
    {
        menuSceneLoadTime = 0;

        redObjCount = 0;
        blueObjCount = 0;
        yellowObjCount = 0;
        greenObjCount = 0;
    }

   
    void Update()
    {
        GameFinished();
        GameOver();
    }

    void GameFinished()
    {
        if(redObjCount==redObjNum && blueObjCount==blueObjNum && yellowObjCount == yellowObjNum && greenObjCount==greenObjNum) // If all count is equal to real numbers of objects
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
