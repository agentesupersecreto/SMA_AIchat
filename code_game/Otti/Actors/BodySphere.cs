using System;
using System.Collections.Generic;
using com.ootii.Data.Serializers;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x02000097 RID: 151
	[Serializable]
	public class BodySphere : BodyShape
	{
		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x0002E241 File Offset: 0x0002C441
		// (set) Token: 0x06000888 RID: 2184 RVA: 0x0002E24C File Offset: 0x0002C44C
		public override Vector3 Offset
		{
			get
			{
				return this._Offset;
			}
			set
			{
				if (this._Offset == value)
				{
					return;
				}
				this._Offset = value;
				if (this.mColliders != null && this.Collider != null)
				{
					Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
					float num = (transform.lossyScale.x + transform.lossyScale.y + transform.lossyScale.z) / 3f;
					this.Collider.center = this._Offset / num;
				}
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000889 RID: 2185 RVA: 0x0002E2E3 File Offset: 0x0002C4E3
		// (set) Token: 0x0600088A RID: 2186 RVA: 0x0002E2EC File Offset: 0x0002C4EC
		public override float Radius
		{
			get
			{
				return this._Radius;
			}
			set
			{
				if (this._Radius == value)
				{
					return;
				}
				this._Radius = value;
				if (this.mColliders != null && this.Collider != null)
				{
					Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
					float num = (transform.lossyScale.x + transform.lossyScale.y + transform.lossyScale.z) / 3f;
					this.Collider.radius = this._Radius / num;
				}
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x0002E37A File Offset: 0x0002C57A
		// (set) Token: 0x0600088C RID: 2188 RVA: 0x0002E39C File Offset: 0x0002C59C
		[SerializationIgnore]
		public new SphereCollider Collider
		{
			get
			{
				if (this.mColliders == null || this.mColliders.Length == 0)
				{
					return null;
				}
				return this.mColliders[0] as SphereCollider;
			}
			set
			{
				if (this.mColliders == null || this.mColliders.Length == 0)
				{
					this.mColliders = new Collider[1];
				}
				this.mColliders[0] = value;
			}
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0002E3C4 File Offset: 0x0002C5C4
		public override bool CollisionOverlapTavo(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask, out BodyShape.BodyShapeHitFast hit)
		{
			if (!(this._Transform == null))
			{
				Transform transform = this._Transform;
			}
			else
			{
				Transform parent = this._Parent;
			}
			Vector3 vector = rPositionDelta + ((this._Transform == null) ? (this._Parent.position + this._Parent.rotation * rRotationDelta * this._Offset) : (this._Transform.position + this._Transform.rotation * rRotationDelta * this._Offset));
			Collider[] array = null;
			int num = RaycastExt.SafeOverlapSphere(vector, this._Radius, out array, rLayerMask, this._Parent, null, true);
			for (int i = 0; i < this.mColliders.Length; i++)
			{
				Collider collider = this.mColliders[i];
				Transform transform2 = collider.transform;
				for (int j = 0; j < num; j++)
				{
					Collider collider2 = array[j];
					Transform transform3 = collider2.transform;
					Vector3 vector2;
					float num2;
					if (Physics.ComputePenetration(collider, transform2.position, transform2.rotation, collider2, transform3.position, transform3.rotation, out vector2, out num2))
					{
						hit = default(BodyShape.BodyShapeHitFast);
						hit.HitDistance = num2;
						hit.HitOrigin = collider.bounds.center;
						hit.HitPoint = hit.HitOrigin + vector2 * num2;
						return true;
					}
				}
			}
			hit = default(BodyShape.BodyShapeHitFast);
			return false;
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0002E540 File Offset: 0x0002C740
		public override List<BodyShapeHit> CollisionOverlap(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask)
		{
			List<BodyShapeHit> list = new List<BodyShapeHit>();
			Vector3 vector = rPositionDelta + ((this._Transform == null) ? (this._Parent.position + this._Parent.rotation * rRotationDelta * this._Offset) : (this._Transform.position + this._Transform.rotation * rRotationDelta * this._Offset));
			GeometryExt.Ignore = this._Parent;
			Collider[] array = null;
			int num = RaycastExt.SafeOverlapSphere(vector, this._Radius, out array, rLayerMask, this._Parent, null, true);
			for (int i = 0; i < num; i++)
			{
				if (!(array[i].transform == this._Transform) && (this._CharacterController == null || !this._CharacterController.IsIgnoringCollision(array[i])))
				{
					Vector3 vector2 = vector;
					Vector3 vector3 = GeometryExt.ClosestPoint(vector, this._Radius, array[i], rLayerMask);
					if (vector3 != Vector3Ext.Null)
					{
						float num2 = Vector3.Distance(vector2, vector3);
						if (num2 < this._Radius + 0.001f)
						{
							BodyShapeHit bodyShapeHit = BodyShapeHit.Allocate();
							bodyShapeHit.StartPosition = vector;
							bodyShapeHit.HitCollider = array[i];
							bodyShapeHit.HitOrigin = vector2;
							bodyShapeHit.HitPoint = vector3;
							bodyShapeHit.HitDistance = num2 - this._Radius - 0.001f;
							list.Add(bodyShapeHit);
						}
					}
				}
			}
			GeometryExt.Ignore = null;
			GeometryExt.IgnoreArray = null;
			return list;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0002E6C8 File Offset: 0x0002C8C8
		public override BodyShapeHit[] CollisionCastAll(Vector3 rPositionDelta, Vector3 rDirection, float rDistance, int rLayerMask)
		{
			Vector3 vector = rPositionDelta + ((this._Transform == null) ? (this._Parent.position + this._Parent.rotation * this._Offset) : (this._Transform.position + this._Transform.rotation * this._Offset));
			for (int i = 0; i < this.mBodyShapeHitArray.Length; i++)
			{
				this.mBodyShapeHitArray[i] = null;
			}
			int num = Physics.SphereCastNonAlloc(vector, this._Radius, rDirection, this.mRaycastHitArray, rDistance + 0.001f, rLayerMask, QueryTriggerInteraction.Ignore);
			int num2 = 0;
			for (int j = 0; j < num; j++)
			{
				if (!this.mRaycastHitArray[j].collider.isTrigger && (this._CharacterController == null || !this._CharacterController.IsIgnoringCollision(this.mRaycastHitArray[j].collider)))
				{
					Transform transform = this.mRaycastHitArray[j].collider.transform;
					if (!(transform == this._Transform))
					{
						bool flag = true;
						while (transform != null)
						{
							if (transform == this._Parent)
							{
								flag = false;
								break;
							}
							transform = transform.parent;
						}
						if (flag)
						{
							BodyShapeHit bodyShapeHit = BodyShapeHit.Allocate();
							bodyShapeHit.StartPosition = vector;
							bodyShapeHit.Shape = this;
							bodyShapeHit.Hit = this.mRaycastHitArray[j];
							bodyShapeHit.HitOrigin = vector;
							bodyShapeHit.HitCollider = this.mRaycastHitArray[j].collider;
							bodyShapeHit.HitPoint = this.mRaycastHitArray[j].point;
							bodyShapeHit.HitNormal = this.mRaycastHitArray[j].normal;
							bodyShapeHit.HitDistance = this.mRaycastHitArray[j].distance;
							if (this.mRaycastHitArray[j].distance == 0f)
							{
								Vector3 vector2 = Vector3.zero;
								vector2 = GeometryExt.ClosestPoint(vector, this._Radius, bodyShapeHit.HitCollider, rLayerMask);
								if (vector2 == Vector3Ext.Null)
								{
									BodyShapeHit.Release(bodyShapeHit);
									goto IL_039C;
								}
								Vector3 vector3 = vector2 - vector;
								if (Mathf.Abs(vector3.magnitude - this._Radius) < 0.001f && Vector3.Dot(vector3.normalized, rDirection) <= -0.8f)
								{
									BodyShapeHit.Release(bodyShapeHit);
									goto IL_039C;
								}
								bodyShapeHit.HitOrigin = vector;
								bodyShapeHit.HitPoint = vector2;
								bodyShapeHit.HitDistance = vector3.magnitude - this._Radius;
								bodyShapeHit.HitPenetration = bodyShapeHit.HitDistance < 0f;
								RaycastHit raycastHit;
								if (RaycastExt.SafeRaycast(vector, vector3.normalized, out raycastHit, Mathf.Max(bodyShapeHit.HitDistance + this._Radius, this._Radius + 0.01f), -1, null, null, true, false))
								{
									bodyShapeHit.HitNormal = raycastHit.normal;
								}
								else if (bodyShapeHit.HitDistance < 0.001f)
								{
									bodyShapeHit.HitNormal = (vector - vector2).normalized;
								}
							}
							if (bodyShapeHit != null)
							{
								RaycastHit raycastHit2;
								if (rDirection != Vector3.down && RaycastExt.SafeRaycast(bodyShapeHit.HitPoint - rDirection * rDistance, rDirection, out raycastHit2, rDistance + this._Radius, -1, this._Parent, null, true, false))
								{
									bodyShapeHit.HitNormal = raycastHit2.normal;
								}
								bodyShapeHit.HitRootDistance = this._Parent.InverseTransformPoint(bodyShapeHit.HitPoint).y;
								this.mBodyShapeHitArray[num2] = bodyShapeHit;
								num2++;
							}
						}
					}
				}
				IL_039C:;
			}
			return this.mBodyShapeHitArray;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0002EA88 File Offset: 0x0002CC88
		public override bool ClosestPoint(Collider rCollider, Vector3 rMovement, bool rProcessTerrain, out Vector3 rShapePoint, out Vector3 rContactPoint)
		{
			Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
			rShapePoint = transform.position + transform.rotation * this._Offset;
			rContactPoint = Vector3.zero;
			rContactPoint = GeometryExt.ClosestPoint(rShapePoint, this._Radius, rCollider, -1);
			return rContactPoint != Vector3Ext.Null;
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x0002EB0D File Offset: 0x0002CD0D
		public override Vector3 CalculateHitOrigin(Vector3 rHitPoint, Vector3 rStartPosition, Vector3 rEndPosition)
		{
			return rStartPosition;
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x0002EB10 File Offset: 0x0002CD10
		public override void CreateUnityColliders()
		{
			if (this._Parent == null)
			{
				return;
			}
			this.DestroyUnityColliders();
			Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
			float num = (transform.lossyScale.x + transform.lossyScale.y + transform.lossyScale.z) / 3f;
			SphereCollider sphereCollider = transform.gameObject.AddComponent<SphereCollider>();
			sphereCollider.radius = this._Radius / num;
			sphereCollider.center = this._Offset / num;
			if (this.mColliders == null || this.mColliders.Length == 0)
			{
				this.mColliders = new Collider[1];
			}
			this.mColliders[0] = sphereCollider;
		}
	}
}
