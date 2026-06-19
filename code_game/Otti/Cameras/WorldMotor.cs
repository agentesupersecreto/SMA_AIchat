using System;
using com.ootii.Base;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Input;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x0200007C RID: 124
	[BaseName("Top-Down View Motor")]
	[BaseDescription("Camera Motor for strategy games and MOBAs that allow for a top-down view.")]
	public class WorldMotor : YawPitchMotor
	{
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x00021F39 File Offset: 0x00020139
		// (set) Token: 0x06000600 RID: 1536 RVA: 0x00021F41 File Offset: 0x00020141
		public Vector3 MinBounds
		{
			get
			{
				return this._MinBounds;
			}
			set
			{
				this._MinBounds = value;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x00021F4A File Offset: 0x0002014A
		// (set) Token: 0x06000602 RID: 1538 RVA: 0x00021F52 File Offset: 0x00020152
		public Vector3 MaxBounds
		{
			get
			{
				return this._MaxBounds;
			}
			set
			{
				this._MaxBounds = value;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000603 RID: 1539 RVA: 0x00021F5B File Offset: 0x0002015B
		// (set) Token: 0x06000604 RID: 1540 RVA: 0x00021F63 File Offset: 0x00020163
		public bool FollowGround
		{
			get
			{
				return this._FollowGround;
			}
			set
			{
				this._FollowGround = value;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000605 RID: 1541 RVA: 0x00021F6C File Offset: 0x0002016C
		// (set) Token: 0x06000606 RID: 1542 RVA: 0x00021F74 File Offset: 0x00020174
		public float GroundDistance
		{
			get
			{
				return this._GroundDistance;
			}
			set
			{
				this._GroundDistance = value;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000607 RID: 1543 RVA: 0x00021F7D File Offset: 0x0002017D
		// (set) Token: 0x06000608 RID: 1544 RVA: 0x00021F85 File Offset: 0x00020185
		public float GroundSmoothing
		{
			get
			{
				return this._GroundSmoothing;
			}
			set
			{
				this._GroundSmoothing = Mathf.Clamp(value, 0f, 0.8f);
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x00021F9D File Offset: 0x0002019D
		// (set) Token: 0x0600060A RID: 1546 RVA: 0x00021FA5 File Offset: 0x000201A5
		public int GroundLayers
		{
			get
			{
				return this._GroundLayers;
			}
			set
			{
				this._GroundLayers = value;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x00021FAE File Offset: 0x000201AE
		// (set) Token: 0x0600060C RID: 1548 RVA: 0x00021FB6 File Offset: 0x000201B6
		public bool FollowAnchor
		{
			get
			{
				return this._FollowAnchor;
			}
			set
			{
				this._FollowAnchor = value;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x00021FBF File Offset: 0x000201BF
		// (set) Token: 0x0600060E RID: 1550 RVA: 0x00021FC7 File Offset: 0x000201C7
		public string FollowAlias
		{
			get
			{
				return this._FollowAlias;
			}
			set
			{
				this._FollowAlias = value;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x00021FD0 File Offset: 0x000201D0
		// (set) Token: 0x06000610 RID: 1552 RVA: 0x00021FD8 File Offset: 0x000201D8
		public bool FollowElevation
		{
			get
			{
				return this._FollowElevation;
			}
			set
			{
				this._FollowElevation = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x00021FE1 File Offset: 0x000201E1
		// (set) Token: 0x06000612 RID: 1554 RVA: 0x00021FE9 File Offset: 0x000201E9
		public bool FollowFromView
		{
			get
			{
				return this._FollowFromView;
			}
			set
			{
				this._FollowFromView = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x00021FF2 File Offset: 0x000201F2
		// (set) Token: 0x06000614 RID: 1556 RVA: 0x00021FFA File Offset: 0x000201FA
		public bool AllowDisconnect
		{
			get
			{
				return this._AllowDisconnect;
			}
			set
			{
				this._AllowDisconnect = value;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x00022003 File Offset: 0x00020203
		// (set) Token: 0x06000616 RID: 1558 RVA: 0x0002200B File Offset: 0x0002020B
		public bool GripPan
		{
			get
			{
				return this._GripPan;
			}
			set
			{
				this._GripPan = value;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000617 RID: 1559 RVA: 0x00022014 File Offset: 0x00020214
		// (set) Token: 0x06000618 RID: 1560 RVA: 0x0002201C File Offset: 0x0002021C
		public string GripAlias
		{
			get
			{
				return this._GripAlias;
			}
			set
			{
				this._GripAlias = value;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x00022025 File Offset: 0x00020225
		// (set) Token: 0x0600061A RID: 1562 RVA: 0x0002202D File Offset: 0x0002022D
		public float GripPanSpeed
		{
			get
			{
				return this._GripPanSpeed;
			}
			set
			{
				this._GripPanSpeed = value;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x00022036 File Offset: 0x00020236
		// (set) Token: 0x0600061C RID: 1564 RVA: 0x0002203E File Offset: 0x0002023E
		public bool EdgePan
		{
			get
			{
				return this._EdgePan;
			}
			set
			{
				this._EdgePan = value;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x00022047 File Offset: 0x00020247
		// (set) Token: 0x0600061E RID: 1566 RVA: 0x0002204F File Offset: 0x0002024F
		public float EdgePanBorder
		{
			get
			{
				return this._EdgePanBorder;
			}
			set
			{
				this._EdgePanBorder = value;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x00022058 File Offset: 0x00020258
		// (set) Token: 0x06000620 RID: 1568 RVA: 0x00022060 File Offset: 0x00020260
		public float EdgePanSpeed
		{
			get
			{
				return this._EdgePanSpeed;
			}
			set
			{
				this._EdgePanSpeed = value;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x00022069 File Offset: 0x00020269
		// (set) Token: 0x06000622 RID: 1570 RVA: 0x00022071 File Offset: 0x00020271
		public bool InputPan
		{
			get
			{
				return this._InputPan;
			}
			set
			{
				this._InputPan = value;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x0002207A File Offset: 0x0002027A
		// (set) Token: 0x06000624 RID: 1572 RVA: 0x00022082 File Offset: 0x00020282
		public bool UseViewInput
		{
			get
			{
				return this._UseViewInput;
			}
			set
			{
				this._UseViewInput = value;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x0002208B File Offset: 0x0002028B
		// (set) Token: 0x06000626 RID: 1574 RVA: 0x00022093 File Offset: 0x00020293
		public string ForwardAlias
		{
			get
			{
				return this._ForwardAlias;
			}
			set
			{
				this._ForwardAlias = value;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x0002209C File Offset: 0x0002029C
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x000220A4 File Offset: 0x000202A4
		public string BackAlias
		{
			get
			{
				return this._BackAlias;
			}
			set
			{
				this._BackAlias = value;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x000220AD File Offset: 0x000202AD
		// (set) Token: 0x0600062A RID: 1578 RVA: 0x000220B5 File Offset: 0x000202B5
		public string LeftAlias
		{
			get
			{
				return this._LeftAlias;
			}
			set
			{
				this._LeftAlias = value;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x000220BE File Offset: 0x000202BE
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x000220C6 File Offset: 0x000202C6
		public string RightAlias
		{
			get
			{
				return this._RightAlias;
			}
			set
			{
				this._RightAlias = value;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x000220CF File Offset: 0x000202CF
		// (set) Token: 0x0600062E RID: 1582 RVA: 0x000220D7 File Offset: 0x000202D7
		public float InputPanSpeed
		{
			get
			{
				return this._InputPanSpeed;
			}
			set
			{
				this._InputPanSpeed = value;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x000220E0 File Offset: 0x000202E0
		// (set) Token: 0x06000630 RID: 1584 RVA: 0x000220E8 File Offset: 0x000202E8
		public bool IsFollowConnected
		{
			get
			{
				return this.mIsFollowConnected;
			}
			set
			{
				this.mIsFollowConnected = value;
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x000220F4 File Offset: 0x000202F4
		public WorldMotor()
		{
			this._MaxDistance = 8f;
			this.mDistance = 8f;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00022218 File Offset: 0x00020418
		public override bool Initialize()
		{
			base.Initialize();
			this.mGripUnitsPerTick = this._GripPanSpeed * Time.deltaTime;
			this.mEdgeUnitsPerTick = this._EdgePanSpeed * Time.deltaTime;
			this.mInputUnitsPerTick = this._InputPanSpeed * Time.deltaTime;
			this.mRigTransform.Position = this.RigController.Transform.position;
			this.mRigTransform.Rotation = this.RigController.Transform.rotation;
			this.mPositionTarget = this.mRigTransform.Position;
			if (this._MaxDistance == 0f)
			{
				this.MaxDistance = this.RigController._Transform.position.y - this.AnchorPosition.y;
			}
			if (this._GroundDistance == 0f)
			{
				this.GroundDistance = this.GetGroundDistance();
			}
			return true;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x000222F8 File Offset: 0x000204F8
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			bool flag = true;
			bool flag2 = true;
			Vector3 vector = Vector3.zero;
			IInputSource inputSource = this.RigController.InputSource;
			Quaternion quaternion = Quaternion.Euler(0f, this.RigController._Transform.rotation.eulerAngles.y, 0f);
			if (this._FollowAnchor && this.Anchor != null && vector.sqrMagnitude == 0f)
			{
				if (!this._AllowDisconnect)
				{
					this.mIsFollowConnected = true;
				}
				else if (this._FollowAlias.Length == 0)
				{
					this.mIsFollowConnected = true;
				}
				else if (this._FollowAlias.Length > 0 && inputSource != null && inputSource.IsPressed(this._FollowAlias))
				{
					this.mIsFollowConnected = true;
				}
				if (this.mIsFollowConnected)
				{
					flag = false;
					flag2 = false;
					Vector3 anchorPosition = this.AnchorPosition;
					if (this._FollowFromView)
					{
						Vector3 vector2 = this.mPositionTarget;
						this.mPositionTarget = anchorPosition - this.RigController._Transform.forward * this._MaxDistance;
						if (!this._FollowElevation)
						{
							this.mPositionTarget.y = vector2.y;
						}
					}
					else
					{
						vector.x = anchorPosition.x - this.RigController._Transform.position.x;
						vector.y = (this._FollowElevation ? (anchorPosition.y - this.RigController._Transform.position.y) : 0f);
						vector.z = anchorPosition.z - this.RigController._Transform.position.z;
					}
				}
			}
			else
			{
				this.mIsFollowConnected = false;
				this.mPositionTarget = this.RigController._Transform.position;
			}
			if (this._GripPan && inputSource != null && vector.sqrMagnitude == 0f && (this._GripAlias.Length == 0 || inputSource.IsPressed(this._GripAlias)) && (inputSource.ViewX != 0f || inputSource.ViewY != 0f))
			{
				this.mIsFollowConnected = false;
				if (flag2)
				{
					flag2 = false;
					vector.x = inputSource.ViewX * -this.mGripUnitsPerTick;
					vector.z = inputSource.ViewY * -this.mGripUnitsPerTick;
					vector = quaternion * vector;
				}
			}
			if (this._InputPan && inputSource != null && vector.sqrMagnitude == 0f)
			{
				float num = ((this._ForwardAlias.Length > 0 && inputSource.IsPressed(this._ForwardAlias)) ? 1f : 0f);
				num -= ((this._BackAlias.Length > 0 && inputSource.IsPressed(this._BackAlias)) ? 1f : 0f);
				float num2 = ((this._RightAlias.Length > 0 && inputSource.IsPressed(this._RightAlias)) ? 1f : 0f);
				num2 -= ((this._LeftAlias.Length > 0 && inputSource.IsPressed(this._LeftAlias)) ? 1f : 0f);
				if (num2 != 0f || num != 0f)
				{
					this.mIsFollowConnected = false;
					if (flag2)
					{
						float num3 = 1f;
						InputManagerHelper.ConvertToRadialInput(ref num2, ref num, ref num3, 1f);
						flag2 = false;
						vector.x = num2;
						vector.z = num;
						vector = quaternion * vector * this.mInputUnitsPerTick;
					}
				}
			}
			if (this._EdgePan && vector.sqrMagnitude == 0f)
			{
				Vector3 zero = Vector3.zero;
				float num4 = (float)Screen.width;
				float num5 = (float)Screen.height;
				Vector3 mousePosition = Input.mousePosition;
				mousePosition.x = Mathf.Clamp(mousePosition.x, 0f, num4 - 1f);
				mousePosition.y = Mathf.Clamp(mousePosition.y, 0f, num5 - 1f);
				float num6 = ((this._EdgePanBorder > 1f) ? this._EdgePanBorder : 1f);
				if (mousePosition.x < num6)
				{
					float num7 = (num6 - mousePosition.x) / num6;
					zero.x = -this.mEdgeUnitsPerTick * num7;
				}
				else if (mousePosition.x >= num4 - this._EdgePanBorder)
				{
					float num8 = (num6 - (num4 - 1f - mousePosition.x)) / num6;
					zero.x = this.mEdgeUnitsPerTick * num8;
				}
				if (mousePosition.y < this._EdgePanBorder)
				{
					float num9 = (num6 - mousePosition.y) / num6;
					zero.z = -this.mEdgeUnitsPerTick * num9;
				}
				else if (mousePosition.y >= num5 - this._EdgePanBorder)
				{
					float num10 = (num6 - (num5 - 1f - mousePosition.y)) / num6;
					zero.z = this.mEdgeUnitsPerTick * num10;
				}
				if (zero.sqrMagnitude > 0f)
				{
					this.mIsFollowConnected = false;
					if (flag2)
					{
						vector.x = zero.x;
						vector.z = zero.z;
						vector = quaternion * vector;
					}
				}
			}
			this.mPositionTarget += vector;
			if (!this.mIsFollowConnected || !this._FollowElevation)
			{
				Vector3 groundTarget = this.GetGroundTarget();
				if (groundTarget != Vector3Ext.Null)
				{
					this.mPositionTarget.y = base.SmoothDamp(this.mPositionTarget.y, groundTarget.y + this._GroundDistance, this._GroundSmoothing, rDeltaTime);
				}
			}
			if (this._MinBounds.x != 0f || this._MaxBounds.x != 0f)
			{
				this.mPositionTarget.x = Mathf.Clamp(this.mPositionTarget.x, this._MinBounds.x, this._MaxBounds.x);
			}
			if (this._MinBounds.y != 0f || this._MaxBounds.y != 0f)
			{
				this.mPositionTarget.y = Mathf.Clamp(this.mPositionTarget.y, this._MinBounds.y, this._MaxBounds.y);
			}
			if (this._MinBounds.z != 0f || this._MaxBounds.z != 0f)
			{
				this.mPositionTarget.z = Mathf.Clamp(this.mPositionTarget.z, this._MinBounds.z, this._MaxBounds.z);
			}
			vector = ((!flag) ? this.mPositionTarget : Vector3.SmoothDamp(this.RigController._Transform.position, this.mPositionTarget, ref this.mPositionVelocity, rDeltaTime)) - this.RigController._Transform.position;
			this.mRigTransform.Position = this.RigController._Transform.position + vector;
			this.mRigTransform.Rotation = this.RigController._Transform.rotation;
			return this.mRigTransform;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00022A24 File Offset: 0x00020C24
		public override void PostRigLateUpdate()
		{
			if (this.Anchor != null)
			{
				this.mAnchorLastPosition = this.Anchor.position;
				this.mAnchorLastRotation = this.Anchor.rotation;
			}
			if (Vector3.Distance(this.mPositionTarget, this.mRigTransform.Position) < 0.0001f)
			{
				this.mPositionTarget = this.mRigTransform.Position;
				this.mPositionVelocity.x = 0f;
				this.mPositionVelocity.y = 0f;
				this.mPositionVelocity.z = 0f;
			}
			this.mAnchorOffsetDistance = Mathf.Min(this.mAnchorOffsetDistance + 1f * Time.deltaTime, this.AnchorOffset.magnitude);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00022AEC File Offset: 0x00020CEC
		public Vector3 GetGroundTarget()
		{
			Vector3 position = this.RigController._Transform.position;
			float num = ((this._GroundDistance > 0f) ? (this._GroundDistance * 20f) : 100f);
			RaycastHit raycastHit;
			if (RaycastExt.SafeRaycast(position, Vector3.down, out raycastHit, num, this._GroundLayers, this._Anchor, null, true, false))
			{
				return raycastHit.point;
			}
			return Vector3Ext.Null;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00022B58 File Offset: 0x00020D58
		public float GetGroundDistance()
		{
			Vector3 position = this.RigController._Transform.position;
			float num = ((this._GroundDistance > 0f) ? (this._GroundDistance * 20f) : 100f);
			RaycastHit raycastHit;
			if (RaycastExt.SafeRaycast(position, Vector3.down, out raycastHit, num, this._GroundLayers, this._Anchor, null, true, false))
			{
				return raycastHit.distance;
			}
			return 0f;
		}

		// Token: 0x040002EF RID: 751
		public Vector3 _MinBounds = new Vector3(-100f, -100f, -100f);

		// Token: 0x040002F0 RID: 752
		public Vector3 _MaxBounds = new Vector3(100f, 100f, 100f);

		// Token: 0x040002F1 RID: 753
		public bool _FollowGround;

		// Token: 0x040002F2 RID: 754
		public float _GroundDistance;

		// Token: 0x040002F3 RID: 755
		public float _GroundSmoothing = 0.05f;

		// Token: 0x040002F4 RID: 756
		public int _GroundLayers = 1;

		// Token: 0x040002F5 RID: 757
		public bool _FollowAnchor;

		// Token: 0x040002F6 RID: 758
		public string _FollowAlias = "Camera Follow";

		// Token: 0x040002F7 RID: 759
		public bool _FollowElevation = true;

		// Token: 0x040002F8 RID: 760
		public bool _FollowFromView = true;

		// Token: 0x040002F9 RID: 761
		public bool _AllowDisconnect = true;

		// Token: 0x040002FA RID: 762
		public bool _GripPan = true;

		// Token: 0x040002FB RID: 763
		public string _GripAlias = "Camera Grip";

		// Token: 0x040002FC RID: 764
		public float _GripPanSpeed = 50f;

		// Token: 0x040002FD RID: 765
		public bool _EdgePan = true;

		// Token: 0x040002FE RID: 766
		public float _EdgePanBorder = 20f;

		// Token: 0x040002FF RID: 767
		public float _EdgePanSpeed = 10f;

		// Token: 0x04000300 RID: 768
		public bool _InputPan = true;

		// Token: 0x04000301 RID: 769
		public bool _UseViewInput;

		// Token: 0x04000302 RID: 770
		public string _ForwardAlias = "Camera Forward";

		// Token: 0x04000303 RID: 771
		public string _BackAlias = "Camera Back";

		// Token: 0x04000304 RID: 772
		public string _LeftAlias = "Camera Left";

		// Token: 0x04000305 RID: 773
		public string _RightAlias = "Camera Right";

		// Token: 0x04000306 RID: 774
		public float _InputPanSpeed = 10f;

		// Token: 0x04000307 RID: 775
		protected bool mIsFollowConnected = true;

		// Token: 0x04000308 RID: 776
		public float mGripUnitsPerTick;

		// Token: 0x04000309 RID: 777
		public float mEdgeUnitsPerTick;

		// Token: 0x0400030A RID: 778
		public float mInputUnitsPerTick;

		// Token: 0x0400030B RID: 779
		protected Vector3 mPositionTarget = Vector3.zero;

		// Token: 0x0400030C RID: 780
		protected Vector3 mPositionVelocity = Vector3.zero;
	}
}
