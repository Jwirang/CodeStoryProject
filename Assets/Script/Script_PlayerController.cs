using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_PlayerController : MonoBehaviour
{
    public static Script_PlayerController Instance; // �̱���

    public Transform player;

    [Tooltip("�г��� �ؽ�Ʈ")]
    public TMP_Text nickName;

    [Tooltip("���� ����Ʈ")]
    public GameObject[] weapons;

    [Tooltip("�̵� �ӵ�")]
    public float speed;

    [Tooltip("���� ������ ���� �ε���")]
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
    /// �г��� ���� ��ư Ŭ���� ����
    /// </summary>
    /// <param name="newNickName">���ο� �г���</param>
    public void NickNameChange(string newNickName)
    {
        nickName.text = newNickName;
    }

    /// <summary>
    /// ���� ����� ����
    /// </summary>
    /// <param name="index">���� �ε���</param>
    public void WeaponChange(int index)
    {
        if (weaponIndex == index) return;

        weapons[weaponIndex].SetActive(false);
        weapons[index].SetActive(true);

        weaponIndex = index;
    }
}
