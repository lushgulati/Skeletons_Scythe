using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour
{
    public int sceneNumber;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
            SceneManager.LoadScene(sceneNumber);
    }
}
