using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands;
using Assets._ReusableScripts.UI.Interacciones.Donas;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem
{
	// Token: 0x0200009D RID: 157
	public class HandjobActionIsGrayOut : CustomMonobehaviour, ICheckerIsGreyOut
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x000228D9 File Offset: 0x00020AD9
		public bool isGreyOut
		{
			get
			{
				if (this.m_HandJobController == null)
				{
					return true;
				}
				if (this.m_HandJobController.currentStado.FirstOrDefaultEjecutandose() == null)
				{
					return this.m_isGreyOutWhenThereIsNoOrder;
				}
				return !this.m_isGreyOutWhenThereIsNoOrder;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0002290D File Offset: 0x00020B0D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_HandJobController = this.GetComponentEnRoot(false);
			if (this.m_HandJobController == null)
			{
				throw new ArgumentNullException("m_HandJobController", "m_HandJobController null reference.");
			}
		}

		// Token: 0x040003BB RID: 955
		private HandJobController m_HandJobController;

		// Token: 0x040003BC RID: 956
		[SerializeField]
		private bool m_isGreyOutWhenThereIsNoOrder;
	}
}
