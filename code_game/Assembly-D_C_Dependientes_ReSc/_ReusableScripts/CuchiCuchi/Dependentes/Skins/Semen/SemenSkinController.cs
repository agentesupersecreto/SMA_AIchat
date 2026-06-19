using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.MeshCalcules;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Semens;
using Assets.TValle.BeachGirl.VertExmotions.Runtime.Scripts;
using Assets.TValle.BeachGirl.VertExmotions.Runtime.Scripts.Updaters;
using Assets.TValle.MeshCalcules.Runtime.V2;
using Assets.TValle.MeshCalcules.ShapingSkinningPoints.Runtime.Triangles.SkinningShaping;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Skins.Semen;
using Assets._ReusableScripts.CuchiCuchi.Chars;
using Assets._ReusableScripts.CuchiCuchi.Particulas;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Globales.Updater;
using Kalagaan;
using TValleCustomClases;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen
{
	// Token: 0x02000049 RID: 73
	public sealed class SemenSkinController : AplicableBehaviour, ISemenSkinController
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000C0DD File Offset: 0x0000A2DD
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.meshUpdate3);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000C0E6 File Offset: 0x0000A2E6
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI3);
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x0000C0EF File Offset: 0x0000A2EF
		public IReadOnlyList<SemenSkinController.SemenSkin> semenSkins
		{
			get
			{
				return this.m_SemenSkins;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000C0F7 File Offset: 0x0000A2F7
		public Skin skins
		{
			get
			{
				return this.m_Skin;
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000C100 File Offset: 0x0000A300
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			SemenSkinController.workingSemenParticle.Preparar();
			this.m_Skin = base.GetComponent<Skin>();
			this.m_character = this.GetComponentEnRoot(false);
			this.m_characterAI = this.GetComponentEnRoot(true);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			if (this.m_characterAI == null)
			{
				throw new ArgumentNullException("m_characterAI", "m_characterAI null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000C17F File Offset: 0x0000A37F
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.Unsubscribe();
			this.Subscribe();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000C193 File Offset: 0x0000A393
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Unsubscribe();
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000C1A2 File Offset: 0x0000A3A2
		private void Subscribe()
		{
			if (this.m_Skin != null)
			{
				this.m_Skin.onEnabled += this.M_Skin_onEnabled;
				this.m_Skin.onDisabled += this.M_Skin_onDisabled;
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000C1E0 File Offset: 0x0000A3E0
		private void Unsubscribe()
		{
			if (this.m_Skin != null)
			{
				this.m_Skin.onEnabled -= this.M_Skin_onEnabled;
				this.m_Skin.onDisabled -= this.M_Skin_onDisabled;
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000C220 File Offset: 0x0000A420
		private void M_Skin_onDisabled(object obj)
		{
			for (int i = 0; i < this.m_SemenSkins.Count; i++)
			{
				SemenSkinController.SemenSkin semenSkin = this.m_SemenSkins[i];
				SkinnedMeshRenderer skinnedMeshRenderer = ((semenSkin != null) ? semenSkin.skinnedMeshRenderer : null);
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.enabled = false;
				}
			}
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000C26C File Offset: 0x0000A46C
		private void M_Skin_onEnabled(object obj)
		{
			for (int i = 0; i < this.m_SemenSkins.Count; i++)
			{
				SemenSkinController.SemenSkin semenSkin = this.m_SemenSkins[i];
				SkinnedMeshRenderer skinnedMeshRenderer = ((semenSkin != null) ? semenSkin.skinnedMeshRenderer : null);
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.enabled = true;
				}
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000C2B8 File Offset: 0x0000A4B8
		protected override IEnumerator YieldStartUnityEvent()
		{
			do
			{
				if (this.m_Skin == null)
				{
					this.m_Skin = base.GetComponent<Skin>();
				}
				if (this.m_Skin == null)
				{
					yield return null;
				}
			}
			while (this.m_Skin == null);
			this.Unsubscribe();
			this.Subscribe();
			while (!this.m_Skin.isStared || !this.m_Skin.skinIsAdded)
			{
				yield return null;
			}
			this.m_IMeshGetter = this.m_Skin.skinnedMeshRenderer.GetComponent<IMeshGetter>();
			this.m_IMeshOriginalDataGetter = this.m_Skin.skinnedMeshRenderer.GetComponent<IMeshOriginalDataGetter>();
			this.m_IMeshBoneWeightsDataGetter = this.m_Skin.skinnedMeshRenderer.GetComponent<IMeshBoneWeightsDataGetter>();
			this.m_IMeshBlendShapesDataGetter = this.m_Skin.skinnedMeshRenderer.GetComponent<IMeshBlendShapesDataGetter>();
			this.m_IMeshSkinningDataGetter = this.m_Skin.skinnedMeshRenderer.GetComponent<IMeshSkinningDataGetter>();
			if (this.m_IMeshOriginalDataGetter == null)
			{
				throw new ArgumentNullException("m_IMeshOriginalDataGetter", "m_IMeshOriginalDataGetter null reference.");
			}
			if (this.m_IMeshGetter == null)
			{
				throw new ArgumentNullException("m_IMeshGetter", "m_IMeshGetter null reference.");
			}
			if (this.m_IMeshBoneWeightsDataGetter == null)
			{
				throw new ArgumentNullException("m_IMeshBoneWeightsDataGetter", "m_IMeshBoneWeightsDataGetter null reference.");
			}
			if (this.m_IMeshBlendShapesDataGetter == null)
			{
				throw new ArgumentNullException("m_IMeshBlendShapesDataGetter", "m_IMeshBlendShapesDataGetter null reference.");
			}
			if (this.m_IMeshSkinningDataGetter == null)
			{
				throw new ArgumentNullException("m_IMeshSkinningDataGetter", "m_IMeshSkinningDataGetter null reference.");
			}
			while (!this.m_IMeshGetter.isInitiated || !this.m_IMeshOriginalDataGetter.isInitiated || !this.m_IMeshBoneWeightsDataGetter.isInitiated || !this.m_IMeshSkinningDataGetter.isInitiated)
			{
				yield return null;
			}
			while (!this.m_IMeshBlendShapesDataGetter.isShapeKeysBinded)
			{
				yield return null;
			}
			this.m_SkinData = new SemenSkinController.SkinData();
			this.m_SkinData.Init(this);
			this.m_waitBuffer.bufferTime = this.config.waitTimeToConvertSemenMeshToSkin;
			yield break;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000C2C7 File Offset: 0x0000A4C7
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.ClearPedido();
			SemenSkinController.SkinData skinData = this.m_SkinData;
			if (skinData != null)
			{
				skinData.Dispose();
			}
			this.DestroySemenSkins();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000C2ED File Offset: 0x0000A4ED
		public void Add(SemenMeshToSkinMesh self, SemenMeshToSkinMesh next)
		{
			this.m_enCola.Add(new SemenSkinController.SemenChainPar(self, next));
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000C301 File Offset: 0x0000A501
		public void Add(SemenSelfPointToSemenSkinData Self, SemenPointToSemenSkinData Next)
		{
			this.Add(ref Self, ref Next);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000C30D File Offset: 0x0000A50D
		public void Add(ref SemenSelfPointToSemenSkinData Self, ref SemenPointToSemenSkinData Next)
		{
			if (Self.semenData.existio)
			{
				this.m_enCola.Add(new SemenSkinController.SemenChainPar(ref Self, ref Next));
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000C330 File Offset: 0x0000A530
		private void DestroySemenSkins()
		{
			for (int i = 0; i < this.m_SemenSkins.Count; i++)
			{
				SemenSkinController.SemenSkin semenSkin = this.m_SemenSkins[i];
				if (semenSkin != null)
				{
					semenSkin.Destroy(this);
				}
			}
			this.m_SemenSkins.Clear();
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000C376 File Offset: 0x0000A576
		private void DestroySemenSkin(SemenSkinController.SemenSkin semenSkin)
		{
			this.m_SemenSkins.Remove(semenSkin);
			semenSkin.Destroy(this);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000C38C File Offset: 0x0000A58C
		public override void OnUpdateEvent1()
		{
			try
			{
				switch (this.GetPedidoEstate())
				{
				case SemenSkinController.PedidoEstado.libre:
				{
					if (this.m_enCola.Count <= 0)
					{
						goto IL_0363;
					}
					float num;
					bool flag = this.m_waitBuffer.IsBuffered(true, out num);
					bool flag2 = this.m_enCola.Count >= this.config.maxParticlesWaiting;
					if ((!this.flagDontWait || this.m_enCola.Count <= 0) && flag && !flag2)
					{
						goto IL_0363;
					}
					List<SemenSkinController.SemenChainPar> list = new List<SemenSkinController.SemenChainPar>(this.config.maxParticlesWaiting);
					List<int> list2 = new List<int>(this.config.maxParticlesWaiting);
					int num2 = 0;
					while (num2 < this.m_enCola.Count && list.Count <= this.config.maxParticlesWaiting)
					{
						list2.Add(num2);
						SemenSkinController.SemenChainPar semenChainPar = this.m_enCola[num2];
						if (semenChainPar.IsValidAndCorrect())
						{
							semenChainPar.LoadPostValidationData();
							list.Add(semenChainPar);
						}
						else
						{
							semenChainPar.Clear();
						}
						num2++;
					}
					for (int i = list2.Count - 1; i >= 0; i--)
					{
						this.m_enCola.RemoveAt(list2[i]);
					}
					if (list.Count <= 0)
					{
						goto IL_0363;
					}
					try
					{
						this.m_SkinData.Update();
						this.m_pedidoDeBones = new SemenSkinController.PedidoDeBones();
						this.m_pedidoDeBones.LoadData(this, list);
						this.m_pedidoDeBones.Schedule(this, default(JobHandle));
						goto IL_0363;
					}
					finally
					{
						this.m_waitBuffer.bufferTime = this.config.waitTimeToConvertSemenMeshToSkin;
					}
					break;
				}
				case SemenSkinController.PedidoEstado.calculandoBones:
					break;
				case SemenSkinController.PedidoEstado.calculandoVertices:
				{
					this.m_pedidoDeVertices.Complete();
					SemenSkinController.SemenSkin semenSkin = this.m_SemenSkins.LastOrDefault<SemenSkinController.SemenSkin>();
					if (semenSkin != null && !semenSkin.consolidado && semenSkin.currentVertexCount <= this.config.semenSkinVertexCountToConsolidate && semenSkin.currentLifeTime <= this.config.semenSkinLifeTimeToConsolidate)
					{
						SemenSkinController.SemenSkin.PerSparcedShapeDeltasData currentPerSparcedShapeDeltasData = semenSkin.currentPerSparcedShapeDeltasData;
						if (((currentPerSparcedShapeDeltasData != null) ? new int?(currentPerSparcedShapeDeltasData.dataLength) : null).GetValueOrDefault() <= this.config.semenSkinSparcedDeltasCountToConsolidate)
						{
							SemenSkinController.SemenSkin.PerBoneWeightsData currentPerBoneWeightsData = semenSkin.currentPerBoneWeightsData;
							if (((currentPerBoneWeightsData != null) ? new int?(currentPerBoneWeightsData.dataLength) : null).GetValueOrDefault() <= this.config.semenSkinAllBonesWeightCountToConsolidate)
							{
								goto IL_02DD;
							}
						}
					}
					if (semenSkin != null)
					{
						semenSkin.Consolidar(this);
					}
					semenSkin = new SemenSkinController.SemenSkin();
					semenSkin.Init(this, this.m_SemenSkins.Count);
					this.m_SemenSkins.Add(semenSkin);
					IL_02DD:
					this.m_pedidoDeUpdateVerticesData = new SemenSkinController.PedidoDeUpdateVerticesData();
					this.m_pedidoDeUpdateVerticesData.Init(semenSkin);
					this.m_pedidoDeUpdateVerticesData.Schedule(this, default(JobHandle));
					goto IL_0363;
				}
				case SemenSkinController.PedidoEstado.updatingMesh:
					this.m_pedidoDeUpdateVerticesData.CompleteAndUpdateMesh(this, this.m_pedidoDeBones.toDoParticles);
					this.m_pedidoDeBones.DestroyParticles();
					this.m_pedidoDeUpdateVerticesData.semenSkin.OnParticlesDestroyed(this);
					this.ClearPedido();
					goto IL_0363;
				default:
					throw new ArgumentOutOfRangeException(this.GetPedidoEstate().ToString());
				}
				this.m_pedidoDeBones.Complete();
				this.m_pedidoDeVertices = new SemenSkinController.PedidoDeVertices();
				this.m_pedidoDeVertices.LoadData(this, this.m_SkinData, this.m_pedidoDeBones);
				this.m_pedidoDeVertices.Schedule(this, default(JobHandle));
				IL_0363:;
			}
			catch (Exception ex)
			{
				this.ClearPedido();
				Debug.LogError(ex, this);
			}
			finally
			{
				this.flagDontWait = false;
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000C760 File Offset: 0x0000A960
		public override void OnUpdateEvent2()
		{
			if (this.GetPedidoEstate() == SemenSkinController.PedidoEstado.libre)
			{
				SemenSkinController.SemenSkin semenSkin = this.m_SemenSkins.LastOrDefault<SemenSkinController.SemenSkin>();
				if (semenSkin != null && !semenSkin.consolidado && (semenSkin.currentVertexCount > this.config.semenSkinVertexCountToConsolidate || semenSkin.currentLifeTime > this.config.semenSkinLifeTimeToConsolidate))
				{
					semenSkin.Consolidar(this);
				}
			}
			for (int i = 0; i < this.m_SemenSkins.Count; i++)
			{
				SemenSkinController.SemenSkin semenSkin2 = this.m_SemenSkins[i];
				if (semenSkin2 != null)
				{
					semenSkin2.Update(this);
				}
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000C7E8 File Offset: 0x0000A9E8
		private void ClearPedido()
		{
			SemenSkinController.PedidoDeBones pedidoDeBones = this.m_pedidoDeBones;
			if (pedidoDeBones != null)
			{
				pedidoDeBones.Dispose();
			}
			SemenSkinController.PedidoDeVertices pedidoDeVertices = this.m_pedidoDeVertices;
			if (pedidoDeVertices != null)
			{
				pedidoDeVertices.Dispose();
			}
			SemenSkinController.PedidoDeUpdateVerticesData pedidoDeUpdateVerticesData = this.m_pedidoDeUpdateVerticesData;
			if (pedidoDeUpdateVerticesData != null)
			{
				pedidoDeUpdateVerticesData.Dispose();
			}
			this.m_pedidoDeBones = null;
			this.m_pedidoDeVertices = null;
			this.m_pedidoDeUpdateVerticesData = null;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000C840 File Offset: 0x0000AA40
		private SemenSkinController.PedidoEstado GetPedidoEstate()
		{
			if (this.m_pedidoDeBones == null && this.m_pedidoDeVertices == null && this.m_pedidoDeUpdateVerticesData == null)
			{
				return SemenSkinController.PedidoEstado.libre;
			}
			if (this.m_pedidoDeBones != null && this.m_pedidoDeVertices == null && this.m_pedidoDeUpdateVerticesData == null)
			{
				return SemenSkinController.PedidoEstado.calculandoBones;
			}
			if (this.m_pedidoDeBones != null && this.m_pedidoDeVertices != null && this.m_pedidoDeUpdateVerticesData == null)
			{
				return SemenSkinController.PedidoEstado.calculandoVertices;
			}
			if (this.m_pedidoDeBones != null && this.m_pedidoDeVertices != null && this.m_pedidoDeUpdateVerticesData != null)
			{
				return SemenSkinController.PedidoEstado.updatingMesh;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000C8BA File Offset: 0x0000AABA
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Destruir Semen Skins"
			};
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000C8D3 File Offset: 0x0000AAD3
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.DestroySemenSkins();
		}

		// Token: 0x0400018B RID: 395
		private static readonly HashSet<string> m_VG_Prohibidos = new HashSet<string>
		{
			"DEF_Anus_Hole.R.000", "DEF_Anus_Hole.L.000", "DEF_Anus_Hole.R.002", "DEF_Anus_Hole.L.002", "DEF_Anus_Hole.R.001", "DEF_Anus_Hole.L.001", "DEF_Anus_Hole.R.003", "DEF_Anus_Hole.L.003", "DEF_Anus_Inner_Hole.000", "DEF_Anus_Hole_Out.F",
			"DEF_Anus_Hole_Out.B.001", "DEF_Anus_Hole_Out.R.002", "DEF_Anus_Hole_Out.R.001", "DEF_Anus_Hole_Out.R.003", "DEF_Anus_Hole_Out.L.002", "DEF_Anus_Hole_Out.L.001", "DEF_Anus_Hole_Out.L.003", "DEF_Vag_Hole.R.000", "DEF_Vag_Hole.L.000", "DEF_Vag_Hole.R.001",
			"DEF_Vag_Hole.L.001", "DEF_Vag_Hole.R.002", "DEF_Vag_Hole.L.002", "DEF_Vag_Hole.R.003", "DEF_Vag_Hole.L.003", "DEF_Vag_InnerHole.001"
		};

		// Token: 0x0400018C RID: 396
		private static SemenSkinController.WorkingSemenParticle workingSemenParticle = new SemenSkinController.WorkingSemenParticle();

		// Token: 0x0400018D RID: 397
		public SemenSkinController.Config config = new SemenSkinController.Config();

		// Token: 0x0400018E RID: 398
		[ReadOnlyUI]
		[SerializeField]
		private List<SemenSkinController.SemenSkin> m_SemenSkins = new List<SemenSkinController.SemenSkin>();

		// Token: 0x0400018F RID: 399
		[ReadOnlyUI]
		[SerializeField]
		private List<SemenSkinController.SemenChainPar> m_enCola = new List<SemenSkinController.SemenChainPar>();

		// Token: 0x04000190 RID: 400
		private BufferedCoolDown m_waitBuffer = new BufferedCoolDown();

		// Token: 0x04000191 RID: 401
		private ICharacter m_character;

		// Token: 0x04000192 RID: 402
		private CharAi m_characterAI;

		// Token: 0x04000193 RID: 403
		private Skin m_Skin;

		// Token: 0x04000194 RID: 404
		private IMeshGetter m_IMeshGetter;

		// Token: 0x04000195 RID: 405
		private IMeshOriginalDataGetter m_IMeshOriginalDataGetter;

		// Token: 0x04000196 RID: 406
		private IMeshBoneWeightsDataGetter m_IMeshBoneWeightsDataGetter;

		// Token: 0x04000197 RID: 407
		private IMeshBlendShapesDataGetter m_IMeshBlendShapesDataGetter;

		// Token: 0x04000198 RID: 408
		private IMeshSkinningDataGetter m_IMeshSkinningDataGetter;

		// Token: 0x04000199 RID: 409
		[NonSerialized]
		private SemenSkinController.SkinData m_SkinData;

		// Token: 0x0400019A RID: 410
		[SerializeReference]
		private SemenSkinController.PedidoDeBones m_pedidoDeBones;

		// Token: 0x0400019B RID: 411
		[SerializeReference]
		private SemenSkinController.PedidoDeVertices m_pedidoDeVertices;

		// Token: 0x0400019C RID: 412
		[SerializeReference]
		private SemenSkinController.PedidoDeUpdateVerticesData m_pedidoDeUpdateVerticesData;

		// Token: 0x0400019D RID: 413
		public bool flagDontWait;

		// Token: 0x0200004A RID: 74
		public enum PedidoEstado
		{
			// Token: 0x0400019F RID: 415
			libre,
			// Token: 0x040001A0 RID: 416
			calculandoBones,
			// Token: 0x040001A1 RID: 417
			calculandoVertices,
			// Token: 0x040001A2 RID: 418
			updatingMesh
		}

		// Token: 0x0200004B RID: 75
		[Serializable]
		public class PedidoDeBones
		{
			// Token: 0x17000040 RID: 64
			// (get) Token: 0x060001D1 RID: 465 RVA: 0x0000CA71 File Offset: 0x0000AC71
			public int Count
			{
				get
				{
					return this.toDoParticles.Count;
				}
			}

			// Token: 0x17000041 RID: 65
			// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000CA7E File Offset: 0x0000AC7E
			public SemenSkinController.UsersData usersData
			{
				get
				{
					return this.m_UsersData;
				}
			}

			// Token: 0x17000042 RID: 66
			// (get) Token: 0x060001D3 RID: 467 RVA: 0x0000CA86 File Offset: 0x0000AC86
			public SemenSkinController.UsersBonesDataResult usersBonesResultData
			{
				get
				{
					return this.m_usersBonesResultData;
				}
			}

			// Token: 0x060001D4 RID: 468 RVA: 0x0000CA90 File Offset: 0x0000AC90
			public void LoadData(SemenSkinController controller, IEnumerable<SemenSkinController.SemenChainPar> enCola)
			{
				if (this.toDoParticles.Count != 0)
				{
					throw new InvalidOperationException();
				}
				this.toDoParticles.AddRange(enCola);
				if (this.toDoParticles.Count == 0)
				{
					throw new InvalidOperationException();
				}
				this.m_UsersData = new SemenSkinController.UsersData();
				this.m_UsersData.Init(controller, this.toDoParticles);
				this.m_usersBonesResultData = new SemenSkinController.UsersBonesDataResult();
				this.m_usersBonesResultData.Init(this.toDoParticles.Count);
			}

			// Token: 0x060001D5 RID: 469 RVA: 0x0000CB10 File Offset: 0x0000AD10
			public void Schedule(SemenSkinController controller, JobHandle dependsOn = default(JobHandle))
			{
				this.m_JobCalculeParticleBonesTransformsJobHandle = new JobHandle?(new SemenSkinController.JobCalculeParticleBonesTransforms
				{
					characterScale = controller.m_SkinData.characterScale,
					skinVertices = controller.m_SkinData.skinVertices,
					skinNormals = controller.m_SkinData.skinNormals,
					skinTangents = controller.m_SkinData.skinTangents,
					headBarycentricCoordinates = this.m_UsersData.headBarycentricCoordinates.AsReadOnly(),
					tailBarycentricCoordinates = this.m_UsersData.tailBarycentricCoordinates,
					headTriangleVertexIndexs = this.m_UsersData.headTriangleVertexIndexs.AsReadOnly(),
					tailTriangleVertexIndexs = this.m_UsersData.tailTriangleVertexIndexs,
					distacesToBreak = this.m_UsersData.distacesToBreak.AsReadOnly(),
					headDeltaRotations = this.m_UsersData.headDeltaRotations.AsReadOnly(),
					tailDeltaRotations = this.m_UsersData.tailDeltaRotations.AsReadOnly(),
					headDeltaPositions = this.m_UsersData.headDeltaPositions.AsReadOnly(),
					tailDeltaPositions = this.m_UsersData.tailDeltaPositions.AsReadOnly(),
					headWTrianglePerimeters = this.m_UsersData.headWTrianglePerimeters.AsReadOnly(),
					tailWTrianglePerimeters = this.m_UsersData.tailWTrianglePerimeters.AsReadOnly(),
					skeletonSkinnedLocalScales = this.m_UsersData.skeletonSkinnedLocalScales.AsReadOnly(),
					bone1SkinnedLocalScales = this.m_UsersData.bone1SkinnedLocalScales.AsReadOnly(),
					bone2SkinnedLocalScales = this.m_UsersData.bone2SkinnedLocalScales.AsReadOnly(),
					stretchedBoneSkinnedLocalScales = this.m_UsersData.stretchedBoneSkinnedLocalScales.AsReadOnly(),
					stretchedBoneSkinnedLocalFromHeadRotation = this.m_UsersData.stretchedBoneSkinnedLocalFromHeadRotation.AsReadOnly(),
					skeletonLocalPositions = this.m_usersBonesResultData.skeletonLocalPositions,
					skeletonLocalRotations = this.m_usersBonesResultData.skeletonLocalRotations,
					skeletonLocalScales = this.m_usersBonesResultData.skeletonLocalScales,
					headLocalPositions = this.m_usersBonesResultData.headLocalPositions,
					headLocalRotations = this.m_usersBonesResultData.headLocalRotations,
					headLocalScales = this.m_usersBonesResultData.headLocalScales,
					stretchedLocalPositions = this.m_usersBonesResultData.stretchedLocalPositions,
					stretchedLocalRotations = this.m_usersBonesResultData.stretchedLocalRotations,
					stretchedLocalScales = this.m_usersBonesResultData.stretchedLocalScales,
					tailLocalPositions = this.m_usersBonesResultData.tailLocalPositions,
					tailLocalRotations = this.m_usersBonesResultData.tailLocalRotations,
					tailLocalScales = this.m_usersBonesResultData.tailLocalScales
				}.Schedule(this.toDoParticles.Count, this.toDoParticles.Count.BatchCountASYNC(), dependsOn));
			}

			// Token: 0x060001D6 RID: 470 RVA: 0x0000CDE0 File Offset: 0x0000AFE0
			public void Complete()
			{
				if (this.m_JobCalculeParticleBonesTransformsJobHandle != null)
				{
					this.m_JobCalculeParticleBonesTransformsJobHandle.GetValueOrDefault().Complete();
				}
				this.m_JobCalculeParticleBonesTransformsJobHandle = null;
			}

			// Token: 0x060001D7 RID: 471 RVA: 0x0000CE18 File Offset: 0x0000B018
			public void DestroyParticles()
			{
				for (int i = 0; i < this.toDoParticles.Count; i++)
				{
					this.toDoParticles[i].OnConvertedToSkin();
				}
				this.toDoParticles.Clear();
				this.toDoParticles = null;
			}

			// Token: 0x060001D8 RID: 472 RVA: 0x0000CE60 File Offset: 0x0000B060
			public void Dispose()
			{
				this.Complete();
				if (this.toDoParticles != null && this.toDoParticles.Count != 0)
				{
					Debug.LogError("Before Disposing make sure to destroy used particles");
				}
				this.toDoParticles = null;
				SemenSkinController.UsersData usersData = this.m_UsersData;
				if (usersData != null)
				{
					usersData.Dispose();
				}
				SemenSkinController.UsersBonesDataResult usersBonesResultData = this.m_usersBonesResultData;
				if (usersBonesResultData != null)
				{
					usersBonesResultData.Dispose();
				}
				this.m_UsersData = null;
				this.m_usersBonesResultData = null;
			}

			// Token: 0x040001A3 RID: 419
			public List<SemenSkinController.SemenChainPar> toDoParticles = new List<SemenSkinController.SemenChainPar>();

			// Token: 0x040001A4 RID: 420
			[NonSerialized]
			private SemenSkinController.UsersData m_UsersData;

			// Token: 0x040001A5 RID: 421
			[NonSerialized]
			private SemenSkinController.UsersBonesDataResult m_usersBonesResultData;

			// Token: 0x040001A6 RID: 422
			private JobHandle? m_JobCalculeParticleBonesTransformsJobHandle;
		}

		// Token: 0x0200004C RID: 76
		[Serializable]
		public class PedidoDeVertices
		{
			// Token: 0x060001DA RID: 474 RVA: 0x0000CEDC File Offset: 0x0000B0DC
			public void LoadData(SemenSkinController controller, SemenSkinController.SkinData skinData, SemenSkinController.PedidoDeBones pedidoDeBones)
			{
				this.particlesMeshData = new SemenSkinController.ParticlesMeshData();
				this.particlesMeshData.Init(SemenSkinController.workingSemenParticle.vertexCount, pedidoDeBones.Count, SemenSkinController.workingSemenParticle.triangleCount);
				for (int i = 0; i < pedidoDeBones.Count; i++)
				{
					SemenSkinController.workingSemenParticle.skeleton.SetPositionAndRotation(pedidoDeBones.usersBonesResultData.skeletonLocalPositions[i], pedidoDeBones.usersBonesResultData.skeletonLocalRotations[i]);
					SemenSkinController.workingSemenParticle.skeleton.localScale = pedidoDeBones.usersBonesResultData.skeletonLocalScales[i];
					SemenSkinController.workingSemenParticle.bone1.SetPositionAndRotation(pedidoDeBones.usersBonesResultData.headLocalPositions[i], pedidoDeBones.usersBonesResultData.headLocalRotations[i]);
					SemenSkinController.workingSemenParticle.bone1.localScale = pedidoDeBones.usersBonesResultData.headLocalScales[i];
					SemenSkinController.workingSemenParticle.stretchedBone.SetPositionAndRotation(pedidoDeBones.usersBonesResultData.stretchedLocalPositions[i], pedidoDeBones.usersBonesResultData.stretchedLocalRotations[i]);
					SemenSkinController.workingSemenParticle.stretchedBone.localScale = pedidoDeBones.usersBonesResultData.stretchedLocalScales[i];
					SemenSkinController.workingSemenParticle.bone2.SetPositionAndRotation(pedidoDeBones.usersBonesResultData.tailLocalPositions[i], pedidoDeBones.usersBonesResultData.tailLocalRotations[i]);
					SemenSkinController.workingSemenParticle.bone2.localScale = pedidoDeBones.usersBonesResultData.tailLocalScales[i];
					SemenSkinController.workingSemenParticle.Bake();
					this.particlesMeshData.AddParticleData(controller, i, SemenSkinController.workingSemenParticle.vertexCount, SemenSkinController.workingSemenParticle.triangleCount, SemenSkinController.workingSemenParticle.vertices, SemenSkinController.workingSemenParticle.normals, SemenSkinController.workingSemenParticle.tangents, SemenSkinController.workingSemenParticle.uvs);
				}
				this.particlesMeshDataResult = new SemenSkinController.ParticlesMeshDataResult();
				this.particlesMeshDataResult.Init(pedidoDeBones.Count, SemenSkinController.workingSemenParticle.vertexCount, SemenSkinController.workingSemenParticle.triangleCount, skinData.shapeCount);
			}

			// Token: 0x060001DB RID: 475 RVA: 0x0000D13C File Offset: 0x0000B33C
			public void Schedule(SemenSkinController controller, JobHandle dependsOn = default(JobHandle))
			{
				this.m_jobCalculeSemenSkinVertexSkinningHandle = new JobHandle?(new SemenSkinController.JobCalculeSemenSkinVertexSkinning
				{
					vertexCountPerParticle = this.particlesMeshData.vertexCountsOfEachParticle.AsReadOnly(),
					headTriangleVertexIndexs = controller.m_pedidoDeBones.usersData.headTriangleVertexIndexs.AsReadOnly(),
					tailTriangleVertexIndexs = controller.m_pedidoDeBones.usersData.tailTriangleVertexIndexs.AsReadOnly(),
					headBarycentricCoordinates = controller.m_pedidoDeBones.usersData.headBarycentricCoordinates.AsReadOnly(),
					tailBarycentricCoordinates = controller.m_pedidoDeBones.usersData.tailBarycentricCoordinates.AsReadOnly(),
					headToTailWeightsPerParticleVertex = SemenSkinController.workingSemenParticle.headToTailWeights.AsReadOnly(),
					allBoneWeightsPerVertIndexSkin = controller.m_SkinData.allBoneWeightsPerVertIndex,
					allBoneWeightsSemen = this.particlesMeshDataResult.allBoneWeights,
					bonesPerVertexSemen = this.particlesMeshDataResult.bonesPerVertex
				}.Schedule(dependsOn));
				this.m_jobCalculeSemenSkinVertexAttributesHandle = new JobHandle?(new SemenSkinController.JobCalculeSemenSkinVertexAttributes
				{
					vertexCountPerParticle = this.particlesMeshData.vertexCountsOfEachParticle.AsReadOnly(),
					triangleCountPerParticle = this.particlesMeshData.tiranglesCountsOfEachParticle.AsReadOnly(),
					headTriangleVertexIndexs = controller.m_pedidoDeBones.usersData.headTriangleVertexIndexs.AsReadOnly(),
					tailTriangleVertexIndexs = controller.m_pedidoDeBones.usersData.tailTriangleVertexIndexs.AsReadOnly(),
					headBarycentricCoordinates = controller.m_pedidoDeBones.usersData.headBarycentricCoordinates.AsReadOnly(),
					tailBarycentricCoordinates = controller.m_pedidoDeBones.usersData.tailBarycentricCoordinates.AsReadOnly(),
					headToTailWeightsPerParticleVertex = SemenSkinController.workingSemenParticle.headToTailWeights.AsReadOnly(),
					particleTriangles = SemenSkinController.workingSemenParticle.triangles.AsReadOnly(),
					skinColors = controller.m_SkinData.skinColors,
					skinVertices = controller.m_SkinData.skinVertices,
					semenVertexColors = this.particlesMeshDataResult.vertexColors,
					semenTriangles = this.particlesMeshDataResult.triangles
				}.Schedule(dependsOn));
				this.m_jobCalculeSemenSkinVertexShapingHandle = new JobHandle?(new SemenSkinController.JobCalculeSemenSkinVertexShaping
				{
					vertexCountPerParticle = this.particlesMeshData.vertexCountsOfEachParticle.AsReadOnly(),
					headTriangleVertexIndexs = controller.m_pedidoDeBones.usersData.headTriangleVertexIndexs.AsReadOnly(),
					tailTriangleVertexIndexs = controller.m_pedidoDeBones.usersData.tailTriangleVertexIndexs.AsReadOnly(),
					headBarycentricCoordinates = controller.m_pedidoDeBones.usersData.headBarycentricCoordinates.AsReadOnly(),
					tailBarycentricCoordinates = controller.m_pedidoDeBones.usersData.tailBarycentricCoordinates.AsReadOnly(),
					headToTailWeightsPerParticleVertex = SemenSkinController.workingSemenParticle.headToTailWeights.AsReadOnly(),
					shapeCountOfSkin = controller.m_SkinData.shapeCountNativeReference,
					allShapeDataPerVertIndexSkin = controller.m_SkinData.allShapeDataPerVertIndex,
					vertexCountSemen = controller.m_pedidoDeVertices.particlesMeshData.totalVertexCountNativeReference,
					sparcedDeltaPositionsOfSemen = controller.m_pedidoDeVertices.particlesMeshDataResult.sparcedDeltaPositions
				}.Schedule(dependsOn));
			}

			// Token: 0x060001DC RID: 476 RVA: 0x0000D478 File Offset: 0x0000B678
			public void Complete()
			{
				if (this.m_jobCalculeSemenSkinVertexSkinningHandle != null)
				{
					this.m_jobCalculeSemenSkinVertexSkinningHandle.GetValueOrDefault().Complete();
				}
				this.m_jobCalculeSemenSkinVertexSkinningHandle = null;
				if (this.m_jobCalculeSemenSkinVertexAttributesHandle != null)
				{
					this.m_jobCalculeSemenSkinVertexAttributesHandle.GetValueOrDefault().Complete();
				}
				this.m_jobCalculeSemenSkinVertexAttributesHandle = null;
				if (this.m_jobCalculeSemenSkinVertexShapingHandle != null)
				{
					this.m_jobCalculeSemenSkinVertexShapingHandle.GetValueOrDefault().Complete();
				}
				this.m_jobCalculeSemenSkinVertexShapingHandle = null;
			}

			// Token: 0x060001DD RID: 477 RVA: 0x0000D503 File Offset: 0x0000B703
			public void Dispose()
			{
				this.Complete();
				SemenSkinController.ParticlesMeshData particlesMeshData = this.particlesMeshData;
				if (particlesMeshData != null)
				{
					particlesMeshData.Dispose();
				}
				SemenSkinController.ParticlesMeshDataResult particlesMeshDataResult = this.particlesMeshDataResult;
				if (particlesMeshDataResult == null)
				{
					return;
				}
				particlesMeshDataResult.Dispose();
			}

			// Token: 0x040001A7 RID: 423
			[NonSerialized]
			public SemenSkinController.ParticlesMeshData particlesMeshData;

			// Token: 0x040001A8 RID: 424
			[NonSerialized]
			public SemenSkinController.ParticlesMeshDataResult particlesMeshDataResult;

			// Token: 0x040001A9 RID: 425
			private JobHandle? m_jobCalculeSemenSkinVertexSkinningHandle;

			// Token: 0x040001AA RID: 426
			private JobHandle? m_jobCalculeSemenSkinVertexAttributesHandle;

			// Token: 0x040001AB RID: 427
			private JobHandle? m_jobCalculeSemenSkinVertexShapingHandle;
		}

		// Token: 0x0200004D RID: 77
		[Serializable]
		public class PedidoDeUpdateVerticesData
		{
			// Token: 0x060001DF RID: 479 RVA: 0x0000D52C File Offset: 0x0000B72C
			public void Init(SemenSkinController.SemenSkin semenSkin)
			{
				if (semenSkin.consolidado)
				{
					throw new InvalidOperationException();
				}
				this.semenSkin = semenSkin;
			}

			// Token: 0x060001E0 RID: 480 RVA: 0x0000D544 File Offset: 0x0000B744
			public void Schedule(SemenSkinController controller, JobHandle dependsOn = default(JobHandle))
			{
				int num = this.semenSkin.currentVertexCount + controller.m_pedidoDeVertices.particlesMeshData.totalVertexCount;
				this.m_perVertexData = new SemenSkinController.SemenSkin.PerVertexData();
				this.m_perVertexData.Init(num);
				this.m_perTriangleData = new SemenSkinController.SemenSkin.PerTriangleData();
				this.m_perTriangleData.Init(((this.semenSkin.currentPerTriangleData == null) ? 0 : this.semenSkin.currentPerTriangleData.dataLength) + controller.m_pedidoDeVertices.particlesMeshDataResult.triangles.Length);
				this.m_perBoneWeightsData = new SemenSkinController.SemenSkin.PerBoneWeightsData();
				this.m_perBoneWeightsData.Init(((this.semenSkin.currentPerBoneWeightsData == null) ? 0 : this.semenSkin.currentPerBoneWeightsData.dataLength) + controller.m_pedidoDeVertices.particlesMeshDataResult.allBoneWeights.Length);
				this.m_perSparcedShapeDeltasData = new SemenSkinController.SemenSkin.PerSparcedShapeDeltasData();
				this.m_perSparcedShapeDeltasData.Init(controller.m_SkinData.shapeCount * num);
				this.m_jobAddPerSparcedShapeDeltasDataHandle = new JobHandle?(new SemenSkinController.JobAddPerSparcedShapeDeltasData
				{
					vectexCountExisting = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.dataLengthNativeReference : this.semenSkin.currentPerVertexData.dataLengthNativeReference),
					sparcedDeltaPositionsExisting = ((this.semenSkin.currentPerSparcedShapeDeltasData == null) ? SemenSkinController.SemenSkin.PerSparcedShapeDeltasData.empty.sparcedDeltaPositions : this.semenSkin.currentPerSparcedShapeDeltasData.sparcedDeltaPositions),
					vectexCountToAdd = controller.m_pedidoDeVertices.particlesMeshData.totalVertexCountNativeReference,
					sparcedDeltaPositionsToAdd = controller.m_pedidoDeVertices.particlesMeshDataResult.sparcedDeltaPositions.AsReadOnly(),
					vectexCount = this.m_perVertexData.dataLengthNativeReference,
					sparcedDeltaPositions = this.m_perSparcedShapeDeltasData.sparcedDeltaPositions
				}.Schedule(controller.m_SkinData.shapeCount, controller.m_SkinData.shapeCount.BatchCountASYNC(), dependsOn));
				this.m_jobAddPerBoneWeightDataHandle = new JobHandle?(new SemenSkinController.JobAddPerBoneWeightData
				{
					allBoneWeightsExisting = ((this.semenSkin.currentPerBoneWeightsData == null) ? SemenSkinController.SemenSkin.PerBoneWeightsData.empty.allBoneWeights : this.semenSkin.currentPerBoneWeightsData.allBoneWeights),
					allBoneWeightsToAdd = controller.m_pedidoDeVertices.particlesMeshDataResult.allBoneWeights.AsReadOnly(),
					allBoneWeights = this.m_perBoneWeightsData.allBoneWeights
				}.Schedule(dependsOn));
				this.m_jobAddPerTriangleDataHandle = new JobHandle?(new SemenSkinController.JobAddPerTriangleData
				{
					vectexCountExisting = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.dataLengthNativeReference : this.semenSkin.currentPerVertexData.dataLengthNativeReference),
					trianglesExisting = ((this.semenSkin.currentPerTriangleData == null) ? SemenSkinController.SemenSkin.PerTriangleData.empty.triangles : this.semenSkin.currentPerTriangleData.triangles),
					trianglesToAdd = controller.m_pedidoDeVertices.particlesMeshDataResult.triangles.AsReadOnly(),
					triangles = this.m_perTriangleData.triangles
				}.Schedule(dependsOn));
				this.m_jobAddPerVertexDataHandle = new JobHandle?(new SemenSkinController.JobAddPerVertexData
				{
					existingCount = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.dataLengthNativeReference : this.semenSkin.currentPerVertexData.dataLengthNativeReference),
					verticesExisting = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.vertices : this.semenSkin.currentPerVertexData.vertices),
					normalsExisting = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.normals : this.semenSkin.currentPerVertexData.normals),
					tangentsExisting = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.tangents : this.semenSkin.currentPerVertexData.tangents),
					vertexColorsExisting = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.vertexColors : this.semenSkin.currentPerVertexData.vertexColors),
					UVsExisting = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.UVs : this.semenSkin.currentPerVertexData.UVs),
					bonesPerVertexExisting = ((this.semenSkin.currentPerVertexData == null) ? SemenSkinController.SemenSkin.PerVertexData.empty.bonesPerVertex : this.semenSkin.currentPerVertexData.bonesPerVertex),
					toAddCount = controller.m_pedidoDeVertices.particlesMeshData.totalVertexCountNativeReference,
					verticesToAdd = controller.m_pedidoDeVertices.particlesMeshData.vertices.AsReadOnly(),
					normalsToAdd = controller.m_pedidoDeVertices.particlesMeshData.normals.AsReadOnly(),
					tangentsToAdd = controller.m_pedidoDeVertices.particlesMeshData.tangents.AsReadOnly(),
					vertexColorsToAdd = controller.m_pedidoDeVertices.particlesMeshDataResult.vertexColors.AsReadOnly(),
					UVsToAdd = controller.m_pedidoDeVertices.particlesMeshData.UVs.AsReadOnly(),
					bonesPerVertexToAdd = controller.m_pedidoDeVertices.particlesMeshDataResult.bonesPerVertex.AsReadOnly(),
					vertices = this.m_perVertexData.vertices,
					normals = this.m_perVertexData.normals,
					tangents = this.m_perVertexData.tangents,
					vertexColors = this.m_perVertexData.vertexColors,
					UVs = this.m_perVertexData.UVs,
					bonesPerVertex = this.m_perVertexData.bonesPerVertex
				}.Schedule(dependsOn));
			}

			// Token: 0x060001E1 RID: 481 RVA: 0x0000DAE8 File Offset: 0x0000BCE8
			public void CompleteAndUpdateMesh(SemenSkinController controller, IReadOnlyList<SemenSkinController.SemenChainPar> particles)
			{
				this.Complete();
				this.semenSkin.Rebuild(controller, particles, this.m_perVertexData, this.m_perTriangleData, this.m_perBoneWeightsData, this.m_perSparcedShapeDeltasData);
				this.m_perVertexData = null;
				this.m_perTriangleData = null;
				this.m_perBoneWeightsData = null;
				this.m_perSparcedShapeDeltasData = null;
			}

			// Token: 0x060001E2 RID: 482 RVA: 0x0000DB3C File Offset: 0x0000BD3C
			public void Complete()
			{
				if (this.m_jobAddPerSparcedShapeDeltasDataHandle != null)
				{
					this.m_jobAddPerSparcedShapeDeltasDataHandle.GetValueOrDefault().Complete();
				}
				if (this.m_jobAddPerBoneWeightDataHandle != null)
				{
					this.m_jobAddPerBoneWeightDataHandle.GetValueOrDefault().Complete();
				}
				if (this.m_jobAddPerTriangleDataHandle != null)
				{
					this.m_jobAddPerTriangleDataHandle.GetValueOrDefault().Complete();
				}
				if (this.m_jobAddPerVertexDataHandle != null)
				{
					this.m_jobAddPerVertexDataHandle.GetValueOrDefault().Complete();
				}
				this.m_jobAddPerSparcedShapeDeltasDataHandle = null;
				this.m_jobAddPerBoneWeightDataHandle = null;
				this.m_jobAddPerTriangleDataHandle = null;
				this.m_jobAddPerVertexDataHandle = null;
			}

			// Token: 0x060001E3 RID: 483 RVA: 0x0000DBF4 File Offset: 0x0000BDF4
			public void Dispose()
			{
				this.Complete();
				SemenSkinController.SemenSkin.PerVertexData perVertexData = this.m_perVertexData;
				if (perVertexData != null)
				{
					perVertexData.Dispose();
				}
				SemenSkinController.SemenSkin.PerTriangleData perTriangleData = this.m_perTriangleData;
				if (perTriangleData != null)
				{
					perTriangleData.Dispose();
				}
				SemenSkinController.SemenSkin.PerBoneWeightsData perBoneWeightsData = this.m_perBoneWeightsData;
				if (perBoneWeightsData != null)
				{
					perBoneWeightsData.Dispose();
				}
				SemenSkinController.SemenSkin.PerSparcedShapeDeltasData perSparcedShapeDeltasData = this.m_perSparcedShapeDeltasData;
				if (perSparcedShapeDeltasData != null)
				{
					perSparcedShapeDeltasData.Dispose();
				}
				this.m_perVertexData = null;
				this.m_perTriangleData = null;
				this.m_perBoneWeightsData = null;
				this.m_perSparcedShapeDeltasData = null;
			}

			// Token: 0x040001AC RID: 428
			public SemenSkinController.SemenSkin semenSkin;

			// Token: 0x040001AD RID: 429
			private SemenSkinController.SemenSkin.PerVertexData m_perVertexData;

			// Token: 0x040001AE RID: 430
			private SemenSkinController.SemenSkin.PerTriangleData m_perTriangleData;

			// Token: 0x040001AF RID: 431
			private SemenSkinController.SemenSkin.PerBoneWeightsData m_perBoneWeightsData;

			// Token: 0x040001B0 RID: 432
			private SemenSkinController.SemenSkin.PerSparcedShapeDeltasData m_perSparcedShapeDeltasData;

			// Token: 0x040001B1 RID: 433
			private JobHandle? m_jobAddPerSparcedShapeDeltasDataHandle;

			// Token: 0x040001B2 RID: 434
			private JobHandle? m_jobAddPerBoneWeightDataHandle;

			// Token: 0x040001B3 RID: 435
			private JobHandle? m_jobAddPerTriangleDataHandle;

			// Token: 0x040001B4 RID: 436
			private JobHandle? m_jobAddPerVertexDataHandle;
		}

		// Token: 0x0200004E RID: 78
		public class SkinData
		{
			// Token: 0x17000043 RID: 67
			// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000DC67 File Offset: 0x0000BE67
			public bool initiated
			{
				get
				{
					return this.m_init;
				}
			}

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000DC6F File Offset: 0x0000BE6F
			public Transform[] bones
			{
				get
				{
					return this.m_bones;
				}
			}

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x060001E7 RID: 487 RVA: 0x0000DC77 File Offset: 0x0000BE77
			public int shapeCount
			{
				get
				{
					return this.m_controller.m_IMeshBlendShapesDataGetter.shapeCount;
				}
			}

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000DC89 File Offset: 0x0000BE89
			public NativeArray<float3>.ReadOnly skinVertices
			{
				get
				{
					return this.m_controller.m_IMeshOriginalDataGetter.verticesOriginales;
				}
			}

			// Token: 0x17000047 RID: 71
			// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000DC9B File Offset: 0x0000BE9B
			public NativeArray<float3>.ReadOnly skinNormals
			{
				get
				{
					return this.m_controller.m_IMeshOriginalDataGetter.normalesOriginales;
				}
			}

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x060001EA RID: 490 RVA: 0x0000DCAD File Offset: 0x0000BEAD
			public NativeArray<float4>.ReadOnly skinTangents
			{
				get
				{
					return this.m_controller.m_IMeshOriginalDataGetter.tangentesOriginales;
				}
			}

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x060001EB RID: 491 RVA: 0x0000DCBF File Offset: 0x0000BEBF
			public NativeArray<Color>.ReadOnly skinColors
			{
				get
				{
					return this.m_controller.m_IMeshOriginalDataGetter.colores;
				}
			}

			// Token: 0x1700004A RID: 74
			// (get) Token: 0x060001EC RID: 492 RVA: 0x0000DCD4 File Offset: 0x0000BED4
			public NativeParallelMultiHashMap<int, BoneWeight1>.ReadOnly allBoneWeightsPerVertIndex
			{
				get
				{
					return this.m_controller.m_IMeshBoneWeightsDataGetter.allBoneWeightsPerVertIndex.AsReadOnly();
				}
			}

			// Token: 0x1700004B RID: 75
			// (get) Token: 0x060001ED RID: 493 RVA: 0x0000DCFC File Offset: 0x0000BEFC
			public NativeParallelMultiHashMap<int, ShapeVertexData>.ReadOnly allShapeDataPerVertIndex
			{
				get
				{
					return this.m_controller.m_IMeshBlendShapesDataGetter.allShapeDataPerVertIndex.AsReadOnly();
				}
			}

			// Token: 0x060001EE RID: 494 RVA: 0x0000DD24 File Offset: 0x0000BF24
			public void Init(SemenSkinController controller)
			{
				if (this.m_init)
				{
					throw new InvalidOperationException();
				}
				this.m_controller = controller;
				this.characterScale = new NativeReference<float>(Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.shapeCountNativeReference = new NativeReference<int>(this.shapeCount, Allocator.Persistent);
				this.characterScale.Value = this.m_controller.m_Skin.owner.character.escala;
				this.m_bones = this.m_controller.m_Skin.skinnedMeshRenderer.bones;
				this.m_init = true;
			}

			// Token: 0x060001EF RID: 495 RVA: 0x0000DDB6 File Offset: 0x0000BFB6
			public void Update()
			{
				this.characterScale.Value = this.m_controller.m_Skin.owner.character.escala;
			}

			// Token: 0x060001F0 RID: 496 RVA: 0x0000DDDD File Offset: 0x0000BFDD
			public void Dispose()
			{
				if (!this.m_init)
				{
					return;
				}
				this.characterScale.Dispose();
				this.shapeCountNativeReference.Dispose();
			}

			// Token: 0x040001B5 RID: 437
			private Transform[] m_bones;

			// Token: 0x040001B6 RID: 438
			private bool m_init;

			// Token: 0x040001B7 RID: 439
			public NativeReference<float> characterScale;

			// Token: 0x040001B8 RID: 440
			public NativeReference<int> shapeCountNativeReference;

			// Token: 0x040001B9 RID: 441
			private SemenSkinController m_controller;
		}

		// Token: 0x0200004F RID: 79
		public class UsersData
		{
			// Token: 0x1700004C RID: 76
			// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000DDFE File Offset: 0x0000BFFE
			public bool initiated
			{
				get
				{
					return this.m_init;
				}
			}

			// Token: 0x060001F3 RID: 499 RVA: 0x0000DE08 File Offset: 0x0000C008
			public void Init(SemenSkinController controller, IReadOnlyList<SemenSkinController.SemenChainPar> particles)
			{
				if (this.m_init || !controller.m_SkinData.initiated)
				{
					throw new InvalidOperationException();
				}
				int count = particles.Count;
				this.headBarycentricCoordinates = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tailBarycentricCoordinates = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.headTriangleVertexIndexs = new NativeArray<int3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tailTriangleVertexIndexs = new NativeArray<int3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.headDeltaRotations = new NativeArray<quaternion>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tailDeltaRotations = new NativeArray<quaternion>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.headDeltaPositions = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tailDeltaPositions = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.headWTrianglePerimeters = new NativeArray<float>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tailWTrianglePerimeters = new NativeArray<float>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.distacesToBreak = new NativeArray<float>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.skeletonSkinnedLocalScales = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.bone1SkinnedLocalScales = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.bone2SkinnedLocalScales = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.stretchedBoneSkinnedLocalScales = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.stretchedBoneSkinnedLocalFromHeadRotation = new NativeArray<quaternion>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				for (int i = 0; i < particles.Count; i++)
				{
					SemenSkinController.SemenChainPar semenChainPar = particles[i];
					if (!semenChainPar.nextData.existio || !semenChainPar.nextData.hitData.usable)
					{
						this.InitIndex(i, ref semenChainPar.selfData, ref semenChainPar.selfData.semenData);
					}
					else
					{
						this.InitIndex(i, ref semenChainPar.selfData, ref semenChainPar.nextData);
					}
				}
				this.m_init = true;
			}

			// Token: 0x060001F4 RID: 500 RVA: 0x0000DF84 File Offset: 0x0000C184
			private void InitIndex(int i, ref SemenSelfPointToSemenSkinData self_Data, ref SemenPointToSemenSkinData next_Data)
			{
				this.headBarycentricCoordinates[i] = self_Data.semenData.hitData.barycentricCoordinate;
				this.tailBarycentricCoordinates[i] = next_Data.hitData.barycentricCoordinate;
				this.headTriangleVertexIndexs[i] = new int3(self_Data.semenData.hitData.hitBakedTriangleData.vertexIndex0, self_Data.semenData.hitData.hitBakedTriangleData.vertexIndex1, self_Data.semenData.hitData.hitBakedTriangleData.vertexIndex2);
				this.tailTriangleVertexIndexs[i] = new int3(next_Data.hitData.hitBakedTriangleData.vertexIndex0, next_Data.hitData.hitBakedTriangleData.vertexIndex1, next_Data.hitData.hitBakedTriangleData.vertexIndex2);
				this.headDeltaRotations[i] = self_Data.semenData.deltaRotation;
				this.headDeltaPositions[i] = self_Data.semenData.deltaPosition;
				this.headWTrianglePerimeters[i] = self_Data.semenData.hitData.wTrianglePerimeter;
				this.tailDeltaRotations[i] = next_Data.deltaRotation;
				this.tailDeltaPositions[i] = next_Data.deltaPosition;
				this.tailWTrianglePerimeters[i] = next_Data.hitData.wTrianglePerimeter;
				this.distacesToBreak[i] = self_Data.localDistanceToBreak;
				this.skeletonSkinnedLocalScales[i] = self_Data.skeletonLocalScales;
				this.bone1SkinnedLocalScales[i] = self_Data.bone1LocalScales;
				this.bone2SkinnedLocalScales[i] = self_Data.bone2LocalScales;
				this.stretchedBoneSkinnedLocalScales[i] = self_Data.StretchedBoneLocalScales;
				this.stretchedBoneSkinnedLocalFromHeadRotation[i] = self_Data.stretchedBoneLocalRotation;
			}

			// Token: 0x060001F5 RID: 501 RVA: 0x0000E180 File Offset: 0x0000C380
			public void Dispose()
			{
				if (!this.m_init)
				{
					return;
				}
				this.headBarycentricCoordinates.Dispose();
				this.headDeltaRotations.Dispose();
				this.headDeltaPositions.Dispose();
				this.headWTrianglePerimeters.Dispose();
				this.tailBarycentricCoordinates.Dispose();
				this.tailDeltaRotations.Dispose();
				this.tailDeltaPositions.Dispose();
				this.tailWTrianglePerimeters.Dispose();
				this.headTriangleVertexIndexs.Dispose();
				this.tailTriangleVertexIndexs.Dispose();
				this.distacesToBreak.Dispose();
				this.skeletonSkinnedLocalScales.Dispose();
				this.bone1SkinnedLocalScales.Dispose();
				this.bone2SkinnedLocalScales.Dispose();
				this.stretchedBoneSkinnedLocalScales.Dispose();
				this.stretchedBoneSkinnedLocalFromHeadRotation.Dispose();
			}

			// Token: 0x040001BA RID: 442
			private bool m_init;

			// Token: 0x040001BB RID: 443
			public NativeArray<float3> headBarycentricCoordinates;

			// Token: 0x040001BC RID: 444
			public NativeArray<float3> tailBarycentricCoordinates;

			// Token: 0x040001BD RID: 445
			public NativeArray<int3> headTriangleVertexIndexs;

			// Token: 0x040001BE RID: 446
			public NativeArray<int3> tailTriangleVertexIndexs;

			// Token: 0x040001BF RID: 447
			public NativeArray<quaternion> headDeltaRotations;

			// Token: 0x040001C0 RID: 448
			public NativeArray<quaternion> tailDeltaRotations;

			// Token: 0x040001C1 RID: 449
			public NativeArray<float3> headDeltaPositions;

			// Token: 0x040001C2 RID: 450
			public NativeArray<float3> tailDeltaPositions;

			// Token: 0x040001C3 RID: 451
			public NativeArray<float> headWTrianglePerimeters;

			// Token: 0x040001C4 RID: 452
			public NativeArray<float> tailWTrianglePerimeters;

			// Token: 0x040001C5 RID: 453
			public NativeArray<float> distacesToBreak;

			// Token: 0x040001C6 RID: 454
			public NativeArray<float3> skeletonSkinnedLocalScales;

			// Token: 0x040001C7 RID: 455
			public NativeArray<float3> bone1SkinnedLocalScales;

			// Token: 0x040001C8 RID: 456
			public NativeArray<float3> bone2SkinnedLocalScales;

			// Token: 0x040001C9 RID: 457
			public NativeArray<float3> stretchedBoneSkinnedLocalScales;

			// Token: 0x040001CA RID: 458
			public NativeArray<quaternion> stretchedBoneSkinnedLocalFromHeadRotation;
		}

		// Token: 0x02000050 RID: 80
		public class UsersBonesDataResult
		{
			// Token: 0x1700004D RID: 77
			// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000E246 File Offset: 0x0000C446
			public bool initiated
			{
				get
				{
					return this.m_init;
				}
			}

			// Token: 0x060001F8 RID: 504 RVA: 0x0000E250 File Offset: 0x0000C450
			public void Init(int cantidadDeUsuarios)
			{
				if (this.m_init)
				{
					throw new InvalidOperationException();
				}
				this.skeletonLocalPositions = new NativeArray<float3>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.skeletonLocalRotations = new NativeArray<quaternion>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.skeletonLocalScales = new NativeArray<float3>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.headLocalPositions = new NativeArray<float3>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.headLocalRotations = new NativeArray<quaternion>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.headLocalScales = new NativeArray<float3>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.stretchedLocalPositions = new NativeArray<float3>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.stretchedLocalRotations = new NativeArray<quaternion>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.stretchedLocalScales = new NativeArray<float3>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tailLocalPositions = new NativeArray<float3>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tailLocalRotations = new NativeArray<quaternion>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tailLocalScales = new NativeArray<float3>(cantidadDeUsuarios, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.m_init = true;
			}

			// Token: 0x060001F9 RID: 505 RVA: 0x0000E31C File Offset: 0x0000C51C
			public void Dispose()
			{
				if (!this.m_init)
				{
					return;
				}
				this.headLocalPositions.Dispose();
				this.headLocalRotations.Dispose();
				this.headLocalScales.Dispose();
				this.tailLocalPositions.Dispose();
				this.tailLocalRotations.Dispose();
				this.tailLocalScales.Dispose();
				this.skeletonLocalPositions.Dispose();
				this.skeletonLocalRotations.Dispose();
				this.skeletonLocalScales.Dispose();
				this.stretchedLocalPositions.Dispose();
				this.stretchedLocalRotations.Dispose();
				this.stretchedLocalScales.Dispose();
			}

			// Token: 0x040001CB RID: 459
			private bool m_init;

			// Token: 0x040001CC RID: 460
			public NativeArray<float3> skeletonLocalPositions;

			// Token: 0x040001CD RID: 461
			public NativeArray<quaternion> skeletonLocalRotations;

			// Token: 0x040001CE RID: 462
			public NativeArray<float3> skeletonLocalScales;

			// Token: 0x040001CF RID: 463
			public NativeArray<float3> headLocalPositions;

			// Token: 0x040001D0 RID: 464
			public NativeArray<quaternion> headLocalRotations;

			// Token: 0x040001D1 RID: 465
			public NativeArray<float3> headLocalScales;

			// Token: 0x040001D2 RID: 466
			public NativeArray<float3> stretchedLocalPositions;

			// Token: 0x040001D3 RID: 467
			public NativeArray<quaternion> stretchedLocalRotations;

			// Token: 0x040001D4 RID: 468
			public NativeArray<float3> stretchedLocalScales;

			// Token: 0x040001D5 RID: 469
			public NativeArray<float3> tailLocalPositions;

			// Token: 0x040001D6 RID: 470
			public NativeArray<quaternion> tailLocalRotations;

			// Token: 0x040001D7 RID: 471
			public NativeArray<float3> tailLocalScales;
		}

		// Token: 0x02000051 RID: 81
		public class ParticlesMeshData
		{
			// Token: 0x1700004E RID: 78
			// (get) Token: 0x060001FB RID: 507 RVA: 0x0000E3B6 File Offset: 0x0000C5B6
			public bool initiated
			{
				get
				{
					return this.m_init;
				}
			}

			// Token: 0x1700004F RID: 79
			// (get) Token: 0x060001FC RID: 508 RVA: 0x0000E3BE File Offset: 0x0000C5BE
			public int totalVertexCount
			{
				get
				{
					return this.m_totalVertexCount;
				}
			}

			// Token: 0x060001FD RID: 509 RVA: 0x0000E3C8 File Offset: 0x0000C5C8
			public void Init(int verticesPorCadaParticula, int cantidadDeParticulas, int triangulosPorParticula)
			{
				if (this.m_init)
				{
					throw new InvalidOperationException();
				}
				this.m_totalVertexCount = verticesPorCadaParticula * cantidadDeParticulas;
				this.totalVertexCountNativeReference = new NativeReference<int>(this.m_totalVertexCount, Allocator.TempJob);
				this.vertices = new NativeArray<float3>(this.m_totalVertexCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.normals = new NativeArray<float3>(this.m_totalVertexCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tangents = new NativeArray<float4>(this.m_totalVertexCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.UVs = new NativeArray<float2>(this.m_totalVertexCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.tiranglesCountsOfEachParticle = new NativeArray<int>(cantidadDeParticulas, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.vertexCountsOfEachParticle = new NativeArray<int>(cantidadDeParticulas, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				this.m_init = true;
			}

			// Token: 0x060001FE RID: 510 RVA: 0x0000E474 File Offset: 0x0000C674
			public void AddParticleData(SemenSkinController controller, int particleIndex, int verticesPorCadaParticula, int triangulosPorParticula, NativeArray<float3> particleVertices, NativeArray<float3> particleNormals, NativeArray<float4> particleTangents, NativeArray<float2> particleUVs)
			{
				int num = particleIndex * verticesPorCadaParticula;
				NativeArray<float3>.Copy(particleVertices, 0, this.vertices, num, verticesPorCadaParticula);
				NativeArray<float3>.Copy(particleNormals, 0, this.normals, num, verticesPorCadaParticula);
				NativeArray<float4>.Copy(particleTangents, 0, this.tangents, num, verticesPorCadaParticula);
				NativeArray<float2>.Copy(particleUVs, 0, this.UVs, num, verticesPorCadaParticula);
				this.tiranglesCountsOfEachParticle[particleIndex] = triangulosPorParticula;
				this.vertexCountsOfEachParticle[particleIndex] = verticesPorCadaParticula;
			}

			// Token: 0x060001FF RID: 511 RVA: 0x0000E4E0 File Offset: 0x0000C6E0
			public void Dispose()
			{
				if (!this.m_init)
				{
					return;
				}
				this.vertices.Dispose();
				this.normals.Dispose();
				this.tangents.Dispose();
				this.UVs.Dispose();
				this.vertexCountsOfEachParticle.Dispose();
				this.tiranglesCountsOfEachParticle.Dispose();
				this.totalVertexCountNativeReference.Dispose();
			}

			// Token: 0x040001D8 RID: 472
			private bool m_init;

			// Token: 0x040001D9 RID: 473
			private int m_totalVertexCount;

			// Token: 0x040001DA RID: 474
			public NativeArray<float3> vertices;

			// Token: 0x040001DB RID: 475
			public NativeArray<float3> normals;

			// Token: 0x040001DC RID: 476
			public NativeArray<float4> tangents;

			// Token: 0x040001DD RID: 477
			public NativeArray<float2> UVs;

			// Token: 0x040001DE RID: 478
			public NativeArray<int> vertexCountsOfEachParticle;

			// Token: 0x040001DF RID: 479
			public NativeArray<int> tiranglesCountsOfEachParticle;

			// Token: 0x040001E0 RID: 480
			public NativeReference<int> totalVertexCountNativeReference;

			// Token: 0x040001E1 RID: 481
			private static ProfilerMarker CombiningData = new ProfilerMarker("SemenSkinController.ParticlesMeshData.AddParticleData");
		}

		// Token: 0x02000052 RID: 82
		public class ParticlesMeshDataResult
		{
			// Token: 0x17000050 RID: 80
			// (get) Token: 0x06000202 RID: 514 RVA: 0x0000E554 File Offset: 0x0000C754
			public bool initiated
			{
				get
				{
					return this.m_init;
				}
			}

			// Token: 0x06000203 RID: 515 RVA: 0x0000E55C File Offset: 0x0000C75C
			public void Init(int particlesCount, int particleVertexCount, int particleTriangleCount, int skinShapesCount)
			{
				if (this.m_init)
				{
					throw new InvalidOperationException();
				}
				int num = particlesCount * particleVertexCount;
				this.allBoneWeights = new NativeList<BoneWeight1>(Allocator.TempJob);
				this.bonesPerVertex = new NativeArray<byte>(num, Allocator.TempJob, NativeArrayOptions.ClearMemory);
				this.vertexColors = new NativeArray<Color>(num, Allocator.TempJob, NativeArrayOptions.ClearMemory);
				this.triangles = new NativeArray<int>(particleTriangleCount * particlesCount, Allocator.TempJob, NativeArrayOptions.ClearMemory);
				this.sparcedDeltaPositions = new NativeArray<float3>(num * skinShapesCount, Allocator.TempJob, NativeArrayOptions.ClearMemory);
				this.m_init = true;
			}

			// Token: 0x06000204 RID: 516 RVA: 0x0000E5D0 File Offset: 0x0000C7D0
			public void Dispose()
			{
				if (!this.m_init)
				{
					return;
				}
				this.vertexColors.Dispose();
				this.allBoneWeights.Dispose();
				this.bonesPerVertex.Dispose();
				this.triangles.Dispose();
				this.sparcedDeltaPositions.Dispose();
			}

			// Token: 0x040001E2 RID: 482
			private bool m_init;

			// Token: 0x040001E3 RID: 483
			public NativeArray<Color> vertexColors;

			// Token: 0x040001E4 RID: 484
			public NativeArray<int> triangles;

			// Token: 0x040001E5 RID: 485
			public NativeList<BoneWeight1> allBoneWeights;

			// Token: 0x040001E6 RID: 486
			public NativeArray<byte> bonesPerVertex;

			// Token: 0x040001E7 RID: 487
			public NativeArray<float3> sparcedDeltaPositions;
		}

		// Token: 0x02000053 RID: 83
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobAddPerSparcedShapeDeltasData : IJobParallelFor
		{
			// Token: 0x06000206 RID: 518 RVA: 0x0000E620 File Offset: 0x0000C820
			public void Execute(int ShapeIndex)
			{
				int value = this.vectexCount.Value;
				int value2 = this.vectexCountExisting.Value;
				int value3 = this.vectexCountToAdd.Value;
				int num = ShapeIndex * value2;
				int num2 = ShapeIndex * value3;
				int num3 = ShapeIndex * value;
				for (int i = 0; i < value2; i++)
				{
					this.sparcedDeltaPositions[num3 + i] = this.sparcedDeltaPositionsExisting[num + i];
				}
				for (int j = 0; j < value3; j++)
				{
					this.sparcedDeltaPositions[num3 + value2 + j] = this.sparcedDeltaPositionsToAdd[num2 + j];
				}
			}

			// Token: 0x040001E8 RID: 488
			[ReadOnly]
			public NativeReference<int> vectexCountExisting;

			// Token: 0x040001E9 RID: 489
			[NativeDisableParallelForRestriction]
			[ReadOnly]
			public NativeArray<float3> sparcedDeltaPositionsExisting;

			// Token: 0x040001EA RID: 490
			[ReadOnly]
			public NativeReference<int> vectexCountToAdd;

			// Token: 0x040001EB RID: 491
			[NativeDisableParallelForRestriction]
			[ReadOnly]
			public NativeArray<float3>.ReadOnly sparcedDeltaPositionsToAdd;

			// Token: 0x040001EC RID: 492
			[ReadOnly]
			public NativeReference<int> vectexCount;

			// Token: 0x040001ED RID: 493
			[NativeDisableParallelForRestriction]
			public NativeArray<float3> sparcedDeltaPositions;
		}

		// Token: 0x02000054 RID: 84
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobAddPerBoneWeightData : IJob
		{
			// Token: 0x06000207 RID: 519 RVA: 0x0000E6C0 File Offset: 0x0000C8C0
			public void Execute()
			{
				if (this.allBoneWeightsToAdd.Length <= 0)
				{
					throw new InvalidOperationException("no need to call this job if no new data exists");
				}
				int length = this.allBoneWeightsExisting.Length;
				if (length > 0)
				{
					NativeArray<BoneWeight1>.Copy(this.allBoneWeightsExisting, 0, this.allBoneWeights, 0, length);
				}
				NativeArray<BoneWeight1>.Copy(this.allBoneWeightsToAdd, 0, this.allBoneWeights, length, this.allBoneWeightsToAdd.Length);
			}

			// Token: 0x040001EE RID: 494
			[ReadOnly]
			public NativeArray<BoneWeight1> allBoneWeightsExisting;

			// Token: 0x040001EF RID: 495
			[ReadOnly]
			public NativeArray<BoneWeight1>.ReadOnly allBoneWeightsToAdd;

			// Token: 0x040001F0 RID: 496
			public NativeArray<BoneWeight1> allBoneWeights;
		}

		// Token: 0x02000055 RID: 85
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobAddPerTriangleData : IJob
		{
			// Token: 0x06000208 RID: 520 RVA: 0x0000E728 File Offset: 0x0000C928
			public void Execute()
			{
				int value = this.vectexCountExisting.Value;
				int length = this.trianglesExisting.Length;
				if (this.triangles.Length != this.trianglesToAdd.Length + length)
				{
					throw new InvalidOperationException("colleciones no tiene largo correcto");
				}
				if (this.trianglesToAdd.Length <= 0)
				{
					throw new InvalidOperationException("no need to call this job if no new data exists");
				}
				if (length > 0)
				{
					NativeArray<int>.Copy(this.trianglesExisting, 0, this.triangles, 0, length);
				}
				int num = length;
				for (int i = 0; i < this.trianglesToAdd.Length; i++)
				{
					this.triangles[num + i] = this.trianglesToAdd[i] + value;
				}
			}

			// Token: 0x040001F1 RID: 497
			[ReadOnly]
			public NativeReference<int> vectexCountExisting;

			// Token: 0x040001F2 RID: 498
			[ReadOnly]
			public NativeArray<int> trianglesExisting;

			// Token: 0x040001F3 RID: 499
			[ReadOnly]
			public NativeArray<int>.ReadOnly trianglesToAdd;

			// Token: 0x040001F4 RID: 500
			public NativeArray<int> triangles;
		}

		// Token: 0x02000056 RID: 86
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobAddPerVertexData : IJob
		{
			// Token: 0x06000209 RID: 521 RVA: 0x0000E7D8 File Offset: 0x0000C9D8
			public void Execute()
			{
				int value = this.existingCount.Value;
				int value2 = this.toAddCount.Value;
				if (value2 <= 0)
				{
					throw new InvalidOperationException("no need to call this job if no new data exists");
				}
				if (this.vertices.Length != value + value2)
				{
					throw new InvalidOperationException("collections are not the correct " + value.ToString() + value2.ToString() + " largo");
				}
				if (this.vertices.Length != this.normals.Length || this.vertices.Length != this.tangents.Length || this.vertices.Length != this.vertexColors.Length || this.vertices.Length != this.UVs.Length || this.vertices.Length != this.bonesPerVertex.Length)
				{
					throw new InvalidOperationException("data largo is not the same for collections");
				}
				if (value > 0)
				{
					NativeArray<float3>.Copy(this.verticesExisting, 0, this.vertices, 0, value);
					NativeArray<float3>.Copy(this.normalsExisting, 0, this.normals, 0, value);
					NativeArray<float4>.Copy(this.tangentsExisting, 0, this.tangents, 0, value);
					NativeArray<Color>.Copy(this.vertexColorsExisting, 0, this.vertexColors, 0, value);
					NativeArray<float2>.Copy(this.UVsExisting, 0, this.UVs, 0, value);
					NativeArray<byte>.Copy(this.bonesPerVertexExisting, 0, this.bonesPerVertex, 0, value);
				}
				NativeArray<float3>.Copy(this.verticesToAdd, 0, this.vertices, value, value2);
				NativeArray<float3>.Copy(this.normalsToAdd, 0, this.normals, value, value2);
				NativeArray<float4>.Copy(this.tangentsToAdd, 0, this.tangents, value, value2);
				NativeArray<Color>.Copy(this.vertexColorsToAdd, 0, this.vertexColors, value, value2);
				NativeArray<float2>.Copy(this.UVsToAdd, 0, this.UVs, value, value2);
				NativeArray<byte>.Copy(this.bonesPerVertexToAdd, 0, this.bonesPerVertex, value, value2);
			}

			// Token: 0x040001F5 RID: 501
			[ReadOnly]
			public NativeReference<int> existingCount;

			// Token: 0x040001F6 RID: 502
			[ReadOnly]
			public NativeArray<float3> verticesExisting;

			// Token: 0x040001F7 RID: 503
			[ReadOnly]
			public NativeArray<float3> normalsExisting;

			// Token: 0x040001F8 RID: 504
			[ReadOnly]
			public NativeArray<float4> tangentsExisting;

			// Token: 0x040001F9 RID: 505
			[ReadOnly]
			public NativeArray<Color> vertexColorsExisting;

			// Token: 0x040001FA RID: 506
			[ReadOnly]
			public NativeArray<float2> UVsExisting;

			// Token: 0x040001FB RID: 507
			[ReadOnly]
			public NativeArray<byte> bonesPerVertexExisting;

			// Token: 0x040001FC RID: 508
			[ReadOnly]
			public NativeReference<int>.ReadOnly toAddCount;

			// Token: 0x040001FD RID: 509
			[ReadOnly]
			public NativeArray<float3>.ReadOnly verticesToAdd;

			// Token: 0x040001FE RID: 510
			[ReadOnly]
			public NativeArray<float3>.ReadOnly normalsToAdd;

			// Token: 0x040001FF RID: 511
			[ReadOnly]
			public NativeArray<float4>.ReadOnly tangentsToAdd;

			// Token: 0x04000200 RID: 512
			[ReadOnly]
			public NativeArray<Color>.ReadOnly vertexColorsToAdd;

			// Token: 0x04000201 RID: 513
			[ReadOnly]
			public NativeArray<float2>.ReadOnly UVsToAdd;

			// Token: 0x04000202 RID: 514
			[ReadOnly]
			public NativeArray<byte>.ReadOnly bonesPerVertexToAdd;

			// Token: 0x04000203 RID: 515
			public NativeArray<float3> vertices;

			// Token: 0x04000204 RID: 516
			public NativeArray<float3> normals;

			// Token: 0x04000205 RID: 517
			public NativeArray<float4> tangents;

			// Token: 0x04000206 RID: 518
			public NativeArray<Color> vertexColors;

			// Token: 0x04000207 RID: 519
			public NativeArray<float2> UVs;

			// Token: 0x04000208 RID: 520
			public NativeArray<byte> bonesPerVertex;
		}

		// Token: 0x02000057 RID: 87
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobCalculeSemenSkinVertexShaping : IJob
		{
			// Token: 0x0600020A RID: 522 RVA: 0x0000E9B8 File Offset: 0x0000CBB8
			public void Execute()
			{
				int value = this.shapeCountOfSkin.Value;
				int value2 = this.vertexCountSemen.Value;
				for (int i = 0; i < this.headTriangleVertexIndexs.Length; i++)
				{
					int num = this.vertexCountPerParticle[i];
					int3 @int = this.headTriangleVertexIndexs[i];
					int3 int2 = this.tailTriangleVertexIndexs[i];
					float3 @float = this.headBarycentricCoordinates[i];
					float3 float2 = this.tailBarycentricCoordinates[i];
					NativeArray<float3> nativeArray = new NativeArray<float3>(value, Allocator.Temp, NativeArrayOptions.ClearMemory);
					NativeArray<float3> nativeArray2 = new NativeArray<float3>(value, Allocator.Temp, NativeArrayOptions.ClearMemory);
					NativeArray<float3> nativeArray3 = new NativeArray<float3>(value, Allocator.Temp, NativeArrayOptions.ClearMemory);
					NativeArray<float3> nativeArray4 = new NativeArray<float3>(value, Allocator.Temp, NativeArrayOptions.ClearMemory);
					NativeArray<float3> nativeArray5 = new NativeArray<float3>(value, Allocator.Temp, NativeArrayOptions.ClearMemory);
					NativeArray<float3> nativeArray6 = new NativeArray<float3>(value, Allocator.Temp, NativeArrayOptions.ClearMemory);
					this.LoadVertexShapingData(nativeArray, @int.x);
					this.LoadVertexShapingData(nativeArray2, @int.y);
					this.LoadVertexShapingData(nativeArray3, @int.z);
					this.LoadVertexShapingData(nativeArray4, int2.x);
					this.LoadVertexShapingData(nativeArray5, int2.y);
					this.LoadVertexShapingData(nativeArray6, int2.z);
					NativeArray<float3> nativeArray7 = new NativeArray<float3>(value, Allocator.Temp, NativeArrayOptions.ClearMemory);
					NativeArray<float3> nativeArray8 = new NativeArray<float3>(value, Allocator.Temp, NativeArrayOptions.ClearMemory);
					this.LoadBoneWeights(@float, value, nativeArray7, nativeArray, nativeArray2, nativeArray3);
					this.LoadBoneWeights(float2, value, nativeArray8, nativeArray4, nativeArray5, nativeArray6);
					for (int j = 0; j < num; j++)
					{
						int num2 = num * i + j;
						float2 float3 = this.headToTailWeightsPerParticleVertex[j];
						this.AddShapeDeltasToSemenVertex(num2, value2, float3, nativeArray7, nativeArray8);
					}
				}
			}

			// Token: 0x0600020B RID: 523 RVA: 0x0000EB40 File Offset: 0x0000CD40
			private void LoadVertexShapingData(NativeArray<float3> result, int skinVertexIndex)
			{
				ShapeVertexData shapeVertexData;
				NativeParallelMultiHashMapIterator<int> nativeParallelMultiHashMapIterator;
				if (this.allShapeDataPerVertIndexSkin.TryGetFirstValue(skinVertexIndex, out shapeVertexData, out nativeParallelMultiHashMapIterator))
				{
					do
					{
						result[shapeVertexData.shapeIndex] = shapeVertexData.deltaVertice;
					}
					while (this.allShapeDataPerVertIndexSkin.TryGetNextValue(out shapeVertexData, ref nativeParallelMultiHashMapIterator));
				}
			}

			// Token: 0x0600020C RID: 524 RVA: 0x0000EB84 File Offset: 0x0000CD84
			private void LoadBoneWeights(float3 barycentricCoordinates, int shapeCount, NativeArray<float3> combinedDeltas, NativeArray<float3> vertex0Deltas, NativeArray<float3> vertex1Deltas, NativeArray<float3> vertex2Deltas)
			{
				for (int i = 0; i < shapeCount; i++)
				{
					float3 @float = vertex0Deltas[i];
					float3 float2 = vertex1Deltas[i];
					float3 float3 = vertex2Deltas[i];
					float3 float4 = @float * barycentricCoordinates.x + float2 * barycentricCoordinates.y + float3 * barycentricCoordinates.z;
					combinedDeltas[i] = float4;
				}
			}

			// Token: 0x0600020D RID: 525 RVA: 0x0000EBF0 File Offset: 0x0000CDF0
			private void AddShapeDeltasToSemenVertex(int semenVertexIndex, int semenVertexCount, float2 headToTailWeight, NativeArray<float3> headCombinedDeltas, NativeArray<float3> tailCombinedDeltas)
			{
				for (int i = 0; i < headCombinedDeltas.Length; i++)
				{
					float3 @float = headCombinedDeltas[i] * headToTailWeight.x + tailCombinedDeltas[i] * headToTailWeight.y;
					this.sparcedDeltaPositionsOfSemen[semenVertexCount * i + semenVertexIndex] = @float;
				}
			}

			// Token: 0x04000209 RID: 521
			[ReadOnly]
			public NativeArray<int>.ReadOnly vertexCountPerParticle;

			// Token: 0x0400020A RID: 522
			[ReadOnly]
			public NativeArray<int3>.ReadOnly headTriangleVertexIndexs;

			// Token: 0x0400020B RID: 523
			[ReadOnly]
			public NativeArray<int3>.ReadOnly tailTriangleVertexIndexs;

			// Token: 0x0400020C RID: 524
			[ReadOnly]
			public NativeArray<float3>.ReadOnly headBarycentricCoordinates;

			// Token: 0x0400020D RID: 525
			[ReadOnly]
			public NativeArray<float3>.ReadOnly tailBarycentricCoordinates;

			// Token: 0x0400020E RID: 526
			[ReadOnly]
			public NativeArray<float2>.ReadOnly headToTailWeightsPerParticleVertex;

			// Token: 0x0400020F RID: 527
			[ReadOnly]
			public NativeReference<int>.ReadOnly shapeCountOfSkin;

			// Token: 0x04000210 RID: 528
			[ReadOnly]
			public NativeParallelMultiHashMap<int, ShapeVertexData>.ReadOnly allShapeDataPerVertIndexSkin;

			// Token: 0x04000211 RID: 529
			[ReadOnly]
			public NativeReference<int>.ReadOnly vertexCountSemen;

			// Token: 0x04000212 RID: 530
			[WriteOnly]
			public NativeArray<float3> sparcedDeltaPositionsOfSemen;
		}

		// Token: 0x02000058 RID: 88
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobCalculeSemenSkinVertexAttributes : IJob
		{
			// Token: 0x0600020E RID: 526 RVA: 0x0000EC4C File Offset: 0x0000CE4C
			public void Execute()
			{
				for (int i = 0; i < this.headTriangleVertexIndexs.Length; i++)
				{
					int num = this.vertexCountPerParticle[i];
					int3 @int = this.headTriangleVertexIndexs[i];
					int3 int2 = this.tailTriangleVertexIndexs[i];
					float3 @float = this.headBarycentricCoordinates[i];
					float3 float2 = this.tailBarycentricCoordinates[i];
					float3 position = this.GetPosition(@int, @float);
					float3 position2 = this.GetPosition(int2, float2);
					float num2 = math.length(position - position2);
					bool flag = num2 < 0.001f;
					float num3 = math.saturate(math.unlerp(0.001f, 0.005f, num2));
					num3 = math.lerp(1f, 0.05f, num3);
					Color color = this.GetColor(@int, @float);
					Color color2 = this.GetColor(int2, float2);
					for (int j = 0; j < num; j++)
					{
						int num4 = num * i + j;
						float2 float3 = this.headToTailWeightsPerParticleVertex[j];
						float num5;
						if (flag)
						{
							num5 = 1f;
						}
						else
						{
							num5 = math.abs(float3.x - float3.y);
							num5 = math.lerp(num3, 1f, num5);
						}
						float num6 = float3.x + float3.y;
						float3.x /= num6;
						float3.y /= num6;
						Color color3 = color * float3.x + color2 * float3.y;
						color3 = Color.Lerp(Color.black, color3, num5);
						this.semenVertexColors[num4] = color3;
					}
					int num7 = this.triangleCountPerParticle[i];
					int num8 = num * i;
					for (int k = 0; k < this.particleTriangles.Length; k++)
					{
						int num9 = this.particleTriangles[k];
						int num10 = num7 * i + k;
						this.semenTriangles[num10] = num8 + num9;
					}
				}
			}

			// Token: 0x0600020F RID: 527 RVA: 0x0000EE54 File Offset: 0x0000D054
			private Color GetColor(int3 triangle, float3 barycentricCoordinates)
			{
				Color color = this.skinColors[triangle.x];
				Color color2 = this.skinColors[triangle.y];
				Color color3 = this.skinColors[triangle.z];
				return color * barycentricCoordinates.x + color2 * barycentricCoordinates.y + color3 * barycentricCoordinates.z;
			}

			// Token: 0x06000210 RID: 528 RVA: 0x0000EEC4 File Offset: 0x0000D0C4
			private float3 GetPosition(int3 triangle, float3 barycentricCoordinates)
			{
				float3 @float = this.skinVertices[triangle.x];
				float3 float2 = this.skinVertices[triangle.y];
				float3 float3 = this.skinVertices[triangle.z];
				return @float * barycentricCoordinates.x + float2 * barycentricCoordinates.y + float3 * barycentricCoordinates.z;
			}

			// Token: 0x04000213 RID: 531
			[ReadOnly]
			public NativeArray<int>.ReadOnly vertexCountPerParticle;

			// Token: 0x04000214 RID: 532
			[ReadOnly]
			public NativeArray<int>.ReadOnly triangleCountPerParticle;

			// Token: 0x04000215 RID: 533
			[ReadOnly]
			public NativeArray<int3>.ReadOnly headTriangleVertexIndexs;

			// Token: 0x04000216 RID: 534
			[ReadOnly]
			public NativeArray<int3>.ReadOnly tailTriangleVertexIndexs;

			// Token: 0x04000217 RID: 535
			[ReadOnly]
			public NativeArray<float3>.ReadOnly headBarycentricCoordinates;

			// Token: 0x04000218 RID: 536
			[ReadOnly]
			public NativeArray<float3>.ReadOnly tailBarycentricCoordinates;

			// Token: 0x04000219 RID: 537
			[ReadOnly]
			public NativeArray<float2>.ReadOnly headToTailWeightsPerParticleVertex;

			// Token: 0x0400021A RID: 538
			[ReadOnly]
			public NativeArray<int>.ReadOnly particleTriangles;

			// Token: 0x0400021B RID: 539
			[ReadOnly]
			public NativeArray<Color>.ReadOnly skinColors;

			// Token: 0x0400021C RID: 540
			[ReadOnly]
			public NativeArray<float3>.ReadOnly skinVertices;

			// Token: 0x0400021D RID: 541
			[WriteOnly]
			public NativeArray<Color> semenVertexColors;

			// Token: 0x0400021E RID: 542
			[WriteOnly]
			public NativeArray<int> semenTriangles;

			// Token: 0x0400021F RID: 543
			private const float distanceToIgnoreColorReductionStart = 0.001f;

			// Token: 0x04000220 RID: 544
			private const float distanceToIgnoreColorReductionEnd = 0.005f;

			// Token: 0x04000221 RID: 545
			private const float minColor = 0.05f;
		}

		// Token: 0x02000059 RID: 89
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobCalculeSemenSkinVertexSkinning : IJob
		{
			// Token: 0x06000211 RID: 529 RVA: 0x0000EF34 File Offset: 0x0000D134
			public void Execute()
			{
				SemenSkinController.JobCalculeSemenSkinVertexSkinning.SortW sortW = default(SemenSkinController.JobCalculeSemenSkinVertexSkinning.SortW);
				for (int i = 0; i < this.headTriangleVertexIndexs.Length; i++)
				{
					int num = this.vertexCountPerParticle[i];
					int3 @int = this.headTriangleVertexIndexs[i];
					int3 int2 = this.tailTriangleVertexIndexs[i];
					float3 @float = this.headBarycentricCoordinates[i];
					float3 float2 = this.tailBarycentricCoordinates[i];
					NativeHashSet<int> nativeHashSet = new NativeHashSet<int>(2, Allocator.Temp);
					NativeHashMap<int, float> nativeHashMap = new NativeHashMap<int, float>(2, Allocator.Temp);
					NativeHashMap<int, float> nativeHashMap2 = new NativeHashMap<int, float>(2, Allocator.Temp);
					NativeHashMap<int, float> nativeHashMap3 = new NativeHashMap<int, float>(2, Allocator.Temp);
					NativeHashSet<int> nativeHashSet2 = new NativeHashSet<int>(2, Allocator.Temp);
					NativeHashMap<int, float> nativeHashMap4 = new NativeHashMap<int, float>(2, Allocator.Temp);
					NativeHashMap<int, float> nativeHashMap5 = new NativeHashMap<int, float>(2, Allocator.Temp);
					NativeHashMap<int, float> nativeHashMap6 = new NativeHashMap<int, float>(2, Allocator.Temp);
					this.LoadVertexSkinningData(nativeHashSet, nativeHashMap, @int.x);
					this.LoadVertexSkinningData(nativeHashSet, nativeHashMap2, @int.y);
					this.LoadVertexSkinningData(nativeHashSet, nativeHashMap3, @int.z);
					this.LoadVertexSkinningData(nativeHashSet2, nativeHashMap4, int2.x);
					this.LoadVertexSkinningData(nativeHashSet2, nativeHashMap5, int2.y);
					this.LoadVertexSkinningData(nativeHashSet2, nativeHashMap6, int2.z);
					NativeArray<BoneWeight1> nativeArray = new NativeArray<BoneWeight1>(nativeHashSet.Count, Allocator.Temp, NativeArrayOptions.ClearMemory);
					NativeArray<BoneWeight1> nativeArray2 = new NativeArray<BoneWeight1>(nativeHashSet2.Count, Allocator.Temp, NativeArrayOptions.ClearMemory);
					this.LoadBoneWeights(@float, nativeArray, nativeHashSet, nativeHashMap, nativeHashMap2, nativeHashMap3);
					this.LoadBoneWeights(float2, nativeArray2, nativeHashSet2, nativeHashMap4, nativeHashMap5, nativeHashMap6);
					NativeArray<SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail> nativeArray3 = this.CombineHeatAndTailWeights(nativeArray, nativeArray2);
					for (int j = 0; j < num; j++)
					{
						int num2 = num * i + j;
						float2 float3 = this.headToTailWeightsPerParticleVertex[j];
						this.AddBoneWeightsToSemenVertex(num2, nativeArray3, float3, sortW);
					}
				}
			}

			// Token: 0x06000212 RID: 530 RVA: 0x0000F100 File Offset: 0x0000D300
			private void LoadVertexSkinningData(NativeHashSet<int> headBoneIndex, NativeHashMap<int, float> headVertexWeightDeBoneIndex, int skinVertexIndex)
			{
				BoneWeight1 boneWeight;
				NativeParallelMultiHashMapIterator<int> nativeParallelMultiHashMapIterator;
				if (this.allBoneWeightsPerVertIndexSkin.TryGetFirstValue(skinVertexIndex, out boneWeight, out nativeParallelMultiHashMapIterator))
				{
					do
					{
						headVertexWeightDeBoneIndex.Add(boneWeight.boneIndex, boneWeight.weight);
						headBoneIndex.Add(boneWeight.boneIndex);
					}
					while (this.allBoneWeightsPerVertIndexSkin.TryGetNextValue(out boneWeight, ref nativeParallelMultiHashMapIterator));
				}
			}

			// Token: 0x06000213 RID: 531 RVA: 0x0000F154 File Offset: 0x0000D354
			private void LoadBoneWeights(float3 barycentricCoordinates, NativeArray<BoneWeight1> weights, NativeHashSet<int> boneIndexes, NativeHashMap<int, float> vertex0WeightDeBoneIndex, NativeHashMap<int, float> vertex1WeightDeBoneIndex, NativeHashMap<int, float> vertex2WeightDeBoneIndex)
			{
				NativeArray<int> nativeArray = boneIndexes.ToNativeArray(Allocator.Temp);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					int num = nativeArray[i];
					float num2;
					vertex0WeightDeBoneIndex.TryGetValue(num, out num2);
					float num3;
					vertex1WeightDeBoneIndex.TryGetValue(num, out num3);
					float num4;
					vertex2WeightDeBoneIndex.TryGetValue(num, out num4);
					float num5 = num2 * barycentricCoordinates.x + num3 * barycentricCoordinates.y + num4 * barycentricCoordinates.z;
					weights[i] = new BoneWeight1
					{
						boneIndex = num,
						weight = num5
					};
				}
			}

			// Token: 0x06000214 RID: 532 RVA: 0x0000F1EC File Offset: 0x0000D3EC
			private NativeArray<SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail> CombineHeatAndTailWeights(NativeArray<BoneWeight1> headCombinedWeights, NativeArray<BoneWeight1> tailCombinedWeights)
			{
				NativeHashMap<int, SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail> nativeHashMap = new NativeHashMap<int, SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail>(2, Allocator.Temp);
				for (int i = 0; i < headCombinedWeights.Length; i++)
				{
					BoneWeight1 boneWeight = headCombinedWeights[i];
					SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail boneWeightHeadTail;
					if (!nativeHashMap.TryGetValue(boneWeight.boneIndex, out boneWeightHeadTail))
					{
						boneWeightHeadTail = default(SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail);
						boneWeightHeadTail.boneIndex = boneWeight.boneIndex;
						boneWeightHeadTail.headWeight = boneWeight.weight;
						nativeHashMap.Add(boneWeight.boneIndex, boneWeightHeadTail);
					}
				}
				for (int j = 0; j < tailCombinedWeights.Length; j++)
				{
					BoneWeight1 boneWeight2 = tailCombinedWeights[j];
					SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail boneWeightHeadTail2;
					if (!nativeHashMap.TryGetValue(boneWeight2.boneIndex, out boneWeightHeadTail2))
					{
						boneWeightHeadTail2 = default(SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail);
						boneWeightHeadTail2.boneIndex = boneWeight2.boneIndex;
						boneWeightHeadTail2.tailWeight = boneWeight2.weight;
						nativeHashMap.Add(boneWeight2.boneIndex, boneWeightHeadTail2);
					}
					else
					{
						boneWeightHeadTail2.tailWeight = boneWeight2.weight;
						nativeHashMap[boneWeight2.boneIndex] = boneWeightHeadTail2;
					}
				}
				return nativeHashMap.GetValueArray(Allocator.Temp);
			}

			// Token: 0x06000215 RID: 533 RVA: 0x0000F300 File Offset: 0x0000D500
			private void AddBoneWeightsToSemenVertex(int semenVertexIndex, NativeArray<SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail> combinedWeights, float2 headToTailWeight, SemenSkinController.JobCalculeSemenSkinVertexSkinning.SortW sortw)
			{
				if (combinedWeights.Length == 0)
				{
					throw new InvalidOperationException();
				}
				NativeArray<BoneWeight1> nativeArray = new NativeArray<BoneWeight1>(combinedWeights.Length, Allocator.Temp, NativeArrayOptions.ClearMemory);
				this.bonesPerVertexSemen[semenVertexIndex] = (byte)combinedWeights.Length;
				for (int i = 0; i < combinedWeights.Length; i++)
				{
					SemenSkinController.JobCalculeSemenSkinVertexSkinning.BoneWeightHeadTail boneWeightHeadTail = combinedWeights[i];
					float num = boneWeightHeadTail.headWeight * headToTailWeight.x + boneWeightHeadTail.tailWeight * headToTailWeight.y;
					nativeArray[i] = new BoneWeight1
					{
						boneIndex = boneWeightHeadTail.boneIndex,
						weight = num
					};
				}
				if (combinedWeights.Length > 1)
				{
					nativeArray.Sort(sortw);
				}
				this.allBoneWeightsSemen.AddRange(nativeArray);
			}

			// Token: 0x04000222 RID: 546
			[ReadOnly]
			public NativeArray<int>.ReadOnly vertexCountPerParticle;

			// Token: 0x04000223 RID: 547
			[ReadOnly]
			public NativeArray<int3>.ReadOnly headTriangleVertexIndexs;

			// Token: 0x04000224 RID: 548
			[ReadOnly]
			public NativeArray<int3>.ReadOnly tailTriangleVertexIndexs;

			// Token: 0x04000225 RID: 549
			[ReadOnly]
			public NativeArray<float3>.ReadOnly headBarycentricCoordinates;

			// Token: 0x04000226 RID: 550
			[ReadOnly]
			public NativeArray<float3>.ReadOnly tailBarycentricCoordinates;

			// Token: 0x04000227 RID: 551
			[ReadOnly]
			public NativeArray<float2>.ReadOnly headToTailWeightsPerParticleVertex;

			// Token: 0x04000228 RID: 552
			[ReadOnly]
			public NativeParallelMultiHashMap<int, BoneWeight1>.ReadOnly allBoneWeightsPerVertIndexSkin;

			// Token: 0x04000229 RID: 553
			[WriteOnly]
			public NativeList<BoneWeight1> allBoneWeightsSemen;

			// Token: 0x0400022A RID: 554
			[WriteOnly]
			public NativeArray<byte> bonesPerVertexSemen;

			// Token: 0x0200005A RID: 90
			public struct SortW : IComparer<BoneWeight1>
			{
				// Token: 0x06000216 RID: 534 RVA: 0x0000F3BC File Offset: 0x0000D5BC
				public static int CompareTo(float a, float b)
				{
					if (a < b)
					{
						return -1;
					}
					if (a > b)
					{
						return 1;
					}
					if (a == b)
					{
						return 0;
					}
					throw new ArgumentOutOfRangeException();
				}

				// Token: 0x06000217 RID: 535 RVA: 0x0000F3D5 File Offset: 0x0000D5D5
				public int Compare(BoneWeight1 x, BoneWeight1 y)
				{
					return SemenSkinController.JobCalculeSemenSkinVertexSkinning.SortW.CompareTo(y.weight, x.weight);
				}
			}

			// Token: 0x0200005B RID: 91
			public struct BoneWeightHeadTail
			{
				// Token: 0x0400022B RID: 555
				public int boneIndex;

				// Token: 0x0400022C RID: 556
				public float headWeight;

				// Token: 0x0400022D RID: 557
				public float tailWeight;
			}
		}

		// Token: 0x0200005C RID: 92
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobCalculeParticleBonesTransforms : IJobParallelFor
		{
			// Token: 0x06000218 RID: 536 RVA: 0x0000F3EC File Offset: 0x0000D5EC
			public void Execute(int i)
			{
				int3 @int = this.headTriangleVertexIndexs[i];
				int3 int2 = this.tailTriangleVertexIndexs[i];
				float3 @float = this.skinVertices[@int.x];
				float3 float2 = this.skinVertices[@int.y];
				float3 float3 = this.skinVertices[@int.z];
				float3 float4 = this.skinNormals[@int.x];
				float3 float5 = this.skinNormals[@int.y];
				float3 float6 = this.skinNormals[@int.z];
				float4 float7 = this.skinTangents[@int.x];
				float4 float8 = this.skinTangents[@int.y];
				float4 float9 = this.skinTangents[@int.z];
				float3 float10 = this.skinVertices[int2.x];
				float3 float11 = this.skinVertices[int2.y];
				float3 float12 = this.skinVertices[int2.z];
				float3 float13 = this.skinNormals[int2.x];
				float3 float14 = this.skinNormals[int2.y];
				float3 float15 = this.skinNormals[int2.z];
				float4 float16 = this.skinTangents[int2.x];
				float4 float17 = this.skinTangents[int2.y];
				float4 float18 = this.skinTangents[int2.z];
				float num = this.headWTrianglePerimeters[i];
				float num2 = this.tailWTrianglePerimeters[i];
				float num3 = num / this.characterScale.Value;
				float num4 = num2 / this.characterScale.Value;
				float3 float19 = this.headBarycentricCoordinates[i];
				float3 float20 = this.tailBarycentricCoordinates[i];
				quaternion quaternion = this.headDeltaRotations[i];
				quaternion quaternion2 = this.tailDeltaRotations[i];
				float3 float21 = this.headDeltaPositions[i];
				float3 float22 = this.tailDeltaPositions[i];
				float3 float23 = @float * float19.x + float2 * float19.y + float3 * float19.z;
				float3 float24 = float10 * float20.x + float11 * float20.y + float12 * float20.z;
				float3 float25 = float4 * float19.x + float5 * float19.y + float6 * float19.z;
				float3 float26 = float13 * float20.x + float14 * float20.y + float15 * float20.z;
				float4 float27 = float7 * float19.x + float8 * float19.y + float9 * float19.z;
				float4 float28 = float16 * float20.x + float17 * float20.y + float18 * float20.z;
				float num5 = math.length(float2 - @float) + math.length(float3 - float2) + math.length(@float - float3);
				float num6 = math.length(float11 - float10) + math.length(float12 - float11) + math.length(float10 - float12);
				float3 float29 = new float3(1f, 1f, 1f) / (num / num5);
				float3 float30 = new float3(1f, 1f, 1f) / (num2 / num6);
				float num7 = num3 / num5;
				float num8 = num4 / num6;
				float3 float31 = float21 / num7;
				float3 float32 = float22 / num8;
				quaternion quaternion3 = quaternion.LookRotationSafe(float25, float27.xyz);
				quaternion quaternion4 = quaternion.LookRotationSafe(float26, float28.xyz);
				quaternion quaternion5 = math.mul(quaternion3, quaternion);
				quaternion quaternion6 = math.mul(quaternion4, quaternion2);
				float3 float33 = float23 + math.mul(quaternion3, float31);
				float3 float34 = float24 + math.mul(quaternion4, float32);
				float3 float35 = SemenSkinController.JobCalculeParticleBonesTransforms.Scale(this.bone1SkinnedLocalScales[i], float29);
				float3 float36 = SemenSkinController.JobCalculeParticleBonesTransforms.Scale(this.bone2SkinnedLocalScales[i], float30);
				float num9 = (float35.x + float35.y + float35.z) / 3f;
				float3 float37 = float34 - float33;
				float num10 = math.length(float37);
				float num11 = this.distacesToBreak[i] * 1.5f * num9;
				bool flag = num10 <= 1.1754944E-38f;
				bool flag2 = num10 > num11;
				quaternion quaternion7 = math.mul(quaternion5, this.stretchedBoneSkinnedLocalFromHeadRotation[i]);
				float3 float38;
				quaternion quaternion8;
				if (flag || flag2)
				{
					float38 = new float3(0.9f, 0.9f, 0.05f);
					quaternion8 = quaternion5;
					float36 = float35;
					if (flag2)
					{
						float34 = float33;
						this.tailBarycentricCoordinates[i] = float19;
						this.tailTriangleVertexIndexs[i] = @int;
					}
				}
				else
				{
					float38 = this.stretchedBoneSkinnedLocalScales[i];
					quaternion8 = quaternion.LookRotationSafe(float37, math.mul(quaternion7, new float3(0f, 1f, 0f)));
				}
				this.skeletonLocalPositions[i] = float33;
				this.skeletonLocalRotations[i] = quaternion5;
				this.skeletonLocalScales[i] = this.skeletonSkinnedLocalScales[i];
				this.headLocalPositions[i] = float33;
				this.headLocalRotations[i] = quaternion5;
				this.headLocalScales[i] = float35;
				this.stretchedLocalPositions[i] = float33;
				this.stretchedLocalRotations[i] = quaternion8;
				this.stretchedLocalScales[i] = float38;
				this.tailLocalPositions[i] = float34;
				this.tailLocalRotations[i] = quaternion6;
				this.tailLocalScales[i] = float36;
			}

			// Token: 0x06000219 RID: 537 RVA: 0x0000FA0F File Offset: 0x0000DC0F
			private static float3 Scale(float3 a, float3 b)
			{
				return new float3(a.x * b.x, a.y * b.y, a.z * b.z);
			}

			// Token: 0x0400022E RID: 558
			[ReadOnly]
			public NativeReference<float>.ReadOnly characterScale;

			// Token: 0x0400022F RID: 559
			[ReadOnly]
			public NativeArray<float3>.ReadOnly skinVertices;

			// Token: 0x04000230 RID: 560
			[ReadOnly]
			public NativeArray<float3>.ReadOnly skinNormals;

			// Token: 0x04000231 RID: 561
			[ReadOnly]
			public NativeArray<float4>.ReadOnly skinTangents;

			// Token: 0x04000232 RID: 562
			[ReadOnly]
			public NativeArray<float3>.ReadOnly headBarycentricCoordinates;

			// Token: 0x04000233 RID: 563
			public NativeArray<float3> tailBarycentricCoordinates;

			// Token: 0x04000234 RID: 564
			[ReadOnly]
			public NativeArray<int3>.ReadOnly headTriangleVertexIndexs;

			// Token: 0x04000235 RID: 565
			public NativeArray<int3> tailTriangleVertexIndexs;

			// Token: 0x04000236 RID: 566
			[ReadOnly]
			public NativeArray<quaternion>.ReadOnly headDeltaRotations;

			// Token: 0x04000237 RID: 567
			[ReadOnly]
			public NativeArray<quaternion>.ReadOnly tailDeltaRotations;

			// Token: 0x04000238 RID: 568
			[ReadOnly]
			public NativeArray<float3>.ReadOnly headDeltaPositions;

			// Token: 0x04000239 RID: 569
			[ReadOnly]
			public NativeArray<float3>.ReadOnly tailDeltaPositions;

			// Token: 0x0400023A RID: 570
			[ReadOnly]
			public NativeArray<float>.ReadOnly headWTrianglePerimeters;

			// Token: 0x0400023B RID: 571
			[ReadOnly]
			public NativeArray<float>.ReadOnly tailWTrianglePerimeters;

			// Token: 0x0400023C RID: 572
			[ReadOnly]
			public NativeArray<float>.ReadOnly distacesToBreak;

			// Token: 0x0400023D RID: 573
			[ReadOnly]
			public NativeArray<float3>.ReadOnly skeletonSkinnedLocalScales;

			// Token: 0x0400023E RID: 574
			[ReadOnly]
			public NativeArray<float3>.ReadOnly bone1SkinnedLocalScales;

			// Token: 0x0400023F RID: 575
			[ReadOnly]
			public NativeArray<float3>.ReadOnly bone2SkinnedLocalScales;

			// Token: 0x04000240 RID: 576
			[ReadOnly]
			public NativeArray<float3>.ReadOnly stretchedBoneSkinnedLocalScales;

			// Token: 0x04000241 RID: 577
			[ReadOnly]
			public NativeArray<quaternion>.ReadOnly stretchedBoneSkinnedLocalFromHeadRotation;

			// Token: 0x04000242 RID: 578
			[WriteOnly]
			public NativeArray<float3> skeletonLocalPositions;

			// Token: 0x04000243 RID: 579
			[WriteOnly]
			public NativeArray<quaternion> skeletonLocalRotations;

			// Token: 0x04000244 RID: 580
			[WriteOnly]
			public NativeArray<float3> skeletonLocalScales;

			// Token: 0x04000245 RID: 581
			[WriteOnly]
			public NativeArray<float3> headLocalPositions;

			// Token: 0x04000246 RID: 582
			[WriteOnly]
			public NativeArray<quaternion> headLocalRotations;

			// Token: 0x04000247 RID: 583
			[WriteOnly]
			public NativeArray<float3> headLocalScales;

			// Token: 0x04000248 RID: 584
			[WriteOnly]
			public NativeArray<float3> stretchedLocalPositions;

			// Token: 0x04000249 RID: 585
			[WriteOnly]
			public NativeArray<quaternion> stretchedLocalRotations;

			// Token: 0x0400024A RID: 586
			[WriteOnly]
			public NativeArray<float3> stretchedLocalScales;

			// Token: 0x0400024B RID: 587
			[WriteOnly]
			public NativeArray<float3> tailLocalPositions;

			// Token: 0x0400024C RID: 588
			[WriteOnly]
			public NativeArray<quaternion> tailLocalRotations;

			// Token: 0x0400024D RID: 589
			[WriteOnly]
			public NativeArray<float3> tailLocalScales;
		}

		// Token: 0x0200005D RID: 93
		[Serializable]
		public class SemenSkin
		{
			// Token: 0x17000051 RID: 81
			// (get) Token: 0x0600021A RID: 538 RVA: 0x0000FA3D File Offset: 0x0000DC3D
			public bool consolidado
			{
				get
				{
					return this.m_consolidado;
				}
			}

			// Token: 0x17000052 RID: 82
			// (get) Token: 0x0600021B RID: 539 RVA: 0x0000FA45 File Offset: 0x0000DC45
			public int currentVertexCount
			{
				get
				{
					if (this.m_currentPerVertexData != null)
					{
						return this.m_currentPerVertexData.vertices.Length;
					}
					return 0;
				}
			}

			// Token: 0x17000053 RID: 83
			// (get) Token: 0x0600021C RID: 540 RVA: 0x0000FA61 File Offset: 0x0000DC61
			public float currentLifeTime
			{
				get
				{
					return Time.time - this.m_createdTime;
				}
			}

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x0600021D RID: 541 RVA: 0x0000FA6F File Offset: 0x0000DC6F
			public float currentLifeTimeAfterConsolidation
			{
				get
				{
					return Time.time - this.m_consolidatedTime;
				}
			}

			// Token: 0x17000055 RID: 85
			// (get) Token: 0x0600021E RID: 542 RVA: 0x0000FA7D File Offset: 0x0000DC7D
			public SemenSkinController.SemenSkin.PerVertexData currentPerVertexData
			{
				get
				{
					return this.m_currentPerVertexData;
				}
			}

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x0600021F RID: 543 RVA: 0x0000FA85 File Offset: 0x0000DC85
			public SemenSkinController.SemenSkin.PerTriangleData currentPerTriangleData
			{
				get
				{
					return this.m_currentPerTriangleData;
				}
			}

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x06000220 RID: 544 RVA: 0x0000FA8D File Offset: 0x0000DC8D
			public SemenSkinController.SemenSkin.PerBoneWeightsData currentPerBoneWeightsData
			{
				get
				{
					return this.m_currentPerBoneWeightsData;
				}
			}

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x06000221 RID: 545 RVA: 0x0000FA95 File Offset: 0x0000DC95
			public SemenSkinController.SemenSkin.PerSparcedShapeDeltasData currentPerSparcedShapeDeltasData
			{
				get
				{
					return this.m_currentPerSparcedShapeDeltasData;
				}
			}

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x06000222 RID: 546 RVA: 0x0000FA9D File Offset: 0x0000DC9D
			public SkinnedMeshRenderer skinnedMeshRenderer
			{
				get
				{
					return this.m_SkinnedMeshRenderer;
				}
			}

			// Token: 0x06000223 RID: 547 RVA: 0x0000FAA8 File Offset: 0x0000DCA8
			public void GetParticlesData([TupleElementNames(new string[] { "selfData", "nextData" })] List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> result)
			{
				if (this.m_particlesData == null)
				{
					return;
				}
				for (int i = 0; i < this.m_particlesData.Count; i++)
				{
					ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = this.m_particlesData[i];
					NativeArray<ValueTuple<ParteDelCuerpoHumano, Side>> partesImpactadas = valueTuple.Item1.partesImpactadas;
					valueTuple.Item1.partesImpactadas = new NativeArray<ValueTuple<ParteDelCuerpoHumano, Side>>(partesImpactadas, Allocator.Persistent);
					result.Add(valueTuple);
				}
			}

			// Token: 0x06000224 RID: 548 RVA: 0x0000FB08 File Offset: 0x0000DD08
			public void Init(SemenSkinController controller, int index)
			{
				this.m_createdTime = Time.time;
				this.m_SkinnedMeshRenderer = controller.transform.CreateChild(controller.m_Skin.name + "SemenDynamic" + index.ToString()).gameObject.AddComponent<SkinnedMeshRenderer>();
				foreach (Material material in this.m_SkinnedMeshRenderer.sharedMaterials)
				{
					if (material != null)
					{
						Object.Destroy(material);
					}
				}
				this.m_SkinnedMeshRenderer.bones = controller.m_SkinData.bones;
				this.m_SkinnedMeshRenderer.rootBone = controller.m_Skin.skinnedMeshRenderer.rootBone;
				this.m_material = Object.Instantiate<Material>(Singleton<ColleccionDeParticulas>.instance.semenSkinMaterial);
				this.m_SkinnedMeshRenderer.sharedMaterial = this.m_material;
				bool updateWhenOffscreen = controller.m_Skin.skinnedMeshRenderer.updateWhenOffscreen;
				controller.m_Skin.skinnedMeshRenderer.updateWhenOffscreen = false;
				this.m_SkinnedMeshRenderer.localBounds = controller.m_Skin.skinnedMeshRenderer.localBounds;
				controller.m_Skin.skinnedMeshRenderer.updateWhenOffscreen = updateWhenOffscreen;
				this.m_materialDefaultValues = SemenSkinController.SemenSkin.MaterialFieldValues.Load(this.m_material);
				if (controller.config.sensibleToMaleSensors || controller.config.sensibleToSelfSensors)
				{
					VertExmotion.SetSensorsCount();
					VertExmotion componentNotNull = this.m_SkinnedMeshRenderer.GetComponentNotNull<VertExmotion>();
					componentNotNull.m_params.usePaintDataFromMeshColors = true;
					componentNotNull.m_normalCorrection = 0f;
					componentNotNull.m_normalSmooth = 0f;
					componentNotNull.m_useVertexBufferMode = false;
					this.m_SkinnedMeshRenderer.GetComponentNotNull<VertExmotionUpdater>();
					LoadSensoresDeMainCharacter componentNotNull2 = this.m_SkinnedMeshRenderer.GetComponentNotNull<LoadSensoresDeMainCharacter>();
					componentNotNull2.layer = SensorConLayers.Layer.skin;
					componentNotNull2.loadFromMainCharacter = controller.config.sensibleToMaleSensors;
					componentNotNull2.loadFromSelfCharacter = controller.config.sensibleToSelfSensors;
				}
			}

			// Token: 0x06000225 RID: 549 RVA: 0x0000FCCC File Offset: 0x0000DECC
			public void Rebuild(SemenSkinController controller, IReadOnlyList<SemenSkinController.SemenChainPar> particles, SemenSkinController.SemenSkin.PerVertexData perVertexData, SemenSkinController.SemenSkin.PerTriangleData perTriangleData, SemenSkinController.SemenSkin.PerBoneWeightsData perBoneWeightsData, SemenSkinController.SemenSkin.PerSparcedShapeDeltasData perSparcedShapeDeltasData)
			{
				if (!perVertexData.initiated || !perTriangleData.initiated || !perBoneWeightsData.initiated || !perSparcedShapeDeltasData.initiated)
				{
					throw new InvalidOperationException();
				}
				this.Dispose();
				this.DestroyCurrentMesh();
				this.m_currentPerVertexData = perVertexData;
				this.m_currentPerTriangleData = perTriangleData;
				this.m_currentPerBoneWeightsData = perBoneWeightsData;
				this.m_currentPerSparcedShapeDeltasData = perSparcedShapeDeltasData;
				this.m_currentMesh = new Mesh();
				this.m_currentMesh.MarkDynamic();
				this.m_currentMesh.SetVertices<float3>(perVertexData.vertices, 0, perVertexData.dataLength, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				this.m_currentMesh.SetNormals<float3>(perVertexData.normals, 0, perVertexData.dataLength, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				this.m_currentMesh.SetTangents<float4>(perVertexData.tangents, 0, perVertexData.dataLength, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				this.m_currentMesh.SetColors<Color>(perVertexData.vertexColors, 0, perVertexData.dataLength, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				this.m_currentMesh.SetUVs<float2>(0, perVertexData.UVs, 0, perVertexData.dataLength, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				this.m_currentMesh.SetTriangles(perTriangleData.triangles.ToArray(), 0);
				this.m_currentMesh.SetBoneWeights(perVertexData.bonesPerVertex, perBoneWeightsData.allBoneWeights);
				this.m_currentMesh.bindposes = controller.m_IMeshSkinningDataGetter.binePoses.Reinterpret<Matrix4x4>().ToArray();
				Mesh originalMesh = controller.m_IMeshGetter.originalMesh;
				Vector3[] array = new Vector3[perVertexData.dataLength];
				NativeArray<Vector3> nativeArray = perSparcedShapeDeltasData.sparcedDeltaPositions.Reinterpret<Vector3>();
				for (int i = 0; i < controller.m_SkinData.shapeCount; i++)
				{
					NativeArray<Vector3>.Copy(nativeArray.GetSubArray(perVertexData.dataLength * i, perVertexData.dataLength), 0, array, 0, perVertexData.dataLength);
					this.m_currentMesh.AddBlendShapeFrame(originalMesh.GetBlendShapeName(i), originalMesh.GetBlendShapeFrameWeight(i, 0), array, null, null);
				}
				this.m_SkinnedMeshRenderer.sharedMesh = this.m_currentMesh;
				this.m_currentMesh.RecalculateBounds();
				this.m_currentMesh.MarkModified();
				if (this.m_ShapeKeyCopier == null)
				{
					this.m_ShapeKeyCopier = GenericShapeKeyCopier.Add(this.m_SkinnedMeshRenderer, controller.m_Skin.skinnedMeshRenderer);
				}
				this.OnRebuilded(controller, particles);
			}

			// Token: 0x06000226 RID: 550 RVA: 0x0000FEF8 File Offset: 0x0000E0F8
			private void OnRebuilded(SemenSkinController controller, IReadOnlyList<SemenSkinController.SemenChainPar> particles)
			{
				if (this.m_consolidado)
				{
					throw new InvalidOperationException();
				}
				for (int i = 0; i < particles.Count; i++)
				{
					SemenSkinController.SemenChainPar semenChainPar = particles[i];
					if (semenChainPar.selfData.semenData.existio)
					{
						for (int j = 0; j < semenChainPar.selfData.partesImpactadas.Length; j++)
						{
							this.m_newPartesImpactadas.Add(semenChainPar.selfData.partesImpactadas[j]);
						}
						this.m_particlesData.Add(new ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>(semenChainPar.selfData, semenChainPar.nextData));
						this.m_duration = Mathf.Max(this.m_duration, semenChainPar.selfData.duraction);
					}
				}
			}

			// Token: 0x06000227 RID: 551 RVA: 0x0000FFB4 File Offset: 0x0000E1B4
			public void OnParticlesDestroyed(SemenSkinController controller)
			{
				for (int i = 0; i < this.m_newPartesImpactadas.Count; i++)
				{
					ValueTuple<ParteDelCuerpoHumano, Side> valueTuple = this.m_newPartesImpactadas[i];
					if (controller.m_characterAI.isActiveAndEnabled)
					{
						controller.m_characterAI.RegistrarSemenSobre(valueTuple.Item1, TipoDeSemen.semen, valueTuple.Item2, 1);
					}
				}
				this.m_partesImpactadas.AddRange(this.m_newPartesImpactadas);
				this.m_newPartesImpactadas.Clear();
			}

			// Token: 0x06000228 RID: 552 RVA: 0x00010026 File Offset: 0x0000E226
			public void Consolidar(SemenSkinController controller)
			{
				this.Dispose();
				if (this.m_consolidado)
				{
					return;
				}
				this.m_consolidatedTime = Time.time;
				this.m_duration *= 3f.Random(0.3333f);
				this.m_consolidado = true;
			}

			// Token: 0x06000229 RID: 553 RVA: 0x00010068 File Offset: 0x0000E268
			public void Update(SemenSkinController controller)
			{
				if (this.m_consolidado)
				{
					if (this.currentLifeTimeAfterConsolidation > this.m_duration)
					{
						controller.DestroySemenSkin(this);
						return;
					}
					float num = Mathf.InverseLerp(0f, this.m_duration, this.currentLifeTimeAfterConsolidation).OutPow(6f);
					if (num > 0.9f)
					{
						this.UnRegistrar(controller);
					}
					if (!this.m_updateMaterialCoolDown.isOn)
					{
						Color color = this.m_materialDefaultValues.color;
						float num2;
						float num3;
						float num4;
						Color.RGBToHSV(color, out num2, out num3, out num4);
						float num5 = Mathf.Lerp(color.a, 1f, num);
						num4 = Mathf.Lerp(num4, 0f, num);
						color = Color.HSVToRGB(num2, num3, num4);
						color.a = num5;
						this.m_material.SetColor(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.color, color);
						this.m_material.SetFloat(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.smooth, Mathf.Lerp(this.m_materialDefaultValues.smooth, 1f, num));
						this.m_material.SetFloat(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.normal, Mathf.Lerp(this.m_materialDefaultValues.normal, 0f, num));
						this.m_material.SetFloat(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.heightOffset, Mathf.Lerp(this.m_materialDefaultValues.heightOffset, controller.config.semenMinDisplacementOffset, num));
						this.m_updateMaterialCoolDown.ApplyNext(2f.Random(0.5f));
					}
				}
			}

			// Token: 0x0600022A RID: 554 RVA: 0x000101DC File Offset: 0x0000E3DC
			private void UnRegistrar(SemenSkinController controller)
			{
				if (this.m_unRegistrado)
				{
					return;
				}
				for (int i = 0; i < this.m_partesImpactadas.Count; i++)
				{
					ValueTuple<ParteDelCuerpoHumano, Side> valueTuple = this.m_partesImpactadas[i];
					bool? flag;
					if (controller == null)
					{
						flag = null;
					}
					else
					{
						CharAi characterAI = controller.m_characterAI;
						flag = ((characterAI != null) ? new bool?(characterAI.isActiveAndEnabled) : null);
					}
					bool? flag2 = flag;
					if (flag2.GetValueOrDefault() && controller != null)
					{
						CharAi characterAI2 = controller.m_characterAI;
						if (characterAI2 != null)
						{
							characterAI2.UnRegistrarSemenSobre(valueTuple.Item1, TipoDeSemen.semen, valueTuple.Item2, 1);
						}
					}
				}
				this.m_unRegistrado = true;
			}

			// Token: 0x0600022B RID: 555 RVA: 0x00010278 File Offset: 0x0000E478
			public void Destroy(SemenSkinController controller)
			{
				this.UnRegistrar(controller);
				Object.Destroy(this.m_SkinnedMeshRenderer.gameObject);
				Object.Destroy(this.m_material);
				this.Dispose();
				this.DestroyCurrentMesh();
				for (int i = 0; i < this.m_particlesData.Count; i++)
				{
					ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData> valueTuple = this.m_particlesData[i];
					if (valueTuple.Item1.partesImpactadas.IsCreated)
					{
						valueTuple.Item1.partesImpactadas.Dispose();
					}
				}
				this.m_particlesData = null;
			}

			// Token: 0x0600022C RID: 556 RVA: 0x00010301 File Offset: 0x0000E501
			private void DestroyCurrentMesh()
			{
				if (this.m_currentMesh != null)
				{
					Object.Destroy(this.m_currentMesh);
				}
				this.m_currentMesh = null;
			}

			// Token: 0x0600022D RID: 557 RVA: 0x00010324 File Offset: 0x0000E524
			private void Dispose()
			{
				SemenSkinController.SemenSkin.PerVertexData currentPerVertexData = this.m_currentPerVertexData;
				if (currentPerVertexData != null)
				{
					currentPerVertexData.Dispose();
				}
				SemenSkinController.SemenSkin.PerTriangleData currentPerTriangleData = this.m_currentPerTriangleData;
				if (currentPerTriangleData != null)
				{
					currentPerTriangleData.Dispose();
				}
				SemenSkinController.SemenSkin.PerBoneWeightsData currentPerBoneWeightsData = this.m_currentPerBoneWeightsData;
				if (currentPerBoneWeightsData != null)
				{
					currentPerBoneWeightsData.Dispose();
				}
				SemenSkinController.SemenSkin.PerSparcedShapeDeltasData currentPerSparcedShapeDeltasData = this.m_currentPerSparcedShapeDeltasData;
				if (currentPerSparcedShapeDeltasData != null)
				{
					currentPerSparcedShapeDeltasData.Dispose();
				}
				this.m_currentPerVertexData = null;
				this.m_currentPerTriangleData = null;
				this.m_currentPerBoneWeightsData = null;
				this.m_currentPerSparcedShapeDeltasData = null;
			}

			// Token: 0x0400024E RID: 590
			private SemenSkinController.SemenSkin.PerVertexData m_currentPerVertexData;

			// Token: 0x0400024F RID: 591
			private SemenSkinController.SemenSkin.PerTriangleData m_currentPerTriangleData;

			// Token: 0x04000250 RID: 592
			private SemenSkinController.SemenSkin.PerBoneWeightsData m_currentPerBoneWeightsData;

			// Token: 0x04000251 RID: 593
			private SemenSkinController.SemenSkin.PerSparcedShapeDeltasData m_currentPerSparcedShapeDeltasData;

			// Token: 0x04000252 RID: 594
			private List<ValueTuple<ParteDelCuerpoHumano, Side>> m_partesImpactadas = new List<ValueTuple<ParteDelCuerpoHumano, Side>>();

			// Token: 0x04000253 RID: 595
			private List<ValueTuple<ParteDelCuerpoHumano, Side>> m_newPartesImpactadas = new List<ValueTuple<ParteDelCuerpoHumano, Side>>();

			// Token: 0x04000254 RID: 596
			[ReadOnly]
			[SerializeField]
			private SkinnedMeshRenderer m_SkinnedMeshRenderer;

			// Token: 0x04000255 RID: 597
			private GenericShapeKeyCopier m_ShapeKeyCopier;

			// Token: 0x04000256 RID: 598
			[ReadOnly]
			[SerializeField]
			private Mesh m_currentMesh;

			// Token: 0x04000257 RID: 599
			[ReadOnly]
			[SerializeField]
			private Material m_material;

			// Token: 0x04000258 RID: 600
			[ReadOnly]
			[SerializeField]
			private float m_createdTime;

			// Token: 0x04000259 RID: 601
			[ReadOnly]
			[SerializeField]
			private float m_consolidatedTime;

			// Token: 0x0400025A RID: 602
			[ReadOnly]
			[SerializeField]
			private bool m_consolidado;

			// Token: 0x0400025B RID: 603
			[ReadOnly]
			[SerializeField]
			private float m_duration;

			// Token: 0x0400025C RID: 604
			[SerializeField]
			private SemenSkinController.SemenSkin.MaterialFieldValues m_materialDefaultValues;

			// Token: 0x0400025D RID: 605
			private CoolDown m_updateMaterialCoolDown = new CoolDown();

			// Token: 0x0400025E RID: 606
			[TupleElementNames(new string[] { "selfData", "nextData" })]
			[SerializeField]
			private List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>> m_particlesData = new List<ValueTuple<SemenSelfPointToSemenSkinData, SemenPointToSemenSkinData>>();

			// Token: 0x0400025F RID: 607
			private bool m_unRegistrado;

			// Token: 0x0200005E RID: 94
			[Serializable]
			public struct MaterialFieldValues
			{
				// Token: 0x0600022F RID: 559 RVA: 0x000103C8 File Offset: 0x0000E5C8
				public static SemenSkinController.SemenSkin.MaterialFieldValues Load(Material mat)
				{
					return new SemenSkinController.SemenSkin.MaterialFieldValues
					{
						color = mat.GetColor(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.color),
						metalic = mat.GetFloat(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.metalic),
						smooth = mat.GetFloat(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.smooth),
						normal = mat.GetFloat(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.normal),
						heightOffset = mat.GetFloat(SemenSkinController.SemenSkin.MaterialFieldIDs.@default.heightOffset)
					};
				}

				// Token: 0x04000260 RID: 608
				public Color color;

				// Token: 0x04000261 RID: 609
				public float metalic;

				// Token: 0x04000262 RID: 610
				public float smooth;

				// Token: 0x04000263 RID: 611
				public float normal;

				// Token: 0x04000264 RID: 612
				public float heightOffset;
			}

			// Token: 0x0200005F RID: 95
			public class MaterialFieldIDs
			{
				// Token: 0x1700005A RID: 90
				// (get) Token: 0x06000230 RID: 560 RVA: 0x00010451 File Offset: 0x0000E651
				public static SemenSkinController.SemenSkin.MaterialFieldIDs @default
				{
					get
					{
						if (SemenSkinController.SemenSkin.MaterialFieldIDs.m_default == null)
						{
							SemenSkinController.SemenSkin.MaterialFieldIDs.m_default = new SemenSkinController.SemenSkin.MaterialFieldIDs();
						}
						return SemenSkinController.SemenSkin.MaterialFieldIDs.m_default;
					}
				}

				// Token: 0x06000231 RID: 561 RVA: 0x0001046C File Offset: 0x0000E66C
				private MaterialFieldIDs()
				{
					this.color = Shader.PropertyToID("_BaseColor");
					this.metalic = Shader.PropertyToID("_Metallic");
					this.smooth = Shader.PropertyToID("_Smoothness");
					this.normal = Shader.PropertyToID("_NormalScale");
					this.heightOffset = Shader.PropertyToID("_HeightOffset");
				}

				// Token: 0x04000265 RID: 613
				private static SemenSkinController.SemenSkin.MaterialFieldIDs m_default;

				// Token: 0x04000266 RID: 614
				public int color;

				// Token: 0x04000267 RID: 615
				public int metalic;

				// Token: 0x04000268 RID: 616
				public int smooth;

				// Token: 0x04000269 RID: 617
				public int normal;

				// Token: 0x0400026A RID: 618
				public int heightOffset;
			}

			// Token: 0x02000060 RID: 96
			public class PerSparcedShapeDeltasData : SemenSkinController.SemenSkin.Data
			{
				// Token: 0x1700005B RID: 91
				// (get) Token: 0x06000232 RID: 562 RVA: 0x000104CF File Offset: 0x0000E6CF
				public static SemenSkinController.SemenSkin.PerSparcedShapeDeltasData empty
				{
					get
					{
						if (SemenSkinController.SemenSkin.PerSparcedShapeDeltasData.m_empty == null)
						{
							SemenSkinController.SemenSkin.PerSparcedShapeDeltasData.m_empty = new SemenSkinController.SemenSkin.PerSparcedShapeDeltasData();
							SemenSkinController.SemenSkin.PerSparcedShapeDeltasData.m_empty.Init(0);
						}
						return SemenSkinController.SemenSkin.PerSparcedShapeDeltasData.m_empty;
					}
				}

				// Token: 0x06000233 RID: 563 RVA: 0x000104F2 File Offset: 0x0000E6F2
				protected override void OnInit(int dataLength)
				{
					this.sparcedDeltaPositions = new NativeArray<float3>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				}

				// Token: 0x06000234 RID: 564 RVA: 0x00010502 File Offset: 0x0000E702
				protected override void OnDispose()
				{
					if (this.sparcedDeltaPositions.IsCreated)
					{
						this.sparcedDeltaPositions.Dispose();
					}
				}

				// Token: 0x0400026B RID: 619
				private static SemenSkinController.SemenSkin.PerSparcedShapeDeltasData m_empty;

				// Token: 0x0400026C RID: 620
				public NativeArray<float3> sparcedDeltaPositions;
			}

			// Token: 0x02000061 RID: 97
			public class PerBoneWeightsData : SemenSkinController.SemenSkin.Data
			{
				// Token: 0x1700005C RID: 92
				// (get) Token: 0x06000236 RID: 566 RVA: 0x00010524 File Offset: 0x0000E724
				public static SemenSkinController.SemenSkin.PerBoneWeightsData empty
				{
					get
					{
						if (SemenSkinController.SemenSkin.PerBoneWeightsData.m_empty == null)
						{
							SemenSkinController.SemenSkin.PerBoneWeightsData.m_empty = new SemenSkinController.SemenSkin.PerBoneWeightsData();
							SemenSkinController.SemenSkin.PerBoneWeightsData.m_empty.Init(0);
						}
						return SemenSkinController.SemenSkin.PerBoneWeightsData.m_empty;
					}
				}

				// Token: 0x06000237 RID: 567 RVA: 0x00010547 File Offset: 0x0000E747
				protected override void OnInit(int dataLength)
				{
					this.allBoneWeights = new NativeArray<BoneWeight1>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				}

				// Token: 0x06000238 RID: 568 RVA: 0x00010557 File Offset: 0x0000E757
				protected override void OnDispose()
				{
					if (this.allBoneWeights.IsCreated)
					{
						this.allBoneWeights.Dispose();
					}
				}

				// Token: 0x0400026D RID: 621
				private static SemenSkinController.SemenSkin.PerBoneWeightsData m_empty;

				// Token: 0x0400026E RID: 622
				public NativeArray<BoneWeight1> allBoneWeights;
			}

			// Token: 0x02000062 RID: 98
			public class PerTriangleData : SemenSkinController.SemenSkin.Data
			{
				// Token: 0x1700005D RID: 93
				// (get) Token: 0x0600023A RID: 570 RVA: 0x00010571 File Offset: 0x0000E771
				public static SemenSkinController.SemenSkin.PerTriangleData empty
				{
					get
					{
						if (SemenSkinController.SemenSkin.PerTriangleData.m_empty == null)
						{
							SemenSkinController.SemenSkin.PerTriangleData.m_empty = new SemenSkinController.SemenSkin.PerTriangleData();
							SemenSkinController.SemenSkin.PerTriangleData.m_empty.Init(0);
						}
						return SemenSkinController.SemenSkin.PerTriangleData.m_empty;
					}
				}

				// Token: 0x0600023B RID: 571 RVA: 0x00010594 File Offset: 0x0000E794
				protected override void OnInit(int dataLength)
				{
					this.triangles = new NativeArray<int>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				}

				// Token: 0x0600023C RID: 572 RVA: 0x000105A4 File Offset: 0x0000E7A4
				protected override void OnDispose()
				{
					if (this.triangles.IsCreated)
					{
						this.triangles.Dispose();
					}
				}

				// Token: 0x0400026F RID: 623
				private static SemenSkinController.SemenSkin.PerTriangleData m_empty;

				// Token: 0x04000270 RID: 624
				public NativeArray<int> triangles;
			}

			// Token: 0x02000063 RID: 99
			public class PerVertexData : SemenSkinController.SemenSkin.Data
			{
				// Token: 0x1700005E RID: 94
				// (get) Token: 0x0600023E RID: 574 RVA: 0x000105BE File Offset: 0x0000E7BE
				public static SemenSkinController.SemenSkin.PerVertexData empty
				{
					get
					{
						if (SemenSkinController.SemenSkin.PerVertexData.m_empty == null)
						{
							SemenSkinController.SemenSkin.PerVertexData.m_empty = new SemenSkinController.SemenSkin.PerVertexData();
							SemenSkinController.SemenSkin.PerVertexData.m_empty.Init(0);
						}
						return SemenSkinController.SemenSkin.PerVertexData.m_empty;
					}
				}

				// Token: 0x0600023F RID: 575 RVA: 0x000105E4 File Offset: 0x0000E7E4
				protected override void OnInit(int dataLength)
				{
					this.vertices = new NativeArray<float3>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					this.normals = new NativeArray<float3>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					this.tangents = new NativeArray<float4>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					this.vertexColors = new NativeArray<Color>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					this.UVs = new NativeArray<float2>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					this.bonesPerVertex = new NativeArray<byte>(dataLength, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				}

				// Token: 0x06000240 RID: 576 RVA: 0x00010648 File Offset: 0x0000E848
				protected override void OnDispose()
				{
					if (this.vertices.IsCreated)
					{
						this.vertices.Dispose();
					}
					if (this.normals.IsCreated)
					{
						this.normals.Dispose();
					}
					if (this.tangents.IsCreated)
					{
						this.tangents.Dispose();
					}
					if (this.vertexColors.IsCreated)
					{
						this.vertexColors.Dispose();
					}
					if (this.UVs.IsCreated)
					{
						this.UVs.Dispose();
					}
					if (this.bonesPerVertex.IsCreated)
					{
						this.bonesPerVertex.Dispose();
					}
				}

				// Token: 0x04000271 RID: 625
				private static SemenSkinController.SemenSkin.PerVertexData m_empty;

				// Token: 0x04000272 RID: 626
				public NativeArray<float3> vertices;

				// Token: 0x04000273 RID: 627
				public NativeArray<float3> normals;

				// Token: 0x04000274 RID: 628
				public NativeArray<float4> tangents;

				// Token: 0x04000275 RID: 629
				public NativeArray<Color> vertexColors;

				// Token: 0x04000276 RID: 630
				public NativeArray<float2> UVs;

				// Token: 0x04000277 RID: 631
				public NativeArray<byte> bonesPerVertex;
			}

			// Token: 0x02000064 RID: 100
			public abstract class Data
			{
				// Token: 0x1700005F RID: 95
				// (get) Token: 0x06000242 RID: 578 RVA: 0x000106E5 File Offset: 0x0000E8E5
				public NativeReference<int> dataLengthNativeReference
				{
					get
					{
						return this.m_dataLengthNativeReference;
					}
				}

				// Token: 0x17000060 RID: 96
				// (get) Token: 0x06000243 RID: 579 RVA: 0x000106ED File Offset: 0x0000E8ED
				public int dataLength
				{
					get
					{
						return this.m_dataLength;
					}
				}

				// Token: 0x17000061 RID: 97
				// (get) Token: 0x06000244 RID: 580 RVA: 0x000106F5 File Offset: 0x0000E8F5
				public bool initiated
				{
					get
					{
						return this.m_init;
					}
				}

				// Token: 0x06000245 RID: 581 RVA: 0x00010700 File Offset: 0x0000E900
				public void Init(int dataLength)
				{
					if (this.m_init)
					{
						return;
					}
					try
					{
						this.m_dataLength = dataLength;
						this.m_dataLengthNativeReference = new NativeReference<int>(dataLength, Allocator.Persistent);
						this.OnInit(dataLength);
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
					}
					this.m_init = true;
				}

				// Token: 0x06000246 RID: 582
				protected abstract void OnInit(int dataLength);

				// Token: 0x06000247 RID: 583
				protected abstract void OnDispose();

				// Token: 0x06000248 RID: 584 RVA: 0x00010758 File Offset: 0x0000E958
				public void Dispose()
				{
					if (!this.m_init)
					{
						return;
					}
					if (this.m_dataLengthNativeReference.IsCreated)
					{
						this.m_dataLengthNativeReference.Dispose();
					}
					this.OnDispose();
				}

				// Token: 0x04000278 RID: 632
				private NativeReference<int> m_dataLengthNativeReference;

				// Token: 0x04000279 RID: 633
				private int m_dataLength;

				// Token: 0x0400027A RID: 634
				private bool m_init;
			}
		}

		// Token: 0x02000065 RID: 101
		[Serializable]
		public class SemenChainPar
		{
			// Token: 0x0600024A RID: 586 RVA: 0x00010781 File Offset: 0x0000E981
			public SemenChainPar(SemenMeshToSkinMesh Self, SemenMeshToSkinMesh Next)
			{
				this.m_isInyectedData = false;
				this.m_self = Self;
				this.m_next = Next;
			}

			// Token: 0x0600024B RID: 587 RVA: 0x0001079E File Offset: 0x0000E99E
			public SemenChainPar(SemenSelfPointToSemenSkinData Self, SemenPointToSemenSkinData Next)
				: this(ref Self, ref Next)
			{
			}

			// Token: 0x0600024C RID: 588 RVA: 0x000107AA File Offset: 0x0000E9AA
			public SemenChainPar(ref SemenSelfPointToSemenSkinData Self, ref SemenPointToSemenSkinData Next)
			{
				this.m_isInyectedData = true;
				this.selfData = Self;
				this.nextData = Next;
			}

			// Token: 0x0600024D RID: 589 RVA: 0x000107D1 File Offset: 0x0000E9D1
			public void Clear()
			{
				this.m_self = null;
				this.m_next = null;
				if (this.selfData.partesImpactadas.IsCreated)
				{
					this.selfData.partesImpactadas.Dispose();
				}
			}

			// Token: 0x0600024E RID: 590 RVA: 0x00010804 File Offset: 0x0000EA04
			public void LoadPostValidationData()
			{
				if (this.m_isInyectedData)
				{
					return;
				}
				this.selfData.semenData.existio = this.m_self != null && this.m_self.semenPuntoCollisionContraSkin != null && this.m_self.semenPuntoCollisionContraSkin.semenPunto != null;
				if (this.selfData.semenData.existio)
				{
					SemenSkinController.SemenChainPar.LoadSelfData(ref this.selfData, this.m_self);
				}
				this.nextData.existio = this.m_next != null && this.m_next.semenPuntoCollisionContraSkin != null && this.m_next.semenPuntoCollisionContraSkin.semenPunto != null;
				if (this.nextData.existio)
				{
					SemenSkinController.SemenChainPar.LoadData(ref this.nextData, this.m_next);
				}
			}

			// Token: 0x0600024F RID: 591 RVA: 0x000108EA File Offset: 0x0000EAEA
			private static void LoadData(ref SemenPointToSemenSkinData data, SemenMeshToSkinMesh semen)
			{
				data.deltaRotation = semen.triangleAttachmentUser.deltaRotation;
				data.deltaPosition = semen.triangleAttachmentUser.deltaPosition;
				data.hitData = semen.semenPuntoCollisionContraSkin.currentTriangle.data;
			}

			// Token: 0x06000250 RID: 592 RVA: 0x00010924 File Offset: 0x0000EB24
			private static void LoadSelfData(ref SemenSelfPointToSemenSkinData selfData, SemenMeshToSkinMesh semen)
			{
				SemenSkinController.SemenChainPar.LoadData(ref selfData.semenData, semen);
				selfData.startTime = semen.semenPuntoCollisionContraSkin.semenPunto.startTime;
				selfData.duraction = semen.semenPuntoCollisionContraSkin.semenPunto.DuracionTotal();
				selfData.localDistanceToBreak = semen.semenPuntoCollisionContraSkin.semenPunto.GetLocalDistanceToBreak();
				Vector3 vector;
				Vector3 vector2;
				Vector3 vector3;
				Vector3 vector4;
				SemenPunto.GetSemenBonesLocalScales(semen.semenPuntoCollisionContraSkin.semenPunto, out vector, out vector2, out vector3, out vector4);
				Quaternion quaternion;
				SemenPunto.GetSemenStretchedBoneLocalRotation(semen.semenPuntoCollisionContraSkin.semenPunto, out quaternion);
				selfData.skeletonLocalScales = vector;
				selfData.bone1LocalScales = vector2;
				selfData.bone2LocalScales = vector3;
				selfData.StretchedBoneLocalScales = vector4;
				selfData.stretchedBoneLocalRotation = quaternion;
				try
				{
					SemenPuntoCollisionContraSkin.LoadPartesImpactadas(semen.semenPuntoCollisionContraSkin, SemenSkinController.SemenChainPar.m_impactadasPartes);
					selfData.partesImpactadas = new NativeArray<ValueTuple<ParteDelCuerpoHumano, Side>>(SemenSkinController.SemenChainPar.m_impactadasPartes.Count, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
					for (int i = 0; i < SemenSkinController.SemenChainPar.m_impactadasPartes.Count; i++)
					{
						selfData.partesImpactadas[i] = SemenSkinController.SemenChainPar.m_impactadasPartes[i];
					}
				}
				finally
				{
					SemenSkinController.SemenChainPar.m_impactadasPartes.Clear();
				}
			}

			// Token: 0x06000251 RID: 593 RVA: 0x00010A44 File Offset: 0x0000EC44
			public void OnConvertedToSkin()
			{
				if (this.m_self != null)
				{
					try
					{
						this.m_self.OnConvertedToSkin();
						if (this.m_self.CanBeDestroyedWhenConvertedToSkin())
						{
							Object.Destroy(this.m_self.gameObject);
						}
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
					}
				}
			}

			// Token: 0x06000252 RID: 594 RVA: 0x00010AA0 File Offset: 0x0000ECA0
			public bool IsValidAndCorrect()
			{
				if (this.m_isInyectedData)
				{
					return this.selfData.semenData.existio;
				}
				if (this.IsValidPar())
				{
					return true;
				}
				this.m_next = null;
				return this.IsValidOnlySelf();
			}

			// Token: 0x06000253 RID: 595 RVA: 0x00010AD4 File Offset: 0x0000ECD4
			private bool IsValidPar()
			{
				return this.m_next != null && this.m_self != null && this.m_self.semenPuntoCollisionContraSkin.semenPunto.next == this.m_next.semenPuntoCollisionContraSkin.semenPunto && this.m_self.semenPuntoCollisionContraSkin.isAttachedToSkin && this.m_next.semenPuntoCollisionContraSkin.isAttachedToSkin && this.m_self.semenPuntoCollisionContraSkin.attachedTo == this.m_next.semenPuntoCollisionContraSkin.attachedTo && !SemenSkinController.SemenChainPar.SemenAttackedHoleBones(this.m_self) && !SemenSkinController.SemenChainPar.SemenAttackedHoleBones(this.m_next) && !this.m_self.semenPuntoCollisionContraSkin.semenPunto.DistanceToNextSuperadaUnSafe(2f);
			}

			// Token: 0x06000254 RID: 596 RVA: 0x00010BB6 File Offset: 0x0000EDB6
			private bool IsValidOnlySelf()
			{
				return this.m_self != null && this.m_self.semenPuntoCollisionContraSkin.isAttachedToSkin && !SemenSkinController.SemenChainPar.SemenAttackedHoleBones(this.m_self);
			}

			// Token: 0x06000255 RID: 597 RVA: 0x00010BE8 File Offset: 0x0000EDE8
			private static bool SemenAttackedHoleBones(SemenMeshToSkinMesh semen)
			{
				SkinAndShapeTransformToTriangleSurfaceUser triangleAttachmentUser = semen.triangleAttachmentUser;
				IWorkingMesh workingMesh;
				if (triangleAttachmentUser == null)
				{
					workingMesh = null;
				}
				else
				{
					LocalSystemSkinAndShapeTransformToTriangleSurface system = triangleAttachmentUser.system;
					workingMesh = ((system != null) ? system.meshData : null);
				}
				IWorkingMesh workingMesh2 = workingMesh;
				IMeshSkeleton meshSkeleton = ((workingMesh2 != null) ? workingMesh2.meshSkeleton : null);
				if (meshSkeleton == null)
				{
					Debug.LogError("Semen Particle was not a valid attached particle", semen);
					return false;
				}
				SemenPuntoCollisionContraSkin.SkinHitResult.TriangleData hitBakedTriangleData = semen.semenPuntoCollisionContraSkin.currentTriangle.data.hitBakedTriangleData;
				NativeParallelMultiHashMap<int, BoneWeight1> allBoneWeightsPerVertIndex = workingMesh2.allBoneWeightsPerVertIndex;
				return SemenSkinController.SemenChainPar.VertexHasHole(hitBakedTriangleData.vertexIndex0, meshSkeleton, allBoneWeightsPerVertIndex) || SemenSkinController.SemenChainPar.VertexHasHole(hitBakedTriangleData.vertexIndex1, meshSkeleton, allBoneWeightsPerVertIndex) || SemenSkinController.SemenChainPar.VertexHasHole(hitBakedTriangleData.vertexIndex2, meshSkeleton, allBoneWeightsPerVertIndex);
			}

			// Token: 0x06000256 RID: 598 RVA: 0x00010C7C File Offset: 0x0000EE7C
			private static bool VertexHasHole(int vertexIndex, IMeshSkeleton meshSkeleton, NativeParallelMultiHashMap<int, BoneWeight1> boneMap)
			{
				BoneWeight1 boneWeight;
				NativeParallelMultiHashMapIterator<int> nativeParallelMultiHashMapIterator;
				if (boneMap.TryGetFirstValue(vertexIndex, out boneWeight, out nativeParallelMultiHashMapIterator))
				{
					for (;;)
					{
						string text = meshSkeleton.NameDeBone(boneWeight.boneIndex);
						if (SemenSkinController.m_VG_Prohibidos.Contains(text))
						{
							break;
						}
						if (!boneMap.TryGetNextValue(out boneWeight, ref nativeParallelMultiHashMapIterator))
						{
							return false;
						}
					}
					return true;
				}
				return false;
			}

			// Token: 0x0400027B RID: 635
			private static List<ValueTuple<ParteDelCuerpoHumano, Side>> m_impactadasPartes = new List<ValueTuple<ParteDelCuerpoHumano, Side>>();

			// Token: 0x0400027C RID: 636
			[ReadOnly]
			[SerializeField]
			private bool m_isInyectedData;

			// Token: 0x0400027D RID: 637
			[ReadOnly]
			[SerializeField]
			private SemenMeshToSkinMesh m_self;

			// Token: 0x0400027E RID: 638
			[ReadOnly]
			[SerializeField]
			private SemenMeshToSkinMesh m_next;

			// Token: 0x0400027F RID: 639
			public SemenSelfPointToSemenSkinData selfData;

			// Token: 0x04000280 RID: 640
			public SemenPointToSemenSkinData nextData;
		}

		// Token: 0x02000066 RID: 102
		[Serializable]
		public class Config
		{
			// Token: 0x04000281 RID: 641
			public bool sensibleToMaleSensors = true;

			// Token: 0x04000282 RID: 642
			public bool sensibleToSelfSensors = true;

			// Token: 0x04000283 RID: 643
			public float semenSkinDuration = 300f;

			// Token: 0x04000284 RID: 644
			public float semenMinDisplacementOffset = -0.07f;

			// Token: 0x04000285 RID: 645
			public int semenSkinVertexCountToConsolidate = 10000;

			// Token: 0x04000286 RID: 646
			public int semenSkinSparcedDeltasCountToConsolidate = 2000000;

			// Token: 0x04000287 RID: 647
			public int semenSkinAllBonesWeightCountToConsolidate = 1000000;

			// Token: 0x04000288 RID: 648
			public float semenSkinLifeTimeToConsolidate = 30f;

			// Token: 0x04000289 RID: 649
			public float waitTimeToConvertSemenMeshToSkin = 10f;

			// Token: 0x0400028A RID: 650
			public int maxParticlesWaiting = 30;
		}

		// Token: 0x02000067 RID: 103
		public class WorkingSemenParticle
		{
			// Token: 0x17000062 RID: 98
			// (get) Token: 0x06000259 RID: 601 RVA: 0x00010D46 File Offset: 0x0000EF46
			public int vertexCount
			{
				get
				{
					return this.workingMesh.vertexCount;
				}
			}

			// Token: 0x17000063 RID: 99
			// (get) Token: 0x0600025A RID: 602 RVA: 0x00010D53 File Offset: 0x0000EF53
			public int triangleCount
			{
				get
				{
					return this.triangles.Length;
				}
			}

			// Token: 0x0600025B RID: 603 RVA: 0x00010D60 File Offset: 0x0000EF60
			public void Preparar()
			{
				if (this.instance != null)
				{
					return;
				}
				this.instance = Object.Instantiate<GameObject>(Singleton<ColleccionDeParticulas>.instance.semenParticulaPrefab);
				Object.DontDestroyOnLoad(this.instance);
				this.instance.layer = ConfiguracionGlobal.layersStatic.ignoreAll;
				this.skinnedMeshRenderer = this.instance.GetComponentInChildren<SkinnedMeshRenderer>();
				this.workingMesh = Object.Instantiate<Mesh>(this.skinnedMeshRenderer.sharedMesh);
				this.workingMesh.MarkDynamic();
				SemenPunto.FindSemenBones(this.instance.transform, out this.skeleton, out this.bone0, out this.bone1, out this.bone2, out this.stretchedBone);
				this.vertices = new NativeArray<float3>(this.workingMesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.normals = new NativeArray<float3>(this.workingMesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.tangents = new NativeArray<float4>(this.workingMesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.uvs = new NativeArray<float2>(this.workingMesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				this.triangles = new NativeArray<int>(this.workingMesh.triangles, Allocator.Persistent);
				using (Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(this.skinnedMeshRenderer.sharedMesh))
				{
					Mesh.MeshData meshData = meshDataArray[0];
					NativeArray<Vector2> nativeArray = this.uvs.Reinterpret<Vector2>();
					meshData.GetUVs(0, nativeArray);
				}
				float[] array = new float[this.workingMesh.vertexCount];
				float[] array2 = new float[this.workingMesh.vertexCount];
				float[] array3 = new float[this.workingMesh.vertexCount];
				Transform[] bones = this.skinnedMeshRenderer.bones;
				Dictionary<int, float[]> dictionary = new Dictionary<int, float[]>(3);
				for (int i = 0; i < bones.Length; i++)
				{
					Transform transform = bones[i];
					if (transform == this.bone0)
					{
						dictionary.Add(i, array);
					}
					else if (transform == this.bone2)
					{
						dictionary.Add(i, array3);
					}
					else if (transform == this.stretchedBone)
					{
						dictionary.Add(i, array2);
					}
				}
				NativeArray<byte> bonesPerVertex = this.skinnedMeshRenderer.sharedMesh.GetBonesPerVertex();
				NativeArray<BoneWeight1> allBoneWeights = this.skinnedMeshRenderer.sharedMesh.GetAllBoneWeights();
				int num = 0;
				for (int j = 0; j < bonesPerVertex.Length; j++)
				{
					byte b = bonesPerVertex[j];
					if (b > 3)
					{
						throw new NotSupportedException("solo se pueden tener 3 bones Por semen particula");
					}
					for (int k = 0; k < (int)b; k++)
					{
						BoneWeight1 boneWeight = allBoneWeights[num];
						dictionary[boneWeight.boneIndex][j] = boneWeight.weight;
						num++;
					}
				}
				this.headToTailWeights = new NativeArray<float2>(this.workingMesh.vertexCount, Allocator.Persistent, NativeArrayOptions.ClearMemory);
				for (int l = 0; l < this.workingMesh.vertexCount; l++)
				{
					float num2 = array[l];
					float num3 = array3[l];
					float num4 = array2[l] * 0.5f;
					this.headToTailWeights[l] = new float2(num2 + num4, num3 + num4);
				}
			}

			// Token: 0x0600025C RID: 604 RVA: 0x00011084 File Offset: 0x0000F284
			public void Bake()
			{
				this.skinnedMeshRenderer.BakeMesh(this.workingMesh, true);
				using (Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(this.workingMesh))
				{
					Mesh.MeshData meshData = meshDataArray[0];
					NativeArray<Vector3> nativeArray = this.vertices.Reinterpret<Vector3>();
					NativeArray<Vector3> nativeArray2 = this.normals.Reinterpret<Vector3>();
					NativeArray<Vector4> nativeArray3 = this.tangents.Reinterpret<Vector4>();
					meshData.GetVertices(nativeArray);
					meshData.GetNormals(nativeArray2);
					meshData.GetTangents(nativeArray3);
				}
			}

			// Token: 0x0400028B RID: 651
			public GameObject instance;

			// Token: 0x0400028C RID: 652
			public SkinnedMeshRenderer skinnedMeshRenderer;

			// Token: 0x0400028D RID: 653
			public Mesh workingMesh;

			// Token: 0x0400028E RID: 654
			public Transform skeleton;

			// Token: 0x0400028F RID: 655
			public Transform bone0;

			// Token: 0x04000290 RID: 656
			public Transform bone1;

			// Token: 0x04000291 RID: 657
			public Transform bone2;

			// Token: 0x04000292 RID: 658
			public Transform stretchedBone;

			// Token: 0x04000293 RID: 659
			public NativeArray<float2> uvs;

			// Token: 0x04000294 RID: 660
			public NativeArray<float2> headToTailWeights;

			// Token: 0x04000295 RID: 661
			public NativeArray<int> triangles;

			// Token: 0x04000296 RID: 662
			public NativeArray<float3> vertices;

			// Token: 0x04000297 RID: 663
			public NativeArray<float3> normals;

			// Token: 0x04000298 RID: 664
			public NativeArray<float4> tangents;
		}
	}
}
