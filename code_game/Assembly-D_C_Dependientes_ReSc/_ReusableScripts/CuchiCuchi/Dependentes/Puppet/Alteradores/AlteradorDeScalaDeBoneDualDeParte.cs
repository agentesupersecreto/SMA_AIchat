using System;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Componentes;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Alteradores
{
	// Token: 0x02000131 RID: 305
	[Serializable]
	public class AlteradorDeScalaDeBoneDualDeParte : AlteradorDeScalaDeBoneDeParte
	{
		// Token: 0x06000620 RID: 1568 RVA: 0x00022734 File Offset: 0x00020934
		public AlteradorDeScalaDeBoneDualDeParte(string name, HolderDeAlteradores holder, Transform bone, Muscle musculo, float musculoMod, Vector3 minima, Vector3 maxima, Transform boneSeg, Vector3 modificadoresParaSegundario)
			: base(name, holder, bone, musculo, musculoMod, minima, maxima)
		{
			if (boneSeg == null)
			{
				throw new ArgumentNullException("boneSeg", "boneSeg null reference.");
			}
			this.m_modificadoresParaSegundario = modificadoresParaSegundario;
			this.m_scalador2 = new ScaladorLocalDeBone<AlteradorDeScalaDeBoneDualDeParte>(this, boneSeg);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00022782 File Offset: 0x00020982
		protected sealed override void ApplyDefault()
		{
			base.ApplyDefault();
			this.m_scalador2.ScalarADefault();
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00022795 File Offset: 0x00020995
		protected sealed override void Apply(float modPolarizado)
		{
			base.Apply(modPolarizado);
			this.m_scalador2.Scalar(new Vector3?(this.m_minima), this.m_maxima, modPolarizado, this.m_modificadoresParaSegundario);
		}

		// Token: 0x040004F4 RID: 1268
		protected Vector3 m_modificadoresParaSegundario;

		// Token: 0x040004F5 RID: 1269
		private ScaladorLocalDeBone<AlteradorDeScalaDeBoneDualDeParte> m_scalador2;
	}
}
