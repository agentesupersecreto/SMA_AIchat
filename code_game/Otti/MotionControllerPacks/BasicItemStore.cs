using System;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Actors.Inventory;
using com.ootii.Data.Serializers;
using com.ootii.Geometry;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.MotionControllerPacks
{
	// Token: 0x02000006 RID: 6
	[MotionName("Basic Item Store")]
	[MotionDescription("Store the item based on the specified animation style.")]
	public class BasicItemStore : MotionControllerMotion, IEquipStoreMotion
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00003599 File Offset: 0x00001799
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004E RID: 78 RVA: 0x0000359C File Offset: 0x0000179C
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000035A4 File Offset: 0x000017A4
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

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000035AD File Offset: 0x000017AD
		// (set) Token: 0x06000051 RID: 81 RVA: 0x000035B5 File Offset: 0x000017B5
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

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000052 RID: 82 RVA: 0x000035BE File Offset: 0x000017BE
		// (set) Token: 0x06000053 RID: 83 RVA: 0x000035C6 File Offset: 0x000017C6
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

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000035CF File Offset: 0x000017CF
		// (set) Token: 0x06000055 RID: 85 RVA: 0x000035D7 File Offset: 0x000017D7
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

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000035E0 File Offset: 0x000017E0
		// (set) Token: 0x06000057 RID: 87 RVA: 0x000035E8 File Offset: 0x000017E8
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

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000035F1 File Offset: 0x000017F1
		// (set) Token: 0x06000059 RID: 89 RVA: 0x000035F9 File Offset: 0x000017F9
		public GameObject EquippedItem
		{
			get
			{
				return this.mEquippedItem;
			}
			set
			{
				this.mEquippedItem = value;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003604 File Offset: 0x00001804
		public BasicItemStore()
		{
			this._Pack = BasicIdle.GroupName();
			this._Category = 0;
			this._Priority = 8f;
			this._ActionAlias = "";
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003658 File Offset: 0x00001858
		public BasicItemStore(MotionController rController)
			: base(rController)
		{
			this._Pack = BasicIdle.GroupName();
			this._Category = 0;
			this._Priority = 8f;
			this._ActionAlias = "";
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000036AA File Offset: 0x000018AA
		public override void Awake()
		{
			base.Awake();
			if (this.mInventorySource == null && this.mMotionController != null)
			{
				this.mInventorySource = this.mMotionController.gameObject.GetComponent<IInventorySource>();
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000036E0 File Offset: 0x000018E0
		public override bool TestActivate()
		{
			return this.mIsStartable && this.mActorController.IsGrounded && this.mMotionController._InputSource != null && this.mMotionLayer._AnimatorTransitionID == 0 && (this.mInventorySource == null || this.mInventorySource.AllowMotionSelfActivation) && (this._ActionAlias.Length > 0 && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias));
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003764 File Offset: 0x00001964
		public override bool TestUpdate()
		{
			return this.mAge <= 0.2f || !this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Exit");
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000037B2 File Offset: 0x000019B2
		public override bool TestInterruption(MotionControllerMotion rMotion)
		{
			if (rMotion.Category != 9 && this.mIsEquipped)
			{
				this.mIsEquipped = false;
				this.StoreItem();
			}
			return base.TestInterruption(rMotion);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000037DA File Offset: 0x000019DA
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIsEquipped = true;
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this._Form, 0, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000380E File Offset: 0x00001A0E
		public override void Deactivate()
		{
			this._OverrideSlotID = "";
			this._OverrideItemID = "";
			base.Deactivate();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000382C File Offset: 0x00001A2C
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rMovement = Vector3.zero;
			rRotation = Quaternion.identity;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003845 File Offset: 0x00001A45
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003847 File Offset: 0x00001A47
		public override void OnAnimationEvent(AnimationEvent rEvent)
		{
			if (rEvent == null)
			{
				return;
			}
			if ((rEvent.stringParameter.Length == 0 || StringHelper.CleanString(rEvent.stringParameter) == BasicItemStore.EVENT_STORE) && this.mIsEquipped)
			{
				this.mIsEquipped = false;
				this.StoreItem();
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003888 File Offset: 0x00001A88
		protected virtual void StoreItem()
		{
			string text;
			if (this.OverrideSlotID.Length > 0)
			{
				text = this.OverrideSlotID;
			}
			else
			{
				text = this.SlotID;
			}
			GameObject gameObject = this.mEquippedItem;
			ICombatant component = this.mMotionController.gameObject.GetComponent<ICombatant>();
			if (component != null)
			{
				if (component.PrimaryWeapon != null)
				{
					gameObject = component.PrimaryWeapon.gameObject;
					component.PrimaryWeapon.Owner = null;
				}
				component.PrimaryWeapon = null;
			}
			if (this.mInventorySource != null)
			{
				this.mInventorySource.StoreItem(text);
			}
			else
			{
				if (gameObject == null)
				{
					Transform transform = this.FindTransform(this.mMotionController._Transform, this._SlotID);
					Transform child = transform.GetChild(transform.childCount - 1);
					if (child != null)
					{
						gameObject = child.gameObject;
					}
				}
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
					this.mEquippedItem = null;
				}
			}
			this.mMotionController._ActorController.RemoveBodyShape("Combatant Shape");
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000397C File Offset: 0x00001B7C
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

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00003A46 File Offset: 0x00001C46
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0400001F RID: 31
		public static string EVENT_STORE = "store";

		// Token: 0x04000020 RID: 32
		public int PHASE_UNKNOWN;

		// Token: 0x04000021 RID: 33
		public int PHASE_START = 3155;

		// Token: 0x04000022 RID: 34
		public string _SlotID = "RIGHT_HAND";

		// Token: 0x04000023 RID: 35
		[NonSerialized]
		public string _OverrideSlotID;

		// Token: 0x04000024 RID: 36
		[NonSerialized]
		public string _OverrideItemID;

		// Token: 0x04000025 RID: 37
		[NonSerialized]
		protected IInventorySource mInventorySource;

		// Token: 0x04000026 RID: 38
		protected bool mIsEquipped;

		// Token: 0x04000027 RID: 39
		protected GameObject mEquippedItem;
	}
}
