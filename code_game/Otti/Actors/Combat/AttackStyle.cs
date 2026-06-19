using System;
using UnityEngine;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000BB RID: 187
	[Serializable]
	public class AttackStyle : ICombatStyle
	{
		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00033595 File Offset: 0x00031795
		// (set) Token: 0x06000A56 RID: 2646 RVA: 0x0003359D File Offset: 0x0003179D
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x000335A6 File Offset: 0x000317A6
		// (set) Token: 0x06000A58 RID: 2648 RVA: 0x000335AE File Offset: 0x000317AE
		public string ItemType
		{
			get
			{
				return this._ItemType;
			}
			set
			{
				this._ItemType = value;
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x000335B7 File Offset: 0x000317B7
		// (set) Token: 0x06000A5A RID: 2650 RVA: 0x000335CF File Offset: 0x000317CF
		public int Form
		{
			get
			{
				if (this._Form > -1)
				{
					return this._Form;
				}
				return this._ParameterID;
			}
			set
			{
				this._Form = value;
				this._Style = value;
				this._ParameterID = value;
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x000335E6 File Offset: 0x000317E6
		// (set) Token: 0x06000A5C RID: 2652 RVA: 0x000335EE File Offset: 0x000317EE
		public int Parameter
		{
			get
			{
				return this._Parameter;
			}
			set
			{
				this._Parameter = value;
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000A5D RID: 2653 RVA: 0x000335F7 File Offset: 0x000317F7
		// (set) Token: 0x06000A5E RID: 2654 RVA: 0x000335FF File Offset: 0x000317FF
		public string InventorySlotID
		{
			get
			{
				return this._InventorySlotID;
			}
			set
			{
				this._InventorySlotID = value;
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000A5F RID: 2655 RVA: 0x00033608 File Offset: 0x00031808
		// (set) Token: 0x06000A60 RID: 2656 RVA: 0x00033610 File Offset: 0x00031810
		public float Delay
		{
			get
			{
				return this._Delay;
			}
			set
			{
				this._Delay = value;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000A61 RID: 2657 RVA: 0x00033619 File Offset: 0x00031819
		// (set) Token: 0x06000A62 RID: 2658 RVA: 0x00033621 File Offset: 0x00031821
		public bool IsInterruptible
		{
			get
			{
				return this._IsInterruptible;
			}
			set
			{
				this._IsInterruptible = value;
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x0003362A File Offset: 0x0003182A
		// (set) Token: 0x06000A64 RID: 2660 RVA: 0x00033632 File Offset: 0x00031832
		public int Effects
		{
			get
			{
				return this._Effects;
			}
			set
			{
				this._Effects = value;
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x0003363B File Offset: 0x0003183B
		// (set) Token: 0x06000A66 RID: 2662 RVA: 0x00033643 File Offset: 0x00031843
		public Vector3 Forward
		{
			get
			{
				return this._Forward;
			}
			set
			{
				this._Forward = value;
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x0003364C File Offset: 0x0003184C
		// (set) Token: 0x06000A68 RID: 2664 RVA: 0x00033654 File Offset: 0x00031854
		public float HorizontalFOA
		{
			get
			{
				return this._HorizontalFOA;
			}
			set
			{
				this._HorizontalFOA = value;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x0003365D File Offset: 0x0003185D
		// (set) Token: 0x06000A6A RID: 2666 RVA: 0x00033665 File Offset: 0x00031865
		public float VerticalFOA
		{
			get
			{
				return this._VerticalFOA;
			}
			set
			{
				this._VerticalFOA = value;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000A6B RID: 2667 RVA: 0x0003366E File Offset: 0x0003186E
		// (set) Token: 0x06000A6C RID: 2668 RVA: 0x00033676 File Offset: 0x00031876
		public float MinRange
		{
			get
			{
				return this._MinRange;
			}
			set
			{
				this._MinRange = value;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000A6D RID: 2669 RVA: 0x0003367F File Offset: 0x0003187F
		// (set) Token: 0x06000A6E RID: 2670 RVA: 0x00033687 File Offset: 0x00031887
		public float MaxRange
		{
			get
			{
				return this._MaxRange;
			}
			set
			{
				this._MaxRange = value;
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000A6F RID: 2671 RVA: 0x00033690 File Offset: 0x00031890
		// (set) Token: 0x06000A70 RID: 2672 RVA: 0x00033698 File Offset: 0x00031898
		public float DamageModifier
		{
			get
			{
				return this._DamageModifier;
			}
			set
			{
				this._DamageModifier = value;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000A71 RID: 2673 RVA: 0x000336A1 File Offset: 0x000318A1
		// (set) Token: 0x06000A72 RID: 2674 RVA: 0x000336A9 File Offset: 0x000318A9
		public int NextAttackStyleIndex
		{
			get
			{
				return this._NextAttackStyleIndex;
			}
			set
			{
				this._NextAttackStyleIndex = value;
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000A73 RID: 2675 RVA: 0x000336B2 File Offset: 0x000318B2
		// (set) Token: 0x06000A74 RID: 2676 RVA: 0x000336BA File Offset: 0x000318BA
		public float LastAttackTime
		{
			get
			{
				return this.mLastAttackTime;
			}
			set
			{
				this.mLastAttackTime = value;
			}
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x000336C4 File Offset: 0x000318C4
		public AttackStyle()
		{
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0003373C File Offset: 0x0003193C
		public AttackStyle(AttackStyle rSource)
		{
			if (rSource == null)
			{
				return;
			}
			this._Name = rSource._Name;
			this._ParameterID = rSource._ParameterID;
			this._Style = rSource._Style;
			this._IsInterruptible = rSource._IsInterruptible;
			this._Forward = rSource._Forward;
			this._HorizontalFOA = rSource._HorizontalFOA;
			this._VerticalFOA = rSource._VerticalFOA;
			this._MinRange = rSource._MinRange;
			this._MaxRange = rSource._MaxRange;
			this._DamageModifier = rSource._DamageModifier;
		}

		// Token: 0x0400052B RID: 1323
		public string _Name = "";

		// Token: 0x0400052C RID: 1324
		public string _ItemType = "";

		// Token: 0x0400052D RID: 1325
		public int _Form = -1;

		// Token: 0x0400052E RID: 1326
		public int _Parameter;

		// Token: 0x0400052F RID: 1327
		public int _ParameterID;

		// Token: 0x04000530 RID: 1328
		public int _Style;

		// Token: 0x04000531 RID: 1329
		public string _InventorySlotID = "";

		// Token: 0x04000532 RID: 1330
		public float _Delay;

		// Token: 0x04000533 RID: 1331
		public bool _IsInterruptible = true;

		// Token: 0x04000534 RID: 1332
		public int _Effects;

		// Token: 0x04000535 RID: 1333
		public Vector3 _Forward = Vector3.forward;

		// Token: 0x04000536 RID: 1334
		public float _HorizontalFOA = 120f;

		// Token: 0x04000537 RID: 1335
		public float _VerticalFOA = 90f;

		// Token: 0x04000538 RID: 1336
		public float _MinRange;

		// Token: 0x04000539 RID: 1337
		public float _MaxRange;

		// Token: 0x0400053A RID: 1338
		public float _DamageModifier = 1f;

		// Token: 0x0400053B RID: 1339
		public int _NextAttackStyleIndex = -1;

		// Token: 0x0400053C RID: 1340
		protected float mLastAttackTime;
	}
}
