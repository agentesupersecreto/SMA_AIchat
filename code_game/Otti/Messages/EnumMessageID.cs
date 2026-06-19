using System;

namespace com.ootii.Messages
{
	// Token: 0x02000020 RID: 32
	public class EnumMessageID
	{
		// Token: 0x04000105 RID: 261
		public static int MSG_UNKNOWN = 0;

		// Token: 0x04000106 RID: 262
		public static int MSG_NAVIGATE_ARRIVED = 1;

		// Token: 0x04000107 RID: 263
		public static int MSG_NAVIGATE_SLOW_ENTERED = 2;

		// Token: 0x04000108 RID: 264
		public static int MSG_NAVIGATE_WALK = 5;

		// Token: 0x04000109 RID: 265
		public static int MSG_NAVIGATE_JUMP = 10;

		// Token: 0x0400010A RID: 266
		public static int MSG_NAVIGATE_CLIMB = 15;

		// Token: 0x0400010B RID: 267
		public static int MSG_NAVIGATE_PUSHED_BACK = 20;

		// Token: 0x0400010C RID: 268
		public static int MSG_NAVIGATE_KNOCKED_DOWN = 25;

		// Token: 0x0400010D RID: 269
		public static int MSG_MOTION_UNKNOWN = 100;

		// Token: 0x0400010E RID: 270
		public static int MSG_MOTION_ACTIVATE = 101;

		// Token: 0x0400010F RID: 271
		public static int MSG_MOTION_CONTINUE = 102;

		// Token: 0x04000110 RID: 272
		public static int MSG_MOTION_DEACTIVATE = 103;

		// Token: 0x04000111 RID: 273
		public static int MSG_MOTION_TEST = 104;

		// Token: 0x04000112 RID: 274
		public static int MSG_CAMERA_MOTOR_UNKNOWN = 200;

		// Token: 0x04000113 RID: 275
		public static int MSG_CAMERA_MOTOR_ACTIVATE = 201;

		// Token: 0x04000114 RID: 276
		public static int MSG_CAMERA_MOTOR_DEACTIVATE = 202;

		// Token: 0x04000115 RID: 277
		public static int MSG_CAMERA_MOTOR_TEST = 203;

		// Token: 0x04000116 RID: 278
		public static int MSG_INTERACTION_ACTIVATE = 300;

		// Token: 0x04000117 RID: 279
		public static int MSG_COMBAT_UNKNOWN = 1000;

		// Token: 0x04000118 RID: 280
		public static int MSG_COMBAT_COMBATANT_CANCEL = 1001;

		// Token: 0x04000119 RID: 281
		public static int MSG_COMBAT_COMBATANT_ATTACK = 1002;

		// Token: 0x0400011A RID: 282
		public static int MSG_COMBAT_COMBATANT_BLOCK = 1003;

		// Token: 0x0400011B RID: 283
		public static int MSG_COMBAT_COMBATANT_PARRY = 1004;

		// Token: 0x0400011C RID: 284
		public static int MSG_COMBAT_COMBATANT_EVADE = 1005;

		// Token: 0x0400011D RID: 285
		public static int MSG_COMBAT_ATTACKER_PRE_ATTACK = 1100;

		// Token: 0x0400011E RID: 286
		public static int MSG_COMBAT_ATTACKER_ATTACKED = 1101;

		// Token: 0x0400011F RID: 287
		public static int MSG_COMBAT_DEFENDER_ATTACKED = 1150;

		// Token: 0x04000120 RID: 288
		public static int MSG_COMBAT_DEFENDER_ATTACKED_IGNORED = 1102;

		// Token: 0x04000121 RID: 289
		public static int MSG_COMBAT_DEFENDER_ATTACKED_BLOCKED = 1103;

		// Token: 0x04000122 RID: 290
		public static int MSG_COMBAT_DEFENDER_ATTACKED_PARRIED = 1104;

		// Token: 0x04000123 RID: 291
		public static int MSG_COMBAT_DEFENDER_ATTACKED_EVADED = 1105;

		// Token: 0x04000124 RID: 292
		public static int MSG_COMBAT_DEFENDER_DAMAGED = 1107;

		// Token: 0x04000125 RID: 293
		public static int MSG_COMBAT_DEFENDER_KILLED = 1108;

		// Token: 0x04000126 RID: 294
		public static int MSG_COMBAT_ATTACKER_POST_ATTACK = 1149;

		// Token: 0x04000127 RID: 295
		public static int MSG_COMBAT_ATTACKER_TARGET_LOCKED = 1150;

		// Token: 0x04000128 RID: 296
		public static int MSG_COMBAT_ATTACKER_TARGET_UNLOCKED = 1151;

		// Token: 0x04000129 RID: 297
		public static int MSG_INVENTORY_UNKNOWN = 1500;

		// Token: 0x0400012A RID: 298
		public static int MSG_INVENTORY_ITEM_EQUIPPED = 1501;

		// Token: 0x0400012B RID: 299
		public static int MSG_INVENTORY_ITEM_STORED = 1502;

		// Token: 0x0400012C RID: 300
		public static int MSG_INVENTORY_WEAPON_SET_EQUIPPED = 1503;

		// Token: 0x0400012D RID: 301
		public static int MSG_INVENTORY_WEAPON_SET_STORED = 1504;

		// Token: 0x0400012E RID: 302
		public static int MSG_MAGIC_UNKNOWN = 5000;

		// Token: 0x0400012F RID: 303
		public static int MSG_MAGIC_CAST = 5001;

		// Token: 0x04000130 RID: 304
		public static int MSG_MAGIC_CONTINUE = 5002;

		// Token: 0x04000131 RID: 305
		public static int MSG_MAGIC_CANCEL = 5003;

		// Token: 0x04000132 RID: 306
		public static int MSG_MAGIC_PRE_CAST = 5004;

		// Token: 0x04000133 RID: 307
		public static int MSG_MAGIC_POST_CAST = 5005;

		// Token: 0x04000134 RID: 308
		public static int MSG_SENSORS_OBJECTS_DETECTED_ENTER = 5100;

		// Token: 0x04000135 RID: 309
		public static int MSG_SENSORS_OBJECTS_DETECTED_STAY = 5101;

		// Token: 0x04000136 RID: 310
		public static int MSG_SENSORS_OBJECTS_DETECTED_EXIT = 5102;

		// Token: 0x04000137 RID: 311
		public static int MSG_ATTRIBUTE_VALUE_CHANGED = 5200;

		// Token: 0x04000138 RID: 312
		public static int MSG_FACTION_VALUE_CHANGED = 5300;
	}
}
