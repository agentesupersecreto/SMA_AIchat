using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen.Heredacion
{
	// Token: 0x02000069 RID: 105
	[RequireComponent(typeof(ControlladorDeGuiasDeInteraccionDeRopa))]
	public class AdderDeListinersDeGuiaInteractableDeRopaParaHeredarSemen : CustomMonobehaviour
	{
		// Token: 0x06000264 RID: 612 RVA: 0x00011380 File Offset: 0x0000F580
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControlladorDeGuiasDeInteraccionDeRopa = base.GetComponent<ControlladorDeGuiasDeInteraccionDeRopa>();
			if (!this.m_ControlladorDeGuiasDeInteraccionDeRopa.isAwaken)
			{
				this.m_ControlladorDeGuiasDeInteraccionDeRopa.ManualAwake();
			}
			for (int i = 0; i < this.m_ControlladorDeGuiasDeInteraccionDeRopa.guias.Count; i++)
			{
				this.m_ControlladorDeGuiasDeInteraccionDeRopa.guias[i].GetComponentNotNull<ListinersDeGuiaInteractableDeRopaParaHeredarSemen>();
			}
		}

		// Token: 0x0400029C RID: 668
		private ControlladorDeGuiasDeInteraccionDeRopa m_ControlladorDeGuiasDeInteraccionDeRopa;
	}
}
