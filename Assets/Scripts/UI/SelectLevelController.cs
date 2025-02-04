using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelController : MonoBehaviour
{
    public GameObject mainMenuController;

    public GameObject tutorialLevelSelectedSprite;
    public GameObject ballpitLevelSelectedSprite;
    public GameObject gardenLevelSelectedSprite;
    public GameObject menuSelectedSprite;

    private enum MenuOption { Tutorial, Ballpit, Garden, Menu};
    private MenuOption selectedOption;

    private void Start()
    {
        mainMenuController.GetComponent<MainMenuController>().enabled = false;
        InitializeLevelSelect();
    }

    public void InitializeLevelSelect()
    {
        // default selection
        selectedOption = MenuOption.Tutorial;
        tutorialLevelSelectedSprite.SetActive(true);
    }

    private void Update()
    {
        // handle input
        if (InputManager.instance.SelectionUpInput)
        {
            MoveSelectionUp();
        }
        else if (InputManager.instance.SelectionDownInput)
        {
            MoveSelectionDown();
        }
        else if (InputManager.instance.ConfirmInput)
        {
            SelectOption();
        }
        else if (FPSInputManager.GetCancel())
        {
            while (selectedOption != MenuOption.Menu) 
            {
                MoveSelectionUp();
            }
            SelectOption();
        }
    }

    private void MoveSelectionUp()
    {
        switch (selectedOption)
        {
            case MenuOption.Tutorial:
                selectedOption = MenuOption.Menu;
                tutorialLevelSelectedSprite.SetActive(false);
                menuSelectedSprite.SetActive(true);
                break;
            case MenuOption.Ballpit:
                selectedOption = MenuOption.Tutorial;
                ballpitLevelSelectedSprite.SetActive(false);
                tutorialLevelSelectedSprite.SetActive(true);
                break;
            case MenuOption.Garden:
                selectedOption = MenuOption.Ballpit;
                gardenLevelSelectedSprite.SetActive(false);
                ballpitLevelSelectedSprite.SetActive(true);
                break;
            case MenuOption.Menu:
                selectedOption = MenuOption.Garden;
                menuSelectedSprite.SetActive(false);
                gardenLevelSelectedSprite.SetActive(true);
                break;
        }
    }

    private void MoveSelectionDown()
    {
        switch (selectedOption)
        {
            case MenuOption.Tutorial:
                selectedOption = MenuOption.Ballpit;
                tutorialLevelSelectedSprite.SetActive(false);
                ballpitLevelSelectedSprite.SetActive(true);
                break;
            case MenuOption.Ballpit:
                selectedOption = MenuOption.Garden;
                ballpitLevelSelectedSprite.SetActive(false);
                gardenLevelSelectedSprite.SetActive(true);
                break;
            case MenuOption.Garden:
                selectedOption = MenuOption.Menu;
                gardenLevelSelectedSprite.SetActive(false);
                menuSelectedSprite.SetActive(true);
                break;
            case MenuOption.Menu:
                selectedOption = MenuOption.Tutorial;
                menuSelectedSprite.SetActive(false);
                tutorialLevelSelectedSprite.SetActive(true);
                break;
        }
    }

    private void SelectOption()
    {
        GameObject theMenu = GameObject.Find("Main Menu Controller");

        switch (selectedOption)
        {
            case MenuOption.Tutorial:
                AkSoundEngine.PostEvent("Stop_MainMenu", theMenu.gameObject);
                SceneManager.LoadScene("IntroCutScene");
                break;
            case MenuOption.Ballpit:
                AkSoundEngine.PostEvent("Stop_MainMenu", theMenu.gameObject);
                SceneManager.LoadScene("PlayPlaceIntro");
                break;
            case MenuOption.Garden:
                AkSoundEngine.PostEvent("Stop_MainMenu", theMenu.gameObject);
                SceneManager.LoadScene("GardenIntro");
                break;
            case MenuOption.Menu:
                menuSelectedSprite.SetActive(false);
                // disable selectlevelcontroller and enable mainmenucontroller
                mainMenuController.GetComponent<MainMenuController>().enabled = true;
                mainMenuController.GetComponent<MainMenuController>().InitializeMenu();
                gameObject.GetComponent<SelectLevelController>().enabled = false;
                break;
        }
    }
}