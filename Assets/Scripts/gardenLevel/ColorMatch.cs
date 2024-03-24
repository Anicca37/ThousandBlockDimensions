using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ColorMatch : MonoBehaviour
{
    public string colorName; 
    public GameObject windEffectPrefab; 
    public static int matchedFlowersCount = 0;
    private const int totalFlowers = 5;
    public ParticleSystem windParticleSystem;
    private SequenceChecker chimeController;

    public static void ResetMatchedFlowersCount()
    {
        matchedFlowersCount = 0;
    }

    void Start()
    {
        ResetMatchedFlowersCount();
    }

    private void OnTriggerEnter(Collider other)
    {
        FlowerScript flowerScript = other.GetComponent<FlowerScript>();
        if (flowerScript != null && flowerScript.colorName == this.colorName && !flowerScript.isMatched)
        {
            // Correct match
            flowerScript.isMatched = true; // Mark as matched
            SnapFlowerToStone(other.gameObject); // Snap flower to stone
            TriggerWindEffect();
            matchedFlowersCount++;
            AutomaticallyDropFlower(other.gameObject);
            CheckAllFlowersMatched();
        }
    }

    void SnapFlowerToStone(GameObject flower)
    {
        var flowerScript = flower.GetComponent<FlowerSwap>();
        if (flowerScript != null)
        {
            flowerScript.SwapFlower();
            AkSoundEngine.PostEvent("Play_FlowerPlant", this.gameObject);
        }
        else
        {
            Debug.LogError("FlowerSwap component missing on " + flower.name);
        }
    }


    void TriggerWindEffect()
    {
        Instantiate(windEffectPrefab, transform.position, Quaternion.identity);
        AkSoundEngine.PostEvent("Play_FlowerWindBlow", this.gameObject);
    }

    void CheckAllFlowersMatched()
    {
        if (matchedFlowersCount >= totalFlowers)
        {
            GardenManager.Instance.CompletePuzzle("Floral");
            windParticleSystem.Play();

            //play sound
            GameObject TheWind = GameObject.Find("wind");
            AkSoundEngine.PostEvent("Play_Wind_Blowing", TheWind.gameObject);
            GameObject TheChimes = GameObject.Find("Wind Chime");
            AkSoundEngine.PostEvent("Play_WindChime", TheChimes.gameObject);
            Invoke("playCorrectSound", 3f); // play correct after 3s;
        }
    }

    public void playCorrectSound()
    {
        GameObject TheChimes = GameObject.Find("Wind Chime");
        AkSoundEngine.PostEvent("Play_Chime_Melody", TheChimes.gameObject);
    }

    void AutomaticallyDropFlower(GameObject flower)
    {
        playerPickup playerPickupScript = flower.GetComponentInParent<playerPickup>();
        playerPickupScript.DropObject();
        flower.tag = "Untagged";
      
    }
}
