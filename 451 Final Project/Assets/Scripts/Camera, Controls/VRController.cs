using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using UnityEngine.SceneManagement;

namespace Valve.VR
{
    public class VRController : MonoBehaviour
    {

        /**
        Script that controls how inputs from the user are used
        Both controllers can control rotation and translation
        Additional DPad buttons used to switch camera angles and translation/rotation modes

        Implemented powerup selection system (for future update)
         */

        public SteamVR_Input_Sources leftHand;
        public SteamVR_Input_Sources rightHand;
        public SteamVR_Input_Sources bothHands;

        public Transform leftController;
        public Transform rightController;

        public GameObject leftSelected;
        public Transform leftRotate;
        public GameObject rightSelected;
        public Transform rightRotate;

        int tlayer;
        int rlayer;
        int slayer;

        public Text rightText;
        public Text leftText;

        public int mode;
        int maxModes = 5;
        bool leftHandT = false;
        bool rightHandT = true;

        public CameraPositionController cameraController;
        public PlayerPowerUps powerUp;
        public GameStats gameStats;
        public PlayerShopTowers shop;
        public ControllerUI UI;
        public Transform rig;
        public Core core;


        void Start()
        {
            //Grab layermasks to make raycasting less costly
            tlayer = LayerMask.GetMask("TranslateTower");
            rlayer = LayerMask.GetMask("RotateTower");
            slayer = LayerMask.GetMask("StrategyBoard");

            mode = 0;
        }


        void increaseMode()
        {
            mode++;
            if (mode >= maxModes)
            {
                mode = 0;
            }
        }

        void decreaseMode()
        {
            mode--;
            if (mode < 0)
            {
                mode = maxModes - 1;
            }
        }

        int UIvalue;
        // Update is called once per frame
        void Update()
        {
            //Check for inputs based on current modes
            checkModeChangeButtons();
            if (mode == 0)
            {
                checkRayCastTRS();
            }
            else if (mode == 1)
            {
                checkRayCastPowerUps();
            }
            else if (mode == 2)
            {
                checkBuyTowers();
            }
            else if (mode == 3)
            {
                checkCameraChange();
            }
            else if (mode == 4)
            {
                checkRigMovement();
            }

            if (SteamVR_Input._default.inActions.StartNextLevel.GetStateDown(bothHands))
            {
                if (core.health <= 0)
                {
                    SceneManager.LoadScene(1);
                    Debug.Log("restart");
                }
                else
                {
                    gameStats.startNextLevel();
                    Debug.Log("next level");
                }
            }


        }

        bool cameraMove = false;
        void checkRigMovement()
        {
            if (SteamVR_Input._default.inActions.GrabPinch.GetState(bothHands))
            {
                cameraMove = true;
            }
            else
            {
                cameraMove = false;
            }
            if (cameraMove)
            {
                if (SteamVR_Input._default.inActions.DPadDown.GetStateDown(bothHands))
                {
                    rig.position += new Vector3(0, -0.1f, 0);
                }

                if (SteamVR_Input._default.inActions.DPadUp.GetStateDown(bothHands))
                {
                    rig.position += new Vector3(0, 0.1f, 0);
                }
            }

            UI.setText(mode, 0);
        }

