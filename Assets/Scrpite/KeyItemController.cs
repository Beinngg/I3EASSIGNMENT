/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: MATCH KEYS AND DOORS, OPEN DOORS OR ADD KEYS TO INVENTORY
*/
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        // Booleans to identify which type of key or door this object is
        [SerializeField] bool RedDoor = false;
        [SerializeField] bool RedKey = false;
        [SerializeField] bool BlueDoor = false;
        [SerializeField] bool BlueKey = false;
        [SerializeField] bool GreenDoor = false;
        [SerializeField] bool GreenKey = false;
        [SerializeField] bool YellowDoor = false;
        [SerializeField] bool YellowKey = false;        
        [SerializeField] bool PurpleDoor = false;
        [SerializeField] bool PurpleKey = false;
        [SerializeField] bool OrangeDoor = false;
        [SerializeField] bool OrangeKey = false;
        [SerializeField] bool WhiteDoor = false;
        [SerializeField] bool WhiteKey = false;
        [SerializeField] KeyInventry _keyInventry = null; // Reference to the player's key inventory
        private KeyDoorController doorObject; // Reference to the door controller script

        void Start()
        {
            // If this object is a door, get the KeyDoorController component
            if (RedDoor || BlueDoor || GreenDoor || YellowDoor || PurpleDoor || OrangeDoor || WhiteDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            // Door logic: only open if the matching key is in inventory
            if (RedDoor && _keyInventry.HasRedKey)
                doorObject.PlayAnimation();
            else if (BlueDoor && _keyInventry.HasBlueKey)
                doorObject.PlayAnimation();
            else if (GreenDoor && _keyInventry.HasGreenKey)
                doorObject.PlayAnimation();
            else if (YellowDoor && _keyInventry.HasYellowKey)
                doorObject.PlayAnimation();
            else if (PurpleDoor && _keyInventry.HasPurpleKey)
                doorObject.PlayAnimation();
            else if (OrangeDoor && _keyInventry.HasOrangeKey)
                doorObject.PlayAnimation();
            else if (WhiteDoor && _keyInventry.HasWhiteKey)
                doorObject.PlayAnimation();

            // Key logic: add the correct key to inventory and disable the key object
            else if (RedKey)
            {
                _keyInventry.HasRedKey = true;
                gameObject.SetActive(false); // Hide the key after collection
            }
            else if (BlueKey)
            {
                _keyInventry.HasBlueKey = true;
                gameObject.SetActive(false);
            }
            else if (GreenKey)
            {
                _keyInventry.HasGreenKey = true;
                gameObject.SetActive(false);
            }
            else if (YellowKey)
            {
                _keyInventry.HasYellowKey = true;
                gameObject.SetActive(false);
            }
            else if (PurpleKey)
            {
                _keyInventry.HasPurpleKey = true;
                gameObject.SetActive(false);
            }
            else if (OrangeKey)
            {
                _keyInventry.HasOrangeKey = true;
                gameObject.SetActive(false);
            }
            else if (WhiteKey)
            {
                _keyInventry.HasWhiteKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}