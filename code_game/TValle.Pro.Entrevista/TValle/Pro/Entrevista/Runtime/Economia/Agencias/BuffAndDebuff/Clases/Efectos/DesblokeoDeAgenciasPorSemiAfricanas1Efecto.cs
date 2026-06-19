using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000E9 RID: 233
	public sealed class DesblokeoDeAgenciasPorSemiAfricanas1Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorSemiAfricanas1Efecto>
	{
		// Token: 0x06000835 RID: 2101 RVA: 0x0002FC94 File Offset: 0x0002DE94
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorSemiAfricanas1Efecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, 0, 1, 2, new string[] { "interpretacionDeRaza", "african" }) >= 1;
		}
	}
}
