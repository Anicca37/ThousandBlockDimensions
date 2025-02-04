using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdWindow : MonoBehaviour
{
    [SerializeField] private Animator bird;
    [SerializeField] private VoiceLine officeBird;
    private bool soundPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Chirp");
            bird.SetTrigger("Warn");
            Invoke("Warn", 2f);
            Invoke("Push", 4.5f);

            if (soundPlayed == false)
            {
                Invoke("playBirdWing", 1.4f);
                Invoke("ResetBird", 4.5f);
                soundPlayed = true;
            }
        }
    }
    private void ResetBird()
    {
        bird.SetTrigger("Warn Rest");
    }

    private void Warn()
    {
        VoiceLineManager.Instance.PlayVoiceLine(officeBird);
    }

    private void Push()
    {
        TutorialManager.Instance.BirdPush();
    }

    private void playBirdWing()
    {
        GameObject theBird = GameObject.Find("smallBird");
        AkSoundEngine.PostEvent("Play_BirdWing", theBird.gameObject);
    }
}


