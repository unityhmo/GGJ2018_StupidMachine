using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Gamestrap
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private Text _levelText;

        public GameObject _pausePanel;

        private bool _isPaused;

        private void Start()
        {
            _levelText.text = GameManager.Instance.LevelSelected.ToString();


        }

        /// <summary>
        /// It activates the pause animation in the pause panel
        /// </summary>
        public bool IsPaused
        {
            get { return _isPaused; }
            set
            {
                _isPaused = value;

                if (_isPaused)
                {
                    _pausePanel.GetComponent<Animator>().SetBool("Visible", true);
                }
                else
                {
                    _pausePanel.GetComponent<Animator>().SetBool("Visible", false);
                }
            }
        }
    }
}