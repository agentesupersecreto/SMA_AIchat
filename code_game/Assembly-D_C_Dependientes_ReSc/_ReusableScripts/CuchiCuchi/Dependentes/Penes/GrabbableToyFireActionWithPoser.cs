using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Props;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Penes
{
	// Token: 0x02000158 RID: 344
	public abstract class GrabbableToyFireActionWithPoser : GrabbablePropFireActionWithPoser
	{
		// Token: 0x06000703 RID: 1795 RVA: 0x0002583D File Offset: 0x00023A3D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_GrabbableToy = base.GetComponent<GrabbableToy>();
			if (this.m_GrabbableToy == null)
			{
				throw new ArgumentNullException("m_GrabbableToy", "m_GrabbableToy null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00025875 File Offset: 0x00023A75
		protected sealed override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_GrabbableToy.toy == null || !this.m_GrabbableToy.toy.isStared)
			{
				yield return null;
			}
			this.OnToyStared();
			yield break;
		}

		// Token: 0x06000705 RID: 1797
		protected abstract void OnToyStared();

		// Token: 0x04000595 RID: 1429
		protected GrabbableToy m_GrabbableToy;
	}
}
