using UnityEngine;

public class Hammer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] int damage = 5;

    void Update()
    {
        transform.Rotate(0,0, rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>();
            if (player != null)
            {
                player.ModifyHealth(-damage * Time.deltaTime); // Damage over time
            }
        }
    }
}

