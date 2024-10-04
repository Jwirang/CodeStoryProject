using UnityEngine;

public class Script_Camera : MonoBehaviour
{
    [Tooltip("ī�޶�� �÷��̾� ���� ��")]
    private Vector3 offset;

    [Tooltip("ī�޶� �̵� �ӵ�")]
    public float smoothSpeed = 0.125f;

    private Transform player;

    void Start()
    {
        player = Script_PlayerController.Instance.player;
        offset = new Vector3(0, 2, -4);
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(player.position + Vector3.up);
    }
}
