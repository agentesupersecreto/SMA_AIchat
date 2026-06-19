using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas;
using Assets._ReusableScripts.Globales.Updater;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals
{
	// Token: 0x0200019D RID: 413
	public class HoleInternalPointsSolver : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060009CC RID: 2508 RVA: 0x0002BB8C File Offset: 0x00029D8C
		public sealed override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.yieldFixedUpdate1);
			}
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0002BB95 File Offset: 0x00029D95
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_sistema = this.GetComponentNotNull<SistemaLocalDePuntosElasticosDeInternal>();
			this.m_sistema.FastInitiate();
			this.m_sistema.OnIteration += this.M_sistema_OnIteration;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0002BBCB File Offset: 0x00029DCB
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_sistema != null)
			{
				this.m_sistema.OnIteration -= this.M_sistema_OnIteration;
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0002BBFC File Offset: 0x00029DFC
		public void Add(HoleInternal user)
		{
			if (!base.isAwaken)
			{
				throw new InvalidOperationException();
			}
			this.m_users.Add(user);
			for (int i = 0; i < user.elasticPuntos.Count; i++)
			{
				HoleInternal.ElasticInternalPoint elasticInternalPoint = user.elasticPuntos[i];
				this.m_allPoints.Add(elasticInternalPoint);
				this.m_sistema.AddUser(elasticInternalPoint);
			}
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0002BC60 File Offset: 0x00029E60
		public void Remove(HoleInternal user)
		{
			if (!base.isAwaken)
			{
				throw new InvalidOperationException();
			}
			this.m_users.Remove(user);
			foreach (HoleInternal.ElasticInternalPoint elasticInternalPoint in user.elasticPuntos)
			{
				this.m_allPoints.Remove(elasticInternalPoint);
			}
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0002BCD0 File Offset: 0x00029ED0
		public override void OnUpdateEvent1()
		{
			for (int i = 0; i < this.m_users.Count; i++)
			{
				this.m_users[i].PreSolving();
			}
			this.SystemSolve();
			for (int j = 0; j < this.m_users.Count; j++)
			{
				this.m_users[j].PostSolve();
			}
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0002BD34 File Offset: 0x00029F34
		private void SystemSolve()
		{
			for (int i = 0; i < this.m_users.Count; i++)
			{
				this.m_users[i].SolvePuntoPenetration();
			}
			this.m_sistema.ScheduleAndCompleteIterations();
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0002BD74 File Offset: 0x00029F74
		private void M_sistema_OnIteration()
		{
			for (int i = 0; i < this.m_users.Count; i++)
			{
				this.m_users[i].SolveElasticPuntoPenetration(this.m_sistema.configElastic.loops);
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0002BDB8 File Offset: 0x00029FB8
		[Obsolete]
		private void Solve()
		{
			for (int i = 0; i < this.m_users.Count; i++)
			{
				this.m_users[i].SolvePuntoPenetration();
			}
			for (int j = 0; j < this.configElastic.loops; j++)
			{
				this.Loop(this.configElastic.loops);
			}
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0002BE14 File Offset: 0x0002A014
		private void Loop(int loopsTotalCount)
		{
			this.m_allPoints.Shuffle<HoleInternal.ElasticInternalPoint>();
			for (int i = 0; i < this.m_allPoints.Count; i++)
			{
				HoleInternal.ElasticInternalPoint elasticInternalPoint = this.m_allPoints[i];
				elasticInternalPoint.SolveElasticToPrevius(this.configElastic, loopsTotalCount);
				elasticInternalPoint.SolveElasticToNext(this.configElastic, loopsTotalCount);
				elasticInternalPoint.SolveElasticToRoot(this.configElastic, loopsTotalCount);
			}
			float num = this.configElastic.collisionForce * (Time.fixedDeltaTime / (float)loopsTotalCount);
			for (int j = this.m_allPoints.Count - 1; j >= 0; j--)
			{
				HoleInternal.ElasticInternalPoint elasticInternalPoint2 = this.m_allPoints[j];
				for (int k = j - 1; k >= 0; k--)
				{
					HoleInternal.ElasticInternalPoint elasticInternalPoint3 = this.m_allPoints[k];
					if (!(elasticInternalPoint2.owner == elasticInternalPoint3.owner))
					{
						float3 @float = elasticInternalPoint2.punto.position;
						float3 float2 = ((elasticInternalPoint2.next != null) ? elasticInternalPoint2.next.position : @float);
						float3 float3 = elasticInternalPoint3.punto.position;
						float3 float4 = ((elasticInternalPoint3.next != null) ? elasticInternalPoint3.next.position : float3);
						SistemaLocalDePuntosElasticosDeInternal.CollidePointsJob.SolveCapsuleCapsule_Burst(num, ref @float, ref float2, elasticInternalPoint2.penetrationWorldRadius, ref float3, ref float4, elasticInternalPoint3.penetrationWorldRadius);
						elasticInternalPoint2.punto.position = @float;
						if (elasticInternalPoint2.next != null)
						{
							elasticInternalPoint2.next.position = float2;
						}
						elasticInternalPoint3.punto.position = float3;
						if (elasticInternalPoint3.next != null)
						{
							elasticInternalPoint3.next.position = float4;
						}
					}
				}
			}
			for (int l = 0; l < this.m_users.Count; l++)
			{
				this.m_users[l].SolveElasticPuntoPenetration(loopsTotalCount);
			}
		}

		// Token: 0x040007AD RID: 1965
		[Obsolete]
		public HoleInternalPointsSolver.ConfigElastic configElastic = new HoleInternalPointsSolver.ConfigElastic();

		// Token: 0x040007AE RID: 1966
		[SerializeReference]
		private List<HoleInternal.ElasticInternalPoint> m_allPoints = new List<HoleInternal.ElasticInternalPoint>();

		// Token: 0x040007AF RID: 1967
		[SerializeReference]
		private List<HoleInternal> m_users = new List<HoleInternal>();

		// Token: 0x040007B0 RID: 1968
		private SistemaLocalDePuntosElasticosDeInternal m_sistema;

		// Token: 0x040007B1 RID: 1969
		private static ProfilerMarker PRESOLVE = new ProfilerMarker("HoleInternalPointsSolver.PreSolving");

		// Token: 0x040007B2 RID: 1970
		private static ProfilerMarker SOLVE = new ProfilerMarker("HoleInternalPointsSolver.Solve");

		// Token: 0x040007B3 RID: 1971
		private static ProfilerMarker POSTSOLVE = new ProfilerMarker("HoleInternalPointsSolver.PostSolve");

		// Token: 0x040007B4 RID: 1972
		private static ProfilerMarker SOLVECAPSULE = new ProfilerMarker("HoleInternalPointsSolver.SolveCapsuleCapsule");

		// Token: 0x040007B5 RID: 1973
		private static ProfilerMarker Shuffle = new ProfilerMarker("HoleInternalPointsSolver.Shuffle");

		// Token: 0x040007B6 RID: 1974
		private static ProfilerMarker ELASTICS = new ProfilerMarker("HoleInternalPointsSolver.Elastics");

		// Token: 0x040007B7 RID: 1975
		private static ProfilerMarker ELASTICSPOINT = new ProfilerMarker("HoleInternalPointsSolver.ElasticsPoint");

		// Token: 0x040007B8 RID: 1976
		private static ProfilerMarker COLLISIONS = new ProfilerMarker("HoleInternalPointsSolver.Collisiones");

		// Token: 0x040007B9 RID: 1977
		private static ProfilerMarker PENETRATIONS = new ProfilerMarker("HoleInternalPointsSolver.Penetraciones");

		// Token: 0x0200019E RID: 414
		[Obsolete]
		[Serializable]
		public class ConfigElastic
		{
			// Token: 0x040007BA RID: 1978
			[Range(1f, 10f)]
			public int loops = 4;

			// Token: 0x040007BB RID: 1979
			public float rootSmoothTime = 0.1f;

			// Token: 0x040007BC RID: 1980
			public float previusSmoothTime = 0.1f;

			// Token: 0x040007BD RID: 1981
			public float nextSmoothTime = 0.1f;

			// Token: 0x040007BE RID: 1982
			public float collisionForce = 20f;
		}
	}
}
