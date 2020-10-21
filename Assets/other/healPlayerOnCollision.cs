using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// works for rigidbody + box collider
public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update

    public AlienController playerHealth;

    void heal(float health)
    {
        playerHealth.currentHealth += health;
        playerHealth.healthBar.SetHealth(playerHealth.currentHealth);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BaseAlien")
        {
            Destroy(gameObject);
            Debug.Log("healing");
            heal(10f);
        }
    }
}
