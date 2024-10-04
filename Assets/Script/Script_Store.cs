using UnityEngine;

public class Script_Store : MonoBehaviour
{
    [Tooltip("상점 UI")]
    public GameObject shopUI;

    [Tooltip("인벤토리 UI")]
    public GameObject invantoryUI;

    [Tooltip("상점 콜라이더")]
    public Collider storeCollider;

    private Transform player;

    [Tooltip("현재 반경 안에 있는지 체크")]
    private bool isInStoreRadius = false;

    void Start()
    {
        player = Script_PlayerController.Instance.player;
        shopUI.SetActive(false);
        invantoryUI.SetActive(false);
    }

    /// <summary>
    /// 콜라이더에 충돌했을 때 실행
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
    /// 콜라이더 밖으로 나갔을때 실행
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
        if (Input.GetKeyDown(KeyCode.E) && Script_UiManager.Instance.currentUIState == Script_UiManager.UIState.Close) // 키보드 E로 인벤토리 UI on/off 
        {
            for (int i = Script_UiManager.Instance.parent.childCount - 1; i >= 0; i--)
            {
                Destroy(Script_UiManager.Instance.parent.GetChild(i).gameObject);
            }

            invantoryUI.SetActive(!invantoryUI.activeSelf);
        }
    }
}
