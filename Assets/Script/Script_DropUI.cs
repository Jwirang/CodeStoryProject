using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_DropUI : MonoBehaviour, IDropHandler
{
	private	Image image;
	private	RectTransform rect;

	private void Awake()
	{
		image = GetComponent<Image>();
		rect = GetComponent<RectTransform>();
	}

	/// <summary>
	/// 오브젝트 호버 후 드롭시 실행
	/// </summary>
	public void OnDrop(PointerEventData eventData)
	{
		if (image.transform.childCount != 0) return; //이미 드롭 된 오브젝트가 있으니 return

		if ( eventData.pointerDrag != null )
		{
			eventData.pointerDrag.transform.SetParent(transform);
			eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
		}
	}
}

