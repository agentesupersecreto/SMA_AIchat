using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200012A RID: 298
	public class ArmatureSkins : AplicableBehaviour
	{
		// Token: 0x1400005B RID: 91
		// (add) Token: 0x06000CCD RID: 3277 RVA: 0x0002C680 File Offset: 0x0002A880
		// (remove) Token: 0x06000CCE RID: 3278 RVA: 0x0002C6B8 File Offset: 0x0002A8B8
		public event Action<object> mainSkinsAdded;

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x06000CCF RID: 3279 RVA: 0x0002C6F0 File Offset: 0x0002A8F0
		// (remove) Token: 0x06000CD0 RID: 3280 RVA: 0x0002C728 File Offset: 0x0002A928
		public event Action<ArmatureSkins, Skin> skinAdded;

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x06000CD1 RID: 3281 RVA: 0x0002C760 File Offset: 0x0002A960
		// (remove) Token: 0x06000CD2 RID: 3282 RVA: 0x0002C798 File Offset: 0x0002A998
		public event Action<ArmatureSkins, Skin> skinRemoved;

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x06000CD3 RID: 3283 RVA: 0x0002C7D0 File Offset: 0x0002A9D0
		// (remove) Token: 0x06000CD4 RID: 3284 RVA: 0x0002C808 File Offset: 0x0002AA08
		public event Action<ArmatureSkins, Skin> skinHidden;

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x06000CD5 RID: 3285 RVA: 0x0002C840 File Offset: 0x0002AA40
		// (remove) Token: 0x06000CD6 RID: 3286 RVA: 0x0002C878 File Offset: 0x0002AA78
		public event Action<ArmatureSkins, Skin> skinShowed;

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x0002C8AD File Offset: 0x0002AAAD
		[Obsolete("reemplazar con un objeto global, elcual tiene una lista de MapaCorrectorDeSkinBoneRoot")]
		public MapaCorrectorDeSkinBoneRoot mapaCorrectorDeSkinBoneRoot
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000CD8 RID: 3288 RVA: 0x0002C8B0 File Offset: 0x0002AAB0
		public IReadOnlyList<SkinnedMeshRenderer> mainSkinsRenderers
		{
			get
			{
				return this.m_MainSkinsRenders;
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x0002C8B8 File Offset: 0x0002AAB8
		public IDictionary<string, Transform> mainBones
		{
			get
			{
				return this.m_MainBones;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000CDA RID: 3290 RVA: 0x0002C8C0 File Offset: 0x0002AAC0
		public Transform rootBone
		{
			get
			{
				return this.m_RootBone;
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x0002C8C8 File Offset: 0x0002AAC8
		public Matrix4x4 rootBoneInitialOffset
		{
			get
			{
				return this.m_RootBoneInitialOffset;
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000CDC RID: 3292 RVA: 0x0002C8D0 File Offset: 0x0002AAD0
		public Matrix4x4 currentRootBoneOffset
		{
			get
			{
				return base.transform.worldToLocalMatrix * this.m_RootBone.localToWorldMatrix;
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000CDD RID: 3293 RVA: 0x0002C8ED File Offset: 0x0002AAED
		public ICharacter character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000CDE RID: 3294 RVA: 0x0002C8F5 File Offset: 0x0002AAF5
		public IList<Skin> mainSkins
		{
			get
			{
				return this.m_MainSkins;
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x0002C8FD File Offset: 0x0002AAFD
		public virtual Skin mainSkin
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000CE0 RID: 3296 RVA: 0x0002C900 File Offset: 0x0002AB00
		public Animator animator
		{
			get
			{
				if (this.m_Animator == null)
				{
					this.m_Animator = base.GetComponentInChildren<Animator>();
				}
				return this.m_Animator;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x0002C922 File Offset: 0x0002AB22
		public IReadOnlyList<Skin> addedSkins
		{
			get
			{
				return this.m_AddedSkins;
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x0002C92C File Offset: 0x0002AB2C
		public bool areMainSkinsVisible
		{
			get
			{
				for (int i = 0; i < this.m_MainSkins.Count; i++)
				{
					Skin skin = this.m_MainSkins[i];
					if (skin.skinnedMeshRenderer && skin.skinnedMeshRenderer.isVisible)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x0002C97C File Offset: 0x0002AB7C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.animator == null)
			{
				throw new ArgumentNullException("m_Animator", "m_Animator null reference.");
			}
			this.m_Character = base.GetComponent<ICharacter>();
			this.m_CharacterRoot = base.GetComponentInParent<ICharacterRoot>();
			if (this.m_CharacterRoot == null)
			{
				throw new ArgumentNullException("m_CharacterRoot", "m_CharacterRoot null reference.");
			}
			List<SkinnedMeshRenderer> list = this.ObtenerMainRenderers();
			list = list.Except(this.m_ignoreRenders).ToList<SkinnedMeshRenderer>();
			if (list.Count == 0)
			{
				Debug.LogWarning("Char: " + base.name + ", no posee ningun Main Skin.", base.gameObject);
			}
			this.StartMainBones(list);
			this.StartMainSkins(list);
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x0002CA2C File Offset: 0x0002AC2C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_addedAtStart = new List<Skin>();
			SkinConfig nothing = SkinConfig.nothing;
			nothing.copiaShapesDe.Add(MapaSingleton<MapaSingletonDeMainSkins>.instance.body);
			for (int i = 0; i < this.m_toMountAtStart.Count; i++)
			{
				SkinnedMeshRenderer[] componentsInChildren = this.m_toMountAtStart[i].GetComponentsInChildren<SkinnedMeshRenderer>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = Object.Instantiate<SkinnedMeshRenderer>(componentsInChildren[j]);
					int layer = skinnedMeshRenderer.gameObject.layer;
					Skin skin = this.AddSkin<Skin, Skin>(skinnedMeshRenderer, nothing, true, false, null, null, null);
					skin.gameObject.layer = layer;
					this.m_addedAtStart.Add(skin);
					this.m_addedAtStartMaterials.AddRange(skinnedMeshRenderer.materials);
				}
			}
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x0002CAF4 File Offset: 0x0002ACF4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			for (int i = 0; i < this.m_addedAtStart.Count; i++)
			{
				Skin skin = this.m_addedAtStart[i];
				if (((skin != null) ? skin.gameObject : null) != null)
				{
					Object.Destroy(this.m_addedAtStart[i].gameObject);
				}
			}
			for (int j = 0; j < this.m_addedAtStartMaterials.Count; j++)
			{
				if (this.m_addedAtStartMaterials[j] != null)
				{
					Object.Destroy(this.m_addedAtStartMaterials[j]);
				}
			}
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x0002CB8F File Offset: 0x0002AD8F
		protected virtual void StartMainSkins(List<SkinnedMeshRenderer> mains)
		{
			this.StartMainSkins<Skin, ArmatureSkins>(this, mains);
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x0002CB99 File Offset: 0x0002AD99
		protected virtual List<SkinnedMeshRenderer> ObtenerMainRenderers()
		{
			return this.animator.GetComponentsInChildren<SkinnedMeshRenderer>().ToList<SkinnedMeshRenderer>();
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x0002CBAB File Offset: 0x0002ADAB
		protected virtual bool EsExtraMainSkin(SkinnedMeshRenderer mainSkin)
		{
			return false;
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x0002CBB0 File Offset: 0x0002ADB0
		protected virtual void StartMainSkins<T, Y>(Y owner, List<SkinnedMeshRenderer> mains) where T : Skin where Y : ArmatureSkins
		{
			IEnumerable<SkinnedMeshRenderer> enumerable = mains.Distinct<SkinnedMeshRenderer>();
			int num = enumerable.Count<SkinnedMeshRenderer>();
			this.m_MainSkins = new List<Skin>(num);
			this.m_MainSkinsDic = new Dictionary<string, Skin>(num);
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in enumerable)
			{
				if (skinnedMeshRenderer.gameObject.activeInHierarchy)
				{
					T componentNotNull = skinnedMeshRenderer.transform.GetComponentNotNull<T>();
					T t = componentNotNull;
					componentNotNull.initConfig.isMainSkin = true;
					componentNotNull.initConfig.isExtraMainSkin = this.EsExtraMainSkin(skinnedMeshRenderer);
					componentNotNull.initConfig.cloneMaterials = true;
					this.OnMainSkinCreating(componentNotNull, skinnedMeshRenderer);
					t.Adding(this);
					this.m_MainSkins.Add(componentNotNull);
					if (componentNotNull.skinnedMeshRenderer)
					{
						this.m_MainSkinsRenders.Add(componentNotNull.skinnedMeshRenderer);
					}
					this.m_MainSkinsDic.Add(skinnedMeshRenderer.name, componentNotNull);
					t.Added(this);
					this.OnMainSkinCreated(componentNotNull, skinnedMeshRenderer);
				}
			}
			this.OnMainSkinsCreated(this.m_MainSkins, mains);
			Action<object> action = this.mainSkinsAdded;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x0002CD0C File Offset: 0x0002AF0C
		protected virtual void StartMainBones(List<SkinnedMeshRenderer> mains)
		{
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in mains)
			{
				foreach (Transform transform in skinnedMeshRenderer.bones)
				{
					if (transform.IsChildOf(this.animator.transform) && !this.m_MainBones.ContainsKey(transform.name))
					{
						this.m_MainBones.Add(transform.name, transform);
					}
				}
			}
			Transform boneTransform = this.animator.GetBoneTransform(HumanBodyBones.Hips);
			this.m_RootBone = boneTransform;
			while (this.m_RootBone.parent != this.animator.transform && this.m_RootBone.IsChildOf(this.animator.transform))
			{
				this.m_RootBone = this.m_RootBone.parent;
			}
			this.m_RootBoneInitialOffset = base.transform.worldToLocalMatrix * this.m_RootBone.localToWorldMatrix;
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x0002CE24 File Offset: 0x0002B024
		protected virtual void OnMainSkinCreating(Skin s, SkinnedMeshRenderer renderer)
		{
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x0002CE26 File Offset: 0x0002B026
		protected virtual void OnMainSkinCreated(Skin s, SkinnedMeshRenderer renderer)
		{
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0002CE28 File Offset: 0x0002B028
		protected virtual void OnMainSkinsCreated(List<Skin> Skins, List<SkinnedMeshRenderer> mainRenderers)
		{
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x0002CE2A File Offset: 0x0002B02A
		public virtual void ReIgnoreSkinSelfCollisions()
		{
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x0002CE2C File Offset: 0x0002B02C
		public virtual void IgnoreSkinCollisionsVersus(Collider other, bool ignore = true)
		{
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x0002CE2E File Offset: 0x0002B02E
		public virtual bool ContineCollider(Collider col)
		{
			return false;
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x0002CE34 File Offset: 0x0002B034
		public bool IsMain(Skin skin)
		{
			Skin skin2;
			return this.m_MainSkinsDic.TryGetValue(skin.name, out skin2) && skin2 == skin;
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x0002CE60 File Offset: 0x0002B060
		public bool RemoveSkin(Skin skin, bool destroy, bool unparent, bool hide = true)
		{
			unparent = unparent && !destroy;
			((ISkinEvents)skin).Removing(this);
			this.m_AddedSkinsRenders.Remove(skin.skinnedMeshRenderer);
			this.m_AddedSkins.Remove(skin);
			this.m_AddedSkinsNames.Remove(skin.name);
			if (unparent)
			{
				skin.transform.parent = null;
			}
			if (Application.isPlaying)
			{
				if (hide)
				{
					this.HideSkin(skin);
				}
				((ISkinEvents)skin).Removed(this);
				Action<ArmatureSkins, Skin> action = this.skinRemoved;
				if (action != null)
				{
					action(this, skin);
				}
				if (destroy)
				{
					Object.Destroy(skin.gameObject);
				}
			}
			else
			{
				((ISkinEvents)skin).Removed(this);
				Action<ArmatureSkins, Skin> action2 = this.skinRemoved;
				if (action2 != null)
				{
					action2(this, skin);
				}
				if (destroy)
				{
					Object.DestroyImmediate(skin.gameObject);
				}
			}
			return true;
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x0002CF28 File Offset: 0x0002B128
		public void HideSkin(Skin skin)
		{
			if (!skin.gameObject.activeInHierarchy)
			{
				return;
			}
			if (skin.enabled || (skin.skinnedMeshRenderer.enabled && skin.skinnedMeshRenderer.enabled))
			{
				if (skin.skinnedMeshRenderer != null)
				{
					skin.skinnedMeshRenderer.enabled = false;
				}
				skin.enabled = false;
				Action<ArmatureSkins, Skin> action = this.skinHidden;
				if (action == null)
				{
					return;
				}
				action(this, skin);
			}
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x0002CF98 File Offset: 0x0002B198
		public void ShowSkin(Skin skin)
		{
			if (!skin.enabled || (skin.skinnedMeshRenderer != null && !skin.skinnedMeshRenderer.enabled))
			{
				if (!skin.skinMeshIsHidden && skin.skinnedMeshRenderer != null)
				{
					skin.skinnedMeshRenderer.enabled = true;
				}
				skin.enabled = true;
				Action<ArmatureSkins, Skin> action = this.skinShowed;
				if (action == null)
				{
					return;
				}
				action(this, skin);
			}
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x0002D004 File Offset: 0x0002B204
		public TSkinAbstract AddSkin<TSkinAbstract, TSkin>(Transform target, bool cloneMaterials, bool changeTransform, Action<TSkinAbstract> beforeAdded = null) where TSkinAbstract : Skin where TSkin : TSkinAbstract
		{
			if (!ExtendedMonoBehaviour.AlmostEqual(this.m_CharacterRoot.transform.lossyScale, Vector3.one, 0.01f))
			{
				Debug.LogError("Skins NO son compatibles con character root de scala cambiante", this);
			}
			if (changeTransform)
			{
				target.parent = this.animator.transform;
				target.localPosition = Vector3.zero;
				target.localRotation = Quaternion.identity;
				target.localScale = Vector3.one;
			}
			TSkinAbstract componentNotNull = target.GetComponentNotNull<TSkinAbstract, TSkin>();
			if (componentNotNull.skinIsAdded)
			{
				NotSupportedException ex = new NotSupportedException("skin: " + componentNotNull.name + ", ya fue añadida");
				Debug.LogException(ex, componentNotNull);
				throw ex;
			}
			if (this.m_AddedSkinsNames.Contains(componentNotNull.name))
			{
				NotSupportedException ex2 = new NotSupportedException("skin: " + componentNotNull.name + ", ya existe una skin con el mismo nombre");
				Debug.LogException(ex2, componentNotNull);
				throw ex2;
			}
			TSkinAbstract tskinAbstract = componentNotNull;
			componentNotNull.initConfig.isMainSkin = (componentNotNull.initConfig.isExtraMainSkin = false);
			componentNotNull.initConfig.cloneMaterials = cloneMaterials;
			tskinAbstract.Adding(this);
			if (componentNotNull.skinnedMeshRenderer != null)
			{
				this.m_AddedSkinsRenders.Add(componentNotNull.skinnedMeshRenderer);
			}
			this.m_AddedSkins.Add(componentNotNull);
			this.m_AddedSkinsNames.Add(componentNotNull.name);
			if (beforeAdded != null)
			{
				beforeAdded(componentNotNull);
			}
			tskinAbstract.Added(this);
			Action<ArmatureSkins, Skin> action = this.skinAdded;
			if (action != null)
			{
				action(this, componentNotNull);
			}
			return componentNotNull;
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x0002D1B8 File Offset: 0x0002B3B8
		public TSkinAbstract AddSkin<TSkinAbstract>(Type skinType, SkinnedMeshRenderer render, SkinConfig config, bool changeTransform, bool skinEsRendererParent, ICharacterSkinMeshConfig charConfig = null, Action<TSkinAbstract> beforeAdded = null, object extraData = null, Transform ownArmature = null) where TSkinAbstract : Skin
		{
			if (skinType == null)
			{
				throw new ArgumentNullException("skinType", "skinType null reference.");
			}
			if (!ExtendedMonoBehaviour.AlmostEqual(this.m_CharacterRoot.transform.lossyScale, Vector3.one, 0.01f))
			{
				Debug.LogError("Skins NO son compatibles con character root de scala cambiante", this);
			}
			if (this.m_AddedSkinsRenders.Contains(render))
			{
				throw new InvalidOperationException();
			}
			Transform transform;
			if (skinEsRendererParent)
			{
				transform = render.transform.parent;
			}
			else
			{
				transform = render.transform;
			}
			if (changeTransform)
			{
				transform.parent = this.animator.transform;
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
				transform.localScale = Vector3.one;
			}
			bool enabled = render.enabled;
			render.enabled = false;
			TSkinAbstract componentNotNull = transform.GetComponentNotNull(skinType);
			if (componentNotNull == null)
			{
				throw new ArgumentNullException("s", "s null reference.");
			}
			if (componentNotNull.skinIsAdded)
			{
				NotSupportedException ex = new NotSupportedException("skin: " + componentNotNull.name + ", ya fue añadida");
				Debug.LogException(ex, componentNotNull);
				throw ex;
			}
			if (this.m_AddedSkinsNames.Contains(componentNotNull.name))
			{
				NotSupportedException ex2 = new NotSupportedException("skin: " + componentNotNull.name + ", ya existe una skin con el mismo nombre");
				Debug.LogException(ex2, componentNotNull);
				throw ex2;
			}
			TSkinAbstract tskinAbstract = componentNotNull;
			componentNotNull.initConfig.isMainSkin = (componentNotNull.initConfig.isExtraMainSkin = false);
			componentNotNull.initConfig.cloneMaterials = config.clonarMateriales;
			tskinAbstract.Adding(this);
			this.m_AddedSkinsRenders.Add(render);
			this.m_AddedSkins.Add(componentNotNull);
			this.m_AddedSkinsNames.Add(componentNotNull.name);
			SkinConfig.AñadirComponentesExtras(render, this.animator, config, charConfig, extraData, ownArmature);
			render.enabled = enabled;
			if (beforeAdded != null)
			{
				beforeAdded(componentNotNull);
			}
			tskinAbstract.Added(this);
			Action<ArmatureSkins, Skin> action = this.skinAdded;
			if (action != null)
			{
				action(this, componentNotNull);
			}
			return componentNotNull;
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x0002D3E0 File Offset: 0x0002B5E0
		public TSkinAbstract AddSkin<TSkinAbstract, TSkin>(SkinnedMeshRenderer render, SkinConfig config, bool changeTransform, bool skinEsRendererParent, ICharacterSkinMeshConfig charConfig = null, Action<TSkinAbstract> beforeAdded = null, object extraData = null) where TSkinAbstract : Skin where TSkin : TSkinAbstract
		{
			return this.AddSkin<TSkinAbstract>(typeof(TSkin), render, config, changeTransform, skinEsRendererParent, charConfig, beforeAdded, extraData, null);
		}

		// Token: 0x0400074A RID: 1866
		private Animator m_Animator;

		// Token: 0x04000750 RID: 1872
		[SerializeField]
		private List<SkinnedMeshRenderer> m_ignoreRenders;

		// Token: 0x04000751 RID: 1873
		[SerializeField]
		private List<GameObject> m_toMountAtStart;

		// Token: 0x04000752 RID: 1874
		[ReadOnlyUI]
		[SerializeField]
		private List<Skin> m_addedAtStart;

		// Token: 0x04000753 RID: 1875
		[ReadOnlyUI]
		[SerializeField]
		private List<Material> m_addedAtStartMaterials;

		// Token: 0x04000754 RID: 1876
		[ReadOnlyUI]
		[SerializeField]
		protected List<Skin> m_MainSkins;

		// Token: 0x04000755 RID: 1877
		[ReadOnlyUI]
		[SerializeField]
		protected Skin m_MainSkin;

		// Token: 0x04000756 RID: 1878
		[ReadOnlyUI]
		[SerializeField]
		protected List<SkinnedMeshRenderer> m_MainSkinsRenders;

		// Token: 0x04000757 RID: 1879
		private Dictionary<string, Skin> m_MainSkinsDic;

		// Token: 0x04000758 RID: 1880
		private Dictionary<string, Transform> m_MainBones = new Dictionary<string, Transform>();

		// Token: 0x04000759 RID: 1881
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_RootBone;

		// Token: 0x0400075A RID: 1882
		private Matrix4x4 m_RootBoneInitialOffset;

		// Token: 0x0400075B RID: 1883
		private ICharacter m_Character;

		// Token: 0x0400075C RID: 1884
		private ICharacterRoot m_CharacterRoot;

		// Token: 0x0400075D RID: 1885
		public bool isDebug;

		// Token: 0x0400075E RID: 1886
		private List<Skin> m_AddedSkins = new List<Skin>();

		// Token: 0x0400075F RID: 1887
		private HashSet<SkinnedMeshRenderer> m_AddedSkinsRenders = new HashSet<SkinnedMeshRenderer>();

		// Token: 0x04000760 RID: 1888
		private HashSet<string> m_AddedSkinsNames = new HashSet<string>();
	}
}
