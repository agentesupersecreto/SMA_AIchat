using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.TValle.IU.Runtime
{
	// Token: 0x020000CA RID: 202
	public class PointerHandlerBroadcaster : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060005AF RID: 1455 RVA: 0x00015CED File Offset: 0x00013EED
		public bool inside
		{
			get
			{
				return this.m_inside;
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00015CF5 File Offset: 0x00013EF5
		public void AddListiner(IPointerEnterHandler listiner)
		{
			this.m_EnterListiners.Add(listiner);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00015D03 File Offset: 0x00013F03
		public void AddListiner(IPointerExitHandler listiner)
		{
			this.m_ExitListiners.Add(listiner);
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00015D11 File Offset: 0x00013F11
		public void RemoveListiner(IPointerEnterHandler listiner)
		{
			this.m_EnterListiners.Remove(listiner);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00015D20 File Offset: 0x00013F20
		public void RemoveListiner(IPointerExitHandler listiner)
		{
			this.m_ExitListiners.Remove(listiner);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00015D30 File Offset: 0x00013F30
		public void OnPointerEnter(PointerEventData eventData)
		{
			this.m_inside = true;
			for (int i = 0; i < this.m_EnterListiners.Count; i++)
			{
				IPointerEnterHandler pointerEnterHandler = this.m_EnterListiners[i];
				if (pointerEnterHandler != null)
				{
					pointerEnterHandler.OnPointerEnter(eventData);
				}
			}
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00015D74 File Offset: 0x00013F74
		public void OnPointerExit(PointerEventData eventData)
		{
			this.m_inside = false;
			for (int i = 0; i < this.m_ExitListiners.Count; i++)
			{
				IPointerExitHandler pointerExitHandler = this.m_ExitListiners[i];
				if (pointerExitHandler != null)
				{
					pointerExitHandler.OnPointerExit(eventData);
				}
			}
		}

		// Token: 0x0400022E RID: 558
		[SerializeField]
		[ReadOnlyUI]
		private bool m_inside;

		// Token: 0x0400022F RID: 559
		[SerializeField]
		[ReadOnlyUI]
		private List<IPointerEnterHandler> m_EnterListiners = new List<IPointerEnterHandler>();

		// Token: 0x04000230 RID: 560
		[SerializeField]
		[ReadOnlyUI]
		private List<IPointerExitHandler> m_ExitListiners = new List<IPointerExitHandler>();
	}
}
