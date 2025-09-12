using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float hoverAmplitude = 0.25f;
    public float hoverSpeed = 1f;

    private Vector3 rotationAxis;
    private float randomOffset;
    private float hoverMin = 1.6f;
    private float hoverMax = 1.9f;

    void Start()
    {
        // Randomize speed/offset so asteroids don’t move in sync
        rotationSpeed *= Random.Range(0.7f, 1.3f);
        hoverSpeed *= Random.Range(0.7f, 1.3f);
        randomOffset = Random.Range(0f, Mathf.PI * 2);

        rotationAxis = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

        float t = Mathf.Sin(Time.time * hoverSpeed + randomOffset) * 0.5f + 0.5f;
        float yPos = Mathf.Lerp(hoverMin, hoverMax, t);

        Vector3 pos = transform.position;
        pos.y = yPos;
        transform.position = pos;
    }
}
