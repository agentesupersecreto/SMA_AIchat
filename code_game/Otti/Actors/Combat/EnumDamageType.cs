using System;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000C1 RID: 193
	public class EnumDamageType
	{
		// Token: 0x06000A92 RID: 2706 RVA: 0x00033CF0 File Offset: 0x00031EF0
		public static int GetEnum(string rName)
		{
			for (int i = 0; i < EnumDamageType.Names.Length; i++)
			{
				if (EnumDamageType.Names[i].ToLower() == rName.ToLower())
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x04000577 RID: 1399
		public const int OTHER = 0;

		// Token: 0x04000578 RID: 1400
		public const int PHYSICAL = 1;

		// Token: 0x04000579 RID: 1401
		public const int FIRE = 2;

		// Token: 0x0400057A RID: 1402
		public const int COLD = 3;

		// Token: 0x0400057B RID: 1403
		public const int ELECTRIC = 4;

		// Token: 0x0400057C RID: 1404
		public const int POISON = 5;

		// Token: 0x0400057D RID: 1405
		public const int ACID = 6;

		// Token: 0x0400057E RID: 1406
		public const int SOUND = 7;

		// Token: 0x0400057F RID: 1407
		public const int SMELL = 8;

		// Token: 0x04000580 RID: 1408
		public const int ARCANE = 9;

		// Token: 0x04000581 RID: 1409
		public const int PSYCHIC = 10;

		// Token: 0x04000582 RID: 1410
		public const int HOLY = 11;

		// Token: 0x04000583 RID: 1411
		public const int UNHOLY = 12;

		// Token: 0x04000584 RID: 1412
		public static string[] Names = new string[]
		{
			"Other", "Physical", "Fire", "Cold", "Electric", "Poison", "Acid", "Sound", "Smell", "Arcane",
			"Psychic", "Holy", "Unholy"
		};
	}
}
