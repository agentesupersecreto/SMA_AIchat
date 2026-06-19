using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.UI
{
	// Token: 0x02000061 RID: 97
	[RequireComponent(typeof(Canvas))]
	public class SetMainCharCameraToCanvas : CustomMonobehaviour
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x00003DE0 File Offset: 0x00001FE0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00003DEE File Offset: 0x00001FEE
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_Canvas = base.GetComponent<Canvas>();
			for (;;)
			{
				CurrentMainChar instance = Singleton<CurrentMainChar>.instance;
				Object @object;
				if (instance == null)
				{
					@object = null;
				}
				else
				{
					CurrentMainChar.ICamera camara = instance.camara;
					@object = ((camara != null) ? camara.camara : null);
				}
				if (!(@object == null))
				{
					break;
				}
				yield return null;
			}
			this.SetCameraToCanvas();
			yield break;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00003DFD File Offset: 0x00001FFD
		public void SetCameraToCanvas()
		{
			this.m_Canvas.worldCamera = Singleton<CurrentMainChar>.instance.camara.camara;
		}

		// Token: 0x04000117 RID: 279
		private Canvas m_Canvas;
	}
}
