using System;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000DA RID: 218
	[Serializable]
	public sealed class AgencyEarningsEfecto : Efecto<AgencyEarningsEfecto, AgencyEarningsArg>
	{
		// Token: 0x06000808 RID: 2056 RVA: 0x0002F3C4 File Offset: 0x0002D5C4
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			CharacterWallet characterWallet = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (characterWallet == null)
			{
				return;
			}
			AgencyEarningsArg agencyEarningsArg = argument as AgencyEarningsArg;
			if (agencyEarningsArg == null)
			{
				return;
			}
			Agencia agencia = caster as Agencia;
			float num = 1f;
			MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
			ModificadorDeIngresosDeAgenciasDeCharacter modificadorDeIngresosDeAgenciasDeCharacter = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
			if (modificadorDeIngresosDeAgenciasDeCharacter != null && !string.IsNullOrWhiteSpace((agencia != null) ? agencia.ID : null))
			{
				ModificableDeFloat modifiacableDeAgencia = modificadorDeIngresosDeAgenciasDeCharacter.GetModifiacableDeAgencia(agencia.ID);
				num = ((modifiacableDeAgencia != null) ? new float?(modifiacableDeAgencia.ModificarValor(1f)) : null).GetValueOrDefault(1f);
			}
			for (int i = 0; i < stacks; i++)
			{
				float num2 = agencyEarningsArg.income;
				for (int j = 0; j < agencyEarningsArg.bonuses; j++)
				{
					num2 *= agencyEarningsArg.bonusMod;
				}
				for (int k = 0; k < agencyEarningsArg.antiBonuses; k++)
				{
					num2 *= agencyEarningsArg.antiBonusMod;
				}
				characterWallet.Change("fiat", num2 * num, (agencia != null) ? agencia.nombre : null);
			}
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0002F4E8 File Offset: 0x0002D6E8
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0002F4EF File Offset: 0x0002D6EF
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			throw new NotImplementedException();
		}
	}
}
