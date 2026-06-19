using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B4 RID: 180
	public class PlantaPieCollider : BoneColliderGeneric<BoxCollider>
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x0000E864 File Offset: 0x0000CA64
		public static T Crear<T>(Skin skin, Transform pieBase, TalonPieCollider talon, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho, Transform parent, BoneCollider.Mode mode = BoneCollider.Mode.zAxis) where T : PlantaPieCollider
		{
			if (talon == null)
			{
				throw new ArgumentNullException("talon", "talon null reference.");
			}
			if (dedoGordo == null)
			{
				throw new ArgumentNullException("dedoGordo", "dedoGordo null reference.");
			}
			if (dedoPequeño == null)
			{
				throw new ArgumentNullException("dedoPequeño", "dedoPequeño null reference.");
			}
			T t = BoneColliderGeneric<BoxCollider>.Crear<T>(skin, pieBase, parent, true);
			BoxCollider boneCollider = t.boneCollider;
			Vector3 vector = t.transform.InverseTransformPoint(talon.boneCollider.transform.TransformPoint(talon.boneCollider.center));
			Vector3 vector2 = t.transform.InverseTransformPoint((dedoPequeño.position + dedoGordo.position) / 2f) - vector;
			PlantaPieCollider plantaPieCollider = t;
			BoxCollider boxCollider = boneCollider;
			Vector3 vector3 = new Vector3(ancho, alto, vector2.magnitude);
			boxCollider.size = vector3;
			plantaPieCollider.m_defaultSize = vector3;
			if (mode != BoneCollider.Mode.zAxis)
			{
				if (mode != BoneCollider.Mode.yAxis)
				{
					throw new ArgumentOutOfRangeException(mode.ToString());
				}
				boneCollider.transform.localRotation = Quaternion.LookRotation(vector2, -Vector3.up);
			}
			else
			{
				boneCollider.transform.localRotation = Quaternion.LookRotation(vector2, -Vector3.forward);
			}
			boneCollider.transform.localPosition = vector + vector2 / 2f;
			return t;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000E9CF File Offset: 0x0000CBCF
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.size = Vector3.Scale(this.m_defaultSize, mod);
		}

		// Token: 0x040002D0 RID: 720
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_defaultSize;
	}
}
