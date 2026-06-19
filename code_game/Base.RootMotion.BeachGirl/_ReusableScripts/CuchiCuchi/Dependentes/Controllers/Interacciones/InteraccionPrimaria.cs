using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000ED RID: 237
	public sealed class InteraccionPrimaria : InteraccionPrimariaBase
	{
		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x0002857F File Offset: 0x0002677F
		protected override bool detenerTodasDelMismoLayer
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x00028582 File Offset: 0x00026782
		public sealed override IInteractionController user
		{
			get
			{
				return this.m_InteractionsController;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x0002858A File Offset: 0x0002678A
		protected override AnimController animController
		{
			get
			{
				return this.m_animController;
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00028594 File Offset: 0x00026794
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteractionsController = this.GetComponentEnRoot(false);
			this.m_animController = this.GetComponentEnRoot(false);
			if (this.m_InteractionsController == null)
			{
				throw new ArgumentNullException("m_InteractionsController", "m_InteractionsController null reference.");
			}
			if (this.m_animController == null)
			{
				throw new ArgumentNullException("m_animController", "m_animController null reference.");
			}
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x000285F7 File Offset: 0x000267F7
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!this.m_datos.isValid)
			{
				Debug.LogWarning(base.name + "_Interaccion, no tiene datos validos");
			}
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00028621 File Offset: 0x00026821
		protected sealed override void DespuesDeDetenerse()
		{
			base.DespuesDeDetenerse();
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00028629 File Offset: 0x00026829
		protected sealed override bool AntesDeDetenerse()
		{
			return true;
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0002862C File Offset: 0x0002682C
		protected override void OnForzada()
		{
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0002862E File Offset: 0x0002682E
		protected sealed override bool OnPuedeEjecutarseConParametros(InteraccionStartParams parametros)
		{
			return true;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00028631 File Offset: 0x00026831
		protected override void JustoAntesDeEjecutarse(ref InteraccionStartParams parametros)
		{
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00028633 File Offset: 0x00026833
		protected sealed override void DespuesDeEjecutarse(InteraccionStartParams parametros)
		{
		}

		// Token: 0x0400059F RID: 1439
		private AnimController m_animController;

		// Token: 0x040005A0 RID: 1440
		private IInteractionController m_InteractionsController;
	}
}
