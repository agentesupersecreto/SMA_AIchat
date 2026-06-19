using System;
using Assets._ReusableScripts.BoneColliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Colliders
{
	// Token: 0x02000131 RID: 305
	public class HandCenterCollider : BoneColliderGeneric<BoxCollider>
	{
		// Token: 0x06000D4E RID: 3406 RVA: 0x0002E154 File Offset: 0x0002C354
		public static T Crear<T>(MonoBehaviour skin, Transform targetBone, float altura, Vector3 localForward, Transform parent, Transform IndexProximalBone, Transform littleProximal) where T : HandCenterCollider
		{
			if (IndexProximalBone == null)
			{
				throw new ArgumentNullException("IndexProximalBone", "IndexProximalBone null reference.");
			}
			if (littleProximal == null)
			{
				throw new ArgumentNullException("littleProximal", "littleProximal null reference.");
			}
			T t = BoneColliderGeneric<BoxCollider>.Crear<T>(skin, targetBone, parent, true);
			Vector3 vector = targetBone.InverseTransformPoint(IndexProximalBone.position);
			Vector3 vector2 = targetBone.InverseTransformPoint(littleProximal.position);
			Vector3 vector3 = (vector + vector2) / 2f;
			float magnitude = vector3.magnitude;
			Vector3 vector4 = vector - vector2;
			float num = vector4.magnitude * 0.7f;
			vector4 = vector4.normalized;
			BoxCollider boneCollider = t.boneCollider;
			Vector3 normalized = vector3.normalized;
			Vector3 vector5 = Vector3.Cross(normalized, vector4);
			Vector3 normalized2 = vector5.normalized;
			Quaternion quaternion = Quaternion.LookRotation(normalized, normalized2);
			boneCollider.transform.localRotation = quaternion;
			Vector3 vector6 = new Vector3(0f, 0f, magnitude * 0.5f);
			boneCollider.center = vector6;
			HandCenterCollider handCenterCollider = t;
			BoxCollider boxCollider = boneCollider;
			vector5 = new Vector3(num, altura, magnitude);
			boxCollider.size = vector5;
			handCenterCollider.m_defaultSize = vector5;
			if (localForward == Vector3.forward)
			{
				t.m_direction = 2;
			}
			else if (localForward == Vector3.up)
			{
				t.m_direction = 1;
			}
			else
			{
				if (!(localForward == Vector3.right))
				{
					throw new ArgumentOutOfRangeException();
				}
				t.m_direction = 0;
			}
			return t;
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x0002E2D0 File Offset: 0x0002C4D0
		protected override void SizeModChanged(Vector3 mod)
		{
			Vector3 defaultSize = this.m_defaultSize;
			switch (this.m_direction)
			{
			case 0:
				defaultSize.y *= mod.x;
				defaultSize.z *= mod.x;
				break;
			case 1:
				defaultSize.x *= mod.x;
				defaultSize.z *= mod.x;
				break;
			case 2:
				defaultSize.y *= mod.x;
				defaultSize.x *= mod.x;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_direction.ToString());
			}
			base.boneCollider.size = defaultSize;
		}

		// Token: 0x04000773 RID: 1907
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_defaultSize;

		// Token: 0x04000774 RID: 1908
		[ReadOnlyUI]
		[SerializeField]
		private int m_direction;
	}
}
