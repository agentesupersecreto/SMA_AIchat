using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B6 RID: 182
	public class PlantaSuperiorPieCollider : BoneColliderGeneric<BoxCollider>
	{
		// Token: 0x060003D8 RID: 984 RVA: 0x0000EB10 File Offset: 0x0000CD10
		public static T Crear<T>(Skin skin, Transform pieBase, Transform dedoGordo, Transform dedoPequeño, float alto, float ancho, Transform parent, BoneCollider.Mode mode = BoneCollider.Mode.zAxis) where T : PlantaSuperiorPieCollider
		{
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
			Vector3 vector = pieBase.InverseTransformPoint((dedoPequeño.position + dedoGordo.position) / 2f);
			PlantaSuperiorPieCollider plantaSuperiorPieCollider = t;
			BoxCollider boxCollider = boneCollider;
			Vector3 vector2 = new Vector3(ancho, alto, vector.magnitude);
			boxCollider.size = vector2;
			plantaSuperiorPieCollider.m_defaultSize = vector2;
			if (mode != BoneCollider.Mode.zAxis)
			{
				if (mode != BoneCollider.Mode.yAxis)
				{
					throw new ArgumentOutOfRangeException(mode.ToString());
				}
				boneCollider.transform.localRotation = Quaternion.LookRotation(vector, -Vector3.up);
			}
			else
			{
				boneCollider.transform.localRotation = Quaternion.LookRotation(vector, -Vector3.forward);
			}
			boneCollider.transform.localPosition = vector / 2f;
			return t;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000EC1C File Offset: 0x0000CE1C
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.size = Vector3.Scale(this.m_defaultSize, mod);
		}

		// Token: 0x040002D3 RID: 723
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_defaultSize;
	}
}
