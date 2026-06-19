using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000039 RID: 57
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class EspacioAttribute : Attribute
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00006731 File Offset: 0x00004931
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x0000673E File Offset: 0x0000493E
		public int height
		{
			get
			{
				return this.m_Height.GetValueOrDefault();
			}
			set
			{
				this.m_Height = new int?(value);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000674C File Offset: 0x0000494C
		public bool heightByUser
		{
			get
			{
				return this.m_Height != null;
			}
		}

		// Token: 0x040000C4 RID: 196
		private int? m_Height;
	}
}
