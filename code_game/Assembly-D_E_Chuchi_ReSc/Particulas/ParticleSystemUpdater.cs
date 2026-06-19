using System;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas
{
	// Token: 0x02000156 RID: 342
	[RequireComponent(typeof(ParticleSystem))]
	public sealed class ParticleSystemUpdater : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x00023F8B File Offset: 0x0002218B
		public override int updateEvent1Index
		{
			get
			{
				return 57;
			}
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00023F8F File Offset: 0x0002218F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ParticleSystem = base.GetComponent<ParticleSystem>();
			if (this.m_ParticleSystem == null)
			{
				throw new ArgumentNullException("m_ParticleSystem", "m_ParticleSystem null reference.");
			}
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00023FC1 File Offset: 0x000221C1
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_ParticleSystem != null)
			{
				this.m_ParticleSystem.Clear();
			}
			this.m_flagTurnOff = false;
			this.m_simularPor.ApplyNext(0f);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x00023FFA File Offset: 0x000221FA
		public void SimularPor(float time)
		{
			this.m_flagTurnOff = true;
			this.m_simularPor.ApplyNext(time);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00024010 File Offset: 0x00022210
		public override void OnUpdateEvent1()
		{
			if (!this.m_ParticleSystem.isPaused)
			{
				this.m_ParticleSystem.Pause();
			}
			if (this.flagToSkipUpdate)
			{
				this.flagToSkipUpdate = false;
				return;
			}
			if (!this.m_ParticleSystem.IsAlive())
			{
				return;
			}
			if (this.siempreSimular || this.m_simularPor.isOn)
			{
				this.m_ParticleSystem.Simulate(Time.deltaTime, true, false);
				return;
			}
			if (this.m_flagTurnOff)
			{
				this.m_flagTurnOff = false;
				this.m_ParticleSystem.Clear();
			}
		}

		// Token: 0x04000616 RID: 1558
		public bool flagToSkipUpdate;

		// Token: 0x04000617 RID: 1559
		public bool siempreSimular;

		// Token: 0x04000618 RID: 1560
		[NonSerialized]
		private bool m_flagTurnOff;

		// Token: 0x04000619 RID: 1561
		private CoolDown m_simularPor = new CoolDown();

		// Token: 0x0400061A RID: 1562
		private ParticleSystem m_ParticleSystem;
	}
}
