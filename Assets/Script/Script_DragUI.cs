using UnityEngine;
using UnityEngine.EventSystems;

public class Script_DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[Tooltip("최상단 부모 오브젝트")]
	private	Transform parentCanvers;

	[Tooltip("현재 부모 오브젝트")]
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
	/// 오브젝트 드래그시 실행
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
	/// 오브젝트를 드래그 중일 때 실행
	/// </summary>
	public void OnDrag(PointerEventData eventData)
	{
		rect.position = eventData.position;
	}

	/// <summary>
	/// 오브젝트 드래그 종료 시 실행
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

