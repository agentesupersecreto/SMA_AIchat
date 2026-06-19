using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000EE RID: 238
	public sealed class DesblokeoDeAgenciasPorFit1Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorFit1Efecto>
	{
		// Token: 0x0600083F RID: 2111 RVA: 0x0002FE60 File Offset: 0x0002E060
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorFit1Efecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, -1, -2, new string[] { "interpretacionDeBodySuperficial", "bodyfat" }) >= 1;
		}
	}
}
