using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform ground;

    public float forwardForce = 2700f;
    public float sidewaysForce = 80f;
    public float hoverHeight = 1.4f;
    public float hoverForce = 200f;
    public float tiltAmount = 20f;
    public float tiltSpeed = 5f;

    private float halfWidth;

    void Start()
    {
        halfWidth = ground.localScale.x / 2f;
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (IsAboveGround()) 
        {
            float diff = hoverHeight - rb.position.y;
            rb.AddForce(0, diff * hoverForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        float targetTilt = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            targetTilt = -tiltAmount;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            targetTilt = tiltAmount;
        }

        Quaternion rotation = Quaternion.Euler(0, 0, targetTilt);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, tiltSpeed * Time.deltaTime);

        if (rb.position.y < 0.5f) 
        {
            this.enabled = false;
            FindFirstObjectByType<GameManager>().EndGame();
        }
    }

    private bool IsAboveGround()
    {
        Vector3 groundPosition = ground.position;
        Vector3 playerPosition = transform.position;

        return (
            playerPosition.x >= groundPosition.x - halfWidth &&
            playerPosition.x <= groundPosition.x + halfWidth
            );
    }
}
