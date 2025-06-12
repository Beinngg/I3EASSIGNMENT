using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        Animator DoorAnimator;
        bool DoorOpen = false;

        [Header("Animation Names")]
        [SerializeField] string OpenAnimationName = "Open";
        [SerializeField] string CloseAnimationName = "Close";
        [SerializeField] int TimeToShowUI = 1;
        [SerializeField] GameObject ShowDoorLockedUI = null;
        [SerializeField] KeyInventry _keyInventry = null;
        [SerializeField] int waitTimer = 1;
        [SerializeField] bool pauseInteraction = false;

        private void Awake()
        {
            DoorAnimator = GetComponent<Animator>();
        }

        IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (_keyInventry.HasRedKey)
            {
                if (!DoorOpen && !pauseInteraction)
                {
                    DoorAnimator.Play(OpenAnimationName, 0, 0f);
                    DoorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                    StartCoroutine(AutoCloseDoor()); // Start auto-close coroutine
                }
                else if (DoorOpen && !pauseInteraction)
                {
                    DoorAnimator.Play(CloseAnimationName, 0, 0f);
                    DoorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }
            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        // Add this coroutine to auto-close the door after 3 seconds
        IEnumerator AutoCloseDoor()
        {
            yield return new WaitForSeconds(2f);
            if (DoorOpen && !pauseInteraction)
            {
                DoorAnimator.Play(CloseAnimationName, 0, 0f);
                DoorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }

        IEnumerator ShowDoorLocked()
        {
            if (ShowDoorLockedUI != null)
                ShowDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(TimeToShowUI);
            if (ShowDoorLockedUI != null)
                ShowDoorLockedUI.SetActive(false);
        }
    }
}