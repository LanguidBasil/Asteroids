using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

using Project.Core.Conf.SO;
using Project.Input;

namespace Project.Managers
{
    public class UI : MonoBehaviour
    {
        [SerializeField]
        private GameFlow gameFlow;
        [SerializeField]
        private Scorer scorer;
        [SerializeField]
        private SceneInfoSO sceneInfo;
        [SerializeField]
        private PlayerInputs input;
        [SerializeField]
        private PlayerInput unityPlayerInput;
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

            input.Menu += () =>
            {
                SwitchActionMap(sceneInfo.UIActionMapName);
                menu.SetActive(true);
                gameFlow.GamePause();
            };
        }

        private void Start()
        {
            continueButton.interactable = false;
            menu.SetActive(true);

            SwitchControlScheme(keyboardAndMouse, sceneInfo.KeybordAndMouseControlSchemeName);
        }

        public void Continue()
        {
            menu.SetActive(false);
            SwitchActionMap(sceneInfo.GameplayActionMapName);

            gameFlow.GameContinue();
        }

        public void NewGame()
        {
            menu.SetActive(false);
            SwitchActionMap(sceneInfo.GameplayActionMapName);

            continueButton.interactable = true;
            gameFlow.GameStart();
        }

        public void SwitchControls()
        {
            if (controllsToggle.GetComponentInChildren<Text>().text == keyboard)
                SwitchControlScheme(keyboardAndMouse, sceneInfo.KeybordAndMouseControlSchemeName);
            else
                SwitchControlScheme(keyboard, sceneInfo.KeybordControlSchemeName);
        }

        private void SwitchActionMap(string actionMapName)
        {
            unityPlayerInput.SwitchCurrentActionMap(actionMapName);
        }

        private void SwitchControlScheme(string dysplayedText, string controlSchemeName)
        {
            input.RethinkControlScheme(controlSchemeName);
            controllsToggle.GetComponentInChildren<Text>().text = dysplayedText;
            unityPlayerInput.SwitchCurrentControlScheme(controlSchemeName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}