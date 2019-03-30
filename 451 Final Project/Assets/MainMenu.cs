using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

namespace Valve.VR
{
    public class MainMenu : MonoBehaviour
    {
        public SteamVR_Input_Sources bothHands;
        // Use this for initialization
        void Start()
        {
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (SteamVR_Input._default.inActions.StartNextLevel.GetStateDown(bothHands))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(1);
            }
        }
    }
}
