using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.UI.Interacciones.Donas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI
{
	// Token: 0x020001BA RID: 442
	public class SitDownIsGreyOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000A96 RID: 2710 RVA: 0x000348CD File Offset: 0x00032ACD
		public bool isGreyOut
		{
			get
			{
				if (this.m_esParaSentarse)
				{
					return this.m_FemaleAnimController.currentRecostableOnRange == null || this.m_FemaleAnimController.animatedPoseID.EsRecostadaAnim();
				}
				return !this.m_FemaleAnimController.animatedPoseID.EsRecostadaAnim();
			}
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x0003490A File Offset: 0x00032B0A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FemaleAnimController = this.GetComponentEnRoot(false);
			if (this.m_FemaleAnimController == null)
			{
				throw new ArgumentNullException("m_FemaleAnimController", "m_FemaleAnimController null reference.");
			}
		}

		// Token: 0x040007FC RID: 2044
		[Tooltip("true para checkear si sentarse es gray out, false para checkear si levantarse de la silal es grayout")]
		[SerializeField]
		private bool m_esParaSentarse;

		// Token: 0x040007FD RID: 2045
		private FemaleAnimController m_FemaleAnimController;
	}
}
