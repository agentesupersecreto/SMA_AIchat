using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Assets.TValle.MeshCalcules.BeachGirl.Runtime.ColliderBaker;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using Kalagaan;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.TValle.BeachGirl.Runtime.Skins.Physics
{
	// Token: 0x0200006A RID: 106
	public sealed class PedidoDePhyscisBakeDeSkin : CustomUpdatedMonobehaviourBase, IColliderBakerUserListiner
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00004657 File Offset: 0x00002857
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.m_ClearEvent);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00004664 File Offset: 0x00002864
		public Skin owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000466C File Offset: 0x0000286C
		public int id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00004674 File Offset: 0x00002874
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00004684 File Offset: 0x00002884
		public void Init(Skin Owner, bool afterPhyscis)
		{
			this.InitGpuBaking(Owner);
			this.m_owner = Owner;
			base.gameObject.layer = ConfiguracionGlobal.layersStatic.ignoreAll;
			IMeshColliderBaker meshColliderBaker2;
			if (!afterPhyscis)
			{
				IMeshColliderBaker meshColliderBaker = base.gameObject.AddComponent<ColliderBakerLowPriorityUser>();
				meshColliderBaker2 = meshColliderBaker;
			}
			else
			{
				IMeshColliderBaker meshColliderBaker = base.gameObject.AddComponent<ColliderBakerAfterPhysicsLowPriorityUser>();
				meshColliderBaker2 = meshColliderBaker;
			}
			this.m_Baker = meshColliderBaker2;
			this.m_Baker.enabled = false;
			if (!afterPhyscis)
			{
				this.m_ClearEvent = GlobalUpdater.UpdateType.meshUpdate2;
				base.ReSubscribeToGlobalUpdater();
			}
			this.m_MeshCollider = this.GetComponentNotNull<MeshCollider>();
			this.m_MeshCollider.enabled = false;
			this.m_Mesh = Object.Instantiate<Mesh>(Owner.skinnedMeshRenderer.sharedMesh);
			this.m_Mesh.MarkDynamic();
			this.m_meshID = this.m_Mesh.GetInstanceID();
			this.m_CurrentVertex = new PedidoDePhyscisBakeDeSkin.CurrentVertex(Owner, this.m_Mesh, this);
			base.Initialize();
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000475C File Offset: 0x0000295C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			PedidoDePhyscisBakeDeSkin.CurrentVertex currentVertex = this.m_CurrentVertex;
			if (currentVertex != null)
			{
				currentVertex.Dispose();
			}
			this.AfterCookClean();
			if (this.m_Mesh)
			{
				Object.Destroy(this.m_Mesh);
			}
			if (this.m_MeshCollider)
			{
				Object.Destroy(this.m_MeshCollider);
			}
			this.DestroyGpuBaking();
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x000047C0 File Offset: 0x000029C0
		public void Cook(PedidoDePhyscisBakeDeSkin.IUser user, bool gpu, object extradata)
		{
			if (!this.m_canGpuBakeMesh)
			{
				gpu = false;
			}
			if (user != null)
			{
				this.m_IUsers.Add(user);
				this.m_IUsersData.Add(extradata);
			}
			if (this.m_BakeState == PedidoDePhyscisBakeDeSkin.BakeState.None)
			{
				this.m_failed = false;
				this.m_id = Time.frameCount;
				this.m_MeshCollider.enabled = true;
				this.m_Baker.enabled = true;
				this.m_BakeState = (gpu ? PedidoDePhyscisBakeDeSkin.BakeState.BakingGPU : PedidoDePhyscisBakeDeSkin.BakeState.BakingCPU);
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00004832 File Offset: 0x00002A32
		private void AfterCookClean()
		{
			this.m_IUsers.Clear();
			this.m_IUsersData.Clear();
			this.m_Baker.enabled = false;
			if (this.letMeshColliderEnabled)
			{
				this.m_MeshCollider.enabled = false;
			}
			this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.None;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00004874 File Offset: 0x00002A74
		void IColliderBakerUserListiner.Scheduling(bool firstSchedulingForUser, out int meshID, out bool convex, out bool doColliderBake)
		{
			meshID = this.m_meshID;
			convex = false;
			if (this.m_BakeState == PedidoDePhyscisBakeDeSkin.BakeState.BakingCPU)
			{
				this.<Assets.TValle.MeshCalcules.BeachGirl.Runtime.ColliderBaker.IColliderBakerUserListiner.Scheduling>g__Bake|27_0(true);
				doColliderBake = true;
				this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.Cooking;
				return;
			}
			if (this.m_BakeState == PedidoDePhyscisBakeDeSkin.BakeState.BakingGPU)
			{
				this.<Assets.TValle.MeshCalcules.BeachGirl.Runtime.ColliderBaker.IColliderBakerUserListiner.Scheduling>g__Bake|27_0(true);
				if (this.m_GpuBakingCoroutine != null)
				{
					Debug.LogError("multiple  m_GpuBakingCoroutine se estan ejecutando");
					base.StopCoroutine(this.m_GpuBakingCoroutine);
				}
				doColliderBake = false;
				this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.BakingGPUProcessing;
				this.m_GpuBakingCoroutine = base.StartCoroutine(this.GpuBakeMeshAsync(new Action<bool>(this.OnGpuBaked)));
				return;
			}
			if (this.m_BakeState == PedidoDePhyscisBakeDeSkin.BakeState.BakingGPUProcessing)
			{
				doColliderBake = false;
				this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.BakingGPUProcessing;
				return;
			}
			if (this.m_BakeState == PedidoDePhyscisBakeDeSkin.BakeState.BakingGPUFinnish)
			{
				doColliderBake = true;
				this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.Cooking;
				return;
			}
			Debug.LogException(new ArgumentOutOfRangeException(), this);
			doColliderBake = false;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00004939 File Offset: 0x00002B39
		private void OnGpuBaked(bool exito)
		{
			this.m_GpuBakingCoroutine = null;
			if (!exito)
			{
				Debug.LogError("Cooking mesh failed, restarting using BakingCPU");
				this.m_failed = true;
				this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.BakingCPU;
				return;
			}
			this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.BakingGPUFinnish;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00004968 File Offset: 0x00002B68
		void IColliderBakerUserListiner.Completed(bool didBake)
		{
			if (base.isDestroyed)
			{
				return;
			}
			if (didBake)
			{
				this.m_MeshCollider.sharedMesh = this.m_Mesh;
				if (this.m_MeshCollider.bounds.extents == Vector3.zero && this.m_MeshCollider.attachedRigidbody == null)
				{
					Debug.LogError("Cooking mesh collider failed, restarting using BakingCPU");
					this.m_failed = true;
					this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.BakingCPU;
					return;
				}
				this.m_BakeState = PedidoDePhyscisBakeDeSkin.BakeState.None;
				for (int i = 0; i < this.m_IUsers.Count; i++)
				{
					this.m_IUsers[i].OnCooked(this.m_Mesh, this.m_MeshCollider, this.m_IUsersData[i], this.m_owner, this);
				}
				this.m_flagToAfterCookClean = true;
				this.m_owner.OnCooked(this);
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00004A40 File Offset: 0x00002C40
		public override void OnUpdateEvent1()
		{
			if (this.m_flagToAfterCookClean)
			{
				this.AfterCookClean();
				this.m_flagToAfterCookClean = false;
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00004A57 File Offset: 0x00002C57
		public bool TriangleIndexIsValid(int triangleIndex)
		{
			return triangleIndex >= 0 && this.m_CurrentVertex.triangles.ContieneIndex(triangleIndex * 3 + 2);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00004A74 File Offset: 0x00002C74
		public void GetWorldVerticesOfTriangle(int triangleIndex, out int vertexIndex0, out int vertexIndex1, out int vertexIndex2, out Vector3 vertex0, out Vector3 vertex1, out Vector3 vertex2, out Vector3 wVertex0, out Vector3 wVertex1, out Vector3 wVertex2)
		{
			this.m_CurrentVertex.Refresh(this.m_id);
			int num = triangleIndex * 3;
			try
			{
				vertexIndex0 = this.m_CurrentVertex.triangles[num];
				vertexIndex1 = this.m_CurrentVertex.triangles[num + 1];
				vertexIndex2 = this.m_CurrentVertex.triangles[num + 2];
			}
			catch (Exception ex)
			{
				Debug.LogError("Indice Fuera de Range: " + triangleIndex.ToString() + ", en Skin: " + this.owner.name);
				throw ex;
			}
			vertex0 = this.m_CurrentVertex.skinnedVertices[vertexIndex0];
			vertex1 = this.m_CurrentVertex.skinnedVertices[vertexIndex1];
			vertex2 = this.m_CurrentVertex.skinnedVertices[vertexIndex2];
			Transform transform = this.m_CurrentVertex.renderer.transform;
			wVertex0 = transform.TransformPoint(vertex0);
			wVertex1 = transform.TransformPoint(vertex1);
			wVertex2 = transform.TransformPoint(vertex2);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00004B9C File Offset: 0x00002D9C
		public void GetWorldVerticesOfTriangle(int triangleIndex, out int vertexIndex0, out int vertexIndex1, out int vertexIndex2, out Vector3 vertex0, out Vector3 vertex1, out Vector3 vertex2, out Vector3 normal0, out Vector3 normal1, out Vector3 normal2, out Vector3 tangent0, out Vector3 tangent1, out Vector3 tangent2, out Vector3 wVertex0, out Vector3 wVertex1, out Vector3 wVertex2, out Vector3 wNormal0, out Vector3 wNormal1, out Vector3 wNormal2, out Vector3 wTangent0, out Vector3 wTangent1, out Vector3 wTangent2)
		{
			this.m_CurrentVertex.Refresh(this.m_id);
			int num = triangleIndex * 3;
			try
			{
				vertexIndex0 = this.m_CurrentVertex.triangles[num];
				vertexIndex1 = this.m_CurrentVertex.triangles[num + 1];
				vertexIndex2 = this.m_CurrentVertex.triangles[num + 2];
			}
			catch (Exception ex)
			{
				Debug.LogError("Indice Fuera de Range: " + triangleIndex.ToString() + ", en Skin: " + this.owner.name);
				throw ex;
			}
			vertex0 = this.m_CurrentVertex.skinnedVertices[vertexIndex0];
			vertex1 = this.m_CurrentVertex.skinnedVertices[vertexIndex1];
			vertex2 = this.m_CurrentVertex.skinnedVertices[vertexIndex2];
			normal0 = this.m_CurrentVertex.skinnedNormals[vertexIndex0];
			normal1 = this.m_CurrentVertex.skinnedNormals[vertexIndex1];
			normal2 = this.m_CurrentVertex.skinnedNormals[vertexIndex2];
			tangent0 = this.m_CurrentVertex.skinnedTangents[vertexIndex0];
			tangent1 = this.m_CurrentVertex.skinnedTangents[vertexIndex1];
			tangent2 = this.m_CurrentVertex.skinnedTangents[vertexIndex2];
			Transform transform = this.m_CurrentVertex.renderer.transform;
			wVertex0 = transform.TransformPoint(vertex0);
			wVertex1 = transform.TransformPoint(vertex1);
			wVertex2 = transform.TransformPoint(vertex2);
			wNormal0 = transform.TransformDirection(normal0);
			wNormal1 = transform.TransformDirection(normal1);
			wNormal2 = transform.TransformDirection(normal2);
			wTangent0 = transform.TransformDirection(tangent0);
			wTangent1 = transform.TransformDirection(tangent1);
			wTangent2 = transform.TransformDirection(tangent2);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00004DE4 File Offset: 0x00002FE4
		private static void ReleaseBuffer(ref ComputeBuffer Buffer)
		{
			if (Buffer != null)
			{
				Buffer.Release();
			}
			Buffer = null;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00004DF4 File Offset: 0x00002FF4
		private void InitGpuBaking(Skin Owner)
		{
			this.m_VertExmotionBase = Owner.GetComponent<VertExmotionBase>();
			this.m_canGpuBakeMesh = this.m_VertExmotionBase != null;
			if (this.m_canGpuBakeMesh)
			{
				MethodInfo method = typeof(VertExmotionBase).GetMethod("UpdateComputeShaderArray", BindingFlags.Instance | BindingFlags.NonPublic);
				this.UpdateComputeShaderArrayDelegate = (PedidoDePhyscisBakeDeSkin.UpdateComputeShaderArrayHandler)Delegate.CreateDelegate(typeof(PedidoDePhyscisBakeDeSkin.UpdateComputeShaderArrayHandler), this.m_VertExmotionBase, method);
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00004E60 File Offset: 0x00003060
		private void DestroyGpuBaking()
		{
			if (this.m_GpuBakingCoroutine != null)
			{
				base.StopCoroutine(this.m_GpuBakingCoroutine);
			}
			this.m_GpuBakingCoroutine = null;
			PedidoDePhyscisBakeDeSkin.ReleaseBuffer(ref this.m_vertexBuff);
			PedidoDePhyscisBakeDeSkin.ReleaseBuffer(ref this.m_normalBuff);
			PedidoDePhyscisBakeDeSkin.ReleaseBuffer(ref this.m_tangentBuff);
			PedidoDePhyscisBakeDeSkin.ReleaseBuffer(ref this.m_colorBuff);
			if (this.m_bakedVertices.IsCreated)
			{
				this.m_bakedVertices.Dispose();
			}
			if (this.m_bakedNormals.IsCreated)
			{
				this.m_bakedNormals.Dispose();
			}
			if (this.m_bakedTangents.IsCreated)
			{
				this.m_bakedTangents.Dispose();
			}
			if (this.m_bakedColors.IsCreated)
			{
				this.m_bakedColors.Dispose();
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00004F14 File Offset: 0x00003114
		private void GpuBakeMeshInit()
		{
			if (this.m_csBake == null)
			{
				this.m_csBake = Object.Instantiate<ComputeShader>(Resources.Load<ComputeShader>("VertExmotionBakeMesh"));
			}
			if (this.m_csBake != null)
			{
				this.m_bakeKernel = this.m_csBake.FindKernel("CSMain");
			}
			if (this.m_vertexBuff == null)
			{
				this.DestroyGpuBaking();
				this.m_bakedVertices = new NativeArray<Vector3>(this.m_Mesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.m_bakedNormals = new NativeArray<Vector3>(this.m_Mesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.m_bakedTangents = new NativeArray<Vector4>(this.m_Mesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.m_bakedColors = new NativeArray<Color>(this.m_Mesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.m_vertexBuff = new ComputeBuffer(this.m_Mesh.vertexCount, Marshal.SizeOf(typeof(Vector3)));
				this.m_normalBuff = new ComputeBuffer(this.m_Mesh.vertexCount, Marshal.SizeOf(typeof(Vector3)));
				this.m_tangentBuff = new ComputeBuffer(this.m_Mesh.vertexCount, Marshal.SizeOf(typeof(Vector4)));
				this.m_colorBuff = new ComputeBuffer(this.m_Mesh.vertexCount, Marshal.SizeOf(typeof(Color)));
				this.m_csBake.SetBuffer(this.m_bakeKernel, "_vertexBuf", this.m_vertexBuff);
				this.m_csBake.SetBuffer(this.m_bakeKernel, "_normalBuf", this.m_normalBuff);
				this.m_csBake.SetBuffer(this.m_bakeKernel, "_tangentBuf", this.m_tangentBuff);
				this.m_csBake.SetBuffer(this.m_bakeKernel, "_colorBuf", this.m_colorBuff);
			}
			this.m_GpuBakeMeshInitialized = true;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x000050E4 File Offset: 0x000032E4
		private IEnumerator GpuBakeMeshAsync(Action<bool> onComplete)
		{
			if (!SystemInfo.supportsComputeShaders)
			{
				Debug.LogError("System doesn't support Compute shaders");
				yield break;
			}
			if (!this.m_GpuBakeMeshInitialized)
			{
				this.GpuBakeMeshInit();
			}
			if (this.m_csBake == null)
			{
				Debug.LogError("'VertExmotionBakeMesh.compute' not found");
				yield break;
			}
			this.m_VertExmotionBase.UpdateShaders();
			this.UpdateComputeShaderArrayDelegate(ref this.m_csBake);
			using (Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(this.m_Mesh))
			{
				Mesh.MeshData meshData = meshDataArray[0];
				meshData.GetVertices(this.m_bakedVertices);
				meshData.GetNormals(this.m_bakedNormals);
				meshData.GetTangents(this.m_bakedTangents);
				meshData.GetColors(this.m_bakedColors);
			}
			this.m_vertexBuff.SetData<Vector3>(this.m_bakedVertices);
			this.m_normalBuff.SetData<Vector3>(this.m_bakedNormals);
			this.m_tangentBuff.SetData<Vector4>(this.m_bakedTangents);
			this.m_colorBuff.SetData<Color>(this.m_bakedColors);
			this.m_csBake.SetMatrix("_ObjectToWorld", this.m_VertExmotionBase.transform.localToWorldMatrix);
			this.m_csBake.SetMatrix("_WorldToObject", this.m_VertExmotionBase.transform.worldToLocalMatrix);
			this.m_csBake.Dispatch(this.m_bakeKernel, Mathf.CeilToInt((float)this.m_Mesh.vertexCount / 512f), 1, 1);
			AsyncGPUReadbackRequest vertexRequest = AsyncGPUReadback.RequestIntoNativeArray<Vector3>(ref this.m_bakedVertices, this.m_vertexBuff, null);
			AsyncGPUReadbackRequest normalRequest = AsyncGPUReadback.RequestIntoNativeArray<Vector3>(ref this.m_bakedNormals, this.m_normalBuff, null);
			yield return new WaitUntil(() => vertexRequest.done && normalRequest.done);
			if (vertexRequest.hasError || normalRequest.hasError)
			{
				Debug.LogError("GPU readback error");
				if (onComplete != null)
				{
					onComplete(false);
				}
				yield break;
			}
			this.m_Mesh.SetVertices<Vector3>(this.m_bakedVertices);
			this.m_Mesh.SetNormals<Vector3>(this.m_bakedNormals);
			if (onComplete != null)
			{
				onComplete(true);
			}
			yield break;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000050FC File Offset: 0x000032FC
		private void GpuBakeMeshSync()
		{
			if (!SystemInfo.supportsComputeShaders)
			{
				Debug.LogError("System doesn't support Compute shaders");
				return;
			}
			if (!this.m_GpuBakeMeshInitialized)
			{
				this.GpuBakeMeshInit();
			}
			if (this.m_csBake == null)
			{
				Debug.LogError("'VertExmotionBakeMesh.compute' not found");
				return;
			}
			this.m_VertExmotionBase.UpdateShaders();
			this.UpdateComputeShaderArrayDelegate(ref this.m_csBake);
			Vector3[] vertices = this.m_Mesh.vertices;
			Vector3[] normals = this.m_Mesh.normals;
			Vector4[] tangents = this.m_Mesh.tangents;
			Color[] colors = this.m_Mesh.colors;
			this.m_vertexBuff.SetData(vertices);
			this.m_normalBuff.SetData(normals);
			this.m_tangentBuff.SetData(tangents);
			this.m_colorBuff.SetData(colors);
			this.m_csBake.SetMatrix("_ObjectToWorld", this.m_VertExmotionBase.transform.localToWorldMatrix);
			this.m_csBake.SetMatrix("_WorldToObject", this.m_VertExmotionBase.transform.worldToLocalMatrix);
			this.m_csBake.Dispatch(this.m_bakeKernel, Mathf.CeilToInt((float)this.m_Mesh.vertexCount / 512f), 1, 1);
			this.m_vertexBuff.GetData(vertices);
			this.m_normalBuff.GetData(normals);
			this.m_Mesh.vertices = vertices;
			this.m_Mesh.normals = normals;
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00005280 File Offset: 0x00003480
		[CompilerGenerated]
		private void <Assets.TValle.MeshCalcules.BeachGirl.Runtime.ColliderBaker.IColliderBakerUserListiner.Scheduling>g__Bake|27_0(bool useScale)
		{
			if (!useScale)
			{
				this.m_owner.skinnedMeshRenderer.BakeMesh(this.m_Mesh);
				return;
			}
			if (!this.m_owner.skinnedMeshRenderer.transform.localScale.Escala().AlmostEqualV2(1f, 1E-45f))
			{
				this.m_owner.skinnedMeshRenderer.BakeMesh(this.m_Mesh, true);
				this.m_Mesh.RecalculateNormals();
				this.m_Mesh.RecalculateTangents();
				return;
			}
			this.m_owner.skinnedMeshRenderer.BakeMesh(this.m_Mesh, true);
		}

		// Token: 0x0400012A RID: 298
		[SerializeField]
		[ReadOnlyUI]
		private GlobalUpdater.UpdateType m_ClearEvent = GlobalUpdater.UpdateType.beforeFixedUpdates3;

		// Token: 0x0400012B RID: 299
		public bool letMeshColliderEnabled;

		// Token: 0x0400012C RID: 300
		private PedidoDePhyscisBakeDeSkin.CurrentVertex m_CurrentVertex;

		// Token: 0x0400012D RID: 301
		[SerializeField]
		[ReadOnlyUI]
		private Skin m_owner;

		// Token: 0x0400012E RID: 302
		[SerializeField]
		[ReadOnlyUI]
		private Mesh m_Mesh;

		// Token: 0x0400012F RID: 303
		[SerializeField]
		[ReadOnlyUI]
		private int m_meshID;

		// Token: 0x04000130 RID: 304
		[SerializeField]
		[ReadOnlyUI]
		private MeshCollider m_MeshCollider;

		// Token: 0x04000131 RID: 305
		[SerializeField]
		[ReadOnlyUI]
		private IMeshColliderBaker m_Baker;

		// Token: 0x04000132 RID: 306
		[ReadOnlyUI]
		[SerializeField]
		private int m_id;

		// Token: 0x04000133 RID: 307
		[ReadOnlyUI]
		[SerializeField]
		private PedidoDePhyscisBakeDeSkin.BakeState m_BakeState;

		// Token: 0x04000134 RID: 308
		[ReadOnlyUI]
		[SerializeField]
		private bool m_failed;

		// Token: 0x04000135 RID: 309
		[ReadOnlyUI]
		[SerializeField]
		private bool m_flagToAfterCookClean;

		// Token: 0x04000136 RID: 310
		[ReadOnlyUI]
		[SerializeField]
		private bool m_GpuBakeMeshInitialized;

		// Token: 0x04000137 RID: 311
		[SerializeReference]
		private List<PedidoDePhyscisBakeDeSkin.IUser> m_IUsers = new List<PedidoDePhyscisBakeDeSkin.IUser>();

		// Token: 0x04000138 RID: 312
		[SerializeField]
		private List<object> m_IUsersData = new List<object>();

		// Token: 0x04000139 RID: 313
		[ReadOnlyUI]
		[SerializeField]
		private bool m_canGpuBakeMesh;

		// Token: 0x0400013A RID: 314
		[ReadOnlyUI]
		[SerializeField]
		private VertExmotionBase m_VertExmotionBase;

		// Token: 0x0400013B RID: 315
		private ComputeShader m_csBake;

		// Token: 0x0400013C RID: 316
		private int m_bakeKernel;

		// Token: 0x0400013D RID: 317
		private ComputeBuffer m_vertexBuff;

		// Token: 0x0400013E RID: 318
		private ComputeBuffer m_normalBuff;

		// Token: 0x0400013F RID: 319
		private ComputeBuffer m_tangentBuff;

		// Token: 0x04000140 RID: 320
		private ComputeBuffer m_colorBuff;

		// Token: 0x04000141 RID: 321
		private NativeArray<Vector3> m_bakedVertices;

		// Token: 0x04000142 RID: 322
		private NativeArray<Vector3> m_bakedNormals;

		// Token: 0x04000143 RID: 323
		private NativeArray<Vector4> m_bakedTangents;

		// Token: 0x04000144 RID: 324
		private NativeArray<Color> m_bakedColors;

		// Token: 0x04000145 RID: 325
		private PedidoDePhyscisBakeDeSkin.UpdateComputeShaderArrayHandler UpdateComputeShaderArrayDelegate;

		// Token: 0x04000146 RID: 326
		private Coroutine m_GpuBakingCoroutine;

		// Token: 0x0200014F RID: 335
		private enum BakeState
		{
			// Token: 0x040007E2 RID: 2018
			None,
			// Token: 0x040007E3 RID: 2019
			BakingCPU,
			// Token: 0x040007E4 RID: 2020
			BakingGPU,
			// Token: 0x040007E5 RID: 2021
			BakingGPUProcessing,
			// Token: 0x040007E6 RID: 2022
			BakingGPUFinnish,
			// Token: 0x040007E7 RID: 2023
			Cooking
		}

		// Token: 0x02000150 RID: 336
		private class CurrentVertex
		{
			// Token: 0x06000DD0 RID: 3536 RVA: 0x0002F93C File Offset: 0x0002DB3C
			public CurrentVertex(Skin owner, Mesh WorkingMesh, PedidoDePhyscisBakeDeSkin Pedido)
			{
				this.workingMesh = WorkingMesh;
				this.renderer = owner.skinnedMeshRenderer;
				this.pedido = Pedido;
				this.triangles = WorkingMesh.triangles;
				this.skinnedVertices = new NativeArray<Vector3>(owner.skinnedMeshRenderer.sharedMesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.skinnedNormals = new NativeArray<Vector3>(owner.skinnedMeshRenderer.sharedMesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.skinnedTangents = new NativeArray<Vector4>(owner.skinnedMeshRenderer.sharedMesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			}

			// Token: 0x06000DD1 RID: 3537 RVA: 0x0002F9CC File Offset: 0x0002DBCC
			public void Refresh(int currentID)
			{
				if (currentID != this.id)
				{
					this.id = currentID;
					using (Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(this.workingMesh))
					{
						Mesh.MeshData meshData = meshDataArray[0];
						meshData.GetVertices(this.skinnedVertices);
						meshData.GetNormals(this.skinnedNormals);
						meshData.GetTangents(this.skinnedTangents);
					}
				}
			}

			// Token: 0x06000DD2 RID: 3538 RVA: 0x0002FA48 File Offset: 0x0002DC48
			public void Dispose()
			{
				if (this.skinnedVertices.IsCreated)
				{
					this.skinnedVertices.Dispose();
				}
				if (this.skinnedNormals.IsCreated)
				{
					this.skinnedNormals.Dispose();
				}
				if (this.skinnedTangents.IsCreated)
				{
					this.skinnedTangents.Dispose();
				}
			}

			// Token: 0x040007E8 RID: 2024
			public int id;

			// Token: 0x040007E9 RID: 2025
			public SkinnedMeshRenderer renderer;

			// Token: 0x040007EA RID: 2026
			public Mesh workingMesh;

			// Token: 0x040007EB RID: 2027
			public PedidoDePhyscisBakeDeSkin pedido;

			// Token: 0x040007EC RID: 2028
			public NativeArray<Vector3> skinnedVertices;

			// Token: 0x040007ED RID: 2029
			public NativeArray<Vector3> skinnedNormals;

			// Token: 0x040007EE RID: 2030
			public NativeArray<Vector4> skinnedTangents;

			// Token: 0x040007EF RID: 2031
			public int[] triangles;
		}

		// Token: 0x02000151 RID: 337
		public interface IUser
		{
			// Token: 0x06000DD3 RID: 3539
			void OnCooked(Mesh mesh, MeshCollider collider, object extraData, Skin cooked, PedidoDePhyscisBakeDeSkin sender);
		}

		// Token: 0x02000152 RID: 338
		// (Invoke) Token: 0x06000DD5 RID: 3541
		private delegate void UpdateComputeShaderArrayHandler(ref ComputeShader cs);
	}
}
