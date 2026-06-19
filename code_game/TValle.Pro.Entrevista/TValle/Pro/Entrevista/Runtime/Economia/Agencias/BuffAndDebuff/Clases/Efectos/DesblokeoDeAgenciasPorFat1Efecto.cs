using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000EF RID: 239
	public sealed class DesblokeoDeAgenciasPorFat1Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorFat1Efecto>
	{
		// Token: 0x06000841 RID: 2113 RVA: 0x0002FEBC File Offset: 0x0002E0BC
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorFat1Efecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, 1, 2, new string[] { "interpretacionDeBodySuperficial", "bodyfat" }) >= 1;
		}
	}
}
