using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B1 RID: 177
	[Obsolete("Deben ser collider q sigan guias", true)]
	public class LenguaParteCollider : BoneColliderGeneric<BoxCollider>
	{
		// Token: 0x060003C6 RID: 966 RVA: 0x0000E490 File Offset: 0x0000C690
		public static T Crear<T>(HitSkin skin, Transform targetBone, Transform endBone, float ancho, float alto, Transform parent) where T : LenguaParteCollider
		{
			if (endBone == null)
			{
				throw new ArgumentNullException("endBone", "endBone null reference.");
			}
			T t = BoneColliderGeneric<BoxCollider>.Crear<T>(skin, targetBone, parent, true);
			BoxCollider boneCollider = t.boneCollider;
			Vector3 vector = t.transform.InverseTransformPoint(endBone.position);
			boneCollider.center = vector / 2f;
			LenguaParteCollider lenguaParteCollider = t;
			BoxCollider boxCollider = boneCollider;
			Vector3 vector2 = new Vector3(ancho, alto, vector.magnitude);
			boxCollider.size = vector2;
			lenguaParteCollider.m_defaultSize = vector2;
			boneCollider.transform.rotation = Quaternion.LookRotation(targetBone.forward, Vector3.up);
			return t;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000E534 File Offset: 0x0000C734
		public static T Crear<T>(HitSkin skin, Transform targetBone, float largo, float ancho, float alto, Transform parent) where T : LenguaParteCollider
		{
			T t = BoneColliderGeneric<BoxCollider>.Crear<T>(skin, targetBone, parent, true);
			BoxCollider boneCollider = t.boneCollider;
			Vector3 vector = new Vector3(0f, 0f, largo);
			boneCollider.center = vector / 2f;
			LenguaParteCollider lenguaParteCollider = t;
			BoxCollider boxCollider = boneCollider;
			Vector3 vector2 = new Vector3(ancho, alto, vector.magnitude);
			boxCollider.size = vector2;
			lenguaParteCollider.m_defaultSize = vector2;
			boneCollider.transform.rotation = Quaternion.LookRotation(targetBone.forward, Vector3.up);
			return t;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000E5B9 File Offset: 0x0000C7B9
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.size = Vector3.Scale(this.m_defaultSize, mod);
		}

		// Token: 0x040002CD RID: 717
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_defaultSize;
	}
}
