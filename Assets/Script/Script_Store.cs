using UnityEngine;

public class Script_Store : MonoBehaviour
{
    [Tooltip("���� UI")]
    public GameObject shopUI;

    [Tooltip("�κ��丮 UI")]
    public GameObject invantoryUI;

    [Tooltip("���� �ݶ��̴�")]
    public Collider storeCollider;

    private Transform player;

    [Tooltip("���� �ݰ� �ȿ� �ִ��� üũ")]
    private bool isInStoreRadius = false;

    void Start()
    {
        player = Script_PlayerController.Instance.player;
        shopUI.SetActive(false);
        invantoryUI.SetActive(false);
    }

    /// <summary>
    /// �ݶ��̴��� �浹���� �� ����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isInStoreRadius)
            {
                shopUI.SetActive(true);
                invantoryUI.SetActive(true);
                isInStoreRadius = true;
            }
        }
    }

    /// <summary>
    /// �ݶ��̴� ������ �������� ����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isInStoreRadius)
            {
                for (int i = Script_UiManager.Instance.parent.childCount - 1; i >= 0; i--)
                {
                    Destroy(Script_UiManager.Instance.parent.GetChild(i).gameObject);
                }

                shopUI.SetActive(false);
                invantoryUI.SetActive(false);
                isInStoreRadius = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Script_UiManager.Instance.currentUIState == Script_UiManager.UIState.Close) // Ű���� E�� �κ��丮 UI on/off 
        {
            for (int i = Script_UiManager.Instance.parent.childCount - 1; i >= 0; i--)
            {
                Destroy(Script_UiManager.Instance.parent.GetChild(i).gameObject);
            }

            invantoryUI.SetActive(!invantoryUI.activeSelf);
        }
    }
}
