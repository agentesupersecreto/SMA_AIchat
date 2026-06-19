using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000084 RID: 132
	public sealed class Boca : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0000AC63 File Offset: 0x00008E63
		public bool presionEstaAislada
		{
			get
			{
				return this.m_presionEstaAisladaBuffered;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0000AC6B File Offset: 0x00008E6B
		public float aisladoWeight
		{
			get
			{
				return this.m_aisladoWeight;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000393 RID: 915 RVA: 0x0000AC73 File Offset: 0x00008E73
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates1);
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000394 RID: 916 RVA: 0x0000AC7C File Offset: 0x00008E7C
		public List<Collider> allColliders
		{
			get
			{
				return this.m_allColliders;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000395 RID: 917 RVA: 0x0000AC84 File Offset: 0x00008E84
		public BocaHole hole
		{
			get
			{
				if (this.m_hole == null)
				{
					this.m_hole = base.GetComponentInChildren<BocaHole>();
				}
				return this.m_hole;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000396 RID: 918 RVA: 0x0000ACA0 File Offset: 0x00008EA0
		public LabiosChain labios
		{
			get
			{
				if (this.m_labios == null)
				{
					this.m_labios = base.GetComponentInChildren<LabiosChain>();
				}
				return this.m_labios;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000397 RID: 919 RVA: 0x0000ACBC File Offset: 0x00008EBC
		public LabiosSuckPose labiosSuckPose
		{
			get
			{
				if (this.m_LabiosSuckPose == null)
				{
					this.m_LabiosSuckPose = base.GetComponentInChildren<LabiosSuckPose>();
				}
				return this.m_LabiosSuckPose;
			}
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000ACD8 File Offset: 0x00008ED8
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.m_asiladaBuffer.bufferTime = 0.1f;
			this.m_asiladaBuffer.bufferResetTime = 0.025f;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000AD00 File Offset: 0x00008F00
		protected override void AwakeUnityEvent()
		{
			this.m_LabiosSuckPose = base.GetComponent<LabiosSuckPose>();
			if (this.m_LabiosSuckPose == null)
			{
				throw new ArgumentNullException("m_LabiosSuckPose", "m_LabiosSuckPose null reference.");
			}
			this.m_layer = Singleton<ConfiguracionGeneral>.instance.layers.holeExtras;
			this.m_holeLayer = Singleton<ConfiguracionGeneral>.instance.layers.holePrimario;
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = this.m_layer;
			}, true);
			this.hole.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = this.m_holeLayer;
			}, true);
			base.AwakeUnityEvent();
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000AD9C File Offset: 0x00008F9C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_suckWeightAlSellarCalculed = false;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0000ADAC File Offset: 0x00008FAC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!this.hole.isStared)
			{
				this.hole.ManualStart();
			}
			if (this.labios.enabled && !this.labios.isStared)
			{
				this.labios.ManualStart();
			}
			base.GetComponentsInChildren<Collider>(true, this.m_allColliders);
			this.IgnoreAllSelfCollisions();
			this.m_LayerDeCheckAisladaBoca = Singleton<ConfiguracionGeneral>.instance.layers.layerToMaleInteractionAll | this.m_labios.puntos[0].puntoCollider.main.gameObject.layer.ToLayerMask();
			this.m_ignoreAllLayer = Singleton<ConfiguracionGeneral>.instance.layers.ignoreAll;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0000AE64 File Offset: 0x00009064
		public sealed override void OnUpdateEvent1()
		{
			this.UpdateSelladoState();
			bool flag = this.m_presionEstaAisladaFrame != this.m_presionEstaAisladaBuffered;
			float num;
			if (!this.m_asiladaBuffer.IsBuffered(flag, out num))
			{
				this.m_presionEstaAisladaBuffered = this.m_presionEstaAisladaFrame;
			}
			if (!this.m_presionEstaAisladaFrame && !this.m_presionEstaAisladaBuffered)
			{
				this.m_aisladoWeight = 0f;
				return;
			}
			if (this.m_suckWeightAlSellar >= 0f)
			{
				this.m_aisladoWeight = Mathf.Lerp(0.1f, 1f, Mathf.InverseLerp(this.m_suckWeightAlSellar, 1f, this.m_LabiosSuckPose.currentWeight).InPow(2f));
				return;
			}
			this.m_aisladoWeight = 0.1f;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0000AF14 File Offset: 0x00009114
		private void UpdateSelladoState()
		{
			this.m_presionEstaAisladaFrame = this.BocaEstaSellado();
			if (this.m_presionEstaAisladaFrame && !this.m_suckWeightAlSellarCalculed)
			{
				this.m_suckWeightAlSellar = Mathf.Clamp(this.m_LabiosSuckPose.currentWeight, 0f, 0.9999f);
				this.m_suckWeightAlSellarCalculed = true;
			}
			if (!this.m_presionEstaAisladaFrame && !this.m_presionEstaAisladaBuffered)
			{
				this.m_suckWeightAlSellar = -1f;
				this.m_suckWeightAlSellarCalculed = false;
			}
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0000AF88 File Offset: 0x00009188
		public bool BocaEstaSellado()
		{
			IReadOnlyList<LabioPoint> puntos = this.m_labios.puntos;
			int count = puntos.Count;
			bool flag = true;
			for (int i = 0; i < count; i++)
			{
				LabioPointCollider puntoCollider = puntos[i].puntoCollider;
				SphereCollider main = puntoCollider.main;
				int layer = main.gameObject.layer;
				main.gameObject.layer = this.m_ignoreAllLayer;
				bool flag2 = PhysicsCast.CheckCollider(main, puntoCollider.escala, puntoCollider.contactOffset * this.sellamientoCastOffsetMod, this.m_LayerDeCheckAisladaBoca, QueryTriggerInteraction.Ignore);
				main.gameObject.layer = layer;
				if (!flag2)
				{
					flag = false;
					break;
				}
			}
			return flag;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000B025 File Offset: 0x00009225
		public void IgnoreAllSelfCollisions()
		{
			this.m_allColliders.Colisionar(delegate(Collider a, Collider b)
			{
				Physics.IgnoreCollision(a, b);
			});
		}

		// Token: 0x04000215 RID: 533
		[SerializeField]
		[Range(0f, 1f)]
		private float sellamientoCastOffsetMod = 0.425f;

		// Token: 0x04000216 RID: 534
		private BocaHole m_hole;

		// Token: 0x04000217 RID: 535
		private LabiosChain m_labios;

		// Token: 0x04000218 RID: 536
		private List<Collider> m_allColliders = new List<Collider>();

		// Token: 0x04000219 RID: 537
		private LabiosSuckPose m_LabiosSuckPose;

		// Token: 0x0400021A RID: 538
		private int m_layer;

		// Token: 0x0400021B RID: 539
		private int m_holeLayer;

		// Token: 0x0400021C RID: 540
		[SerializeField]
		[ReadOnlyUI]
		private bool m_presionEstaAisladaFrame;

		// Token: 0x0400021D RID: 541
		[SerializeField]
		[ReadOnlyUI]
		private bool m_presionEstaAisladaBuffered;

		// Token: 0x0400021E RID: 542
		[SerializeField]
		[ReadOnlyUI]
		private float m_suckWeightAlSellar = -1f;

		// Token: 0x0400021F RID: 543
		[SerializeField]
		[ReadOnlyUI]
		private bool m_suckWeightAlSellarCalculed;

		// Token: 0x04000220 RID: 544
		[SerializeField]
		[ReadOnlyUI]
		private float m_aisladoWeight;

		// Token: 0x04000221 RID: 545
		[SerializeField]
		private BufferedCoolDown m_asiladaBuffer = new BufferedCoolDown();

		// Token: 0x04000222 RID: 546
		private int m_LayerDeCheckAisladaBoca;

		// Token: 0x04000223 RID: 547
		private int m_ignoreAllLayer;
	}
}
