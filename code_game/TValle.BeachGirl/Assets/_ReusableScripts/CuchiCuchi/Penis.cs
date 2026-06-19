using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000D5 RID: 213
	[RequireComponent(typeof(PenisLinearChain))]
	public sealed class Penis : Penetrador
	{
		// Token: 0x17000304 RID: 772
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x000185EA File Offset: 0x000167EA
		public override Renderer mainRenderer
		{
			get
			{
				return this.m_renders.main;
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x000185F7 File Offset: 0x000167F7
		public override IReadOnlyList<Renderer> allRenderer
		{
			get
			{
				return this.m_renders.all;
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x00018604 File Offset: 0x00016804
		public override Transform lookAtTarget
		{
			get
			{
				return this.m_skinSurfaceTransform;
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0001860C File Offset: 0x0001680C
		public ModificableDeBool isBlockedOR
		{
			get
			{
				return this.m_isBlockedOR;
			}
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x00018614 File Offset: 0x00016814
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_inmediateOwner.GetComponentsInChildren<IPenisBlocker>(this.m_blokers);
			if (this.m_blokers.Count == 0)
			{
				Debug.LogWarning("Ningun blokeador de pene ha sido encontrado", this);
			}
			Transform transform = base.penisLinearChain.skeletonRoot.parent;
			if (transform == null)
			{
				transform = base.penisLinearChain.skeletonRoot;
			}
			this.m_renders = transform.GetComponentInChildren<PenetradorRenderers>();
			if (this.m_renders == null)
			{
				throw new ArgumentNullException("m_renders", "m_renders null reference.");
			}
			IReadOnlyList<Renderer> allRenderer = this.allRenderer;
			Material[] array;
			if (allRenderer == null)
			{
				array = null;
			}
			else
			{
				array = allRenderer.SelectMany((Renderer r) => r.materials).ToArray<Material>();
			}
			this.m_materials = array;
			ModificadorDeMasaDeContactosUser componentNotNull = this.GetComponentNotNull<ModificadorDeMasaDeContactosUser>();
			componentNotNull.InitializedIgnoring(null);
			componentNotNull.GetAgaintsLayerModificable(12).ObtenerModificadorNotNull(this).valor.valor = 0.1f;
			componentNotNull.GetAgaintsLayerModificable(14).ObtenerModificadorNotNull(this).valor.valor = 0.2f;
			componentNotNull.GetAgaintsLayerModificable(18).ObtenerModificadorNotNull(this).valor.valor = 0.2f;
			componentNotNull.GetAgaintsLayerModificable(24).ObtenerModificadorNotNull(this).valor.valor = 0.33333334f;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0001875C File Offset: 0x0001695C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_materials != null)
			{
				for (int i = 0; i < this.m_materials.Length; i++)
				{
					if (this.m_materials[i] != null)
					{
						Object.Destroy(this.m_materials[i]);
					}
				}
			}
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x000187A8 File Offset: 0x000169A8
		public override void OnUpdateEvent1()
		{
			base.OnUpdateEvent1();
			float num = MathfExtension.InverseLerpConMedio(0.2f, 1f, 5f, this.m_largo);
			num = MathfExtension.LerpConMedio(0.333f, 1f, 2f, num);
			base.penisLinearChain.FixUnderSkinPenetrationProyection(this.m_skinSurfaceTransform, num);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00018800 File Offset: 0x00016A00
		public override bool IsBlocked()
		{
			bool flag = false;
			for (int i = 0; i < this.m_blokers.Count; i++)
			{
				IPenisBlocker penisBlocker = this.m_blokers[i];
				if (((penisBlocker != null) ? new bool?(penisBlocker.blocked) : null).GetValueOrDefault())
				{
					flag = true;
					break;
				}
			}
			return this.m_isBlockedOR.Or(flag);
		}

		// Token: 0x04000460 RID: 1120
		public const float disminucionDeMasa = 10f;

		// Token: 0x04000461 RID: 1121
		public const float pointsDistance = 0.02f;

		// Token: 0x04000462 RID: 1122
		private List<IPenisBlocker> m_blokers = new List<IPenisBlocker>();

		// Token: 0x04000463 RID: 1123
		[ReadOnlyUI]
		[SerializeField]
		private Material[] m_materials;

		// Token: 0x04000464 RID: 1124
		private PenetradorRenderers m_renders;

		// Token: 0x04000465 RID: 1125
		private ModificableDeBool m_isBlockedOR = new ModificableDeBool(false);
	}
}
