using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime
{
	// Token: 0x020000C7 RID: 199
	[RequireComponent(typeof(Button))]
	public class BotonSostenible : CustomMonobehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000598 RID: 1432 RVA: 0x000159CC File Offset: 0x00013BCC
		// (remove) Token: 0x06000599 RID: 1433 RVA: 0x00015A04 File Offset: 0x00013C04
		public event Action sostenido;

		// Token: 0x0600059A RID: 1434 RVA: 0x00015A39 File Offset: 0x00013C39
		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			this.susteniendo = true;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00015A42 File Offset: 0x00013C42
		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			this.susteniendo = false;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00015A4B File Offset: 0x00013C4B
		private void Update()
		{
			if (this.susteniendo)
			{
				Action action = this.sostenido;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x04000222 RID: 546
		public bool susteniendo;
	}
}
