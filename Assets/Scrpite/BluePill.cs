using UnityEngine;

public class BluePill : MonoBehaviour
{
    [SerializeField] float damage = 1000f;
    private Renderer rend;
    private Color originalColor;
    public void Collect(PlayerBehaviour player)
    {
        // Logic for collecting the blue pill
        Debug.Log("Blue pill collected!");

        // Apply damage to the player
        player.ModifyHealth(-damage);

        Destroy(gameObject); // Destroy the blue pill object
                             // Destroy the blue pill bject

    }
    public void Highlight()
    {
        if (rend != null)
        {
            rend.material.color = Color.yellow;
        } }



    public void Unhighlight()
    {
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }
}

