using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x02000392 RID: 914
	public abstract class ReactorACalculoDeEstimuloBase<TCalculo> : ReactorACalculoDeEstimuloBase where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x060013FD RID: 5117
		public abstract bool ReaccionarACalculo(TCalculo calculo);

		// Token: 0x060013FE RID: 5118
		public abstract bool ReaccionarACalculos(IReadOnlyList<TCalculo> calculos);

		// Token: 0x060013FF RID: 5119 RVA: 0x00056860 File Offset: 0x00054A60
		protected sealed override float ModificadorDeCoolDown(object arg)
		{
			TCalculo tcalculo = arg as TCalculo;
			if (tcalculo == null)
			{
				return 1f;
			}
			ICalculoDeEstimuloReaccionable calculoDeEstimuloReaccionable = arg as ICalculoDeEstimuloReaccionable;
			if (calculoDeEstimuloReaccionable != null && calculoDeEstimuloReaccionable.ignorarCoolDown)
			{
				return 0f;
			}
			float num = 1f;
			switch (tcalculo.tipo)
			{
			case TipoDeCalculoDeEstimulo.None:
				num *= 1f;
				goto IL_00C2;
			case TipoDeCalculoDeEstimulo.frame:
				num *= 1f;
				goto IL_00C2;
			case TipoDeCalculoDeEstimulo.sesionComienza:
				num *= 0.95f;
				goto IL_00C2;
			case TipoDeCalculoDeEstimulo.sesionEnCurso:
				num *= 0.99f;
				goto IL_00C2;
			case TipoDeCalculoDeEstimulo.sesionTermina:
				num *= 0.94f;
				goto IL_00C2;
			}
			throw new ArgumentOutOfRangeException(tcalculo.tipo.ToString());
			IL_00C2:
			if (tcalculo.producidoPor != null)
			{
				TipoDeCalculadorDeEstimulo tipo = tcalculo.producidoPor.tipo;
				switch (tipo)
				{
				case TipoDeCalculadorDeEstimulo.None:
					num *= 1f;
					goto IL_0188;
				case TipoDeCalculadorDeEstimulo.frame:
					num *= 1f;
					goto IL_0188;
				case TipoDeCalculadorDeEstimulo.sesionEspecifica:
					num *= 0.95f;
					goto IL_0188;
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecifica:
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
				case TipoDeCalculadorDeEstimulo.sesionEspecifica | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecifica | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
					break;
				case TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
					num *= 0.9f;
					goto IL_0188;
				case TipoDeCalculadorDeEstimulo.sesionGeneral:
					num *= 0.975f;
					goto IL_0188;
				default:
					if (tipo == TipoDeCalculadorDeEstimulo.sesionGeneralDe)
					{
						num *= 0.96f;
						goto IL_0188;
					}
					if (tipo == TipoDeCalculadorDeEstimulo.sesionGeneralDeTipoDeCualquierEmocion)
					{
						num *= 0.98f;
						goto IL_0188;
					}
					break;
				}
				throw new ArgumentOutOfRangeException(tcalculo.producidoPor.tipo.ToString());
			}
			IL_0188:
			return this.CoolDownModificadorParaCalculo(tcalculo) * num;
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x00056A00 File Offset: 0x00054C00
		protected sealed override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			TCalculo tcalculo = arg as TCalculo;
			if (tcalculo == null)
			{
				return 1f;
			}
			ICalculoDeEstimuloReaccionable calculoDeEstimuloReaccionable = arg as ICalculoDeEstimuloReaccionable;
			if (calculoDeEstimuloReaccionable != null && calculoDeEstimuloReaccionable.ignorarProbabilidad)
			{
				return float.MaxValue;
			}
			float num = 1f;
			switch (tcalculo.tipo)
			{
			case TipoDeCalculoDeEstimulo.None:
				num *= 1f;
				goto IL_00C2;
			case TipoDeCalculoDeEstimulo.frame:
				num *= 1f;
				goto IL_00C2;
			case TipoDeCalculoDeEstimulo.sesionComienza:
				num *= 1.2f;
				goto IL_00C2;
			case TipoDeCalculoDeEstimulo.sesionEnCurso:
				num *= 1.1f;
				goto IL_00C2;
			case TipoDeCalculoDeEstimulo.sesionTermina:
				num *= 1.3f;
				goto IL_00C2;
			}
			throw new ArgumentOutOfRangeException(tcalculo.tipo.ToString());
			IL_00C2:
			if (tcalculo.producidoPor != null)
			{
				TipoDeCalculadorDeEstimulo tipo = tcalculo.producidoPor.tipo;
				switch (tipo)
				{
				case TipoDeCalculadorDeEstimulo.None:
					num *= 1f;
					goto IL_0188;
				case TipoDeCalculadorDeEstimulo.frame:
					num *= 1f;
					goto IL_0188;
				case TipoDeCalculadorDeEstimulo.sesionEspecifica:
					num *= 1.2f;
					goto IL_0188;
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecifica:
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
				case TipoDeCalculadorDeEstimulo.sesionEspecifica | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
				case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecifica | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
					break;
				case TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
					num *= 1.15f;
					goto IL_0188;
				case TipoDeCalculadorDeEstimulo.sesionGeneral:
					num *= 1.05f;
					goto IL_0188;
				default:
					if (tipo == TipoDeCalculadorDeEstimulo.sesionGeneralDe)
					{
						num *= 1.1f;
						goto IL_0188;
					}
					if (tipo == TipoDeCalculadorDeEstimulo.sesionGeneralDeTipoDeCualquierEmocion)
					{
						num *= 1.05f;
						goto IL_0188;
					}
					break;
				}
				throw new ArgumentOutOfRangeException(tcalculo.producidoPor.tipo.ToString());
			}
			IL_0188:
			return this.ProbabilidadPorSegundoModificadorParaCalculo(tcalculo) * num;
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x00056B9E File Offset: 0x00054D9E
		public sealed override bool ReactorPadrePuedeReaccionar(ReactorPadre padre, object arg, out bool negarTodos)
		{
			if (arg == null)
			{
				negarTodos = false;
				return true;
			}
			return this.PadrePuedeReaccionar(padre, arg as TCalculo, arg, out negarTodos);
		}

		// Token: 0x06001402 RID: 5122
		protected abstract bool CalculoEsValido(TCalculo calculo);

		// Token: 0x06001403 RID: 5123
		protected abstract bool ReaccionarCalculo(TCalculo calculo);

		// Token: 0x06001404 RID: 5124
		protected abstract float CoolDownModificadorParaCalculo(TCalculo calculo);

		// Token: 0x06001405 RID: 5125
		protected abstract float ProbabilidadPorSegundoModificadorParaCalculo(TCalculo calculo);

		// Token: 0x06001406 RID: 5126 RVA: 0x00056BBC File Offset: 0x00054DBC
		protected virtual bool PadrePuedeReaccionar(ReactorPadre padre, TCalculo calculo, object arg, out bool negarTodos)
		{
			negarTodos = false;
			return true;
		}
	}
}
