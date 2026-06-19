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
	// Token: 0x020001A9 RID: 425
	internal class TransformsData : IDisposable
	{
		// Token: 0x06000A18 RID: 2584 RVA: 0x0002D64C File Offset: 0x0002B84C
		public void UpdateUserTransforms(InternalData holeData, int index, Transform internalRoot, Transform Root, Transform Prev, Transform Punto, Transform Next)
		{
			try
			{
				this.rootAccess[index] = Root;
				this.prevAccess[index] = Prev;
				this.puntosAccess[index] = Punto;
				this.nextAccess[index] = Next;
				this.holeIndex_HolePrevNext[index] = new int4(holeData.IndexOf(internalRoot), internalRoot.GetInstanceID(), (Prev != null) ? Prev.GetInstanceID() : 0, (Next != null) ? Next.GetInstanceID() : 0);
				this.rootAccessTEST[index] = Root;
				this.prevAccessTEST[index] = Prev;
				this.puntosAccessTEST[index] = Punto;
				this.nextAccessTEST[index] = Next;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x0002D714 File Offset: 0x0002B914
		public void UpdateNextIndexDeIndex(int index)
		{
			Transform transform = this.nextAccess[index];
			if (transform == null)
			{
				this.nextIndexDePointIndex[index] = -1;
				return;
			}
			for (int i = 0; i < this.puntosAccess.length; i++)
			{
				if (this.puntosAccess[i] == transform)
				{
					this.nextIndexDePointIndex[index] = i;
					return;
				}
			}
			this.nextIndexDePointIndex[index] = -1;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0002D78C File Offset: 0x0002B98C
		public JobHandle GetPointsCurrentPositions(JobHandle dependsOn)
		{
			return new TransformsData.GetCurrentWorldPosition
			{
				currentWorldPosition = this.currentPuntoWorldPosition
			}.ScheduleReadOnly(this.puntosAccess, this.puntosAccess.length.BatchCountLIGHT(), dependsOn);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0002D7CC File Offset: 0x0002B9CC
		public JobHandle GetNextCurrentPositions(JobHandle dependsOn)
		{
			return new TransformsData.GetCurrentWorldPosition
			{
				currentWorldPosition = this.currentNextWorldPosition
			}.ScheduleReadOnly(this.nextAccess, this.nextAccess.length.BatchCountLIGHT(), dependsOn);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0002D80C File Offset: 0x0002BA0C
		public JobHandle SetPointsCurrentPositions(JobHandle dependsOn)
		{
			return new TransformsData.SetCurrentWorldPosition
			{
				currentWorldPosition = this.currentPuntoWorldPosition
			}.Schedule(this.puntosAccess, dependsOn);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0002D83C File Offset: 0x0002BA3C
		public void SetPointsCurrentPositionsNow()
		{
			for (int i = 0; i < this.puntosAccess.length; i++)
			{
				this.puntosAccess[i].position = this.currentPuntoWorldPosition[i];
			}
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0002D884 File Offset: 0x0002BA84
		public void OnUsersChanged(int usersCount, bool usersHadChanged, NativeArray<int2> usersWentFromToIndexes, int usersWentFromToIndexesCount)
		{
			TransformAccessArray transformAccessArray = new TransformAccessArray(usersCount, -1);
			TransformAccessArray transformAccessArray2 = new TransformAccessArray(usersCount, -1);
			TransformAccessArray transformAccessArray3 = new TransformAccessArray(usersCount, -1);
			TransformAccessArray transformAccessArray4 = new TransformAccessArray(usersCount, -1);
			NativeArray<int4> nativeArray = new NativeArray<int4>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			NativeArray<float3> nativeArray2 = new NativeArray<float3>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			NativeArray<float3> nativeArray3 = new NativeArray<float3>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			while (usersCount > transformAccessArray.length)
			{
				transformAccessArray.Add(null);
			}
			while (usersCount > transformAccessArray2.length)
			{
				transformAccessArray2.Add(null);
			}
			while (usersCount > transformAccessArray3.length)
			{
				transformAccessArray3.Add(null);
			}
			while (usersCount > transformAccessArray4.length)
			{
				transformAccessArray4.Add(null);
			}
			if (usersHadChanged)
			{
				if (usersWentFromToIndexesCount > 0)
				{
					UsuariosDeSystemaHandles.MoverArrayData(this.rootAccess, transformAccessArray, usersWentFromToIndexes, usersWentFromToIndexesCount, false);
					UsuariosDeSystemaHandles.MoverArrayData(this.prevAccess, transformAccessArray2, usersWentFromToIndexes, usersWentFromToIndexesCount, false);
					UsuariosDeSystemaHandles.MoverArrayData(this.puntosAccess, transformAccessArray3, usersWentFromToIndexes, usersWentFromToIndexesCount, false);
					UsuariosDeSystemaHandles.MoverArrayData(this.nextAccess, transformAccessArray4, usersWentFromToIndexes, usersWentFromToIndexesCount, false);
					NativeList<JobHandle> nativeList = new NativeList<JobHandle>(Allocator.Temp);
					NativeArray<int4> nativeArray4 = this.holeIndex_HolePrevNext;
					NativeArray<int4> nativeArray5 = nativeArray;
					JobHandle jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray4, nativeArray5, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					NativeArray<float3> nativeArray6 = this.currentPuntoWorldPosition;
					NativeArray<float3> nativeArray7 = nativeArray2;
					jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray6, nativeArray7, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					NativeArray<float3> nativeArray8 = this.currentNextWorldPosition;
					NativeArray<float3> nativeArray9 = nativeArray3;
					jobHandle = default(JobHandle);
					jobHandle = UsuariosDeSystemaHandles.MoverArrayData(nativeArray8, nativeArray9, usersWentFromToIndexes, usersWentFromToIndexesCount, jobHandle, false);
					nativeList.Add(in jobHandle);
					jobHandle = JobHandle.CombineDependencies(nativeList.AsArray());
					jobHandle.Complete();
				}
				this.Dispose();
			}
			this.rootAccess = transformAccessArray;
			this.prevAccess = transformAccessArray2;
			this.puntosAccess = transformAccessArray3;
			this.nextAccess = transformAccessArray4;
			this.holeIndex_HolePrevNext = nativeArray;
			this.currentPuntoWorldPosition = nativeArray2;
			this.currentNextWorldPosition = nativeArray3;
			if (this.rootAccess.length != usersCount)
			{
				throw new InvalidOperationException();
			}
			if (this.prevAccess.length != usersCount)
			{
				throw new InvalidOperationException();
			}
			if (this.puntosAccess.length != usersCount)
			{
				throw new InvalidOperationException();
			}
			if (this.nextAccess.length != usersCount)
			{
				throw new InvalidOperationException();
			}
			this.rootAccessTEST = new Transform[usersCount];
			this.prevAccessTEST = new Transform[usersCount];
			this.puntosAccessTEST = new Transform[usersCount];
			this.nextAccessTEST = new Transform[usersCount];
			for (int i = 0; i < this.rootAccess.length; i++)
			{
				this.rootAccessTEST[i] = this.rootAccess[i];
			}
			for (int j = 0; j < this.prevAccess.length; j++)
			{
				this.prevAccessTEST[j] = this.prevAccess[j];
			}
			for (int k = 0; k < this.puntosAccess.length; k++)
			{
				this.puntosAccessTEST[k] = this.puntosAccess[k];
			}
			for (int l = 0; l < this.nextAccess.length; l++)
			{
				this.nextAccessTEST[l] = this.nextAccess[l];
			}
			this.nextIndexDePointIndex = new NativeArray<int>(usersCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			for (int m = 0; m < usersCount; m++)
			{
				this.UpdateNextIndexDeIndex(m);
			}
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0002DBA8 File Offset: 0x0002BDA8
		public void Dispose()
		{
			if (this.rootAccess.isCreated)
			{
				this.rootAccess.Dispose();
			}
			if (this.prevAccess.isCreated)
			{
				this.prevAccess.Dispose();
			}
			if (this.puntosAccess.isCreated)
			{
				this.puntosAccess.Dispose();
			}
			if (this.nextAccess.isCreated)
			{
				this.nextAccess.Dispose();
			}
			if (this.holeIndex_HolePrevNext.IsCreated)
			{
				this.holeIndex_HolePrevNext.Dispose();
			}
			if (this.currentPuntoWorldPosition.IsCreated)
			{
				this.currentPuntoWorldPosition.Dispose();
			}
			if (this.currentNextWorldPosition.IsCreated)
			{
				this.currentNextWorldPosition.Dispose();
			}
		}

		// Token: 0x040007FC RID: 2044
		public TransformAccessArray rootAccess;

		// Token: 0x040007FD RID: 2045
		public TransformAccessArray prevAccess;

		// Token: 0x040007FE RID: 2046
		public TransformAccessArray puntosAccess;

		// Token: 0x040007FF RID: 2047
		public TransformAccessArray nextAccess;

		// Token: 0x04000800 RID: 2048
		public NativeArray<float3> currentPuntoWorldPosition;

		// Token: 0x04000801 RID: 2049
		public NativeArray<float3> currentNextWorldPosition;

		// Token: 0x04000802 RID: 2050
		public NativeArray<int> nextIndexDePointIndex;

		// Token: 0x04000803 RID: 2051
		public Transform[] rootAccessTEST;

		// Token: 0x04000804 RID: 2052
		public Transform[] prevAccessTEST;

		// Token: 0x04000805 RID: 2053
		public Transform[] puntosAccessTEST;

		// Token: 0x04000806 RID: 2054
		public Transform[] nextAccessTEST;

		// Token: 0x04000807 RID: 2055
		public NativeArray<int4> holeIndex_HolePrevNext;

		// Token: 0x020001AA RID: 426
		[BurstCompile(FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
		private struct GetCurrentWorldPosition : IJobParallelForTransform
		{
			// Token: 0x06000A21 RID: 2593 RVA: 0x0002DC60 File Offset: 0x0002BE60
			public void Execute(int index, TransformAccess other)
			{
				this.currentWorldPosition[index] = (other.isValid ? other.position : default(Vector3));
			}

			// Token: 0x04000808 RID: 2056
			[WriteOnly]
			public NativeArray<float3> currentWorldPosition;
		}

		// Token: 0x020001AB RID: 427
		[BurstCompile(FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
		private struct SetCurrentWorldPosition : IJobParallelForTransform
		{
			// Token: 0x06000A22 RID: 2594 RVA: 0x0002DC99 File Offset: 0x0002BE99
			public void Execute(int index, TransformAccess other)
			{
				if (other.isValid)
				{
					other.position = this.currentWorldPosition[index];
				}
			}

			// Token: 0x04000809 RID: 2057
			[ReadOnly]
			public NativeArray<float3> currentWorldPosition;
		}
	}
}
