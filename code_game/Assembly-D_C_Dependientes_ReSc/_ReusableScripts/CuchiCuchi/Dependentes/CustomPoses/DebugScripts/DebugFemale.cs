using System;
using System.Collections;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.CustomPoses.DebugScripts
{
	// Token: 0x02000192 RID: 402
	public class DebugFemale : CustomMonobehaviour
	{
		// Token: 0x06000978 RID: 2424 RVA: 0x0002F04A File Offset: 0x0002D24A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_char = this.GetComponentEnRoot(false);
			base.SetYieldStart();
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0002F065 File Offset: 0x0002D265
		protected override IEnumerator YieldStartUnityEvent()
		{
			yield return new WaitForSeconds(3f);
			if (!Application.isEditor)
			{
				yield break;
			}
			if (this.setMaxVagDesgaste)
			{
				VagController componentInChildren = this.m_char.GetComponentInChildren<VagController>();
				((IHoleDesgastableDebug)componentInChildren).SumarMotion(1f);
				((IHoleDesgastableDebug)componentInChildren).SumarAnchura(1f);
				((IHoleDesgastableDebug)componentInChildren).SumarProfundidad(1f);
				yield return null;
			}
			if (this.setMaxAnusDesgaste)
			{
				AnusController componentInChildren2 = this.m_char.GetComponentInChildren<AnusController>();
				((IHoleDesgastableDebug)componentInChildren2).SumarMotion(1f);
				((IHoleDesgastableDebug)componentInChildren2).SumarAnchura(1f);
				((IHoleDesgastableDebug)componentInChildren2).SumarProfundidad(1f);
				yield return null;
			}
			if (this.setMaxVagHardPointsDesgaste)
			{
				this.m_char.GetComponentInChildren<VagHole>().hardPointsList.ForEach(delegate(HoleVirtualHardPoint x)
				{
					x.desgaste = 1f;
				});
				yield return null;
			}
			if (this.setMaxAnusHardPointsDesgaste)
			{
				this.m_char.GetComponentInChildren<AnusHole>().hardPointsList.ForEach(delegate(HoleVirtualHardPoint x)
				{
					x.desgaste = 1f;
				});
				yield return null;
			}
			if (this.disableAI)
			{
				this.m_char.GetComponentInChildren<FemaleSimpleAi>().gameObject.SetActive(false);
				yield return null;
			}
			yield break;
		}

		// Token: 0x04000706 RID: 1798
		public bool disableAI;

		// Token: 0x04000707 RID: 1799
		public bool setMaxVagDesgaste;

		// Token: 0x04000708 RID: 1800
		public bool setMaxAnusDesgaste;

		// Token: 0x04000709 RID: 1801
		public bool setMaxVagHardPointsDesgaste;

		// Token: 0x0400070A RID: 1802
		public bool setMaxAnusHardPointsDesgaste;

		// Token: 0x0400070B RID: 1803
		private FemaleChar m_char;
	}
}
