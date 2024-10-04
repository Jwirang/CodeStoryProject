using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ChangeWeapons : MonoBehaviour
{
    /// <summary>
    /// 무기 UI 오브젝트 클릭시 실행
    /// </summary>
    public void OnClick() 
    {
        Script_WeaponsInfo weaponsInfo = GetComponentInChildren<Script_WeaponsInfo>();

        if (weaponsInfo == null) return;

        if (Script_UiManager.Instance.store.activeSelf == true)
        {
            weaponsInfo.gameObject.transform.SetParent(Script_UiManager.Instance.spawnPoint);
        }
        else {
            Script_PlayerController.Instance.WeaponChange(weaponsInfo.id);
        }

    }
}
