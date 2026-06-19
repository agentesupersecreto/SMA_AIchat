using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02000005 RID: 5
[AddComponentMenu("")]
public class AmplifyOcclusionBase : MonoBehaviour
{
	// Token: 0x0600000C RID: 12 RVA: 0x00004758 File Offset: 0x00002958
	private bool CheckParamsChanged()
	{
		return this.prevScreenWidth != this.m_camera.pixelWidth || this.prevScreenHeight != this.m_camera.pixelHeight || this.prevHDR != this.m_camera.allowHDR || this.prevApplyMethod != this.ApplyMethod || this.prevSampleCount != this.SampleCount || this.prevPerPixelNormals != this.PerPixelNormals || this.prevCacheAware != this.CacheAware || this.prevDownscale != this.Downsample || this.prevBlurEnabled != this.BlurEnabled || this.prevBlurRadius != this.BlurRadius || this.prevBlurPasses != this.BlurPasses;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x0000481C File Offset: 0x00002A1C
	private void UpdateParams()
	{
		this.prevScreenWidth = this.m_camera.pixelWidth;
		this.prevScreenHeight = this.m_camera.pixelHeight;
		this.prevHDR = this.m_camera.allowHDR;
		this.prevApplyMethod = this.ApplyMethod;
		this.prevSampleCount = this.SampleCount;
		this.prevPerPixelNormals = this.PerPixelNormals;
		this.prevCacheAware = this.CacheAware;
		this.prevDownscale = this.Downsample;
		this.prevBlurEnabled = this.BlurEnabled;
		this.prevBlurRadius = this.BlurRadius;
		this.prevBlurPasses = this.BlurPasses;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000048BC File Offset: 0x00002ABC
	private void Warmup()
	{
		this.CheckMaterial();
		this.CheckRandomData();
		this.m_depthLayerRT = new int[16];
		this.m_normalLayerRT = new int[16];
		this.m_occlusionLayerRT = new int[16];
		this.m_mrtCount = Mathf.Min(SystemInfo.supportedRenderTargetCount, 4);
		this.m_layerOffsetNames = new string[this.m_mrtCount];
		this.m_layerRandomNames = new string[this.m_mrtCount];
		for (int i = 0; i < this.m_mrtCount; i++)
		{
			this.m_layerOffsetNames[i] = "_AO_LayerOffset" + i.ToString();
			this.m_layerRandomNames[i] = "_AO_LayerRandom" + i.ToString();
		}
		this.m_layerDepthNames = new string[16];
		this.m_layerNormalNames = new string[16];
		this.m_layerOcclusionNames = new string[16];
		for (int j = 0; j < 16; j++)
		{
			this.m_layerDepthNames[j] = "_AO_DepthLayer" + j.ToString();
			this.m_layerNormalNames[j] = "_AO_NormalLayer" + j.ToString();
			this.m_layerOcclusionNames[j] = "_AO_OcclusionLayer" + j.ToString();
		}
		this.m_depthTargets = new RenderTargetIdentifier[this.m_mrtCount];
		this.m_normalTargets = new RenderTargetIdentifier[this.m_mrtCount];
		if (this.m_mrtCount == 4)
		{
			this.m_deinterleaveDepthPass = 10;
			this.m_deinterleaveNormalPass = 11;
		}
		else
		{
			this.m_deinterleaveDepthPass = 5;
			this.m_deinterleaveNormalPass = 6;
		}
		this.m_applyDeferredTargets = new RenderTargetIdentifier[2];
		if (this.m_blitMesh != null)
		{
			Object.DestroyImmediate(this.m_blitMesh);
		}
		this.m_blitMesh = new Mesh();
		this.m_blitMesh.vertices = new Vector3[]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(1f, 1f, 0f),
			new Vector3(1f, 0f, 0f)
		};
		this.m_blitMesh.uv = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 0f)
		};
		this.m_blitMesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00004B70 File Offset: 0x00002D70
	private void Shutdown()
	{
		this.CommandBuffer_UnregisterAll();
		this.SafeReleaseRT(ref this.m_occlusionRT);
		if (this.m_occlusionMat != null)
		{
			Object.DestroyImmediate(this.m_occlusionMat);
		}
		if (this.m_blurMat != null)
		{
			Object.DestroyImmediate(this.m_blurMat);
		}
		if (this.m_copyMat != null)
		{
			Object.DestroyImmediate(this.m_copyMat);
		}
		if (this.m_randomTex != null)
		{
			Object.DestroyImmediate(this.m_randomTex);
		}
		if (this.m_blitMesh != null)
		{
			Object.DestroyImmediate(this.m_blitMesh);
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00004C0C File Offset: 0x00002E0C
	private void OnEnable()
	{
		this.m_camera = base.GetComponent<Camera>();
		this.Warmup();
		this.CommandBuffer_UnregisterAll();
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00004C26 File Offset: 0x00002E26
	private void OnDisable()
	{
		this.Shutdown();
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00004C2E File Offset: 0x00002E2E
	private void OnDestroy()
	{
		this.Shutdown();
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00004C38 File Offset: 0x00002E38
	private void Update()
	{
		if (this.m_camera.actualRenderingPath != RenderingPath.DeferredShading)
		{
			if (this.PerPixelNormals != AmplifyOcclusionBase.PerPixelNormalSource.None && this.PerPixelNormals != AmplifyOcclusionBase.PerPixelNormalSource.Camera)
			{
				this.PerPixelNormals = AmplifyOcclusionBase.PerPixelNormalSource.Camera;
				Debug.LogWarning("[AmplifyOcclusion] GBuffer Normals only available in Camera Deferred Shading mode. Switched to Camera source.");
			}
			if (this.ApplyMethod == AmplifyOcclusionBase.ApplicationMethod.Deferred)
			{
				this.ApplyMethod = AmplifyOcclusionBase.ApplicationMethod.PostEffect;
				Debug.LogWarning("[AmplifyOcclusion] Deferred Method requires a Deferred Shading path. Switching to Post Effect Method.");
			}
		}
		if (this.ApplyMethod == AmplifyOcclusionBase.ApplicationMethod.Deferred && this.PerPixelNormals == AmplifyOcclusionBase.PerPixelNormalSource.Camera)
		{
			this.PerPixelNormals = AmplifyOcclusionBase.PerPixelNormalSource.GBuffer;
			Debug.LogWarning("[AmplifyOcclusion] Camera Normals not supported for Deferred Method. Switching to GBuffer Normals.");
		}
		if ((this.m_camera.depthTextureMode & DepthTextureMode.Depth) == DepthTextureMode.None)
		{
			this.m_camera.depthTextureMode |= DepthTextureMode.Depth;
		}
		if (this.PerPixelNormals == AmplifyOcclusionBase.PerPixelNormalSource.Camera && (this.m_camera.depthTextureMode & DepthTextureMode.DepthNormals) == DepthTextureMode.None)
		{
			this.m_camera.depthTextureMode |= DepthTextureMode.DepthNormals;
		}
		this.CheckMaterial();
		this.CheckRandomData();
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00004D0C File Offset: 0x00002F0C
	private void CheckMaterial()
	{
		if (this.m_occlusionMat == null)
		{
			this.m_occlusionMat = new Material(Shader.Find("Hidden/Amplify Occlusion/Occlusion"))
			{
				hideFlags = HideFlags.DontSave
			};
		}
		if (this.m_blurMat == null)
		{
			this.m_blurMat = new Material(Shader.Find("Hidden/Amplify Occlusion/Blur"))
			{
				hideFlags = HideFlags.DontSave
			};
		}
		if (this.m_copyMat == null)
		{
			this.m_copyMat = new Material(Shader.Find("Hidden/Amplify Occlusion/Copy"))
			{
				hideFlags = HideFlags.DontSave
			};
		}
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00004D9A File Offset: 0x00002F9A
	private void CheckRandomData()
	{
		if (this.m_randomData == null)
		{
			this.m_randomData = AmplifyOcclusionBase.GenerateRandomizationData();
		}
		if (this.m_randomTex == null)
		{
			this.m_randomTex = AmplifyOcclusionBase.GenerateRandomizationTexture(this.m_randomData);
		}
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00004DD0 File Offset: 0x00002FD0
	public static Color[] GenerateRandomizationData()
	{
		Color[] array = new Color[16];
		int i = 0;
		int num = 0;
		while (i < 16)
		{
			float num2 = RandomTable.Values[num++];
			float num3 = RandomTable.Values[num++];
			float num4 = 6.2831855f * num2 / 8f;
			array[i].r = Mathf.Cos(num4);
			array[i].g = Mathf.Sin(num4);
			array[i].b = num3;
			array[i].a = 0f;
			i++;
		}
		return array;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00004E62 File Offset: 0x00003062
	public static Texture2D GenerateRandomizationTexture(Color[] randomPixels)
	{
		Texture2D texture2D = new Texture2D(4, 4, TextureFormat.ARGB32, false, true);
		texture2D.hideFlags = HideFlags.DontSave;
		texture2D.name = "RandomTexture";
		texture2D.filterMode = FilterMode.Point;
		texture2D.wrapMode = TextureWrapMode.Repeat;
		texture2D.SetPixels(randomPixels);
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00004E9C File Offset: 0x0000309C
	private RenderTexture SafeAllocateRT(string name, int width, int height, RenderTextureFormat format, RenderTextureReadWrite readWrite)
	{
		width = Mathf.Max(width, 1);
		height = Mathf.Max(height, 1);
		RenderTexture renderTexture = new RenderTexture(width, height, 0, format, readWrite);
		renderTexture.hideFlags = HideFlags.DontSave;
		renderTexture.name = name;
		renderTexture.filterMode = FilterMode.Point;
		renderTexture.wrapMode = TextureWrapMode.Clamp;
		renderTexture.Create();
		return renderTexture;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00004EEB File Offset: 0x000030EB
	private void SafeReleaseRT(ref RenderTexture rt)
	{
		if (rt != null)
		{
			RenderTexture.active = null;
			rt.Release();
			Object.DestroyImmediate(rt);
			rt = null;
		}
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00004F10 File Offset: 0x00003110
	private int SafeAllocateTemporaryRT(CommandBuffer cb, string propertyName, int width, int height, RenderTextureFormat format = RenderTextureFormat.Default, RenderTextureReadWrite readWrite = RenderTextureReadWrite.Default, FilterMode filterMode = FilterMode.Point)
	{
		int num = Shader.PropertyToID(propertyName);
		cb.GetTemporaryRT(num, width, height, 0, filterMode, format, readWrite);
		return num;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00004F36 File Offset: 0x00003136
	private void SafeReleaseTemporaryRT(CommandBuffer cb, int id)
	{
		cb.ReleaseTemporaryRT(id);
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00004F40 File Offset: 0x00003140
	private void SetBlitTarget(CommandBuffer cb, RenderTargetIdentifier[] targets, int targetWidth, int targetHeight)
	{
		cb.SetGlobalVector("_AO_Target_TexelSize", new Vector4(1f / (float)targetWidth, 1f / (float)targetHeight, (float)targetWidth, (float)targetHeight));
		cb.SetGlobalVector("_AO_Target_Position", Vector2.zero);
		cb.SetRenderTarget(targets, targets[0]);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00004F96 File Offset: 0x00003196
	private void SetBlitTarget(CommandBuffer cb, RenderTargetIdentifier target, int targetWidth, int targetHeight)
	{
		cb.SetGlobalVector("_AO_Target_TexelSize", new Vector4(1f / (float)targetWidth, 1f / (float)targetHeight, (float)targetWidth, (float)targetHeight));
		cb.SetRenderTarget(target);
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00004FC5 File Offset: 0x000031C5
	private void PerformBlit(CommandBuffer cb, Material mat, int pass)
	{
		cb.DrawMesh(this.m_blitMesh, Matrix4x4.identity, mat, 0, pass);
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00004FDB File Offset: 0x000031DB
	private void PerformBlit(CommandBuffer cb, Material mat, int pass, int x, int y)
	{
		cb.SetGlobalVector("_AO_Target_Position", new Vector2((float)x, (float)y));
		this.PerformBlit(cb, mat, pass);
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00005001 File Offset: 0x00003201
	private void PerformBlit(CommandBuffer cb, RenderTargetIdentifier source, int sourceWidth, int sourceHeight, Material mat, int pass)
	{
		cb.SetGlobalTexture("_AO_Source", source);
		cb.SetGlobalVector("_AO_Source_TexelSize", new Vector4(1f / (float)sourceWidth, 1f / (float)sourceHeight, (float)sourceWidth, (float)sourceHeight));
		this.PerformBlit(cb, mat, pass);
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00005040 File Offset: 0x00003240
	private void PerformBlit(CommandBuffer cb, RenderTargetIdentifier source, int sourceWidth, int sourceHeight, Material mat, int pass, int x, int y)
	{
		cb.SetGlobalVector("_AO_Target_Position", new Vector2((float)x, (float)y));
		this.PerformBlit(cb, source, sourceWidth, sourceHeight, mat, pass);
	}

	// Token: 0x06000022 RID: 34 RVA: 0x0000506C File Offset: 0x0000326C
	private CommandBuffer CommandBuffer_Allocate(string name)
	{
		return new CommandBuffer
		{
			name = name
		};
	}

	// Token: 0x06000023 RID: 35 RVA: 0x0000507A File Offset: 0x0000327A
	private void CommandBuffer_Register(CameraEvent cameraEvent, CommandBuffer commandBuffer)
	{
		this.m_camera.AddCommandBuffer(cameraEvent, commandBuffer);
		this.m_registeredCommandBuffers.Add(cameraEvent, commandBuffer);
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00005098 File Offset: 0x00003298
	private void CommandBuffer_Unregister(CameraEvent cameraEvent, CommandBuffer commandBuffer)
	{
		if (this.m_camera != null)
		{
			foreach (CommandBuffer commandBuffer2 in this.m_camera.GetCommandBuffers(cameraEvent))
			{
				if (commandBuffer2.name == commandBuffer.name)
				{
					this.m_camera.RemoveCommandBuffer(cameraEvent, commandBuffer2);
				}
			}
		}
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000050F4 File Offset: 0x000032F4
	private CommandBuffer CommandBuffer_AllocateRegister(CameraEvent cameraEvent)
	{
		string text = "";
		if (cameraEvent == CameraEvent.BeforeReflections)
		{
			text = "AO-BeforeRefl";
		}
		else if (cameraEvent == CameraEvent.AfterLighting)
		{
			text = "AO-AfterLighting";
		}
		else if (cameraEvent == CameraEvent.BeforeImageEffectsOpaque)
		{
			text = "AO-BeforePostOpaque";
		}
		else
		{
			Debug.LogError("[AmplifyOcclusion] Unsupported CameraEvent. Please contact support.");
		}
		CommandBuffer commandBuffer = this.CommandBuffer_Allocate(text);
		this.CommandBuffer_Register(cameraEvent, commandBuffer);
		return commandBuffer;
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00005148 File Offset: 0x00003348
	private void CommandBuffer_UnregisterAll()
	{
		foreach (KeyValuePair<CameraEvent, CommandBuffer> keyValuePair in this.m_registeredCommandBuffers)
		{
			this.CommandBuffer_Unregister(keyValuePair.Key, keyValuePair.Value);
		}
		this.m_registeredCommandBuffers.Clear();
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000051B4 File Offset: 0x000033B4
	private void UpdateGlobalShaderConstants(AmplifyOcclusionBase.TargetDesc target)
	{
		float num = this.m_camera.fieldOfView * 0.017453292f;
		Vector2 vector = new Vector2(1f / Mathf.Tan(num * 0.5f) * ((float)target.height / (float)target.width), 1f / Mathf.Tan(num * 0.5f));
		Vector2 vector2 = new Vector2(1f / vector.x, 1f / vector.y);
		float num2;
		if (this.m_camera.orthographic)
		{
			num2 = (float)target.height / this.m_camera.orthographicSize;
		}
		else
		{
			num2 = (float)target.height / (Mathf.Tan(num * 0.5f) * 2f);
		}
		float num3 = Mathf.Clamp(this.Bias, 0f, 1f);
		Shader.SetGlobalMatrix("_AO_CameraProj", GL.GetGPUProjectionMatrix(Matrix4x4.Ortho(0f, 1f, 0f, 1f, -1f, 100f), false));
		Shader.SetGlobalMatrix("_AO_CameraView", this.m_camera.worldToCameraMatrix);
		Shader.SetGlobalVector("_AO_UVToView", new Vector4(2f * vector2.x, -2f * vector2.y, -1f * vector2.x, 1f * vector2.y));
		Shader.SetGlobalFloat("_AO_NegRcpR2", -1f / (this.Radius * this.Radius));
		Shader.SetGlobalFloat("_AO_RadiusToScreen", this.Radius * 0.5f * num2);
		Shader.SetGlobalFloat("_AO_PowExponent", this.PowerExponent);
		Shader.SetGlobalFloat("_AO_Bias", num3);
		Shader.SetGlobalFloat("_AO_Multiplier", 1f / (1f - num3));
		Shader.SetGlobalFloat("_AO_BlurSharpness", this.BlurSharpness);
		Shader.SetGlobalColor("_AO_Levels", new Color(this.Tint.r, this.Tint.g, this.Tint.b, this.Intensity));
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000053B8 File Offset: 0x000035B8
	private void CommandBuffer_FillComputeOcclusion(CommandBuffer cb, AmplifyOcclusionBase.TargetDesc target)
	{
		this.CheckMaterial();
		this.CheckRandomData();
		cb.SetGlobalVector("_AO_Buffer_PadScale", new Vector4(target.padRatioWidth, target.padRatioHeight, 1f / target.padRatioWidth, 1f / target.padRatioHeight));
		cb.SetGlobalVector("_AO_Buffer_TexelSize", new Vector4(1f / (float)target.width, 1f / (float)target.height, (float)target.width, (float)target.height));
		cb.SetGlobalVector("_AO_QuarterBuffer_TexelSize", new Vector4(1f / (float)target.quarterWidth, 1f / (float)target.quarterHeight, (float)target.quarterWidth, (float)target.quarterHeight));
		cb.SetGlobalFloat("_AO_MaxRadiusPixels", (float)Mathf.Min(target.width, target.height));
		if (this.m_occlusionRT == null || this.m_occlusionRT.width != target.width || this.m_occlusionRT.height != target.height || !this.m_occlusionRT.IsCreated())
		{
			this.SafeReleaseRT(ref this.m_occlusionRT);
			this.m_occlusionRT = this.SafeAllocateRT("_AO_OcclusionTexture", target.width, target.height, RenderTextureFormat.RGHalf, RenderTextureReadWrite.Linear);
		}
		int num = -1;
		if (this.Downsample)
		{
			num = this.SafeAllocateTemporaryRT(cb, "_AO_SmallOcclusionTexture", target.width / 2, target.height / 2, RenderTextureFormat.RGHalf, RenderTextureReadWrite.Linear, FilterMode.Bilinear);
		}
		if (this.CacheAware && !this.Downsample)
		{
			int num2 = this.SafeAllocateTemporaryRT(cb, "_AO_OcclusionAtlas", target.width, target.height, RenderTextureFormat.RGHalf, RenderTextureReadWrite.Linear, FilterMode.Point);
			for (int i = 0; i < 16; i++)
			{
				this.m_depthLayerRT[i] = this.SafeAllocateTemporaryRT(cb, this.m_layerDepthNames[i], target.quarterWidth, target.quarterHeight, RenderTextureFormat.RFloat, RenderTextureReadWrite.Linear, FilterMode.Point);
				this.m_normalLayerRT[i] = this.SafeAllocateTemporaryRT(cb, this.m_layerNormalNames[i], target.quarterWidth, target.quarterHeight, RenderTextureFormat.ARGB2101010, RenderTextureReadWrite.Linear, FilterMode.Point);
				this.m_occlusionLayerRT[i] = this.SafeAllocateTemporaryRT(cb, this.m_layerOcclusionNames[i], target.quarterWidth, target.quarterHeight, RenderTextureFormat.RGHalf, RenderTextureReadWrite.Linear, FilterMode.Point);
			}
			for (int j = 0; j < 16; j += this.m_mrtCount)
			{
				for (int k = 0; k < this.m_mrtCount; k++)
				{
					int num3 = k + j;
					int num4 = num3 & 3;
					int num5 = num3 >> 2;
					cb.SetGlobalVector(this.m_layerOffsetNames[k], new Vector2((float)num4 + 0.5f, (float)num5 + 0.5f));
					this.m_depthTargets[k] = this.m_depthLayerRT[num3];
					this.m_normalTargets[k] = this.m_normalLayerRT[num3];
				}
				this.SetBlitTarget(cb, this.m_depthTargets, target.quarterWidth, target.quarterHeight);
				this.PerformBlit(cb, this.m_occlusionMat, this.m_deinterleaveDepthPass);
				this.SetBlitTarget(cb, this.m_normalTargets, target.quarterWidth, target.quarterHeight);
				this.PerformBlit(cb, this.m_occlusionMat, (int)(this.m_deinterleaveNormalPass + this.PerPixelNormals));
			}
			for (int l = 0; l < 16; l++)
			{
				cb.SetGlobalVector("_AO_LayerOffset", new Vector2((float)(l & 3) + 0.5f, (float)(l >> 2) + 0.5f));
				cb.SetGlobalVector("_AO_LayerRandom", this.m_randomData[l]);
				cb.SetGlobalTexture("_AO_NormalTexture", this.m_normalLayerRT[l]);
				cb.SetGlobalTexture("_AO_DepthTexture", this.m_depthLayerRT[l]);
				this.SetBlitTarget(cb, this.m_occlusionLayerRT[l], target.quarterWidth, target.quarterHeight);
				this.PerformBlit(cb, this.m_occlusionMat, (int)(15 + this.SampleCount));
			}
			this.SetBlitTarget(cb, num2, target.width, target.height);
			for (int m = 0; m < 16; m++)
			{
				int num6 = (m & 3) * target.quarterWidth;
				int num7 = (m >> 2) * target.quarterHeight;
				this.PerformBlit(cb, this.m_occlusionLayerRT[m], target.quarterWidth, target.quarterHeight, this.m_copyMat, 0, num6, num7);
			}
			cb.SetGlobalTexture("_AO_OcclusionAtlas", num2);
			this.SetBlitTarget(cb, this.m_occlusionRT, target.width, target.height);
			this.PerformBlit(cb, this.m_occlusionMat, 19);
			for (int n = 0; n < 16; n++)
			{
				this.SafeReleaseTemporaryRT(cb, this.m_occlusionLayerRT[n]);
				this.SafeReleaseTemporaryRT(cb, this.m_normalLayerRT[n]);
				this.SafeReleaseTemporaryRT(cb, this.m_depthLayerRT[n]);
			}
			this.SafeReleaseTemporaryRT(cb, num2);
		}
		else
		{
			this.m_occlusionMat.SetTexture("_AO_RandomTexture", this.m_randomTex);
			int num8 = (int)(20 + this.SampleCount * (AmplifyOcclusionBase.SampleCountLevel)4 + (int)this.PerPixelNormals);
			if (this.Downsample)
			{
				cb.Blit(null, new RenderTargetIdentifier(num), this.m_occlusionMat, num8);
				this.SetBlitTarget(cb, this.m_occlusionRT, target.width, target.height);
				this.PerformBlit(cb, num, target.width / 2, target.height / 2, this.m_occlusionMat, 41);
			}
			else
			{
				cb.Blit(null, this.m_occlusionRT, this.m_occlusionMat, num8);
			}
		}
		if (this.BlurEnabled)
		{
			int num9 = this.SafeAllocateTemporaryRT(cb, "_AO_TEMP", target.width, target.height, RenderTextureFormat.RGHalf, RenderTextureReadWrite.Linear, FilterMode.Point);
			for (int num10 = 0; num10 < this.BlurPasses; num10++)
			{
				this.SetBlitTarget(cb, num9, target.width, target.height);
				this.PerformBlit(cb, this.m_occlusionRT, target.width, target.height, this.m_blurMat, (this.BlurRadius - 1) * 2);
				this.SetBlitTarget(cb, this.m_occlusionRT, target.width, target.height);
				this.PerformBlit(cb, num9, target.width, target.height, this.m_blurMat, 1 + (this.BlurRadius - 1) * 2);
			}
			this.SafeReleaseTemporaryRT(cb, num9);
		}
		if (this.Downsample && num >= 0)
		{
			this.SafeReleaseTemporaryRT(cb, num);
		}
		cb.SetRenderTarget(null);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00005A4C File Offset: 0x00003C4C
	private void CommandBuffer_FillApplyDeferred(CommandBuffer cb, AmplifyOcclusionBase.TargetDesc target, bool logTarget)
	{
		cb.SetGlobalTexture("_AO_OcclusionTexture", this.m_occlusionRT);
		this.m_applyDeferredTargets[0] = BuiltinRenderTextureType.GBuffer0;
		this.m_applyDeferredTargets[1] = (logTarget ? BuiltinRenderTextureType.GBuffer3 : BuiltinRenderTextureType.CameraTarget);
		if (!logTarget)
		{
			this.SetBlitTarget(cb, this.m_applyDeferredTargets, target.fullWidth, target.fullHeight);
			this.PerformBlit(cb, this.m_occlusionMat, 37);
		}
		else
		{
			int num = this.SafeAllocateTemporaryRT(cb, "_AO_GBufferAlbedo", target.fullWidth, target.fullHeight, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, FilterMode.Point);
			int num2 = this.SafeAllocateTemporaryRT(cb, "_AO_GBufferEmission", target.fullWidth, target.fullHeight, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, FilterMode.Point);
			cb.Blit(this.m_applyDeferredTargets[0], num);
			cb.Blit(this.m_applyDeferredTargets[1], num2);
			cb.SetGlobalTexture("_AO_GBufferAlbedo", num);
			cb.SetGlobalTexture("_AO_GBufferEmission", num2);
			this.SetBlitTarget(cb, this.m_applyDeferredTargets, target.fullWidth, target.fullHeight);
			this.PerformBlit(cb, this.m_occlusionMat, 38);
			this.SafeReleaseTemporaryRT(cb, num);
			this.SafeReleaseTemporaryRT(cb, num2);
		}
		cb.SetRenderTarget(null);
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00005B9C File Offset: 0x00003D9C
	private void CommandBuffer_FillApplyPostEffect(CommandBuffer cb, AmplifyOcclusionBase.TargetDesc target, bool logTarget)
	{
		cb.SetGlobalTexture("_AO_OcclusionTexture", this.m_occlusionRT);
		if (!logTarget)
		{
			this.SetBlitTarget(cb, BuiltinRenderTextureType.CameraTarget, target.fullWidth, target.fullHeight);
			this.PerformBlit(cb, this.m_occlusionMat, 39);
		}
		else
		{
			int num = this.SafeAllocateTemporaryRT(cb, "_AO_GBufferEmission", target.fullWidth, target.fullHeight, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, FilterMode.Point);
			cb.Blit(BuiltinRenderTextureType.GBuffer3, num);
			cb.SetGlobalTexture("_AO_GBufferEmission", num);
			this.SetBlitTarget(cb, BuiltinRenderTextureType.GBuffer3, target.fullWidth, target.fullHeight);
			this.PerformBlit(cb, this.m_occlusionMat, 40);
			this.SafeReleaseTemporaryRT(cb, num);
		}
		cb.SetRenderTarget(null);
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00005C6C File Offset: 0x00003E6C
	private void CommandBuffer_FillApplyDebug(CommandBuffer cb, AmplifyOcclusionBase.TargetDesc target)
	{
		cb.SetGlobalTexture("_AO_OcclusionTexture", this.m_occlusionRT);
		this.SetBlitTarget(cb, BuiltinRenderTextureType.CameraTarget, target.fullWidth, target.fullHeight);
		this.PerformBlit(cb, this.m_occlusionMat, 36);
		cb.SetRenderTarget(null);
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00005CC4 File Offset: 0x00003EC4
	private void CommandBuffer_Rebuild(AmplifyOcclusionBase.TargetDesc target)
	{
		bool flag = this.PerPixelNormals == AmplifyOcclusionBase.PerPixelNormalSource.GBuffer || this.PerPixelNormals == AmplifyOcclusionBase.PerPixelNormalSource.GBufferOctaEncoded;
		CameraEvent cameraEvent = (flag ? CameraEvent.AfterLighting : CameraEvent.BeforeImageEffectsOpaque);
		CommandBuffer commandBuffer;
		if (this.ApplyMethod == AmplifyOcclusionBase.ApplicationMethod.Debug)
		{
			commandBuffer = this.CommandBuffer_AllocateRegister(cameraEvent);
			this.CommandBuffer_FillComputeOcclusion(commandBuffer, target);
			this.CommandBuffer_FillApplyDebug(commandBuffer, target);
			return;
		}
		bool flag2 = !this.m_camera.allowHDR && flag;
		cameraEvent = ((this.ApplyMethod == AmplifyOcclusionBase.ApplicationMethod.Deferred) ? CameraEvent.BeforeReflections : cameraEvent);
		commandBuffer = this.CommandBuffer_AllocateRegister(cameraEvent);
		this.CommandBuffer_FillComputeOcclusion(commandBuffer, target);
		if (this.ApplyMethod == AmplifyOcclusionBase.ApplicationMethod.PostEffect)
		{
			this.CommandBuffer_FillApplyPostEffect(commandBuffer, target, flag2);
			return;
		}
		if (this.ApplyMethod == AmplifyOcclusionBase.ApplicationMethod.Deferred)
		{
			this.CommandBuffer_FillApplyDeferred(commandBuffer, target, flag2);
		}
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00005D68 File Offset: 0x00003F68
	private void OnPreRender()
	{
		this.m_target.fullWidth = this.m_camera.pixelWidth;
		this.m_target.fullHeight = this.m_camera.pixelHeight;
		this.m_target.format = (this.m_camera.allowHDR ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32);
		this.m_target.width = (this.CacheAware ? ((this.m_target.fullWidth + 3) & -4) : this.m_target.fullWidth);
		this.m_target.height = (this.CacheAware ? ((this.m_target.fullHeight + 3) & -4) : this.m_target.fullHeight);
		this.m_target.quarterWidth = this.m_target.width / 4;
		this.m_target.quarterHeight = this.m_target.height / 4;
		this.m_target.padRatioWidth = (float)this.m_target.width / (float)this.m_target.fullWidth;
		this.m_target.padRatioHeight = (float)this.m_target.height / (float)this.m_target.fullHeight;
		this.UpdateGlobalShaderConstants(this.m_target);
		if (this.CheckParamsChanged() || this.m_registeredCommandBuffers.Count == 0)
		{
			this.CommandBuffer_UnregisterAll();
			this.CommandBuffer_Rebuild(this.m_target);
			this.UpdateParams();
		}
	}

	// Token: 0x04000049 RID: 73
	[Header("Ambient Occlusion")]
	public AmplifyOcclusionBase.ApplicationMethod ApplyMethod;

	// Token: 0x0400004A RID: 74
	public AmplifyOcclusionBase.SampleCountLevel SampleCount = AmplifyOcclusionBase.SampleCountLevel.Medium;

	// Token: 0x0400004B RID: 75
	public AmplifyOcclusionBase.PerPixelNormalSource PerPixelNormals = AmplifyOcclusionBase.PerPixelNormalSource.Camera;

	// Token: 0x0400004C RID: 76
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x0400004D RID: 77
	public Color Tint = Color.black;

	// Token: 0x0400004E RID: 78
	[Range(0f, 16f)]
	public float Radius = 1f;

	// Token: 0x0400004F RID: 79
	[Range(0f, 16f)]
	public float PowerExponent = 1.8f;

	// Token: 0x04000050 RID: 80
	[Range(0f, 0.99f)]
	public float Bias = 0.05f;

	// Token: 0x04000051 RID: 81
	public bool CacheAware;

	// Token: 0x04000052 RID: 82
	public bool Downsample;

	// Token: 0x04000053 RID: 83
	[Header("Bilateral Blur")]
	public bool BlurEnabled = true;

	// Token: 0x04000054 RID: 84
	[Range(1f, 4f)]
	public int BlurRadius = 2;

	// Token: 0x04000055 RID: 85
	[Range(1f, 4f)]
	public int BlurPasses = 1;

	// Token: 0x04000056 RID: 86
	[Range(0f, 20f)]
	public float BlurSharpness = 10f;

	// Token: 0x04000057 RID: 87
	private const int PerPixelNormalSourceCount = 4;

	// Token: 0x04000058 RID: 88
	private int prevScreenWidth;

	// Token: 0x04000059 RID: 89
	private int prevScreenHeight;

	// Token: 0x0400005A RID: 90
	private bool prevHDR;

	// Token: 0x0400005B RID: 91
	private AmplifyOcclusionBase.ApplicationMethod prevApplyMethod;

	// Token: 0x0400005C RID: 92
	private AmplifyOcclusionBase.SampleCountLevel prevSampleCount;

	// Token: 0x0400005D RID: 93
	private AmplifyOcclusionBase.PerPixelNormalSource prevPerPixelNormals;

	// Token: 0x0400005E RID: 94
	private bool prevCacheAware;

	// Token: 0x0400005F RID: 95
	private bool prevDownscale;

	// Token: 0x04000060 RID: 96
	private bool prevBlurEnabled;

	// Token: 0x04000061 RID: 97
	private int prevBlurRadius;

	// Token: 0x04000062 RID: 98
	private int prevBlurPasses;

	// Token: 0x04000063 RID: 99
	private Camera m_camera;

	// Token: 0x04000064 RID: 100
	private Material m_occlusionMat;

	// Token: 0x04000065 RID: 101
	private Material m_blurMat;

	// Token: 0x04000066 RID: 102
	private Material m_copyMat;

	// Token: 0x04000067 RID: 103
	private Texture2D m_randomTex;

	// Token: 0x04000068 RID: 104
	private const int RandomSize = 4;

	// Token: 0x04000069 RID: 105
	private const int DirectionCount = 8;

	// Token: 0x0400006A RID: 106
	private Color[] m_randomData;

	// Token: 0x0400006B RID: 107
	private string[] m_layerOffsetNames;

	// Token: 0x0400006C RID: 108
	private string[] m_layerRandomNames;

	// Token: 0x0400006D RID: 109
	private string[] m_layerDepthNames;

	// Token: 0x0400006E RID: 110
	private string[] m_layerNormalNames;

	// Token: 0x0400006F RID: 111
	private string[] m_layerOcclusionNames;

	// Token: 0x04000070 RID: 112
	private RenderTexture m_occlusionRT;

	// Token: 0x04000071 RID: 113
	private int[] m_depthLayerRT;

	// Token: 0x04000072 RID: 114
	private int[] m_normalLayerRT;

	// Token: 0x04000073 RID: 115
	private int[] m_occlusionLayerRT;

	// Token: 0x04000074 RID: 116
	private int m_mrtCount;

	// Token: 0x04000075 RID: 117
	private RenderTargetIdentifier[] m_depthTargets;

	// Token: 0x04000076 RID: 118
	private RenderTargetIdentifier[] m_normalTargets;

	// Token: 0x04000077 RID: 119
	private int m_deinterleaveDepthPass;

	// Token: 0x04000078 RID: 120
	private int m_deinterleaveNormalPass;

	// Token: 0x04000079 RID: 121
	private RenderTargetIdentifier[] m_applyDeferredTargets;

	// Token: 0x0400007A RID: 122
	private Mesh m_blitMesh;

	// Token: 0x0400007B RID: 123
	private AmplifyOcclusionBase.TargetDesc m_target;

	// Token: 0x0400007C RID: 124
	private Dictionary<CameraEvent, CommandBuffer> m_registeredCommandBuffers = new Dictionary<CameraEvent, CommandBuffer>();

	// Token: 0x020000CD RID: 205
	public enum ApplicationMethod
	{
		// Token: 0x04000254 RID: 596
		PostEffect,
		// Token: 0x04000255 RID: 597
		Deferred,
		// Token: 0x04000256 RID: 598
		Debug
	}

	// Token: 0x020000CE RID: 206
	public enum PerPixelNormalSource
	{
		// Token: 0x04000258 RID: 600
		None,
		// Token: 0x04000259 RID: 601
		Camera,
		// Token: 0x0400025A RID: 602
		GBuffer,
		// Token: 0x0400025B RID: 603
		GBufferOctaEncoded
	}

	// Token: 0x020000CF RID: 207
	public enum SampleCountLevel
	{
		// Token: 0x0400025D RID: 605
		Low,
		// Token: 0x0400025E RID: 606
		Medium,
		// Token: 0x0400025F RID: 607
		High,
		// Token: 0x04000260 RID: 608
		VeryHigh
	}

	// Token: 0x020000D0 RID: 208
	private static class ShaderPass
	{
		// Token: 0x04000261 RID: 609
		public const int FullDepth = 0;

		// Token: 0x04000262 RID: 610
		public const int FullNormal_None = 1;

		// Token: 0x04000263 RID: 611
		public const int FullNormal_Camera = 2;

		// Token: 0x04000264 RID: 612
		public const int FullNormal_GBuffer = 3;

		// Token: 0x04000265 RID: 613
		public const int FullNormal_GBufferOctaEncoded = 4;

		// Token: 0x04000266 RID: 614
		public const int DeinterleaveDepth1 = 5;

		// Token: 0x04000267 RID: 615
		public const int DeinterleaveNormal1_None = 6;

		// Token: 0x04000268 RID: 616
		public const int DeinterleaveNormal1_Camera = 7;

		// Token: 0x04000269 RID: 617
		public const int DeinterleaveNormal1_GBuffer = 8;

		// Token: 0x0400026A RID: 618
		public const int DeinterleaveNormal1_GBufferOctaEncoded = 9;

		// Token: 0x0400026B RID: 619
		public const int DeinterleaveDepth4 = 10;

		// Token: 0x0400026C RID: 620
		public const int DeinterleaveNormal4_None = 11;

		// Token: 0x0400026D RID: 621
		public const int DeinterleaveNormal4_Camera = 12;

		// Token: 0x0400026E RID: 622
		public const int DeinterleaveNormal4_GBuffer = 13;

		// Token: 0x0400026F RID: 623
		public const int DeinterleaveNormal4_GBufferOctaEncoded = 14;

		// Token: 0x04000270 RID: 624
		public const int OcclusionCache_Low = 15;

		// Token: 0x04000271 RID: 625
		public const int OcclusionCache_Medium = 16;

		// Token: 0x04000272 RID: 626
		public const int OcclusionCache_High = 17;

		// Token: 0x04000273 RID: 627
		public const int OcclusionCache_VeryHigh = 18;

		// Token: 0x04000274 RID: 628
		public const int Reinterleave = 19;

		// Token: 0x04000275 RID: 629
		public const int OcclusionLow_None = 20;

		// Token: 0x04000276 RID: 630
		public const int OcclusionLow_Camera = 21;

		// Token: 0x04000277 RID: 631
		public const int OcclusionLow_GBuffer = 22;

		// Token: 0x04000278 RID: 632
		public const int OcclusionLow_GBufferOctaEncoded = 23;

		// Token: 0x04000279 RID: 633
		public const int OcclusionMedium_None = 24;

		// Token: 0x0400027A RID: 634
		public const int OcclusionMedium_Camera = 25;

		// Token: 0x0400027B RID: 635
		public const int OcclusionMedium_GBuffer = 26;

		// Token: 0x0400027C RID: 636
		public const int OcclusionMedium_GBufferOctaEncoded = 27;

		// Token: 0x0400027D RID: 637
		public const int OcclusionHigh_None = 28;

		// Token: 0x0400027E RID: 638
		public const int OcclusionHigh_Camera = 29;

		// Token: 0x0400027F RID: 639
		public const int OcclusionHigh_GBuffer = 30;

		// Token: 0x04000280 RID: 640
		public const int OcclusionHigh_GBufferOctaEncoded = 31;

		// Token: 0x04000281 RID: 641
		public const int OcclusionVeryHigh_None = 32;

		// Token: 0x04000282 RID: 642
		public const int OcclusionVeryHigh_Camera = 33;

		// Token: 0x04000283 RID: 643
		public const int OcclusionVeryHigh_GBuffer = 34;

		// Token: 0x04000284 RID: 644
		public const int OcclusionVeryHigh_GBufferNormalEncoded = 35;

		// Token: 0x04000285 RID: 645
		public const int ApplyDebug = 36;

		// Token: 0x04000286 RID: 646
		public const int ApplyDeferred = 37;

		// Token: 0x04000287 RID: 647
		public const int ApplyDeferredLog = 38;

		// Token: 0x04000288 RID: 648
		public const int ApplyPostEffect = 39;

		// Token: 0x04000289 RID: 649
		public const int ApplyPostEffectLog = 40;

		// Token: 0x0400028A RID: 650
		public const int CombineDownsampledOcclusionDepth = 41;

		// Token: 0x0400028B RID: 651
		public const int BlurHorizontal1 = 0;

		// Token: 0x0400028C RID: 652
		public const int BlurVertical1 = 1;

		// Token: 0x0400028D RID: 653
		public const int BlurHorizontal2 = 2;

		// Token: 0x0400028E RID: 654
		public const int BlurVertical2 = 3;

		// Token: 0x0400028F RID: 655
		public const int BlurHorizontal3 = 4;

		// Token: 0x04000290 RID: 656
		public const int BlurVertical3 = 5;

		// Token: 0x04000291 RID: 657
		public const int BlurHorizontal4 = 6;

		// Token: 0x04000292 RID: 658
		public const int BlurVertical4 = 7;

		// Token: 0x04000293 RID: 659
		public const int Copy = 0;
	}

	// Token: 0x020000D1 RID: 209
	private struct TargetDesc
	{
		// Token: 0x04000294 RID: 660
		public int fullWidth;

		// Token: 0x04000295 RID: 661
		public int fullHeight;

		// Token: 0x04000296 RID: 662
		public RenderTextureFormat format;

		// Token: 0x04000297 RID: 663
		public int width;

		// Token: 0x04000298 RID: 664
		public int height;

		// Token: 0x04000299 RID: 665
		public int quarterWidth;

		// Token: 0x0400029A RID: 666
		public int quarterHeight;

		// Token: 0x0400029B RID: 667
		public float padRatioWidth;

		// Token: 0x0400029C RID: 668
		public float padRatioHeight;
	}
}
