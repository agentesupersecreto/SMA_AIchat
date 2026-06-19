using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Followers
{
	// Token: 0x020000B7 RID: 183
	public class FollowInterObjTransform : InterObjIKPassMatrixFollower
	{
		// Token: 0x060006D8 RID: 1752 RVA: 0x0002123B File Offset: 0x0001F43B
		protected override void LoadTarget()
		{
			if (this.target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0002125B File Offset: 0x0001F45B
		protected override bool Following()
		{
			return this.target != null;
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00021269 File Offset: 0x0001F469
		protected override void Followed()
		{
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0002126B File Offset: 0x0001F46B
		protected override void FollowingValidarMatrix(ref Matrix4x4 matrix)
		{
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0002126D File Offset: 0x0001F46D
		protected override Matrix4x4 GetLocalToWorldMatrix()
		{
			return this.target.localToWorldMatrix;
		}

		// Token: 0x0400049F RID: 1183
		public Transform target;
	}
}
