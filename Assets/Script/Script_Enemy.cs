using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    private Transform player;

    [Tooltip("플레이어 추적 반경")]
    public float chaseRadius = 5f;

    [Tooltip("이동 속도")]
    public float moveSpeed = 3f;

    [Tooltip("초기 위치 값")]
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
    /// 플레이어가 범위 안에 들어 왔을 때 실행
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
    /// 플레이어가 범위 밖으로 벗어났을 때 실행
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
