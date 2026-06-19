using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x0200008F RID: 143
	[RequireComponent(typeof(LabiosSuckPose))]
	[RequireComponent(typeof(LabiosChainFolloingGuias))]
	public sealed class LabiosChainFolloingGuiasOffsetsController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x0000D131 File Offset: 0x0000B331
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.yieldFixedUpdate2);
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000D13A File Offset: 0x0000B33A
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates3);
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000D143 File Offset: 0x0000B343
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_boca = base.GetComponentInParent<Boca>();
			this.m_LabiosChainFolloingGuias = base.GetComponent<LabiosChainFolloingGuias>();
			this.m_LabiosSuckPose = base.GetComponent<LabiosSuckPose>();
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000D16F File Offset: 0x0000B36F
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_hole = base.GetComponentInChildren<BocaHole>();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000D1A4 File Offset: 0x0000B3A4
		public override void OnUpdateEvent1()
		{
			float num = 0f;
			if (this.m_hole.penetraciones.isPenetratedByAny)
			{
				num = this.m_hole.penetraciones.currentHits.primero.penis.penetratingWorldLength / this.m_hole.worldScaleReal;
			}
			bool presionEstaAislada = this.m_boca.presionEstaAislada;
			this.m_currentWeight = this.m_boca.aisladoWeight;
			try
			{
				float num2 = -1f * (num - this.m_lastDeep) * this.m_currentWeight;
				bool flag = num >= this.m_lastDeep;
				this.m_currentRotationOffset += num2 * (flag ? this.config.sensibilidadRotacionPositiva : this.config.sensibilidadRotacionNegativa);
				this.m_currentRotationOffset = Mathf.Clamp(this.m_currentRotationOffset, this.config.minAngle, this.config.maxAngle);
				float num3 = 1f - MathfExtension.InverseLerpAlMedio(this.config.minAngle, 0f, this.config.maxAngle, this.m_currentRotationOffset);
				num3 = Mathf.Clamp(num3, 0.001f, 1f);
				num3 = num3.OutPow(this.config.powerDeRecuperacionRotacion);
				float num4 = ((num == 0f) ? this.config.velModDeRecuRotPorNoPenetracion : 1f);
				num4 = Mathf.Max(num4, this.m_currentModDeRecuperacionPorSelladoRot);
				this.m_currentRotationOffset = Mathf.MoveTowardsAngle(this.m_currentRotationOffset, 0f, this.config.velDeRecuperacionRotacion * num4 * num3 * Time.fixedDeltaTime);
				this.m_currentForwardOffset += num2 * (flag ? this.config.sensibilidadPosicionPositiva : this.config.sensibilidadPosicionNegativa);
				this.m_currentForwardOffset = Mathf.Clamp(this.m_currentForwardOffset, this.config.minForward, this.config.maxForward);
				float num5 = 1f - MathfExtension.InverseLerpAlMedio(this.config.minForward, 0f, this.config.maxForward, this.m_currentForwardOffset);
				num5 = Mathf.Clamp(num5, 0.001f, 1f);
				num5 = num5.OutPow(this.config.powerDeRecuperacionPosicion);
				float num6 = ((num == 0f) ? this.config.velModDeRecuPosPorNoPenetracion : 1f);
				num6 = Mathf.Max(num6, this.m_currentModDeRecuperacionPorSelladoPos);
				this.m_currentForwardOffset = Mathf.MoveTowardsAngle(this.m_currentForwardOffset, 0f, this.config.velDeRecuperacionPosicion * num6 * num5 * Time.fixedDeltaTime);
			}
			finally
			{
				this.m_lastSelladoState = presionEstaAislada;
				this.m_lastDeep = num;
				if (this.updateLabioRotationOffset)
				{
					this.m_LabiosChainFolloingGuias.localRotationOffset.x = this.m_currentRotationOffset;
				}
				if (this.updateLabioPositionOffset)
				{
					this.m_LabiosChainFolloingGuias.localFromBocaPositionOffset.z = this.m_currentForwardOffset;
				}
			}
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000D49C File Offset: 0x0000B69C
		public override void OnUpdateEvent2()
		{
			try
			{
				bool presionEstaAislada = this.m_boca.presionEstaAislada;
				bool flag = this.m_currentWeight < this.m_lastFrameWeight && ((this.m_lastSelladoState && !presionEstaAislada) || (!this.m_lastSelladoState && !presionEstaAislada));
				this.m_currentModDeRecuperacionPorSelladoRot = (flag ? this.config.velModDeRecuRotPorNoAislada : 1f);
				this.m_currentModDeRecuperacionPorSelladoPos = (flag ? this.config.velModDeRecuPosPorNoAislada : 1f);
			}
			finally
			{
				this.m_lastFrameWeight = this.m_currentWeight;
			}
		}

		// Token: 0x04000264 RID: 612
		public bool updateLabioPositionOffset = true;

		// Token: 0x04000265 RID: 613
		public bool updateLabioRotationOffset = true;

		// Token: 0x04000266 RID: 614
		private LabiosChainFolloingGuias m_LabiosChainFolloingGuias;

		// Token: 0x04000267 RID: 615
		private BocaHole m_hole;

		// Token: 0x04000268 RID: 616
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentRotationOffset;

		// Token: 0x04000269 RID: 617
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentForwardOffset;

		// Token: 0x0400026A RID: 618
		public LabiosChainFolloingGuiasOffsetsController.Config config = new LabiosChainFolloingGuiasOffsetsController.Config();

		// Token: 0x0400026B RID: 619
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastDeep;

		// Token: 0x0400026C RID: 620
		[SerializeField]
		[ReadOnlyUI]
		private bool m_lastSelladoState;

		// Token: 0x0400026D RID: 621
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentWeight;

		// Token: 0x0400026E RID: 622
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentModDeRecuperacionPorSelladoRot;

		// Token: 0x0400026F RID: 623
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentModDeRecuperacionPorSelladoPos;

		// Token: 0x04000270 RID: 624
		private float m_lastFrameWeight;

		// Token: 0x04000271 RID: 625
		private LabiosSuckPose m_LabiosSuckPose;

		// Token: 0x04000272 RID: 626
		private Boca m_boca;

		// Token: 0x02000183 RID: 387
		[Serializable]
		public class Config
		{
			// Token: 0x040008B4 RID: 2228
			public float sensibilidadRotacionNegativa = 1500f;

			// Token: 0x040008B5 RID: 2229
			public float sensibilidadRotacionPositiva = 750f;

			// Token: 0x040008B6 RID: 2230
			public float velDeRecuperacionRotacion = 75f;

			// Token: 0x040008B7 RID: 2231
			[Tooltip("mod de velocidad de recuperacion cuando no hay penetracion")]
			public float velModDeRecuRotPorNoPenetracion = 20f;

			// Token: 0x040008B8 RID: 2232
			[Tooltip("mod de velocidad de recuperacion cuando no hay aislamiento")]
			public float velModDeRecuRotPorNoAislada = 5f;

			// Token: 0x040008B9 RID: 2233
			public float powerDeRecuperacionRotacion = 3f;

			// Token: 0x040008BA RID: 2234
			[Range(-90f, 0f)]
			public float minAngle = -45f;

			// Token: 0x040008BB RID: 2235
			[Range(0f, 90f)]
			public float maxAngle = 60f;

			// Token: 0x040008BC RID: 2236
			public float sensibilidadPosicionNegativa = 0.425f;

			// Token: 0x040008BD RID: 2237
			public float sensibilidadPosicionPositiva = 0.2125f;

			// Token: 0x040008BE RID: 2238
			public float velDeRecuperacionPosicion = 0.02125f;

			// Token: 0x040008BF RID: 2239
			[Tooltip("mod de velocidad de recuperacion cuando no hay penetracion")]
			public float velModDeRecuPosPorNoPenetracion = 20f;

			// Token: 0x040008C0 RID: 2240
			[Tooltip("mod de velocidad de recuperacion cuando no hay aislamiento")]
			public float velModDeRecuPosPorNoAislada = 5f;

			// Token: 0x040008C1 RID: 2241
			public float powerDeRecuperacionPosicion = 3f;

			// Token: 0x040008C2 RID: 2242
			[Range(-0.05f, 0f)]
			public float minForward = -0.003f;

			// Token: 0x040008C3 RID: 2243
			[Range(0f, 0.05f)]
			public float maxForward = 0.015f;
		}
	}
}
