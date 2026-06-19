using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000ED RID: 237
	public sealed class DesblokeoDeAgenciasPorSemiNordic1Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorSemiNordic1Efecto>
	{
		// Token: 0x0600083D RID: 2109 RVA: 0x0002FE04 File Offset: 0x0002E004
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorSemiNordic1Efecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, 0, 1, 2, new string[] { "interpretacionDeRaza", "nordic" }) >= 1;
		}
	}
}
