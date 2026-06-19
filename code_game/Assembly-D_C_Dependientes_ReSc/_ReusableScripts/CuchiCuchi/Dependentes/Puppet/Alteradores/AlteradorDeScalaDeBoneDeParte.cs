using System;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Componentes;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Alteradores.Componentes;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Alteradores
{
	// Token: 0x02000130 RID: 304
	[Serializable]
	public class AlteradorDeScalaDeBoneDeParte : AlteradorPorcentajeSingle
	{
		// Token: 0x06000613 RID: 1555 RVA: 0x00022640 File Offset: 0x00020840
		public AlteradorDeScalaDeBoneDeParte(string name, HolderDeAlteradores holder, Transform bone, Muscle musculo, float musculoMod, Vector3 minima, Vector3 maxima)
			: base(name, holder)
		{
			if (bone == null)
			{
				throw new ArgumentNullException("bone", "bone null reference.");
			}
			this.m_minima = minima;
			this.m_maxima = maxima;
			if (musculo != null)
			{
				this.m_usaMuscle = true;
				this.m_scalador = new ScaladorDeColliderPrincipalDeParte<AlteradorDeScalaDeBoneDeParte>(this, bone, musculo, musculoMod);
				return;
			}
			this.m_usaMuscle = false;
			this.m_scalador = new ScaladorLocalDeBone<AlteradorDeScalaDeBoneDeParte>(this, bone);
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public sealed override bool applyAtStart
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x000226AF File Offset: 0x000208AF
		// (set) Token: 0x06000616 RID: 1558 RVA: 0x000226CB File Offset: 0x000208CB
		public bool cambiarAlturaDeCollider
		{
			get
			{
				return this.m_usaMuscle && ((ScaladorDeColliderPrincipalDeParte<AlteradorDeScalaDeBoneDeParte>)this.m_scalador).cambiarAlturaDeCollider;
			}
			set
			{
				if (this.m_usaMuscle)
				{
					((ScaladorDeColliderPrincipalDeParte<AlteradorDeScalaDeBoneDeParte>)this.m_scalador).cambiarAlturaDeCollider = value;
				}
			}
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x000226E6 File Offset: 0x000208E6
		protected sealed override void ResetToStart()
		{
			this.ResetValores();
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x000226EE File Offset: 0x000208EE
		protected override void ApplyDefault()
		{
			this.m_scalador.ScalarADefault();
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x000226FB File Offset: 0x000208FB
		protected override void Apply(float modPolarizado)
		{
			this.m_scalador.Scalar(new Vector3?(this.m_minima), this.m_maxima, modPolarizado);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0002271A File Offset: 0x0002091A
		protected sealed override void Applyed()
		{
			if (this.m_usaMuscle)
			{
				((ScaladorDeColliderPrincipalDeParte<AlteradorDeScalaDeBoneDeParte>)this.m_scalador).ScalarParte();
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected sealed override void ApplyHaciaAbajo(float mod)
		{
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected sealed override void ApplyHaciaArriba(float mod)
		{
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected sealed override void OnStart()
		{
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x000066D6 File Offset: 0x000048D6
		protected sealed override bool Updating()
		{
			return true;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected sealed override void Updated()
		{
		}

		// Token: 0x040004F0 RID: 1264
		[SerializeField]
		protected Vector3 m_minima;

		// Token: 0x040004F1 RID: 1265
		[SerializeField]
		protected Vector3 m_maxima;

		// Token: 0x040004F2 RID: 1266
		private bool m_usaMuscle;

		// Token: 0x040004F3 RID: 1267
		private ScaladorLocalDeBone<AlteradorDeScalaDeBoneDeParte> m_scalador;
	}
}
