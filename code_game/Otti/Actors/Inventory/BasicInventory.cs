using System;
using System.Collections;
using System.Collections.Generic;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Actors.LifeCores;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Input;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.Inventory
{
	// Token: 0x020000B4 RID: 180
	public class BasicInventory : MonoBehaviour, IInventorySource
	{
		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000A09 RID: 2569 RVA: 0x00032188 File Offset: 0x00030388
		// (set) Token: 0x06000A0A RID: 2570 RVA: 0x00032190 File Offset: 0x00030390
		public bool IsEnabled
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

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00032199 File Offset: 0x00030399
		// (set) Token: 0x06000A0C RID: 2572 RVA: 0x000321A1 File Offset: 0x000303A1
		public GameObject InputSourceOwner
		{
			get
			{
				return this._InputSourceOwner;
			}
			set
			{
				this._InputSourceOwner = value;
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x000321AA File Offset: 0x000303AA
		// (set) Token: 0x06000A0E RID: 2574 RVA: 0x000321B2 File Offset: 0x000303B2
		public IInputSource InputSource
		{
			get
			{
				return this._InputSource;
			}
			set
			{
				this._InputSource = value;
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x000321BB File Offset: 0x000303BB
		// (set) Token: 0x06000A10 RID: 2576 RVA: 0x000321C3 File Offset: 0x000303C3
		public bool AutoFindInputSource
		{
			get
			{
				return this._AutoFindInputSource;
			}
			set
			{
				this._AutoFindInputSource = value;
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x000321CC File Offset: 0x000303CC
		// (set) Token: 0x06000A12 RID: 2578 RVA: 0x000321D4 File Offset: 0x000303D4
		public bool UseNumberKeys
		{
			get
			{
				return this._UseNumberKeys;
			}
			set
			{
				this._UseNumberKeys = value;
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000A13 RID: 2579 RVA: 0x000321DD File Offset: 0x000303DD
		// (set) Token: 0x06000A14 RID: 2580 RVA: 0x000321E5 File Offset: 0x000303E5
		public string ToggleWeaponSetAlias
		{
			get
			{
				return this._ToggleWeaponSetAlias;
			}
			set
			{
				this._ToggleWeaponSetAlias = value;
			}
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x000321EE File Offset: 0x000303EE
		// (set) Token: 0x06000A16 RID: 2582 RVA: 0x000321F6 File Offset: 0x000303F6
		public string ShiftWeaponSetAlias
		{
			get
			{
				return this._ShiftWeaponSetAlias;
			}
			set
			{
				this._ShiftWeaponSetAlias = value;
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x000321FF File Offset: 0x000303FF
		// (set) Token: 0x06000A18 RID: 2584 RVA: 0x00032207 File Offset: 0x00030407
		public virtual bool AllowMotionSelfActivation
		{
			get
			{
				return this._AllowMotionSelfActivation;
			}
			set
			{
				this._AllowMotionSelfActivation = value;
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000A19 RID: 2585 RVA: 0x00032210 File Offset: 0x00030410
		// (set) Token: 0x06000A1A RID: 2586 RVA: 0x00032218 File Offset: 0x00030418
		public virtual int ActiveWeaponSet
		{
			get
			{
				return this._ActiveWeaponSet;
			}
			set
			{
				this._ActiveWeaponSet = value;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000A1B RID: 2587 RVA: 0x00032221 File Offset: 0x00030421
		// (set) Token: 0x06000A1C RID: 2588 RVA: 0x00032229 File Offset: 0x00030429
		public bool EquipOnStart
		{
			get
			{
				return this._EquipOnStart;
			}
			set
			{
				this._EquipOnStart = value;
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000A1D RID: 2589 RVA: 0x00032232 File Offset: 0x00030432
		public bool IsEquippingItem
		{
			get
			{
				return this.mIsEquippingItem;
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x0003223C File Offset: 0x0003043C
		public virtual bool IsEquipStoreAllowed
		{
			get
			{
				if (this.mMotionController != null)
				{
					MotionControllerMotion activeMotion = this.mMotionController.ActiveMotion;
					return activeMotion == null || activeMotion.Category == 1 || activeMotion.Category == 2 || activeMotion.Category == 3 || activeMotion is IWalkRunMotion;
				}
				return true;
			}
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00032298 File Offset: 0x00030498
		protected virtual void Awake()
		{
			if (BasicInventory.UnityBones == null)
			{
				BasicInventory.UnityBones = Enum.GetNames(typeof(HumanBodyBones));
				for (int i = 0; i < BasicInventory.UnityBones.Length; i++)
				{
					BasicInventory.UnityBones[i] = StringHelper.CleanString(BasicInventory.UnityBones[i]);
				}
			}
			if (this._InputSourceOwner != null)
			{
				this._InputSource = InterfaceHelper.GetComponent<IInputSource>(this._InputSourceOwner);
			}
			if (this._AutoFindInputSource && this._InputSource == null)
			{
				this._InputSource = InterfaceHelper.GetComponent<IInputSource>(base.gameObject);
				if (this._InputSource != null)
				{
					this._InputSourceOwner = base.gameObject;
				}
			}
			if (this._AutoFindInputSource && this._InputSource == null)
			{
				IInputSource[] components = InterfaceHelper.GetComponents<IInputSource>();
				for (int j = 0; j < components.Length; j++)
				{
					GameObject gameObject = ((MonoBehaviour)components[j]).gameObject;
					if (gameObject.activeSelf && components[j].IsEnabled)
					{
						this._InputSource = components[j];
						this._InputSourceOwner = gameObject;
					}
				}
			}
			this.mMotionController = base.gameObject.GetComponent<MotionController>();
			this.mActorCore = base.gameObject.GetComponent<IActorCore>();
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x000323B0 File Offset: 0x000305B0
		protected virtual void Start()
		{
			if (this.WeaponSets.Count == 0)
			{
				this._ActiveWeaponSet = -1;
			}
			if (this._ActiveWeaponSet >= this.WeaponSets.Count)
			{
				this._ActiveWeaponSet = 0;
			}
			for (int i = 0; i < this.Items.Count; i++)
			{
				BasicInventoryItem basicInventoryItem = this.Items[i];
				if (basicInventoryItem.Instance != null)
				{
					basicInventoryItem.DestroyOnStore = false;
					basicInventoryItem.StoredParent = basicInventoryItem.Instance.transform.parent;
					basicInventoryItem.StoredPosition = basicInventoryItem.Instance.transform.localPosition;
					basicInventoryItem.StoredRotation = basicInventoryItem.Instance.transform.localRotation;
				}
			}
			if (this._ActiveWeaponSet >= 0 && this._EquipOnStart)
			{
				this.EquipWeaponSet(this._ActiveWeaponSet);
			}
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x00032484 File Offset: 0x00030684
		protected virtual void Update()
		{
			bool flag = this.WeaponSets != null && this.WeaponSets.Count > 0;
			if (flag)
			{
				flag = this.mMotionController.IsGrounded;
			}
			if (flag)
			{
				flag = this.IsEquipStoreAllowed;
			}
			if (this._InputSource != null && this._InputSource.IsEnabled && !this.mIsEquippingItem)
			{
				if (flag && this._UseNumberKeys)
				{
					for (int i = 0; i < Mathf.Min(this.WeaponSets.Count, 8); i++)
					{
						if (i < this.WeaponSets.Count && this.WeaponSets[i].IsEnabled && this._InputSource.IsJustPressed(KeyCode.Alpha1 + i))
						{
							flag = false;
							this._ActiveWeaponSet = i;
							base.StartCoroutine(this.SwapWeaponSet(i));
						}
					}
				}
				if (flag && this._ToggleWeaponSetAlias.Length > 0 && this._InputSource.GetValue(this._ToggleWeaponSetAlias) != 0f)
				{
					flag = false;
					base.StartCoroutine(this.SwapWeaponSet(this._ActiveWeaponSet));
				}
				if (flag && this._ShiftWeaponSetAlias.Length > 0)
				{
					float value = this._InputSource.GetValue(this._ShiftWeaponSetAlias);
					if (value != 0f)
					{
						int num = this._ActiveWeaponSet;
						for (int j = 0; j < 10; j++)
						{
							num += ((value < -0.1f) ? (-1) : ((value > 0.1f) ? 1 : 0));
							if (num < 0)
							{
								num = this.WeaponSets.Count - 1;
							}
							else if (num >= this.WeaponSets.Count)
							{
								num = 0;
							}
							if (this.WeaponSets[num].IsEnabled || num == this._ActiveWeaponSet)
							{
								break;
							}
						}
						if (num != this._ActiveWeaponSet)
						{
							this._ActiveWeaponSet = num;
							base.StartCoroutine(this.SwapWeaponSet(this._ActiveWeaponSet));
						}
					}
				}
			}
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00032664 File Offset: 0x00030864
		public virtual GameObject EquipItem(string rItemID, string rSlotID, string rResourcePath = "")
		{
			BasicInventoryItem inventoryItem = this.GetInventoryItem(rItemID);
			if (inventoryItem == null)
			{
				return null;
			}
			string text = rResourcePath;
			if (text.Length == 0)
			{
				text = inventoryItem.ResourcePath;
			}
			Quaternion quaternion = Quaternion.Euler(inventoryItem.LocalRotationEuler);
			if (quaternion == Quaternion.identity && inventoryItem.LocalRotation != Quaternion.identity)
			{
				quaternion = inventoryItem.LocalRotation;
				inventoryItem.LocalRotationEuler = inventoryItem.LocalRotation.eulerAngles;
			}
			if (inventoryItem.Instance == null)
			{
				GameObject gameObject = this.CreateAndMountItem(base.gameObject, text, inventoryItem.LocalPosition, quaternion, rSlotID, "Handle");
				if (gameObject != null)
				{
					inventoryItem.Instance = gameObject;
				}
			}
			else
			{
				this.MountItem(base.gameObject, inventoryItem.Instance, inventoryItem.LocalPosition, quaternion, rSlotID, "Handle");
			}
			if (inventoryItem.Instance != null)
			{
				IItemCore component = inventoryItem.Instance.GetComponent<IItemCore>();
				if (component != null)
				{
					component.OnEquipped();
				}
				BasicInventorySlot inventorySlot = this.GetInventorySlot(rSlotID);
				if (inventorySlot != null)
				{
					inventorySlot.ItemID = rItemID;
				}
				InventoryMessage inventoryMessage = InventoryMessage.Allocate();
				inventoryMessage.ID = EnumMessageID.MSG_INVENTORY_ITEM_EQUIPPED;
				inventoryMessage.InventorySource = this;
				inventoryMessage.ItemID = rItemID;
				inventoryMessage.SlotID = rSlotID;
				inventoryMessage.Form = ((inventoryItem != null) ? inventoryItem.EquipStyle : 0);
				inventoryMessage.WeaponSetID = null;
				if (this.ItemEquippedEvent != null)
				{
					this.ItemEquippedEvent.Invoke(inventoryMessage);
				}
				if (this.mActorCore != null)
				{
					this.mActorCore.SendMessage(inventoryMessage);
				}
				InventoryMessage.Release(inventoryMessage);
			}
			return inventoryItem.Instance;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x000327E8 File Offset: 0x000309E8
		public virtual void StoreItem(string rSlotID)
		{
			int num = -1;
			for (int i = 0; i < this.Slots.Count; i++)
			{
				if (this.Slots[i].ID == rSlotID)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return;
			}
			BasicInventorySlot basicInventorySlot = this.Slots[num];
			if (basicInventorySlot == null)
			{
				return;
			}
			BasicInventoryItem basicInventoryItem = null;
			for (int j = 0; j < this.Items.Count; j++)
			{
				if (this.Items[j].ID == basicInventorySlot.ItemID)
				{
					basicInventoryItem = this.Items[j];
					break;
				}
			}
			if (basicInventoryItem != null && basicInventoryItem.Instance != null)
			{
				IItemCore component = basicInventoryItem.Instance.GetComponent<IItemCore>();
				if (component != null)
				{
					component.OnStored();
				}
				ICombatant component2 = base.gameObject.GetComponent<ICombatant>();
				if (component2 != null)
				{
					IWeaponCore component3 = basicInventoryItem.Instance.GetComponent<IWeaponCore>();
					if (component3 != null)
					{
						if (component2.PrimaryWeapon == component3)
						{
							component2.PrimaryWeapon = null;
						}
						if (component2.SecondaryWeapon == component3)
						{
							component2.SecondaryWeapon = null;
						}
					}
				}
				if (basicInventoryItem.StoredParent == null)
				{
					if (basicInventoryItem.DestroyOnStore)
					{
						Object.Destroy(basicInventoryItem.Instance);
						basicInventoryItem.Instance = null;
					}
					else
					{
						basicInventoryItem.Instance.SetActive(false);
						basicInventoryItem.Instance.hideFlags = HideFlags.HideInHierarchy;
					}
				}
				else if (!false)
				{
					basicInventoryItem.Instance.transform.parent = basicInventoryItem.StoredParent;
					basicInventoryItem.Instance.transform.localPosition = basicInventoryItem.StoredPosition;
					basicInventoryItem.Instance.transform.localRotation = basicInventoryItem.StoredRotation;
				}
				InventoryMessage inventoryMessage = InventoryMessage.Allocate();
				inventoryMessage.ID = EnumMessageID.MSG_INVENTORY_ITEM_STORED;
				inventoryMessage.InventorySource = this;
				inventoryMessage.ItemID = ((basicInventoryItem != null) ? basicInventoryItem.ID : null);
				inventoryMessage.SlotID = rSlotID;
				inventoryMessage.Form = ((basicInventoryItem != null) ? basicInventoryItem.StoreStyle : 0);
				inventoryMessage.WeaponSetID = null;
				if (this.ItemStoredEvent != null)
				{
					this.ItemStoredEvent.Invoke(inventoryMessage);
				}
				if (this.mActorCore != null)
				{
					this.mActorCore.SendMessage(inventoryMessage);
				}
				InventoryMessage.Release(inventoryMessage);
			}
			basicInventorySlot.ItemID = "";
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00032A18 File Offset: 0x00030C18
		public virtual string GetItemID(string rSlotID, bool rRequireIsEquipped = true)
		{
			for (int i = 0; i < this.Slots.Count; i++)
			{
				if (this.Slots[i].ID == rSlotID)
				{
					return this.Slots[i].ItemID;
				}
			}
			return "";
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x00032A6C File Offset: 0x00030C6C
		public virtual T GetItemPropertyValue<T>(string rItemID, string rPropertyID)
		{
			string text = rPropertyID.Replace(" ", string.Empty);
			for (int i = 0; i < this.Items.Count; i++)
			{
				if (this.Items[i].ID == rItemID)
				{
					if (string.Compare(text, BasicInventory.Properties[0], true) == 0)
					{
						if (typeof(T) == typeof(string))
						{
							return (T)((object)this.Items[i].ResourcePath);
						}
					}
					else if (string.Compare(text, BasicInventory.Properties[1], true) == 0)
					{
						if (typeof(T) == typeof(GameObject))
						{
							GameObject instance = this.Items[i].Instance;
							if (instance != null)
							{
								return (T)((object)instance);
							}
						}
					}
					else if (string.Compare(text, BasicInventory.Properties[2], true) == 0 && typeof(T) == typeof(int))
					{
						return (T)((object)this.Items[i].Quantity);
					}
					return default(T);
				}
			}
			return default(T);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00032BB0 File Offset: 0x00030DB0
		public virtual void SetItemPropertyValue<T>(string rItemID, string rPropertyID, T rValue)
		{
			string text = rPropertyID.Replace(" ", string.Empty);
			for (int i = 0; i < this.Items.Count; i++)
			{
				if (this.Items[i].ID == rItemID)
				{
					if (string.Compare(text, BasicInventory.Properties[0], true) == 0)
					{
						if (typeof(T) == typeof(string))
						{
							this.Items[i].ResourcePath = Convert.ToString(rValue);
						}
					}
					else if (string.Compare(text, BasicInventory.Properties[1], true) == 0)
					{
						if (typeof(T) == typeof(GameObject))
						{
							this.Items[i].Instance = Convert.ChangeType(rValue, typeof(GameObject)) as GameObject;
						}
					}
					else if (string.Compare(text, BasicInventory.Properties[2], true) == 0 && typeof(T) == typeof(int))
					{
						this.Items[i].Quantity = Convert.ToInt32(rValue);
					}
				}
			}
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00032CF4 File Offset: 0x00030EF4
		public virtual BasicInventorySlot GetInventorySlot(string rSlotID)
		{
			for (int i = 0; i < this.Slots.Count; i++)
			{
				if (this.Slots[i].ID == rSlotID)
				{
					return this.Slots[i];
				}
			}
			return null;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00032D40 File Offset: 0x00030F40
		public virtual BasicInventoryItem GetInventoryItem(string rItemID)
		{
			for (int i = 0; i < this.Items.Count; i++)
			{
				if (this.Items[i].ID == rItemID)
				{
					return this.Items[i];
				}
			}
			return null;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00032D8C File Offset: 0x00030F8C
		public virtual BasicInventorySet GetWeaponSet(string rSetID)
		{
			rSetID = StringHelper.CleanString(rSetID);
			for (int i = 0; i < this.WeaponSets.Count; i++)
			{
				if (StringHelper.CleanString(this.WeaponSets[i].ID) == rSetID)
				{
					return this.WeaponSets[i];
				}
			}
			return null;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00032DE4 File Offset: 0x00030FE4
		public virtual bool IsWeaponSetEquipped(int rIndex = -1)
		{
			if (rIndex < 0)
			{
				rIndex = this._ActiveWeaponSet;
			}
			if (rIndex < 0 || rIndex >= this.WeaponSets.Count)
			{
				return false;
			}
			BasicInventorySet basicInventorySet = this.WeaponSets[rIndex];
			for (int i = 0; i < basicInventorySet.Items.Count; i++)
			{
				for (int j = 0; j < this.Slots.Count; j++)
				{
					if (this.Slots[j].ID == basicInventorySet.Items[i].SlotID && this.Slots[j].ItemID != basicInventorySet.Items[i].ItemID)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00032E9F File Offset: 0x0003109F
		public virtual void EquipWeaponSet(int rIndex = -1)
		{
			if (rIndex < 0)
			{
				rIndex = this._ActiveWeaponSet;
			}
			base.StartCoroutine(this.Internal_EquipWeaponsSet(rIndex));
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00032EBB File Offset: 0x000310BB
		public virtual void StoreWeaponSet(int rIndex = -1)
		{
			if (rIndex < 0)
			{
				rIndex = this._ActiveWeaponSet;
			}
			base.StartCoroutine(this.Internal_StoreWeaponsSet(rIndex));
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00032ED7 File Offset: 0x000310D7
		public virtual void ToggleWeaponSet(int rIndex = -1)
		{
			if (rIndex < 0)
			{
				rIndex = this._ActiveWeaponSet;
			}
			base.StartCoroutine(this.SwapWeaponSet(rIndex));
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00032EF3 File Offset: 0x000310F3
		protected virtual IEnumerator SwapWeaponSet(int rIndex)
		{
			if (!this.mIsEquippingItem && this.WeaponSets != null && this.WeaponSets.Count > rIndex)
			{
				this.mIsEquippingItem = true;
				bool lEquipItems = false;
				int num;
				for (int i = 0; i < this.WeaponSets[rIndex].Items.Count; i = num + 1)
				{
					BasicInventorySlot lSlot = this.GetInventorySlot(this.WeaponSets[rIndex].Items[i].SlotID);
					if (lSlot != null)
					{
						if (lSlot.ItemID.Length == 0 && this.WeaponSets[rIndex].Items[i].ItemID.Length > 0)
						{
							lEquipItems = true;
						}
						else if (lSlot.ItemID != this.WeaponSets[rIndex].Items[i].ItemID)
						{
							lEquipItems = true;
							yield return base.StartCoroutine(this.Internal_StoreItem(lSlot.ID, true));
							lSlot.ItemID = "";
						}
					}
					lSlot = null;
					num = i;
				}
				if (lEquipItems)
				{
					yield return base.StartCoroutine(this.Internal_EquipWeaponsSet(rIndex));
				}
				else
				{
					yield return base.StartCoroutine(this.Internal_StoreWeaponsSet(rIndex));
				}
				this.mIsEquippingItem = false;
				this._ActiveWeaponSet = rIndex;
			}
			yield break;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00032F09 File Offset: 0x00031109
		protected virtual IEnumerator Internal_StoreItem(string rSlotID, bool rClearStates)
		{
			bool lStanceSet = false;
			BasicInventorySlot lSlot = this.GetInventorySlot(rSlotID);
			if (lSlot != null)
			{
				BasicInventoryItem lItem = this.GetInventoryItem(lSlot.ItemID);
				if (lItem != null)
				{
					if (lItem.StoreMotion.Length > 0)
					{
						MotionControllerMotion lMotion = this.mMotionController.GetMotion(lItem.StoreMotion, false);
						if (lMotion != null)
						{
							while (lMotion.MotionLayer._AnimatorTransitionID != 0)
							{
								yield return null;
							}
							IEquipStoreMotion equipStoreMotion = lMotion as IEquipStoreMotion;
							if (equipStoreMotion != null)
							{
								equipStoreMotion.OverrideItemID = lItem.ID;
								equipStoreMotion.OverrideSlotID = lSlot.ID;
							}
							lMotion.Form = lItem.StoreStyle;
							this.mMotionController.ActivateMotion(lMotion, 0);
							while (lMotion.IsActive || lMotion.QueueActivation)
							{
								yield return null;
								if (!lStanceSet && rClearStates && lMotion.IsActive && lMotion.Age > 0.3f)
								{
									lStanceSet = true;
									this.mMotionController.Stance = 0;
									this.mMotionController.CurrentForm = this.mMotionController.DefaultForm;
								}
							}
						}
						lMotion = null;
					}
					else
					{
						this.StoreItem(lSlot.ID);
					}
				}
				lSlot.ItemID = "";
				lItem = null;
			}
			yield break;
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00032F26 File Offset: 0x00031126
		protected virtual IEnumerator Internal_EquipWeaponsSet(int rIndex)
		{
			this.mIsEquippingItem = true;
			bool lStanceSet = false;
			for (int j = 0; j < this.WeaponSets[rIndex].Items.Count; j++)
			{
				BasicInventoryItem inventoryItem = this.GetInventoryItem(this.WeaponSets[rIndex].Items[j].ItemID);
				if (inventoryItem != null && inventoryItem.EquipMotion.Length == 0)
				{
					BasicInventorySlot inventorySlot = this.GetInventorySlot(this.WeaponSets[rIndex].Items[j].SlotID);
					if (inventorySlot != null)
					{
						if (this.WeaponSets[rIndex].Items[j].Instantiate)
						{
							if (this.EquipItem(inventoryItem.ID, inventorySlot.ID, "") != null)
							{
								inventorySlot.ItemID = inventoryItem.ID;
							}
						}
						else
						{
							inventorySlot.ItemID = inventoryItem.ID;
						}
					}
				}
			}
			int num;
			for (int i = 0; i < this.WeaponSets[rIndex].Items.Count; i = num + 1)
			{
				BasicInventoryItem lItem = this.GetInventoryItem(this.WeaponSets[rIndex].Items[i].ItemID);
				if (lItem != null && lItem.EquipMotion.Length > 0)
				{
					BasicInventorySlot lSlot = this.GetInventorySlot(this.WeaponSets[rIndex].Items[i].SlotID);
					if (lSlot != null && lSlot.ItemID.Length == 0)
					{
						MotionControllerMotion lMotion = this.mMotionController.GetMotion(lItem.EquipMotion, false);
						if (lMotion != null)
						{
							IEquipStoreMotion equipStoreMotion = lMotion as IEquipStoreMotion;
							if (equipStoreMotion != null)
							{
								equipStoreMotion.OverrideItemID = lItem.ID;
								equipStoreMotion.OverrideSlotID = lSlot.ID;
							}
							lMotion.Form = lItem.EquipStyle;
							this.mMotionController.ActivateMotion(lMotion, 0);
							while (lMotion.IsActive || lMotion.QueueActivation)
							{
								yield return null;
								if (!lStanceSet && lMotion.IsActive && lMotion.Age > 0.3f)
								{
									lStanceSet = true;
									if (this.WeaponSets[rIndex].Stance > 0)
									{
										this.mMotionController.Stance = this.WeaponSets[rIndex].Stance;
									}
									if (this.WeaponSets[rIndex].DefaultForm > 0)
									{
										this.mMotionController.CurrentForm = this.WeaponSets[rIndex].DefaultForm;
									}
								}
							}
							lSlot.ItemID = lItem.ID;
						}
						lMotion = null;
					}
					lSlot = null;
				}
				lItem = null;
				num = i;
			}
			if (!lStanceSet)
			{
				lStanceSet = true;
				if (this.WeaponSets[rIndex].Stance > 0)
				{
					this.mMotionController.Stance = this.WeaponSets[rIndex].Stance;
				}
				if (this.WeaponSets[rIndex].DefaultForm > 0)
				{
					this.mMotionController.CurrentForm = this.WeaponSets[rIndex].DefaultForm;
				}
			}
			this._ActiveWeaponSet = rIndex;
			InventoryMessage inventoryMessage = InventoryMessage.Allocate();
			inventoryMessage.ID = EnumMessageID.MSG_INVENTORY_WEAPON_SET_EQUIPPED;
			inventoryMessage.InventorySource = this;
			inventoryMessage.ItemID = null;
			inventoryMessage.SlotID = null;
			inventoryMessage.WeaponSetID = this.WeaponSets[this._ActiveWeaponSet].ID;
			inventoryMessage.Form = this.WeaponSets[this._ActiveWeaponSet].DefaultForm;
			if (this.WeaponSetEquippedEvent != null)
			{
				this.WeaponSetEquippedEvent.Invoke(inventoryMessage);
			}
			if (this.mActorCore != null)
			{
				this.mActorCore.SendMessage(inventoryMessage);
			}
			InventoryMessage.Release(inventoryMessage);
			this.mIsEquippingItem = false;
			yield break;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00032F3C File Offset: 0x0003113C
		protected virtual IEnumerator Internal_StoreWeaponsSet(int rIndex)
		{
			this.mIsEquippingItem = true;
			bool lStanceSet = false;
			int num;
			for (int i = 0; i < this.WeaponSets[rIndex].Items.Count; i = num + 1)
			{
				BasicInventorySlot lSlot = this.GetInventorySlot(this.WeaponSets[rIndex].Items[i].SlotID);
				if (lSlot != null && lSlot.ItemID.Length > 0)
				{
					BasicInventoryItem lItem = this.GetInventoryItem(lSlot.ItemID);
					if (lItem != null && lItem.StoreMotion.Length > 0)
					{
						MotionControllerMotion lMotion = this.mMotionController.GetMotion(lItem.StoreMotion, false);
						if (lMotion != null)
						{
							while (lMotion.MotionLayer._AnimatorTransitionID != 0)
							{
								yield return null;
							}
							IEquipStoreMotion equipStoreMotion = lMotion as IEquipStoreMotion;
							if (equipStoreMotion != null)
							{
								equipStoreMotion.OverrideItemID = lItem.ID;
								equipStoreMotion.OverrideSlotID = lSlot.ID;
							}
							lMotion.Form = lItem.StoreStyle;
							this.mMotionController.ActivateMotion(lMotion, 0);
							while (lMotion.IsActive || lMotion.QueueActivation)
							{
								yield return null;
								if (!lStanceSet && lMotion.IsActive && lMotion.Age > 0.3f)
								{
									lStanceSet = true;
									if (this.WeaponSets[rIndex].Stance >= 0)
									{
										this.mMotionController.Stance = 0;
									}
									if (this.WeaponSets[rIndex].DefaultForm >= 0)
									{
										this.mMotionController.CurrentForm = this.mMotionController.DefaultForm;
									}
								}
							}
							lSlot.ItemID = "";
						}
						lMotion = null;
					}
					lItem = null;
				}
				lSlot = null;
				num = i;
			}
			for (int j = 0; j < this.WeaponSets[rIndex].Items.Count; j++)
			{
				BasicInventorySlot inventorySlot = this.GetInventorySlot(this.WeaponSets[rIndex].Items[j].SlotID);
				if (inventorySlot != null && inventorySlot.ItemID.Length > 0)
				{
					this.StoreItem(inventorySlot.ID);
				}
			}
			if (!lStanceSet)
			{
				if (this.WeaponSets[rIndex].Stance >= 0)
				{
					this.mMotionController.Stance = 0;
				}
				if (this.WeaponSets[rIndex].DefaultForm >= 0)
				{
					this.mMotionController.CurrentForm = this.mMotionController.DefaultForm;
				}
			}
			InventoryMessage inventoryMessage = InventoryMessage.Allocate();
			inventoryMessage.ID = EnumMessageID.MSG_INVENTORY_WEAPON_SET_STORED;
			inventoryMessage.InventorySource = this;
			inventoryMessage.ItemID = null;
			inventoryMessage.SlotID = null;
			inventoryMessage.WeaponSetID = this.WeaponSets[rIndex].ID;
			inventoryMessage.Form = this.WeaponSets[rIndex].DefaultForm;
			if (this.WeaponSetStoredEvent != null)
			{
				this.WeaponSetStoredEvent.Invoke(inventoryMessage);
			}
			if (this.mActorCore != null)
			{
				this.mActorCore.SendMessage(inventoryMessage);
			}
			InventoryMessage.Release(inventoryMessage);
			this.mIsEquippingItem = false;
			yield break;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00032F54 File Offset: 0x00031154
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
					ICombatant component = base.gameObject.GetComponent<ICombatant>();
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

		// Token: 0x06000A33 RID: 2611 RVA: 0x00033028 File Offset: 0x00031228
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
					component.Owner = base.gameObject;
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
				ICombatant component2 = base.gameObject.GetComponent<ICombatant>();
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

		// Token: 0x06000A34 RID: 2612 RVA: 0x00033174 File Offset: 0x00031374
		protected Transform FindTransform(Transform rParent, string rName)
		{
			Transform transform = null;
			if (transform == null)
			{
				Animator componentInChildren = rParent.GetComponentInChildren<Animator>();
				if (componentInChildren != null)
				{
					string text = StringHelper.CleanString(rName);
					for (int i = 0; i < BasicInventory.UnityBones.Length; i++)
					{
						if (BasicInventory.UnityBones[i] == text)
						{
							transform = componentInChildren.GetBoneTransform((HumanBodyBones)i);
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

		// Token: 0x040004F0 RID: 1264
		public static string[] Properties = new string[] { "resourcepath", "instance", "quantity" };

		// Token: 0x040004F1 RID: 1265
		public static string[] UnityBones = null;

		// Token: 0x040004F2 RID: 1266
		public List<BasicInventoryItem> Items = new List<BasicInventoryItem>();

		// Token: 0x040004F3 RID: 1267
		public List<BasicInventorySlot> Slots = new List<BasicInventorySlot>();

		// Token: 0x040004F4 RID: 1268
		public List<BasicInventorySet> WeaponSets = new List<BasicInventorySet>();

		// Token: 0x040004F5 RID: 1269
		public bool _IsEnabled = true;

		// Token: 0x040004F6 RID: 1270
		public GameObject _InputSourceOwner;

		// Token: 0x040004F7 RID: 1271
		[NonSerialized]
		public IInputSource _InputSource;

		// Token: 0x040004F8 RID: 1272
		public bool _AutoFindInputSource = true;

		// Token: 0x040004F9 RID: 1273
		public bool _UseNumberKeys = true;

		// Token: 0x040004FA RID: 1274
		public string _ToggleWeaponSetAlias = "Inventory Toggle";

		// Token: 0x040004FB RID: 1275
		public string _ShiftWeaponSetAlias = "Inventory Shift";

		// Token: 0x040004FC RID: 1276
		public bool _AllowMotionSelfActivation;

		// Token: 0x040004FD RID: 1277
		public int _ActiveWeaponSet;

		// Token: 0x040004FE RID: 1278
		public bool _EquipOnStart;

		// Token: 0x040004FF RID: 1279
		protected bool mIsEquippingItem;

		// Token: 0x04000500 RID: 1280
		public MessageEvent ItemEquippedEvent;

		// Token: 0x04000501 RID: 1281
		public MessageEvent ItemStoredEvent;

		// Token: 0x04000502 RID: 1282
		public MessageEvent WeaponSetEquippedEvent;

		// Token: 0x04000503 RID: 1283
		public MessageEvent WeaponSetStoredEvent;

		// Token: 0x04000504 RID: 1284
		protected MotionController mMotionController;

		// Token: 0x04000505 RID: 1285
		protected IActorCore mActorCore;
	}
}
