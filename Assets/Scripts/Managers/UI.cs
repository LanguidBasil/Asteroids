using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Project.Managers
{
    public class UI : MonoBehaviour
    {
        [SerializeField]
        private GameFlow gameFlow;
        [SerializeField]
        private PlayerInput input;
        [SerializeField]
        private GameObject canvas;
        [SerializeField]
        private Button continueButton;
        [SerializeField]
        private Toggle controllsToggle;
        [Space(8)]
        [SerializeField]
        private string keybordControlSchemeName;
        [SerializeField]
        private string keybordAndMouseControlSchemeName;

        const string keyboard = "KeyB";
        const string keyboardAndMouse = "KeyB & Mouse";

        private void Start()
        {
            continueButton.interactable = false;
            canvas.SetActive(true);

            SwitchControlScheme(keyboard, keybordControlSchemeName);
        }

        public void Continue()
        {
            canvas.SetActive(false);
            gameFlow.GameContinue();
        }

        public void NewGame()
        {
            canvas.SetActive(false);
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