using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Penes
{
	// Token: 0x02000115 RID: 277
	public abstract class ToPenetratorPartsAdder<T, T_Penetrator> : BehaviourAdder where T : Component where T_Penetrator : Penetrador
	{
		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000C30 RID: 3120 RVA: 0x0002953B File Offset: 0x0002773B
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000C31 RID: 3121 RVA: 0x00029543 File Offset: 0x00027743
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000C32 RID: 3122 RVA: 0x00029546 File Offset: 0x00027746
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00029549 File Offset: 0x00027749
		public override void OnUpdateEvent1()
		{
			this.TryAdd();
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00029554 File Offset: 0x00027754
		private void TryAdd()
		{
			T_Penetrator componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null || !componentEnRoot.isStared)
			{
				return;
			}
			this.m_added = new List<T>();
			foreach (PenisPart penisPart in componentEnRoot.enumerator)
			{
				this.m_added.Add(penisPart.physicBone.GetComponentNotNull<T>());
			}
			base.OnAddBehaviour();
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x000295EC File Offset: 0x000277EC
		protected override void AddBehaviour()
		{
		}

		// Token: 0x0400069C RID: 1692
		private List<T> m_added;
	}
}
