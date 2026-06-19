using System;
using com.ootii.Base;
using com.ootii.Items;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000B0 RID: 176
	public class ItemCore : BaseMonoObject, IItemCore, IItem, IBaseObject, ILifeCore
	{
		// Token: 0x1700029A RID: 666
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x00030DE1 File Offset: 0x0002EFE1
		// (set) Token: 0x060009C4 RID: 2500 RVA: 0x00030DE9 File Offset: 0x0002EFE9
		public GameObject Prefab
		{
			get
			{
				return this.mPrefab;
			}
			set
			{
				this.mPrefab = value;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x060009C5 RID: 2501 RVA: 0x00030DF2 File Offset: 0x0002EFF2
		// (set) Token: 0x060009C6 RID: 2502 RVA: 0x00030DFA File Offset: 0x0002EFFA
		public virtual GameObject Owner
		{
			get
			{
				return this.mOwner;
			}
			set
			{
				this.mOwner = value;
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x00030E03 File Offset: 0x0002F003
		// (set) Token: 0x060009C8 RID: 2504 RVA: 0x00030E0B File Offset: 0x0002F00B
		public virtual Vector3 LocalPosition
		{
			get
			{
				return this._LocalPosition;
			}
			set
			{
				this._LocalPosition = value;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x00030E14 File Offset: 0x0002F014
		// (set) Token: 0x060009CA RID: 2506 RVA: 0x00030E1C File Offset: 0x0002F01C
		public virtual Quaternion LocalRotation
		{
			get
			{
				return this._LocalRotation;
			}
			set
			{
				this._LocalRotation = value;
				this._LocalRotationEuler = this._LocalRotation.eulerAngles;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x00030E36 File Offset: 0x0002F036
		// (set) Token: 0x060009CC RID: 2508 RVA: 0x00030E3E File Offset: 0x0002F03E
		public virtual Vector3 LocalRotationEuler
		{
			get
			{
				return this._LocalRotationEuler;
			}
			set
			{
				this._LocalRotationEuler = value;
				this._LocalRotation = Quaternion.Euler(this._LocalRotationEuler);
			}
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00030E58 File Offset: 0x0002F058
		protected virtual void OnEnable()
		{
			if (this._LocalRotationEuler.sqrMagnitude == 0f)
			{
				this._LocalRotationEuler = this._LocalRotation.eulerAngles;
				return;
			}
			this._LocalRotation = Quaternion.Euler(this._LocalRotationEuler);
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x00030E8F File Offset: 0x0002F08F
		public virtual void OnEquipped()
		{
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00030E91 File Offset: 0x0002F091
		public virtual void OnStored()
		{
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00030EBC File Offset: 0x0002F0BC
		GameObject ILifeCore.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040004D2 RID: 1234
		protected GameObject mPrefab;

		// Token: 0x040004D3 RID: 1235
		protected GameObject mOwner;

		// Token: 0x040004D4 RID: 1236
		public Vector3 _LocalPosition = Vector3.zero;

		// Token: 0x040004D5 RID: 1237
		public Quaternion _LocalRotation = Quaternion.identity;

		// Token: 0x040004D6 RID: 1238
		public Vector3 _LocalRotationEuler = Vector3.zero;
	}
}
