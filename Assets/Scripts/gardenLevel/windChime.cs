using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windChime : MonoBehaviour, IInteract
{
    public ParticleSystem birdsParticleSystem;
    public TreeGrowthController treeGrowthController;
    public Transform windDirectionIndicator;
    public SequenceChecker sequenceChecker;
    public int chimeID;
    [SerializeField] private Animator chimeAnimator;
    private float lastKeyPressTime = 0f;
    public float cooldownDuration = 1f;

    public void OnMouseDown()
    {
        // check if enough times passed
        if (Time.time - lastKeyPressTime < cooldownDuration || !SequenceChecker.CanClickChime)
        {
            return; // not long enough / playing sequence hint :(
        }
        lastKeyPressTime = Time.time;
        chimeAnimator.SetTrigger("Hit"); // animate hit
                                         // check if the floral puzzle is matched
                                         // if (!true)
        ChangeWindDirection(chimeID);
        if (GardenManager.Instance.IsFloralMatched())
        {
            // Debug.Log($"curr index: {currentSequenceIndex}");
            // Debug.Log($"{chimeID} = {targetSequence[currentSequenceIndex]} is {chimeID == targetSequence[currentSequenceIndex]}");
            if (!GardenManager.Instance.IsWindChimesPlayed)
            {
                FindObjectOfType<SequenceChecker>().ChimeClicked(chimeID);
            }
        }
        else
        {
            Debug.Log("Ah! So many birds!");
            TriggerBirdsAndGrowPlants();
            // GardenManager.Instance.CompletePuzzle("WindChimes");
        }
        StartCoroutine(ResetAnimation(chimeID, 4f));
    }
    IEnumerator ResetAnimation(int id, float delay)
    {
        yield return new WaitForSeconds(delay);
        chimeAnimator.SetTrigger("Return");
    }

    void ChangeWindDirection(int chimeID)
    {
        Vector3 direction = Vector3.zero;
        switch (chimeID)
        {
            case 1:
                AkSoundEngine.PostEvent("Play_ChimeG", this.gameObject); // sound
                direction = Vector3.forward; // North             
                break;
            case 2:
                AkSoundEngine.PostEvent("Play_ChimeE", this.gameObject); // sound
                direction = Vector3.back; // South
                break;
            case 3:
                AkSoundEngine.PostEvent("Play_ChimeD", this.gameObject); // sound
                direction = Vector3.right; // East
                break;
            case 4:
                AkSoundEngine.PostEvent("Play_ChimeC", this.gameObject); // sound
                direction = Vector3.left; // West
                break;
        }

        if (windDirectionIndicator != null && direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            windDirectionIndicator.rotation = targetRotation;
        }
        Debug.Log($"curr chime: {chimeID}");
        Debug.Log($"wind direction: {direction}");

        // play sound
        // AkSoundEngine.PostEvent("Play_ChimeD", this.gameObject);
    }

    void TriggerBirdsAndGrowPlants()
    {
        birdsParticleSystem.Play(); // bird flock
        StartCoroutine(PlayBirdSoundMultipleTimes());
        Invoke("GrowTreesAfterBirds", birdsParticleSystem.main.duration); // delay tree growth after birds
        Invoke("RemoveTreesAfterGrowth", 12f); // reset after 8sec
        // Invoke("ResetGarden", 8f); // reset after 8sec

    }

    IEnumerator PlayBirdSoundMultipleTimes()
    {
        float duration = 5.0f; // Duration in seconds after which the sound should stop
        float startTime = Time.time; // Record the start time

        // play sound
        while (Time.time - startTime < duration)
        {
            AkSoundEngine.PostEvent("Play_BirdsCrazy", this.gameObject);
            yield return new WaitForSeconds(0.1f);
        }
    }


    void GrowTreesAfterBirds()
    {
        treeGrowthController.GrowTreesAtMainPoints();
    }

    void RemoveTreesAfterGrowth()
    {
        treeGrowthController.RemoveTreesAfterGrowth();
    }

    void ResetGarden()
    {
        // reset to initial state
        birdsParticleSystem.Stop();
        birdsParticleSystem.Clear();
        treeGrowthController.ClearAllTrees();
        GardenManager.Instance.ResetPuzzles(); //?
    }
}