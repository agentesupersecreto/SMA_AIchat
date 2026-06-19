using System;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000DB RID: 219
	public class EnumControllerStance
	{
		// Token: 0x040005C2 RID: 1474
		public const int TRAVERSAL = 0;

		// Token: 0x040005C3 RID: 1475
		public const int COMBAT_MELEE = 1;

		// Token: 0x040005C4 RID: 1476
		public const int COMBAT_RANGED = 2;

		// Token: 0x040005C5 RID: 1477
		public const int SWIMMING = 3;

		// Token: 0x040005C6 RID: 1478
		public const int STEALTH = 4;

		// Token: 0x040005C7 RID: 1479
		public const int SNEAK = 4;

		// Token: 0x040005C8 RID: 1480
		public const int CLIMB_CROUCH = 5;

		// Token: 0x040005C9 RID: 1481
		public const int CLIMB_LADDER = 6;

		// Token: 0x040005CA RID: 1482
		public const int CLIMB_WALL = 7;

		// Token: 0x040005CB RID: 1483
		public const int SPELL_CASTING = 8;

		// Token: 0x040005CC RID: 1484
		public const int CHANNELING = 9;

		// Token: 0x040005CD RID: 1485
		public const int COMBAT_RANGED_LONGBOW = 10;

		// Token: 0x040005CE RID: 1486
		public const int COMBAT_MELEE_SWORD_SHIELD = 11;

		// Token: 0x040005CF RID: 1487
		public const int LEVITATION = 12;

		// Token: 0x040005D0 RID: 1488
		public const int FLIGHT = 13;

		// Token: 0x040005D1 RID: 1489
		public const int UNCONCIOUS = 14;

		// Token: 0x040005D2 RID: 1490
		public const int COMBAT_SHOOTING = 15;

		// Token: 0x040005D3 RID: 1491
		public static string[] Names = new string[]
		{
			"Traversal", "Combat-Melee", "Combat-Ranged", "Swimming", "Stealth", "Climb-Crouch", "Climb-Ladder", "Climb-Wall", "Spell Casting", "Channeling",
			"Combat-Ranged (longbow)", "Combat-Melee (sword and shield)", "Levitation", "Flight", "Unconcious"
		};
	}
}
