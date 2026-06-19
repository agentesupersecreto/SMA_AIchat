using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas
{
	// Token: 0x020001AC RID: 428
	internal abstract class ElasticFromOtherData : IDisposable
	{
		// Token: 0x06000A23 RID: 2595 RVA: 0x0002DCBC File Offset: 0x0002BEBC
		public void Init()
		{
			this.m_esRootData = new NativeReference<bool>(this.EsRoot(), Allocator.Persistent);
			this.m_IDIndex = new NativeReference<int>(this.IDIndex(), Allocator.Persistent);
		}

		// Token: 0x06000A24 RID: 2596
		protected abstract TransformAccessArray GetArray(TransformsData transformsData);

		// Token: 0x06000A25 RID: 2597
		protected abstract bool EsRoot();

		// Token: 0x06000A26 RID: 2598
		protected abstract int IDIndex();

		// Token: 0x06000A27 RID: 2599 RVA: 0x0002DCEC File Offset: 0x0002BEEC
		public JobHandle UpdateData(JobHandle dependsOn, InternalData internalData, TransformsData transformsData)
		{
			ElasticFromOtherData.CalculateFromMatrixJob calculateFromMatrixJob = default(ElasticFromOtherData.CalculateFromMatrixJob);
			calculateFromMatrixJob.idIndex = this.m_IDIndex.AsReadOnly();
			calculateFromMatrixJob.holeIndex_HolePrevNextIDs = transformsData.holeIndex_HolePrevNext.AsReadOnly();
			calculateFromMatrixJob.internalLossyScale = internalData.internalLossyScale.AsReadOnly();
			calculateFromMatrixJob.otherEsRoot = this.m_esRootData.AsReadOnly();
			calculateFromMatrixJob.currentMatrixFromOther = this.currentMatrixFromOther;
			TransformAccessArray array = this.GetArray(transformsData);
			dependsOn = calculateFromMatrixJob.ScheduleReadOnly(array, array.length.BatchCountLIGHT(), dependsOn);
			return dependsOn;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0002DD78 File Offset: 0x0002BF78
		public void UpdateDataNow(InternalData internalData, TransformsData transformsData)
		{
			ElasticFromOtherData.CalculateFromMatrixJob calculateFromMatrixJob = default(ElasticFromOtherData.CalculateFromMatrixJob);
			calculateFromMatrixJob.idIndex = this.m_IDIndex.AsReadOnly();
			calculateFromMatrixJob.holeIndex_HolePrevNextIDs = transformsData.holeIndex_HolePrevNext.AsReadOnly();
			calculateFromMatrixJob.internalLossyScale = internalData.internalLossyScale.AsReadOnly();
			calculateFromMatrixJob.otherEsRoot = this.m_esRootData.AsReadOnly();
			calculateFromMatrixJob.currentMatrixFromOther = this.currentMatrixFromOther;
			TransformAccessArray array = this.GetArray(transformsData);
			calculateFromMatrixJob.RunReadOnly(array);
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0002DDF4 File Offset: 0x0002BFF4
		public void UpdateUserDefaultPosition(int index, Vector3 defaultPositionFrom)
		{
			try
			{
				this.defaultPositionFromOther[index] = defaultPositionFrom;
				this.currentPositionFromOther[index] = defaultPositionFrom;
				this.currentVelocityFromOther[index] = Vector3.zero;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0002DE50 File Offset: 0x0002C050
		public void OnUsersChanged(int usersCount, bool usersHadChanged, NativeArray<int2> usersWentFromToIndexes, int usersWentFromToIndexesCount)
		{
			NativeArray<float3> nativeArray = new NativeArray<float3>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			NativeArray<float3> nativeArray2 = new NativeArray<float3>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			NativeArray<float3> nativeArray3 = new NativeArray<float3>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			NativeArray<float4x4> nativeArray4 = new NativeArray<float4x4>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			if (usersHadChanged)
			{
				if (usersWentFromToIndexesCount > 0)
				{
					NativeList<JobHandle> nativeList = new NativeList<JobHandle>(Allocator.Temp);
					NativeArray<float3> nativeArray5 = this.defaultPositionFromOther;
					NativeArray<float3> nativeArray6 = nativeArray;
					JobHandle jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray5, nativeArray6, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					NativeArray<float3> nativeArray7 = this.currentPositionFromOther;
					NativeArray<float3> nativeArray8 = nativeArray2;
					jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray7, nativeArray8, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					NativeArray<float3> nativeArray9 = this.currentVelocityFromOther;
					NativeArray<float3> nativeArray10 = nativeArray3;
					jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray9, nativeArray10, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					NativeArray<float4x4> nativeArray11 = this.currentMatrixFromOther;
					NativeArray<float4x4> nativeArray12 = nativeArray4;
					jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray11, nativeArray12, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					jobHandle = JobHandle.CombineDependencies(nativeList.AsArray());
					jobHandle.Complete();
				}
				this.Dispose();
			}
			this.defaultPositionFromOther = nativeArray;
			this.currentPositionFromOther = nativeArray2;
			this.currentVelocityFromOther = nativeArray3;
			this.currentMatrixFromOther = nativeArray4;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x0002DF6C File Offset: 0x0002C16C
		public void Dispose()
		{
			if (this.m_IDIndex.IsCreated)
			{
				this.m_IDIndex.Dispose();
			}
			if (this.defaultPositionFromOther.IsCreated)
			{
				this.defaultPositionFromOther.Dispose();
			}
			if (this.currentPositionFromOther.IsCreated)
			{
				this.currentPositionFromOther.Dispose();
			}
			if (this.currentVelocityFromOther.IsCreated)
			{
				this.currentVelocityFromOther.Dispose();
			}
			if (this.currentMatrixFromOther.IsCreated)
			{
				this.currentMatrixFromOther.Dispose();
			}
			if (this.m_esRootData.IsCreated)
			{
				this.m_esRootData.Dispose();
			}
		}

		// Token: 0x0400080A RID: 2058
		public NativeArray<float3> defaultPositionFromOther;

		// Token: 0x0400080B RID: 2059
		public NativeArray<float3> currentPositionFromOther;

		// Token: 0x0400080C RID: 2060
		public NativeArray<float3> currentVelocityFromOther;

		// Token: 0x0400080D RID: 2061
		public NativeArray<float4x4> currentMatrixFromOther;

		// Token: 0x0400080E RID: 2062
		private NativeReference<bool> m_esRootData;

		// Token: 0x0400080F RID: 2063
		private NativeReference<int> m_IDIndex;

		// Token: 0x020001AD RID: 429
		[BurstCompile(FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
		private struct CalculateFromMatrixJob : IJobParallelForTransform
		{
			// Token: 0x06000A2D RID: 2605 RVA: 0x0002E00C File Offset: 0x0002C20C
			public void Execute(int index, TransformAccess other)
			{
				int4 @int = this.holeIndex_HolePrevNextIDs[index];
				if (@int[this.idIndex.Value] == 0 || !other.isValid)
				{
					return;
				}
				int num = @int[0];
				float3 @float = this.internalLossyScale[num];
				float4x4 float4x = (this.otherEsRoot.Value ? other.localToWorldMatrix : float4x4.TRS(other.position, other.rotation, @float));
				this.currentMatrixFromOther[index] = float4x;
			}

			// Token: 0x04000810 RID: 2064
			[ReadOnly]
			public NativeReference<int>.ReadOnly idIndex;

			// Token: 0x04000811 RID: 2065
			[ReadOnly]
			public NativeArray<int4>.ReadOnly holeIndex_HolePrevNextIDs;

			// Token: 0x04000812 RID: 2066
			[ReadOnly]
			public NativeArray<float3>.ReadOnly internalLossyScale;

			// Token: 0x04000813 RID: 2067
			[ReadOnly]
			public NativeReference<bool>.ReadOnly otherEsRoot;

			// Token: 0x04000814 RID: 2068
			[WriteOnly]
			public NativeArray<float4x4> currentMatrixFromOther;
		}
	}
}
