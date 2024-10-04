using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speedMultiplier = 5f;

    public float powerUpTime = 4f;
    
    void Update()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(30f, 60, 20f) * Time.deltaTime); 
    }

    private IEnumerator DoPowerUp(PlayerMovement playerMovement)
    {
        playerMovement.speedMultiplier = speedMultiplier;

        yield return new WaitForSeconds(powerUpTime);

        playerMovement.speedMultiplier = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.StartCoroutine(DoPowerUp(playerMovement));
            }

            Destroy(gameObject);
        }
    }
}
