using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Untagged":
                
                StartCrashSequence();
     
                break;

            case "Finish":

                StartSuccessSequence();
                break;
        }
    }


    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("Respawn", delay);

    }


    void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);

    }


    void Respawn()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex);
    }

    void LoadNextLevel()
    {

        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(sceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            sceneIndex = 0;
        }
        SceneManager.LoadScene(sceneIndex);

    }
}
