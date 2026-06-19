using System;
using System.IO;

namespace Assets.TValle.Tools.Runtime.Moddding
{
	// Token: 0x02000031 RID: 49
	public static class Directorys
	{
		// Token: 0x06000112 RID: 274 RVA: 0x000031B8 File Offset: 0x000013B8
		static Directorys()
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			Directorys.clothingModsPath = Path.Combine(new string[] { folderPath, "TValle Games", "Some Modeling Agency", "Mods", "Clothing" });
			Directorys.scriptingModsPath = Path.Combine(new string[] { folderPath, "TValle Games", "Some Modeling Agency", "Mods", "Scripts" });
			Directorys.clothingModsTypePath = string.Format("{{{0}.{1}}}", typeof(Directorys).FullName, "clothingModsPath");
			Directorys.m_invalid = Path.GetInvalidPathChars();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00003261 File Offset: 0x00001461
		public static string RemoveInvalid(string srt)
		{
			return srt.Trim(Directorys.m_invalid);
		}

		// Token: 0x0400004A RID: 74
		public const string companyName = "TValle Games";

		// Token: 0x0400004B RID: 75
		public const string productName = "Some Modeling Agency";

		// Token: 0x0400004C RID: 76
		public const string modsFolderName = "Mods";

		// Token: 0x0400004D RID: 77
		public const string clothingFolderName = "Clothing";

		// Token: 0x0400004E RID: 78
		public const string scriptingFolderName = "Scripts";

		// Token: 0x0400004F RID: 79
		public static readonly string clothingModsPath;

		// Token: 0x04000050 RID: 80
		public static readonly string scriptingModsPath;

		// Token: 0x04000051 RID: 81
		public static readonly string clothingModsTypePath;

		// Token: 0x04000052 RID: 82
		private static readonly char[] m_invalid;
	}
}
