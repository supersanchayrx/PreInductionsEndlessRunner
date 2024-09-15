using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public scoreManager scoreScript;


    
    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("WeedScene");
    }

    public void RestartScene()
    {
        scoreScript.Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
