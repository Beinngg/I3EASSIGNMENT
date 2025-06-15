using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] int damage = 5;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnCollisionStay(Collision other)
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