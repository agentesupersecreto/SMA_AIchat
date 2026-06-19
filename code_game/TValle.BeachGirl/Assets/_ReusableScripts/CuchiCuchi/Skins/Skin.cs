using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.BeachGirl.Mapas.Materiales.Runtime;
using Assets.Base.BeachGirl.Mapas.Materiales.Runtime.Globales;
using Assets.Base.Bones.Runtime.V2.Systemas;
using Assets.Scripts.MeshCalcules;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Skins.Physics;
using Assets.TValle.MeshCalcules.Runtime.V2;
using Assets.TValle.MeshCalcules.ShapingSkinningPoints.Runtime.Triangles.SkinningShaping;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Chars.Materiales.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200012B RID: 299
	public class Skin : AplicableBehaviour, ISkinEvents
	{
		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x0002D43D File Offset: 0x0002B63D
		public float materialZOffset
		{
			get
			{
				return this.m_materialZOffset;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x0002D445 File Offset: 0x0002B645
		public bool isTriangleAttachmentSystemInitiated
		{
			get
			{
				return this.m_TriangleAttachmentSystem != null && this.m_TriangleAttachmentSystem.initiated;
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000CFB RID: 3323 RVA: 0x0002D462 File Offset: 0x0002B662
		public LocalSystemSkinAndShapeTransformToTriangleSurface triangleAttachmentSystem
		{
			get
			{
				return this.m_TriangleAttachmentSystem;
			}
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x0002D46A File Offset: 0x0002B66A
		private void StartTriangleAttachmentSystem()
		{
			if (!this.isTriangleAttachmentSystemInitiated && this.CheckIfIsTriangleAttachable())
			{
				base.StartCoroutine(this.InitTriangleAttachmentSystem());
			}
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x0002D489 File Offset: 0x0002B689
		private void EnableTriangleAttachmentSystem()
		{
			if (this.m_TriangleAttachmentSystem != null && !this.m_TriangleAttachmentSystem.enabled)
			{
				this.m_TriangleAttachmentSystem.enabled = true;
			}
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x0002D4B2 File Offset: 0x0002B6B2
		private void DisableTriangleAttachmentSystem()
		{
			if (this.m_TriangleAttachmentSystem != null && this.m_TriangleAttachmentSystem.enabled)
			{
				this.m_TriangleAttachmentSystem.enabled = false;
			}
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x0002D4DB File Offset: 0x0002B6DB
		private void DestroyTriangleAttachmentSystem()
		{
			if (this.m_TriangleAttachmentSystem)
			{
				Object.Destroy(this.m_TriangleAttachmentSystem);
			}
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x0002D4F8 File Offset: 0x0002B6F8
		public bool CheckIfIsTriangleAttachable()
		{
			ISkinIgnoreAttachments skinIgnoreAttachments;
			IWorkingMesh workingMesh;
			IShapeKeys shapeKeys;
			return this.isTriangleAttachmentSystemInitiated || (!base.TryGetComponent<ISkinIgnoreAttachments>(out skinIgnoreAttachments) && base.TryGetComponent<IWorkingMesh>(out workingMesh) && base.TryGetComponent<IShapeKeys>(out shapeKeys));
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x0002D52D File Offset: 0x0002B72D
		public IEnumerator InitTriangleAttachmentSystem()
		{
			if (this.isTriangleAttachmentSystemInitiated)
			{
				yield break;
			}
			if (!this.CheckIfIsTriangleAttachable())
			{
				yield break;
			}
			if (this.m_TriangleAttachmentSystem == null)
			{
				this.m_TriangleAttachmentSystem = base.gameObject.AddComponent<LocalSystemSkinAndShapeTransformToTriangleSurface>();
				this.m_TriangleAttachmentSystem.updateScale = false;
				SystemaConUsuariosStandaloneScheduler systemaConUsuariosStandaloneScheduler = base.gameObject.AddComponent<SystemaConUsuariosStandaloneScheduler>();
				systemaConUsuariosStandaloneScheduler.doScheduleEvent = GlobalUpdater.UpdateType.meshGeneralModsUpdate1;
				systemaConUsuariosStandaloneScheduler.doScheduleEventPass = 1;
				systemaConUsuariosStandaloneScheduler.doCompleteEvent = GlobalUpdater.UpdateType.meshUpdate2;
				systemaConUsuariosStandaloneScheduler.doCompleteEventPass = 1;
			}
			while (!this.m_TriangleAttachmentSystem.initiated)
			{
				yield return null;
			}
			int num = Shader.PropertyToID("_HeightOffset");
			float num2 = 0f;
			for (int i = 0; i < this.m_SkinnedMeshRenderer.sharedMaterials.Length; i++)
			{
				Material material = this.m_SkinnedMeshRenderer.sharedMaterials[i];
				if (material.HasFloat(num))
				{
					float num3 = material.GetFloat(num) * 0.01f * 1.01f;
					num2 = Mathf.Max(num2, num3);
				}
			}
			this.m_materialZOffset = num2;
			yield break;
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000D02 RID: 3330 RVA: 0x0002D53C File Offset: 0x0002B73C
		protected virtual bool cookAfterPhysics
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000D03 RID: 3331 RVA: 0x0002D53F File Offset: 0x0002B73F
		public bool isCookable
		{
			get
			{
				return this.skinnedMeshRenderer != null;
			}
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x0002D54D File Offset: 0x0002B74D
		private void StartCooking()
		{
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0002D54F File Offset: 0x0002B74F
		private void InitCooking()
		{
			this.m_rootParaPedidos = base.transform.CreateChild("Pedidos De Bake Collider");
			this.m_poolDePedidos = new SimplePoolDeComponentesHijos<PedidoDePhyscisBakeDeSkin>(this.m_rootParaPedidos, delegate(PedidoDePhyscisBakeDeSkin p)
			{
				p.Init(this, this.cookAfterPhysics);
			}, null);
			this.m_CookingIsInit = true;
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x0002D58C File Offset: 0x0002B78C
		public void Cook(PedidoDePhyscisBakeDeSkin.IUser user, bool gpu, object extradata)
		{
			if (!this.m_CookingIsInit)
			{
				this.InitCooking();
			}
			PedidoDePhyscisBakeDeSkin item;
			if (!this.m_pedidosPorFrameID.TryGetValue(Time.frameCount, out item))
			{
				item = this.m_poolDePedidos.GetItem();
				item.gameObject.SetActive(true);
				this.m_pedidosPorFrameID.Add(Time.frameCount, item);
			}
			item.Cook(user, gpu, extradata);
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x0002D5ED File Offset: 0x0002B7ED
		public PedidoDePhyscisBakeDeSkin GetStandAlonePedido()
		{
			PedidoDePhyscisBakeDeSkin item = this.m_poolDePedidos.GetItem();
			item.gameObject.SetActive(true);
			return item;
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x0002D606 File Offset: 0x0002B806
		internal void OnCooked(PedidoDePhyscisBakeDeSkin pedido)
		{
			this.m_pedidosPorFrameID.Remove(pedido.id);
			this.m_poolDePedidos.ReturnItem(pedido);
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x0002D628 File Offset: 0x0002B828
		private void DestroyCooking()
		{
			SimplePoolDeComponentesHijos<PedidoDePhyscisBakeDeSkin> poolDePedidos = this.m_poolDePedidos;
			if (poolDePedidos != null)
			{
				poolDePedidos.Destroy();
			}
			if (this.m_pedidosPorFrameID.Count > 0)
			{
				foreach (KeyValuePair<int, PedidoDePhyscisBakeDeSkin> keyValuePair in this.m_pedidosPorFrameID)
				{
					Object.Destroy(keyValuePair.Value);
				}
			}
			if (this.m_rootParaPedidos)
			{
				Object.Destroy(this.m_rootParaPedidos.gameObject);
			}
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x0002D6BC File Offset: 0x0002B8BC
		protected sealed override void OnAplicar5()
		{
			base.OnAplicar5();
			this.Cook(null, false, null);
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x0002D6CD File Offset: 0x0002B8CD
		protected sealed override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Crear Pedido De Bake Physics",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x0002D6E6 File Offset: 0x0002B8E6
		protected sealed override void OnAplicar4()
		{
			base.OnAplicar4();
			this.Cook(null, true, null);
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0002D6F7 File Offset: 0x0002B8F7
		protected sealed override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Crear Pedido De GPU Bake Physics",
				editorTimeVisible = false
			};
		}

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x06000D0E RID: 3342 RVA: 0x0002D710 File Offset: 0x0002B910
		// (remove) Token: 0x06000D0F RID: 3343 RVA: 0x0002D748 File Offset: 0x0002B948
		public event Action<Skin> skinAdded;

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x06000D10 RID: 3344 RVA: 0x0002D780 File Offset: 0x0002B980
		// (remove) Token: 0x06000D11 RID: 3345 RVA: 0x0002D7B8 File Offset: 0x0002B9B8
		public event Action<Skin> skinRemoved;

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000D12 RID: 3346 RVA: 0x0002D7ED File Offset: 0x0002B9ED
		public virtual bool skinMeshIsHidden
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000D13 RID: 3347 RVA: 0x0002D7F0 File Offset: 0x0002B9F0
		// (set) Token: 0x06000D14 RID: 3348 RVA: 0x0002D7F8 File Offset: 0x0002B9F8
		public int? overrideLayer { get; set; }

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000D15 RID: 3349 RVA: 0x0002D801 File Offset: 0x0002BA01
		public Skin.InitConfig initConfig
		{
			get
			{
				return this.m_InitConfig;
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000D16 RID: 3350 RVA: 0x0002D809 File Offset: 0x0002BA09
		public bool hidden
		{
			get
			{
				return !base.enabled;
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000D17 RID: 3351 RVA: 0x0002D814 File Offset: 0x0002BA14
		public bool skinIsAdded
		{
			get
			{
				return this.m_owner != null;
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x0002D822 File Offset: 0x0002BA22
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x0002D82A File Offset: 0x0002BA2A
		public new string name
		{
			get
			{
				return base.name;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x0002D831 File Offset: 0x0002BA31
		public static T AddSkin<T, Y>(SkinnedMeshRenderer render, Y owner, SkinConfig config, bool changeTransform, bool skinEsRendererParent) where T : Skin where Y : ArmatureSkins
		{
			return owner.AddSkin<T, T>(render, config, changeTransform, skinEsRendererParent, null, null, null);
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x0002D846 File Offset: 0x0002BA46
		public static T AddSkin<T, Y>(Transform skinTransform, Y owner, bool cloneMaterials, bool changeTransform) where T : Skin where Y : ArmatureSkins
		{
			return owner.AddSkin<T, T>(skinTransform, cloneMaterials, changeTransform, null);
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x0002D857 File Offset: 0x0002BA57
		public SkinnedMeshRenderer skinnedMeshRenderer
		{
			get
			{
				return this.m_SkinnedMeshRenderer;
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x0002D85F File Offset: 0x0002BA5F
		public ArmatureSkins owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06000D1E RID: 3358 RVA: 0x0002D868 File Offset: 0x0002BA68
		public virtual bool isDebug
		{
			get
			{
				ArmatureSkins owner = this.m_owner;
				return ((owner != null) ? new bool?(owner.isDebug) : null).GetValueOrDefault();
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06000D1F RID: 3359 RVA: 0x0002D89C File Offset: 0x0002BA9C
		// (set) Token: 0x06000D20 RID: 3360 RVA: 0x0002D8A4 File Offset: 0x0002BAA4
		public virtual bool corregirLayer { get; set; } = true;

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06000D21 RID: 3361 RVA: 0x0002D8AD File Offset: 0x0002BAAD
		// (set) Token: 0x06000D22 RID: 3362 RVA: 0x0002D8B5 File Offset: 0x0002BAB5
		public virtual bool corregirRootBone { get; set; } = true;

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06000D23 RID: 3363 RVA: 0x0002D8BE File Offset: 0x0002BABE
		// (set) Token: 0x06000D24 RID: 3364 RVA: 0x0002D8C6 File Offset: 0x0002BAC6
		public virtual bool cambiarBonesReferences { get; set; } = true;

		// Token: 0x06000D25 RID: 3365 RVA: 0x0002D8CF File Offset: 0x0002BACF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SkinnedMeshRenderer = base.GetComponentInChildren<SkinnedMeshRenderer>();
			base.name = base.name.Replace("(Clone)", "");
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x0002D8FE File Offset: 0x0002BAFE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_owner != null)
			{
				this.m_owner.ShowSkin(this);
			}
			this.EnableTriangleAttachmentSystem();
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x0002D926 File Offset: 0x0002BB26
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.StartCooking();
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x0002D934 File Offset: 0x0002BB34
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_owner != null && !quitting)
			{
				this.m_owner.HideSkin(this);
			}
			if (!quitting)
			{
				this.DisableTriangleAttachmentSystem();
			}
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x0002D964 File Offset: 0x0002BB64
		private void OnAddedInternal(ArmatureSkins owner)
		{
			if (this.m_owner != null)
			{
				throw new InvalidOperationException();
			}
			this.m_owner = owner;
			this.ConfigSkinOnAdded(this.m_InitConfig.isMainSkin, this.m_InitConfig.isExtraMainSkin, this.m_InitConfig.cloneMaterials);
			this.StartTriangleAttachmentSystem();
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x0002D9BC File Offset: 0x0002BBBC
		protected void ConfigSkinOnAdded(bool isMainSkin, bool isExtraMainSkin, bool cloneMaterials)
		{
			if (!isMainSkin)
			{
				if (this.corregirLayer)
				{
					Skin.SetLayer(base.gameObject, this.overrideLayer);
				}
				if (this.corregirRootBone)
				{
					Skin.CorregirRootBone(this.m_owner, this.skinnedMeshRenderer);
				}
				if (this.cambiarBonesReferences)
				{
					Skin.CambiarBonesReferences(this.m_owner, this.skinnedMeshRenderer, null);
				}
				if (cloneMaterials)
				{
					this.CloneMaterials(null);
				}
			}
			else
			{
				if (isExtraMainSkin)
				{
					if (this.corregirRootBone)
					{
						Skin.CorregirRootBone(this.m_owner, this.skinnedMeshRenderer);
					}
					if (this.cambiarBonesReferences)
					{
						Skin.CambiarBonesReferences(this.m_owner, this.skinnedMeshRenderer, null);
					}
				}
				MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig mainSkinConfig = MapaSingleton<MapaSingletonDeFemaleMainSkinsConfig>.instance.mainSkins.FirstOrDefault((MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig ms) => ms.ObtenerSkinName() == this.m_SkinnedMeshRenderer.name);
				if (mainSkinConfig != null && mainSkinConfig.layerConfig.overrideLayer)
				{
					this.overrideLayer = new int?(mainSkinConfig.layerConfig.overridingLayer);
				}
				Skin.SetLayer(base.gameObject, this.overrideLayer);
				if (cloneMaterials)
				{
					this.CloneMaterials(mainSkinConfig);
				}
			}
			if (this.m_SkinnedMeshRenderer != null)
			{
				this.m_SkinnedMeshRenderer.localBounds = new Bounds(Vector3.zero, Vector3.one * this.m_owner.character.defaultEstatura * 1.5f);
			}
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x0002DB04 File Offset: 0x0002BD04
		private static void SetLayer(GameObject target, int? overrideLayer)
		{
			if (overrideLayer == null)
			{
				target.transform.ExecDeepChild(delegate(Transform t)
				{
					t.gameObject.layer = Singleton<ConfiguracionGeneral>.instance.layers.skinsRenders;
				}, true);
				return;
			}
			target.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = overrideLayer.Value;
			}, true);
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x0002DB70 File Offset: 0x0002BD70
		protected void CloneMaterialsSimple()
		{
			if (this.m_cloned != null)
			{
				throw new InvalidOperationException();
			}
			this.m_cloned = new List<Material>();
			if (this.m_SkinnedMeshRenderer)
			{
				List<Material> list = this.m_SkinnedMeshRenderer.materials.ToList<Material>();
				this.m_cloned.AddRange(list);
			}
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x0002DBC0 File Offset: 0x0002BDC0
		protected void CloneMaterials(MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig mainSkin)
		{
			if (this.m_cloned != null)
			{
				throw new InvalidOperationException();
			}
			this.m_cloned = new List<Material>();
			if (this.m_SkinnedMeshRenderer)
			{
				List<Material> list = this.m_SkinnedMeshRenderer.materials.ToList<Material>();
				this.m_cloned.AddRange(list);
				if (mainSkin != null && mainSkin.usarTessellation)
				{
					MapaSingletonDeFemaleMateriales instance = MapaSingleton<MapaSingletonDeFemaleMateriales>.instance;
					for (int i = list.Count - 1; i >= 0; i--)
					{
						Material material = list[i];
						foreach (string text in mainSkin.ignorarTessellationEn)
						{
							string text2 = instance.ObtenerValorDeField(text);
							if (material.name.StartsWith(text2, StringComparison.Ordinal))
							{
								list.RemoveAt(i);
								break;
							}
						}
					}
					MaterialFieldsDeTessellationIDs materialFieldsDeTessellationIDs = new MaterialFieldsDeTessellationIDs();
					MaterialFieldsDeTessellationIDs materialFieldsDeTessellationIDs2 = materialFieldsDeTessellationIDs;
					MapaDeMaterialFields mapaDeMaterialFields = Singleton<MaterialesFieldsNombres>.instance.Obtener();
					materialFieldsDeTessellationIDs2.Load((mapaDeMaterialFields != null) ? mapaDeMaterialFields.tessellation : null);
					ConfiguracionGeneralDeGraficos.TesselationConfig skinsTesselationConfig = Singleton<ConfiguracionGeneralDeGraficos>.instance.graficas.skinsTesselationConfig;
					for (int j = 0; j < list.Count; j++)
					{
						Material material2 = list[j];
						if (Singleton<ConfiguracionGeneralDeGraficos>.instance.graficas.usarTesselation)
						{
							TessellationDeMaterial.Set(material2, materialFieldsDeTessellationIDs, skinsTesselationConfig.amount, skinsTesselationConfig.phongSmoothing, skinsTesselationConfig.minCameraDistance, skinsTesselationConfig.maxCameraDistance);
						}
						else
						{
							TessellationDeMaterial.TurnOff(material2, materialFieldsDeTessellationIDs);
						}
					}
				}
			}
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x0002DD40 File Offset: 0x0002BF40
		protected virtual void OnRemoved()
		{
			this.m_owner = null;
			throw new NotImplementedException();
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x0002DD4E File Offset: 0x0002BF4E
		public virtual bool IsTouchedBy(ICharacter character)
		{
			return false;
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x0002DD54 File Offset: 0x0002BF54
		public static void CambiarBonesReferences(ArmatureSkins owner, SkinnedMeshRenderer skinnedMeshRenderer, Func<Transform, bool> boneIsValidDelegate = null)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
			if (skinnedMeshRenderer == null)
			{
				return;
			}
			bool flag = boneIsValidDelegate != null;
			try
			{
				IDictionary<string, Transform> mainBones = owner.mainBones;
				List<Transform> list = new List<Transform>(skinnedMeshRenderer.bones);
				for (int i = 0; i < list.Count; i++)
				{
					Transform transform = list[i];
					if (!flag || boneIsValidDelegate(transform))
					{
						string name = transform.name;
						Transform transform2;
						if (mainBones.TryGetValue(name, out transform2))
						{
							list[i] = transform2;
						}
					}
				}
				skinnedMeshRenderer.bones = list.ToArray();
			}
			catch (Exception ex)
			{
				Debug.LogWarning("error al intercambiar bones de skin", skinnedMeshRenderer);
				throw ex;
			}
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x0002DE0C File Offset: 0x0002C00C
		public static void MountToSkeleton(GameObject target, Transform armature)
		{
			SkinnedMeshRenderer[] componentsInChildren = target.GetComponentsInChildren<SkinnedMeshRenderer>(true);
			Dictionary<string, Transform> dictionary = armature.GetComponentsInChildren<Transform>().ToDictionary((Transform t) => t.name);
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
			{
				List<Transform> list = new List<Transform>(skinnedMeshRenderer.bones);
				for (int j = 0; j < list.Count; j++)
				{
					string name = list[j].name;
					Transform transform;
					if (dictionary.TryGetValue(name, out transform))
					{
						list[j] = transform;
					}
				}
				skinnedMeshRenderer.bones = list.ToArray();
				if (dictionary.ContainsKey(skinnedMeshRenderer.rootBone.name))
				{
					skinnedMeshRenderer.rootBone = dictionary[skinnedMeshRenderer.rootBone.name];
				}
			}
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x0002DEE8 File Offset: 0x0002C0E8
		private static void CorregirRootBone(ArmatureSkins owner, SkinnedMeshRenderer skinnedMeshRenderer)
		{
			if (skinnedMeshRenderer != null)
			{
				skinnedMeshRenderer.updateWhenOffscreen = true;
				if (skinnedMeshRenderer.rootBone == null || string.IsNullOrEmpty(skinnedMeshRenderer.rootBone.name))
				{
					skinnedMeshRenderer.rootBone = owner.animator.GetBoneTransform(HumanBodyBones.Hips);
					return;
				}
				if (owner.mainBones.ContainsKey(skinnedMeshRenderer.rootBone.name))
				{
					skinnedMeshRenderer.rootBone = owner.mainBones[skinnedMeshRenderer.rootBone.name];
					return;
				}
				if (owner.rootBone.name == skinnedMeshRenderer.rootBone.name)
				{
					skinnedMeshRenderer.rootBone = owner.rootBone;
				}
			}
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x0002DF9C File Offset: 0x0002C19C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_cloned != null)
			{
				foreach (Material material in this.m_cloned)
				{
					if (material)
					{
						Object.Destroy(material);
					}
				}
			}
			this.DestroyCooking();
			if (!quitting)
			{
				this.DestroyTriangleAttachmentSystem();
			}
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x0002E014 File Offset: 0x0002C214
		void ISkinEvents.Adding(ArmatureSkins owner)
		{
			this.Adding(owner);
			this.OnAddedInternal(owner);
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x0002E024 File Offset: 0x0002C224
		void ISkinEvents.Added(ArmatureSkins owner)
		{
			this.Added(owner);
			Action<Skin> action = this.skinAdded;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x0002E03E File Offset: 0x0002C23E
		void ISkinEvents.Removing(ArmatureSkins owner)
		{
			this.Removing(owner);
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x0002E047 File Offset: 0x0002C247
		void ISkinEvents.Removed(ArmatureSkins owner)
		{
			this.Removed(owner);
			Action<Skin> action = this.skinRemoved;
			if (action != null)
			{
				action(this);
			}
			this.m_owner = null;
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x0002E069 File Offset: 0x0002C269
		protected virtual void Adding(ArmatureSkins owner)
		{
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x0002E06B File Offset: 0x0002C26B
		protected virtual void Added(ArmatureSkins owner)
		{
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x0002E06D File Offset: 0x0002C26D
		protected virtual void Removing(ArmatureSkins owner)
		{
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x0002E06F File Offset: 0x0002C26F
		protected virtual void Removed(ArmatureSkins owner)
		{
		}

		// Token: 0x04000761 RID: 1889
		[ReadOnlyUI]
		[SerializeField]
		private float m_materialZOffset;

		// Token: 0x04000762 RID: 1890
		[ReadOnlyUI]
		[SerializeField]
		private LocalSystemSkinAndShapeTransformToTriangleSurface m_TriangleAttachmentSystem;

		// Token: 0x04000763 RID: 1891
		private SimplePoolDeComponentesHijos<PedidoDePhyscisBakeDeSkin> m_poolDePedidos;

		// Token: 0x04000764 RID: 1892
		private Transform m_rootParaPedidos;

		// Token: 0x04000765 RID: 1893
		private Dictionary<int, PedidoDePhyscisBakeDeSkin> m_pedidosPorFrameID = new Dictionary<int, PedidoDePhyscisBakeDeSkin>();

		// Token: 0x04000766 RID: 1894
		private bool m_CookingIsInit;

		// Token: 0x0400076A RID: 1898
		[ReadOnlyUI]
		private Skin.InitConfig m_InitConfig = new Skin.InitConfig();

		// Token: 0x0400076B RID: 1899
		private SkinnedMeshRenderer m_SkinnedMeshRenderer;

		// Token: 0x0400076C RID: 1900
		[ReadOnlyUI]
		[SerializeField]
		private ArmatureSkins m_owner;

		// Token: 0x04000770 RID: 1904
		private List<Material> m_cloned;

		// Token: 0x02000201 RID: 513
		[Serializable]
		public class InitConfig
		{
			// Token: 0x04000B01 RID: 2817
			public bool isMainSkin;

			// Token: 0x04000B02 RID: 2818
			public bool isExtraMainSkin;

			// Token: 0x04000B03 RID: 2819
			public bool cloneMaterials;
		}
	}
}
