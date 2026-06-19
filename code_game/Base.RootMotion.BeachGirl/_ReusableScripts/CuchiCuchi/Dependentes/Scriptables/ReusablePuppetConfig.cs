using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scriptables
{
	// Token: 0x0200005A RID: 90
	[CreateAssetMenu(fileName = "PuppetConfig", menuName = "CuChiCuChi/Configuraciones/ConfiguracionDePuppet")]
	public class ReusablePuppetConfig : ScriptableObject
	{
		// Token: 0x0400029E RID: 670
		public PuppetConfig puppetConfig = new PuppetConfig();
	}
}
