using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_UiManager : MonoBehaviour
{
    public static Script_UiManager Instance; // 싱글톤
   
    [Tooltip("UI 상태 enum")]
    public enum UIState
    {
        Open,
        Close
    }

    [Tooltip("무기 정보")]
    [System.Serializable]
    public class WeaponsDTO
    {
        public int id;
        public string name;
        public int price;
        public Sprite image;
    }

    [Tooltip("무기 리스트")]
    public List<WeaponsDTO> weapons = new List<WeaponsDTO>();

    [Tooltip("무기 항목 UI")]
    public GameObject prefab;

    [Tooltip("상점 UI 리스트 생성 위치")]
    public Transform spawnPoint;

    [Tooltip("상점 UI")]
    public GameObject store;

    [Tooltip("닉네임 인풋필드 텍스트")]
    public TMP_Text nickName;

    [Tooltip("무기 정보 UI 생성 위치")]
    public Transform parent;

    public UIState currentUIState = UIState.Open;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // 무기 항목 UI 생성
        foreach (WeaponsDTO i in weapons) {
            GameObject weaponUi = Instantiate(prefab);
            weaponUi.transform.SetParent(spawnPoint);
            Script_WeaponsInfo weaponInfo = weaponUi.GetComponent<Script_WeaponsInfo>();
            weaponInfo.id = i.id;
            weaponInfo.name = i.name;
            weaponInfo.price = i.price;
            weaponInfo.image.sprite = i.image;
        }
    }

    /// <summary>
    /// 닉네임 확인 버튼 클릭시 실행
    /// </summary>
    public void OnClick()
    {
        currentUIState = UIState.Close;
        Script_PlayerController.Instance.NickNameChange(nickName.text);
    }

}
