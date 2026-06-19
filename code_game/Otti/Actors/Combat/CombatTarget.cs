using System;
using UnityEngine;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000BE RID: 190
	public struct CombatTarget
	{
		// Token: 0x06000A84 RID: 2692 RVA: 0x00033B3F File Offset: 0x00031D3F
		public override bool Equals(object rOther)
		{
			return base.Equals(rOther);
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00033B52 File Offset: 0x00031D52
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00033B64 File Offset: 0x00031D64
		public static bool operator ==(CombatTarget c1, CombatTarget c2)
		{
			return c1.Equals(c2);
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00033B79 File Offset: 0x00031D79
		public static bool operator !=(CombatTarget c1, CombatTarget c2)
		{
			return !c1.Equals(c2);
		}

		// Token: 0x04000564 RID: 1380
		public static CombatTarget EMPTY;

		// Token: 0x04000565 RID: 1381
		public Vector3 SeekOrigin;

		// Token: 0x04000566 RID: 1382
		public ICombatant Combatant;

		// Token: 0x04000567 RID: 1383
		public Collider Collider;

		// Token: 0x04000568 RID: 1384
		public Vector3 ClosestPoint;

		// Token: 0x04000569 RID: 1385
		public float Distance;

		// Token: 0x0400056A RID: 1386
		public Vector3 Direction;

		// Token: 0x0400056B RID: 1387
		public float HorizontalAngle;

		// Token: 0x0400056C RID: 1388
		public float VerticalAngle;
	}
}
