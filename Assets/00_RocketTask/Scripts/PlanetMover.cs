using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity += Vector3.right * speed;
    }
}
