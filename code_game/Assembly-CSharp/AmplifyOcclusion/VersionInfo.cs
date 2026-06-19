using System;
using UnityEngine;

namespace AmplifyOcclusion
{
	// Token: 0x020000CB RID: 203
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x0600053C RID: 1340 RVA: 0x00019284 File Offset: 0x00017484
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 1, 0) + VersionInfo.StageSuffix;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x000192AC File Offset: 0x000174AC
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix;
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x000192E3 File Offset: 0x000174E3
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x000192FF File Offset: 0x000174FF
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 1;
			this.m_release = 0;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001931C File Offset: 0x0001751C
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00019339 File Offset: 0x00017539
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 1, 0);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00019343 File Offset: 0x00017543
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 1 == version.m_minor && version.m_release == 0;
		}

		// Token: 0x04000246 RID: 582
		public const byte Major = 1;

		// Token: 0x04000247 RID: 583
		public const byte Minor = 1;

		// Token: 0x04000248 RID: 584
		public const byte Release = 0;

		// Token: 0x04000249 RID: 585
		private static string StageSuffix = "_dev001";

		// Token: 0x0400024A RID: 586
		[SerializeField]
		private int m_major;

		// Token: 0x0400024B RID: 587
		[SerializeField]
		private int m_minor;

		// Token: 0x0400024C RID: 588
		[SerializeField]
		private int m_release;
	}
}
