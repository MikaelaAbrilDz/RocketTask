using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoomer : MonoBehaviour
{
    public void OnZoomCam(InputAction.CallbackContext ctx)
    {
        transform.position = transform.position + new Vector3 (0,0,ctx.ReadValue<Vector2>().y * 10);
    }
}
