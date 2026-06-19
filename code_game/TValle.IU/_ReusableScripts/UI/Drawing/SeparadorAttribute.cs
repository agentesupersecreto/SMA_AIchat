using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000038 RID: 56
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class SeparadorAttribute : Attribute
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00006701 File Offset: 0x00004901
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x0000670E File Offset: 0x0000490E
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

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x0000671C File Offset: 0x0000491C
		public bool heightByUser
		{
			get
			{
				return this.m_Height != null;
			}
		}

		// Token: 0x040000C3 RID: 195
		private int? m_Height;
	}
}
