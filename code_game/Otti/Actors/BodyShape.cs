using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using com.ootii.Data.Serializers;
using com.ootii.Geometry;
using com.ootii.Utilities;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x02000094 RID: 148
	public abstract class BodyShape
	{
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x0002C53C File Offset: 0x0002A73C
		// (set) Token: 0x0600084A RID: 2122 RVA: 0x0002C544 File Offset: 0x0002A744
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x0002C54D File Offset: 0x0002A74D
		// (set) Token: 0x0600084C RID: 2124 RVA: 0x0002C555 File Offset: 0x0002A755
		public bool UseUnityColliders
		{
			get
			{
				return this._UseUnityColliders;
			}
			set
			{
				this._UseUnityColliders = value;
				if (this._UseUnityColliders)
				{
					if (this.mColliders == null || this.mColliders.Length == 0)
					{
						this.CreateUnityColliders();
						return;
					}
				}
				else if (this.mColliders != null)
				{
					this.DestroyUnityColliders();
				}
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0002C58C File Offset: 0x0002A78C
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x0002C594 File Offset: 0x0002A794
		public bool IsEnabledOnGround
		{
			get
			{
				return this._IsEnabledOnGround;
			}
			set
			{
				this._IsEnabledOnGround = value;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x0002C59D File Offset: 0x0002A79D
		// (set) Token: 0x06000850 RID: 2128 RVA: 0x0002C5A5 File Offset: 0x0002A7A5
		public bool IsEnabledOnSlope
		{
			get
			{
				return this._IsEnabledOnSlope;
			}
			set
			{
				this._IsEnabledOnSlope = value;
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x0002C5AE File Offset: 0x0002A7AE
		// (set) Token: 0x06000852 RID: 2130 RVA: 0x0002C5B6 File Offset: 0x0002A7B6
		public bool IsEnabledAboveGround
		{
			get
			{
				return this._IsEnabledAboveGround;
			}
			set
			{
				this._IsEnabledAboveGround = value;
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000853 RID: 2131 RVA: 0x0002C5BF File Offset: 0x0002A7BF
		[SerializationIgnore]
		public Transform Parent
		{
			get
			{
				return this._Parent;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x0002C5C7 File Offset: 0x0002A7C7
		[SerializationIgnore]
		public ICharacterController CharacterController
		{
			get
			{
				return this._CharacterController;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x0002C5CF File Offset: 0x0002A7CF
		// (set) Token: 0x06000856 RID: 2134 RVA: 0x0002C5D7 File Offset: 0x0002A7D7
		[SerializationIgnore]
		public virtual Transform Transform
		{
			get
			{
				return this._Transform;
			}
			set
			{
				if (this._Transform == value)
				{
					return;
				}
				this._Transform = value;
				if (this._UseUnityColliders && this.mColliders != null)
				{
					this.CreateUnityColliders();
				}
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x0002C605 File Offset: 0x0002A805
		// (set) Token: 0x06000858 RID: 2136 RVA: 0x0002C60D File Offset: 0x0002A80D
		public virtual Vector3 Offset
		{
			get
			{
				return this._Offset;
			}
			set
			{
				this._Offset = value;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0002C616 File Offset: 0x0002A816
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x0002C61E File Offset: 0x0002A81E
		public virtual float Radius
		{
			get
			{
				return this._Radius;
			}
			set
			{
				this._Radius = value;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x0002C627 File Offset: 0x0002A827
		// (set) Token: 0x0600085C RID: 2140 RVA: 0x0002C62F File Offset: 0x0002A82F
		[SerializationIgnore]
		public virtual Collider[] Colliders
		{
			get
			{
				return this.mColliders;
			}
			set
			{
				this.mColliders = value;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x0002C638 File Offset: 0x0002A838
		// (set) Token: 0x0600085E RID: 2142 RVA: 0x0002C655 File Offset: 0x0002A855
		[SerializationIgnore]
		public virtual Collider Collider
		{
			get
			{
				if (this.mColliders == null || this.mColliders.Length == 0)
				{
					return null;
				}
				return this.mColliders[0];
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

		// Token: 0x0600085F RID: 2143 RVA: 0x0002C67D File Offset: 0x0002A87D
		public virtual void LateUpdate()
		{
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0002C67F File Offset: 0x0002A87F
		public virtual List<BodyShapeHit> CollisionOverlap(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask)
		{
			return null;
		}

		// Token: 0x06000861 RID: 2145
		public abstract bool CollisionOverlapTavo(Vector3 rPositionDelta, Quaternion rRotationDelta, int rLayerMask, out BodyShape.BodyShapeHitFast hit);

		// Token: 0x06000862 RID: 2146 RVA: 0x0002C682 File Offset: 0x0002A882
		public virtual BodyShapeHit[] CollisionCastAll(Vector3 rPositionDelta, Vector3 rDirection, float rDistance, int rLayerMask)
		{
			return null;
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0002C688 File Offset: 0x0002A888
		public virtual Vector3 ClosestPoint(Vector3 rOrigin)
		{
			Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
			Vector3 vector = transform.position + transform.rotation * this._Offset;
			return GeometryExt.ClosestPoint(rOrigin, vector, this._Radius);
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0002C6DC File Offset: 0x0002A8DC
		public virtual bool ClosestPoint(Collider rCollider, Vector3 rMovement, bool rProcessTerrain, out Vector3 rShapePoint, out Vector3 rContactPoint)
		{
			Transform transform = ((this._Transform != null) ? this._Transform : this._Parent);
			rShapePoint = transform.position + transform.rotation * this._Offset;
			rContactPoint = Vector3.zero;
			return false;
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0002C736 File Offset: 0x0002A936
		public virtual Vector3 CalculateHitOrigin(Vector3 rHitPoint, Vector3 rStartPosition, Vector3 rEndPosition)
		{
			return GeometryExt.ClosestPoint(rHitPoint, rStartPosition, rEndPosition);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0002C740 File Offset: 0x0002A940
		public virtual void CreateUnityColliders()
		{
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0002C744 File Offset: 0x0002A944
		public virtual void DestroyUnityColliders()
		{
			if (this.mColliders != null)
			{
				for (int i = 0; i < this.mColliders.Length; i++)
				{
					Collider collider = this.mColliders[i];
					if (Application.isPlaying)
					{
						Object.Destroy(collider);
					}
					else
					{
						Object.DestroyImmediate(collider);
					}
				}
			}
			this.mColliders = null;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0002C794 File Offset: 0x0002A994
		public virtual string Serialize()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			stringBuilder.Append(", \"Type\" : \"" + base.GetType().AssemblyQualifiedName + "\"");
			foreach (PropertyInfo propertyInfo in base.GetType().GetProperties())
			{
				if (propertyInfo.CanWrite && propertyInfo.GetValue(this, null) != null)
				{
					object value = propertyInfo.GetValue(this, null);
					if (propertyInfo.PropertyType == typeof(Vector2))
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							", \"",
							propertyInfo.Name,
							"\" : \"",
							((Vector2)value).ToString("G8"),
							"\""
						}));
					}
					else if (propertyInfo.PropertyType == typeof(Vector3))
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							", \"",
							propertyInfo.Name,
							"\" : \"",
							((Vector3)value).ToString("G8"),
							"\""
						}));
					}
					else if (propertyInfo.PropertyType == typeof(Vector4))
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							", \"",
							propertyInfo.Name,
							"\" : \"",
							((Vector4)value).ToString("G8"),
							"\""
						}));
					}
					else if (propertyInfo.PropertyType == typeof(Transform))
					{
						string text = "";
						Transform transform = (Transform)value;
						while (transform != null)
						{
							if (transform.parent != null)
							{
								text = transform.name + ((text.Length > 0) ? "/" : "") + text;
							}
							transform = transform.parent;
							if (transform == this._Parent)
							{
								break;
							}
						}
						if (text.Length == 0)
						{
							text = ".";
						}
						stringBuilder.Append(string.Concat(new string[] { ", \"", propertyInfo.Name, "\" : \"", text, "\"" }));
					}
					else
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							", \"",
							propertyInfo.Name,
							"\" : \"",
							value.ToString(),
							"\""
						}));
					}
				}
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0002CA6C File Offset: 0x0002AC6C
		public virtual void Deserialize(string rDefinition)
		{
			JSONNode jsonnode = JSONNode.Parse(rDefinition);
			if (jsonnode == null)
			{
				return;
			}
			foreach (PropertyInfo propertyInfo in base.GetType().GetProperties())
			{
				if (propertyInfo.CanWrite)
				{
					JSONNode jsonnode2 = jsonnode[propertyInfo.Name];
					if (jsonnode2 == null)
					{
						if (propertyInfo.PropertyType == typeof(string))
						{
							propertyInfo.SetValue(this, "", null);
						}
					}
					else if (propertyInfo.PropertyType == typeof(string))
					{
						propertyInfo.SetValue(this, jsonnode2.Value, null);
					}
					else if (propertyInfo.PropertyType == typeof(int))
					{
						propertyInfo.SetValue(this, jsonnode2.AsInt, null);
					}
					else if (propertyInfo.PropertyType == typeof(float))
					{
						propertyInfo.SetValue(this, jsonnode2.AsFloat, null);
					}
					else if (propertyInfo.PropertyType == typeof(bool))
					{
						propertyInfo.SetValue(this, jsonnode2.AsBool, null);
					}
					else if (propertyInfo.PropertyType == typeof(Vector2))
					{
						Vector2 vector = Vector2.zero;
						vector = vector.FromString(jsonnode2.Value);
						propertyInfo.SetValue(this, vector, null);
					}
					else if (propertyInfo.PropertyType == typeof(Vector3))
					{
						Vector3 vector2 = Vector3.zero;
						vector2 = vector2.FromString(jsonnode2.Value);
						propertyInfo.SetValue(this, vector2, null);
					}
					else if (propertyInfo.PropertyType == typeof(Vector4))
					{
						Vector4 vector3 = Vector4.zero;
						vector3 = vector3.FromString(jsonnode2.Value);
						propertyInfo.SetValue(this, vector3, null);
					}
					else if (propertyInfo.PropertyType == typeof(Transform) && this._Parent != null)
					{
						if (jsonnode2.Value == ".")
						{
							propertyInfo.SetValue(this, this._Parent, null);
						}
						else
						{
							Transform transform = this._Parent.Find(jsonnode2.Value);
							if (transform != null)
							{
								propertyInfo.SetValue(this, transform, null);
							}
						}
					}
				}
			}
		}

		// Token: 0x0400044D RID: 1101
		public const float EPSILON = 0.001f;

		// Token: 0x0400044E RID: 1102
		public string _Name = "";

		// Token: 0x0400044F RID: 1103
		public bool _UseUnityColliders = true;

		// Token: 0x04000450 RID: 1104
		public bool _IsEnabledOnGround = true;

		// Token: 0x04000451 RID: 1105
		public bool _IsEnabledOnSlope = true;

		// Token: 0x04000452 RID: 1106
		public bool _IsEnabledAboveGround = true;

		// Token: 0x04000453 RID: 1107
		[NonSerialized]
		public Transform _Parent;

		// Token: 0x04000454 RID: 1108
		[NonSerialized]
		public ICharacterController _CharacterController;

		// Token: 0x04000455 RID: 1109
		[NonSerialized]
		public Transform _Transform;

		// Token: 0x04000456 RID: 1110
		public Vector3 _Offset = Vector3.zero;

		// Token: 0x04000457 RID: 1111
		public float _Radius = 0.25f;

		// Token: 0x04000458 RID: 1112
		protected Collider[] mColliders;

		// Token: 0x04000459 RID: 1113
		protected RaycastHit[] mRaycastHitArray = new RaycastHit[15];

		// Token: 0x0400045A RID: 1114
		protected BodyShapeHit[] mBodyShapeHitArray = new BodyShapeHit[15];

		// Token: 0x02000136 RID: 310
		public struct BodyShapeHitFast
		{
			// Token: 0x04000DDF RID: 3551
			public Vector3 HitOrigin;

			// Token: 0x04000DE0 RID: 3552
			public Vector3 HitPoint;

			// Token: 0x04000DE1 RID: 3553
			public float HitDistance;
		}
	}
}
