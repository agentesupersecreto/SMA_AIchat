using System;
using Assets._ReusableScripts.CuchiCuchi.Particulas.Penes;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas
{
	// Token: 0x02000157 RID: 343
	[Obsolete("", true)]
	[RequireComponent(typeof(ParticleSystem))]
	public class SemenParticles : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x000240A8 File Offset: 0x000222A8
		public ParticleSystem particulas
		{
			get
			{
				return this.m_semen;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x000240B0 File Offset: 0x000222B0
		public ParticulasDeSemenParaPene peneParticles
		{
			get
			{
				return this.m_peneParticles;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x000240B8 File Offset: 0x000222B8
		public bool esDePene
		{
			get
			{
				return this.m_peneParticles != null;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (set) Token: 0x060007C4 RID: 1988 RVA: 0x000240C6 File Offset: 0x000222C6
		public bool flagToSkipUpdate
		{
			set
			{
				this.m_updater.flagToSkipUpdate = value;
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000240D4 File Offset: 0x000222D4
		public void SimularPor(float time)
		{
			this.m_updater.SimularPor(time);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x000240E2 File Offset: 0x000222E2
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_semen == null)
			{
				this.m_semen = base.GetComponent<ParticleSystem>();
				if (this.m_semen == null)
				{
					throw new ArgumentNullException("m_semen", "m_semen null reference.");
				}
			}
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00024122 File Offset: 0x00022322
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_peneParticles = base.GetComponentInParent<ParticulasDeSemenParaPene>();
			this.m_updater = this.GetComponentNotNull<ParticleSystemUpdater>();
			if (this.esDePene)
			{
				this.m_updater.siempreSimular = true;
			}
		}

		// Token: 0x0400061B RID: 1563
		[SerializeField]
		private ParticleSystem m_semen;

		// Token: 0x0400061C RID: 1564
		[SerializeField]
		private ParticulasDeSemenParaPene m_peneParticles;

		// Token: 0x0400061D RID: 1565
		private ParticleSystemUpdater m_updater;
	}
}
