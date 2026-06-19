using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Testing.PhyscisAnus
{
	// Token: 0x02000018 RID: 24
	public class TestingIngoreCollisionsInnerColliders : MonoBehaviour
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00004166 File Offset: 0x00002366
		private void Awake()
		{
			base.GetComponentsInChildren<Collider>(true, this.colliders);
			ExtendedMonoBehaviour.CollideListItems<Collider>(this.colliders, delegate(Collider a, Collider b)
			{
				Physics.IgnoreCollision(a, b);
			});
		}

		// Token: 0x04000073 RID: 115
		public List<Collider> colliders = new List<Collider>();
	}
}
