using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Skins.PhysicsScripts
{
	// Token: 0x0200006C RID: 108
	[Serializable]
	public class HitSkinColision : ColisionPhysicaV2
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00005317 File Offset: 0x00003517
		public Skin skin
		{
			get
			{
				return this.m_skin;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060001FA RID: 506 RVA: 0x0000531F File Offset: 0x0000351F
		public IReadOnlyList<ParteDelCuerpoHumano> partesHumanasImpactadas
		{
			get
			{
				return this.m_partesHumanasImpactadas;
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00005328 File Offset: 0x00003528
		public void Poblar(Skin skin, IStepVelocitySaverEmulated nosotrosSaver, Transform boneTarget, Collision collision, RaycastHit hit, IReadOnlyList<ParteDelCuerpoHumano> partesImpactadasCopia)
		{
			this.m_skin = skin;
			if (this.m_partesHumanasImpactadas == null)
			{
				this.m_partesHumanasImpactadas = new List<ParteDelCuerpoHumano>();
			}
			if (this.m_partesHumanasImpactadas.Count > 0)
			{
				this.m_partesHumanasImpactadas.Clear();
			}
			for (int i = 0; i < partesImpactadasCopia.Count; i++)
			{
				this.m_partesHumanasImpactadas.Add(partesImpactadasCopia[i]);
			}
			base.PoblarDesdeCollision(collision, hit.normal, hit.point, nosotrosSaver, boneTarget);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000053A5 File Offset: 0x000035A5
		protected override void OnClearPhysica()
		{
			this.m_skin = null;
			if (this.m_partesHumanasImpactadas != null)
			{
				this.m_partesHumanasImpactadas.Clear();
			}
		}

		// Token: 0x04000147 RID: 327
		private Skin m_skin;

		// Token: 0x04000148 RID: 328
		private List<ParteDelCuerpoHumano> m_partesHumanasImpactadas;
	}
}
