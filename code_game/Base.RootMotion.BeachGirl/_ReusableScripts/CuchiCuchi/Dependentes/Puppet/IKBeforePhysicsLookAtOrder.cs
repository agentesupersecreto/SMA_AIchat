using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000101 RID: 257
	public class IKBeforePhysicsLookAtOrder : MonoBehaviour
	{
		// Token: 0x06000991 RID: 2449 RVA: 0x0002B67E File Offset: 0x0002987E
		public IEnumerable GetEnumerable()
		{
			return this.m_Order;
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0002B688 File Offset: 0x00029888
		public void AddTo(IList<LookAtIK> target)
		{
			for (int i = 0; i < this.m_Order.Count; i++)
			{
				target.Add(this.m_Order[i]);
			}
		}

		// Token: 0x040005E3 RID: 1507
		[CoolArrayItem]
		[SerializeField]
		private List<LookAtIK> m_Order = new List<LookAtIK>();
	}
}
