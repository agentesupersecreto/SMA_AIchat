using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.CuchiCuchi.Skins.Colliders;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000068 RID: 104
	public class LenguaHitSkin : NonSkinnedHitSkinBase
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002BF RID: 703 RVA: 0x0000A6FF File Offset: 0x000088FF
		public override BodyPartEnum parte
		{
			get
			{
				return BodyPartEnum.lengua;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00004252 File Offset: 0x00002452
		public override Side side
		{
			get
			{
				return Side.none;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00005A42 File Offset: 0x00003C42
		public override NonSkinnedHitSkinBase.BaseColliders baseColliders
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000A704 File Offset: 0x00008904
		public virtual void Init(LenguaBoneMap lenguaBoneMap, Skin VisualSkin)
		{
			Transform boneTransform = base.owner.animator.GetBoneTransform(HumanBodyBones.Jaw);
			HitPartEnum hitPartEnum = HitPartEnum.lengua;
			this.m_LenguaBoneMap = lenguaBoneMap;
			Transform boneTransform2 = base.owner.animator.GetBoneTransform(HumanBodyBones.Hips);
			this.bones.@base = boneTransform2.FindDeepChild(this.m_LenguaBoneMap.lenguaBase, true);
			this.bones.middle = boneTransform2.FindDeepChild(this.m_LenguaBoneMap.lenguaMedio, true);
			this.bones.tip = boneTransform2.FindDeepChild(this.m_LenguaBoneMap.lenguaPunta, true);
			this.CrearCollidersDeLengua();
			this.Init(hitPartEnum, boneTransform, VisualSkin);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000A7A6 File Offset: 0x000089A6
		protected override PhysicMaterial ObtenerClonePhysicMaterial()
		{
			return Object.Instantiate<PhysicMaterial>(Singleton<ColecionDePhysicsMaterials>.instance.senos);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000A7B7 File Offset: 0x000089B7
		protected virtual void CrearCollidersDeLengua()
		{
			this.m_Colliders.colliders = base.transform.CreateChild("LenguaColliders").gameObject.AddComponent<LenguaColliders>();
			this.m_Colliders.colliders.Init();
		}

		// Token: 0x040001C5 RID: 453
		[SerializeField]
		private LenguaBoneMap m_LenguaBoneMap;

		// Token: 0x040001C6 RID: 454
		[SerializeField]
		private LenguaHitSkin.Colliders m_Colliders = new LenguaHitSkin.Colliders();

		// Token: 0x040001C7 RID: 455
		public LenguaHitSkin.Bones bones = new LenguaHitSkin.Bones();

		// Token: 0x02000069 RID: 105
		[Serializable]
		public class Colliders : NonSkinnedHitSkinBase.BaseColliders
		{
			// Token: 0x040001C8 RID: 456
			public LenguaColliders colliders;
		}

		// Token: 0x0200006A RID: 106
		[Serializable]
		public class Bones
		{
			// Token: 0x040001C9 RID: 457
			public Transform @base;

			// Token: 0x040001CA RID: 458
			public Transform middle;

			// Token: 0x040001CB RID: 459
			public Transform tip;
		}
	}
}
