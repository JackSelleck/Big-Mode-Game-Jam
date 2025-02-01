using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace UI
{
    public class Cutscene_Manager : MonoBehaviour
    {
        [SerializeField] private GameObject ContinueButton;
        [SerializeField] private GameObject PlayButton;
        
        [SerializeField] private GameObject[] cutscenePanels;

        private int currentPanelIndex = 0;
        
        private void Start()
        {
            PlayButton.SetActive(false);
            
            foreach (var panel in cutscenePanels)
            {
                panel.SetActive(false);
            }
            cutscenePanels[currentPanelIndex].SetActive(true);
        }
        
        public void NextPanel()
        {
            cutscenePanels[currentPanelIndex].SetActive(false);
            currentPanelIndex++;
            cutscenePanels[currentPanelIndex].SetActive(true);

            if (currentPanelIndex != cutscenePanels.Length - 1) return;
            
            ContinueButton.SetActive(false);
            PlayButton.SetActive(true);
            Debug.Log("End of cutscene");
            //TODO load the next scene.
        }
        
        public void PlayGame(string nextSceneName)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}