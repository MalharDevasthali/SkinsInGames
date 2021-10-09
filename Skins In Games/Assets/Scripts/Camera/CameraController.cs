
using UnityEngine;
using Commons;
//using Cinemachine;

public class CameraController : GenericMonoSingleton<CameraController>
{
    // private CinemachineVirtualCamera virtualCamera;
    private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    private bool hasTargetSet = false;

    protected override void Awake()
    {
        base.Awake();
        // virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void SetTarget(Transform _taregt)
    {
        //  virtualCamera.Follow = taregt;
        target = _taregt;
        hasTargetSet = true;
    }
    private void FixedUpdate()
    {
        if (hasTargetSet && target != null)
        {
            Vector3 disiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, disiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
