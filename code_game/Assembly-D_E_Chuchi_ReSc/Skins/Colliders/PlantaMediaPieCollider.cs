using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B3 RID: 179
	public class PlantaMediaPieCollider : BoneColliderGeneric<BoxCollider>
	{
		// Token: 0x060003CF RID: 975 RVA: 0x0000E6B8 File Offset: 0x0000C8B8
		public static T Crear<T>(Skin skin, Transform pieBase, TalonPieCollider talon, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho, Transform parent, BoneCollider.Mode mode = BoneCollider.Mode.zAxis) where T : PlantaMediaPieCollider
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
			Vector3 vector = talon.boneCollider.transform.TransformPoint(talon.boneCollider.center) - pieBase.position;
			Vector3 vector2 = t.transform.InverseTransformPoint(pieBase.position + vector / 2f);
			Vector3 vector3 = t.transform.InverseTransformPoint((dedoPequeño.position + dedoGordo.position) / 2f) - vector2;
			PlantaMediaPieCollider plantaMediaPieCollider = t;
			BoxCollider boxCollider = boneCollider;
			Vector3 vector4 = new Vector3(ancho, alto, vector3.magnitude);
			boxCollider.size = vector4;
			plantaMediaPieCollider.m_defaultSize = vector4;
			if (mode != BoneCollider.Mode.zAxis)
			{
				if (mode != BoneCollider.Mode.yAxis)
				{
					throw new ArgumentOutOfRangeException(mode.ToString());
				}
				boneCollider.transform.localRotation = Quaternion.LookRotation(vector3, -Vector3.up);
			}
			else
			{
				boneCollider.transform.localRotation = Quaternion.LookRotation(vector3, -Vector3.forward);
			}
			boneCollider.transform.localPosition = vector2 + vector3 / 2f;
			return t;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000E849 File Offset: 0x0000CA49
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.size = Vector3.Scale(this.m_defaultSize, mod);
		}

		// Token: 0x040002CF RID: 719
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_defaultSize;
	}
}
