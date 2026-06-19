using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000DC RID: 220
	[Serializable]
	public abstract class AgencyIncomeChangeEfecto<T> : Efecto<T, AgencyIncomeChangeArg> where T : AgencyIncomeChangeEfecto<T>
	{
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600080D RID: 2061
		protected abstract float amount { get; }

		// Token: 0x0600080E RID: 2062 RVA: 0x0002F508 File Offset: 0x0002D708
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ModificadorDeIngresosDeAgenciasDeCharacter modificadorDeIngresosDeAgenciasDeCharacter = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (modificadorDeIngresosDeAgenciasDeCharacter == null)
			{
				return;
			}
			AgencyIncomeChangeArg agencyIncomeChangeArg = argument as AgencyIncomeChangeArg;
			if (agencyIncomeChangeArg == null)
			{
				return;
			}
			ModificadorDeFloat modificadorNotNullDeAgencia = modificadorDeIngresosDeAgenciasDeCharacter.GetModificadorNotNullDeAgencia(agencyIncomeChangeArg.agenciaID, this.id);
			if (modificadorNotNullDeAgencia == null)
			{
				return;
			}
			float num = 1f + this.amount / 100f;
			num = Mathf.Clamp(num, 0f, float.MaxValue);
			modificadorNotNullDeAgencia.valor.valor = 1f;
			for (int i = 0; i < stacks; i++)
			{
				ModificadorDeFloat modificadorDeFloat = modificadorNotNullDeAgencia;
				modificadorDeFloat.valor.valor = modificadorDeFloat.valor.valor * num;
			}
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0002F5A9 File Offset: 0x0002D7A9
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0002F5B0 File Offset: 0x0002D7B0
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ModificadorDeIngresosDeAgenciasDeCharacter modificadorDeIngresosDeAgenciasDeCharacter = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (modificadorDeIngresosDeAgenciasDeCharacter == null)
			{
				return;
			}
			AgencyIncomeChangeArg agencyIncomeChangeArg = argument as AgencyIncomeChangeArg;
			if (agencyIncomeChangeArg == null)
			{
				return;
			}
			ModificadorDeFloat modificadorNotNullDeAgencia = modificadorDeIngresosDeAgenciasDeCharacter.GetModificadorNotNullDeAgencia(agencyIncomeChangeArg.agenciaID, this.id);
			if (modificadorNotNullDeAgencia == null)
			{
				return;
			}
			modificadorNotNullDeAgencia.valor.valor = 1f;
		}
	}
}
