using System;

namespace Assets._ReusableScripts.Miscellaneous
{
	// Token: 0x020000BE RID: 190
	[Serializable]
	public abstract class GlobalUserBigData : BaseGlobalUserData
	{
		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000550 RID: 1360
		[Obsolete("", true)]
		public abstract long id { get; }

		// Token: 0x06000551 RID: 1361 RVA: 0x00014B1C File Offset: 0x00012D1C
		protected sealed override void GenerateID(out string ID, out string displayID)
		{
			displayID = string.Concat(new string[] { this.organizacion, ".", this.categoria, ".", this.nombreCompleto });
			ID = displayID.RemoveSpecialCharacters().Trim().ToLower();
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00014B74 File Offset: 0x00012D74
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

		// Token: 0x06000553 RID: 1363 RVA: 0x00014BB2 File Offset: 0x00012DB2
		public sealed override bool IsPostInitValid()
		{
			return base.IsPostInitValid();
		}
	}
}
