using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public GameObject EscapeController;
    public DoorMovement doorMovement;

    private float distanceToPlayer = 15f;
    private float drawForce = 5f;
    private GameObject player;
    private CharacterController playerController;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<CharacterController>();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (IsPlayerNearby() && doorMovement.IsDoorOpen())
        {
            DrawInward();
        }
    }

    public void ResetPuzzles()
    {
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
    }

    bool IsPlayerNearby()
    {
        // check if player is nearby
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance < distanceToPlayer;
    }

    void DrawInward()
    {
        Vector3 direction = transform.position - player.transform.position;
        playerController.Move(direction * drawForce * Time.deltaTime);
    }
}
