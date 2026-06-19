using System;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000C2 RID: 194
	public class EnumImpactType
	{
		// Token: 0x06000A95 RID: 2709 RVA: 0x00033DBC File Offset: 0x00031FBC
		public static int GetEnum(string rName)
		{
			for (int i = 0; i < EnumImpactType.Names.Length; i++)
			{
				if (EnumImpactType.Names[i].ToLower() == rName.ToLower())
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x04000585 RID: 1413
		public const int OTHER = 0;

		// Token: 0x04000586 RID: 1414
		public const int SLASH = 1;

		// Token: 0x04000587 RID: 1415
		public const int PIERCE = 2;

		// Token: 0x04000588 RID: 1416
		public const int BLUDGEON = 3;

		// Token: 0x04000589 RID: 1417
		public const int IMMERSE = 4;

		// Token: 0x0400058A RID: 1418
		public const int MENTAL = 5;

		// Token: 0x0400058B RID: 1419
		public static string[] Names = new string[] { "Other", "Slash", "Pierce", "Bludgeon", "Immerse", "Mental" };
	}
}
