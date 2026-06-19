using System;

namespace Assets._ReusableScripts.Miscellaneous
{
	// Token: 0x020000BF RID: 191
	[Serializable]
	public abstract class GlobalUserData : BaseGlobalUserData
	{
		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000555 RID: 1365
		[Obsolete("", true)]
		public abstract int id { get; }

		// Token: 0x06000556 RID: 1366 RVA: 0x00014BC4 File Offset: 0x00012DC4
		protected sealed override void GenerateID(out string ID, out string displayID)
		{
			displayID = string.Concat(new string[] { this.organizacion, ".", this.categoria, ".", this.nombreCompleto });
			ID = displayID.RemoveSpecialCharacters().Trim().ToLower();
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00014C1C File Offset: 0x00012E1C
		protected override bool TryGenerateID(out string ID, out string displayID)
		{
			displayID = null;
			ID = null;
			if (string.IsNullOrWhiteSpace(this.organizacion))
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(this.categoria))
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(this.nombreCompleto))
			{
				return false;
			}
			this.GenerateID(out ID, out displayID);
			return true;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00014C5A File Offset: 0x00012E5A
		public sealed override bool IsPostInitValid()
		{
			return base.IsPostInitValid();
		}
	}
}
