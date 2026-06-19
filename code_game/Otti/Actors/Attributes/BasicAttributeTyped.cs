using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000D2 RID: 210
	[Serializable]
	public abstract class BasicAttributeTyped<T> : BasicAttribute
	{
		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000AFD RID: 2813 RVA: 0x00034863 File Offset: 0x00032A63
		public override Type ValueType
		{
			get
			{
				return this.mValueType;
			}
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x0003486B File Offset: 0x00032A6B
		// (set) Token: 0x06000AFF RID: 2815 RVA: 0x00034874 File Offset: 0x00032A74
		public virtual T Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				T value2 = this._Value;
				this._Value = value;
				if (Application.isPlaying && this.mAttributes != null && !EqualityComparer<T>.Default.Equals(value2, this._Value))
				{
					if (this.mAttributes.OnAttributeValueChangedEvent != null)
					{
						this.mAttributes.OnAttributeValueChangedEvent(this, value2);
					}
					AttributeMessage attributeMessage = AttributeMessage.Allocate();
					attributeMessage.ID = AttributeMessage.MSG_VALUE_CHANGED;
					attributeMessage.Attribute = this;
					attributeMessage.Value = value2;
					if (this.mAttributes.AttributeValueChangedEvent != null)
					{
						this.mAttributes.AttributeValueChangedEvent.Invoke(attributeMessage);
					}
					AttributeMessage.Release(attributeMessage);
				}
			}
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00034926 File Offset: 0x00032B26
		public BasicAttributeTyped()
		{
			this.mValueType = typeof(T);
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x0003493E File Offset: 0x00032B3E
		public override T1 GetValue<T1>()
		{
			if (typeof(T1) == this.mValueType)
			{
				return (T1)((object)this.Value);
			}
			throw new Exception("BasicAttributeType.GetValue() - Requested type does not match attribute type.");
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x00034972 File Offset: 0x00032B72
		public override void SetValue<T1>(T1 rValue)
		{
			if (typeof(T1) == this.mValueType)
			{
				this.Value = (T)((object)rValue);
				return;
			}
			throw new Exception("BasicAttributeTyped.SetValue() - Requested type does not match attribute type.");
		}

		// Token: 0x0400059F RID: 1439
		protected Type mValueType;

		// Token: 0x040005A0 RID: 1440
		public T _Value;
	}
}
