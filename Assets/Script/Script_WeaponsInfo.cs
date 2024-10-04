using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Script_WeaponsInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Script_WeaponsInfo Instance; // �̱���

    [Tooltip("���� ��ȣ")]
    public int id;

    [Tooltip("���� �̸�")]
    public string name;

    [Tooltip("���� ����")]
    public int price;

    [Tooltip("���� �̹���")]
    public Image image;

    [Tooltip("���� ���� UI ������")]
    public GameObject weaponInfo;

    [Tooltip("������ ���� ���� ������")]
    public GameObject instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// ���콺 ȣ���� ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        Script_WeaponsUi weaponsUi = weaponInfo.GetComponent<Script_WeaponsUi>();
        weaponsUi.name.text = "�̸�: " + name;
        weaponsUi.price.text = "$: " + price.ToString();
        weaponsUi.spriteImage.sprite = image.sprite;
        instance = Instantiate(weaponInfo, gameObject.transform.position + new Vector3(80, -80 , 0), gameObject.transform.rotation);
        instance.transform.SetParent(Script_UiManager.Instance.parent);
    }

    /// <summary>
    /// ���콺 ȣ�� ����� ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(instance);
    }

}
