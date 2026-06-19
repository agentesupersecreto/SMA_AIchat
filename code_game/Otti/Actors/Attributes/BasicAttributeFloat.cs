using System;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000CB RID: 203
	public class BasicAttributeFloat : BasicAttributeTyped<float>
	{
		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x0003477C File Offset: 0x0003297C
		// (set) Token: 0x06000AF1 RID: 2801 RVA: 0x00034784 File Offset: 0x00032984
		public float MinValue
		{
			get
			{
				return this._MinValue;
			}
			set
			{
				this._MinValue = value;
				if (this._Value < this._MinValue)
				{
					this.Value = this._MinValue;
				}
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x000347A7 File Offset: 0x000329A7
		// (set) Token: 0x06000AF3 RID: 2803 RVA: 0x000347AF File Offset: 0x000329AF
		public float MaxValue
		{
			get
			{
				return this._MaxValue;
			}
			set
			{
				this._MaxValue = value;
				if (this._Value > this._MaxValue)
				{
					this.Value = this._MaxValue;
				}
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x000347D2 File Offset: 0x000329D2
		// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x000347DA File Offset: 0x000329DA
		public override float Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value < this._MinValue)
				{
					value = this._MinValue;
				}
				else if (value > this._MaxValue)
				{
					value = this._MaxValue;
				}
				base.Value = value;
			}
		}

		// Token: 0x0400059D RID: 1437
		public float _MinValue = float.MinValue;

		// Token: 0x0400059E RID: 1438
		public float _MaxValue = float.MaxValue;
	}
}
