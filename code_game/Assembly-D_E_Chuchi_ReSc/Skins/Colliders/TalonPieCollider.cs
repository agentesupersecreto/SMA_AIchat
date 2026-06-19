using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x020000B7 RID: 183
	public class TalonPieCollider : BoneColliderGeneric<SphereCollider>
	{
		// Token: 0x060003DB RID: 987 RVA: 0x0000EC38 File Offset: 0x0000CE38
		public static T Crear<T>(Skin skin, Transform pieBaseBone, float ancho, Transform dedosRoot, Transform parent, BoneCollider.Mode mode = BoneCollider.Mode.zAxis) where T : TalonPieCollider
		{
			if (dedosRoot == null)
			{
				throw new ArgumentNullException("dedosRoot", "dedosRoot null reference.");
			}
			T t = BoneColliderGeneric<SphereCollider>.Crear<T>(skin, pieBaseBone, parent, false);
			SphereCollider boneCollider = t.boneCollider;
			Vector3 vector = pieBaseBone.InverseTransformPoint(dedosRoot.position);
			Vector3 vector2;
			if (mode != BoneCollider.Mode.zAxis)
			{
				if (mode != BoneCollider.Mode.yAxis)
				{
					throw new ArgumentOutOfRangeException(mode.ToString());
				}
				vector2 = new Vector3(0f, vector.y, 0f);
			}
			else
			{
				vector2 = new Vector3(0f, 0f, vector.z);
			}
			boneCollider.center = vector2;
			t.m_defaultRadius = (boneCollider.radius = ancho / 2f);
			return t;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000ECF7 File Offset: 0x0000CEF7
		protected override void SizeModChanged(Vector3 mod)
		{
			base.boneCollider.radius = this.m_defaultRadius * mod.x;
		}

		// Token: 0x040002D4 RID: 724
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultRadius;
	}
}
