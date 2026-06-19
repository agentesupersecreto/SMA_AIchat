using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000AF RID: 175
	public class GenericBoneCollider : BoneColliderGeneric<SphereCollider>
	{
		// Token: 0x060003BD RID: 957 RVA: 0x0000E0A0 File Offset: 0x0000C2A0
		public static T Crear<T>(HitSkin skin, Transform targetBone, Transform parent, float radius) where T : GenericBoneCollider
		{
			T t = BoneColliderGeneric<SphereCollider>.Crear<T>(skin, targetBone, parent, false);
			SphereCollider boneCollider = t.boneCollider;
			GenericBoneCollider genericBoneCollider = t;
			boneCollider.radius = radius;
			genericBoneCollider.m_defaultRadius = radius;
			return t;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000E0D7 File Offset: 0x0000C2D7
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.radius = this.m_defaultRadius * mod.x;
		}

		// Token: 0x040002C8 RID: 712
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultRadius;
	}
}
