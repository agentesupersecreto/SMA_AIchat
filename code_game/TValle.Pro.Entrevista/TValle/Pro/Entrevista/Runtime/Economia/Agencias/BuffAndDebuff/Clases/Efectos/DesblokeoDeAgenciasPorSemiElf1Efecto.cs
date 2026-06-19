using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000EB RID: 235
	public sealed class DesblokeoDeAgenciasPorSemiElf1Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorSemiElf1Efecto>
	{
		// Token: 0x06000839 RID: 2105 RVA: 0x0002FD4C File Offset: 0x0002DF4C
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorSemiElf1Efecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, 0, 1, 2, new string[] { "interpretacionDeRaza", "elf" }) >= 1;
		}
	}
}
