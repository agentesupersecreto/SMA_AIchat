using System;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.LifeCores;
using com.ootii.Collections;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000BD RID: 189
	public class CombatMessage : DamageMessage
	{
		// Token: 0x06000A7C RID: 2684 RVA: 0x00033881 File Offset: 0x00031A81
		public override void Clear()
		{
			this.Attacker = null;
			this.Defender = null;
			this.Weapon = null;
			this.AttackIndex = 0;
			this.StyleIndex = -1;
			this.CombatStyle = null;
			this.HitTransform = null;
			base.Clear();
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x000338BA File Offset: 0x00031ABA
		public override void Release()
		{
			this.Clear();
			base.IsSent = true;
			base.IsHandled = true;
			if (this != null)
			{
				CombatMessage.sPool.Release(this);
			}
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x000338E0 File Offset: 0x00031AE0
		public new static CombatMessage Allocate()
		{
			CombatMessage combatMessage = CombatMessage.sPool.Allocate();
			if (combatMessage == null)
			{
				combatMessage = new CombatMessage();
			}
			combatMessage.IsSent = false;
			combatMessage.IsHandled = false;
			return combatMessage;
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00033910 File Offset: 0x00031B10
		public static CombatMessage Allocate(CombatMessage rSource)
		{
			CombatMessage combatMessage = CombatMessage.sPool.Allocate();
			if (combatMessage == null)
			{
				combatMessage = new CombatMessage();
			}
			combatMessage.Attacker = rSource.Attacker;
			combatMessage.Defender = rSource.Defender;
			combatMessage.Weapon = rSource.Weapon;
			combatMessage.AttackIndex = rSource.AttackIndex;
			combatMessage.StyleIndex = rSource.StyleIndex;
			combatMessage.CombatStyle = rSource.CombatStyle;
			combatMessage.Damage = rSource.Damage;
			combatMessage.DamageType = rSource.DamageType;
			combatMessage.ImpactPower = rSource.ImpactPower;
			combatMessage.HitVector = rSource.HitVector;
			combatMessage.HitTransform = rSource.HitTransform;
			combatMessage.HitPoint = rSource.HitPoint;
			combatMessage.HitDirection = rSource.HitDirection;
			combatMessage.IsSent = false;
			combatMessage.IsHandled = false;
			return combatMessage;
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x000339DC File Offset: 0x00031BDC
		public static void Release(CombatMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			CombatMessage.sPool.Release(rInstance);
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00033A01 File Offset: 0x00031C01
		public new static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is CombatMessage)
			{
				CombatMessage.sPool.Release((CombatMessage)rInstance);
			}
		}

		// Token: 0x04000544 RID: 1348
		public static int MSG_UNKNOWN = 1000;

		// Token: 0x04000545 RID: 1349
		public static int MSG_COMBATANT_CANCEL = 1001;

		// Token: 0x04000546 RID: 1350
		public static int MSG_COMBATANT_ATTACK = 1002;

		// Token: 0x04000547 RID: 1351
		public static int MSG_COMBATANT_BLOCK = 1003;

		// Token: 0x04000548 RID: 1352
		public static int MSG_COMBATANT_PARRY = 1004;

		// Token: 0x04000549 RID: 1353
		public static int MSG_COMBATANT_EVADE = 1005;

		// Token: 0x0400054A RID: 1354
		public static int MSG_ATTACKER_PRE_ATTACK = 1100;

		// Token: 0x0400054B RID: 1355
		public static int MSG_ATTACKER_ATTACKED = 1101;

		// Token: 0x0400054C RID: 1356
		public static int MSG_DEFENDER_ATTACKED = 1150;

		// Token: 0x0400054D RID: 1357
		public static int MSG_DEFENDER_ATTACKED_IGNORED = 1102;

		// Token: 0x0400054E RID: 1358
		public static int MSG_DEFENDER_ATTACKED_BLOCKED = 1103;

		// Token: 0x0400054F RID: 1359
		public static int MSG_DEFENDER_ATTACKED_PARRIED = 1104;

		// Token: 0x04000550 RID: 1360
		public static int MSG_DEFENDER_ATTACKED_EVADED = 1105;

		// Token: 0x04000551 RID: 1361
		public static int MSG_DEFENDER_DAMAGED = 1107;

		// Token: 0x04000552 RID: 1362
		public static int MSG_DEFENDER_KILLED = 1108;

		// Token: 0x04000553 RID: 1363
		public static int MSG_ATTACKER_POST_ATTACK = 1149;

		// Token: 0x04000554 RID: 1364
		public static int MSG_ATTACKER_TARGET_LOCKED = 1150;

		// Token: 0x04000555 RID: 1365
		public static int MSG_ATTACKER_TARGET_UNLOCKED = 1151;

		// Token: 0x04000556 RID: 1366
		public GameObject Attacker;

		// Token: 0x04000557 RID: 1367
		public GameObject Defender;

		// Token: 0x04000558 RID: 1368
		public IWeaponCore Weapon;

		// Token: 0x04000559 RID: 1369
		public int AttackIndex;

		// Token: 0x0400055A RID: 1370
		public int StyleIndex = -1;

		// Token: 0x0400055B RID: 1371
		public ICombatStyle CombatStyle;

		// Token: 0x0400055C RID: 1372
		public IMotionControllerMotion CombatMotion;

		// Token: 0x0400055D RID: 1373
		public float ImpactPower;

		// Token: 0x0400055E RID: 1374
		public Transform HitTransform;

		// Token: 0x0400055F RID: 1375
		public Vector3 HitPoint = Vector3.zero;

		// Token: 0x04000560 RID: 1376
		public Vector3 HitNormal = Vector3.zero;

		// Token: 0x04000561 RID: 1377
		public Vector3 HitVector = Vector3.zero;

		// Token: 0x04000562 RID: 1378
		public Vector3 HitDirection = Vector3.zero;

		// Token: 0x04000563 RID: 1379
		private static ObjectPool<CombatMessage> sPool = new ObjectPool<CombatMessage>(10, 10);
	}
}
