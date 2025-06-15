/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: CHECK IF PLAYER HAS THE KEY AND OPEN DOOR
*/
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        Animator DoorAnimator; // Reference to the door's Animator component
        bool DoorOpen = false; // Tracks if the door is open

        [Header("Animation Names")]
        [SerializeField] string OpenAnimationName = "Open"; // Name of the open animation
        [SerializeField] string CloseAnimationName = "Close"; // Name of the close animation
        [SerializeField] int TimeToShowUI = 1; // How long to show the locked UI
        [SerializeField] GameObject ShowDoorLockedUI = null; // UI to show when door is locked
        [SerializeField] KeyInventry _keyInventry = null; // Reference to the player's key inventory
        [SerializeField] int waitTimer = 1; // Wait time before allowing interaction again
        [SerializeField] bool pauseInteraction = false; // Prevents rapid interaction

        private void Awake()
        {
            DoorAnimator = GetComponent<Animator>(); // Get the Animator component
        }

        IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true; // Pause interaction
            yield return new WaitForSeconds(waitTimer); // Wait
            pauseInteraction = false; // Resume interaction
        }

        public void PlayAnimation()
        {
            // Check if the player has any key; if so, open the door
            if (_keyInventry.HasRedKey)
            {
                OpenDoor();
            }
            else if (_keyInventry.HasBlueKey)
            {
                OpenDoor();
            }
            else if (_keyInventry.HasGreenKey)
            {
                OpenDoor();
            }
            else if (_keyInventry.HasYellowKey)
            {
                OpenDoor();
            }
            else if (_keyInventry.HasPurpleKey)
            {
                OpenDoor();
            }
            else if (_keyInventry.HasOrangeKey)
            {
                OpenDoor();
            }
            else if (_keyInventry.HasWhiteKey)
            {
                OpenDoor();
            }
            else
            {
                StartCoroutine(ShowDoorLocked()); // Show locked UI if no key
            }
        }

        // Coroutine to auto-close the door after a delay
        IEnumerator AutoCloseDoor()
        {
            yield return new WaitForSeconds(2f);
            if (DoorOpen && !pauseInteraction)
            {
                DoorAnimator.Play(CloseAnimationName, 0, 0f); // Play close animation
                DoorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }

        // Coroutine to show the locked UI for a set time
        IEnumerator ShowDoorLocked()
        {
            if (ShowDoorLockedUI != null)
                ShowDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(TimeToShowUI);
            if (ShowDoorLockedUI != null)
                ShowDoorLockedUI.SetActive(false);
        }

        // Opens the door if not already open and not paused
        void OpenDoor()
        {
            if (!DoorOpen && !pauseInteraction)
            {
                DoorAnimator.Play(OpenAnimationName, 0, 0f); // Play open animation
                DoorOpen = true;
                StartCoroutine(AutoCloseDoor()); // Auto-close after delay
                StartCoroutine(PauseDoorInteraction()); // Pause further interaction
            }
        }
    }
}