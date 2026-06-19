using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000B0 RID: 176
	[Serializable]
	public class BuffOnDeshieloDeEstimuloEnPartesEffecto : Efecto<BuffOnDeshieloDeEstimuloEnPartesEffecto, BuffOnDeshieloDeEstimuloEnPartesArg>
	{
		// Token: 0x060003AA RID: 938 RVA: 0x0001510C File Offset: 0x0001330C
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg = (BuffOnDeshieloDeEstimuloEnPartesArg)argument;
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			DesHielo desHielo = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (desHielo == null)
			{
				return;
			}
			for (int i = 0; i < buffOnDeshieloDeEstimuloEnPartesArg.data.Length; i++)
			{
				BuffOnDeshieloDeEstimuloEnPartesArg.Data data = buffOnDeshieloDeEstimuloEnPartesArg.data[i];
				for (int j = 0; j < data.estimuladas.Length; j++)
				{
					desHielo.SetTo(buffOnDeshieloDeEstimuloEnPartesArg.value, data.tipo, data.estimuladas[j], data.direccion, data.estiulante);
				}
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00015198 File Offset: 0x00013398
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg = (BuffOnDeshieloDeEstimuloEnPartesArg)argument;
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			DesHielo desHielo = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (desHielo == null)
			{
				return;
			}
			for (int i = 0; i < buffOnDeshieloDeEstimuloEnPartesArg.data.Length; i++)
			{
				BuffOnDeshieloDeEstimuloEnPartesArg.Data data = buffOnDeshieloDeEstimuloEnPartesArg.data[i];
				for (int j = 0; j < data.estimuladas.Length; j++)
				{
					desHielo.SetTo(-buffOnDeshieloDeEstimuloEnPartesArg.value, data.tipo, data.estimuladas[j], data.direccion, data.estiulante);
				}
			}
		}
	}
}
