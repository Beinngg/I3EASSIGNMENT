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
        [serializeField] int waitTimer = 1;
        [SerializeField] bool pauseInteraction = false;
        private void Awake()
        {
            doorAnimator = GetComponent<Animator>();
        }
        IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }
        void PlayAnimation()
        {
            if (_keyInventry.HasRedKey)
            {
                if (!DoorOpen && !pauseInteraction)
                {
                    DoorAnimator.Play(OpenAnimationName, 0, 0, 0f);
                    DoorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                }
                else if (DoorOpen && !pauseInteraction)
                {
                    DoorAnimator.Play(CloseAnimationName, 0, 0, 0f);
                    DoorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }

            }
            else
            {
                startCoroutine(ShowDoorLocked());
            }
        }
        IEnumerator ShowDoorLocked()
        {
            ShowDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(TimeToShowUI);
            ShowDoorLockedUI.SetActive(false);
        }

    }
}