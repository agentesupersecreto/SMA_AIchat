using System;
using UnityEngine;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000C4 RID: 196
	public interface ICombatStyle
	{
		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000AA9 RID: 2729
		// (set) Token: 0x06000AAA RID: 2730
		string Name { get; set; }

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000AAB RID: 2731
		// (set) Token: 0x06000AAC RID: 2732
		int Form { get; set; }

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000AAD RID: 2733
		// (set) Token: 0x06000AAE RID: 2734
		string InventorySlotID { get; set; }

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000AAF RID: 2735
		// (set) Token: 0x06000AB0 RID: 2736
		float Delay { get; set; }

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000AB1 RID: 2737
		// (set) Token: 0x06000AB2 RID: 2738
		bool IsInterruptible { get; set; }

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000AB3 RID: 2739
		// (set) Token: 0x06000AB4 RID: 2740
		int Effects { get; set; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000AB5 RID: 2741
		// (set) Token: 0x06000AB6 RID: 2742
		Vector3 Forward { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000AB7 RID: 2743
		// (set) Token: 0x06000AB8 RID: 2744
		float HorizontalFOA { get; set; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000AB9 RID: 2745
		// (set) Token: 0x06000ABA RID: 2746
		float VerticalFOA { get; set; }

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000ABB RID: 2747
		// (set) Token: 0x06000ABC RID: 2748
		float MinRange { get; set; }

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000ABD RID: 2749
		// (set) Token: 0x06000ABE RID: 2750
		float MaxRange { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000ABF RID: 2751
		// (set) Token: 0x06000AC0 RID: 2752
		float DamageModifier { get; set; }
	}
}
