using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200047B RID: 1147
	public abstract class CalculoDeEstimuloEnFrame<TConfig, TEstimuloEnFrameCollecor> : CalculoDeEstimuloEnFrame<TConfig> where TConfig : new() where TEstimuloEnFrameCollecor : MonoBehaviour
	{
		// Token: 0x06001951 RID: 6481 RVA: 0x0006730B File Offset: 0x0006550B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Emo.stared += this.Emo_stared;
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x0006732A File Offset: 0x0006552A
		private void Emo_stared(object obj)
		{
			this.m_EstimuloByMainInFrame = ((Emocion)obj).owner.owner.GetComponentInChildren<TEstimuloEnFrameCollecor>();
			if (this.m_EstimuloByMainInFrame == null)
			{
				throw new ArgumentNullException("m_TouchesInFrame", "m_TouchesInFrame null reference.");
			}
		}

		// Token: 0x0400131B RID: 4891
		protected TEstimuloEnFrameCollecor m_EstimuloByMainInFrame;
	}
}
