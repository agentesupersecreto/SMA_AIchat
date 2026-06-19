using System;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x0200004E RID: 78
	[RequireComponent(typeof(PuppetMaster))]
	public sealed class MalePuppetMasterUpdater : PuppetMasterUpdater
	{
		// Token: 0x0600034B RID: 843 RVA: 0x0001097D File Offset: 0x0000EB7D
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.lateUpdateOrder = GlobalUpdater.UpdateType.lateUpdateOnMalePupetMaster;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00010990 File Offset: 0x0000EB90
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.lateUpdateOrder != GlobalUpdater.UpdateType.lateUpdateOnMalePupetMaster)
			{
				Debug.LogWarning("lateUpdateOrder no es en: " + GlobalUpdater.UpdateType.lateUpdateOnMalePupetMaster.ToString());
			}
		}
	}
}
