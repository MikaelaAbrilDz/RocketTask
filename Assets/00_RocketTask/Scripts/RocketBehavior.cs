using UnityEngine;
using UnityEngine.InputSystem;

public class RocketBehavior : MonoBehaviour
{
    Rigidbody rb;
    LineRenderer lineRenderer;
    bool isBursting;
    [SerializeField] float burstPower;
    float rocketMass;

    [SerializeField] Transform planetTransform;

    Vector3 burst = Vector3.zero;
    Vector3 gravity = Vector3.zero;
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

        gravity = (transform.position - planetTransform.position) * ((rocketMass * planetTransform.gameObject.GetComponent<Rigidbody>().mass) / Mathf.Pow((planetTransform.position - transform.position).magnitude, 2));
        if (isBursting) burst = transform.up * burstPower;
        else burst = Vector3.zero;

    }
    private void FixedUpdate()
    {
        rb.AddForce(burst - gravity, ForceMode.Force);
    }
    public void OnBurst(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) isBursting = true;
        else if (ctx.canceled) isBursting = false;
    }
}
