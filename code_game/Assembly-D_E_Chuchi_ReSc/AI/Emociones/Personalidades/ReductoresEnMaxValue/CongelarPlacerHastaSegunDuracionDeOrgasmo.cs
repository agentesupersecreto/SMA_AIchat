using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Personalidades.ReductoresEnMaxValue
{
	// Token: 0x0200042A RID: 1066
	[RequireComponent(typeof(ReductorDeEmocionValueEnMaxEmocionValue))]
	public class CongelarPlacerHastaSegunDuracionDeOrgasmo : CustomMonobehaviour
	{
		// Token: 0x060017C6 RID: 6086 RVA: 0x00060230 File Offset: 0x0005E430
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_reductor = base.GetComponent<ReductorDeEmocionValueEnMaxEmocionValue>();
			this.m_DuracionDeOrgasmo = this.GetComponentEnRoot(false);
			if (this.m_DuracionDeOrgasmo == null)
			{
				throw new ArgumentNullException("m_DuracionDeOrgasmo", "m_DuracionDeOrgasmo null reference.");
			}
		}

		// Token: 0x060017C7 RID: 6087 RVA: 0x00060269 File Offset: 0x0005E469
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_reductor.congelandoEmocion += this.M_reductor_congelandoEmocion;
		}

		// Token: 0x060017C8 RID: 6088 RVA: 0x00060288 File Offset: 0x0005E488
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_reductor != null)
			{
				this.m_reductor.congelandoEmocion -= this.M_reductor_congelandoEmocion;
			}
		}

		// Token: 0x060017C9 RID: 6089 RVA: 0x000602B6 File Offset: 0x0005E4B6
		private void M_reductor_congelandoEmocion(object obj)
		{
			this.m_reductor.congelarPorTiempo = this.m_DuracionDeOrgasmo.currentDuracionTotalDeOrgasmo * 1.25f;
		}

		// Token: 0x04001226 RID: 4646
		private ReductorDeEmocionValueEnMaxEmocionValue m_reductor;

		// Token: 0x04001227 RID: 4647
		private IDuracionDeOrgasmo m_DuracionDeOrgasmo;
	}
}
