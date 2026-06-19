using System;
using System.Collections.Generic;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000050 RID: 80
	public static class BoundsCalcule
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0000CBD4 File Offset: 0x0000ADD4
		public static Bounds LocalBounds(this List<Collider> colliders, Transform reference)
		{
			if (colliders.Count == 0)
			{
				throw new InvalidOperationException();
			}
			Bounds bounds = default(Bounds);
			for (int i = 0; i < colliders.Count; i++)
			{
				Bounds bounds2;
				if (BoundsCalcule.tryGetColliderLocalbounds(colliders[i], out bounds2, reference))
				{
					bounds.Encapsulate(bounds2);
				}
			}
			return bounds;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000CC24 File Offset: 0x0000AE24
		public static Bounds LocalBounds(this BoxCollider collider, Transform reference)
		{
			Transform transform = collider.transform;
			Vector3 position = transform.position;
			Vector3 position2 = reference.position;
			Vector3 vector = position - position2;
			Vector3 vector2 = reference.InverseTransformDirection(vector);
			Quaternion quaternion = Quaternion.Inverse(reference.rotation) * transform.rotation;
			Vector3 lossyScale = transform.lossyScale;
			return new Bounds(Vector3.Scale(collider.center, lossyScale) + vector2, quaternion * Vector3.Scale(collider.size, lossyScale));
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000CCA0 File Offset: 0x0000AEA0
		public static Bounds LocalBounds(this SphereCollider collider, Transform reference)
		{
			Transform transform = collider.transform;
			Vector3 position = transform.position;
			Vector3 position2 = reference.position;
			Vector3 vector = position - position2;
			Vector3 vector2 = reference.InverseTransformDirection(vector);
			Quaternion quaternion = Quaternion.Inverse(reference.rotation) * transform.rotation;
			float num = collider.radius * 2f;
			Vector3 vector3 = new Vector3(num, num, num);
			Vector3 lossyScale = transform.lossyScale;
			return new Bounds(Vector3.Scale(collider.center, lossyScale) + vector2, quaternion * Vector3.Scale(vector3, lossyScale));
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000CD34 File Offset: 0x0000AF34
		public static Bounds LocalBounds(this CapsuleCollider collider, Transform reference)
		{
			Transform transform = collider.transform;
			Vector3 position = transform.position;
			Vector3 position2 = reference.position;
			Vector3 vector = position - position2;
			Vector3 vector2 = reference.InverseTransformDirection(vector);
			Quaternion quaternion = Quaternion.Inverse(reference.rotation) * transform.rotation;
			float num = collider.radius * 2f;
			float height = collider.height;
			Vector3 vector3;
			switch (collider.direction)
			{
			case 0:
				vector3 = new Vector3(height, num, num);
				break;
			case 1:
				vector3 = new Vector3(num, height, num);
				break;
			case 2:
				vector3 = new Vector3(num, num, height);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			Vector3 lossyScale = transform.lossyScale;
			return new Bounds(Vector3.Scale(collider.center, lossyScale) + vector2, quaternion * Vector3.Scale(vector3, lossyScale));
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000CE14 File Offset: 0x0000B014
		private static bool tryGetColliderLocalbounds(Collider collider, out Bounds bounds, Transform reference)
		{
			BoxCollider boxCollider = collider as BoxCollider;
			if (boxCollider != null)
			{
				bounds = boxCollider.LocalBounds(reference);
				return true;
			}
			SphereCollider sphereCollider = collider as SphereCollider;
			if (sphereCollider != null)
			{
				bounds = sphereCollider.LocalBounds(reference);
				return true;
			}
			CapsuleCollider capsuleCollider = collider as CapsuleCollider;
			if (capsuleCollider != null)
			{
				bounds = capsuleCollider.LocalBounds(reference);
				return true;
			}
			bounds = default(Bounds);
			return false;
		}
	}
}
