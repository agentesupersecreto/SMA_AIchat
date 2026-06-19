using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B8 RID: 184
	public class TobilloCollider : BoneColliderGeneric<SphereCollider>
	{
		// Token: 0x060003DE RID: 990 RVA: 0x0000ED14 File Offset: 0x0000CF14
		public static T Crear<T>(Skin skin, Transform pieBaseBone, float ancho, Transform parent) where T : TobilloCollider
		{
			T t = BoneColliderGeneric<SphereCollider>.Crear<T>(skin, pieBaseBone, parent, false);
			SphereCollider boneCollider = t.boneCollider;
			t.m_defaultRadius = (boneCollider.radius = ancho / 2f);
			return t;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000ED51 File Offset: 0x0000CF51
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.radius = this.m_defaultRadius * mod.x;
		}

		// Token: 0x040002D5 RID: 725
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultRadius;
	}
}
