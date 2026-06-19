using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Adresables.Runtime.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x02000123 RID: 291
	public abstract class PiezaDeRopaBase : Skin
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060006B2 RID: 1714 RVA: 0x0001F59B File Offset: 0x0001D79B
		public RopaCubre cubreFlags
		{
			get
			{
				return this.m_data.cubreFlag;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060006B3 RID: 1715 RVA: 0x0001F5A8 File Offset: 0x0001D7A8
		public MapaDeRopa.RopaData dataDeRopa
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x0001F5B0 File Offset: 0x0001D7B0
		public IReadOnlyList<SlotDeMaterialDeRopa> materialesData
		{
			get
			{
				return this.m_materiales;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x0001F5B8 File Offset: 0x0001D7B8
		public IReadOnlyList<Object> instantiatedAssets
		{
			get
			{
				return this.m_instantiatedAssets;
			}
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0001F5C0 File Offset: 0x0001D7C0
		public void InitPiezaDeRopa(MapaDeRopa.RopaData data, Transform ownArmature, IReadOnlyList<GameObject> InstantiatedGameObject, IReadOnlyList<SlotDeMaterialDeRopa> Materiales, IReadOnlyList<ICustomClothingItemScript> customScripts)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data null reference.");
			}
			this.m_data = data;
			this.m_ownArmature = ownArmature;
			ICustomClothingItemScript[] array;
			if (customScripts == null)
			{
				array = null;
			}
			else
			{
				array = customScripts.Where((ICustomClothingItemScript s) => s != null).ToArray<ICustomClothingItemScript>();
			}
			this.m_customScripts = array;
			SlotDeMaterialDeRopa[] array2;
			if (Materiales == null)
			{
				array2 = null;
			}
			else
			{
				array2 = (from m in Materiales
					where m != null
					select m.Clone()).ToArray<SlotDeMaterialDeRopa>();
			}
			this.m_materiales = array2;
			Object[] array3;
			if (InstantiatedGameObject == null)
			{
				array3 = null;
			}
			else
			{
				array3 = InstantiatedGameObject.Where((GameObject a) => a != null).ToArray<GameObject>();
			}
			Object[] array4 = array3;
			this.m_instantiatedAssets = array4;
			if (data.interacciones.Count > 0)
			{
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				Mesh sharedMesh = base.skinnedMeshRenderer.sharedMesh;
				int blendShapeCount = sharedMesh.blendShapeCount;
				for (int i = 0; i < blendShapeCount; i++)
				{
					string blendShapeName = sharedMesh.GetBlendShapeName(i);
					dictionary.Add(blendShapeName, i);
				}
				for (int j = 0; j < data.interacciones.Count; j++)
				{
					MapaDeRopa.RopaData.Interacciones interacciones = data.interacciones[j];
					int num;
					if (dictionary.TryGetValue(interacciones.shapeName, out num))
					{
						this.m_shapeIndexDeInteraccion.Add(interacciones.id, num);
					}
				}
			}
			for (int k = 0; k < this.m_customScripts.Length; k++)
			{
				ICustomClothingItemScript customClothingItemScript = this.m_customScripts[k];
				if (customClothingItemScript != null)
				{
					customClothingItemScript.OnInit(InstantiatedGameObject[0], InstantiatedGameObject[1]);
				}
			}
			if (this.m_customScripts != null)
			{
				for (int l = 0; l < this.m_customScripts.Length; l++)
				{
					ICustomClothingItemScript customClothingItemScript2 = this.m_customScripts[l];
					if (customClothingItemScript2 != null)
					{
						customClothingItemScript2.OnShown();
					}
				}
			}
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0001F7C4 File Offset: 0x0001D9C4
		public void ChangeMaterial(int index, SlotDeMaterialDeRopa newData, Material instance)
		{
			if (instance == null)
			{
				Debug.LogError("No se puede actualizar material q es nullo", this);
				return;
			}
			Material[] sharedMaterials = base.skinnedMeshRenderer.sharedMaterials;
			if (!this.m_materiales.ContieneIndexBase(index) || !sharedMaterials.ContieneIndexBase(index))
			{
				Debug.LogError("No se puede actualizar data de index: " + index.ToString() + " no existe", this);
				return;
			}
			this.m_materiales[index] = newData;
			sharedMaterials[index] = instance;
			base.skinnedMeshRenderer.sharedMaterials = sharedMaterials;
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0001F840 File Offset: 0x0001DA40
		public void ChangeMainColor(int index, Color color)
		{
			try
			{
				base.skinnedMeshRenderer.GetSharedMaterials(PiezaDeRopaBase.m_tempMaterials);
				if (!PiezaDeRopaBase.m_tempMaterials.ContieneIndex(index) || !this.m_materiales.ContieneIndexBase(index))
				{
					Debug.LogError("pieza de ropa no toene material slot: " + index.ToString(), this);
				}
				else
				{
					Material material = PiezaDeRopaBase.m_tempMaterials[index];
					SlotDeMaterialDeRopa slotDeMaterialDeRopa = this.m_materiales[index];
					MaterialParaRopaData materialParaRopaData = AsyncSingleton<MaterialesParaRopa>.instance.ObtenerData(slotDeMaterialDeRopa.materialIDString);
					if (materialParaRopaData == null)
					{
						Debug.LogWarning("material id: " + slotDeMaterialDeRopa.materialIDString + ". no tiene data.", this);
					}
					else
					{
						PiezasDeRopaLoader.ChangeMainColor(material, color, materialParaRopaData, slotDeMaterialDeRopa);
					}
				}
			}
			finally
			{
				PiezaDeRopaBase.m_tempMaterials.Clear();
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0001F900 File Offset: 0x0001DB00
		public bool Cubre(RopaCubre cubre)
		{
			return this.m_data.Cubre(cubre);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0001F90E File Offset: 0x0001DB0E
		protected sealed override void AfterStartUnityEvent()
		{
			base.AfterStartUnityEvent();
			base.StartCoroutine(this.LoadSkinColliders());
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0001F923 File Offset: 0x0001DB23
		private IEnumerator LoadSkinColliders()
		{
			int num;
			for (int i = 0; i < this.m_data.skinsToColliders.Count; i = num + 1)
			{
				PiezaDeRopaBase.<>c__DisplayClass22_0 CS$<>8__locals1 = new PiezaDeRopaBase.<>c__DisplayClass22_0();
				MapaDeRopa.RopaData.SkinCollider collData = this.m_data.skinsToColliders[i];
				if (string.IsNullOrEmpty(collData.rendererAddress.AssetGUID) || (collData.tipoDeMontura == MapaDeRopa.RopaData.SkinCollider.TipoDeMontura.skinSkeleton && this.m_ownArmature == null))
				{
					Debug.LogError(string.Concat(new string[]
					{
						"Skin collider index: ",
						i.ToString(),
						" de pieza de ropa: ",
						this.m_data.nombreCompleto,
						" no es valido"
					}), this);
				}
				else
				{
					Transform instanciaHitSkinTransform = base.transform.CreateChild(base.name + "HitSkin" + i.ToString(), true);
					CS$<>8__locals1.instanciaSkinsToCollidersGO = null;
					yield return Singleton<AdresablesInstanciador>.instance.Instanciate<GameObject>(collData.rendererAddress, false, delegate(GameObject r)
					{
						CS$<>8__locals1.instanciaSkinsToCollidersGO = r;
					}, instanciaHitSkinTransform, new bool?(false));
					SkinnedMeshRenderer skinnedMeshRenderer;
					if (!CS$<>8__locals1.instanciaSkinsToCollidersGO.TryGetComponent<SkinnedMeshRenderer>(out skinnedMeshRenderer))
					{
						Debug.LogError(string.Concat(new string[] { "No se pudo añadir skin collider de ", base.name, " ", instanciaHitSkinTransform.name, " no tiene renderer" }), this);
						Singleton<AdresablesInstanciador>.instance.ReleaseInstance<GameObject>(CS$<>8__locals1.instanciaSkinsToCollidersGO);
					}
					else
					{
						NonBodyDynamicHitSkin nonBodyDynamicHitSkin = Skin.AddSkin<NonBodyDynamicHitSkin, ArmatureSkins>(skinnedMeshRenderer, base.owner, SkinConfig.nothing, false, true);
						if (collData.tipoDeMontura == MapaDeRopa.RopaData.SkinCollider.TipoDeMontura.skinSkeleton)
						{
							Skin.MountToSkeleton(skinnedMeshRenderer.gameObject, this.m_ownArmature);
						}
						Transform transform = this.ObtenerBoneTargetParaSubSkin<NonBodyDynamicHitSkin>(collData.tipoDeMontura, nonBodyDynamicHitSkin);
						nonBodyDynamicHitSkin.gameObject.layer = ConfiguracionGlobal.layersStatic.skins;
						skinnedMeshRenderer.gameObject.layer = ConfiguracionGlobal.layersStatic.ignoreAll;
						this.m_subSkins.Add(nonBodyDynamicHitSkin);
						this.m_subSkinsInstantiatedAssets.Add(CS$<>8__locals1.instanciaSkinsToCollidersGO);
						nonBodyDynamicHitSkin.Init(Singleton<ColecionDePhysicsMaterials>.instance.skinClothes, transform, this, ManualDynamicHitSkin.BakerType.Light);
						CS$<>8__locals1 = null;
						collData = null;
						instanciaHitSkinTransform = null;
					}
				}
				num = i;
			}
			for (int j = 0; j < this.m_customScripts.Length; j++)
			{
				ICustomClothingItemScript customClothingItemScript = this.m_customScripts[j];
				if (customClothingItemScript != null)
				{
					customClothingItemScript.OnCollidersInit(this.m_subSkinsInstantiatedAssets);
				}
			}
			yield return this.OnSkinCollidersLoaded();
			yield break;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x0001F932 File Offset: 0x0001DB32
		protected virtual IEnumerator OnSkinCollidersLoaded()
		{
			yield break;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001F93C File Offset: 0x0001DB3C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			for (int i = 0; i < this.m_subSkinsInstantiatedAssets.Count; i++)
			{
				if (!Singleton<AdresablesInstanciador>.IsInScene || !Application.isPlaying || !Singleton<AdresablesInstanciador>.instance.ReleaseInstance<GameObject>(this.m_subSkinsInstantiatedAssets[i]))
				{
					Object.Destroy(this.m_subSkinsInstantiatedAssets[i]);
				}
			}
			this.m_subSkinsInstantiatedAssets = null;
			for (int j = 0; j < this.m_subSkins.Count; j++)
			{
				Skin skin = this.m_subSkins[j];
				if (base.owner != null && skin != null)
				{
					base.owner.RemoveSkin(skin, false, false, true);
				}
				GameObject gameObject = ((skin != null) ? skin.gameObject : null);
				if (gameObject)
				{
					Object.Destroy(gameObject);
				}
			}
			this.m_subSkins = null;
			if (this.m_customScripts != null)
			{
				for (int k = 0; k < this.m_customScripts.Length; k++)
				{
					if (this.m_customScripts[k] as Component != null)
					{
						Object.Destroy(this.m_customScripts[k] as Component);
					}
				}
			}
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0001FA58 File Offset: 0x0001DC58
		protected virtual Transform ObtenerBoneTargetParaSubSkin<T>(MapaDeRopa.RopaData.SkinCollider.TipoDeMontura tipoDeMontura, T subSkin) where T : Skin
		{
			Transform transform;
			if (tipoDeMontura == MapaDeRopa.RopaData.SkinCollider.TipoDeMontura.skinSkeleton)
			{
				transform = this.m_ownArmature;
			}
			else
			{
				transform = base.owner.rootBone;
			}
			return transform;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0001FA80 File Offset: 0x0001DC80
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_customScripts != null)
			{
				for (int i = 0; i < this.m_customScripts.Length; i++)
				{
					ICustomClothingItemScript customClothingItemScript = this.m_customScripts[i];
					if (customClothingItemScript != null)
					{
						customClothingItemScript.OnShown();
					}
				}
			}
			if (base.skinIsAdded && base.isStared)
			{
				if (this.m_ownArmature != null)
				{
					this.m_ownArmature.gameObject.SetActive(true);
				}
				for (int j = 0; j < this.m_subSkins.Count; j++)
				{
					Skin skin = this.m_subSkins[j];
					GameObject gameObject = ((skin != null) ? skin.gameObject : null);
					if (gameObject)
					{
						gameObject.SetActive(true);
					}
				}
			}
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0001FB30 File Offset: 0x0001DD30
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_customScripts != null)
			{
				for (int i = 0; i < this.m_customScripts.Length; i++)
				{
					ICustomClothingItemScript customClothingItemScript = this.m_customScripts[i];
					if (customClothingItemScript != null)
					{
						customClothingItemScript.OnHidden();
					}
				}
			}
			if (base.skinIsAdded)
			{
				if (this.m_ownArmature != null)
				{
					this.m_ownArmature.gameObject.SetActive(false);
				}
				for (int j = 0; j < this.m_subSkins.Count; j++)
				{
					Skin skin = this.m_subSkins[j];
					GameObject gameObject = ((skin != null) ? skin.gameObject : null);
					if (gameObject)
					{
						gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0001FBD8 File Offset: 0x0001DDD8
		protected override void Added(ArmatureSkins owner)
		{
			base.Added(owner);
			if (this.m_customScripts != null)
			{
				for (int i = 0; i < this.m_customScripts.Length; i++)
				{
					ICustomClothingItemScript customClothingItemScript = this.m_customScripts[i];
					if (customClothingItemScript != null)
					{
						customClothingItemScript.OnAdded();
					}
				}
			}
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0001FC1C File Offset: 0x0001DE1C
		protected override void Removed(ArmatureSkins owner)
		{
			base.Removed(owner);
			if (this.m_customScripts != null)
			{
				for (int i = 0; i < this.m_customScripts.Length; i++)
				{
					ICustomClothingItemScript customClothingItemScript = this.m_customScripts[i];
					if (customClothingItemScript != null)
					{
						customClothingItemScript.OnRemoved();
					}
				}
			}
			if (this.m_subSkins != null)
			{
				for (int j = 0; j < this.m_subSkins.Count; j++)
				{
					Skin skin = this.m_subSkins[j];
					if (owner != null)
					{
						owner.RemoveSkin(skin, false, false, true);
					}
				}
			}
		}

		// Token: 0x04000557 RID: 1367
		[SerializeField]
		protected MapaDeRopa.RopaData m_data;

		// Token: 0x04000558 RID: 1368
		[SerializeField]
		protected SlotDeMaterialDeRopa[] m_materiales;

		// Token: 0x04000559 RID: 1369
		[SerializeField]
		protected Object[] m_instantiatedAssets;

		// Token: 0x0400055A RID: 1370
		[SerializeField]
		protected ICustomClothingItemScript[] m_customScripts;

		// Token: 0x0400055B RID: 1371
		[SerializeField]
		protected Transform m_ownArmature;

		// Token: 0x0400055C RID: 1372
		[SerializeField]
		protected List<Skin> m_subSkins = new List<Skin>();

		// Token: 0x0400055D RID: 1373
		[SerializeField]
		protected List<GameObject> m_subSkinsInstantiatedAssets = new List<GameObject>();

		// Token: 0x0400055E RID: 1374
		private DiccionaryEnum<MapaDeRopa.Interaciones, int> m_shapeIndexDeInteraccion = new DiccionaryEnum<MapaDeRopa.Interaciones, int>((MapaDeRopa.Interaciones x) => (int)x);

		// Token: 0x0400055F RID: 1375
		private static List<Material> m_tempMaterials = new List<Material>();
	}
}
