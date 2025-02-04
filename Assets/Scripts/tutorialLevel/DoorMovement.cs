using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public ClockManipulation clockController;
    public float minAngle = 90f;
    public float maxAngle = 180f;

    private bool isDoorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanDoorOpen(minAngle, maxAngle))
        {
            if (!isDoorOpen)
            {
                transform.Rotate(Vector3.up, -90f);
                isDoorOpen = true;
                
                GameObject theDoor = GameObject.Find("Door");
                AkSoundEngine.PostEvent("Play_Door_Open", theDoor.gameObject);
            }
        }
        else
        {
            if (isDoorOpen)
            {
                transform.Rotate(Vector3.up, 90f);
                isDoorOpen = false;
                
                GameObject theDoor = GameObject.Find("Door");
                AkSoundEngine.PostEvent("Play_Door_Close", theDoor.gameObject);
            }
        }
    }

    private bool CanDoorOpen(float minAngle, float maxAngle)
    {
        return clockController.CheckClockSet(minAngle, maxAngle, "Either");
    }

    public bool IsDoorOpen()
    {
        return isDoorOpen;
    }
}
