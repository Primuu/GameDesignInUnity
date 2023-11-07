using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchForceMultiplier = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MoveWithCharacterControllerL5 playerScript = other.GetComponent<MoveWithCharacterControllerL5>();

            if (playerScript != null)
            {
                float launchForce = Mathf.Sqrt(playerScript.jumpHeight * -3.0f * playerScript.gravityValue) * launchForceMultiplier;
                
                playerScript.LaunchPlayer(launchForce);
            }
        }
    }
}
