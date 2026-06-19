using System;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000C7 RID: 199
	[Serializable]
	public abstract class BasicAttribute : IAttribute
	{
		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x000340E4 File Offset: 0x000322E4
		public string ID
		{
			get
			{
				return this._ID;
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x000340EC File Offset: 0x000322EC
		public virtual Type ValueType
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x000340EF File Offset: 0x000322EF
		// (set) Token: 0x06000AD4 RID: 2772 RVA: 0x000340F7 File Offset: 0x000322F7
		public bool IsValid
		{
			get
			{
				return this.mIsValid;
			}
			set
			{
				this.mIsValid = value;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x00034100 File Offset: 0x00032300
		// (set) Token: 0x06000AD6 RID: 2774 RVA: 0x00034108 File Offset: 0x00032308
		public BasicAttributes Attributes
		{
			get
			{
				return this.mAttributes;
			}
			set
			{
				this.mAttributes = value;
			}
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x00034114 File Offset: 0x00032314
		public virtual T1 GetValue<T1>()
		{
			return default(T1);
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0003412A File Offset: 0x0003232A
		public virtual void SetValue<T1>(T1 rValue)
		{
		}

		// Token: 0x04000595 RID: 1429
		public string _ID = "";

		// Token: 0x04000596 RID: 1430
		protected bool mIsValid = true;

		// Token: 0x04000597 RID: 1431
		[NonSerialized]
		protected BasicAttributes mAttributes;
	}
}
