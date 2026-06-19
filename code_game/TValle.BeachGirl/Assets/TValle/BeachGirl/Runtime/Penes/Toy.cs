using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Penes
{
	// Token: 0x0200009B RID: 155
	[RequireComponent(typeof(PenisLinearChain))]
	public class Toy : Penetrador, IPropPeneConPartes, IPeneConPartes, IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple, IPenetrableProp
	{
		// Token: 0x170001DA RID: 474
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x0000EE37 File Offset: 0x0000D037
		public override Renderer mainRenderer
		{
			get
			{
				return this.m_renders.main;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000EE44 File Offset: 0x0000D044
		public override IReadOnlyList<Renderer> allRenderer
		{
			get
			{
				return this.m_renders.all;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0000EE51 File Offset: 0x0000D051
		public override Transform lookAtTarget
		{
			get
			{
				return this.m_skinSurfaceTransform;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000EE59 File Offset: 0x0000D059
		public ModificableDeBool isBlockedOR
		{
			get
			{
				return this.m_isBlockedOR;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000EE61 File Offset: 0x0000D061
		public bool propEstaActivo
		{
			get
			{
				return base.isActiveAndEnabled && (this.m_grabableLogic.estado == GrabbablePropEstado.NotGrabbedButActivated || this.m_grabableLogic.estado == GrabbablePropEstado.Grabbed);
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0000EE8B File Offset: 0x0000D08B
		public Transform baseDeProp
		{
			get
			{
				return this.m_grabableLogic.sensorBase;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0000EE98 File Offset: 0x0000D098
		public float worldRadiusDeBaseDeProp
		{
			get
			{
				return this.m_grabableLogic.sensorBaseWorldRadius;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0000EEA5 File Offset: 0x0000D0A5
		TipoDeProp IPenetrableProp.tipoDeProp
		{
			get
			{
				return this.tipoDeProp;
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0000EEB0 File Offset: 0x0000D0B0
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
			this.m_grabableLogic = base.GetComponentInParent<IGrabableToy>();
			if (this.m_grabableLogic == null)
			{
				throw new ArgumentNullException("m_grabableLogic", "m_grabableLogic null reference.");
			}
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0000F01C File Offset: 0x0000D21C
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

		// Token: 0x060004A8 RID: 1192 RVA: 0x0000F068 File Offset: 0x0000D268
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

		// Token: 0x060004AA RID: 1194 RVA: 0x0000F0ED File Offset: 0x0000D2ED
		bool IPene.get_isDestroyed()
		{
			return base.isDestroyed;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000F0F5 File Offset: 0x0000D2F5
		bool IPene.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0000F0FD File Offset: 0x0000D2FD
		string IPene.get_name()
		{
			return base.name;
		}

		// Token: 0x040002BB RID: 699
		public const float disminucionDeMasa = 10f;

		// Token: 0x040002BC RID: 700
		public const float pointsDistance = 0.02f;

		// Token: 0x040002BD RID: 701
		public TipoDeProp tipoDeProp;

		// Token: 0x040002BE RID: 702
		private List<IPenisBlocker> m_blokers = new List<IPenisBlocker>();

		// Token: 0x040002BF RID: 703
		[ReadOnlyUI]
		[SerializeField]
		private Material[] m_materials;

		// Token: 0x040002C0 RID: 704
		private PenetradorRenderers m_renders;

		// Token: 0x040002C1 RID: 705
		private ModificableDeBool m_isBlockedOR = new ModificableDeBool(false);

		// Token: 0x040002C2 RID: 706
		private IGrabableToy m_grabableLogic;
	}
}
