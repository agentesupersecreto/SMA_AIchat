using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Ai
{
	// Token: 0x020002A5 RID: 677
	public abstract class FemaleInformer : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06001186 RID: 4486 RVA: 0x00052E65 File Offset: 0x00051065
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FemaleChar = base.GetComponentInParent<FemaleChar>();
			if (this.m_FemaleChar == null)
			{
				throw new ArgumentNullException("m_FemaleChar", "m_FemaleChar null reference.");
			}
		}

		// Token: 0x04000CE1 RID: 3297
		public bool debug;

		// Token: 0x04000CE2 RID: 3298
		public bool debugDraw;

		// Token: 0x04000CE3 RID: 3299
		protected FemaleChar m_FemaleChar;
	}
}
