using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas
{
	// Token: 0x020001B3 RID: 435
	public class SistemaLocalDePuntosElasticosDeInternal : SystemaLocalConUsuarios<SistemaLocalDePuntosElasticosDeInternal, SistemaLocalDePuntosElasticosDeInternal.IUser>
	{
		// Token: 0x14000038 RID: 56
		// (add) Token: 0x06000A43 RID: 2627 RVA: 0x0002E2F4 File Offset: 0x0002C4F4
		// (remove) Token: 0x06000A44 RID: 2628 RVA: 0x0002E32C File Offset: 0x0002C52C
		public event Action OnIteration;

		// Token: 0x06000A45 RID: 2629 RVA: 0x00003BC5 File Offset: 0x00001DC5
		protected override IEnumerator Initiating()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x0002E361 File Offset: 0x0002C561
		protected override void FastInitiating()
		{
			this.m_vag = this.GetComponentEnRoot(false);
			this.m_anus = this.GetComponentEnRoot(false);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0002E380 File Offset: 0x0002C580
		protected override void Initiated()
		{
			this.m_SystemData.Init();
			this.m_InternalData.Init(this.m_vag, this.m_anus);
			this.m_ElasticFromRootData.Init();
			this.m_ElasticFromPrevData.Init();
			this.m_ElasticFromNextData.Init();
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0002E3D0 File Offset: 0x0002C5D0
		public void ScheduleAndCompleteIterations()
		{
			((ISystemaSchedulable)this).Schedule(default(JobHandle));
			((ISystemaSchedulable)this).Complete();
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x0002E3F4 File Offset: 0x0002C5F4
		public void UpdateInitialData(SistemaLocalDePuntosElasticosDeInternal.IUser user, HoleInternal owner, Transform Root, Transform Prev, Transform Punto, Transform Next, Vector3 defaultPositionFromRoot, Vector3 defaultPositionFromPrev, Vector3 defaultPositionFromNext)
		{
			int num = base.ObtenerIndexDeUsuario(user);
			this.m_TransformsData.UpdateUserTransforms(this.m_InternalData, num, owner.root, Root, Prev, Punto, Next);
			this.m_ElasticFromRootData.UpdateUserDefaultPosition(num, defaultPositionFromRoot);
			this.m_ElasticFromPrevData.UpdateUserDefaultPosition(num, defaultPositionFromPrev);
			this.m_ElasticFromNextData.UpdateUserDefaultPosition(num, defaultPositionFromNext);
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x0002E454 File Offset: 0x0002C654
		public void UpdateConfigData(SistemaLocalDePuntosElasticosDeInternal.IUser user, float elasticTimesPrev, float elasticTimesNext, float elasticTimesRoot)
		{
			int num = base.ObtenerIndexDeUsuario(user);
			this.m_userData.UpdateUserData(num, elasticTimesPrev * this.configElastic.previusSmoothTime, elasticTimesNext * this.configElastic.nextSmoothTime, elasticTimesRoot * this.configElastic.rootSmoothTime);
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0002E4A0 File Offset: 0x0002C6A0
		protected override void OnDestroyed(bool wasInitiated, bool usersHadChanged)
		{
			if (wasInitiated)
			{
				this.m_SystemData.Dispose();
				this.m_userData.Dispose();
				this.m_InternalData.Dispose();
				this.m_TransformsData.Dispose();
				this.m_ElasticFromRootData.Dispose();
				this.m_ElasticFromPrevData.Dispose();
				this.m_ElasticFromNextData.Dispose();
			}
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x0002E500 File Offset: 0x0002C700
		protected override void OnUsersChanged(bool usersHadChanged, NativeArray<int2> usersWentFromToIndexes, int usersWentFromToIndexesCount, NativeArray<int> newUsersIndexes, int newUsersIndexesCount)
		{
			int num = base.ObtenerUsersCount();
			this.m_userData.OnUsersChanged(num, usersHadChanged, usersWentFromToIndexes, usersWentFromToIndexesCount);
			this.m_TransformsData.OnUsersChanged(num, usersHadChanged, usersWentFromToIndexes, usersWentFromToIndexesCount);
			this.m_ElasticFromRootData.OnUsersChanged(num, usersHadChanged, usersWentFromToIndexes, usersWentFromToIndexesCount);
			this.m_ElasticFromPrevData.OnUsersChanged(num, usersHadChanged, usersWentFromToIndexes, usersWentFromToIndexesCount);
			this.m_ElasticFromNextData.OnUsersChanged(num, usersHadChanged, usersWentFromToIndexes, usersWentFromToIndexesCount);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0002E560 File Offset: 0x0002C760
		protected override JobHandle OnSchedulingFirstTimeUsers(NativeArray<int>.ReadOnly firstTimeUsersIndexes, JobHandle dependsOn)
		{
			for (int i = 0; i < firstTimeUsersIndexes.Length; i++)
			{
				this.m_TransformsData.UpdateNextIndexDeIndex(firstTimeUsersIndexes[i]);
			}
			return dependsOn;
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0002E593 File Offset: 0x0002C793
		protected override JobHandle OnScheduling(JobHandle dependsOn)
		{
			this.m_SystemData.UpdateData(this);
			this.m_InternalData.UpdateData();
			return dependsOn;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0002E5B0 File Offset: 0x0002C7B0
		protected override JobHandle OnSchedule(int arrayLength, int innerloopBatchCount, JobHandle dependsOn)
		{
			int loops = this.configElastic.loops;
			for (int i = 0; i < loops; i++)
			{
				NativeArray<int>.ReadOnly readOnly = base.ObtenerUsers();
				for (int j = 0; j < readOnly.Length; j++)
				{
					SistemaLocalDePuntosElasticosDeInternal.IUser user = base.ObtenerUsuario(readOnly[j]);
					this.m_userData.UpdateUserData(j, user.worldRadius);
				}
				JobHandle pointsCurrentPositions = this.m_TransformsData.GetPointsCurrentPositions(dependsOn);
				JobHandle jobHandle = this.m_ElasticFromPrevData.UpdateData(dependsOn, this.m_InternalData, this.m_TransformsData);
				JobHandle jobHandle2 = this.m_ElasticFromNextData.UpdateData(dependsOn, this.m_InternalData, this.m_TransformsData);
				JobHandle jobHandle3 = this.m_ElasticFromRootData.UpdateData(dependsOn, this.m_InternalData, this.m_TransformsData);
				JobHandle jobHandle4 = JobHandle.CombineDependencies(pointsCurrentPositions, JobHandle.CombineDependencies(jobHandle, jobHandle2, jobHandle3));
				SistemaLocalDePuntosElasticosDeInternal.ElasticPointsJob elasticPointsJob = default(SistemaLocalDePuntosElasticosDeInternal.ElasticPointsJob);
				elasticPointsJob.fixedDeltaTime = this.m_SystemData.fixedDeltaTime.AsReadOnly();
				elasticPointsJob.iterationsCount = this.m_SystemData.iterations.AsReadOnly();
				elasticPointsJob.elasticTimesPrevNextRoot = this.m_userData.elasticTimesPrevNextRoot.AsReadOnly();
				elasticPointsJob.holeIndex_HolePrevNext = this.m_TransformsData.holeIndex_HolePrevNext.AsReadOnly();
				elasticPointsJob.defaultPositionFromPrev = this.m_ElasticFromPrevData.defaultPositionFromOther.AsReadOnly();
				elasticPointsJob.currentPositionFromPrev = this.m_ElasticFromPrevData.currentPositionFromOther;
				elasticPointsJob.currentVelocityFromPrev = this.m_ElasticFromPrevData.currentVelocityFromOther;
				elasticPointsJob.currentMatrixFromPrev = this.m_ElasticFromPrevData.currentMatrixFromOther.AsReadOnly();
				elasticPointsJob.defaultPositionFromNext = this.m_ElasticFromNextData.defaultPositionFromOther.AsReadOnly();
				elasticPointsJob.currentPositionFromNext = this.m_ElasticFromNextData.currentPositionFromOther;
				elasticPointsJob.currentVelocityFromNext = this.m_ElasticFromNextData.currentVelocityFromOther;
				elasticPointsJob.currentMatrixFromNext = this.m_ElasticFromNextData.currentMatrixFromOther.AsReadOnly();
				elasticPointsJob.defaultPositionFromRoot = this.m_ElasticFromRootData.defaultPositionFromOther.AsReadOnly();
				elasticPointsJob.currentPositionFromRoot = this.m_ElasticFromRootData.currentPositionFromOther;
				elasticPointsJob.currentVelocityFromRoot = this.m_ElasticFromRootData.currentVelocityFromOther;
				elasticPointsJob.currentMatrixFromRoot = this.m_ElasticFromRootData.currentMatrixFromOther.AsReadOnly();
				jobHandle4.Complete();
				elasticPointsJob.currentPointWorldPosition = this.m_TransformsData.currentPuntoWorldPosition;
				elasticPointsJob.Run(this.m_TransformsData.puntosAccess.length);
				this.m_TransformsData.GetNextCurrentPositions(dependsOn).Complete();
				new SistemaLocalDePuntosElasticosDeInternal.CollidePointsJob
				{
					fixedDeltaTime = this.m_SystemData.fixedDeltaTime.AsReadOnly(),
					iterationsCount = this.m_SystemData.iterations.AsReadOnly(),
					collisionForce = this.m_SystemData.collisionForce.AsReadOnly(),
					holeIndex_HolePrevNext = this.m_TransformsData.holeIndex_HolePrevNext.AsReadOnly(),
					currentNextWorldPosition = this.m_TransformsData.currentNextWorldPosition,
					nextIndexDePointIndex = this.m_TransformsData.nextIndexDePointIndex.AsReadOnly(),
					worldRadius = this.m_userData.worldRadius.AsReadOnly(),
					currentPointWorldPosition = this.m_TransformsData.currentPuntoWorldPosition
				}.Run<SistemaLocalDePuntosElasticosDeInternal.CollidePointsJob>();
				this.m_TransformsData.SetPointsCurrentPositions(default(JobHandle)).Complete();
				Action onIteration = this.OnIteration;
				if (onIteration != null)
				{
					onIteration();
				}
			}
			return dependsOn;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnScheduled(JobHandle dependsOn)
		{
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnCompleting()
		{
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnCompleted()
		{
		}

		// Token: 0x0400081A RID: 2074
		public SistemaLocalDePuntosElasticosDeInternal.ConfigElastic configElastic = new SistemaLocalDePuntosElasticosDeInternal.ConfigElastic();

		// Token: 0x0400081B RID: 2075
		private SystemData m_SystemData = new SystemData();

		// Token: 0x0400081C RID: 2076
		private UserData m_userData = new UserData();

		// Token: 0x0400081D RID: 2077
		private InternalData m_InternalData = new InternalData();

		// Token: 0x0400081E RID: 2078
		private TransformsData m_TransformsData = new TransformsData();

		// Token: 0x0400081F RID: 2079
		private ElasticFromRootData m_ElasticFromRootData = new ElasticFromRootData();

		// Token: 0x04000820 RID: 2080
		private ElasticFromPrevData m_ElasticFromPrevData = new ElasticFromPrevData();

		// Token: 0x04000821 RID: 2081
		private ElasticFromNextData m_ElasticFromNextData = new ElasticFromNextData();

		// Token: 0x04000822 RID: 2082
		private VagInternals m_vag;

		// Token: 0x04000823 RID: 2083
		private AnusInternals m_anus;

		// Token: 0x020001B4 RID: 436
		[Serializable]
		public class ConfigElastic
		{
			// Token: 0x04000825 RID: 2085
			[Range(1f, 10f)]
			public int loops = 2;

			// Token: 0x04000826 RID: 2086
			public float rootSmoothTime = 0.1f;

			// Token: 0x04000827 RID: 2087
			public float previusSmoothTime = 0.1f;

			// Token: 0x04000828 RID: 2088
			public float nextSmoothTime = 0.1f;

			// Token: 0x04000829 RID: 2089
			public float collisionForce = 20f;
		}

		// Token: 0x020001B5 RID: 437
		public interface IUser : IUserDeSystemaLocal<SistemaLocalDePuntosElasticosDeInternal>, IUserDeSystema<SistemaLocalDePuntosElasticosDeInternal>, IUserDeSystema, IUserDeSystemaLocal
		{
			// Token: 0x17000232 RID: 562
			// (get) Token: 0x06000A55 RID: 2645
			float worldRadius { get; }
		}

		// Token: 0x020001B6 RID: 438
		[BurstCompile(FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
		public struct CollidePointsJob : IJob
		{
			// Token: 0x06000A56 RID: 2646 RVA: 0x0002E9BC File Offset: 0x0002CBBC
			public void Execute()
			{
				float num = this.fixedDeltaTime.Value / (float)this.iterationsCount.Value;
				float num2 = this.collisionForce.Value * num;
				for (int i = this.currentPointWorldPosition.Length - 1; i >= 0; i--)
				{
					int num3 = this.holeIndex_HolePrevNext[i][0];
					for (int j = i - 1; j >= 0; j--)
					{
						int num4 = this.holeIndex_HolePrevNext[j][0];
						if (num3 != num4)
						{
							bool flag = this.holeIndex_HolePrevNext[i][3] != 0;
							bool flag2 = this.holeIndex_HolePrevNext[j][3] != 0;
							int num5 = this.nextIndexDePointIndex[i];
							int num6 = this.nextIndexDePointIndex[j];
							float3 @float = this.currentPointWorldPosition[i];
							float3 float2 = (flag ? ((num5 >= 0) ? this.currentPointWorldPosition[num5] : this.currentNextWorldPosition[i]) : @float);
							float3 float3 = this.currentPointWorldPosition[j];
							float3 float4 = (flag2 ? ((num6 >= 0) ? this.currentPointWorldPosition[num6] : this.currentNextWorldPosition[j]) : float3);
							SistemaLocalDePuntosElasticosDeInternal.CollidePointsJob.SolveCapsuleCapsule_Burst(num2, ref @float, ref float2, this.worldRadius[i], ref float3, ref float4, this.worldRadius[j]);
							this.currentPointWorldPosition[i] = @float;
							this.currentPointWorldPosition[j] = float3;
							if (num5 >= 0)
							{
								this.currentPointWorldPosition[num5] = float2;
							}
							if (num6 >= 0)
							{
								this.currentPointWorldPosition[num6] = float4;
							}
						}
					}
				}
			}

			// Token: 0x06000A57 RID: 2647 RVA: 0x0002EB8C File Offset: 0x0002CD8C
			public static void SolveCapsuleCapsule_Burst(float stepVel, ref float3 p0a, ref float3 p1a, float radiusA, ref float3 p0b, ref float3 p1b, float radiusB)
			{
				SistemaLocalDePuntosElasticosDeInternal.CollidePointsJob.SolveCapsuleCapsule(ref p0a, ref p1a, radiusA, ref p0b, ref p1b, radiusB, stepVel);
			}

			// Token: 0x06000A58 RID: 2648 RVA: 0x0002EBA0 File Offset: 0x0002CDA0
			private static void ClosestPtSegmentSegment(float3 p1, float3 q1, float3 p2, float3 q2, out float3 c1, out float3 c2)
			{
				float3 @float = q1 - p1;
				float3 float2 = q2 - p2;
				float3 float3 = p1 - p2;
				float num = math.dot(@float, @float);
				float num2 = math.dot(float2, float2);
				float num3 = math.dot(float2, float3);
				if (num <= 1E-06f && num2 <= 1E-06f)
				{
					c1 = p1;
					c2 = p2;
					return;
				}
				float num4;
				float num5;
				if (num <= 1E-06f)
				{
					num4 = 0f;
					num5 = math.clamp(num3 / num2, 0f, 1f);
				}
				else
				{
					float num6 = math.dot(@float, float3);
					if (num2 <= 1E-06f)
					{
						num5 = 0f;
						num4 = math.clamp(-num6 / num, 0f, 1f);
					}
					else
					{
						float num7 = math.dot(@float, float2);
						float num8 = num * num2 - num7 * num7;
						if (num8 != 0f)
						{
							num4 = math.clamp((num7 * num3 - num6 * num2) / num8, 0f, 1f);
						}
						else
						{
							num4 = 0f;
						}
						num5 = (num7 * num4 + num3) / num2;
						if (num5 < 0f)
						{
							num5 = 0f;
							num4 = math.clamp(-num6 / num, 0f, 1f);
						}
						else if (num5 > 1f)
						{
							num5 = 1f;
							num4 = math.clamp((num7 - num6) / num, 0f, 1f);
						}
					}
				}
				c1 = p1 + @float * num4;
				c2 = p2 + float2 * num5;
			}

			// Token: 0x06000A59 RID: 2649 RVA: 0x0002ED2C File Offset: 0x0002CF2C
			private static void SolveCapsuleCapsule(ref float3 p0a, ref float3 p1a, float radiusA, ref float3 p0b, ref float3 p1b, float radiusB, float stepVel)
			{
				float3 @float;
				float3 float2;
				SistemaLocalDePuntosElasticosDeInternal.CollidePointsJob.ClosestPtSegmentSegment(p0a, p1a, p0b, p1b, out @float, out float2);
				float3 float3 = float2 - @float;
				float num = math.lengthsq(float3);
				float num2 = radiusA + radiusB;
				float num3 = num2 * num2;
				if (num >= num3 || num < 1E-10f)
				{
					return;
				}
				float num4 = math.sqrt(num);
				float3 float4 = float3 / num4;
				float num5 = num2 - num4;
				float3 float5 = float4 * (num5 * 0.5f * stepVel);
				p0a -= float5;
				p1a -= float5;
				p0b += float5;
				p1b += float5;
			}

			// Token: 0x0400082A RID: 2090
			[ReadOnly]
			public NativeReference<float>.ReadOnly fixedDeltaTime;

			// Token: 0x0400082B RID: 2091
			[ReadOnly]
			public NativeReference<int>.ReadOnly iterationsCount;

			// Token: 0x0400082C RID: 2092
			[ReadOnly]
			public NativeReference<float>.ReadOnly collisionForce;

			// Token: 0x0400082D RID: 2093
			[ReadOnly]
			public NativeArray<int4>.ReadOnly holeIndex_HolePrevNext;

			// Token: 0x0400082E RID: 2094
			[ReadOnly]
			public NativeArray<int>.ReadOnly nextIndexDePointIndex;

			// Token: 0x0400082F RID: 2095
			[ReadOnly]
			public NativeArray<float>.ReadOnly worldRadius;

			// Token: 0x04000830 RID: 2096
			public NativeArray<float3> currentNextWorldPosition;

			// Token: 0x04000831 RID: 2097
			public NativeArray<float3> currentPointWorldPosition;
		}

		// Token: 0x020001B7 RID: 439
		[BurstCompile(FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
		public struct ElasticPointsJob : IJobParallelForTransform, IJobParallelFor
		{
			// Token: 0x06000A5A RID: 2650 RVA: 0x0002EDFC File Offset: 0x0002CFFC
			public void Execute(int i, TransformAccess transform)
			{
				float num = this.fixedDeltaTime.Value / (float)this.iterationsCount.Value;
				bool flag = this.holeIndex_HolePrevNext[i][2] != 0;
				bool flag2 = this.holeIndex_HolePrevNext[i][3] != 0;
				float3 @float = transform.position;
				this.ExecuteElastic(i, ref @float, num, flag, flag2);
				transform.position = @float;
			}

			// Token: 0x06000A5B RID: 2651 RVA: 0x0002EE7C File Offset: 0x0002D07C
			public void Execute(int i)
			{
				float num = this.fixedDeltaTime.Value / (float)this.iterationsCount.Value;
				bool flag = this.holeIndex_HolePrevNext[i][2] != 0;
				bool flag2 = this.holeIndex_HolePrevNext[i][3] != 0;
				float3 @float = this.currentPointWorldPosition[i];
				this.ExecuteElastic(i, ref @float, num, flag, flag2);
				this.currentPointWorldPosition[i] = @float;
			}

			// Token: 0x06000A5C RID: 2652 RVA: 0x0002EEFC File Offset: 0x0002D0FC
			private void ExecuteElastic(int i, ref float3 CurrentPointWorldPosition, float deltaTime, bool prevInstanceIDExist, bool nextInstanceIDExist)
			{
				if (prevInstanceIDExist)
				{
					SistemaLocalDePuntosElasticosDeInternal.ElasticPointsJob.Procesar(i, this.elasticTimesPrevNextRoot[i].x, deltaTime, ref CurrentPointWorldPosition, this.currentMatrixFromPrev, this.defaultPositionFromPrev, this.currentPositionFromPrev, this.currentVelocityFromPrev);
				}
				if (nextInstanceIDExist)
				{
					SistemaLocalDePuntosElasticosDeInternal.ElasticPointsJob.Procesar(i, this.elasticTimesPrevNextRoot[i].y, deltaTime, ref CurrentPointWorldPosition, this.currentMatrixFromNext, this.defaultPositionFromNext, this.currentPositionFromNext, this.currentVelocityFromNext);
				}
				SistemaLocalDePuntosElasticosDeInternal.ElasticPointsJob.Procesar(i, this.elasticTimesPrevNextRoot[i].z, deltaTime, ref CurrentPointWorldPosition, this.currentMatrixFromRoot, this.defaultPositionFromRoot, this.currentPositionFromRoot, this.currentVelocityFromRoot);
			}

			// Token: 0x06000A5D RID: 2653 RVA: 0x0002EFA4 File Offset: 0x0002D1A4
			private static void Procesar(int i, float elasticTime, float deltaTime, ref float3 currentPointWorldPosition, NativeArray<float4x4>.ReadOnly currentMatrix, NativeArray<float3>.ReadOnly defaultFromPosition, NativeArray<float3> currentFromPosition, NativeArray<float3> currentVelocity)
			{
				float4x4 float4x = currentMatrix[i];
				float3 @float = math.transform(math.inverse(float4x), currentPointWorldPosition);
				float3 float2 = currentVelocity[i];
				if (!math.all(math.isfinite(float2)))
				{
					float2 = float3.zero;
				}
				float3 float3 = defaultFromPosition[i];
				@float = SistemaLocalDePuntosElasticosDeInternal.ElasticPointsJob.SmoothDamp(@float, float3, ref float2, elasticTime, float.PositiveInfinity, deltaTime);
				currentVelocity[i] = float2;
				currentFromPosition[i] = @float;
				currentPointWorldPosition = math.transform(float4x, @float);
			}

			// Token: 0x06000A5E RID: 2654 RVA: 0x0002F024 File Offset: 0x0002D224
			private static float3 SmoothDamp(float3 current, float3 target, ref float3 currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
			{
				smoothTime = math.max(0.0001f, smoothTime);
				float num = 2f / smoothTime;
				float num2 = num * deltaTime;
				float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
				float num4 = current.x - target.x;
				float num5 = current.y - target.y;
				float num6 = current.z - target.z;
				float3 @float = target;
				float num7 = maxSpeed * smoothTime;
				float num8 = num7 * num7;
				float num9 = num4 * num4 + num5 * num5 + num6 * num6;
				if (num9 > num8)
				{
					float num10 = math.sqrt(num9);
					num4 = num4 / num10 * num7;
					num5 = num5 / num10 * num7;
					num6 = num6 / num10 * num7;
				}
				target.x = current.x - num4;
				target.y = current.y - num5;
				target.z = current.z - num6;
				float num11 = (currentVelocity.x + num * num4) * deltaTime;
				float num12 = (currentVelocity.y + num * num5) * deltaTime;
				float num13 = (currentVelocity.z + num * num6) * deltaTime;
				currentVelocity.x = (currentVelocity.x - num * num11) * num3;
				currentVelocity.y = (currentVelocity.y - num * num12) * num3;
				currentVelocity.z = (currentVelocity.z - num * num13) * num3;
				float num14 = target.x + (num4 + num11) * num3;
				float num15 = target.y + (num5 + num12) * num3;
				float num16 = target.z + (num6 + num13) * num3;
				float num17 = @float.x - current.x;
				float num18 = @float.y - current.y;
				float num19 = @float.z - current.z;
				float num20 = num14 - @float.x;
				float num21 = num15 - @float.y;
				float num22 = num16 - @float.z;
				if (num17 * num20 + num18 * num21 + num19 * num22 > 0f)
				{
					num14 = @float.x;
					num15 = @float.y;
					num16 = @float.z;
					currentVelocity.x = (num14 - @float.x) / deltaTime;
					currentVelocity.y = (num15 - @float.y) / deltaTime;
					currentVelocity.z = (num16 - @float.z) / deltaTime;
				}
				return new float3(num14, num15, num16);
			}

			// Token: 0x04000832 RID: 2098
			[ReadOnly]
			public NativeReference<float>.ReadOnly fixedDeltaTime;

			// Token: 0x04000833 RID: 2099
			[ReadOnly]
			public NativeReference<int>.ReadOnly iterationsCount;

			// Token: 0x04000834 RID: 2100
			[ReadOnly]
			public NativeArray<float3>.ReadOnly elasticTimesPrevNextRoot;

			// Token: 0x04000835 RID: 2101
			[ReadOnly]
			public NativeArray<int4>.ReadOnly holeIndex_HolePrevNext;

			// Token: 0x04000836 RID: 2102
			[ReadOnly]
			public NativeArray<float3>.ReadOnly defaultPositionFromPrev;

			// Token: 0x04000837 RID: 2103
			public NativeArray<float3> currentPositionFromPrev;

			// Token: 0x04000838 RID: 2104
			public NativeArray<float3> currentVelocityFromPrev;

			// Token: 0x04000839 RID: 2105
			[ReadOnly]
			public NativeArray<float4x4>.ReadOnly currentMatrixFromPrev;

			// Token: 0x0400083A RID: 2106
			[ReadOnly]
			public NativeArray<float3>.ReadOnly defaultPositionFromNext;

			// Token: 0x0400083B RID: 2107
			public NativeArray<float3> currentPositionFromNext;

			// Token: 0x0400083C RID: 2108
			public NativeArray<float3> currentVelocityFromNext;

			// Token: 0x0400083D RID: 2109
			[ReadOnly]
			public NativeArray<float4x4>.ReadOnly currentMatrixFromNext;

			// Token: 0x0400083E RID: 2110
			[ReadOnly]
			public NativeArray<float3>.ReadOnly defaultPositionFromRoot;

			// Token: 0x0400083F RID: 2111
			public NativeArray<float3> currentPositionFromRoot;

			// Token: 0x04000840 RID: 2112
			public NativeArray<float3> currentVelocityFromRoot;

			// Token: 0x04000841 RID: 2113
			[ReadOnly]
			public NativeArray<float4x4>.ReadOnly currentMatrixFromRoot;

			// Token: 0x04000842 RID: 2114
			public NativeArray<float3> currentPointWorldPosition;
		}
	}
}
