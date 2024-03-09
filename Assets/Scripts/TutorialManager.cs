using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public GameObject EscapeController;   

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);

            AkSoundEngine.PostEvent("Play_Level0Music", this.gameObject);                       
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ResetPuzzles()
    {
        //stop music
        AkSoundEngine.PostEvent("Stop_Level0Music", this.gameObject);

        GameObject TheClock = GameObject.Find("Clock");
        AkSoundEngine.PostEvent("Stop_Clock_Tick", TheClock.gameObject);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the tutorial area.");
            EscapeTutorial();
        }
    }

    private void EscapeTutorial()
    {
        Debug.Log("Escaping the office.");
        EscapeController.GetComponent<EscapeMenuController>().OnEscapeActivated();

        AkSoundEngine.PostEvent("Play_Win", this.gameObject);
    }
}
