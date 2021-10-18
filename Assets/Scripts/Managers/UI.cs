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
        private Button controllsButton;

        private void Start()
        {
            continueButton.interactable = false;
            canvas.SetActive(true);
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

        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}