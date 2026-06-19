using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000EE RID: 238
	public sealed class InteraccionSegundaria : InteraccionSegundariaBase
	{
		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x0002863D File Offset: 0x0002683D
		protected override bool detenerTodasDelMismoLayer
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060008D7 RID: 2263 RVA: 0x00028640 File Offset: 0x00026840
		public sealed override IInteractionController user
		{
			get
			{
				return this.interactionsController;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x00028648 File Offset: 0x00026848
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x00028655 File Offset: 0x00026855
		private IInteractionController interactionsController
		{
			get
			{
				return this.m_interactionsController as IInteractionController;
			}
			set
			{
				this.m_interactionsController = value as Object;
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00028663 File Offset: 0x00026863
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!this.m_datos.isValid)
			{
				Debug.LogWarning(base.name + "_Interaccion, no tiene datos validos");
			}
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0002868D File Offset: 0x0002688D
		protected sealed override bool OnPuedeEjecutarseConParametros(InteraccionStartParams parametros)
		{
			this.interactionsController = this.GetComponentEnRoot(false);
			return this.interactionsController != null;
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x000286A7 File Offset: 0x000268A7
		protected override void OnForzada()
		{
			if (this.interactionsController == null)
			{
				this.interactionsController = this.GetComponentEnRoot(false);
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x000286C0 File Offset: 0x000268C0
		protected override void JustoAntesDeEjecutarse(ref InteraccionStartParams parametros)
		{
			for (int i = 0; i < this.m_detenerAntesDeEjecutar.Count; i++)
			{
				InteraccionSegundaria interaccionSegundaria = this.m_detenerAntesDeEjecutar[i];
				if (!(interaccionSegundaria == this) && interaccionSegundaria.ejecutandose)
				{
					interaccionSegundaria.Detener(false);
				}
			}
			base.FolloweOwnerCharacterPose(this.followScalePose);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00028714 File Offset: 0x00026914
		protected sealed override void DespuesDeEjecutarse(InteraccionStartParams parametros)
		{
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00028716 File Offset: 0x00026916
		protected sealed override bool AntesDeDetenerse()
		{
			if (this.interactionsController == null)
			{
				this.interactionsController = this.GetComponentEnRoot(false);
			}
			return this.interactionsController != null;
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00028736 File Offset: 0x00026936
		protected sealed override void DespuesDeDetenerse()
		{
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00028738 File Offset: 0x00026938
		protected sealed override void Comienza()
		{
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x0002873A File Offset: 0x0002693A
		protected sealed override void Termina()
		{
		}

		// Token: 0x040005A1 RID: 1441
		[SerializeField]
		[CoolArrayItem]
		private List<InteraccionSegundaria> m_detenerAntesDeEjecutar = new List<InteraccionSegundaria>();

		// Token: 0x040005A2 RID: 1442
		[ConstraintType(typeof(IInteractionController), true)]
		[SerializeField]
		private Object m_interactionsController;
	}
}
