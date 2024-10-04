using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    private Transform player;

    [Tooltip("�÷��̾� ���� �ݰ�")]
    public float chaseRadius = 5f;

    [Tooltip("�̵� �ӵ�")]
    public float moveSpeed = 3f;

    [Tooltip("�ʱ� ��ġ ��")]
    private Vector3 originalPosition;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = Script_PlayerController.Instance.player;
        originalPosition = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= chaseRadius)
        {
            ChasePlayer();
        }
        else
        {
            ReturnToOriginalPosition();
        }
    }

    /// <summary>
    /// �÷��̾ ���� �ȿ� ��� ���� �� ����
    /// </summary>
    private void ChasePlayer()
    {
        anim.SetBool("isRunnig", true);

        Vector3 direction = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    /// <summary>
    /// �÷��̾ ���� ������ ����� �� ����
    /// </summary>
    private void ReturnToOriginalPosition()
    {
        float distance = Vector3.Distance(originalPosition, transform.position);

        if (distance > 0.1f)
        {
            anim.SetBool("isRunnig", true);
           
            Vector3 direction = new Vector3(originalPosition.x - transform.position.x, 0, originalPosition.z - transform.position.z).normalized;

            transform.position += direction * moveSpeed * Time.deltaTime;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        }
        else
        {
            anim.SetBool("isRunnig", false);
        }
    }
}
