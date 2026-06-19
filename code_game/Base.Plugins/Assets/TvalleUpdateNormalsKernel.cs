using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200014A RID: 330
	[Serializable]
	public class TvalleUpdateNormalsKernel : TvalleGPUKernel
	{
		// Token: 0x060009DF RID: 2527 RVA: 0x000201B8 File Offset: 0x0001E3B8
		public TvalleUpdateNormalsKernel(SkinnedMeshRenderer renderer, string ComputeShaderPath, string KernelName)
		{
			this.m_smr = renderer;
			ComputeShader computeShader = Object.Instantiate<ComputeShader>(Resources.Load<ComputeShader>(ComputeShaderPath));
			this.Init(computeShader, KernelName);
			Mesh sharedMesh = this.m_smr.sharedMesh;
			this.m_customNormalsBuffer = new ComputeBuffer(sharedMesh.vertexCount, Marshal.SizeOf(typeof(Vector3)));
			this.m_customNormalsBuffer.SetData(sharedMesh.normals);
			this.m_cs.SetInt("_VertexCount", sharedMesh.vertexCount);
			base.SetBuffer("_CustomNormals", this.m_customNormalsBuffer);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0002024C File Offset: 0x0001E44C
		public void VBufferUpdate(NativeArray<float3> normals)
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (Time.frameCount == this.m_lastFrameCount)
			{
				return;
			}
			if (this.m_cs == null)
			{
				return;
			}
			this.m_lastFrameCount = Time.frameCount;
			int num = 0;
			this.GetVertexBuffer(ref this.m_gb, out num);
			if (this.m_gb != null)
			{
				base.SetBuffer("_VertexBuffer", this.m_gb);
				this.m_cs.SetInt("_VertexBufferStride", this.m_gb.stride);
				this.m_customNormalsBuffer.SetData<float3>(normals);
				base.Dispatch(num);
			}
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x000202E0 File Offset: 0x0001E4E0
		private void GetVertexBuffer(ref GraphicsBuffer vb, out int nbVertex)
		{
			nbVertex = 0;
			GraphicsBuffer graphicsBuffer = vb;
			if (graphicsBuffer != null)
			{
				graphicsBuffer.Dispose();
			}
			if (this.m_smr != null)
			{
				vb = this.m_smr.GetVertexBuffer();
				nbVertex = this.m_smr.sharedMesh.vertexCount;
			}
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0002031F File Offset: 0x0001E51F
		public void Dispose()
		{
			TvalleUpdateNormalsKernel.ReleaseBuffer(ref this.m_customNormalsBuffer);
			TvalleUpdateNormalsKernel.ReleaseBuffer(ref this.m_gb);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00020337 File Offset: 0x0001E537
		private static void ReleaseBuffer(ref ComputeBuffer Buffer)
		{
			if (Buffer != null)
			{
				Buffer.Release();
			}
			Buffer = null;
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x00020347 File Offset: 0x0001E547
		private static void ReleaseBuffer(ref GraphicsBuffer Buffer)
		{
			if (Buffer != null)
			{
				Buffer.Release();
			}
			Buffer = null;
		}

		// Token: 0x04000270 RID: 624
		private SkinnedMeshRenderer m_smr;

		// Token: 0x04000271 RID: 625
		private GraphicsBuffer m_gb;

		// Token: 0x04000272 RID: 626
		private ComputeBuffer m_customNormalsBuffer;

		// Token: 0x04000273 RID: 627
		private int m_lastFrameCount;
	}
}
