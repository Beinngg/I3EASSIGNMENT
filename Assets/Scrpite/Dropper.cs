/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description:DROP AND DEAL DAMAGE IN A ROOM
*/
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float DropTime = 7f;
    [SerializeField] float damage = 70f;
    MeshRenderer meshRendererr;//define a MeshRenderer variable to control visibility
    Rigidbody rigidBody;//define a Rigidbody variable to control physics
    bool isDropped = false; // Flag to check if the object has been dropped

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        meshRendererr = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();
        meshRendererr.enabled = false; // Set the MeshRenderer to not visible initially
        rigidBody.useGravity = false;
    } // Set the Rigidbody to kinematic initially

    // Update is called once per frame
    void Update()
    {
        if (!isDropped && Time.time >= DropTime)
        {// Reset the drop time for the next drop
            meshRendererr.enabled = true; // Make the MeshRenderer visible
            rigidBody.useGravity = true; // Enable the Rigidbody for physics interactions
            isDropped = true; // Set the flag to true to prevent further drops
        }
    }
    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>();
            if (player != null)
            {
                player.ModifyHealth(-damage * Time.deltaTime);
            }
            else
            {
                Debug.LogWarning("PlayerBehaviour not found on collided object!");
            }
        }
    }
    // In Dropper.cs

}
