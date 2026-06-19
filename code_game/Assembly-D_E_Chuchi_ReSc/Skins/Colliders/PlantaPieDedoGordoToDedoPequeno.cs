using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B5 RID: 181
	public class PlantaPieDedoGordoToDedoPequeno : BoneColliderGeneric<CapsuleCollider>
	{
		// Token: 0x060003D5 RID: 981 RVA: 0x0000E9E8 File Offset: 0x0000CBE8
		public static T Crear<T>(Skin skin, Transform rootFiengers, Transform dedoGordo, Transform dedoPequeño, float ancho, Transform parent) where T : PlantaPieDedoGordoToDedoPequeno
		{
			if (dedoGordo == null)
			{
				throw new ArgumentNullException("dedoGordo", "dedoGordo null reference.");
			}
			if (dedoPequeño == null)
			{
				throw new ArgumentNullException("dedoPequeño", "dedoPequeño null reference.");
			}
			T t = BoneColliderGeneric<CapsuleCollider>.Crear<T>(skin, rootFiengers, parent, true);
			CapsuleCollider boneCollider = t.boneCollider;
			boneCollider.direction = 2;
			Vector3 vector = rootFiengers.InverseTransformPoint(dedoGordo.position);
			Vector3 vector2 = rootFiengers.InverseTransformPoint(dedoPequeño.position);
			Vector3 vector3 = vector2 - vector;
			Vector3 vector4 = (vector2 + vector) / 2f;
			t.m_defaultRadius = (boneCollider.radius = ancho / 2f);
			t.m_defaultHeigth = (boneCollider.height = vector3.magnitude + boneCollider.radius);
			boneCollider.transform.localPosition = vector4;
			boneCollider.transform.localRotation = Quaternion.LookRotation(vector3);
			return t;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000EAD5 File Offset: 0x0000CCD5
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.radius = this.m_defaultRadius * mod.x;
			base.boneCollider.height = this.m_defaultHeigth * mod.y;
		}

		// Token: 0x040002D1 RID: 721
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultRadius;

		// Token: 0x040002D2 RID: 722
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultHeigth;
	}
}
