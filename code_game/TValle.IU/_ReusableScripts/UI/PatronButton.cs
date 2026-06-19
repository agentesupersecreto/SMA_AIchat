using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI
{
	// Token: 0x02000011 RID: 17
	[RequireComponent(typeof(Button))]
	public class PatronButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00002DE1 File Offset: 0x00000FE1
		private void Start()
		{
			base.GetComponent<Button>().onClick.AddListener(new UnityAction(this.PatronClick));
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002DFF File Offset: 0x00000FFF
		private void OnDisable()
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002E0D File Offset: 0x0000100D
		public void PatronClick()
		{
			Application.OpenURL(this.link);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002E1A File Offset: 0x0000101A
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.patronCursor != null)
			{
				Cursor.SetCursor(this.patronCursor, Vector2.zero, CursorMode.Auto);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002E3B File Offset: 0x0000103B
		public void OnPointerExit(PointerEventData eventData)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}

		// Token: 0x0400002B RID: 43
		public Texture2D patronCursor;

		// Token: 0x0400002C RID: 44
		public string link;
	}
}
