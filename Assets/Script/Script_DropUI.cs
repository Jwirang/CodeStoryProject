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
	/// ������Ʈ ȣ�� �� ��ӽ� ����
	/// </summary>
	public void OnDrop(PointerEventData eventData)
	{
		if (image.transform.childCount != 0) return; //�̹� ��� �� ������Ʈ�� ������ return

		if ( eventData.pointerDrag != null )
		{
			eventData.pointerDrag.transform.SetParent(transform);
			eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
		}
	}
}

