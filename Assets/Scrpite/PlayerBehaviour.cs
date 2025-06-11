using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    float CurrentHealth = 100f;

    public void ModifyHealth(float amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth <= 0)
        {
            Debug.Log("Player is dead");
        }
        else
        {
            Debug.Log("Player is alive " + CurrentHealth);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Hit")==true)
        {
            Debug.Log("Player hit by enemy");
            other.gameObject.GetComponent<HitBehaviour>().TakeDamage(this); // Assuming HitBehaviour has a TakeDamage method
        }
    }
}

