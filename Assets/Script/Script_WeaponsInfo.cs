using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Script_WeaponsInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Script_WeaponsInfo Instance; // 싱글톤

    [Tooltip("무기 번호")]
    public int id;

    [Tooltip("무기 이름")]
    public string name;

    [Tooltip("무기 가격")]
    public int price;

    [Tooltip("무기 이미지")]
    public Image image;

    [Tooltip("무기 정보 UI 프리팹")]
    public GameObject weaponInfo;

    [Tooltip("생성된 무기 정보 프리팹")]
    public GameObject instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 마우스 호버시 실행
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        Script_WeaponsUi weaponsUi = weaponInfo.GetComponent<Script_WeaponsUi>();
        weaponsUi.name.text = "이름: " + name;
        weaponsUi.price.text = "$: " + price.ToString();
        weaponsUi.spriteImage.sprite = image.sprite;
        instance = Instantiate(weaponInfo, gameObject.transform.position + new Vector3(80, -80 , 0), gameObject.transform.rotation);
        instance.transform.SetParent(Script_UiManager.Instance.parent);
    }

    /// <summary>
    /// 마우스 호버 종료시 실행
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(instance);
    }

}
