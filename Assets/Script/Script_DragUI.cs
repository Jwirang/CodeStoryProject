using UnityEngine;
using UnityEngine.EventSystems;

public class Script_DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[Tooltip("�ֻ�� �θ� ������Ʈ")]
	private	Transform parentCanvers;

	[Tooltip("���� �θ� ������Ʈ")]
	private Transform parent;

	private RectTransform rect;
	private CanvasGroup canvasGroup;

	private void Awake()
	{
		parentCanvers = GameObject.Find("MainUI").transform;
		rect = GetComponent<RectTransform>();
		canvasGroup	= GetComponent<CanvasGroup>();
	}

	/// <summary>
	/// ������Ʈ �巡�׽� ����
	/// </summary>
	public void OnBeginDrag(PointerEventData eventData)
	{
		parent = transform.parent;

		transform.SetParent(parentCanvers);
		transform.SetAsLastSibling();

		canvasGroup.alpha = 0.6f;
		canvasGroup.blocksRaycasts = false;
	}

	/// <summary>
	/// ������Ʈ�� �巡�� ���� �� ����
	/// </summary>
	public void OnDrag(PointerEventData eventData)
	{
		rect.position = eventData.position;
	}

	/// <summary>
	/// ������Ʈ �巡�� ���� �� ����
	/// </summary>
	public void OnEndDrag(PointerEventData eventData)
	{
		if ( transform.parent == parentCanvers )
		{
			transform.SetParent(parent);
			rect.position = parent.GetComponent<RectTransform>().position;
		}

		canvasGroup.alpha = 1.0f;
		canvasGroup.blocksRaycasts = true;
	}
}

