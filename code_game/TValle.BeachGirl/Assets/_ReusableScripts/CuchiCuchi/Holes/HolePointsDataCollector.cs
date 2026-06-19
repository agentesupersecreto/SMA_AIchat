using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes
{
	// Token: 0x020000DA RID: 218
	[RequireComponent(typeof(BoneStretchedChain))]
	public class HolePointsDataCollector : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000847 RID: 2119 RVA: 0x0001A75D File Offset: 0x0001895D
		public sealed override int updateEvent1Index
		{
			get
			{
				return 48;
			}
		}

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x06000848 RID: 2120 RVA: 0x0001A764 File Offset: 0x00018964
		// (remove) Token: 0x06000849 RID: 2121 RVA: 0x0001A79C File Offset: 0x0001899C
		public event Action<HolePointsDataCollector> updated;

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x0001A7D1 File Offset: 0x000189D1
		public BoneStretchedChain hole
		{
			get
			{
				if (this.m_hole != null)
				{
					return this.m_hole;
				}
				this.m_hole = base.GetComponent<BoneStretchedChain>();
				return this.m_hole;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x0001A7FA File Offset: 0x000189FA
		public BoneStretchedChain.EstadoDePuntos estadoActual
		{
			get
			{
				return this.hole.estadoDePuntos;
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x0001A807 File Offset: 0x00018A07
		public HolePointsDataCollector.StepData stepData
		{
			get
			{
				return this.m_StepData;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0001A80F File Offset: 0x00018A0F
		public HolePointsDataCollector.Estado actualAI
		{
			get
			{
				return this.m_ActualAI;
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x0001A817 File Offset: 0x00018A17
		public HolePointsDataCollector.Estado actualReal
		{
			get
			{
				return this.m_ActualReal;
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x0001A81F File Offset: 0x00018A1F
		public float anchuraPromedioAumentante
		{
			get
			{
				return this.m_PromedioAumentanteData.Aperture;
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0001A82C File Offset: 0x00018A2C
		public Vector3 worldOutHoleDirection
		{
			get
			{
				return this.m_worldOutHoleDirection;
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x0001A834 File Offset: 0x00018A34
		public Vector3 worldUpHoleDirection
		{
			get
			{
				return this.m_worldUpHoleDirection;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x0001A83C File Offset: 0x00018A3C
		public Vector3 worldEntradaPosition
		{
			get
			{
				return this.m_worldEntradaPosition;
			}
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0001A844 File Offset: 0x00018A44
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_hole = base.GetComponent<BoneStretchedChain>();
			this.m_StepData = new HolePointsDataCollector.StepData(this);
			if (!this.m_hole.isStared)
			{
				this.m_hole.stared += this.M_Hole_stared;
				return;
			}
			this.M_Hole_stared(this.m_hole);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0001A8A0 File Offset: 0x00018AA0
		private void M_Hole_stared(object obj)
		{
			this.m_estadoPasado = new BoneStretchedChain.EstadoDePuntos(this.m_hole);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0001A8B3 File Offset: 0x00018AB3
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0001A8BC File Offset: 0x00018ABC
		public override void OnUpdateEvent1()
		{
			if (!this.m_hole.isStared)
			{
				return;
			}
			if (this.m_isFirst)
			{
				this.m_isFirst = false;
				this.m_hole.estadoDePuntos.CopiarA(this.m_estadoPasado);
			}
			float deltaTime = Time.deltaTime;
			this.m_ActualAI.LoadAI(this.m_hole);
			this.m_ActualReal.LoadReal(this.m_hole);
			this.m_PromedioData.Promediar(ref this.m_ActualAI, this.m_PromedioDataTotal, deltaTime);
			this.m_PromedioAumentanteData.PromediarAumentante(ref this.m_ActualAI, ref this.m_PromedioData, this.m_PromedioDataTotal, deltaTime);
			this.m_PromedioDataTotal += deltaTime;
			this.m_PromedioDataTotal = Mathf.Clamp(0f, 30f, this.m_PromedioDataTotal);
			this.m_StepData.OnUpdate(deltaTime);
			Action<HolePointsDataCollector> action = this.updated;
			if (action != null)
			{
				action(this);
			}
			this.m_hole.estadoDePuntos.CopiarA(this.m_estadoPasado);
			this.m_worldOutHoleDirection = this.m_hole.worldOutHoleDirection;
			this.m_worldUpHoleDirection = this.m_hole.worldUpHoleDirection;
			this.m_worldEntradaPosition = this.m_hole.entrada.position;
		}

		// Token: 0x0400048F RID: 1167
		private BoneStretchedChain m_hole;

		// Token: 0x04000490 RID: 1168
		[SerializeField]
		private BoneStretchedChain.EstadoDePuntos m_estadoPasado;

		// Token: 0x04000491 RID: 1169
		[SerializeField]
		private HolePointsDataCollector.StepData m_StepData;

		// Token: 0x04000492 RID: 1170
		[SerializeField]
		private HolePointsDataCollector.Estado m_ActualAI;

		// Token: 0x04000493 RID: 1171
		[SerializeField]
		private HolePointsDataCollector.Estado m_ActualReal;

		// Token: 0x04000494 RID: 1172
		[SerializeField]
		private HolePointsDataCollector.Estado m_PromedioData;

		// Token: 0x04000495 RID: 1173
		[SerializeField]
		private HolePointsDataCollector.Estado m_PromedioAumentanteData;

		// Token: 0x04000496 RID: 1174
		[SerializeField]
		private float m_PromedioDataTotal;

		// Token: 0x04000497 RID: 1175
		private Vector3 m_worldOutHoleDirection;

		// Token: 0x04000498 RID: 1176
		private Vector3 m_worldUpHoleDirection;

		// Token: 0x04000499 RID: 1177
		private Vector3 m_worldEntradaPosition;

		// Token: 0x0400049A RID: 1178
		private bool m_isFirst = true;

		// Token: 0x020001B1 RID: 433
		[Serializable]
		public class StepData
		{
			// Token: 0x06000F29 RID: 3881 RVA: 0x00033C47 File Offset: 0x00031E47
			public StepData(HolePointsDataCollector collector)
			{
				if (collector == null)
				{
					throw new ArgumentNullException("collector", "collector null reference.");
				}
				this.m_collector = collector;
			}

			// Token: 0x06000F2A RID: 3882 RVA: 0x00033C70 File Offset: 0x00031E70
			public void OnUpdate(float deltaTime)
			{
				float penetratedDepthLocalInternals = this.m_collector.m_estadoPasado.actualLocal.penetratedDepthLocalInternals;
				try
				{
					this.entrando = this.m_lastDeep < penetratedDepthLocalInternals;
					this.justEntered = this.m_lastDeep <= 0f && penetratedDepthLocalInternals > 0f;
					this.UpdateCenterMovement();
					this.UpdateDeepMovement();
					this.UpdateApertureChange();
					if (deltaTime != 0f)
					{
						this.localCenterVelocity = this.localCenterMovement / deltaTime;
						this.localHoleDeepVelocity = this.localHoleDeepMovement / deltaTime;
						this.localPenisDeepVelocityV2 = this.localPenisDeepMovementV2 / deltaTime;
						this.localApertureVelocity = this.localApertureChange / deltaTime;
					}
					else
					{
						this.localCenterVelocity = (this.localHoleDeepVelocity = (this.localPenisDeepVelocityV2 = (this.localApertureVelocity = 0f)));
					}
				}
				finally
				{
					this.m_lastDeep = penetratedDepthLocalInternals;
				}
			}

			// Token: 0x06000F2B RID: 3883 RVA: 0x00033D54 File Offset: 0x00031F54
			private void UpdateDeepMovement()
			{
				float num = Mathf.Abs(this.m_collector.hole.estadoDePuntos.actualLocal.penetratedDepthLocalInternals - this.m_collector.m_estadoPasado.actualLocal.penetratedDepthLocalInternals);
				this.localHoleDeepMovement = num;
				float num2 = Mathf.Abs(this.m_collector.hole.estadoDePuntos.actualLocal.penisPenetratedDepthLocalInternals - this.m_collector.m_estadoPasado.actualLocal.penisPenetratedDepthLocalInternals);
				this.localPenisDeepMovementV2 = num2;
			}

			// Token: 0x06000F2C RID: 3884 RVA: 0x00033DDC File Offset: 0x00031FDC
			private void UpdateCenterMovement()
			{
				float num = Vector3.Distance(this.m_collector.hole.estadoDePuntos.centroDePuntos.centroLocal, this.m_collector.m_estadoPasado.centroDePuntos.centroLocal);
				this.localCenterMovement = num;
			}

			// Token: 0x06000F2D RID: 3885 RVA: 0x00033E28 File Offset: 0x00032028
			private void UpdateApertureChange()
			{
				float num = Mathf.Abs(this.m_collector.hole.estadoDePuntos.actualLocal.maxLimpiaLocalInternals - this.m_collector.m_estadoPasado.actualLocal.maxLimpiaLocalInternals);
				this.localApertureChange = num;
			}

			// Token: 0x040009BC RID: 2492
			private HolePointsDataCollector m_collector;

			// Token: 0x040009BD RID: 2493
			private float m_lastDeep;

			// Token: 0x040009BE RID: 2494
			public bool entrando;

			// Token: 0x040009BF RID: 2495
			public bool justEntered;

			// Token: 0x040009C0 RID: 2496
			public float localCenterMovement;

			// Token: 0x040009C1 RID: 2497
			public float localHoleDeepMovement;

			// Token: 0x040009C2 RID: 2498
			public float localPenisDeepMovementV2;

			// Token: 0x040009C3 RID: 2499
			public float localApertureChange;

			// Token: 0x040009C4 RID: 2500
			public float localCenterVelocity;

			// Token: 0x040009C5 RID: 2501
			public float localHoleDeepVelocity;

			// Token: 0x040009C6 RID: 2502
			public float localPenisDeepVelocityV2;

			// Token: 0x040009C7 RID: 2503
			public float localApertureVelocity;
		}

		// Token: 0x020001B2 RID: 434
		[Serializable]
		public struct Estado
		{
			// Token: 0x06000F2E RID: 3886 RVA: 0x00033E74 File Offset: 0x00032074
			public void LoadAI(BoneStretchedChain hole)
			{
				this.DeepMovementHole = hole.estadoDePuntos.actualLocal.penetratedDepthLocalInternals;
				this.DeepMovementPenis = hole.estadoDePuntos.actualLocal.penisPenetratedDepthLocalInternals;
				this.Aperture = hole.estadoDePuntos.actualLocal.maxLimpiaLocalInternals;
			}

			// Token: 0x06000F2F RID: 3887 RVA: 0x00033EC4 File Offset: 0x000320C4
			public void LoadReal(BoneStretchedChain hole)
			{
				this.DeepMovementHole = hole.estadoDePuntos.actualLocal.penetratedDepthLocalInternals;
				this.DeepMovementPenis = hole.estadoDePuntos.actualLocal.penisPenetratedDepthLocalInternals;
				this.Aperture = hole.estadoDePuntos.actualLocal.maxLocalInternals;
			}

			// Token: 0x06000F30 RID: 3888 RVA: 0x00033F14 File Offset: 0x00032114
			public void Promediar(ref HolePointsDataCollector.Estado actual, float duracion, float deltaTime)
			{
				if (duracion <= 0f)
				{
					this.DeepMovementHole = actual.DeepMovementHole;
					this.DeepMovementPenis = actual.DeepMovementPenis;
					this.Aperture = actual.Aperture;
					return;
				}
				if (deltaTime <= 0f)
				{
					return;
				}
				float num = deltaTime / duracion;
				this.DeepMovementHole = Mathf.Lerp(this.DeepMovementHole, actual.DeepMovementHole, num);
				this.DeepMovementPenis = Mathf.Lerp(this.DeepMovementPenis, actual.DeepMovementPenis, num);
				this.Aperture = Mathf.Lerp(this.Aperture, actual.Aperture, num);
			}

			// Token: 0x06000F31 RID: 3889 RVA: 0x00033FA4 File Offset: 0x000321A4
			public void PromediarAumentante(ref HolePointsDataCollector.Estado actual, ref HolePointsDataCollector.Estado promedio, float duracion, float deltaTime)
			{
				if (duracion <= 0f)
				{
					promedio.DeepMovementHole = actual.DeepMovementHole;
					promedio.DeepMovementPenis = actual.DeepMovementPenis;
					promedio.Aperture = actual.Aperture;
					return;
				}
				if (deltaTime <= 0f)
				{
					return;
				}
				if (this.DeepMovementHole < promedio.DeepMovementHole)
				{
					this.DeepMovementHole = promedio.DeepMovementHole;
				}
				if (this.DeepMovementPenis < promedio.DeepMovementPenis)
				{
					this.DeepMovementPenis = promedio.DeepMovementPenis;
				}
				if (this.Aperture < promedio.Aperture)
				{
					this.Aperture = promedio.Aperture;
				}
			}

			// Token: 0x040009C8 RID: 2504
			public float DeepMovementHole;

			// Token: 0x040009C9 RID: 2505
			public float DeepMovementPenis;

			// Token: 0x040009CA RID: 2506
			public float Aperture;
		}
	}
}
