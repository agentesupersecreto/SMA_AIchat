using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas
{
	// Token: 0x020001B1 RID: 433
	internal class UserData : IDisposable
	{
		// Token: 0x06000A3A RID: 2618 RVA: 0x0002E0C4 File Offset: 0x0002C2C4
		public void UpdateUserData(int index, float elasticTimesPrev, float elasticTimesNext, float elasticTimesRoot)
		{
			try
			{
				this.elasticTimesPrevNextRoot[index] = new float3(elasticTimesPrev, elasticTimesNext, elasticTimesRoot);
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x0002E0FC File Offset: 0x0002C2FC
		public void UpdateUserData(int index, float WorldRadius)
		{
			try
			{
				this.worldRadius[index] = WorldRadius;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0002E12C File Offset: 0x0002C32C
		public void OnUsersChanged(int usersCount, bool usersHadChanged, NativeArray<int2> usersWentFromToIndexes, int usersWentFromToIndexesCount)
		{
			NativeArray<float3> nativeArray = new NativeArray<float3>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			NativeArray<float> nativeArray2 = new NativeArray<float>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			if (usersHadChanged)
			{
				if (usersWentFromToIndexesCount > 0)
				{
					NativeList<JobHandle> nativeList = new NativeList<JobHandle>(Allocator.Temp);
					NativeArray<float3> nativeArray3 = this.elasticTimesPrevNextRoot;
					NativeArray<float3> nativeArray4 = nativeArray;
					JobHandle jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray3, nativeArray4, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					NativeArray<float> nativeArray5 = this.worldRadius;
					NativeArray<float> nativeArray6 = nativeArray2;
					jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray5, nativeArray6, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					jobHandle = JobHandle.CombineDependencies(nativeList.AsArray());
					jobHandle.Complete();
				}
				this.Dispose();
			}
			this.elasticTimesPrevNextRoot = nativeArray;
			this.worldRadius = nativeArray2;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0002E1D0 File Offset: 0x0002C3D0
		public void Dispose()
		{
			if (this.elasticTimesPrevNextRoot.IsCreated)
			{
				this.elasticTimesPrevNextRoot.Dispose();
			}
			if (this.worldRadius.IsCreated)
			{
				this.worldRadius.Dispose();
			}
		}

		// Token: 0x04000815 RID: 2069
		public NativeArray<float3> elasticTimesPrevNextRoot;

		// Token: 0x04000816 RID: 2070
		public NativeArray<float> worldRadius;
	}
}
