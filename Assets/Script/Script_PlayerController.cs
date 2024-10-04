using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_PlayerController : MonoBehaviour
{
    public static Script_PlayerController Instance; // 싱글톤

    public Transform player;

    [Tooltip("닉네임 텍스트")]
    public TMP_Text nickName;

    [Tooltip("무기 리스트")]
    public GameObject[] weapons;

    [Tooltip("이동 속도")]
    public float speed;

    [Tooltip("현재 장착한 무기 인덱스")]
    private int weaponIndex = 0;

    private  float hAxis;
    private  float vAxis;
    private  Vector3 moveVec;

    private Animator anim;

    private void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Script_UiManager.Instance.currentUIState == Script_UiManager.UIState.Close)
        {
            hAxis = Input.GetAxisRaw("Horizontal");
            vAxis = Input.GetAxisRaw("Vertical");

            moveVec = new Vector3(hAxis, 0, vAxis).normalized;

            transform.position += moveVec * speed * Time.deltaTime;

            if (moveVec != Vector3.zero)
            {
                anim.SetBool("isWalking", true);
                transform.rotation = Quaternion.LookRotation(moveVec);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }

    }

    /// <summary>
    /// 닉네임 변경 버튼 클릭시 실행
    /// </summary>
    /// <param name="newNickName">새로운 닉네임</param>
    public void NickNameChange(string newNickName)
    {
        nickName.text = newNickName;
    }

    /// <summary>
    /// 무기 변경시 실행
    /// </summary>
    /// <param name="index">무기 인덱스</param>
    public void WeaponChange(int index)
    {
        if (weaponIndex == index) return;

        weapons[weaponIndex].SetActive(false);
        weapons[index].SetActive(true);

        weaponIndex = index;
    }
}
