using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayPlaceManager : MonoBehaviour
{
    public static PlayPlaceManager Instance;

    private bool isClockInteracted = false;
    private bool areBlocksSorted = false;
    private bool isXylophoneSequenceCorrect = false;

    public PlayPlaceLightController playPlaceLightController;
    public GameObject EscapeController;
    private Vector3 ballsinitialPosition;
    public GameObject balls;
    public Camera playerCamera;
    public Camera tunnelCamera;
    [SerializeField] private Animator doorAnimator;
    public GameObject player;

    [SerializeField] private VoiceLine enterPlayPlace;
    [SerializeField] private VoiceLine completeClock;
    [SerializeField] private VoiceLine noProgress25;
    [SerializeField] private VoiceLine noProgress60;
    private bool completeClockPlayed = false;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GameObject theClock = GameObject.Find("Clock");
            AkSoundEngine.PostEvent("Stop_Clock_Tick", theClock.gameObject);
            AkSoundEngine.PostEvent("Stop_Lv1_PlayPlaceMusic", this.gameObject);
            AkSoundEngine.PostEvent("Stop_Lv1_LightShowMusic", this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        ballsinitialPosition = balls.transform.position;

        StartCoroutine(WaitForVoiceLineManager());
        StartCoroutine(NoProgress25());
        StartCoroutine(NoProgress60());
    }

    IEnumerator WaitForVoiceLineManager()
    {
        // Wait until VoiceLineManager is no longer null
        yield return new WaitUntil(() => VoiceLineManager.Instance != null);
        VoiceLineManager.Instance.AssignSubtitleTextComponent();

        // Now it's safe to use VoiceLineManager.Instance
        VoiceLineManager.Instance.PlayVoiceLine(enterPlayPlace);
    }

    public void CompletePuzzle(string puzzleName)
    {
        switch (puzzleName)
        {
            case "ClockInteraction":
                isClockInteracted = playPlaceLightController.IsPlayPlaceOpen();
                if (isClockInteracted && !completeClockPlayed)
                {
                    VoiceLineManager.Instance.PlayVoiceLine(completeClock);
                    completeClockPlayed = true;
                }
                if (!isClockInteracted && completeClockPlayed)
                {
                    completeClockPlayed = false;
                }
                break;
            case "BlockSorting":
                areBlocksSorted = true;
                RevealXylophoneSequence();
                break;
            case "Xylophone":
                if (!isClockInteracted || !areBlocksSorted) // Xylophone played too early
                {
                    // Debug.Log("Balls!!!");
                    TriggerBallAvalanche();
                }
                else
                {
                    // Debug.Log($"Correct sequence!!!");
                    if (areBlocksSorted && !isXylophoneSequenceCorrect)
                    {
                        isXylophoneSequenceCorrect = true;
                        OpenTunnel(); // Unlock the escape mechanism
                    }
                }
                break;
            case "Escape":
                if (isClockInteracted && areBlocksSorted && isXylophoneSequenceCorrect)
                {
                    EscapePlayPlace();
                }
                break;
        }
    }

    public bool IsClockInteracted()
    {
        return isClockInteracted;
    }

    public bool AreBlocksSorted
    {
        get { return areBlocksSorted; }
    }

    public bool IsXylophoneSequenceCorrect
    {
        get { return isXylophoneSequenceCorrect; }
    }


    void HighlightBlocks()
    {
        Debug.Log("Clock interacted, highlighting balls.");
        // Insert logic to highlight balls here
    }

    void RevealXylophoneSequence()
    {
        XSequenceChecker.CanClickXylo = false; // disable clicking on xylophone
        Debug.Log("Balls sorted, revealing xylophone sequence.");
        // play sound of xylo
        GameObject theXylo = GameObject.Find("Xylo");
        AkSoundEngine.PostEvent("Play_XyloSequence", theXylo.gameObject);
        Invoke("EnableXyloClicking", 2.75f); // enable clicking on xylophone
    }

    void TriggerBallAvalanche()
    {
        Debug.Log("Xylophone played too early, triggering ball avalanche.");
        balls.SetActive(true);

        StartCoroutine(DisableAndResetAfterDelay(balls, 10f));
    }
    IEnumerator DisableAndResetAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false); // disable ball
        obj.transform.position = ballsinitialPosition; // reset to original position
    }

    void OpenTunnel()
    {
        if (isXylophoneSequenceCorrect)
        {
            Debug.Log("Xylophone sequence correct, opening tunnel.");
            StartCoroutine(SwitchCamera(playerCamera, tunnelCamera, 0f));
            StartCoroutine(PlayerEnable(false, 0f));

            doorAnimator.SetTrigger("Open");

            //play sound        
            Invoke("playDoorSound", 1f);

            StartCoroutine(SwitchCamera(tunnelCamera, playerCamera, 3.5f));
            StartCoroutine(PlayerEnable(true, 3.5f));
        }
    }

    private void playDoorSound()
    {
        AkSoundEngine.PostEvent("Play_SlideDoorOpen_1", this.gameObject);
    }

    void EscapePlayPlace()
    {
        Debug.Log("Escaping the play place.");
        // Insert escape logic here
        EscapeController.GetComponent<EscapeMenuController>().OnEscapeActivated();

        // play sound
        AkSoundEngine.PostEvent("Play_Win", this.gameObject);
    }

    IEnumerator SwitchCamera(Camera cameraToDisable, Camera cameraToEnable, float delay)
    {
        yield return new WaitForSeconds(delay);
        cameraToDisable.gameObject.SetActive(false);
        cameraToEnable.gameObject.SetActive(true);

    }

    IEnumerator PlayerEnable(bool enable, float delay)
    {
        yield return new WaitForSeconds(delay);
        player.GetComponent<playerMovement>().enabled = enable;
    }

    public void ResetPuzzles()
    {
        // Stop music here

        isClockInteracted = false;
        areBlocksSorted = false;
        isXylophoneSequenceCorrect = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool GetIsXylophoneSequenceCorrect()
    {
        return isXylophoneSequenceCorrect;
    }

    void EnableXyloClicking()
    {
        XSequenceChecker.CanClickXylo = true;
    }

    IEnumerator NoProgress25()
    {
        yield return new WaitForSeconds(25f); // wait 25 seconds

        if (!isClockInteracted) // clock not interacted
        {
            VoiceLineManager.Instance.PlayVoiceLine(noProgress25);
        }
    }

    IEnumerator NoProgress60()
    {
        yield return new WaitForSeconds(60f); // wait 60 seconds

        if (!isClockInteracted) // clock not interacted
        {
            VoiceLineManager.Instance.PlayVoiceLine(noProgress60);
        }
    }
}
