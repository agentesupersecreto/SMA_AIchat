using System;
using UnityEngine.SceneManagement;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Scenas
{
	// Token: 0x020002E2 RID: 738
	public abstract class ScenaAI : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060012AA RID: 4778 RVA: 0x0005939D File Offset: 0x0005759D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.ownScena = base.gameObject.scene;
			SceneManager.sceneUnloaded += this.SceneManager_sceneUnloaded;
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x000593C7 File Offset: 0x000575C7
		private void SceneManager_sceneUnloaded(Scene arg0)
		{
			if (this.ownScena == arg0)
			{
				this.OnUnload();
			}
		}

		// Token: 0x060012AC RID: 4780
		protected abstract void OnUnload();

		// Token: 0x04000D95 RID: 3477
		protected Scene ownScena;
	}
}
