using System;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000AA RID: 170
	public class BuffOnAlteratorFemAppValueChangeEffecto : Efecto<BuffOnAlteratorFemAppValueChangeEffecto, BuffOnAlteratorValueChangeArg>
	{
		// Token: 0x0600038F RID: 911 RVA: 0x00014A5C File Offset: 0x00012C5C
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			BuffOnAlteratorValueChangeArg buffOnAlteratorValueChangeArg = argument as BuffOnAlteratorValueChangeArg;
			if (buffOnAlteratorValueChangeArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			AlteradoresDeAparienciaFemenina alteradoresDeAparienciaFemenina = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (alteradoresDeAparienciaFemenina == null)
			{
				return;
			}
			Alterador alterador = alteradoresDeAparienciaFemenina.Obtener(buffOnAlteratorValueChangeArg.alteradorID);
			if (alterador == null)
			{
				return;
			}
			float[] array = new float[alterador.cantidadDeModificadores];
			for (int i = 0; i < array.Length; i++)
			{
				if (buffOnAlteratorValueChangeArg.index < 0 || buffOnAlteratorValueChangeArg.index == i)
				{
					array[i] = buffOnAlteratorValueChangeArg.value;
				}
				else
				{
					array[i] = 0f;
				}
			}
			alterador.AddionarValorUnclamped(array);
			buffEvento.quality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(7f, 13f, Mathf.InverseLerp(0f, 100f, Mathf.Abs(buffOnAlteratorValueChangeArg.value)).OutPow(3f)));
		}

		// Token: 0x06000390 RID: 912 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00014B40 File Offset: 0x00012D40
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			if (!(buff is BuffEvento))
			{
				return;
			}
			BuffOnAlteratorValueChangeArg buffOnAlteratorValueChangeArg = argument as BuffOnAlteratorValueChangeArg;
			if (buffOnAlteratorValueChangeArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			AlteradoresDeAparienciaFemenina alteradoresDeAparienciaFemenina = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (alteradoresDeAparienciaFemenina == null)
			{
				return;
			}
			Alterador alterador = alteradoresDeAparienciaFemenina.Obtener(buffOnAlteratorValueChangeArg.alteradorID);
			if (alterador == null)
			{
				return;
			}
			float[] array = new float[alterador.cantidadDeModificadores];
			for (int i = 0; i < array.Length; i++)
			{
				if (buffOnAlteratorValueChangeArg.index < 0 || buffOnAlteratorValueChangeArg.index == i)
				{
					array[i] = -buffOnAlteratorValueChangeArg.value;
				}
				else
				{
					array[i] = 0f;
				}
			}
			alterador.AddionarValorUnclamped(array);
		}
	}
}
