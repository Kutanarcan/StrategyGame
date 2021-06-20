using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera rtsCamera;
    [SerializeField]
    float moveSpeed = 30f;

    CinemachineConfiner rtsCameraConfiner;

    float currentOrthographicSize;

    const float CAMERA_MOVE_MAX_RANGE = 25;
    const float CAMERA_MOVE_MIN_RANGE = -25;

    void Awake()
    {
        rtsCameraConfiner = rtsCamera.GetComponent<CinemachineConfiner>();

        rtsCamera.Priority = 10;

        currentOrthographicSize = rtsCamera.m_Lens.OrthographicSize;
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float x = 0;
        float y = 0;

        float edgeScrollingSize = 50;

        if (Input.mousePosition.x > Screen.width - edgeScrollingSize && transform.position.x < CAMERA_MOVE_MAX_RANGE)
        {
            x = 1f;
        }

        if (Input.mousePosition.x < edgeScrollingSize && transform.position.x > CAMERA_MOVE_MIN_RANGE)
        {
            x = -1f;
        }

        if (Input.mousePosition.y > Screen.height - edgeScrollingSize && transform.position.y < CAMERA_MOVE_MAX_RANGE)
        {
            y = 1f;
        }

        if (Input.mousePosition.y < edgeScrollingSize && transform.position.y > CAMERA_MOVE_MIN_RANGE)
        {
            y = -1f;
        }

        Vector3 moveDir = new Vector3(x, y).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
