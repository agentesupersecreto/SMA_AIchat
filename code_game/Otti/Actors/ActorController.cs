using System;
using System.Collections.Generic;
using System.Linq;
using com.ootii.Geometry;
using com.ootii.Graphics;
using com.ootii.Helpers;
using com.ootii.Physics;
using com.ootii.Utilities;
using com.ootii.Utilities.Debug;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x02000089 RID: 137
	[AddComponentMenu("ootii/Actor Controller")]
	[Serializable]
	public class ActorController : BaseSystemController, ICharacterController
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000703 RID: 1795 RVA: 0x00025908 File Offset: 0x00023B08
		// (remove) Token: 0x06000704 RID: 1796 RVA: 0x00025940 File Offset: 0x00023B40
		public event Action<ActorController> stared;

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00025975 File Offset: 0x00023B75
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x00025980 File Offset: 0x00023B80
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
				if (this._IsEnabled)
				{
					RaycastHit raycastHit;
					this.ProcessGrounding(this._Transform.position, Vector3.zero, this._Transform.up, this._Transform.up, this._BaseRadius, out raycastHit);
					this.mState.PrevGround = this.mState.Ground;
					this.mState.Position = this._Transform.position;
					this.mState.Rotation = this._Transform.rotation;
					this.mPrevState.Ground = this.mState.Ground;
					this.mPrevState.Position = this._Transform.position;
					this.mPrevState.Rotation = this._Transform.rotation;
				}
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00025A58 File Offset: 0x00023C58
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x00025A60 File Offset: 0x00023C60
		public bool UseTransformPosition
		{
			get
			{
				return this._UseTransformPosition;
			}
			set
			{
				this._UseTransformPosition = value;
				if (!this._UseTransformPosition)
				{
					this._Transform.rotation.DecomposeSwingTwist(this._Transform.up, ref this.mTilt, ref this.mYaw);
				}
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00025A98 File Offset: 0x00023C98
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x00025AA0 File Offset: 0x00023CA0
		public bool UseTransformRotation
		{
			get
			{
				return this._UseTransformRotation;
			}
			set
			{
				this._UseTransformRotation = value;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00025AA9 File Offset: 0x00023CA9
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x00025AB1 File Offset: 0x00023CB1
		public bool ProcessInLateUpdate
		{
			get
			{
				return this._ProcessInLateUpdate;
			}
			set
			{
				this._ProcessInLateUpdate = value;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00025ABA File Offset: 0x00023CBA
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00025AC4 File Offset: 0x00023CC4
		public int StateCount
		{
			get
			{
				return this._StateCount;
			}
			set
			{
				if (value <= 0)
				{
					return;
				}
				if (value == this._StateCount)
				{
					return;
				}
				this._StateCount = value;
				if (this.mStateIndex >= this._StateCount)
				{
					this.mStateIndex = this._StateCount - 1;
				}
				if (this.mStates != null)
				{
					Array.Resize<ActorState>(ref this.mStates, this._StateCount);
				}
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00025B1C File Offset: 0x00023D1C
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00025B24 File Offset: 0x00023D24
		public bool InvertRotationOrder
		{
			get
			{
				return this._InvertRotationOrder;
			}
			set
			{
				this._InvertRotationOrder = value;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00025B2D File Offset: 0x00023D2D
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x00025B35 File Offset: 0x00023D35
		public bool ExtrapolatePhysics
		{
			get
			{
				return this._ExtrapolatePhysics;
			}
			set
			{
				this._ExtrapolatePhysics = value;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x00025B3E File Offset: 0x00023D3E
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x00025B46 File Offset: 0x00023D46
		public bool IsGravityEnabled
		{
			get
			{
				return this._IsGravityEnabled;
			}
			set
			{
				this._IsGravityEnabled = value;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00025B4F File Offset: 0x00023D4F
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00025B57 File Offset: 0x00023D57
		public bool IsGravityRelative
		{
			get
			{
				return this._IsGravityRelative;
			}
			set
			{
				this._IsGravityRelative = value;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00025B60 File Offset: 0x00023D60
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x00025B68 File Offset: 0x00023D68
		public Vector3 Gravity
		{
			get
			{
				return this._Gravity;
			}
			set
			{
				this._Gravity = value;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00025B71 File Offset: 0x00023D71
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x00025B79 File Offset: 0x00023D79
		public bool ApplyGravityInFixedUpdate
		{
			get
			{
				return this._ApplyGravityInFixedUpdate;
			}
			set
			{
				this._ApplyGravityInFixedUpdate = value;
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00025B84 File Offset: 0x00023D84
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x00025CEA File Offset: 0x00023EEA
		public float Height
		{
			get
			{
				if (this._Height <= 0f)
				{
					for (int i = 0; i < this.BodyShapes.Count; i++)
					{
						BodyShape bodyShape = this.BodyShapes[i];
						Transform transform = ((bodyShape._Transform != null) ? bodyShape._Transform : bodyShape._Parent);
						float num = Vector3.Distance(transform.position + transform.rotation * bodyShape._Offset + bodyShape._Parent.up * bodyShape.Radius, this._Transform.position);
						if (this.BodyShapes[i] is BodyCapsule)
						{
							BodyCapsule bodyCapsule = this.BodyShapes[i] as BodyCapsule;
							Transform transform2 = ((bodyCapsule._EndTransform != null) ? bodyCapsule._EndTransform : bodyCapsule._Parent);
							num = Mathf.Max(Vector3.Distance(transform2.position + transform2.rotation * bodyCapsule._EndOffset + bodyCapsule._Parent.up * bodyCapsule.Radius, this._Transform.position), num);
						}
						this._Height = Mathf.Max(num, this._Height);
					}
				}
				return this._Height;
			}
			set
			{
				this._Height = value;
				this.mCenter.y = this._Height * 0.5f;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00025D0A File Offset: 0x00023F0A
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x00025D12 File Offset: 0x00023F12
		public float Radius
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

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x00025D1B File Offset: 0x00023F1B
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x00025D23 File Offset: 0x00023F23
		public float Mass
		{
			get
			{
				return this._Mass;
			}
			set
			{
				this._Mass = value;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x00025D2C File Offset: 0x00023F2C
		public Vector3 Center
		{
			get
			{
				return this.mCenter;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x00025D34 File Offset: 0x00023F34
		// (set) Token: 0x06000723 RID: 1827 RVA: 0x00025D3C File Offset: 0x00023F3C
		public float SkinWidth
		{
			get
			{
				return this._SkinWidth;
			}
			set
			{
				this._SkinWidth = value;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x00025D45 File Offset: 0x00023F45
		// (set) Token: 0x06000725 RID: 1829 RVA: 0x00025D4D File Offset: 0x00023F4D
		public float AltSkinWidth
		{
			get
			{
				return this._AltSkinWidth;
			}
			set
			{
				this._AltSkinWidth = value;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x00025D56 File Offset: 0x00023F56
		// (set) Token: 0x06000727 RID: 1831 RVA: 0x00025D5E File Offset: 0x00023F5E
		public float GroundingStartOffset
		{
			get
			{
				return this._GroundingStartOffset;
			}
			set
			{
				this._GroundingStartOffset = value;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00025D67 File Offset: 0x00023F67
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x00025D6F File Offset: 0x00023F6F
		public float GroundingDistance
		{
			get
			{
				return this._GroundingDistance;
			}
			set
			{
				this._GroundingDistance = value;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00025D78 File Offset: 0x00023F78
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x00025D80 File Offset: 0x00023F80
		public bool IsGroundingLayersEnabled
		{
			get
			{
				return this._IsGroundingLayersEnabled;
			}
			set
			{
				this._IsGroundingLayersEnabled = value;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x00025D89 File Offset: 0x00023F89
		// (set) Token: 0x0600072D RID: 1837 RVA: 0x00025D91 File Offset: 0x00023F91
		public int GroundingLayers
		{
			get
			{
				return this._GroundingLayers;
			}
			set
			{
				this._GroundingLayers = value;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x00025D9A File Offset: 0x00023F9A
		// (set) Token: 0x0600072F RID: 1839 RVA: 0x00025DA2 File Offset: 0x00023FA2
		public float GroundDampenFactor
		{
			get
			{
				return this._GroundDampenFactor;
			}
			set
			{
				this._GroundDampenFactor = value;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x00025DAB File Offset: 0x00023FAB
		// (set) Token: 0x06000731 RID: 1841 RVA: 0x00025DB3 File Offset: 0x00023FB3
		public float BaseRadius
		{
			get
			{
				return this._BaseRadius;
			}
			set
			{
				this._BaseRadius = value;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x00025DBC File Offset: 0x00023FBC
		// (set) Token: 0x06000733 RID: 1843 RVA: 0x00025DC4 File Offset: 0x00023FC4
		public bool FixGroundPenetration
		{
			get
			{
				return this._FixGroundPenetration;
			}
			set
			{
				this._FixGroundPenetration = value;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x00025DCD File Offset: 0x00023FCD
		// (set) Token: 0x06000735 RID: 1845 RVA: 0x00025DD5 File Offset: 0x00023FD5
		public bool ForceGrounding
		{
			get
			{
				return this._ForceGrounding;
			}
			set
			{
				this._ForceGrounding = value;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x00025DDE File Offset: 0x00023FDE
		// (set) Token: 0x06000737 RID: 1847 RVA: 0x00025DE6 File Offset: 0x00023FE6
		public float ForceGroundingDistance
		{
			get
			{
				return this._ForceGroundingDistance;
			}
			set
			{
				this._ForceGroundingDistance = value;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x00025DEF File Offset: 0x00023FEF
		// (set) Token: 0x06000739 RID: 1849 RVA: 0x00025DF7 File Offset: 0x00023FF7
		public bool IsCollsionEnabled
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

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x00025E00 File Offset: 0x00024000
		// (set) Token: 0x0600073B RID: 1851 RVA: 0x00025E08 File Offset: 0x00024008
		public bool StopOnRotationCollision
		{
			get
			{
				return this._StopOnRotationCollision;
			}
			set
			{
				this._StopOnRotationCollision = value;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x00025E11 File Offset: 0x00024011
		// (set) Token: 0x0600073D RID: 1853 RVA: 0x00025E19 File Offset: 0x00024019
		public bool AllowPushback
		{
			get
			{
				return this._AllowPushback;
			}
			set
			{
				this._AllowPushback = value;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x00025E22 File Offset: 0x00024022
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x00025E2A File Offset: 0x0002402A
		public int CollisionLayers
		{
			get
			{
				return this._CollisionLayers;
			}
			set
			{
				this._CollisionLayers = value;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x00025E33 File Offset: 0x00024033
		// (set) Token: 0x06000741 RID: 1857 RVA: 0x00025E3B File Offset: 0x0002403B
		public float OverlapRadius
		{
			get
			{
				return this._OverlapRadius;
			}
			set
			{
				this._OverlapRadius = value;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x00025E44 File Offset: 0x00024044
		// (set) Token: 0x06000743 RID: 1859 RVA: 0x00025E4C File Offset: 0x0002404C
		public Vector3 OverlapCenter
		{
			get
			{
				return this._OverlapCenter;
			}
			set
			{
				this._OverlapCenter = value;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x00025E55 File Offset: 0x00024055
		// (set) Token: 0x06000745 RID: 1861 RVA: 0x00025E5D File Offset: 0x0002405D
		public bool IsSlidingEnabled
		{
			get
			{
				return this._IsSlidingEnabled;
			}
			set
			{
				this._IsSlidingEnabled = value;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x00025E66 File Offset: 0x00024066
		// (set) Token: 0x06000747 RID: 1863 RVA: 0x00025E6E File Offset: 0x0002406E
		public float MinSlopeAngle
		{
			get
			{
				return this._MinSlopeAngle;
			}
			set
			{
				this._MinSlopeAngle = value;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x00025E77 File Offset: 0x00024077
		// (set) Token: 0x06000749 RID: 1865 RVA: 0x00025E7F File Offset: 0x0002407F
		public float MinSlopeGravityCoefficient
		{
			get
			{
				return this._MinSlopeGravityCoefficient;
			}
			set
			{
				this._MinSlopeGravityCoefficient = value;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x00025E88 File Offset: 0x00024088
		// (set) Token: 0x0600074B RID: 1867 RVA: 0x00025E90 File Offset: 0x00024090
		public float MaxSlopeAngle
		{
			get
			{
				return this._MaxSlopeAngle;
			}
			set
			{
				this._MaxSlopeAngle = value;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x00025E99 File Offset: 0x00024099
		// (set) Token: 0x0600074D RID: 1869 RVA: 0x00025EA1 File Offset: 0x000240A1
		public bool UseStepHeightWithMaxSlope
		{
			get
			{
				return this._UseStepHeightWithMaxSlope;
			}
			set
			{
				this._UseStepHeightWithMaxSlope = value;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x00025EAA File Offset: 0x000240AA
		// (set) Token: 0x0600074F RID: 1871 RVA: 0x00025EB2 File Offset: 0x000240B2
		public float SlopeMovementStep
		{
			get
			{
				return this._SlopeMovementStep;
			}
			set
			{
				this._SlopeMovementStep = value;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x00025EBB File Offset: 0x000240BB
		// (set) Token: 0x06000751 RID: 1873 RVA: 0x00025EC4 File Offset: 0x000240C4
		public bool OrientToGround
		{
			get
			{
				return this._OrientToGround;
			}
			set
			{
				this._OrientToGround = value;
				if (this._OrientToGround)
				{
					this.mOrientToGroundNormal = this._Transform.up;
					this._Transform.rotation.DecomposeSwingTwist(Vector3.up, ref this.mTilt, ref this.mYaw);
					return;
				}
				this.mState.IsTilting = true;
				if (this._Transform.up == Vector3.up)
				{
					this.mYaw = this._Transform.rotation;
					this.mTilt = Quaternion.identity;
				}
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x00025F52 File Offset: 0x00024152
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x00025F5A File Offset: 0x0002415A
		public bool KeepOrientationInAir
		{
			get
			{
				return this._KeepOrientationInAir;
			}
			set
			{
				this._KeepOrientationInAir = value;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x00025F63 File Offset: 0x00024163
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x00025F6B File Offset: 0x0002416B
		public float OrientToGroundDistance
		{
			get
			{
				return this._OrientToGroundDistance;
			}
			set
			{
				this._OrientToGroundDistance = value;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x00025F74 File Offset: 0x00024174
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x00025F7C File Offset: 0x0002417C
		public float OrientToGroundSpeed
		{
			get
			{
				return this._OrientToGroundSpeed;
			}
			set
			{
				this._OrientToGroundSpeed = value;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x00025F85 File Offset: 0x00024185
		// (set) Token: 0x06000759 RID: 1881 RVA: 0x00025F8D File Offset: 0x0002418D
		public float MinOrientToGroundAngleForSpeed
		{
			get
			{
				return this._MinOrientToGroundAngleForSpeed;
			}
			set
			{
				this._MinOrientToGroundAngleForSpeed = value;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x00025F96 File Offset: 0x00024196
		// (set) Token: 0x0600075B RID: 1883 RVA: 0x00025F9E File Offset: 0x0002419E
		public float MaxStepHeight
		{
			get
			{
				return this._MaxStepHeight;
			}
			set
			{
				this._MaxStepHeight = value;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x00025FA7 File Offset: 0x000241A7
		// (set) Token: 0x0600075D RID: 1885 RVA: 0x00025FAF File Offset: 0x000241AF
		public float MinStepDepth
		{
			get
			{
				return this._MinStepDepth;
			}
			set
			{
				this._MinStepDepth = value;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x00025FB8 File Offset: 0x000241B8
		// (set) Token: 0x0600075F RID: 1887 RVA: 0x00025FC0 File Offset: 0x000241C0
		public float StepUpSpeed
		{
			get
			{
				return this._StepUpSpeed;
			}
			set
			{
				this._StepUpSpeed = value;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x00025FC9 File Offset: 0x000241C9
		// (set) Token: 0x06000761 RID: 1889 RVA: 0x00025FD1 File Offset: 0x000241D1
		public float MaxStepUpAngle
		{
			get
			{
				return this._MaxStepUpAngle;
			}
			set
			{
				this._MaxStepUpAngle = value;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x00025FDA File Offset: 0x000241DA
		// (set) Token: 0x06000763 RID: 1891 RVA: 0x00025FE2 File Offset: 0x000241E2
		public float StepDownSpeed
		{
			get
			{
				return this._StepDownSpeed;
			}
			set
			{
				this._StepDownSpeed = value;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x00025FEB File Offset: 0x000241EB
		// (set) Token: 0x06000765 RID: 1893 RVA: 0x00025FF3 File Offset: 0x000241F3
		public bool FreezePositionX
		{
			get
			{
				return this._FreezePositionX;
			}
			set
			{
				this._FreezePositionX = value;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x00025FFC File Offset: 0x000241FC
		// (set) Token: 0x06000767 RID: 1895 RVA: 0x00026004 File Offset: 0x00024204
		public bool FreezePositionY
		{
			get
			{
				return this._FreezePositionY;
			}
			set
			{
				this._FreezePositionY = value;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x0002600D File Offset: 0x0002420D
		// (set) Token: 0x06000769 RID: 1897 RVA: 0x00026015 File Offset: 0x00024215
		public bool FreezePositionZ
		{
			get
			{
				return this._FreezePositionZ;
			}
			set
			{
				this._FreezePositionZ = value;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x0002601E File Offset: 0x0002421E
		// (set) Token: 0x0600076B RID: 1899 RVA: 0x00026026 File Offset: 0x00024226
		public bool FreezeRotationX
		{
			get
			{
				return this._FreezeRotationX;
			}
			set
			{
				this._FreezeRotationX = value;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0002602F File Offset: 0x0002422F
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x00026037 File Offset: 0x00024237
		public bool FreezeRotationY
		{
			get
			{
				return this._FreezeRotationY;
			}
			set
			{
				this._FreezeRotationY = value;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x00026040 File Offset: 0x00024240
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x00026048 File Offset: 0x00024248
		public bool FreezeRotationZ
		{
			get
			{
				return this._FreezeRotationZ;
			}
			set
			{
				this._FreezeRotationZ = value;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x00026051 File Offset: 0x00024251
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x00026059 File Offset: 0x00024259
		public bool OverrideProcessing
		{
			get
			{
				return this.mOverrideProcessing;
			}
			set
			{
				this.mOverrideProcessing = value;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x00026062 File Offset: 0x00024262
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x0002606A File Offset: 0x0002426A
		public bool ShowDebug
		{
			get
			{
				return this._ShowDebug;
			}
			set
			{
				this._ShowDebug = value;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x00026073 File Offset: 0x00024273
		public bool IsGrounded
		{
			get
			{
				return this.mState.IsGrounded;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x00026080 File Offset: 0x00024280
		public float GroundedDuration
		{
			get
			{
				return this.mGroundedDuration;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x00026088 File Offset: 0x00024288
		public float FallDuration
		{
			get
			{
				return this.mFallDuration;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x00026090 File Offset: 0x00024290
		public Quaternion Rotation
		{
			get
			{
				return this._Transform.rotation;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0002609D File Offset: 0x0002429D
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x000260A5 File Offset: 0x000242A5
		public Quaternion Yaw
		{
			get
			{
				return this.mYaw;
			}
			set
			{
				this.mYaw = value;
				this._Transform.rotation = (this._InvertRotationOrder ? (this.mYaw * this.mTilt) : (this.mTilt * this.mYaw));
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x000260E5 File Offset: 0x000242E5
		// (set) Token: 0x0600077B RID: 1915 RVA: 0x000260ED File Offset: 0x000242ED
		public Quaternion Tilt
		{
			get
			{
				return this.mTilt;
			}
			set
			{
				this.mTilt = value;
				this._Transform.rotation = (this._InvertRotationOrder ? (this.mYaw * this.mTilt) : (this.mTilt * this.mYaw));
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x0002612D File Offset: 0x0002432D
		public Vector3 Position
		{
			get
			{
				return this._Transform.position;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x0002613A File Offset: 0x0002433A
		public Vector3 Velocity
		{
			get
			{
				return this.mState.Velocity;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x00026147 File Offset: 0x00024347
		public bool PrevIsGrounded
		{
			get
			{
				return this.mPrevState.IsGrounded;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00026154 File Offset: 0x00024354
		public Vector3 PrevPosition
		{
			get
			{
				return this.mPrevState.Position;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x00026161 File Offset: 0x00024361
		public Vector3 PrevVelocity
		{
			get
			{
				return this.mPrevState.Velocity;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x0002616E File Offset: 0x0002436E
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x00026176 File Offset: 0x00024376
		public ActorState State
		{
			get
			{
				return this.mState;
			}
			set
			{
				this.mState = value;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x0002617F File Offset: 0x0002437F
		// (set) Token: 0x06000784 RID: 1924 RVA: 0x00026187 File Offset: 0x00024387
		public ActorState PrevState
		{
			get
			{
				return this.mPrevState;
			}
			set
			{
				this.mPrevState = value;
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x00026190 File Offset: 0x00024390
		// (set) Token: 0x06000786 RID: 1926 RVA: 0x00026198 File Offset: 0x00024398
		public Vector3 AccumulatedVelocity
		{
			get
			{
				return this.mAccumulatedVelocity;
			}
			set
			{
				this.mAccumulatedVelocity = value;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x000261A1 File Offset: 0x000243A1
		// (set) Token: 0x06000788 RID: 1928 RVA: 0x000261A9 File Offset: 0x000243A9
		public List<Force> AppliedForces
		{
			get
			{
				return this.mAppliedForces;
			}
			set
			{
				this.mAppliedForces = value;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x000261B2 File Offset: 0x000243B2
		// (set) Token: 0x0600078A RID: 1930 RVA: 0x000261BA File Offset: 0x000243BA
		public bool IgnoreUseTransform
		{
			get
			{
				return this.mIgnoreUseTransform;
			}
			set
			{
				this.mIgnoreUseTransform = value;
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x000261C3 File Offset: 0x000243C3
		// (set) Token: 0x0600078C RID: 1932 RVA: 0x000261CB File Offset: 0x000243CB
		public ControllerLateUpdateDelegate OnControllerPreLateUpdate
		{
			get
			{
				return this.mOnControllerPreLateUpdate;
			}
			set
			{
				this.mOnControllerPreLateUpdate = value;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x000261D4 File Offset: 0x000243D4
		// (set) Token: 0x0600078E RID: 1934 RVA: 0x000261DC File Offset: 0x000243DC
		public ControllerLateUpdateDelegate OnControllerPostLateUpdate
		{
			get
			{
				return this.mOnControllerPostLateUpdate;
			}
			set
			{
				this.mOnControllerPostLateUpdate = value;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x000261E5 File Offset: 0x000243E5
		// (set) Token: 0x06000790 RID: 1936 RVA: 0x000261ED File Offset: 0x000243ED
		public ControllerMoveDelegate OnPreControllerMove
		{
			get
			{
				return this.mOnPreControllerMove;
			}
			set
			{
				this.mOnPreControllerMove = value;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x000261F6 File Offset: 0x000243F6
		public int StateIndex
		{
			get
			{
				return this.mStateIndex;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x000261FE File Offset: 0x000243FE
		public ActorState[] States
		{
			get
			{
				return this.mStates;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x00026206 File Offset: 0x00024406
		public float FixedUpdates
		{
			get
			{
				return this.mFixedUpdates;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x0002620E File Offset: 0x0002440E
		public int IgnoreCollisionCount
		{
			get
			{
				if (this.mIgnoreCollisions == null)
				{
					return 0;
				}
				return this.mIgnoreCollisions.Count;
			}
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00026225 File Offset: 0x00024425
		protected override void Awake_()
		{
			base.Awake_();
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00026230 File Offset: 0x00024430
		protected override void Start()
		{
			this.mCenter.y = this._Height * 0.5f;
			this.mStates = new ActorState[this._StateCount];
			for (int i = 0; i < this.mStates.Length; i++)
			{
				this.mStates[i] = new ActorState();
			}
			this.mPrevState = this.mStates[this.mStates.Length - 2];
			this.mState = this.mStates[this.mStates.Length - 1];
			this._Transform = base.transform;
			this.mOrientToGroundNormal = this._Transform.up;
			this._Transform.rotation.DecomposeSwingTwist(Vector3.up, ref this.mTilt, ref this.mYaw);
			this.DeserializeBodyShapes();
			for (int j = 0; j < this.BodyShapes.Count; j++)
			{
				if (this.BodyShapes[j]._UseUnityColliders)
				{
					this.BodyShapes[j].CreateUnityColliders();
				}
			}
			RaycastHit raycastHit;
			this.ProcessGrounding(this._Transform.position, Vector3.zero, this._Transform.up, this._Transform.up, this._BaseRadius, out raycastHit);
			this.mState.PrevGround = this.mState.Ground;
			this.mState.Position = this._Transform.position;
			this.mState.Rotation = this._Transform.rotation;
			this.mPrevState.Ground = this.mState.Ground;
			this.mPrevState.Position = this._Transform.position;
			this.mPrevState.Rotation = this._Transform.rotation;
			base.Start();
			if (this.stared != null)
			{
				this.stared(this);
			}
			this.stared = null;
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0002640C File Offset: 0x0002460C
		public void AddImpulse(Vector3 rForce)
		{
			if (this.mUpdateIndex != 1)
			{
				return;
			}
			if (this.mAppliedForces == null)
			{
				this.mAppliedForces = new List<Force>();
			}
			Force force = Force.Allocate();
			force.Type = ForceMode.Impulse;
			force.Value = rForce;
			force.StartTime = Time.time;
			force.Duration = 0f;
			this.mAppliedForces.Add(force);
			this.mIgnoreUseTransform = true;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00026474 File Offset: 0x00024674
		public void AddForce(Vector3 rForce, float rDuration)
		{
			if (this.mUpdateIndex != 1)
			{
				return;
			}
			if (this.mAppliedForces == null)
			{
				this.mAppliedForces = new List<Force>();
			}
			Force force = Force.Allocate();
			force.Type = ForceMode.Force;
			force.Value = rForce;
			force.StartTime = Time.time;
			force.Duration = rDuration;
			this.mAppliedForces.Add(force);
			this.mIgnoreUseTransform = true;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x000264D8 File Offset: 0x000246D8
		protected override void FixedUpdate_()
		{
			base.FixedUpdate_();
			this.mFixedUpdates = 0f;
			if (this.mState.IsGrounded)
			{
				this.mAccumulatedForceVelocity = Vector3.zero;
			}
			Vector3 vector = this.ProcessForces(Time.fixedDeltaTime);
			this.mAccumulatedForceVelocity += vector;
			this.mWorldUp = Vector3.up;
			if (this._IsGravityRelative)
			{
				if (this.mState.IsGrounded)
				{
					this.mWorldUp = Vector3.zero;
					int num = Mathf.Min(this._StateCount, 20);
					for (int i = 0; i < num; i++)
					{
						int num2 = ((this.mStateIndex + i < this._StateCount) ? (this.mStateIndex + i) : (this.mStateIndex + i - this._StateCount));
						if (this.mStates[num2] != null)
						{
							this.mWorldUp += this.mStates[num2].GroundSurfaceDirectNormal;
						}
					}
					this.mWorldUp = this.mWorldUp.normalized;
				}
				else
				{
					this.mWorldUp = Vector3.up;
					if (this.mTargetGroundNormal.sqrMagnitude > 0f)
					{
						this.mWorldUp = this.mTargetGroundNormal;
					}
					else if (this._KeepOrientationInAir || (this.mAccumulatedForceVelocity.sqrMagnitude == 0f && this.mState.GroundSurfaceDistance < this._OrientToGroundDistance))
					{
						if (this.mState.GroundSurfaceDirectNormal.sqrMagnitude == 0f)
						{
							this.mWorldUp = this._Transform.up;
						}
						else
						{
							this.mWorldUp = this.mState.GroundSurfaceDirectNormal;
						}
					}
				}
			}
			else if (this._Gravity.sqrMagnitude > 0f)
			{
				this.mWorldUp = -this._Gravity.normalized;
			}
			else if (Physics.gravity.sqrMagnitude > 0f)
			{
				this.mWorldUp = -Physics.gravity.normalized;
			}
			if (this.mState.IsGrounded)
			{
				Vector3 vector2 = Vector3.Project(this.mAccumulatedVelocity, this.mWorldUp);
				if (Vector3.Dot(vector2.normalized, this.mWorldUp) <= 0f)
				{
					Vector3 vector3 = this.mAccumulatedVelocity - vector2;
					vector2 = Vector3.zero;
					vector3 *= this._GroundDampenFactor;
					this.mAccumulatedVelocity = vector2 + vector3;
				}
			}
			Vector3 vector4 = Vector3.zero;
			if (this._IsGravityEnabled && this._ApplyGravityInFixedUpdate)
			{
				vector4 = ((this._Gravity.sqrMagnitude == 0f) ? Physics.gravity : this._Gravity);
				if (this._IsGravityRelative)
				{
					vector4 = -this.mWorldUp * vector4.magnitude;
				}
				this.mAccumulatedVelocity += vector4 * Time.fixedDeltaTime;
			}
			this.mAccumulatedVelocity += vector;
			if (this.mAccumulatedVelocity.sqrMagnitude > 0f && this._ApplyGravityInFixedUpdate)
			{
				Vector3 vector5 = this.mAccumulatedVelocity * Time.fixedDeltaTime;
				if (vector5.sqrMagnitude < this.mBorrowedFixedMovement.sqrMagnitude)
				{
					vector5 = Vector3.zero;
				}
				else
				{
					vector5 -= this.mBorrowedFixedMovement;
				}
				this.mAccumulatedMovement += vector5;
			}
			this.mBorrowedFixedMovement = Vector3.zero;
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00026840 File Offset: 0x00024A40
		protected override void LateUpdate_()
		{
			base.LateUpdate_();
			if (this.mOnControllerPostLateUpdate != null)
			{
				if (this.mUpdateCount > 0)
				{
					for (int i = 1; i <= this.mUpdateCount; i++)
					{
						this.mOnControllerPostLateUpdate(this, this._DeltaTime, i);
					}
					return;
				}
				this.mOnControllerPostLateUpdate(this, this._DeltaTime, 0);
			}
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0002689C File Offset: 0x00024A9C
		public override void ControllerUpdate(float rDeltaTime, int rUpdateIndex)
		{
			if (!this._ProcessInLateUpdate)
			{
				this.InternalUpdate(rDeltaTime, rUpdateIndex);
			}
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x000268AE File Offset: 0x00024AAE
		public override void ControllerLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
			if (this._ProcessInLateUpdate)
			{
				this.InternalUpdate(rDeltaTime, rUpdateIndex);
			}
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x000268C0 File Offset: 0x00024AC0
		public void ForceInternalUpdate(float rDeltaTime)
		{
			this.InternalUpdate(rDeltaTime, 1);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x000268CC File Offset: 0x00024ACC
		private void InternalUpdate(float rDeltaTime, int rUpdateIndex)
		{
			if (rUpdateIndex == 0)
			{
				return;
			}
			Vector3 up = this._Transform.up;
			if (this.mOnControllerPreLateUpdate != null)
			{
				this.mOnControllerPreLateUpdate(this, rDeltaTime, rUpdateIndex);
			}
			if (!this._IsEnabled)
			{
				return;
			}
			this.mPrevState = this.mState;
			this.mStateIndex = ActorState.Shift(ref this.mStates, this.mStateIndex);
			this.mState = this.mStates[this.mStateIndex];
			for (int i = 0; i < this.BodyShapes.Count; i++)
			{
				this.BodyShapes[i].LateUpdate();
			}
			Quaternion quaternion = Quaternion.identity;
			Quaternion quaternion2 = Quaternion.identity;
			if (!this.mIgnoreUseTransform && this._UseTransformPosition && this._UseTransformRotation)
			{
				this.mTargetRotate = Quaternion.identity;
				this.mTargetRotation = Quaternion.identity;
				this.mTargetRotation.x = float.MaxValue;
				this.mTargetRotationVelocity = Vector3.zero;
				Quaternion rotation = this._Transform.rotation;
				rotation.DecomposeSwingTwist(this._Transform.up, ref this.mTilt, ref this.mYaw);
				this.mState.Rotation = rotation;
				this.mState.RotationYaw = this.mYaw;
				this.mState.RotationTilt = this.mTilt;
			}
			else if (this.mTargetRotation.x != 3.4028235E+38f)
			{
				this.mYaw = this.mTargetRotation;
				this.mTilt = this.mTargetTilt;
				this.mState.Rotation = (this._InvertRotationOrder ? (this.mYaw * this.mTilt) : (this.mTilt * this.mYaw));
				this._Transform.rotation = this.mState.Rotation;
				this.mTargetRotation = Quaternion.identity;
				this.mTargetRotation.x = float.MaxValue;
				this.mTargetTilt = Quaternion.identity;
			}
			else
			{
				if (!this._FreezeRotationY)
				{
					Quaternion quaternion3 = Quaternion.Euler(this.mTargetRotationVelocity * rDeltaTime);
					quaternion *= quaternion3;
					quaternion *= this.mTargetRotate;
				}
				if (!this._FreezeRotationX)
				{
					quaternion2 *= this.mTargetTilt;
				}
				this.mTargetRotate = Quaternion.identity;
				this.mTargetTilt = Quaternion.identity;
			}
			if (!this.mIgnoreUseTransform && this._UseTransformPosition)
			{
				this.mTargetMove = Vector3.zero;
				this.mTargetVelocity = Vector3.zero;
				this.mTargetPosition = Vector3.zero;
				this.mTargetPosition.x = float.MaxValue;
				this.mAccumulatedForceVelocity = Vector3.zero;
				if (this.mAppliedForces != null)
				{
					this.mAppliedForces.Clear();
				}
				this.mYaw *= quaternion;
				this.mTilt *= quaternion2;
				Vector3 position = this._Transform.position;
				this.mState.Position = position;
				this.mState.Velocity = (this.mState.Position - this.mPrevState.Position) / Time.deltaTime;
				if (this.mTargetGround == null)
				{
					RaycastHit raycastHit;
					this.mState.IsGrounded = this.ProcessGrounding(this._Transform.position, Vector3.zero, this._Transform.up, this.mWorldUp, this._BaseRadius, out raycastHit);
					if (this.mState.IsGrounded && this._OrientToGround && Mathf.Abs(this.mState.GroundSurfaceAngle) > this._MinOrientToGroundAngleForSpeed)
					{
						Vector3 vector = (this.mTilt * this.mYaw).Up();
						this.mTilt = QuaternionExt.FromToRotation(vector, this.mState.GroundSurfaceDirectNormal) * this.mTilt;
						this.mState.Rotation = this.mTilt * this.mYaw;
						this.mState.RotationYaw = this.mYaw;
						this.mState.RotationTilt = this.mTilt;
					}
				}
				else
				{
					this.mState.IsGrounded = true;
					this.mState.Ground = this.mTargetGround;
					this.mState.GroundPosition = this.mTargetGround.position;
					this.mState.GroundRotation = this.mTargetGround.rotation;
				}
				this._Transform.rotation = this.mState.Rotation;
				return;
			}
			if (this.mTargetPosition.x != 3.4028235E+38f)
			{
				this.mYaw *= quaternion;
				this.mTilt *= quaternion2;
				this.mState.IsMoveRequested = true;
				this.mState.Velocity = Vector3.zero;
				this.mState.Position = this.mTargetPosition;
				this._Transform.position = this.mTargetPosition;
				RaycastHit raycastHit2;
				this.ProcessGrounding(this._Transform.position, this.mState.MovementPlatformAdjust, up, this.mWorldUp, this._BaseRadius, out raycastHit2);
				this.mTargetPosition.x = float.MaxValue;
				return;
			}
			this.UpdateMovement(rDeltaTime, rUpdateIndex, quaternion, quaternion2);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00026E10 File Offset: 0x00025010
		public void UpdateMovement(float rDeltaTime, int rUpdateIndex, Quaternion rFrameYaw, Quaternion rFrameTilt)
		{
			Vector3 up = this._Transform.up;
			Vector3 vector = Vector3.zero;
			Quaternion quaternion = Quaternion.identity;
			this.mState.Movement = this.mTargetVelocity * rDeltaTime;
			this.mState.Movement = this.mState.Movement + this.mTargetMove;
			this.mTargetMove = Vector3.zero;
			this.mState.IsMoveRequested = this.mState.Movement.sqrMagnitude > 1E-08f;
			bool isMoveRequested = this.mState.IsMoveRequested;
			if (this.mPrevState.IsGrounded)
			{
				this.ProcessPlatforming(this.mPrevState);
			}
			this.mYaw *= rFrameYaw;
			this.mTilt *= rFrameTilt;
			if (this._ApplyGravityInFixedUpdate)
			{
				if (this._ExtrapolatePhysics && this.mFixedUpdates > 0f)
				{
					this.mBorrowedFixedMovement = this.mAccumulatedVelocity * (rDeltaTime / (this.mFixedUpdates + 1f));
					this.mAccumulatedMovement = this.mBorrowedFixedMovement;
				}
				this.mState.MovementForceAdjust = this.mAccumulatedMovement;
				this.mFixedUpdates += 1f;
				this.mAccumulatedMovement = Vector3.zero;
			}
			else if (this._IsGravityEnabled)
			{
				Vector3 vector2 = ((this._Gravity.sqrMagnitude == 0f) ? Physics.gravity : this._Gravity);
				if (this._IsGravityRelative)
				{
					vector2 = -this.mWorldUp * vector2.magnitude;
				}
				this.mAccumulatedVelocity += vector2 * rDeltaTime;
				this.mState.MovementForceAdjust = this.mAccumulatedVelocity * rDeltaTime;
			}
			Vector3 vector3 = Vector3.Project(this.mState.MovementForceAdjust, up);
			float num = Vector3.Dot(vector3, up);
			if (this.mPrevState.IsGrounded && num < 0f)
			{
				this.mState.MovementForceAdjust = this.mState.MovementForceAdjust - vector3;
				vector3 = Vector3.zero;
				num = 0f;
			}
			float num2 = 0.1f;
			Vector3 vector4 = this._Transform.position;
			Vector3 vector5 = this.mState.Movement + this.mState.MovementPlatformAdjust + this.mState.MovementForceAdjust;
			float num3 = vector5.magnitude;
			Vector3 vector6 = vector5.normalized;
			Vector3 vector7 = Vector3.zero;
			float num4 = 0f;
			float num5;
			for (;;)
			{
				num4 += num2;
				if (num4 > num3)
				{
					num2 -= num4 - num3;
					num4 = num3;
				}
				vector7 += vector6 * num2;
				Vector3 vector8 = this._Transform.position + vector7 + this.mState.MovementGroundAdjust + this.mState.MovementCounterAdjust;
				num5 = this.GetGroundDistance(vector8, up);
				if (num5 < this._SkinWidth)
				{
					this.mState.IsGrounded = true;
					if ((this._ForceGrounding && num5 > 0f) || (this._FixGroundPenetration && num5 < 0f))
					{
						this.mState.MovementGroundAdjust = this.mState.MovementGroundAdjust + up * -num5;
					}
				}
				else if (this._ForceGrounding && this._FixGroundPenetration && num < 0.0001f)
				{
					float num6 = ((this._ForceGroundingDistance > 0f) ? this._ForceGroundingDistance : this._SkinWidth);
					if (this.mPrevState.IsGrounded && num5 < num6)
					{
						this.mState.IsGrounded = true;
						this.mState.MovementGroundAdjust = this.mState.MovementGroundAdjust + up * -num5;
					}
				}
				if (this._IsSlidingEnabled && this.mState.IsGrounded && (this._MinSlopeAngle > 0f || this._MaxSlopeAngle > 0f) && (this.mState.GroundSurfaceAngle >= this._MaxSlopeAngle || !this.mState.IsMoveRequested))
				{
					float num7 = ((this._MaxSlopeAngle > 0f) ? this._MaxSlopeAngle : 85f);
					float num8 = ((this._MinSlopeAngle > 0f) ? this._MinSlopeAngle : (num7 * 0.5f));
					if (this.mState.GroundSurfaceAngle > num8 && this.mPrevState.GroundSurfaceAngle > num8)
					{
						float num9 = (this.mState.GroundSurfaceAngle - num8) / (num7 - num8);
						Vector3 vector9 = ((this._Gravity.sqrMagnitude == 0f) ? Physics.gravity : this._Gravity);
						Vector3 vector10 = Vector3.Cross(this.mState.GroundSurfaceNormal, vector9.normalized);
						if (vector10.sqrMagnitude == 0f)
						{
							vector10 = Vector3.Cross(this.mState.GroundSurfaceNormal, -this.mWorldUp);
						}
						Vector3 vector11 = Vector3.Cross(vector10, this.mState.GroundSurfaceNormal);
						this.mState.MovementSlideAdjust = vector11 * (vector9.magnitude * this._MinSlopeGravityCoefficient * num9 * rDeltaTime);
					}
				}
				if (this._IsCollisionEnabled)
				{
					Vector3 vector12 = this._Transform.position + vector7 + this.mState.MovementGroundAdjust + this.mState.MovementSlideAdjust + this.mState.MovementCounterAdjust;
					Vector3 vector13 = vector4 - this._Transform.position;
					Vector3 vector14 = vector12 - vector4;
					Vector3 vector15 = Vector3.zero;
					if (this.ProcessCollisions(vector13, ref vector14, ref vector15))
					{
						this.mState.IsColliding = true;
					}
					this.mState.MovementCounterAdjust = this.mState.MovementCounterAdjust - vector15;
					if (vector15.sqrMagnitude > 1E-08f)
					{
						Vector3 vector16 = vector15 - Vector3.Project(vector15, this.mState.ColliderHit.normal);
						if (this._ShowDebug)
						{
							GraphicsManager.DrawArrow(this.mState.ColliderHit.point, this.mState.ColliderHit.point + this.mState.ColliderHit.normal, Color.red, null, 5f);
							GraphicsManager.DrawArrow(this.mState.ColliderHit.point, this.mState.ColliderHit.point + vector16.normalized, Color.blue, null, 5f);
						}
						if (this.mState.IsGrounded)
						{
							Vector3 vector17 = Vector3.Project(vector16, up);
							float num10 = Vector3.Dot(vector17, up);
							if (num10 > 0f)
							{
								vector16 -= vector17;
							}
							else if (num10 < 0f && this.mState.MovementGroundAdjust.magnitude < this._SkinWidth)
							{
								vector16 -= vector17;
							}
						}
						Vector3 vector18 = Vector3.Project(vector16, this.mState.Movement.normalized);
						if (Vector3.Dot(vector18.normalized, this.mState.Movement.normalized) < 0f)
						{
							vector16 -= vector18;
						}
						if (Vector3.Dot(Vector3.Project(this.mState.ColliderHit.normal, up), up) < -0.05f && Vector3.Dot(Vector3.Project(this.mAccumulatedVelocity, up).normalized, up) > 0f)
						{
							this.mAccumulatedVelocity = Vector3.zero;
						}
						Vector3 vector19 = vector16 - Vector3.Project(vector16, up);
						this.mState.IsMovementBlocked = vector19.sqrMagnitude < 0.0002f;
						vector6 = vector16.normalized;
						num3 -= vector15.magnitude - vector16.magnitude;
						vector15 = Vector3.zero;
						this.ProcessCollisions(vector4 - this._Transform.position + vector14, ref vector16, ref vector15);
						this.mState.MovementCounterAdjust = this.mState.MovementCounterAdjust + vector16;
					}
				}
				if (this.mState.IsGrounded && this._MaxSlopeAngle > 0f && this.mState.GroundSurfaceAngle > this._MaxSlopeAngle)
				{
					Vector3 vector20 = this._Transform.position + vector7 + this.mState.MovementGroundAdjust + this.mState.MovementSlideAdjust + this.mState.MovementCounterAdjust - vector4;
					Vector3 vector21 = Vector3.Project(vector20, up);
					Vector3 vector22 = vector20 - vector21;
					if (Vector3.Dot(vector21.normalized, up) > 0f)
					{
						if (this._ShowDebug)
						{
							GraphicsManager.DrawLine(vector4 + up * this._MaxStepHeight, vector4 + up * this._MaxStepHeight + vector22.normalized * 2f, Color.magenta, null, 2f);
						}
						RaycastHit raycastHit;
						if (RaycastExt.SafeRaycast(vector4 + up * this._MaxStepHeight, vector22.normalized, out raycastHit, 2f, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false) && Vector3.Angle(raycastHit.normal, up) > this._MaxSlopeAngle)
						{
							this.mState.MovementSlideAdjust = this.mState.MovementSlideAdjust - vector20;
							Vector3 vector23 = Vector3.Project(raycastHit.normal, up);
							Vector3 vector24 = raycastHit.normal - vector23;
							Vector3 vector25 = vector22 - Vector3.Project(vector22, vector24.normalized);
							this.mState.IsMovementBlocked = vector25.sqrMagnitude < 0.0002f;
							if (vector25.sqrMagnitude < 1E-08f)
							{
								break;
							}
							this.mState.MovementSlideAdjust = this.mState.MovementSlideAdjust + vector25;
							vector6 = vector25.normalized;
						}
					}
				}
				vector4 = this._Transform.position + vector7 + this.mState.MovementGroundAdjust + this.mState.MovementSlideAdjust + this.mState.MovementCounterAdjust;
				if (num4 >= num3)
				{
					goto IL_0AB2;
				}
			}
			vector4 = this._Transform.position + vector7 + this.mState.MovementGroundAdjust + this.mState.MovementSlideAdjust + this.mState.MovementCounterAdjust;
			IL_0AB2:
			Vector3 vector26 = this._Transform.position + this.mState.Movement + this.mState.MovementPlatformAdjust + this.mState.MovementForceAdjust + this.mState.MovementGroundAdjust + this.mState.MovementSlideAdjust + this.mState.MovementCounterAdjust;
			this.mState.MovementCounterAdjust = this.mState.MovementCounterAdjust + (vector4 - vector26);
			bool flag = this._AllowPushback;
			bool flag2 = this._StopOnRotationCollision;
			if (this._OrientToGround || this.mPrevState.IsTilting || this.mState.IsTilting)
			{
				this.mOrientToGroundNormalTarget = Vector3.up;
				if (this._OrientToGround)
				{
					if (this.mTargetGroundNormal.sqrMagnitude > 0f)
					{
						this.mOrientToGroundNormalTarget = this.mTargetGroundNormal;
					}
					else if (this.mState.IsGrounded || this._KeepOrientationInAir || (this.mAccumulatedForceVelocity.sqrMagnitude == 0f && this.mState.GroundSurfaceDistance < this._OrientToGroundDistance))
					{
						this.mOrientToGroundNormalTarget = this.mState.GroundSurfaceDirectNormal;
					}
				}
				Vector3 vector27 = (this.mTilt * this.mYaw).Up();
				float num11 = Vector3.Angle(vector27, this.mOrientToGroundNormalTarget);
				if (num11 == 0f)
				{
					this.mOrientToSpeed = 0f;
					if (!this._OrientToGround && vector27 == Vector3.up && this.mState.IsGrounded)
					{
						this.mState.IsTilting = false;
						this.mYaw = this._Transform.rotation;
						this.mTilt = Quaternion.identity;
					}
					else if (this.mPrevState.IsTilting && (!this._OrientToGround || !this.mState.IsGrounded))
					{
						this.mState.IsTilting = true;
						flag = true;
						flag2 = true;
					}
				}
				else
				{
					bool flag3 = false;
					float num12 = this.mState.GroundSurfaceAngle;
					if (!this.mPrevState.IsTilting && num11 > 45f)
					{
						int num13 = Mathf.Min(this._StateCount, 20);
						for (int i = 0; i < num13; i++)
						{
							int num14 = ((this.mStateIndex + i < this._StateCount) ? (this.mStateIndex + i) : (this.mStateIndex + i - this._StateCount));
							if (this.mStates[num14] != null)
							{
								num12 += this.mStates[num14].GroundSurfaceAngle;
							}
						}
						num12 /= (float)num13;
						if (this.mState.GroundSurfaceAngle - num12 > 30f)
						{
							flag3 = true;
						}
					}
					if (!flag3)
					{
						if (!this.mPrevState.IsTilting)
						{
							if (this._OrientToGroundSpeed == 0f || this._MinOrientToGroundAngleForSpeed == 0f || num11 < this._MinOrientToGroundAngleForSpeed)
							{
								this.mOrientToGroundNormal = this.mOrientToGroundNormalTarget;
							}
							else
							{
								this.mState.IsTilting = true;
								flag = true;
								flag2 = true;
								float num15 = Mathf.Max((num11 - this._MinOrientToGroundAngleForSpeed) / (180f - this._MinOrientToGroundAngleForSpeed), 0.1f);
								this.mOrientToSpeed = num11 / this._OrientToGroundSpeed / num15;
								this.mOrientToGroundNormal = Vector3.RotateTowards(this.mOrientToGroundNormal, this.mOrientToGroundNormalTarget, this.mOrientToSpeed * rDeltaTime * 0.017453292f, 0f);
							}
						}
						else if (num11 < 0.1f)
						{
							this.mOrientToGroundNormal = this.mOrientToGroundNormalTarget;
						}
						else
						{
							this.mState.IsTilting = true;
							flag = true;
							flag2 = true;
							float num16 = Mathf.Max((num11 - this._MinOrientToGroundAngleForSpeed) / (180f - this._MinOrientToGroundAngleForSpeed), 0.1f);
							this.mOrientToSpeed = Mathf.Max(num11 / this._OrientToGroundSpeed / num16, this.mOrientToSpeed);
							this.mOrientToGroundNormal = Vector3.RotateTowards(this.mOrientToGroundNormal, this.mOrientToGroundNormalTarget, this.mOrientToSpeed * rDeltaTime * 0.017453292f, 0f);
						}
					}
					this.mTilt = QuaternionExt.FromToRotation(vector27, this.mOrientToGroundNormal) * this.mTilt;
					if (QuaternionExt.IsEqual(this.mTilt, Quaternion.identity))
					{
						this.mTilt = Quaternion.identity;
						this.mState.IsTilting = false;
					}
				}
			}
			else if (!this._OrientToGround && Vector3.Angle(up, Vector3.up) > 0f && this.mTilt.eulerAngles.sqrMagnitude < 0.001f)
			{
				Quaternion quaternion2 = QuaternionExt.FromToRotation(this._Transform.up, Vector3.up);
				this.mYaw = quaternion2 * this.mYaw;
				this.mTilt = Quaternion.identity;
			}
			float sqrMagnitude = this.mState.Movement.sqrMagnitude;
			num5 = this.GetGroundDistance(vector4, up);
			vector = vector4 - this._Transform.position;
			quaternion = this._Transform.rotation.RotationTo(this._InvertRotationOrder ? (this.mYaw * this.mTilt) : (this.mTilt * this.mYaw));
			flag = flag || (this._MaxSlopeAngle > 0f && this.mState.GroundSurfaceAngle >= this._MaxSlopeAngle);
			if (this._IsCollisionEnabled && (flag || flag2))
			{
				int j = 0;
				while (j < this.BodyShapes.Count)
				{
					BodyShape bodyShape = this.BodyShapes[j];
					BodyShape.BodyShapeHitFast bodyShapeHitFast;
					if (((bodyShape.IsEnabledOnGround && this.mState.IsGrounded) || (bodyShape.IsEnabledAboveGround && !this.mState.IsGrounded)) && bodyShape.CollisionOverlapTavo(vector, quaternion, this._CollisionLayers, out bodyShapeHitFast))
					{
						if (flag)
						{
							Vector3 normalized = (bodyShapeHitFast.HitOrigin - bodyShapeHitFast.HitPoint).normalized;
							vector += normalized * -bodyShapeHitFast.HitDistance;
						}
						if (flag2)
						{
							this.mYaw = this.mPrevState.RotationYaw;
							this.mTilt = this.mPrevState.RotationTilt;
							quaternion = Quaternion.identity;
							this.mOrientToGroundNormal = (this.mTilt * this.mYaw).Up();
							break;
						}
						break;
					}
					else
					{
						j++;
					}
				}
			}
			this.mState.IsSteppingUp = false;
			this.mState.IsSteppingDown = false;
			bool flag4 = true;
			if (flag4 && !this._FixGroundPenetration)
			{
				flag4 = false;
			}
			if (flag4 && !this.mState.IsGrounded)
			{
				flag4 = false;
			}
			if (flag4 && this.mState.GroundSurfaceAngle > 0.0001f)
			{
				flag4 = false;
			}
			if (flag4 && this.mPrevState.GroundSurfaceAngle > 0.0001f)
			{
				flag4 = false;
			}
			if (flag4 && this.mState.MovementSlideAdjust.sqrMagnitude > 1E-08f)
			{
				flag4 = false;
			}
			if (flag4 && this.mState.MovementPlatformAdjust.sqrMagnitude > 1E-08f)
			{
				flag4 = false;
			}
			if (flag4)
			{
				Vector3 vector28 = Vector3.Project(vector, up);
				Vector3 vector29 = vector - vector28;
				float num17 = Vector3.Dot(vector28, up);
				if (num17 > 0.0001f)
				{
					if (this._StepUpSpeed > 0f)
					{
						this.mState.IsSteppingUp = true;
						vector28 = Vector3.MoveTowards(Vector3.zero, vector28, Mathf.Max(vector29.magnitude, Time.deltaTime * 1f) * this._StepUpSpeed);
						vector = vector29 + vector28;
					}
				}
				else if (num17 < -0.0001f && this._StepDownSpeed > 0f)
				{
					bool flag5 = true;
					Vector3 vector30 = Vector3.Project(this.mAccumulatedVelocity, up);
					if (Vector3.Dot(vector30.normalized, up) < 0f)
					{
						Vector3 vector31 = ((this._Gravity.sqrMagnitude == 0f) ? Physics.gravity : this._Gravity) * rDeltaTime;
						if (vector30.magnitude > vector31.magnitude * 2f)
						{
							flag5 = false;
						}
					}
					if (flag5)
					{
						this.mState.IsSteppingDown = true;
						vector28 = Vector3.MoveTowards(Vector3.zero, vector28, Mathf.Max(vector29.magnitude, Time.deltaTime * 1f) * this._StepDownSpeed);
						vector = vector29 + vector28;
					}
				}
			}
			else if (this._FixGroundPenetration && num5 < 0f)
			{
				this.mState.IsGrounded = true;
				if (this._MaxSlopeAngle > 0f && this.mState.GroundSurfaceAngle < this._MaxSlopeAngle)
				{
					vector += up * -num5;
				}
			}
			if (this._FreezeRotationX || this._FreezeRotationY || this._FreezeRotationZ)
			{
				Vector3 eulerAngles = quaternion.eulerAngles;
				if (this._FreezeRotationX)
				{
					eulerAngles.x = 0f;
				}
				if (this._FreezeRotationY)
				{
					eulerAngles.y = 0f;
				}
				if (this._FreezeRotationZ)
				{
					eulerAngles.z = 0f;
				}
				quaternion.eulerAngles = eulerAngles;
			}
			if (vector.sqrMagnitude > 0f)
			{
				if (this._FreezePositionX)
				{
					vector.x = 0f;
				}
				if (this._FreezePositionY)
				{
					vector.y = 0f;
				}
				if (this._FreezePositionZ)
				{
					vector.z = 0f;
				}
			}
			Quaternion quaternion3 = this._Transform.rotation * quaternion;
			Vector3 vector32 = this._Transform.position + vector;
			if (this.mOnPreControllerMove != null)
			{
				this.mState.RotationYaw = this.mYaw;
				this.mState.RotationTilt = this.mTilt;
				this.mState.Rotation = quaternion3;
				this.mState.Position = vector32;
				this.mState.Velocity = (vector32 - this.mPrevState.Position) / Time.deltaTime;
				this.mOnPreControllerMove(this, ref vector32, ref quaternion3);
			}
			if (this._ShowDebug)
			{
				Log.FileScreenWrite(string.Format("isG:{0} gDist:{1:f3} gAng:{2:f3} gFwdAng:{3:f3} spd:{4:f3}", new object[]
				{
					this.mState.IsGrounded,
					num5,
					this.mState.GroundSurfaceAngle,
					this.mState.GroundSurfaceForwardAngle,
					vector.magnitude / Time.deltaTime
				}), 1);
				Log.FileScreenWrite(string.Format("isUp:{0} isDn:{1} isUser:{2} isBlk:{3} isTlt:{4}", new object[]
				{
					this.mState.IsSteppingUp,
					this.mState.IsSteppingDown,
					this.mState.IsMoveRequested,
					this.mState.IsMovementBlocked,
					this.mState.IsTilting
				}), 2);
				Log.FileWrite(".");
			}
			this._Transform.rotation = quaternion3;
			this._Transform.position = vector32;
			this.mState.RotationYaw = this.mYaw;
			this.mState.RotationTilt = this.mTilt;
			this.mState.Rotation = quaternion3;
			this.mState.Position = vector32;
			this.mState.Velocity = (vector32 - this.mPrevState.Position) / Time.deltaTime;
			if (this.mTargetGround != null)
			{
				this.mState.IsGrounded = true;
				this.mState.Ground = this.mTargetGround;
			}
			if (this.mState.Ground != null)
			{
				this.mState.GroundPosition = this.mState.Ground.position;
				this.mState.GroundRotation = this.mState.Ground.rotation;
			}
			if (this.mState.IsGrounded)
			{
				Vector3 vector33 = Vector3.Project(this.mAccumulatedVelocity, up);
				Vector3 vector34 = this.mAccumulatedVelocity - vector33;
				this.mAccumulatedVelocity = Vector3.zero + vector34;
			}
			if (this.mIgnoreUseTransform && this.mAppliedForces.Count == 0 && this.mAccumulatedVelocity.sqrMagnitude < 1E-08f)
			{
				this.mIgnoreUseTransform = false;
			}
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00028540 File Offset: 0x00026740
		public void SetGround(Transform rGround)
		{
			this.mTargetGround = rGround;
			if (this.mTargetGround == null)
			{
				this.mAccumulatedVelocity = Vector3.zero;
				this.mAccumulatedMovement = Vector3.zero;
			}
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0002856D File Offset: 0x0002676D
		public void SetTargetGroundNormal(Vector3 rTargetGroundNormal)
		{
			if (this._OrientToGround)
			{
				this.mTargetGroundNormal = rTargetGroundNormal;
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0002857E File Offset: 0x0002677E
		public void SetYaw(Quaternion rYaw)
		{
			this.mTargetRotation = rYaw;
			this.mTargetTilt = this.mTilt;
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00028593 File Offset: 0x00026793
		public void SetRotation(Quaternion rRotation)
		{
			this.mTargetRotation = Quaternion.Inverse(this.mTilt) * rRotation;
			this.mTargetTilt = this.mTilt;
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x000285B8 File Offset: 0x000267B8
		public void SetRotation(Quaternion rYaw, Quaternion rTilt)
		{
			this.mTargetRotation = rYaw;
			this.mTargetTilt = rTilt;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x000285C8 File Offset: 0x000267C8
		public void Rotate(Quaternion rYaw)
		{
			this.mTargetRotate *= rYaw;
			this.mTargetTilt = Quaternion.identity;
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x000285E7 File Offset: 0x000267E7
		public void Rotate(Quaternion rYaw, Quaternion rTilt)
		{
			this.mTargetRotate *= rYaw;
			this.mTargetTilt *= rTilt;
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0002860D File Offset: 0x0002680D
		public void SetRotationVelocity(Vector3 rVelocity)
		{
			this.mTargetRotationVelocity = rVelocity;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00028616 File Offset: 0x00026816
		public void SetPosition(Vector3 rPosition)
		{
			this.mTargetPosition = rPosition;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0002861F File Offset: 0x0002681F
		public void Move(Vector3 rMovement)
		{
			this.mTargetMove += rMovement;
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00028633 File Offset: 0x00026833
		public void RelativeMove(Vector3 rMovement)
		{
			this.mTargetMove += this._Transform.rotation * rMovement;
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00028657 File Offset: 0x00026857
		public void SetVelocity(Vector3 rVelocity)
		{
			this.mTargetVelocity = rVelocity;
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00028660 File Offset: 0x00026860
		public void SetRelativeVelocity(Vector3 rVelocity)
		{
			this.mTargetVelocity = this._Transform.rotation * rVelocity;
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0002867C File Offset: 0x0002687C
		public Vector3 ClosestPoint(Vector3 rOrigin)
		{
			Vector3 vector = Vector3Ext.Null;
			float num = float.MaxValue;
			for (int i = 0; i < this.BodyShapes.Count; i++)
			{
				Vector3 vector2 = this.BodyShapes[i].ClosestPoint(rOrigin);
				if (vector2 != Vector3Ext.Null)
				{
					float sqrMagnitude = (vector2 - rOrigin).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						vector = vector2;
						num = sqrMagnitude;
					}
				}
			}
			return vector;
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x000286E8 File Offset: 0x000268E8
		public bool IsIgnoringCollision(Collider rCollider)
		{
			return this.mIgnoreCollisions != null && this.mIgnoreCollisions.Contains(rCollider);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00028700 File Offset: 0x00026900
		public void ClearIgnoreCollisions()
		{
			if (this.mIgnoreCollisions != null)
			{
				for (int i = 0; i < this.mIgnoreCollisions.Count; i++)
				{
					for (int j = 0; j < this.BodyShapes.Count; j++)
					{
						if (this.BodyShapes[j].Colliders != null)
						{
							for (int k = 0; k < this.BodyShapes[j].Colliders.Length; k++)
							{
								Physics.IgnoreCollision(this.BodyShapes[j].Colliders[k], this.mIgnoreCollisions[i], false);
							}
						}
					}
				}
				this.mIgnoreCollisions.Clear();
				this.mIgnoreTransforms.Clear();
			}
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x000287B0 File Offset: 0x000269B0
		public void IgnoreCollision(Collider rCollider, bool rIgnore = true)
		{
			if (rIgnore && this.IsIgnoringCollision(rCollider))
			{
				return;
			}
			if (!rIgnore && !this.IsIgnoringCollision(rCollider))
			{
				return;
			}
			for (int i = 0; i < this.BodyShapes.Count; i++)
			{
				if (this.BodyShapes[i].Colliders != null)
				{
					for (int j = 0; j < this.BodyShapes[i].Colliders.Length; j++)
					{
						Physics.IgnoreCollision(this.BodyShapes[i].Colliders[j], rCollider, rIgnore);
					}
				}
			}
			if (rIgnore)
			{
				if (this.mIgnoreCollisions == null)
				{
					this.mIgnoreCollisions = new List<Collider>();
				}
				if (!this.mIgnoreCollisions.Contains(rCollider))
				{
					this.mIgnoreCollisions.Add(rCollider);
				}
				if (this.mIgnoreTransforms == null)
				{
					this.mIgnoreTransforms = new List<Transform>();
				}
				if (!this.mIgnoreTransforms.Contains(rCollider.transform))
				{
					this.mIgnoreTransforms.Add(rCollider.transform);
					return;
				}
			}
			else
			{
				if (this.mIgnoreCollisions != null)
				{
					this.mIgnoreCollisions.Remove(rCollider);
				}
				if (this.mIgnoreTransforms != null)
				{
					this.mIgnoreTransforms.Remove(rCollider.transform);
				}
			}
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x000288D0 File Offset: 0x00026AD0
		protected bool TestGrounding(Vector3 rPosition, Vector3 rActorUp, Vector3 rWorldUp, out RaycastHit rGroundHitInfo)
		{
			Vector3 vector = rPosition + rActorUp * this._GroundingStartOffset;
			Vector3 vector2 = -rActorUp;
			float num = this._GroundingStartOffset + this._GroundingDistance;
			bool flag;
			if (this._IsGroundingLayersEnabled)
			{
				flag = RaycastExt.SafeRaycast(vector, vector2, out rGroundHitInfo, num, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false);
			}
			else
			{
				flag = RaycastExt.SafeRaycast(vector, vector2, out rGroundHitInfo, num, -1, this._Transform, this.mIgnoreTransforms, true, false);
			}
			if (flag)
			{
				rGroundHitInfo.distance -= this._GroundingStartOffset;
			}
			return flag;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00028964 File Offset: 0x00026B64
		protected bool TestSlope(Vector3 rPosition, Vector3 rActorUp, Vector3 rMovement, Vector3 rPlatformMovement, float rCurrentGroundSurfaceAngle, ref Vector3 rSafeMovement, ref Vector3 rGroundNormal)
		{
			if (rMovement.sqrMagnitude == 0f)
			{
				return false;
			}
			Vector3 vector = rMovement - rPlatformMovement;
			Vector3 normalized = vector.normalized;
			float magnitude = vector.magnitude;
			RaycastHit raycastHit;
			bool flag;
			if (this._IsGroundingLayersEnabled)
			{
				flag = RaycastExt.SafeRaycast(rPosition + rActorUp * 0.0001f, normalized, out raycastHit, magnitude + this._SkinWidth, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false);
			}
			else
			{
				flag = RaycastExt.SafeRaycast(rPosition + rActorUp * 0.0001f, normalized, out raycastHit, magnitude + this._SkinWidth, -1, this._Transform, this.mIgnoreTransforms, true, false);
			}
			if (!flag)
			{
				return false;
			}
			if (this._Transform.InverseTransformPoint(raycastHit.point).y < this._MaxStepHeight)
			{
				RaycastHit raycastHit2;
				if (this._IsGroundingLayersEnabled)
				{
					flag = RaycastExt.SafeRaycast(rPosition + rActorUp * this._MaxStepHeight, normalized, out raycastHit2, this._MinStepDepth * 2f, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false);
				}
				else
				{
					flag = RaycastExt.SafeRaycast(rPosition + rActorUp * this._MaxStepHeight, normalized, out raycastHit2, this._MinStepDepth * 2f, -1, this._Transform, this.mIgnoreTransforms, true, false);
				}
				if (!flag)
				{
					return false;
				}
				float num = ((this._MinStepDepth > 0f) ? this._MinStepDepth : this.Radius);
				if (raycastHit2.distance >= num)
				{
					Vector3 vector2 = Vector3.Project(raycastHit2.normal, rActorUp);
					if (vector2.sqrMagnitude == 0f)
					{
						return false;
					}
					if (Vector3.Dot(vector2.normalized, rActorUp) < 0.1f)
					{
						return false;
					}
				}
			}
			if (Vector3.Dot(Vector3.Project(raycastHit.normal, rActorUp).normalized, rActorUp) == 0f)
			{
				return false;
			}
			float num2 = Vector3.Angle(raycastHit.normal, rActorUp);
			rGroundNormal = raycastHit.normal;
			Vector3 vector3 = rPosition;
			Vector3 vector4 = rPosition;
			Vector3 vector5 = rPosition + normalized * raycastHit.distance;
			Vector3 vector6 = vector4 + (vector5 - vector4) / 2f;
			float num3 = (vector5 - vector4).sqrMagnitude;
			float num4 = this._SlopeMovementStep * this._SlopeMovementStep;
			if (num4 > num3)
			{
				num4 = num3;
			}
			int num5 = 0;
			while (num5 < 20 && num3 > 1E-08f && num3 >= num4)
			{
				num5++;
				bool flag2 = false;
				if (this._IsGroundingLayersEnabled)
				{
					flag = RaycastExt.SafeRaycast(vector6 + rActorUp * this._MaxStepHeight, -rActorUp, out raycastHit, this._MaxStepHeight + 0.05f, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false);
				}
				else
				{
					flag = RaycastExt.SafeRaycast(vector6 + rActorUp * this._MaxStepHeight, -rActorUp, out raycastHit, this._MaxStepHeight + 0.05f, -1, this._Transform, this.mIgnoreTransforms, true, false);
				}
				if (flag && Vector3.Angle(raycastHit.normal, rActorUp) == num2)
				{
					flag2 = true;
				}
				if (flag2)
				{
					vector5 = vector6;
				}
				else
				{
					vector4 = vector6;
					vector3 = vector6;
				}
				num3 = (vector5 - vector4).sqrMagnitude;
				vector6 = vector4 + (vector5 - vector4) / 2f;
			}
			rSafeMovement = vector3 - rPosition;
			return true;
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00028CE0 File Offset: 0x00026EE0
		protected bool ProcessCollisions(Vector3 rSegmentPositionDelta, ref Vector3 rSegmentMovement, ref Vector3 rRemainingMovement)
		{
			for (int i = 0; i < this.mBodyShapeHits.Count; i++)
			{
				BodyShapeHit.Release(this.mBodyShapeHits[i]);
			}
			this.mBodyShapeHits.Clear();
			this._Transform.rotation = (this._InvertRotationOrder ? (this.mYaw * this.mTilt) : (this.mTilt * this.mYaw));
			for (int j = 0; j < this.BodyShapes.Count; j++)
			{
				if ((this.mState.IsGrounded || this.BodyShapes[j].IsEnabledAboveGround) && (!this.mState.IsGrounded || this.BodyShapes[j].IsEnabledOnGround) && (!this.mState.IsGrounded || this.mState.GroundSurfaceAngle <= 5f || this.BodyShapes[j].IsEnabledOnSlope))
				{
					Vector3 normalized = rSegmentMovement.normalized;
					BodyShapeHit[] array = this.BodyShapes[j].CollisionCastAll(rSegmentPositionDelta, normalized, rSegmentMovement.magnitude, this._CollisionLayers);
					if (array != null && array.Length != 0)
					{
						for (int k = 0; k < array.Length; k++)
						{
							if (array[k] != null && (!this.mState.IsGrounded || this._MaxStepHeight <= 0f || array[k].HitRootDistance >= this._MaxStepHeight))
							{
								float num = Vector3.Dot(array[k].HitNormal, this._Transform.up);
								if ((this._MaxStepHeight > 0f || num <= 0.8f) && Vector3.Dot(normalized, array[k].HitNormal) <= -0.0001f)
								{
									BodyShapeHit bodyShapeHit = BodyShapeHit.Allocate(array[k]);
									this.mBodyShapeHits.Add(bodyShapeHit);
								}
							}
						}
						for (int l = 0; l < array.Length; l++)
						{
							BodyShapeHit.Release(array[l]);
						}
					}
				}
			}
			if (this.mBodyShapeHits.Count > 1)
			{
				this.mBodyShapeHits = this.mBodyShapeHits.OrderBy((BodyShapeHit x) => x.HitDistance).ToList<BodyShapeHit>();
			}
			if (this.mBodyShapeHits.Count > 0)
			{
				int num2 = 0;
				BodyShapeHit bodyShapeHit2 = this.mBodyShapeHits[num2];
				this.mState.IsColliding = true;
				this.mState.Collider = bodyShapeHit2.HitCollider;
				this.mState.ColliderHit = bodyShapeHit2.Hit;
				this.mState.ColliderHit.point = bodyShapeHit2.HitPoint;
				this.mState.ColliderHit.normal = bodyShapeHit2.HitNormal;
				this.mState.ColliderHitOrigin = bodyShapeHit2.HitOrigin;
				Vector3 vector = Vector3.zero;
				if (bodyShapeHit2.HitDistance > 0.001f)
				{
					vector = rSegmentMovement.normalized * Mathf.Min(bodyShapeHit2.HitDistance - 0.001f, rSegmentMovement.magnitude);
				}
				else if (bodyShapeHit2.HitDistance < 0.001f)
				{
					vector = (bodyShapeHit2.HitPoint - bodyShapeHit2.HitOrigin).normalized * (bodyShapeHit2.HitDistance - 0.001f);
				}
				rRemainingMovement += rSegmentMovement - vector;
				rSegmentMovement = vector;
			}
			return this.mBodyShapeHits.Count > 0;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0002906C File Offset: 0x0002726C
		protected bool ProcessGrounding(Vector3 rActorPosition, Vector3 rOffset, Vector3 rActorUp, Vector3 rWorldUp, float rGroundRadius, out RaycastHit rGroundHitInfo)
		{
			Vector3 vector = rActorPosition + rOffset + rActorUp * this._GroundingStartOffset;
			Vector3 vector2 = -rActorUp;
			float num = this._GroundingStartOffset + this._GroundingDistance;
			bool flag;
			if (this._IsGroundingLayersEnabled)
			{
				flag = RaycastExt.SafeRaycast(vector, vector2, out rGroundHitInfo, num, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false);
			}
			else
			{
				flag = RaycastExt.SafeRaycast(vector, vector2, out rGroundHitInfo, num, -1, this._Transform, this.mIgnoreTransforms, true, false);
			}
			if (flag)
			{
				float num2 = ((!this.mIgnoreUseTransform && this._UseTransformPosition) ? this._AltSkinWidth : this._SkinWidth);
				flag = rGroundHitInfo.distance - this._GroundingStartOffset < num2 + 0.0001f;
				this.mState.Ground = rGroundHitInfo.collider.gameObject.transform;
				this.mState.GroundPosition = this.mState.Ground.position;
				this.mState.GroundRotation = this.mState.Ground.rotation;
				this.mState.GroundSurfaceAngle = Vector3.Angle(rGroundHitInfo.normal, rActorUp);
				this.mState.GroundSurfaceNormal = rGroundHitInfo.normal;
				this.mState.GroundSurfaceDistance = rGroundHitInfo.distance - this._GroundingStartOffset;
				this.mState.GroundSurfacePoint = rGroundHitInfo.point;
				this.mState.GroundSurfaceDirection = vector2;
				Vector3 forward = this._Transform.forward;
				Vector3 groundSurfaceNormal = this.mState.GroundSurfaceNormal;
				Vector3.OrthoNormalize(ref groundSurfaceNormal, ref forward);
				this.mState.GroundSurfaceForwardAngle = -Vector3Ext.SignedAngle(this._Transform.forward, forward, this._Transform.right);
				this.mState.IsGroundSurfaceDirect = true;
				this.mState.GroundSurfaceDirectNormal = this.mState.GroundSurfaceNormal;
				this.mState.GroundSurfaceDirectDistance = this.mState.GroundSurfaceDistance;
				num = rGroundHitInfo.distance + rGroundRadius;
				if (!flag && rGroundHitInfo.collider is TerrainCollider && this.mState.GroundSurfaceAngle > 10f && this.mState.GroundSurfaceDistance < 0.03f)
				{
					flag = true;
				}
			}
			else if (this._KeepOrientationInAir)
			{
				this.mState.GroundSurfaceNormal = this.mPrevState.GroundSurfaceNormal;
				this.mState.GroundSurfaceDirectNormal = this.mPrevState.GroundSurfaceDirectNormal;
			}
			if (!flag)
			{
				bool flag2 = false;
				Vector3 vector3 = rGroundHitInfo.point;
				vector = rActorPosition + rOffset + rActorUp * rGroundRadius;
				Collider[] array = null;
				int num3;
				if (this._IsGroundingLayersEnabled)
				{
					num3 = RaycastExt.SafeOverlapSphere(vector, rGroundRadius * 1.4142135f, out array, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true);
				}
				else
				{
					num3 = RaycastExt.SafeOverlapSphere(vector, rGroundRadius * 1.4142135f, out array, -1, this._Transform, this.mIgnoreTransforms, true);
				}
				if (array == null || num3 == 0)
				{
					flag2 = true;
					flag = false;
				}
				else if (num3 == 1)
				{
					vector3 = GeometryExt.ClosestPoint(vector, array[0], -1);
					if (vector3 != Vector3Ext.Null)
					{
						Vector3 vector4 = this._Transform.InverseTransformPoint(vector3 - rOffset);
						vector4.y = 0f;
						if (vector4.magnitude > rGroundRadius * 0.25f)
						{
							float num4 = ((this._MaxSlopeAngle > 0f) ? (this._MaxSlopeAngle - 0.5f) : 85f);
							if (rGroundHitInfo.collider == array[0] && this.mState.GroundSurfaceAngle < num4 + 0.0001f)
							{
								flag2 = false;
								flag = true;
							}
							else
							{
								flag2 = true;
								flag = false;
								if (this.mState.GroundSurfaceDistance < 0.01f)
								{
									this.mState.GroundSurfaceDistance = float.MaxValue;
								}
							}
						}
					}
				}
				else
				{
					bool flag3 = true;
					int num5 = 0;
					Vector3[] array2 = new Vector3[num3];
					Vector3[] array3 = new Vector3[num3];
					float[] array4 = new float[num3];
					for (int i = 0; i < num3; i++)
					{
						if (!(array[i] == rGroundHitInfo.collider))
						{
							Vector3 vector5 = GeometryExt.ClosestPoint(vector, array[i], -1);
							if (!(vector5 == Vector3Ext.Null))
							{
								Vector3 vector6 = this._Transform.InverseTransformPoint(vector5 - rOffset);
								if (vector6.y < rGroundRadius + 0.0001f && -vector6.y <= this._SkinWidth + 0.0001f)
								{
									vector6.y = 0f;
									if (vector6.magnitude < rGroundRadius * 0.25f)
									{
										vector3 = vector5;
										flag = true;
										flag3 = false;
										break;
									}
									array2[num5] = vector5;
									array3[num5] = vector6;
									array4[num5] = Vector3Ext.SignedAngle(vector6.normalized, this._Transform.forward);
									num5++;
								}
							}
						}
					}
					if (flag3)
					{
						if (num5 > 0)
						{
							flag2 = true;
							for (int j = 0; j < num5; j++)
							{
								for (int k = j + 1; k < num5; k++)
								{
									if (Vector3.Angle(array3[j], array3[k]) > 60f)
									{
										vector3 = array2[j];
										if (Vector3.SqrMagnitude(array2[k] - vector) < Vector3.SqrMagnitude(vector3 - vector))
										{
											vector3 = array2[k];
										}
										flag2 = false;
										flag = true;
										break;
									}
								}
								if (!flag2)
								{
									break;
								}
							}
						}
						else
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						flag = false;
					}
				}
				if (!flag2)
				{
					Vector3 vector7 = this._Transform.InverseTransformPoint(vector3 - rOffset);
					Vector3 vector8 = vector3 - vector;
					vector2 = vector8.normalized;
					num = vector8.magnitude + this._SkinWidth;
					RaycastHit raycastHit;
					bool flag4;
					if (this._IsGroundingLayersEnabled)
					{
						flag4 = RaycastExt.SafeRaycast(vector, vector2, out raycastHit, num, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false);
					}
					else
					{
						flag4 = RaycastExt.SafeRaycast(vector, vector2, out raycastHit, num, -1, this._Transform, this.mIgnoreTransforms, true, false);
					}
					if (flag4)
					{
						flag = raycastHit.distance - rGroundRadius < (this._SkinWidth + 0.0001f) * 1.4142135f;
						this.mState.Ground = raycastHit.collider.gameObject.transform;
						this.mState.GroundPosition = this.mState.Ground.position;
						this.mState.GroundRotation = this.mState.Ground.rotation;
						this.mState.GroundSurfaceAngle = Vector3.Angle(raycastHit.normal, rActorUp);
						this.mState.GroundSurfaceNormal = raycastHit.normal;
						this.mState.GroundSurfaceDistance = -vector7.y;
						this.mState.GroundSurfacePoint = vector3;
						this.mState.GroundSurfaceDirection = vector2;
						this.mState.IsGroundSurfaceDirect = false;
						Vector3 forward2 = this._Transform.forward;
						Vector3 groundSurfaceNormal2 = this.mState.GroundSurfaceNormal;
						Vector3.OrthoNormalize(ref groundSurfaceNormal2, ref forward2);
						this.mState.GroundSurfaceForwardAngle = -Vector3Ext.SignedAngle(this._Transform.forward, forward2, this._Transform.right);
						rGroundHitInfo = raycastHit;
					}
				}
			}
			this.mState.IsGrounded = flag;
			return flag;
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x000297B8 File Offset: 0x000279B8
		protected float GetGroundDistance(Vector3 rPosition, Vector3 rActorUp)
		{
			Vector3 vector = rPosition + rActorUp * this._GroundingStartOffset;
			Vector3 vector2 = -rActorUp;
			float num = this._GroundingStartOffset + this._GroundingDistance;
			bool flag = false;
			RaycastHit raycastHit;
			bool flag2;
			if (this._IsGroundingLayersEnabled)
			{
				flag2 = RaycastExt.SafeRaycast(vector, vector2, out raycastHit, num, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false);
			}
			else
			{
				flag2 = RaycastExt.SafeRaycast(vector, vector2, out raycastHit, num, -1, this._Transform, this.mIgnoreTransforms, true, false);
			}
			float num2 = float.MaxValue;
			if (flag2)
			{
				float num3 = (this._ForceGrounding ? this._ForceGroundingDistance : this._SkinWidth);
				float num4 = ((!this.mIgnoreUseTransform && this._UseTransformPosition) ? this._AltSkinWidth : num3);
				flag = raycastHit.distance - this._GroundingStartOffset < num4 + 0.0001f;
				num2 = raycastHit.distance - this._GroundingStartOffset;
				this.mState.Ground = raycastHit.collider.transform;
				this.mState.GroundSurfacePoint = raycastHit.point;
				this.mState.GroundSurfaceDistance = num2;
				this.mState.GroundSurfaceDirection = vector2;
				this.mState.GroundSurfaceNormal = raycastHit.normal;
				this.mState.GroundSurfaceAngle = Vector3.Angle(raycastHit.normal, rActorUp);
				Vector3 forward = this._Transform.forward;
				Vector3 groundSurfaceNormal = this.mState.GroundSurfaceNormal;
				Vector3.OrthoNormalize(ref groundSurfaceNormal, ref forward);
				this.mState.GroundSurfaceForwardAngle = -Vector3Ext.SignedAngle(this._Transform.forward, forward, this._Transform.right);
				this.mState.IsGroundSurfaceDirect = true;
				this.mState.GroundSurfaceDirectDistance = num2;
				this.mState.GroundSurfaceDirectNormal = raycastHit.normal;
			}
			if (!flag)
			{
				bool flag3 = false;
				Vector3 vector3 = raycastHit.point;
				vector = rPosition + rActorUp * this._BaseRadius;
				if (this._ShowDebug)
				{
					GraphicsManager.DrawSphere(vector, this._BaseRadius, Color.magenta, 0.1f);
					GraphicsManager.DrawSphere(vector, this._BaseRadius * 1.4142135f, Color.magenta, 0.1f);
				}
				Collider[] array = null;
				int num5;
				if (this._IsGroundingLayersEnabled)
				{
					num5 = RaycastExt.SafeOverlapSphere(vector, this._BaseRadius * 1.4142135f, out array, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true);
				}
				else
				{
					num5 = RaycastExt.SafeOverlapSphere(vector, this._BaseRadius * 1.4142135f, out array, -1, this._Transform, this.mIgnoreTransforms, true);
				}
				if (array == null || num5 == 0)
				{
					flag3 = true;
				}
				else if (num5 == 1)
				{
					vector3 = GeometryExt.ClosestPoint(rPosition + this._Transform.up * 0.05f, array[0], -1);
					if (vector3 != Vector3Ext.Null)
					{
						if (this._ShowDebug)
						{
							GraphicsManager.DrawPoint(vector3, Color.red, null, 0f);
						}
						Vector3 vector4 = this._Transform.InverseTransformPoint(vector3);
						vector4.y = 0f;
						flag3 = vector4.magnitude >= this._BaseRadius;
					}
				}
				else
				{
					bool flag4 = true;
					int num6 = 0;
					Vector3[] array2 = new Vector3[num5];
					Vector3[] array3 = new Vector3[num5];
					float[] array4 = new float[num5];
					for (int i = 0; i < num5; i++)
					{
						if (!(array[i] == raycastHit.collider))
						{
							Vector3 vector5 = GeometryExt.ClosestPoint(rPosition + this._Transform.up * 0.05f, array[i], -1);
							if (!(vector5 == Vector3Ext.Null))
							{
								if (this._ShowDebug)
								{
									GraphicsManager.DrawPoint(vector5, Color.red, null, 0f);
								}
								Vector3 vector6 = this._Transform.InverseTransformPoint(vector5);
								if (vector6.y < this._BaseRadius + 0.0001f)
								{
									vector6.y = 0f;
									if (vector6.magnitude < this._BaseRadius)
									{
										vector3 = vector5;
										flag4 = false;
										break;
									}
									array2[num6] = vector5;
									array3[num6] = vector6;
									array4[num6] = Vector3Ext.SignedAngle(vector6.normalized, this._Transform.forward);
									num6++;
								}
							}
						}
					}
					if (flag4)
					{
						if (num6 > 0)
						{
							flag3 = true;
							for (int j = 0; j < num6; j++)
							{
								for (int k = j + 1; k < num6; k++)
								{
									if (Vector3.Angle(array3[j], array3[k]) > 60f)
									{
										vector3 = array2[j];
										if (Vector3.SqrMagnitude(array2[k] - vector) < Vector3.SqrMagnitude(vector3 - vector))
										{
											vector3 = array2[k];
										}
										flag3 = false;
										break;
									}
								}
								if (!flag3)
								{
									break;
								}
							}
						}
						else
						{
							flag3 = true;
						}
					}
					if (flag3)
					{
					}
				}
				if (!flag3)
				{
					Vector3 vector7 = this._Transform.InverseTransformPoint(vector3);
					vector = vector3 + rActorUp * this._BaseRadius;
					vector2 = -rActorUp;
					num = this._BaseRadius + this._SkinWidth;
					RaycastHit raycastHit2;
					bool flag5;
					if (this._IsGroundingLayersEnabled)
					{
						flag5 = RaycastExt.SafeRaycast(vector, vector2, out raycastHit2, num, this._GroundingLayers, this._Transform, this.mIgnoreTransforms, true, false);
					}
					else
					{
						flag5 = RaycastExt.SafeRaycast(vector, vector2, out raycastHit2, num, -1, this._Transform, this.mIgnoreTransforms, true, false);
					}
					if (flag5)
					{
						num2 = raycastHit2.distance - this._BaseRadius - vector7.y;
						flag = num2 < (this._SkinWidth + 0.0001f) * 1.4142135f;
						this.mState.Ground = raycastHit2.collider.gameObject.transform;
						this.mState.GroundPosition = this.mState.Ground.position;
						this.mState.GroundRotation = this.mState.Ground.rotation;
						this.mState.GroundSurfaceAngle = Vector3.Angle(raycastHit2.normal, rActorUp);
						this.mState.GroundSurfaceNormal = raycastHit2.normal;
						this.mState.GroundSurfaceDistance = num2;
						this.mState.GroundSurfacePoint = vector3;
						this.mState.GroundSurfaceDirection = vector2;
						this.mState.IsGroundSurfaceDirect = false;
						Vector3 forward2 = this._Transform.forward;
						Vector3 groundSurfaceNormal2 = this.mState.GroundSurfaceNormal;
						Vector3.OrthoNormalize(ref groundSurfaceNormal2, ref forward2);
						this.mState.GroundSurfaceForwardAngle = -Vector3Ext.SignedAngle(this._Transform.forward, forward2, this._Transform.right);
						if (this._ShowDebug)
						{
							Log.FileScreenWrite(string.Concat(new string[]
							{
								"multip hit grounding l-y:",
								vector7.y.ToString("f3"),
								" angle:",
								this.mState.GroundSurfaceAngle.ToString("f3"),
								" nml:",
								StringHelper.ToString(this.mState.GroundSurfaceNormal)
							}), 6);
						}
						raycastHit = raycastHit2;
					}
				}
			}
			return num2;
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x00029EEC File Offset: 0x000280EC
		protected Vector3 ProcessForces(float rDeltaTime)
		{
			Vector3 vector = Vector3.zero;
			if (this.mAppliedForces != null)
			{
				for (int i = this.mAppliedForces.Count - 1; i >= 0; i--)
				{
					Force force = this.mAppliedForces[i];
					if (force.StartTime == 0f)
					{
						force.StartTime = Time.time;
					}
					if (force.Value.sqrMagnitude == 0f)
					{
						this.mAppliedForces.RemoveAt(i);
						Force.Release(force);
					}
					else if (force.StartTime <= Time.time)
					{
						if (force.Type == ForceMode.Impulse)
						{
							vector += force.Value / this._Mass;
							this.mAppliedForces.RemoveAt(i);
							Force.Release(force);
						}
						else if (force.Duration > 0f && force.StartTime + force.Duration < Time.time)
						{
							this.mAppliedForces.RemoveAt(i);
							Force.Release(force);
						}
						else
						{
							vector += force.Value / this._Mass;
						}
					}
				}
			}
			return vector;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0002A00C File Offset: 0x0002820C
		protected void ProcessPlatforming(ActorState rPrevState)
		{
			Transform ground = rPrevState.Ground;
			bool flag = rPrevState.IsGrounded;
			if (this.mTargetGround != null)
			{
				flag = true;
				ground = this.mTargetGround;
			}
			if (ground == null)
			{
				return;
			}
			Vector3 vector = Vector3.zero;
			Quaternion identity = Quaternion.identity;
			if (flag)
			{
				Quaternion identity2 = Quaternion.identity;
				Quaternion identity3 = Quaternion.identity;
				if (ground != null && ground == rPrevState.PrevGround)
				{
					Matrix4x4 matrix4x = Matrix4x4.TRS(this.mPrevState.GroundPosition, this.mPrevState.GroundRotation, ground.lossyScale);
					Matrix4x4 matrix4x2 = Matrix4x4.TRS(ground.position, ground.rotation, ground.lossyScale);
					if (matrix4x != matrix4x2)
					{
						Vector3 vector2 = matrix4x.inverse.MultiplyVector(this._Transform.forward);
						vector2 = matrix4x2.MultiplyVector(vector2);
						Vector3 vector3 = matrix4x.inverse.MultiplyVector(this._Transform.up);
						vector3 = matrix4x2.MultiplyVector(vector3);
						Quaternion.LookRotation(vector2, vector3).DecomposeSwingTwist(vector3, ref identity2, ref identity3);
						this.mYaw = identity3;
						this.mTilt = identity2;
						if (!this._OrientToGround)
						{
							this.mTilt = QuaternionExt.FromToRotation(vector3, this.mWorldUp) * this.mTilt;
						}
						Vector3 vector4 = matrix4x.inverse.MultiplyPoint(this._Transform.position);
						vector4 = matrix4x2.MultiplyPoint(vector4);
						vector = vector4 - this._Transform.position;
					}
				}
				this.mState.RotationPlatformAdjust = identity;
				this.mState.MovementPlatformAdjust = vector;
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0002A1BC File Offset: 0x000283BC
		public BodyShape GetBodyShape(string rName)
		{
			for (int i = 0; i < this.BodyShapes.Count; i++)
			{
				if (this.BodyShapes[i].Name == rName)
				{
					return this.BodyShapes[i];
				}
			}
			return null;
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0002A206 File Offset: 0x00028406
		public void AddBodyShape(BodyShape rBodyShape)
		{
			if (this.BodyShapes.Contains(rBodyShape))
			{
				return;
			}
			rBodyShape._CharacterController = this;
			rBodyShape._Parent = this._Transform;
			this.BodyShapes.Add(rBodyShape);
			this.SerializeBodyShapes();
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0002A23C File Offset: 0x0002843C
		public void RemoveBodyShape(BodyShape rBodyShape)
		{
			if (rBodyShape == null)
			{
				return;
			}
			if (this.BodyShapes.Contains(rBodyShape))
			{
				rBodyShape.DestroyUnityColliders();
				this.BodyShapes.Remove(rBodyShape);
			}
			this.SerializeBodyShapes();
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0002A26C File Offset: 0x0002846C
		public void RemoveBodyShape(string rName)
		{
			for (int i = this.BodyShapes.Count - 1; i >= 0; i--)
			{
				if (this.BodyShapes[i].Name == rName)
				{
					this.BodyShapes[i].DestroyUnityColliders();
					this.BodyShapes.RemoveAt(i);
				}
			}
			this.SerializeBodyShapes();
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0002A2D0 File Offset: 0x000284D0
		public void RemoveBodyShapes()
		{
			for (int i = this.BodyShapes.Count - 1; i >= 0; i--)
			{
				this.BodyShapes[i].DestroyUnityColliders();
			}
			this.BodyShapes.Clear();
			this.mBodyShapeDefinitions.Clear();
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0002A31C File Offset: 0x0002851C
		public void SerializeBodyShapes()
		{
			this.mBodyShapeDefinitions.Clear();
			for (int i = 0; i < this.BodyShapes.Count; i++)
			{
				string text = this.BodyShapes[i].Serialize();
				this.mBodyShapeDefinitions.Add(text);
			}
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0002A368 File Offset: 0x00028568
		public void DeserializeBodyShapes()
		{
			int count = this.BodyShapes.Count;
			int count2 = this.mBodyShapeDefinitions.Count;
			for (int i = count - 1; i > count2; i--)
			{
				this.BodyShapes.RemoveAt(i);
			}
			for (int j = 0; j < count2; j++)
			{
				string text = this.mBodyShapeDefinitions[j];
				JSONNode jsonnode = JSONNode.Parse(text);
				if (!(jsonnode == null))
				{
					string value = jsonnode["Type"].Value;
					Type type = Type.GetType(value);
					if (!(type == null))
					{
						BodyShape bodyShape;
						if (this.BodyShapes.Count <= j || value != this.BodyShapes[j].GetType().AssemblyQualifiedName)
						{
							bodyShape = Activator.CreateInstance(type) as BodyShape;
							if (this.BodyShapes.Count <= j)
							{
								this.BodyShapes.Add(bodyShape);
							}
							else
							{
								this.BodyShapes[j] = bodyShape;
							}
						}
						else
						{
							bodyShape = this.BodyShapes[j];
						}
						if (bodyShape != null)
						{
							bodyShape._Parent = base.transform;
							bodyShape._CharacterController = this;
							bodyShape.Deserialize(text);
						}
					}
				}
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0002A77A File Offset: 0x0002897A
		GameObject ICharacterController.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x04000368 RID: 872
		public const float EPSILON = 0.0001f;

		// Token: 0x04000369 RID: 873
		public const float EPSILON_SQR = 1E-08f;

		// Token: 0x0400036A RID: 874
		public const float ONE_OVER_COS45 = 1.4142135f;

		// Token: 0x0400036B RID: 875
		public const float COLLISION_BUFFER = 0.001f;

		// Token: 0x0400036C RID: 876
		public const float MAX_SEGMENTS = 20f;

		// Token: 0x0400036D RID: 877
		public const float MAX_GROUNDING_ANGLE = 85f;

		// Token: 0x0400036E RID: 878
		public bool _IsEnabled = true;

		// Token: 0x0400036F RID: 879
		public bool _UseTransformPosition;

		// Token: 0x04000370 RID: 880
		public bool _UseTransformRotation = true;

		// Token: 0x04000371 RID: 881
		public bool _ProcessInLateUpdate = true;

		// Token: 0x04000372 RID: 882
		public int _StateCount = 20;

		// Token: 0x04000373 RID: 883
		public bool _InvertRotationOrder;

		// Token: 0x04000374 RID: 884
		public bool _ExtrapolatePhysics;

		// Token: 0x04000375 RID: 885
		public bool _IsGravityEnabled = true;

		// Token: 0x04000376 RID: 886
		public bool _IsGravityRelative;

		// Token: 0x04000377 RID: 887
		public Vector3 _Gravity = new Vector3(0f, 0f, 0f);

		// Token: 0x04000378 RID: 888
		public bool _ApplyGravityInFixedUpdate;

		// Token: 0x04000379 RID: 889
		public float _Height = 1.8f;

		// Token: 0x0400037A RID: 890
		public float _Radius = 0.35f;

		// Token: 0x0400037B RID: 891
		public float _Mass = 2f;

		// Token: 0x0400037C RID: 892
		protected Vector3 mCenter = new Vector3(0f, 0.9f, 0f);

		// Token: 0x0400037D RID: 893
		public float _SkinWidth = 0.01f;

		// Token: 0x0400037E RID: 894
		public float _AltSkinWidth = 0.5f;

		// Token: 0x0400037F RID: 895
		public float _GroundingStartOffset = 1f;

		// Token: 0x04000380 RID: 896
		public float _GroundingDistance = 3f;

		// Token: 0x04000381 RID: 897
		public bool _IsGroundingLayersEnabled;

		// Token: 0x04000382 RID: 898
		public int _GroundingLayers = 1;

		// Token: 0x04000383 RID: 899
		public float _GroundDampenFactor = 0.92f;

		// Token: 0x04000384 RID: 900
		public float _BaseRadius = 0.1f;

		// Token: 0x04000385 RID: 901
		public bool _FixGroundPenetration = true;

		// Token: 0x04000386 RID: 902
		public bool _ForceGrounding = true;

		// Token: 0x04000387 RID: 903
		public float _ForceGroundingDistance = 0.3f;

		// Token: 0x04000388 RID: 904
		public bool _IsCollisionEnabled = true;

		// Token: 0x04000389 RID: 905
		public bool _StopOnRotationCollision;

		// Token: 0x0400038A RID: 906
		public bool _AllowPushback;

		// Token: 0x0400038B RID: 907
		public int _CollisionLayers = 1;

		// Token: 0x0400038C RID: 908
		public float _OverlapRadius = 0.9f;

		// Token: 0x0400038D RID: 909
		public Vector3 _OverlapCenter = new Vector3(0f, 0.9f, 0f);

		// Token: 0x0400038E RID: 910
		public bool _IsSlidingEnabled;

		// Token: 0x0400038F RID: 911
		public float _MinSlopeAngle = 20f;

		// Token: 0x04000390 RID: 912
		public float _MinSlopeGravityCoefficient = 1f;

		// Token: 0x04000391 RID: 913
		public float _MaxSlopeAngle = 45f;

		// Token: 0x04000392 RID: 914
		public bool _UseStepHeightWithMaxSlope = true;

		// Token: 0x04000393 RID: 915
		public float _SlopeMovementStep = 0.01f;

		// Token: 0x04000394 RID: 916
		public bool _OrientToGround;

		// Token: 0x04000395 RID: 917
		public bool _KeepOrientationInAir;

		// Token: 0x04000396 RID: 918
		public float _OrientToGroundDistance = 2f;

		// Token: 0x04000397 RID: 919
		public float _OrientToGroundSpeed = 1f;

		// Token: 0x04000398 RID: 920
		public float _MinOrientToGroundAngleForSpeed = 5f;

		// Token: 0x04000399 RID: 921
		public float _MaxStepHeight = 0.3f;

		// Token: 0x0400039A RID: 922
		public float _MinStepDepth = 0.25f;

		// Token: 0x0400039B RID: 923
		public float _StepUpSpeed = 0.75f;

		// Token: 0x0400039C RID: 924
		public float _MaxStepUpAngle = 5f;

		// Token: 0x0400039D RID: 925
		public float _StepDownSpeed = 0.75f;

		// Token: 0x0400039E RID: 926
		public bool _FreezePositionX;

		// Token: 0x0400039F RID: 927
		public bool _FreezePositionY;

		// Token: 0x040003A0 RID: 928
		public bool _FreezePositionZ;

		// Token: 0x040003A1 RID: 929
		public bool _FreezeRotationX;

		// Token: 0x040003A2 RID: 930
		public bool _FreezeRotationY;

		// Token: 0x040003A3 RID: 931
		public bool _FreezeRotationZ;

		// Token: 0x040003A4 RID: 932
		protected bool mOverrideProcessing;

		// Token: 0x040003A5 RID: 933
		public bool _ShowDebug;

		// Token: 0x040003A6 RID: 934
		[NonSerialized]
		public List<BodyShape> BodyShapes = new List<BodyShape>();

		// Token: 0x040003A7 RID: 935
		protected float mGroundedDuration;

		// Token: 0x040003A8 RID: 936
		protected float mFallDuration;

		// Token: 0x040003A9 RID: 937
		protected Quaternion mYaw = Quaternion.identity;

		// Token: 0x040003AA RID: 938
		protected Quaternion mTilt = Quaternion.identity;

		// Token: 0x040003AB RID: 939
		protected ActorState mState = new ActorState();

		// Token: 0x040003AC RID: 940
		protected ActorState mPrevState = new ActorState();

		// Token: 0x040003AD RID: 941
		private Vector3 mAccumulatedVelocity = Vector3.zero;

		// Token: 0x040003AE RID: 942
		private Vector3 mAccumulatedMovement = Vector3.zero;

		// Token: 0x040003AF RID: 943
		private Vector3 mAccumulatedForceVelocity = Vector3.zero;

		// Token: 0x040003B0 RID: 944
		protected List<Force> mAppliedForces = new List<Force>();

		// Token: 0x040003B1 RID: 945
		protected bool mIgnoreUseTransform;

		// Token: 0x040003B2 RID: 946
		protected ControllerLateUpdateDelegate mOnControllerPreLateUpdate;

		// Token: 0x040003B3 RID: 947
		protected ControllerLateUpdateDelegate mOnControllerPostLateUpdate;

		// Token: 0x040003B4 RID: 948
		protected ControllerMoveDelegate mOnPreControllerMove;

		// Token: 0x040003B5 RID: 949
		protected int mStateIndex;

		// Token: 0x040003B6 RID: 950
		protected ActorState[] mStates;

		// Token: 0x040003B7 RID: 951
		protected float mFixedUpdates;

		// Token: 0x040003B8 RID: 952
		protected Vector3 mWorldUp = Vector3.up;

		// Token: 0x040003B9 RID: 953
		protected float mOrientToSpeed;

		// Token: 0x040003BA RID: 954
		protected Vector3 mOrientToGroundNormal = Vector3.up;

		// Token: 0x040003BB RID: 955
		protected Vector3 mOrientToGroundNormalTarget = Vector3.up;

		// Token: 0x040003BC RID: 956
		protected Transform mTargetGround;

		// Token: 0x040003BD RID: 957
		protected Vector3 mTargetGroundNormal = Vector3.zero;

		// Token: 0x040003BE RID: 958
		protected Quaternion mTargetRotation = new Quaternion(float.MaxValue, 0f, 0f, 0f);

		// Token: 0x040003BF RID: 959
		protected Quaternion mTargetRotate = Quaternion.identity;

		// Token: 0x040003C0 RID: 960
		protected Quaternion mTargetTilt = Quaternion.identity;

		// Token: 0x040003C1 RID: 961
		protected Vector3 mTargetRotationVelocity = Vector3.zero;

		// Token: 0x040003C2 RID: 962
		protected Vector3 mTargetPosition = new Vector3(float.MaxValue, 0f, 0f);

		// Token: 0x040003C3 RID: 963
		protected Vector3 mTargetMove = Vector3.zero;

		// Token: 0x040003C4 RID: 964
		protected Vector3 mTargetVelocity = Vector3.zero;

		// Token: 0x040003C5 RID: 965
		protected Vector3 mBorrowedFixedMovement = Vector3.zero;

		// Token: 0x040003C6 RID: 966
		protected float mCurrentStepSpeed;

		// Token: 0x040003C7 RID: 967
		protected List<BodyShapeHit> mBodyShapeHits = new List<BodyShapeHit>();

		// Token: 0x040003C8 RID: 968
		[SerializeField]
		protected List<string> mBodyShapeDefinitions = new List<string>();

		// Token: 0x040003C9 RID: 969
		[NonSerialized]
		protected List<Collider> mIgnoreCollisions;

		// Token: 0x040003CA RID: 970
		protected List<Transform> mIgnoreTransforms;

		// Token: 0x040003CB RID: 971
		protected Vector3 mSmoothStepModifier = Vector3.zero;

		// Token: 0x040003CC RID: 972
		public int EditorBodyShapeIndex;

		// Token: 0x040003CD RID: 973
		public bool EditorShowAdvanced;

		// Token: 0x040003CE RID: 974
		public bool EditorCollideWithObjects = true;

		// Token: 0x040003CF RID: 975
		public bool EditorWalkOnWalls;

		// Token: 0x040003D0 RID: 976
		public bool EditorSlideOnSlopes;

		// Token: 0x040003D1 RID: 977
		public bool EditorRespondToColliders;
	}
}
