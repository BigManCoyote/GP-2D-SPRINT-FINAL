using UnityEngine;

public class PlatformUpDown : MonoBehaviour
{
    public float speed = 2f;         // Speed of movement
    public float distance = 5f;      // Total distance from start to end

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPos + new Vector3(0, offset, 0); // Left-right movement
    }
}
