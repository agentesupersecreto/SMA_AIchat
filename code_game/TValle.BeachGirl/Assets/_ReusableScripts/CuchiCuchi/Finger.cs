using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000D2 RID: 210
	[RequireComponent(typeof(PenisLinearChain))]
	public sealed class Finger : Penetrador
	{
		// Token: 0x170002FE RID: 766
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x000184D4 File Offset: 0x000166D4
		public override Renderer mainRenderer
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x000184D7 File Offset: 0x000166D7
		public override IReadOnlyList<Renderer> allRenderer
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x000184DA File Offset: 0x000166DA
		public override Transform lookAtTarget
		{
			get
			{
				IFingerLookAtTargetProividor ifingerLookAtTargetProividor = this.m_IFingerLookAtTargetProividor;
				if (!(((ifingerLookAtTargetProividor != null) ? ifingerLookAtTargetProividor.lookAtTarget : null) == null))
				{
					return this.m_IFingerLookAtTargetProividor.lookAtTarget;
				}
				return base.@base.physicBone.transform;
			}
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00018512 File Offset: 0x00016712
		public override bool IsBlocked()
		{
			return false;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00018518 File Offset: 0x00016718
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_IFingerLookAtTargetProividor = base.GetComponent<IFingerLookAtTargetProividor>();
			if (this.m_IFingerLookAtTargetProividor == null)
			{
				Debug.LogWarning("Finger no tiene lookat target provider, se usara el target por defecto", this);
			}
			ModificadorDeMasaDeContactosUser componentNotNull = this.GetComponentNotNull<ModificadorDeMasaDeContactosUser>();
			componentNotNull.InitializedIgnoring(null);
			componentNotNull.GetAgaintsLayerModificable(12).ObtenerModificadorNotNull(this).valor.valor = 0.06666667f;
			componentNotNull.GetAgaintsLayerModificable(14).ObtenerModificadorNotNull(this).valor.valor = 0.006666667f;
			componentNotNull.GetAgaintsLayerModificable(18).ObtenerModificadorNotNull(this).valor.valor = 0.006666667f;
			componentNotNull.GetAgaintsLayerModificable(24).ObtenerModificadorNotNull(this).valor.valor = 0.5f;
		}

		// Token: 0x0400045C RID: 1116
		public const float disminucionDeMasa = 15f;

		// Token: 0x0400045D RID: 1117
		private IFingerLookAtTargetProividor m_IFingerLookAtTargetProividor;
	}
}
