using System;
using UnityEngine;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000BC RID: 188
	public struct CombatHit
	{
		// Token: 0x06000A77 RID: 2679 RVA: 0x0003382D File Offset: 0x00031A2D
		public override bool Equals(object rOther)
		{
			return base.Equals(rOther);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00033840 File Offset: 0x00031A40
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00033852 File Offset: 0x00031A52
		public static bool operator ==(CombatHit c1, CombatHit c2)
		{
			return c1.Equals(c2);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00033867 File Offset: 0x00031A67
		public static bool operator !=(CombatHit c1, CombatHit c2)
		{
			return !c1.Equals(c2);
		}

		// Token: 0x0400053D RID: 1341
		public static CombatHit EMPTY;

		// Token: 0x0400053E RID: 1342
		public Collider Collider;

		// Token: 0x0400053F RID: 1343
		public Vector3 Point;

		// Token: 0x04000540 RID: 1344
		public Vector3 Normal;

		// Token: 0x04000541 RID: 1345
		public float Distance;

		// Token: 0x04000542 RID: 1346
		public Vector3 Vector;

		// Token: 0x04000543 RID: 1347
		public float Index;
	}
}
