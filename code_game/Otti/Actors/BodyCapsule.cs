using System;
using System.Collections.Generic;
using com.ootii.Data.Serializers;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x02000096 RID: 150
	[Serializable]
	public class BodyCapsule : BodyShape
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x0002CEE1 File Offset: 0x0002B0E1
		// (set) Token: 0x06000873 RID: 2163 RVA: 0x0002CEE9 File Offset: 0x0002B0E9
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
				if (this._UseUnityColliders && this.mColliders != null)
				{
					this.CreateUnityColliders();
				}
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0002CF17 File Offset: 0x0002B117
		// (set) Token: 0x06000875 RID: 2165 RVA: 0x0002CF20 File Offset: 0x0002B120
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
				if (this._UseUnityColliders && this.mColliders != null)
				{
					Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
					float num = (transform.lossyScale.x + transform.lossyScale.y + transform.lossyScale.z) / 3f;
					for (int i = 0; i < this.mColliders.Length; i++)
					{
						if (this.mColliders[i] is SphereCollider)
						{
							((SphereCollider)this.mColliders[i]).radius = this._Radius / num;
						}
						else if (this.mColliders[i] is CapsuleCollider)
						{
							((CapsuleCollider)this.mColliders[i]).radius = this._Radius / num;
						}
					}
				}
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0002D002 File Offset: 0x0002B202
		// (set) Token: 0x06000877 RID: 2167 RVA: 0x0002D00A File Offset: 0x0002B20A
		public Transform EndTransform
		{
			get
			{
				return this._EndTransform;
			}
			set
			{
				if (this._EndTransform == value)
				{
					return;
				}
				this._EndTransform = value;
				if (this._UseUnityColliders && this.mColliders != null)
				{
					this.CreateUnityColliders();
				}
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x0002D038 File Offset: 0x0002B238
		// (set) Token: 0x06000879 RID: 2169 RVA: 0x0002D040 File Offset: 0x0002B240
		public Vector3 EndOffset
		{
			get
			{
				return this._EndOffset;
			}
			set
			{
				if (this._EndOffset == value)
				{
					return;
				}
				this._EndOffset = value;
				if (this._UseUnityColliders && this.mColliders != null)
				{
					this.CreateUnityColliders();
				}
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x0002D06E File Offset: 0x0002B26E
		// (set) Token: 0x0600087B RID: 2171 RVA: 0x0002D090 File Offset: 0x0002B290
		[SerializationIgnore]
		public new CapsuleCollider Collider
		{
			get
			{
				if (this.mColliders == null || this.mColliders.Length == 0)
				{
					return null;
				}
				return this.mColliders[0] as CapsuleCollider;
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

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x0002D0B8 File Offset: 0x0002B2B8
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x0002D0C0 File Offset: 0x0002B2C0
		[SerializationIgnore]
		public SphereCollider EndCollider
		{
			get
			{
				return this.mEndCollider;
			}
			set
			{
				this.mEndCollider = value;
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0002D0CC File Offset: 0x0002B2CC
		public override void LateUpdate()
		{
			if (this.mColliders == null || this.mColliders.Length == 0)
			{
				return;
			}
			if (this.mColliders[0] is CapsuleCollider)
			{
				return;
			}
			Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
			Transform transform2 = ((this._EndTransform != null) ? this._EndTransform : this._Parent);
			Vector3 vector = transform.position + transform.rotation * this._Offset;
			Vector3 vector2 = transform2.position + transform2.rotation * this._EndOffset;
			transform = this._Parent;
			Vector3 vector3 = transform.InverseTransformPoint(vector);
			Vector3 vector4 = (transform.InverseTransformPoint(vector2) - vector3) / (float)(this.mColliders.Length - 1);
			Vector3 vector5 = Vector3.zero;
			for (int i = 0; i < this.mColliders.Length; i++)
			{
				SphereCollider sphereCollider = this.mColliders[i] as SphereCollider;
				if (this.mColliders.Length - 1 == i)
				{
					this.beforeLateUpdateLastColliderCenter = sphereCollider.center;
				}
				sphereCollider.radius = this._Radius;
				sphereCollider.center = vector3 + vector5;
				vector5 += vector4;
			}
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0002D210 File Offset: 0x0002B410
		public override bool CollisionOverlapTavo(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask, out BodyShape.BodyShapeHitFast hit)
		{
			hit = default(BodyShape.BodyShapeHitFast);
			Transform transform = ((this._Transform == null) ? this._Parent : this._Transform);
			Transform transform2 = ((this._EndTransform == null) ? this._Parent : this._EndTransform);
			Transform transform3 = this.mColliders[this.mColliders.Length - 1].transform;
			Vector3 vector = this.beforeLateUpdateLastColliderCenter;
			Vector3 vector2 = transform3.TransformPoint(vector);
			Vector3 vector3 = transform.position + transform.rotation * this._Offset;
			Vector3 vector4 = vector2 + transform2.rotation * this._EndOffset;
			Vector3 vector5 = rPositionDelta + transform.rotation * rRotationDelta * this._Offset;
			Vector3 vector6 = rPositionDelta + transform2.rotation * rRotationDelta * this._EndOffset;
			Vector3 vector7 = vector5 + transform.position;
			Vector3 vector8 = vector6 + vector2;
			Vector3 vector9 = vector7 + (vector8 - vector7) / 2f;
			Vector3 vector10 = vector3 + (vector4 - vector3) / 2f;
			float num = Vector3.Distance(vector7, vector8) / 2f + this._Radius;
			Vector3 vector11 = vector9 - vector10;
			float num2 = vector11.magnitude + 0.001f;
			if (num2 > 0f)
			{
				vector11 = vector11.normalized;
				int layer = this._Parent.gameObject.layer;
				this._Parent.gameObject.layer = 31;
				RaycastHit raycastHit;
				bool flag = Physics.CapsuleCast(vector3, vector4, this._Radius, vector11, out raycastHit, num2, rLayerMask, QueryTriggerInteraction.Ignore);
				this._Parent.gameObject.layer = layer;
				if (flag && raycastHit.distance > Mathf.Epsilon)
				{
					Vector3 vector12 = Vector3.Project(raycastHit.point - vector10, vector11);
					if (vector12.magnitude > this._Radius)
					{
						vector12 = vector12.normalized * (vector12.magnitude - this._Radius);
						float num3 = Vector3.Distance(vector9, vector10 + vector12);
						Vector3 vector13 = -(vector12.normalized * num3);
						hit.HitDistance = num3;
						hit.HitOrigin = vector10;
						hit.HitPoint = vector10 + vector13;
						return true;
					}
				}
			}
			if (this.m_TestingCollider == null)
			{
				this.m_TestingCollider = new GameObject("CollisionOverlap Testing BodyCapsule").AddComponent<CapsuleCollider>();
				this.m_TestingCollider.transform.parent = this._Parent;
			}
			Collider[] array = null;
			int num4 = RaycastExt.SafeOverlapSphere(vector9, num, out array, rLayerMask, this._Parent, null, true);
			Collider testingCollider = this.m_TestingCollider;
			Transform transform4 = testingCollider.transform;
			Vector3 vector14 = vector4 - vector3;
			transform4.position = vector10;
			transform4.rotation = Quaternion.LookRotation(vector14, this._Parent.up);
			this.m_TestingCollider.center = Vector3.zero;
			this.m_TestingCollider.radius = this._Radius;
			this.m_TestingCollider.height = vector14.magnitude + this._Radius * 2f;
			this.m_TestingCollider.direction = 2;
			this.m_TestingCollider.gameObject.layer = 31;
			for (int i = 0; i < num4; i++)
			{
				Collider collider = array[i];
				Transform transform5 = collider.transform;
				Vector3 vector15;
				float num5;
				if (Physics.ComputePenetration(testingCollider, transform4.position, transform4.rotation, collider, transform5.position, transform5.rotation, out vector15, out num5))
				{
					hit.HitDistance = num5;
					hit.HitOrigin = testingCollider.bounds.center;
					hit.HitPoint = hit.HitOrigin + vector15 * num5;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x0002D5F8 File Offset: 0x0002B7F8
		public override List<BodyShapeHit> CollisionOverlap(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask)
		{
			List<BodyShapeHit> list = new List<BodyShapeHit>();
			Transform transform = ((this._Transform == null) ? this._Parent : this._Transform);
			Transform transform2 = ((this._EndTransform == null) ? this._Parent : this._EndTransform);
			Vector3 position = this._Transform.position;
			Vector3 position2 = this._EndTransform.position;
			position + transform.rotation * rRotationDelta * this._Offset;
			position2 + transform2.rotation * rRotationDelta * this._EndOffset;
			Vector3 vector = rPositionDelta + position;
			Vector3 vector2 = rPositionDelta + position2;
			Vector3 vector3 = vector + (vector2 - vector) / 2f;
			float num = Vector3.Distance(vector, vector2) / 2f + this._Radius;
			GeometryExt.Ignore = this._Parent;
			Collider[] array = null;
			int num2 = RaycastExt.SafeOverlapSphere(vector3, num, out array, rLayerMask, this._Parent, null, true);
			for (int i = 0; i < num2; i++)
			{
				Transform transform3 = array[i].transform;
				if (!(transform3 == this._Transform) && !(transform3 == this._EndTransform) && (this._CharacterController == null || !this._CharacterController.IsIgnoringCollision(array[i])))
				{
					Vector3 zero = Vector3.zero;
					Vector3 zero2 = Vector3.zero;
					GeometryExt.ClosestPoints(vector, vector2, this._Radius, array[i], ref zero, ref zero2, rLayerMask);
					if (zero != Vector3Ext.Null && zero2 != Vector3Ext.Null)
					{
						float num3 = Vector3.Distance(zero, zero2);
						if (num3 < this._Radius + 0.001f)
						{
							BodyShapeHit bodyShapeHit = BodyShapeHit.Allocate();
							bodyShapeHit.StartPosition = vector;
							bodyShapeHit.EndPosition = vector2;
							bodyShapeHit.HitCollider = array[i];
							bodyShapeHit.HitOrigin = zero;
							bodyShapeHit.HitPoint = zero2;
							bodyShapeHit.HitDistance = num3 - this._Radius - 0.001f;
							list.Add(bodyShapeHit);
						}
					}
				}
			}
			GeometryExt.Ignore = null;
			GeometryExt.IgnoreArray = null;
			return list;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x0002D828 File Offset: 0x0002BA28
		public override BodyShapeHit[] CollisionCastAll(Vector3 rPositionDelta, Vector3 rDirection, float rDistance, int rLayerMask)
		{
			Vector3 vector = rPositionDelta + ((this._Transform == null) ? (this._Parent.position + this._Parent.rotation * this._Offset) : (this._Transform.position + this._Transform.rotation * this._Offset));
			Vector3 vector2 = rPositionDelta + ((this._EndTransform == null) ? (this._Parent.position + this._Parent.rotation * this._EndOffset) : (this._EndTransform.position + this._EndTransform.rotation * this._EndOffset));
			for (int i = 0; i < this.mBodyShapeHitArray.Length; i++)
			{
				this.mBodyShapeHitArray[i] = null;
			}
			int num = Physics.CapsuleCastNonAlloc(vector, vector2, this._Radius, rDirection, this.mRaycastHitArray, rDistance + 0.001f, rLayerMask, QueryTriggerInteraction.Ignore);
			int num2 = 0;
			for (int j = 0; j < num; j++)
			{
				if (!this.mRaycastHitArray[j].collider.isTrigger)
				{
					Transform transform = this.mRaycastHitArray[j].collider.transform;
					if (!(transform == this._Transform) && !(transform == this._EndTransform) && (this._CharacterController == null || !this._CharacterController.IsIgnoringCollision(this.mRaycastHitArray[j].collider)))
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
							bodyShapeHit.EndPosition = vector2;
							bodyShapeHit.Shape = this;
							bodyShapeHit.Hit = this.mRaycastHitArray[j];
							bodyShapeHit.HitCollider = this.mRaycastHitArray[j].collider;
							bodyShapeHit.HitPoint = this.mRaycastHitArray[j].point;
							bodyShapeHit.HitNormal = this.mRaycastHitArray[j].normal;
							bodyShapeHit.HitDistance = this.mRaycastHitArray[j].distance;
							if (this.mRaycastHitArray[j].distance == 0f)
							{
								Vector3 zero = Vector3.zero;
								Vector3 zero2 = Vector3.zero;
								GeometryExt.ClosestPoints(vector, vector2, this._Radius, bodyShapeHit.HitCollider, ref zero, ref zero2, rLayerMask);
								if (zero2 == Vector3Ext.Null)
								{
									BodyShapeHit.Release(bodyShapeHit);
									goto IL_041A;
								}
								Vector3 vector3 = zero2 - zero;
								bodyShapeHit.HitOrigin = zero;
								bodyShapeHit.HitPoint = zero2;
								bodyShapeHit.HitDistance = vector3.magnitude - this._Radius;
								bodyShapeHit.HitPenetration = bodyShapeHit.HitDistance < 0f;
								RaycastHit raycastHit;
								if (RaycastExt.SafeRaycast(zero, vector3.normalized, out raycastHit, Mathf.Max(bodyShapeHit.HitDistance + this._Radius, this._Radius + 0.01f), -1, null, null, true, false))
								{
									bodyShapeHit.HitNormal = raycastHit.normal;
								}
								else if (bodyShapeHit.HitDistance < 0.001f)
								{
									bodyShapeHit.HitNormal = (zero - zero2).normalized;
								}
							}
							else
							{
								bodyShapeHit.CalculateHitOrigin();
							}
							if (bodyShapeHit != null)
							{
								RaycastHit raycastHit2;
								if (rDirection != Vector3.down && RaycastExt.SafeRaycast(bodyShapeHit.HitPoint - rDirection * rDistance, rDirection, out raycastHit2, rDistance + this._Radius, -1, this._Parent, null, true, false))
								{
									bodyShapeHit.HitNormal = raycastHit2.normal;
								}
								bodyShapeHit.HitNormal = (bodyShapeHit.HitOrigin - bodyShapeHit.HitPoint).normalized;
								bodyShapeHit.HitRootDistance = this._Parent.InverseTransformPoint(bodyShapeHit.HitPoint).y;
								this.mBodyShapeHitArray[num2] = bodyShapeHit;
								num2++;
							}
						}
					}
				}
				IL_041A:;
			}
			return this.mBodyShapeHitArray;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0002DC64 File Offset: 0x0002BE64
		public override Vector3 ClosestPoint(Vector3 rOrigin)
		{
			Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
			Vector3 vector = transform.position + transform.rotation * this._Offset;
			Transform transform2 = ((this._EndTransform != null) ? this._EndTransform : this._Parent);
			Vector3 vector2 = transform2.position + transform2.rotation * this._EndOffset;
			return GeometryExt.ClosestPoint(rOrigin, vector, vector2, this._Radius);
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0002DCF4 File Offset: 0x0002BEF4
		public override bool ClosestPoint(Collider rCollider, Vector3 rMovement, bool rProcessTerrain, out Vector3 rShapePoint, out Vector3 rContactPoint)
		{
			Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
			Vector3 vector = transform.position + transform.rotation * this._Offset;
			Transform transform2 = ((this._EndTransform != null) ? this._EndTransform : this._Parent);
			Vector3 vector2 = transform2.position + transform2.rotation * this._EndOffset;
			rShapePoint = vector;
			rContactPoint = Vector3.zero;
			GeometryExt.ClosestPoints(vector, vector2, this._Radius, rCollider, ref rShapePoint, ref rContactPoint, -1);
			return rContactPoint != Vector3Ext.Null;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0002DDB0 File Offset: 0x0002BFB0
		public override void CreateUnityColliders()
		{
			if (this._Parent == null)
			{
				return;
			}
			this.DestroyUnityColliders();
			Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
			Transform transform2 = ((this._EndTransform != null) ? this._EndTransform : this._Parent);
			float num = (transform.lossyScale.x + transform.lossyScale.y + transform.lossyScale.z) / 3f;
			int num2 = this.DetermineDirection();
			if (transform == transform2 && num2 > -1)
			{
				CapsuleCollider capsuleCollider = transform.gameObject.AddComponent<CapsuleCollider>();
				capsuleCollider.radius = this._Radius / num;
				capsuleCollider.center = (this._Offset + (this._EndOffset - this._Offset) * 0.5f) / num;
				capsuleCollider.height = (Vector3.Distance(this._Offset, this._EndOffset) + this._Radius * 2f) / num;
				capsuleCollider.direction = num2;
				if (this.mColliders == null || this.mColliders.Length == 0)
				{
					this.mColliders = new Collider[1];
				}
				this.mColliders[0] = capsuleCollider;
				return;
			}
			Vector3 vector = transform.position + transform.rotation * this._Offset;
			Vector3 vector2 = transform2.position + transform2.rotation * this._EndOffset;
			transform = this._Parent;
			Vector3 vector3 = transform.InverseTransformPoint(vector);
			Vector3 vector4 = transform.InverseTransformPoint(vector2);
			if (vector4 == vector3)
			{
				if (this.mColliders == null || this.mColliders.Length != 1)
				{
					this.mColliders = new Collider[1];
				}
				SphereCollider sphereCollider = transform.gameObject.AddComponent<SphereCollider>();
				sphereCollider.radius = this._Radius;
				sphereCollider.center = vector3;
				this.mColliders[0] = sphereCollider;
				return;
			}
			Vector3 vector5 = vector4 - vector3;
			int num3 = (int)(vector5.magnitude / this._Radius);
			if (this.mColliders == null || this.mColliders.Length != num3)
			{
				this.mColliders = new Collider[num3 + 2];
			}
			SphereCollider sphereCollider2 = transform.gameObject.AddComponent<SphereCollider>();
			sphereCollider2.radius = this._Radius;
			sphereCollider2.center = vector3;
			this.mColliders[0] = sphereCollider2;
			SphereCollider sphereCollider3 = transform.gameObject.AddComponent<SphereCollider>();
			sphereCollider3.radius = this._Radius;
			sphereCollider3.center = vector4;
			this.mColliders[this.mColliders.Length - 1] = sphereCollider3;
			for (int i = 1; i < this.mColliders.Length - 1; i++)
			{
				SphereCollider sphereCollider4 = transform.gameObject.AddComponent<SphereCollider>();
				sphereCollider4.radius = this._Radius;
				sphereCollider4.center = vector3 + vector5.normalized * (this._Radius * (float)i);
				this.mColliders[i] = sphereCollider4;
			}
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0002E0AC File Offset: 0x0002C2AC
		private int DetermineDirection()
		{
			int num = -1;
			if (this._Offset.sqrMagnitude == 0f)
			{
				if (this._EndOffset.normalized == Vector3.right)
				{
					num = 0;
				}
				else if (this._EndOffset.normalized == Vector3.up)
				{
					num = 1;
				}
				else if (this._EndOffset.normalized == Vector3.forward)
				{
					num = 2;
				}
			}
			else if (this._EndOffset.sqrMagnitude == 0f)
			{
				if (this._Offset.normalized == Vector3.right)
				{
					num = 0;
				}
				else if (this._Offset.normalized == Vector3.up)
				{
					num = 1;
				}
				else if (this._Offset.normalized == Vector3.forward)
				{
					num = 2;
				}
			}
			else if (this._Offset.normalized == Vector3.right && this._EndOffset.normalized == Vector3.right)
			{
				num = 0;
			}
			else if (this._Offset.normalized == Vector3.up && this._EndOffset.normalized == Vector3.up)
			{
				num = 1;
			}
			else if (this._Offset.normalized == Vector3.forward && this._EndOffset.normalized == Vector3.forward)
			{
				num = 2;
			}
			return num;
		}

		// Token: 0x04000468 RID: 1128
		public Transform _EndTransform;

		// Token: 0x04000469 RID: 1129
		public Vector3 _EndOffset = Vector3.zero;

		// Token: 0x0400046A RID: 1130
		protected SphereCollider mEndCollider;

		// Token: 0x0400046B RID: 1131
		private Vector3 beforeLateUpdateLastColliderCenter;

		// Token: 0x0400046C RID: 1132
		private CapsuleCollider m_TestingCollider;
	}
}
