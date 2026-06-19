using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B2 RID: 178
	public class PezonCollider : BoneColliderGeneric<SphereCollider>
	{
		// Token: 0x060003CA RID: 970 RVA: 0x0000E5DC File Offset: 0x0000C7DC
		public static T Crear<T>(HitSkin skin, Transform targetBone, Transform parent) where T : PezonCollider
		{
			T t = BoneColliderGeneric<SphereCollider>.Crear<T>(skin, targetBone, parent, false);
			SphereCollider boneCollider = t.boneCollider;
			t.m_defaultRadius = (boneCollider.radius = 0.0075f);
			boneCollider.center = new Vector3(0f, 0f, -0.0033f);
			return t;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000E634 File Offset: 0x0000C834
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.radius = this.m_defaultRadius * mod.x;
			base.boneCollider.center = new Vector3(0f, 0f, -base.boneCollider.radius / 2f);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000E685 File Offset: 0x0000C885
		public void SetRadiusAsMod(float radius)
		{
			this.sizeMod.x = radius / this.m_defaultRadius;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000E69A File Offset: 0x0000C89A
		public void SetWorldCenter(Vector3 worldCenter)
		{
			base.boneCollider.center = base.col.transform.InverseTransformPoint(worldCenter);
		}

		// Token: 0x040002CE RID: 718
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultRadius;
	}
}
