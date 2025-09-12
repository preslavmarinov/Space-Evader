using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public ParticleSystem thrusterParticles;

   void OnCollisionEnter(Collision colliderInfo)
    {
        if (colliderInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;

            if (thrusterParticles != null) 
            {
                thrusterParticles.Stop();
            }

            FindFirstObjectByType<GameManager>().EndGame();
        }
    }
}
