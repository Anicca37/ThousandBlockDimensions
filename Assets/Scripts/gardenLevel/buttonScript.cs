using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public GardenManager GardenManager;
    [SerializeField] private VoiceLine clickBird;

    void Update()
    {
        // Check if the left mouse button was clicked (button index 0)
        if (FPSInputManager.GetInteract())
        {
            // Perform a raycast from the camera to the mouse position
            RaycastHit hit;
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the raycast hit this game object
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        // Left mouse button was clicked on this object, complete the puzzle
                        GardenManager.CompletePuzzle("Scales");

                        //play sound
                        // TODO: switch to bird chirp
                        AkSoundEngine.PostEvent("Play_Birds", this.gameObject);

                        if (!GardenManager.IsScaleBalanced())
                        { 
                            VoiceLineManager.Instance.PlayVoiceLine(clickBird); 
                        }
                    }
                }
            }
        }
    }
}