        void checkBuyTowers()
        {
            if (SteamVR_Input._default.inActions.DPadLeft.GetStateDown(bothHands))
            {
                shop.selectPrev();
            }

            if (SteamVR_Input._default.inActions.DPadRight.GetStateDown(bothHands))
            {
                shop.selectNext();
            }

            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(leftHand))
            {
                shop.placeTower(leftController, slayer);
            }
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(rightHand))
            {
                shop.placeTower(rightController, slayer);
            }
            UI.setText(mode, shop.selected);
        }

        //Check for mode changes (Dpad controls)
        void checkModeChangeButtons()
        {
            if (!cameraMove)
            {
                //Change camera views
                if (SteamVR_Input._default.inActions.DPadDown.GetStateDown(bothHands))
                {
                    decreaseMode();
                }

                if (SteamVR_Input._default.inActions.DPadUp.GetStateDown(bothHands))
                {
                    increaseMode();
                }
            }

        }

        void checkCameraChange()
        {
            if (SteamVR_Input._default.inActions.DPadLeft.GetStateDown(bothHands))
            {
                cameraController.switchCameras();
            }

            if (SteamVR_Input._default.inActions.DPadRight.GetStateDown(bothHands))
            {
                cameraController.switchCameras();
            }
            UI.setText(mode, cameraController.selected);
        }

        void checkRayCastPowerUps()
        {
            if (SteamVR_Input._default.inActions.DPadLeft.GetStateDown(bothHands))
            {
                powerUp.selectNext();
            }

            if (SteamVR_Input._default.inActions.DPadRight.GetStateDown(bothHands))
            {
                powerUp.selectPrev();
            }

            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(leftHand))
            {
                powerUp.activatePower(leftController);
            }

            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(rightHand))
            {
                powerUp.activatePower(rightController);
            }
            UI.setText(mode, powerUp.selected);
        }


        void modeCheckTRS()
        {
            if (SteamVR_Input._default.inActions.DPadRight.GetStateDown(rightHand))
            {
                rightHandT = !rightHandT;
                resetRightSelected();
            }
            else if (SteamVR_Input._default.inActions.DPadLeft.GetStateDown(rightHand))
            {
                rightHandT = !rightHandT;
                resetRightSelected();
            }

            if (SteamVR_Input._default.inActions.DPadRight.GetStateDown(leftHand))
            {
                leftHandT = !leftHandT;
                resetLeftSelected();
            }
            else if (SteamVR_Input._default.inActions.DPadLeft.GetStateDown(leftHand))
            {
                leftHandT = !leftHandT;
                resetLeftSelected();
            }

            UI.setText(mode, 0);
        }
        //Check for trigger inputs for selecting and changing certain towers
        void checkRayCastTRS()
        {
            modeCheckTRS();
            //GrabPinch is the trigger button of a htc vive controller
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(leftHand))
            {
                if (leftHandT)
                {
                    if (leftSelected == null)
                    {
                        rayCastLeftTSelect();
                    }
                    else
                    {
                        RayCastLeftTranslate();
                    }
                }
                else
                {
                    if (leftRotate == null)
                    {
                        rayCastLeftRSelect();
                    }
                    else
                    {
                        leftRotateTower();
                    }
                }
            }
            //Continueing to hold the trigger will try to grab a tower if none is selected or
            //will try rotating it
            else if (SteamVR_Input._default.inActions.GrabPinch.GetState(leftHand))
            {
                if (leftHandT)
                {
                    if (leftSelected != null)
                    {
                        RayCastLeftTranslate();
                    }
                }
                else
                {
                    if (leftRotate != null)
                    {
                        leftRotateTower();
                    }
                }
            }
            //Releasing the trigger button will reset what is selected
            else if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(leftHand))
            {
                resetLeftSelected();
            }

            //Similiar implmentation to rotation except holding down will translate the tower
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(rightHand))
            {

                if (rightHandT)
                {
                    if (rightSelected == null)
                    {
                        rayCastRightTSelect();
                    }
                    else
                    {
                        RayCastRightTranslate();
                    }
                }
                else
                {
                    if (rightRotate == null)
                    {
                        rayCastRightRSelect();
                    }
                    else
                    {
                        rightRotateTower();
                    }
                }
            }
            else if (SteamVR_Input._default.inActions.GrabPinch.GetState(rightHand))
            {

                if (rightHandT)
                {
                    if (rightSelected != null)
                    {
                        RayCastRightTranslate();
                    }
                }
                else
                {
                    if (rightRotate != null)
                    {
                        rightRotateTower();
                    }
                }
            }
            else if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(rightHand))
            {
                resetRightSelected();
            }
        }

        void resetRightSelected()
        {
            if (rightHandT)
            {
                rightSelected = null;
                rightRotate = null;
                rightText.text = "Currently translating: Nothing";
            }
            else
            {
                rightSelected = null;
                rightRotate = null;
                rightText.text = "Currently rotating: Nothing";
            }
        }
        void resetLeftSelected()
        {
            if (leftHandT)
            {
                leftSelected = null;
                leftRotate = null;
                leftText.text = "Currently translating: Nothing";
            }
            else
            {
                leftSelected = null;
                leftRotate = null;
                leftText.text = "Currently rotating: Nothing";
            }
        }

        RaycastHit rayHit;
        void rayCastLeftRSelect()
        {
            if (Physics.Raycast(leftController.position, leftController.transform.forward, out rayHit, Mathf.Infinity, rlayer))
            {
                if (rayHit.transform.CompareTag("Rotate"))
                {
                    leftSelected = rayHit.transform.gameObject;
                    leftRotate = leftSelected.GetComponent<RayCastLink>().linked.transform;
                    leftText.text = "Currently rotating: " + rayHit.transform.gameObject.name;
                }
            }
        }
        void rayCastRightRSelect()
        {
            if (Physics.Raycast(rightController.position, rightController.transform.forward, out rayHit, Mathf.Infinity, rlayer))
            {
                if (rayHit.transform.CompareTag("Rotate"))
                {
                    rightSelected = rayHit.transform.gameObject;
                    rightRotate = rightSelected.GetComponent<RayCastLink>().linked.transform;
                    rightText.text = "Currently rotating: " + rayHit.transform.gameObject.name;
                }
            }
        }

        void leftRotateTower()
        {
            if (leftSelected != null)
            {
                //The towers rotation will mimic the controllers rotation
                /*Vector3 temp = leftController.forward;
                if (Vector3.Dot(temp, Vector3.up) < 0)
                {
                    return;
                }*/
                leftRotate.up = leftController.forward;
            }
        }
        void rightRotateTower()
        {
            if (rightSelected != null)
            {
                //The towers rotation will mimic the controllers rotation
                /*Vector3 temp = rightController.forward;
                if (Vector3.Dot(temp, Vector3.up) < 0)
                {
                    return;
                }*/
                rightRotate.up = rightController.forward;
            }
        }

        void rayCastRightTSelect()
        {
            if (Physics.Raycast(rightController.position, rightController.transform.forward, out rayHit, Mathf.Infinity, tlayer))
            {
                if (rayHit.transform.CompareTag("Translate"))
                {
                    rightSelected = rayHit.transform.gameObject;
                    rightText.text = "Currently translating: " + rayHit.transform.gameObject.name;
                }
            }
        }
        void rayCastLeftTSelect()
        {
            if (Physics.Raycast(leftController.position, leftController.transform.forward, out rayHit, Mathf.Infinity, tlayer))
            {
                if (rayHit.transform.CompareTag("Translate"))
                {
                    leftSelected = rayHit.transform.gameObject;
                    leftText.text = "Currently translating: " + rayHit.transform.gameObject.name;
                }
            }
        }

        void RayCastRightTranslate()
        {
            if (Physics.Raycast(rightController.position, rightController.transform.forward, out rayHit, Mathf.Infinity, slayer))
            {
                if (rayHit.transform.CompareTag("StrategyBoard"))
                {
                    rightSelected.GetComponent<RayCastLink>().linked.NodeOrigin = rayHit.point;
                }
            }
        }

        void RayCastLeftTranslate()
        {
            if (Physics.Raycast(leftController.position, leftController.transform.forward, out rayHit, Mathf.Infinity, slayer))
            {
                if (rayHit.transform.CompareTag("StrategyBoard"))
                {
                    leftSelected.GetComponent<RayCastLink>().linked.NodeOrigin = rayHit.point;
                }
            }
        }
    }

}
