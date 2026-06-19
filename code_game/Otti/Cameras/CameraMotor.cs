using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using com.ootii.Base;
using com.ootii.Geometry;
using com.ootii.Utilities;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000072 RID: 114
	public abstract class CameraMotor : BaseObject
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x0001E3D2 File Offset: 0x0001C5D2
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x0001E3DA File Offset: 0x0001C5DA
		public virtual string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x0001E3E3 File Offset: 0x0001C5E3
		// (set) Token: 0x0600054C RID: 1356 RVA: 0x0001E3EB File Offset: 0x0001C5EB
		public virtual bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0001E3F4 File Offset: 0x0001C5F4
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x0001E3FC File Offset: 0x0001C5FC
		public float Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				this._Priority = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x0001E405 File Offset: 0x0001C605
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x0001E40D File Offset: 0x0001C60D
		public string ActionAlias
		{
			get
			{
				return this._ActionAlias;
			}
			set
			{
				this._ActionAlias = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x0001E416 File Offset: 0x0001C616
		public virtual bool IsActive
		{
			get
			{
				return this._IsActive;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x0001E41E File Offset: 0x0001C61E
		// (set) Token: 0x06000553 RID: 1363 RVA: 0x0001E426 File Offset: 0x0001C626
		public bool UseRigAnchor
		{
			get
			{
				return this._UseRigAnchor;
			}
			set
			{
				this._UseRigAnchor = value;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x0001E42F File Offset: 0x0001C62F
		// (set) Token: 0x06000555 RID: 1365 RVA: 0x0001E438 File Offset: 0x0001C638
		public virtual int AnchorIndex
		{
			get
			{
				return this._AnchorIndex;
			}
			set
			{
				this._AnchorIndex = value;
				if (this._AnchorIndex >= 0 && this.RigController != null && this._AnchorIndex < this.RigController.StoredTransforms.Count)
				{
					this._Anchor = this.RigController.StoredTransforms[this._AnchorIndex];
				}
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x0001E497 File Offset: 0x0001C697
		// (set) Token: 0x06000557 RID: 1367 RVA: 0x0001E4C3 File Offset: 0x0001C6C3
		public virtual Transform Anchor
		{
			get
			{
				if (!this._UseRigAnchor)
				{
					return this._Anchor;
				}
				if (this.RigController != null)
				{
					return this.RigController._Anchor;
				}
				return null;
			}
			set
			{
				this._Anchor = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x0001E4CC File Offset: 0x0001C6CC
		public virtual Transform AnchorRoot
		{
			get
			{
				Transform transform = null;
				if (this._UseRigAnchor)
				{
					if (this.RigController != null)
					{
						transform = this.RigController._Anchor;
					}
				}
				else
				{
					transform = this._Anchor;
				}
				if (transform != null)
				{
					IBaseCameraAnchor component = transform.gameObject.GetComponent<IBaseCameraAnchor>();
					if (component != null)
					{
						transform = component.Root;
					}
				}
				return transform;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x0001E526 File Offset: 0x0001C726
		// (set) Token: 0x0600055A RID: 1370 RVA: 0x0001E556 File Offset: 0x0001C756
		public virtual Vector3 AnchorOffset
		{
			get
			{
				if (!this._UseRigAnchor)
				{
					return this._AnchorOffset;
				}
				if (this.RigController != null)
				{
					return this.RigController._AnchorOffset;
				}
				return Vector3.zero;
			}
			set
			{
				this._AnchorOffset = value;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0001E560 File Offset: 0x0001C760
		public virtual Vector3 AnchorPosition
		{
			get
			{
				Transform anchor = this.Anchor;
				if (anchor == null)
				{
					return this.AnchorOffset;
				}
				if (this.RigController.RotateAnchorOffset)
				{
					return anchor.position + anchor.rotation * this.AnchorOffset;
				}
				return anchor.position + this.AnchorOffset;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x0001E5BF File Offset: 0x0001C7BF
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x0001E5C7 File Offset: 0x0001C7C7
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

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x0001E5D0 File Offset: 0x0001C7D0
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x0001E5D7 File Offset: 0x0001C7D7
		public virtual float MaxDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x0001E5D9 File Offset: 0x0001C7D9
		// (set) Token: 0x06000561 RID: 1377 RVA: 0x0001E5E0 File Offset: 0x0001C7E0
		public virtual float Distance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x0001E5E2 File Offset: 0x0001C7E2
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x0001E5EA File Offset: 0x0001C7EA
		public virtual bool IsCollisionEnabled
		{
			get
			{
				return this._IsCollisionEnabled;
			}
			set
			{
				this._IsCollisionEnabled = value;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0001E5F3 File Offset: 0x0001C7F3
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x0001E5FB File Offset: 0x0001C7FB
		public virtual bool IsFadingEnabled
		{
			get
			{
				return this._IsFadingEnabled;
			}
			set
			{
				this._IsFadingEnabled = value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0001E604 File Offset: 0x0001C804
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x0001E60C File Offset: 0x0001C80C
		public bool SpecifyFadeRenderers
		{
			get
			{
				return this._SpecifyFadeRenderers;
			}
			set
			{
				this._SpecifyFadeRenderers = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0001E615 File Offset: 0x0001C815
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x0001E61D File Offset: 0x0001C81D
		public List<int> FadeTransformIndexes
		{
			get
			{
				return this._FadeTransformIndexes;
			}
			set
			{
				this._FadeTransformIndexes = value;
			}
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0001E628 File Offset: 0x0001C828
		public virtual void Awake()
		{
			if (this.RigController != null && this.RigController.Camera != null)
			{
				this.mRigTransform.FieldOfView = this.RigController.Camera.fieldOfView;
			}
			this.mAnchorOffsetDistance = this.AnchorOffset.magnitude;
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001E688 File Offset: 0x0001C888
		public virtual bool Initialize()
		{
			this.mAnchorOffsetDistance = this.AnchorOffset.magnitude;
			return true;
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001E6AC File Offset: 0x0001C8AC
		public virtual bool TestActivate(CameraMotor rActiveMotor)
		{
			return this._IsEnabled && (this._ActionAlias.Length > 0 && this.RigController.InputSource != null && this.RigController.InputSource.IsJustPressed(this._ActionAlias));
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001E6F9 File Offset: 0x0001C8F9
		public virtual void Activate(CameraMotor rOldMotor)
		{
			if (this.Initialize())
			{
				this._IsActive = true;
			}
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0001E70A File Offset: 0x0001C90A
		public virtual void Deactivate(CameraMotor rNewMotor)
		{
			this._IsActive = false;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0001E713 File Offset: 0x0001C913
		public virtual void Clear()
		{
			this.Anchor = null;
			this._FadeTransformIndexes.Clear();
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0001E727 File Offset: 0x0001C927
		public virtual CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			return this.mRigTransform;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0001E730 File Offset: 0x0001C930
		public virtual void PostRigLateUpdate()
		{
			this.mAnchorOffsetDistance = Mathf.Min(this.mAnchorOffsetDistance + 1f * Time.deltaTime, this.AnchorOffset.magnitude);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0001E768 File Offset: 0x0001C968
		public virtual Vector3 GetFocusPosition(Quaternion rCameraRotation)
		{
			Transform anchor = this.Anchor;
			Vector3 vector = this.AnchorOffset;
			Vector3 anchorPosition = this.AnchorPosition;
			Vector3 vector2 = rCameraRotation.Right() * this._Offset.x + rCameraRotation.Forward() * this._Offset.z;
			if (anchor != null)
			{
				if (this.RigController.IsCollisionsEnabled && this._IsCollisionEnabled && vector.sqrMagnitude > 0f)
				{
					Vector3 vector3 = anchorPosition - anchor.position;
					Vector3 normalized = vector3.normalized;
					float magnitude = vector3.magnitude;
					float num = magnitude * 0.5f;
					RaycastHit raycastHit;
					if (RaycastExt.SafeSphereCast(anchor.position + normalized * num, normalized, this.RigController.CollisionRadius * 1.1f, out raycastHit, magnitude - num, this.RigController.CollisionLayers, this.AnchorRoot, null, true) && raycastHit.distance > 0f)
					{
						this.mAnchorOffsetDistance = raycastHit.distance + num;
					}
					vector = normalized * this.mAnchorOffsetDistance;
					vector2 = anchor.position + vector + vector2;
				}
				else
				{
					vector2 = anchor.position + (this.RigController.RotateAnchorOffset ? anchor.rotation : Quaternion.identity) * vector + vector2;
				}
				vector2 += (this.RigController.RotateAnchorOffset ? anchor.up : Vector3.up) * this._Offset.y;
				if (this.RigController.IsCollisionsEnabled && this._IsCollisionEnabled && this.Offset.sqrMagnitude > 0f)
				{
					Vector3 vector4 = vector2 - anchorPosition;
					Vector3 normalized2 = vector4.normalized;
					float magnitude2 = vector4.magnitude;
					RaycastHit raycastHit2;
					if (RaycastExt.SafeSphereCast(anchorPosition, normalized2, this.RigController.CollisionRadius * 1.1f, out raycastHit2, magnitude2, this.RigController.CollisionLayers, this.AnchorRoot, null, true))
					{
						vector2 = anchorPosition + normalized2 * raycastHit2.distance;
					}
				}
			}
			return vector2;
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0001E99C File Offset: 0x0001CB9C
		public void NormalizeEuler(ref Vector3 rEuler)
		{
			if (rEuler.x < -180f)
			{
				rEuler.x += 360f;
			}
			else if (rEuler.x > 180f)
			{
				rEuler.x -= 360f;
			}
			if (rEuler.y < -180f)
			{
				rEuler.y += 360f;
				return;
			}
			if (rEuler.y > 180f)
			{
				rEuler.y -= 360f;
			}
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0001EA28 File Offset: 0x0001CC28
		public bool IsFadeRenderer(Transform rTransform)
		{
			if (!this.IsFadingEnabled)
			{
				return false;
			}
			if (!this.SpecifyFadeRenderers)
			{
				return false;
			}
			for (int i = 0; i < this._FadeTransformIndexes.Count; i++)
			{
				int num = this._FadeTransformIndexes[i];
				if (num >= 0 && num < this.RigController.StoredTransforms.Count && this.RigController.StoredTransforms[num] == rTransform)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0001EAA0 File Offset: 0x0001CCA0
		public Transform GetFadeRenderer(int rIndex)
		{
			if (rIndex < 0 || rIndex >= this._FadeTransformIndexes.Count)
			{
				return null;
			}
			int num = this._FadeTransformIndexes[rIndex];
			if (this.RigController.StoredTransforms == null)
			{
				return null;
			}
			if (num < 0 || num >= this.RigController.StoredTransforms.Count)
			{
				return null;
			}
			return this.RigController.StoredTransforms[num];
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0001EB08 File Offset: 0x0001CD08
		public void AddFadeRenderer(Transform rTransform)
		{
			int num = -1;
			for (int i = 0; i < this.RigController.StoredTransforms.Count; i++)
			{
				if (this.RigController.StoredTransforms[i] == rTransform)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				this.RigController.StoredTransforms.Add(rTransform);
				num = this.RigController.StoredTransforms.Count - 1;
			}
			if (!this._FadeTransformIndexes.Contains(num))
			{
				this._FadeTransformIndexes.Add(num);
			}
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0001EB94 File Offset: 0x0001CD94
		public void SetFadeRenderer(int rIndex, Transform rTransform)
		{
			int num = -1;
			while (rIndex >= this._FadeTransformIndexes.Count)
			{
				this._FadeTransformIndexes.Add(-1);
			}
			for (int i = 0; i < this.RigController.StoredTransforms.Count; i++)
			{
				if (this.RigController.StoredTransforms[i] == rTransform)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				this.RigController.StoredTransforms.Add(rTransform);
				num = this.RigController.StoredTransforms.Count - 1;
			}
			this._FadeTransformIndexes[rIndex] = num;
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0001EC2C File Offset: 0x0001CE2C
		public void RemoveFadeRenderer(Transform rTransform)
		{
			int num = -1;
			for (int i = 0; i < this.RigController.StoredTransforms.Count; i++)
			{
				if (this.RigController.StoredTransforms[i] == rTransform)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				this._FadeTransformIndexes.Remove(num);
			}
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0001EC84 File Offset: 0x0001CE84
		public void RemoveFadeRenderer(int rIndex)
		{
			if (rIndex < 0 || rIndex >= this._FadeTransformIndexes.Count)
			{
				return;
			}
			this._FadeTransformIndexes.RemoveAt(rIndex);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0001ECA8 File Offset: 0x0001CEA8
		public virtual string SerializeMotor()
		{
			if (this._Type.Length == 0)
			{
				this._Type = base.GetType().AssemblyQualifiedName;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			stringBuilder.Append(", \"Type\" : \"" + this._Type + "\"");
			stringBuilder.Append(", \"Name\" : \"" + this._Name + "\"");
			stringBuilder.Append(", \"IsEnabled\" : \"" + this._IsEnabled.ToString() + "\"");
			stringBuilder.Append(", \"ActionAlias\" : \"" + this._ActionAlias.ToString() + "\"");
			stringBuilder.Append(", \"UseRigAnchor\" : \"" + this._UseRigAnchor.ToString() + "\"");
			stringBuilder.Append(", \"AnchorIndex\" : \"" + this._AnchorIndex.ToString() + "\"");
			stringBuilder.Append(", \"AnchorOffset\" : \"" + this._AnchorOffset.ToString("G8") + "\"");
			stringBuilder.Append(", \"Offset\" : \"" + this._Offset.ToString("G8") + "\"");
			stringBuilder.Append(", \"Distance\" : \"" + this.Distance.ToString("f5") + "\"");
			stringBuilder.Append(", \"MaxDistance\" : \"" + this.MaxDistance.ToString("f5") + "\"");
			stringBuilder.Append(", \"IsCollisionEnabled\" : \"" + this._IsCollisionEnabled.ToString() + "\"");
			stringBuilder.Append(", \"IsFadingEnabled\" : \"" + this._IsFadingEnabled.ToString() + "\"");
			stringBuilder.Append(", \"SpecifyFadeRenderers\" : \"" + this._SpecifyFadeRenderers.ToString() + "\"");
			stringBuilder.Append(", \"FadeTransformIndexes\" : \"" + string.Join(",", this._FadeTransformIndexes.Select((int n) => n.ToString()).ToArray<string>()) + "\"");
			PropertyInfo[] properties = typeof(CameraMotor).GetProperties();
			foreach (PropertyInfo propertyInfo in base.GetType().GetProperties())
			{
				if (propertyInfo.CanWrite)
				{
					bool flag = true;
					for (int j = 0; j < properties.Length; j++)
					{
						if (propertyInfo.Name == properties[j].Name)
						{
							flag = false;
							break;
						}
					}
					if (flag && propertyInfo.GetValue(this, null) != null)
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
						else if (propertyInfo.PropertyType == typeof(Quaternion))
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								", \"",
								propertyInfo.Name,
								"\" : \"",
								((Quaternion)value).ToString("G8"),
								"\""
							}));
						}
						else if (!(propertyInfo.PropertyType == typeof(Transform)))
						{
							if (propertyInfo.PropertyType == typeof(List<int>))
							{
								List<int> list = value as List<int>;
								StringBuilder stringBuilder2 = stringBuilder;
								string[] array = new string[5];
								array[0] = ", \"";
								array[1] = propertyInfo.Name;
								array[2] = "\" : \"";
								array[3] = string.Join(",", list.Select((int n) => n.ToString()).ToArray<string>());
								array[4] = "\"";
								stringBuilder2.Append(string.Concat(array));
							}
							else if (propertyInfo.PropertyType == typeof(AnimationCurve))
							{
								stringBuilder.Append(", \"" + propertyInfo.Name + "\" : \"");
								AnimationCurve animationCurve = value as AnimationCurve;
								for (int k = 0; k < animationCurve.keys.Length; k++)
								{
									Keyframe keyframe = animationCurve.keys[k];
									stringBuilder.Append(string.Concat(new string[]
									{
										keyframe.time.ToString("f5"),
										"|",
										keyframe.value.ToString("f5"),
										"|",
										keyframe.tangentMode.ToString(),
										"|",
										keyframe.inTangent.ToString("f5"),
										"|",
										keyframe.outTangent.ToString("f5")
									}));
									if (k < animationCurve.keys.Length - 1)
									{
										stringBuilder.Append(";");
									}
								}
								stringBuilder.Append("\"");
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
				}
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0001F364 File Offset: 0x0001D564
		public virtual void DeserializeMotor(string rDefinition)
		{
			JSONNode jsonnode = JSONNode.Parse(rDefinition);
			if (jsonnode == null)
			{
				return;
			}
			foreach (PropertyInfo propertyInfo in base.GetType().GetProperties())
			{
				if (propertyInfo.CanWrite && propertyInfo.GetValue(this, null) != null)
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
					else if (propertyInfo.PropertyType == typeof(Quaternion))
					{
						Quaternion quaternion = Quaternion.identity;
						quaternion = quaternion.FromString(jsonnode2.Value);
						propertyInfo.SetValue(this, quaternion, null);
					}
					else if (!(propertyInfo.PropertyType == typeof(Transform)))
					{
						if (propertyInfo.PropertyType == typeof(List<int>))
						{
							if (jsonnode2.Value.Length > 0)
							{
								List<int> list = (from x in jsonnode2.Value.Split(',', StringSplitOptions.None)
									select int.Parse(x)).ToList<int>();
								propertyInfo.SetValue(this, list, null);
							}
						}
						else if (propertyInfo.PropertyType == typeof(AnimationCurve) && jsonnode2.Value.Length > 0)
						{
							AnimationCurve animationCurve = new AnimationCurve();
							string[] array = jsonnode2.Value.Split(';', StringSplitOptions.None);
							for (int j = 0; j < array.Length; j++)
							{
								string[] array2 = array[j].Split('|', StringSplitOptions.None);
								if (array2.Length == 5)
								{
									int num = 0;
									float num2 = 0f;
									Keyframe keyframe = default(Keyframe);
									if (float.TryParse(array2[0], out num2))
									{
										keyframe.time = num2;
									}
									if (float.TryParse(array2[1], out num2))
									{
										keyframe.value = num2;
									}
									if (int.TryParse(array2[2], out num))
									{
										keyframe.tangentMode = num;
									}
									if (float.TryParse(array2[3], out num2))
									{
										keyframe.inTangent = num2;
									}
									if (float.TryParse(array2[4], out num2))
									{
										keyframe.outTangent = num2;
									}
									animationCurve.AddKey(keyframe);
								}
							}
							propertyInfo.SetValue(this, animationCurve, null);
						}
					}
				}
			}
			if (this._AnchorIndex >= 0)
			{
				if (this._AnchorIndex < this.RigController.StoredTransforms.Count)
				{
					this._Anchor = this.RigController.StoredTransforms[this._AnchorIndex];
					return;
				}
				this._Anchor = null;
				this._AnchorIndex = -1;
			}
		}

		// Token: 0x040002A3 RID: 675
		public string _Type = "";

		// Token: 0x040002A4 RID: 676
		public bool _IsEnabled = true;

		// Token: 0x040002A5 RID: 677
		public float _Priority;

		// Token: 0x040002A6 RID: 678
		public string _ActionAlias = "";

		// Token: 0x040002A7 RID: 679
		[NonSerialized]
		public bool _IsActive;

		// Token: 0x040002A8 RID: 680
		public bool _UseRigAnchor = true;

		// Token: 0x040002A9 RID: 681
		public int _AnchorIndex = -1;

		// Token: 0x040002AA RID: 682
		[NonSerialized]
		public Transform _Anchor;

		// Token: 0x040002AB RID: 683
		public Vector3 _AnchorOffset = Vector3.zero;

		// Token: 0x040002AC RID: 684
		public Vector3 _Offset = Vector3.zero;

		// Token: 0x040002AD RID: 685
		public bool _IsCollisionEnabled = true;

		// Token: 0x040002AE RID: 686
		public bool _IsFadingEnabled = true;

		// Token: 0x040002AF RID: 687
		public bool _SpecifyFadeRenderers;

		// Token: 0x040002B0 RID: 688
		public List<int> _FadeTransformIndexes = new List<int>();

		// Token: 0x040002B1 RID: 689
		[NonSerialized]
		public CameraController RigController;

		// Token: 0x040002B2 RID: 690
		[NonSerialized]
		protected CameraTransform mRigTransform;

		// Token: 0x040002B3 RID: 691
		protected float mAnchorOffsetDistance;
	}
}
