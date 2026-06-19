using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000F0 RID: 240
	public sealed class DesblokeoDeAgenciasPorTall1Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorTall1Efecto>
	{
		// Token: 0x06000843 RID: 2115 RVA: 0x0002FF14 File Offset: 0x0002E114
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorTall1Efecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, 1, 2, new string[] { "interpretacionDeBodySuperficial", "altura" }) >= 1;
		}
	}
}
