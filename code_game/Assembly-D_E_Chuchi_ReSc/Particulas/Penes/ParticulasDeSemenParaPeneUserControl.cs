using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas.Penes
{
	// Token: 0x02000161 RID: 353
	[Obsolete("las eyaculaciones no van a ser manuales")]
	[RequireComponent(typeof(ParticulasDeSemenParaPene))]
	public class ParticulasDeSemenParaPeneUserControl : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x00004252 File Offset: 0x00002452
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00025861 File Offset: 0x00023A61
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ParticulasDeSemenParaPene = base.GetComponent<ParticulasDeSemenParaPene>();
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00025875 File Offset: 0x00023A75
		public sealed override void OnUpdateEvent1()
		{
			base.OnUpdateEvent1();
			if (Input.GetKeyUp(this.key))
			{
				this.m_ParticulasDeSemenParaPene.Eyacular(1f, 1f, 1f);
			}
		}

		// Token: 0x04000661 RID: 1633
		public KeyCode key = KeyCode.P;

		// Token: 0x04000662 RID: 1634
		private ParticulasDeSemenParaPene m_ParticulasDeSemenParaPene;
	}
}
