using System;
using System.Collections.Generic;
using com.ootii.Data.Serializers;
using com.ootii.Helpers;
using com.ootii.Messages;
using com.ootii.Utilities;
using UnityEngine;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000C9 RID: 201
	public class BasicAttributes : MonoBehaviour, IAttributeSource
	{
		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x00034146 File Offset: 0x00032346
		public List<BasicAttribute> Items
		{
			get
			{
				return this.mItems;
			}
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x00034150 File Offset: 0x00032350
		public void Awake()
		{
			this.OnAfterDeserialize();
			if (this.mItemCache == null)
			{
				this.mItemCache = new Dictionary<string, BasicAttribute>(StringComparer.OrdinalIgnoreCase);
			}
			this.mItemCache.Clear();
			for (int i = 0; i < this.mItems.Count; i++)
			{
				this.mItems[i].Attributes = this;
				this.mItemCache.Add(this.mItems[i].ID, this.mItems[i]);
			}
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x000341D6 File Offset: 0x000323D6
		public virtual bool AttributeExists(string rID)
		{
			return this.mItemCache.ContainsKey(rID);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x000341E4 File Offset: 0x000323E4
		public virtual bool AttributesExist(string rIDs, bool rRequireAll = true)
		{
			if (rIDs == null || rIDs.Length == 0)
			{
				return false;
			}
			for (int i = StringHelper.Split(rIDs, ',') - 1; i >= 0; i--)
			{
				StringHelper.SharedStrings[i] = StringHelper.SharedStrings[i].Trim();
				if (this.mItemCache.ContainsKey(StringHelper.SharedStrings[i]))
				{
					if (!rRequireAll)
					{
						return true;
					}
				}
				else if (rRequireAll)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x00034248 File Offset: 0x00032448
		public virtual BasicAttribute AddAttribute(string rID, Type rType = null)
		{
			if (rID.Length == 0)
			{
				rID = "Attribute";
			}
			string text = rID;
			int num = 0;
			while (this.mItemCache.ContainsKey(text))
			{
				num++;
				text = rID + " (" + num.ToString() + ")";
			}
			BasicAttribute basicAttribute = null;
			Type type = null;
			int @enum = EnumAttributeTypes.GetEnum(rType);
			if (@enum == 0)
			{
				type = typeof(BasicAttributeTag);
			}
			if (@enum == 1)
			{
				type = typeof(BasicAttributeString);
			}
			if (@enum == 2)
			{
				type = typeof(BasicAttributeFloat);
			}
			if (@enum == 3)
			{
				type = typeof(BasicAttributeInt);
			}
			if (@enum == 4)
			{
				type = typeof(BasicAttributeBool);
			}
			if (@enum == 5)
			{
				type = typeof(BasicAttributeVector2);
			}
			if (@enum == 6)
			{
				type = typeof(BasicAttributeVector3);
			}
			if (@enum == 7)
			{
				type = typeof(BasicAttributeVector4);
			}
			if (@enum == 8)
			{
				type = typeof(BasicAttributeQuaternion);
			}
			if (@enum == 9)
			{
				type = typeof(BasicAttributeTransform);
			}
			if (@enum == 10)
			{
				type = typeof(BasicAttributeGameObject);
			}
			if (type != null)
			{
				basicAttribute = Activator.CreateInstance(type) as BasicAttribute;
				basicAttribute.Attributes = this;
				basicAttribute._ID = text;
				this.mItems.Add(basicAttribute);
				this.mItemCache.Add(text, basicAttribute);
			}
			return basicAttribute;
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00034380 File Offset: 0x00032580
		public virtual BasicAttribute AddAttribute<T>(string rID, T rValue = default(T))
		{
			BasicAttribute basicAttribute = this.AddAttribute(rID, typeof(T));
			basicAttribute.SetValue<T>(rValue);
			return basicAttribute;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0003439C File Offset: 0x0003259C
		public virtual void RenameAttribute(string rOldName, string rNewName)
		{
			if (!this.mItemCache.ContainsKey(rOldName))
			{
				return;
			}
			BasicAttribute basicAttribute = this.mItemCache[rOldName];
			basicAttribute._ID = rNewName;
			this.mItemCache.Remove(rOldName);
			this.mItemCache.Add(rNewName, basicAttribute);
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x000343E6 File Offset: 0x000325E6
		public virtual BasicAttribute GetAttribute(string rID)
		{
			if (!this.mItemCache.ContainsKey(rID))
			{
				return null;
			}
			return this.mItemCache[rID];
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00034404 File Offset: 0x00032604
		public virtual T GetAttribute<T>(string rID) where T : BasicAttribute
		{
			if (!this.mItemCache.ContainsKey(rID))
			{
				return default(T);
			}
			return this.mItemCache[rID] as T;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00034440 File Offset: 0x00032640
		public virtual void RemoveAttribute(BasicAttribute rItem)
		{
			if (!this.mItemCache.ContainsKey(rItem.ID))
			{
				return;
			}
			rItem.Attributes = null;
			rItem.IsValid = false;
			this.mItems.Remove(rItem);
			this.mItemCache.Remove(rItem.ID);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00034490 File Offset: 0x00032690
		public virtual void RemoveAttribute(string rID)
		{
			if (!this.mItemCache.ContainsKey(rID))
			{
				return;
			}
			BasicAttribute basicAttribute = this.mItemCache[rID];
			basicAttribute.Attributes = null;
			basicAttribute.IsValid = false;
			this.mItems.Remove(basicAttribute);
			this.mItemCache.Remove(rID);
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x000344E1 File Offset: 0x000326E1
		public virtual Type GetAttributeType(string rID)
		{
			if (!this.mItemCache.ContainsKey(rID))
			{
				return null;
			}
			return this.mItemCache[rID].ValueType;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x00034504 File Offset: 0x00032704
		public virtual T GetAttributeValue<T>(string rID, T rDefault = default(T))
		{
			if (!this.mItemCache.ContainsKey(rID))
			{
				return rDefault;
			}
			return this.mItemCache[rID].GetValue<T>();
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00034527 File Offset: 0x00032727
		public virtual void SetAttributeValue<T>(string rID, T rValue)
		{
			if (!this.mItemCache.ContainsKey(rID))
			{
				this.AddAttribute(rID, typeof(T));
			}
			this.mItemCache[rID].SetValue<T>(rValue);
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0003455C File Offset: 0x0003275C
		public void OnBeforeSerialize()
		{
			JSONSerializer.RootObject = base.gameObject;
			for (int i = 0; i < this.mItems.Count; i++)
			{
				string text = JSONSerializer.Serialize(this.mItems[i], false);
				if (this.mItemDefinitions.Count > i)
				{
					this.mItemDefinitions[i] = text;
				}
				else
				{
					this.mItemDefinitions.Add(text);
				}
			}
			for (int j = this.mItemDefinitions.Count - 1; j >= this.mItems.Count; j--)
			{
				this.mItemDefinitions.RemoveAt(j);
			}
			JSONSerializer.RootObject = null;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x000345FC File Offset: 0x000327FC
		public void OnAfterDeserialize()
		{
			JSONSerializer.RootObject = base.gameObject;
			for (int i = 0; i < this.mItemDefinitions.Count; i++)
			{
				Type type = null;
				JSONNode jsonnode = JSONNode.Parse(this.mItemDefinitions[i]);
				if (jsonnode != null)
				{
					string value = jsonnode["__Type"].Value;
					if (value != null && value.Length > 0)
					{
						type = Type.GetType(value);
					}
				}
				if (type != null && this.mItems.Count > i && this.mItems[i].GetType() == type)
				{
					object obj = this.mItems[i];
					JSONSerializer.DeserializeInto(this.mItemDefinitions[i], ref obj);
				}
				else
				{
					BasicAttribute basicAttribute = JSONSerializer.Deserialize(this.mItemDefinitions[i]) as BasicAttribute;
					if (basicAttribute != null)
					{
						if (this.mItems.Count <= i)
						{
							this.mItems.Add(basicAttribute);
						}
						else
						{
							this.mItems[i] = basicAttribute;
						}
					}
				}
			}
			for (int j = this.mItems.Count - 1; j > this.mItemDefinitions.Count - 1; j--)
			{
				this.mItems.RemoveAt(j);
			}
			JSONSerializer.RootObject = null;
		}

		// Token: 0x04000598 RID: 1432
		protected List<BasicAttribute> mItems = new List<BasicAttribute>();

		// Token: 0x04000599 RID: 1433
		public MessageEvent AttributeValueChangedEvent;

		// Token: 0x0400059A RID: 1434
		[NonSerialized]
		public BasicAttributeValueChangedDelegate OnAttributeValueChangedEvent;

		// Token: 0x0400059B RID: 1435
		protected Dictionary<string, BasicAttribute> mItemCache = new Dictionary<string, BasicAttribute>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x0400059C RID: 1436
		[SerializeField]
		protected List<string> mItemDefinitions = new List<string>();
	}
}
