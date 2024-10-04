using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_UiManager : MonoBehaviour
{
    public static Script_UiManager Instance; // �̱���
   
    [Tooltip("UI ���� enum")]
    public enum UIState
    {
        Open,
        Close
    }

    [Tooltip("���� ����")]
    [System.Serializable]
    public class WeaponsDTO
    {
        public int id;
        public string name;
        public int price;
        public Sprite image;
    }

    [Tooltip("���� ����Ʈ")]
    public List<WeaponsDTO> weapons = new List<WeaponsDTO>();

    [Tooltip("���� �׸� UI")]
    public GameObject prefab;

    [Tooltip("���� UI ����Ʈ ���� ��ġ")]
    public Transform spawnPoint;

    [Tooltip("���� UI")]
    public GameObject store;

    [Tooltip("�г��� ��ǲ�ʵ� �ؽ�Ʈ")]
    public TMP_Text nickName;

    [Tooltip("���� ���� UI ���� ��ġ")]
    public Transform parent;

    public UIState currentUIState = UIState.Open;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // ���� �׸� UI ����
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
    /// �г��� Ȯ�� ��ư Ŭ���� ����
    /// </summary>
    public void OnClick()
    {
        currentUIState = UIState.Close;
        Script_PlayerController.Instance.NickNameChange(nickName.text);
    }

}
