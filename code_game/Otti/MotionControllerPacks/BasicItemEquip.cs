using System;
using com.ootii.Actors;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Actors.Inventory;
using com.ootii.Actors.LifeCores;
using com.ootii.Cameras;
using com.ootii.Data.Serializers;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Timing;
using UnityEngine;

namespace com.ootii.MotionControllerPacks
{
	// Token: 0x02000005 RID: 5
	[MotionName("Basic Item Equip")]
	[MotionDescription("Equip the item based on the specified animation style.")]
	public class BasicItemEquip : MotionControllerMotion, IEquipStoreMotion
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002BCF File Offset: 0x00000DCF
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002BD2 File Offset: 0x00000DD2
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002BDA File Offset: 0x00000DDA
		public string SlotID
		{
			get
			{
				return this._SlotID;
			}
			set
			{
				this._SlotID = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002BE3 File Offset: 0x00000DE3
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002BEB File Offset: 0x00000DEB
		public string ItemID
		{
			get
			{
				return this._ItemID;
			}
			set
			{
				this._ItemID = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002BF4 File Offset: 0x00000DF4
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002BFC File Offset: 0x00000DFC
		public string ResourcePath
		{
			get
			{
				return this._ResourcePath;
			}
			set
			{
				this._ResourcePath = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002C05 File Offset: 0x00000E05
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002C0D File Offset: 0x00000E0D
		public bool AddCombatantBodyShape
		{
			get
			{
				return this._AddCombatantBodyShape;
			}
			set
			{
				this._AddCombatantBodyShape = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002C16 File Offset: 0x00000E16
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002C1E File Offset: 0x00000E1E
		public float CombatantBodyShapeRadius
		{
			get
			{
				return this._CombatantBodyShapeRadius;
			}
			set
			{
				this._CombatantBodyShapeRadius = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002C27 File Offset: 0x00000E27
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002C2F File Offset: 0x00000E2F
		[SerializationIgnore]
		public string OverrideSlotID
		{
			get
			{
				return this._OverrideSlotID;
			}
			set
			{
				this._OverrideSlotID = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002C38 File Offset: 0x00000E38
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002C40 File Offset: 0x00000E40
		[SerializationIgnore]
		public string OverrideItemID
		{
			get
			{
				return this._OverrideItemID;
			}
			set
			{
				this._OverrideItemID = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002C49 File Offset: 0x00000E49
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002C51 File Offset: 0x00000E51
		public IInventorySource InventorySource
		{
			get
			{
				return this.mInventorySource;
			}
			set
			{
				this.mInventorySource = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002C5A File Offset: 0x00000E5A
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002C62 File Offset: 0x00000E62
		public bool IsEquipped
		{
			get
			{
				return this.mIsEquipped;
			}
			set
			{
				this.mIsEquipped = value;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002C6C File Offset: 0x00000E6C
		public BasicItemEquip()
		{
			this._Pack = BasicIdle.GroupName();
			this._Category = 0;
			this._Priority = 20f;
			this._ActionAlias = "";
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002CE8 File Offset: 0x00000EE8
		public BasicItemEquip(MotionController rController)
			: base(rController)
		{
			this._Pack = BasicIdle.GroupName();
			this._Category = 0;
			this._Priority = 20f;
			this._ActionAlias = "";
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002D62 File Offset: 0x00000F62
		public override void Awake()
		{
			base.Awake();
			if (this.mInventorySource == null && this.mMotionController != null)
			{
				this.mInventorySource = this.mMotionController.gameObject.GetComponent<IInventorySource>();
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002D98 File Offset: 0x00000F98
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mActorController.IsGrounded && this.mMotionController._InputSource != null && this.mMotionLayer._AnimatorTransitionID == 0 && (this.mInventorySource == null || this.mInventorySource.AllowMotionSelfActivation) && (this._ActionAlias.Length > 0 && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias));
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002E1C File Offset: 0x0000101C
		public override bool TestUpdate()
		{
			return this.mIsActivatedFrame || this.mAge <= 0.2f || !this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Exit");
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002E74 File Offset: 0x00001074
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			if (rMotion.Category != 9 && !this.mIsEquipped && this.CreateItem() != null)
			{
				this.mIsEquipped = true;
			}
			return base.TestInterruption(rMotion);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002EA4 File Offset: 0x000010A4
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIsEquipped = false;
			string text = ((this._OverrideItemID != null && this._OverrideItemID.Length > 0) ? this._OverrideItemID : this._ItemID);
			string text2 = ((this._OverrideSlotID != null && this._OverrideSlotID.Length > 0) ? this._OverrideSlotID : this._SlotID);
			if (this.mInventorySource != null)
			{
				string itemID = this.mInventorySource.GetItemID(text2, true);
				if (itemID != null && itemID.Length > 0 && text != null && text.Length > 0 && text == itemID)
				{
					return false;
				}
			}
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this._Form, 0, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002F66 File Offset: 0x00001166
		public override void Deactivate()
		{
			this._OverrideSlotID = "";
			this._OverrideItemID = "";
			base.Deactivate();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002F84 File Offset: 0x00001184
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rMovement = Vector3.zero;
			rRotation = Quaternion.identity;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002F9D File Offset: 0x0000119D
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002FA0 File Offset: 0x000011A0
		public override void OnAnimationEvent(AnimationEvent rEvent)
		{
			if (rEvent == null)
			{
				return;
			}
			if ((rEvent.stringParameter.Length == 0 || StringHelper.CleanString(rEvent.stringParameter) == BasicItemEquip.EVENT_EQUIP) && !this.mIsEquipped && this.CreateItem() != null)
			{
				this.mIsEquipped = true;
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002FF4 File Offset: 0x000011F4
		protected virtual void RotateToView(float rSpeed)
		{
			Vector3 forward = this.mMotionController._CameraTransform.forward;
			float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mMotionController._Transform.forward, forward, this.mMotionController._Transform.up);
			if (horizontalAngle == 0f)
			{
				return;
			}
			BaseCameraRig baseCameraRig = this.mMotionController.CameraRig as BaseCameraRig;
			if (baseCameraRig != null)
			{
				baseCameraRig.FrameLockForward = true;
			}
			float num = Mathf.Sign(horizontalAngle);
			float num2 = Mathf.Abs(horizontalAngle);
			float num3 = rSpeed / 60f * TimeManager.Relative60FPSDeltaTime;
			if (num2 <= num3)
			{
				num3 = num2;
			}
			this.mRotation = Quaternion.AngleAxis(num * num3, this.mMotionController._Transform.up);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000030A4 File Offset: 0x000012A4
		protected virtual GameObject CreateItem()
		{
			string text = "";
			string text2 = "";
			if (this.OverrideItemID != null && this.OverrideItemID.Length > 0)
			{
				text2 = this.OverrideItemID;
			}
			else if (this.ResourcePath.Length > 0)
			{
				text = this.ResourcePath;
			}
			else if (this.ItemID.Length > 0)
			{
				text2 = this.ItemID;
			}
			string text3;
			if (this.OverrideSlotID != null && this.OverrideSlotID.Length > 0)
			{
				text3 = this.OverrideSlotID;
			}
			else
			{
				text3 = this.SlotID;
			}
			ICombatant component = this.mMotionController.gameObject.GetComponent<ICombatant>();
			GameObject gameObject = null;
			if (this.mInventorySource != null)
			{
				gameObject = this.mInventorySource.EquipItem(text2, text3, text);
			}
			else
			{
				gameObject = this.EquipItem(text2, text3, text);
			}
			if (component != null)
			{
				try
				{
					component.PrimaryWeapon = gameObject.GetComponent<IWeaponCore>();
					if (component.PrimaryWeapon != null)
					{
						component.PrimaryWeapon.Owner = this.mMotionController.gameObject;
					}
				}
				catch
				{
				}
				if (this._AddCombatantBodyShape)
				{
					BodyCapsule bodyCapsule = new BodyCapsule();
					bodyCapsule.Name = "Combatant Shape";
					bodyCapsule.Radius = this._CombatantBodyShapeRadius;
					bodyCapsule.Offset = new Vector3(0f, 1f, 0f);
					bodyCapsule.EndOffset = new Vector3(0f, 1.2f, 0f);
					bodyCapsule.IsEnabledOnGround = true;
					bodyCapsule.IsEnabledOnSlope = true;
					bodyCapsule.IsEnabledAboveGround = true;
					this.mActorController.AddBodyShape(bodyCapsule);
				}
			}
			return gameObject;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003238 File Offset: 0x00001438
		public virtual GameObject EquipItem(string rItemID, string rSlotID, string rResourcePath = "")
		{
			Vector3 zero = Vector3.zero;
			Quaternion identity = Quaternion.identity;
			GameObject gameObject = this.CreateAndMountItem(this.mMotionController.gameObject, rResourcePath, zero, identity, rSlotID, "Handle");
			if (gameObject != null)
			{
				IItemCore component = gameObject.GetComponent<IItemCore>();
				if (component != null)
				{
					component.OnEquipped();
				}
			}
			return gameObject;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000328C File Offset: 0x0000148C
		protected virtual GameObject CreateAndMountItem(GameObject rParent, string rResourcePath, Vector3 rLocalPosition, Quaternion rLocalRotation, string rParentMountPoint = "Left Hand", string rItemMountPoint = "Handle")
		{
			GameObject gameObject = null;
			if (rResourcePath.Length > 0)
			{
				if (gameObject == null)
				{
					if (rParent.GetComponentInChildren<Animator>() != null)
					{
						Object @object = Resources.Load(rResourcePath);
						if (@object != null)
						{
							gameObject = Object.Instantiate(@object) as GameObject;
							this.MountItem(rParent, gameObject, rLocalPosition, rLocalRotation, rParentMountPoint, "Handle");
						}
						else
						{
							Debug.LogWarning("Resource not found. Resource Path: " + rResourcePath);
						}
					}
				}
				else
				{
					ICombatant component = this.mMotionController.gameObject.GetComponent<ICombatant>();
					if (component != null)
					{
						IWeaponCore component2 = gameObject.GetComponent<IWeaponCore>();
						if (component2 != null)
						{
							string text = StringHelper.CleanString(rParentMountPoint);
							if (text == "righthand")
							{
								component.PrimaryWeapon = component2;
							}
							else if (text == "lefthand" || text == "leftlowerarm")
							{
								component.SecondaryWeapon = component2;
							}
						}
					}
				}
			}
			return gameObject;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003368 File Offset: 0x00001568
		protected virtual void MountItem(GameObject rParent, GameObject rItem, Vector3 rLocalPosition, Quaternion rLocalRotation, string rParentMountPoint, string rItemMountPoint = "Handle")
		{
			if (rParent == null || rItem == null)
			{
				return;
			}
			if (!false)
			{
				Transform transform = this.FindTransform(rParent.transform, rParentMountPoint);
				rItem.transform.parent = transform;
				IItemCore component = rItem.GetComponent<IItemCore>();
				if (component != null)
				{
					component.Owner = this.mMotionController.gameObject;
					if (rLocalPosition.sqrMagnitude == 0f && rLocalRotation.IsIdentity())
					{
						rItem.transform.localPosition = ((component != null) ? component.LocalPosition : Vector3.zero);
						rItem.transform.localRotation = ((component != null) ? component.LocalRotation : Quaternion.identity);
					}
					else
					{
						rItem.transform.localPosition = rLocalPosition;
						rItem.transform.localRotation = rLocalRotation;
					}
				}
				else
				{
					rItem.transform.localPosition = rLocalPosition;
					rItem.transform.localRotation = rLocalRotation;
				}
			}
			if (rItem != null)
			{
				rItem.SetActive(true);
				rItem.hideFlags = HideFlags.None;
				ICombatant component2 = this.mMotionController.gameObject.GetComponent<ICombatant>();
				if (component2 != null)
				{
					IWeaponCore component3 = rItem.GetComponent<IWeaponCore>();
					if (component3 != null)
					{
						string text = StringHelper.CleanString(rParentMountPoint);
						if (text == "righthand")
						{
							component2.PrimaryWeapon = component3;
							return;
						}
						if (text == "lefthand" || text == "leftlowerarm")
						{
							component2.SecondaryWeapon = component3;
						}
					}
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000034C0 File Offset: 0x000016C0
		protected Transform FindTransform(Transform rParent, string rName)
		{
			Transform transform = null;
			if (transform == null)
			{
				Animator componentInChildren = rParent.GetComponentInChildren<Animator>();
				if (componentInChildren != null)
				{
					if (BasicInventory.UnityBones == null)
					{
						BasicInventory.UnityBones = Enum.GetNames(typeof(HumanBodyBones));
						for (int i = 0; i < BasicInventory.UnityBones.Length; i++)
						{
							BasicInventory.UnityBones[i] = StringHelper.CleanString(BasicInventory.UnityBones[i]);
						}
					}
					string text = StringHelper.CleanString(rName);
					for (int j = 0; j < BasicInventory.UnityBones.Length; j++)
					{
						if (BasicInventory.UnityBones[j] == text)
						{
							transform = componentInChildren.GetBoneTransform((HumanBodyBones)j);
							break;
						}
					}
				}
			}
			if (transform == null)
			{
				transform = rParent.transform.FindTransform(rName);
			}
			if (transform == null)
			{
				transform = rParent.transform;
			}
			return transform;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004B RID: 75 RVA: 0x0000358A File Offset: 0x0000178A
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x04000013 RID: 19
		public static string EVENT_EQUIP = "equip";

		// Token: 0x04000014 RID: 20
		public int PHASE_UNKNOWN;

		// Token: 0x04000015 RID: 21
		public int PHASE_START = 3150;

		// Token: 0x04000016 RID: 22
		public string _SlotID = "RIGHT_HAND";

		// Token: 0x04000017 RID: 23
		public string _ItemID = "Sword_01";

		// Token: 0x04000018 RID: 24
		public string _ResourcePath = "";

		// Token: 0x04000019 RID: 25
		public bool _AddCombatantBodyShape = true;

		// Token: 0x0400001A RID: 26
		public float _CombatantBodyShapeRadius = 0.8f;

		// Token: 0x0400001B RID: 27
		[NonSerialized]
		public string _OverrideSlotID;

		// Token: 0x0400001C RID: 28
		[NonSerialized]
		public string _OverrideItemID;

		// Token: 0x0400001D RID: 29
		[NonSerialized]
		protected IInventorySource mInventorySource;

		// Token: 0x0400001E RID: 30
		protected bool mIsEquipped;
	}
}
