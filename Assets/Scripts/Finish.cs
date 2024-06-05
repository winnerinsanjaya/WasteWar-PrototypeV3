using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject player;
    public GameObject uiManager;
    public GameObject manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewStage();
            DestroyObject();
            SceneManager.LoadScene("StageSelect");
        }
    }

    void UnlockNewStage()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedStage", PlayerPrefs.GetInt("UnlockedStage", 1)  + 1);
            PlayerPrefs.Save();
        }
    }

    private void DestroyObject()
    {
        if (player != null)
        {
            Destroy(player);
        }
        if (uiManager != null)
        {
            Destroy(uiManager);
        }
        if (manager != null)
        {
            Destroy(manager);
        }
    }
}
