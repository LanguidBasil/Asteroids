using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Project.Input;

namespace Project.Managers
{
    public class UI : MonoBehaviour
    {
        [SerializeField]
        private EventSystem eventSystem;
        [SerializeField]
        private GameFlow gameFlow;
        [SerializeField]
        private Scorer scorer;
        [SerializeField]
        private PlayerMovementInput pInput;
        [SerializeField]
        [Space(8)]
        private PlayerInput input;
        [SerializeField]
        private string keybordControlSchemeName;
        [SerializeField]
        private string keybordAndMouseControlSchemeName;
        [SerializeField]
        private string gameplayActionMapName;
        [SerializeField]
        private string uiActionMapName;
        [Space(8)]
        [SerializeField]
        private GameObject menu;
        [SerializeField]
        private Button continueButton;
        [SerializeField]
        private Toggle controllsToggle;
        [Space(8)]
        [SerializeField]
        private GameObject hud;
        [SerializeField]
        private Text scoreNumber;
        [SerializeField]
        private Text livesNumber;

        const string keyboard = "KeyB";
        const string keyboardAndMouse = "KeyB & Mouse";

        private void Awake()
        {
            scorer.OnScoreChanged += (object sender, EventArgs e) => { scoreNumber.text = scorer.Score.ToString(); };
            scorer.OnLivesChanged += (object sender, EventArgs e) => { livesNumber.text = scorer.Lives.ToString(); };

            pInput.Menu += () =>
            {
                SwitchActionMap(uiActionMapName);
                menu.SetActive(true);
                gameFlow.GamePause();
            };
        }

        private void Start()
        {
            continueButton.interactable = false;
            menu.SetActive(true);

            SwitchControlScheme(keyboardAndMouse, keybordAndMouseControlSchemeName);
        }

        public void Continue()
        {
            menu.SetActive(false);
            SwitchActionMap(gameplayActionMapName);

            gameFlow.GameContinue();
        }

        public void NewGame()
        {
            menu.SetActive(false);
            SwitchActionMap(gameplayActionMapName);

            continueButton.interactable = true;
            gameFlow.GameStart();
        }

        public void SwitchControls()
        {
            if (controllsToggle.GetComponentInChildren<Text>().text == keyboard)
                SwitchControlScheme(keyboardAndMouse, keybordAndMouseControlSchemeName);
            else
                SwitchControlScheme(keyboard, keybordControlSchemeName);
        }

        private void SwitchActionMap(string actionMapName)
        {
            input.SwitchCurrentActionMap(actionMapName);
        }

        private void SwitchControlScheme(string dysplayedText, string controlSchemeName)
        {
            controllsToggle.GetComponentInChildren<Text>().text = dysplayedText;
            input.SwitchCurrentControlScheme(controlSchemeName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}