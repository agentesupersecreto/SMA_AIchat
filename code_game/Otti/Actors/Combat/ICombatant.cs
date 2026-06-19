using System;
using System.Collections.Generic;
using com.ootii.Actors.LifeCores;
using UnityEngine;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000C3 RID: 195
	public interface ICombatant
	{
		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000A98 RID: 2712
		Transform Transform { get; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000A99 RID: 2713
		Vector3 CombatOrigin { get; }

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000A9A RID: 2714
		float MinMeleeReach { get; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000A9B RID: 2715
		float MaxMeleeReach { get; }

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000A9C RID: 2716
		// (set) Token: 0x06000A9D RID: 2717
		Transform Target { get; set; }

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000A9E RID: 2718
		// (set) Token: 0x06000A9F RID: 2719
		bool IsTargetLocked { get; set; }

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000AA0 RID: 2720
		// (set) Token: 0x06000AA1 RID: 2721
		bool ForceActorRotation { get; set; }

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000AA2 RID: 2722
		// (set) Token: 0x06000AA3 RID: 2723
		IWeaponCore PrimaryWeapon { get; set; }

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000AA4 RID: 2724
		// (set) Token: 0x06000AA5 RID: 2725
		IWeaponCore SecondaryWeapon { get; set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000AA6 RID: 2726
		// (set) Token: 0x06000AA7 RID: 2727
		ICombatStyle CombatStyle { get; set; }

		// Token: 0x06000AA8 RID: 2728
		int QueryCombatTargets(AttackStyle rStyle, List<CombatTarget> rCombatTargets);
	}
}
