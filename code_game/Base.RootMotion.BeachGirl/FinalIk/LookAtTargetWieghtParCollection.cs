using System;
using UnityEngine;

namespace Assets.FinalIk
{
	// Token: 0x0200000B RID: 11
	[SerializeField]
	public class LookAtTargetWieghtParCollection
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00002D4F File Offset: 0x00000F4F
		public void Add(LookAtTargetWieghtPar par)
		{
			this.m_pares.Add(par);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002D5E File Offset: 0x00000F5E
		public void Remove(LookAtTargetWieghtPar par)
		{
			this.m_pares.Remove(par);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002D70 File Offset: 0x00000F70
		public bool ExisteTarget()
		{
			if (this.master != null && this.master.LookAtTarget.esValido && this.master.weight > 0f)
			{
				return true;
			}
			for (int i = 0; i < this.m_pares.Count; i++)
			{
				LookAtTargetWieghtPar lookAtTargetWieghtPar = this.m_pares[i];
				if (lookAtTargetWieghtPar.LookAtTarget.esValido && lookAtTargetWieghtPar.weight > 0f)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002DEC File Offset: 0x00000FEC
		public void CalcularCurrentTarget(Vector3 posicionGlobalOrigen, Vector3 bodyForward, out Vector3 target, LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango, out float wSuma, out float lookAtVelocityMod)
		{
			lookAtVelocityMod = 1f;
			float num = 1f;
			float num2 = 1f;
			float num3 = 0f;
			wSuma = 0f;
			Vector3 zero = Vector3.zero;
			Vector3 vector = Vector3.zero;
			float num4 = 0f;
			if (this.master != null && this.master.LookAtTarget.esValido && this.master.weight > 0f)
			{
				float num5 = 0f;
				if (LookAtTargetWieghtParCollection.UpdatePar(this.master, posicionGlobalOrigen, bodyForward, evaluadorEnRango, ref num, ref zero, ref num5, ref wSuma, 1f))
				{
					num4 = this.master.weight;
					if (this.master.weight >= 1f)
					{
						lookAtVelocityMod = num;
						target = posicionGlobalOrigen + zero;
						return;
					}
				}
			}
			for (int i = 0; i < this.m_pares.Count; i++)
			{
				LookAtTargetWieghtParCollection.UpdatePar(this.m_pares[i], posicionGlobalOrigen, bodyForward, evaluadorEnRango, ref num2, ref vector, ref num3, ref wSuma, 1f);
			}
			lookAtVelocityMod = Mathf.Lerp(num2, num, num4);
			if (num3 > 0f && num4 == 0f)
			{
				vector /= num3;
				target = posicionGlobalOrigen + vector;
				return;
			}
			if (num3 > 0f && num4 > 0f)
			{
				vector /= num3;
				target = posicionGlobalOrigen + Vector3.Lerp(vector, zero, num4);
				return;
			}
			if (num3 == 0f && num4 > 0f)
			{
				lookAtVelocityMod = num;
				target = posicionGlobalOrigen + zero;
				return;
			}
			target = Vector3.zero;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002F88 File Offset: 0x00001188
		private static bool UpdatePar(LookAtTargetWieghtPar par, Vector3 posicionGlobalOrigen, Vector3 bodyForward, LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango, ref float lookAtVelocityMod, ref Vector3 dirResult, ref float cantidad, ref float wSuma, float wMod = 1f)
		{
			if (wMod == 0f)
			{
				return true;
			}
			if (par.weight <= 0f || !par.LookAtTarget.esValido)
			{
				return false;
			}
			float num = (par.weight = Mathf.Clamp01(par.weight));
			num *= wMod;
			par.LookAtTarget.Update();
			Vector3 vector = par.LookAtTarget.posicionGlobal - posicionGlobalOrigen;
			if (ExtendedMonoBehaviour.AlmostEqual(vector.sqrMagnitude, 0f, 1E-06f))
			{
				return false;
			}
			if (par.LookAtTarget.config.usarMaxAngleDeVision && evaluadorEnRango != null && !evaluadorEnRango(posicionGlobalOrigen, bodyForward, par.LookAtTarget.posicionGlobal))
			{
				return false;
			}
			lookAtVelocityMod *= par.LookAtTarget.config.lookAtVelocityMod;
			vector *= num;
			dirResult += vector;
			cantidad += 1f;
			wSuma += num;
			return true;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003084 File Offset: 0x00001284
		public static bool CalcularCurrentTargetConPrioridad(LookAtTargetWieghtParCollection master, LookAtTargetWieghtParCollection slave, LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango, Vector3 bodyForward, Vector3 posicionGlobalOrigen, out Vector3 resultado, out float wSuma, out float lookAtVelocityMod)
		{
			lookAtVelocityMod = 1f;
			bool flag = master.ExisteTarget();
			bool flag2 = slave.ExisteTarget();
			if (!flag && !flag2)
			{
				wSuma = 0f;
				resultado = Vector3.zero;
				return false;
			}
			Vector3 zero = Vector3.zero;
			float num = 0f;
			float num2 = 1f;
			if (flag)
			{
				master.CalcularCurrentTarget(posicionGlobalOrigen, bodyForward, out zero, evaluadorEnRango, out num, out num2);
				flag = flag && num > 0f;
			}
			Vector3 zero2 = Vector3.zero;
			float num3 = 0f;
			float num4 = 1f;
			if (flag2)
			{
				if (num < 1f)
				{
					slave.CalcularCurrentTarget(posicionGlobalOrigen, bodyForward, out zero2, evaluadorEnRango, out num3, out num4);
				}
				flag2 = flag2 && num3 > 0f;
			}
			if (!flag && !flag2)
			{
				wSuma = 0f;
				resultado = Vector3.zero;
				return false;
			}
			if (flag && (num >= 1f || !flag2))
			{
				lookAtVelocityMod *= num2;
				wSuma = num;
				resultado = zero;
				return true;
			}
			if (flag2 && !flag)
			{
				lookAtVelocityMod *= num4;
				wSuma = num3;
				resultado = zero2;
				return true;
			}
			if (flag && flag2)
			{
				lookAtVelocityMod = num2 * num4;
				wSuma = num + num3;
				resultado = Vector3.Lerp(zero2, zero, num);
				return true;
			}
			throw new NotSupportedException();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000031C4 File Offset: 0x000013C4
		public static bool CalcularCurrentTargetConPrioridad(LookAtTargetWieghtParCollection master, LookAtTargetWieghtParCollection slave, LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango, Vector3 bodyForward, Vector3 posicionGlobalOrigen, out Vector3 resultado, out float wSuma, out float lookAtVelocityMod, float minDistance)
		{
			if (!LookAtTargetWieghtParCollection.CalcularCurrentTargetConPrioridad(master, slave, evaluadorEnRango, bodyForward, posicionGlobalOrigen, out resultado, out wSuma, out lookAtVelocityMod))
			{
				return false;
			}
			Vector3 vector = resultado - posicionGlobalOrigen;
			if (minDistance <= 0f || vector.sqrMagnitude >= minDistance * minDistance)
			{
				return true;
			}
			vector = vector.normalized * minDistance;
			resultado = posicionGlobalOrigen + vector;
			return true;
		}

		// Token: 0x04000009 RID: 9
		public LookAtTargetWieghtPar master;

		// Token: 0x0400000A RID: 10
		private HashSetList<LookAtTargetWieghtPar> m_pares = new HashSetList<LookAtTargetWieghtPar>();

		// Token: 0x02000112 RID: 274
		// (Invoke) Token: 0x06000A8B RID: 2699
		public delegate bool EvaluadorDeRango(Vector3 origenPosition, Vector3 bodyForward, Vector3 targetPosition);
	}
}
