using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scriptables
{
	// Token: 0x02000059 RID: 89
	[CreateAssetMenu(fileName = "MuscleConfig", menuName = "CuChiCuChi/Configuraciones/ConfiguracionDeMusculos")]
	public class ReusableMusclesConfig : ScriptableObject
	{
		// Token: 0x060003F3 RID: 1011 RVA: 0x00013264 File Offset: 0x00011464
		public void CopiarDesde(ReusableMusclesConfig other)
		{
			this.musclesConfig.CopiarDesde(other.musclesConfig);
		}

		// Token: 0x0400029D RID: 669
		public PuppetMusclesConfig musclesConfig = new PuppetMusclesConfig();
	}
}
