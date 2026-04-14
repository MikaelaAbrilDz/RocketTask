using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    Rigidbody rb;
    LineRenderer lineRenderer;
    [SerializeField] bool isBursting;
    [SerializeField] float burstPower;
    float rocketMass;

    [SerializeField] Transform planetTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        rocketMass= rb.mass;
    }

    void Update()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);

        Vector3 gravity = (transform.position - planetTransform.position) * ((rocketMass * 25) / Mathf.Pow((planetTransform.position - transform.position).magnitude, 2));
        Vector3 burst;
        if (isBursting) burst = transform.up * burstPower;
        else burst = Vector3.zero;

        rb.AddForce(burst - gravity, ForceMode.Force);
    }
}
