using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x02000329 RID: 809
	[Obsolete("", true)]
	[Serializable]
	public class ModificadorPorCambiosEnCalculos
	{
		// Token: 0x06001464 RID: 5220 RVA: 0x0005F4E8 File Offset: 0x0005D6E8
		public float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo, MonoBehaviour contexto, Personalidad personalidad, bool debugLog)
		{
			float num = 1f;
			return this.UpdateNextCoolDown(calculo, contexto, personalidad, debugLog) * num;
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x0005F508 File Offset: 0x0005D708
		public void OnBarked(ICalculoDeEstimulo calculo)
		{
			ModificadorPorCambiosEnCalculos.SetEstado(this.m_lastEstado, calculo);
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x0005F518 File Offset: 0x0005D718
		protected virtual float UpdateNextCoolDown(ICalculoDeEstimulo calculo, MonoBehaviour contexto, Personalidad personalidad, bool debugLog)
		{
			ModificadorPorCambiosEnCalculos.SetEstado(this.m_coolDownEstado, calculo);
			float num = this.m_coolDownEstado.Calcule(this.m_lastEstado, contexto, debugLog, calculo, personalidad);
			return Mathf.Lerp(1f, num, this.efectividadDeModDeCooldownPorCambioDeEstado);
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x0005F55C File Offset: 0x0005D75C
		private static void SetEstado(ModificadorPorCambiosEnCalculos.Estado estado, ICalculoDeEstimulo calculo)
		{
			estado.m_lastTipoDeCalculoDeEstimulo = ((calculo != null) ? new TipoDeCalculoDeEstimulo?(calculo.tipo) : null);
			if (calculo.emocion == null)
			{
				estado.m_lastReaccion = null;
			}
			else
			{
				estado.m_lastReaccion = new ReaccionHumana?(calculo.emocion.reaccion);
			}
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			if (calculoDeInteracionEstimulante == null)
			{
				estado.m_lastParte = null;
				estado.m_lastTipoEstimulo = null;
				estado.m_lastDireccionEstimulo = null;
			}
			else
			{
				InteracionEstimulanteBasica estimuloBasico = calculoDeInteracionEstimulante.estimuloBasico;
				estado.m_lastParte = new ParteDelCuerpoHumano?(estimuloBasico.partePrincipalEstimulada);
				estado.m_lastTipoEstimulo = new TipoDeEstimulo?(estimuloBasico.tipoDeEstimulo);
				estado.m_lastDireccionEstimulo = new DireccionDeEstimulo?(estimuloBasico.tipo);
			}
			ICalculoDeEstimuloDeParteEstimulante calculoDeEstimuloDeParteEstimulante = calculo as ICalculoDeEstimuloDeParteEstimulante;
			if (calculoDeInteracionEstimulante == null)
			{
				estado.m_lastEstimulante = null;
				return;
			}
			estado.m_lastEstimulante = new ParteQuePuedeEstimular?(calculoDeEstimuloDeParteEstimulante.estimulanteParte);
		}

		// Token: 0x04000E93 RID: 3731
		[Range(0f, 1f)]
		public float efectividadDeModDeCooldownPorCambioDeEstado = 1f;

		// Token: 0x04000E94 RID: 3732
		private ModificadorPorCambiosEnCalculos.Estado m_lastEstado = new ModificadorPorCambiosEnCalculos.Estado();

		// Token: 0x04000E95 RID: 3733
		private ModificadorPorCambiosEnCalculos.Estado m_coolDownEstado = new ModificadorPorCambiosEnCalculos.Estado();

		// Token: 0x0200032A RID: 810
		[Obsolete("", true)]
		protected class Estado
		{
			// Token: 0x06001469 RID: 5225 RVA: 0x0005F678 File Offset: 0x0005D878
			public float Calcule(ModificadorPorCambiosEnCalculos.Estado other, MonoBehaviour contexto, bool isdebugLog, ICalculoDeEstimulo calculo, Personalidad personalidad)
			{
				float num = 1f;
				ReaccionHumana? lastReaccion = other.m_lastReaccion;
				ReaccionHumana? lastReaccion2 = this.m_lastReaccion;
				if (!((lastReaccion.GetValueOrDefault() == lastReaccion2.GetValueOrDefault()) & (lastReaccion != null == (lastReaccion2 != null))))
				{
					if (isdebugLog)
					{
						Debug.Log("REDUCCION DE COOLDONW POR REACCION DIFERENTE", contexto);
						Debug.Log("current: " + this.m_lastReaccion.GetValueOrDefault().ToString() + ", last: " + other.m_lastReaccion.GetValueOrDefault().ToString(), contexto);
					}
					num *= 0.2f;
					if (this.m_lastReaccion != null)
					{
						ReaccionHumana value = this.m_lastReaccion.Value;
						if (value != ReaccionHumana.dolor)
						{
							if (value == ReaccionHumana.rabia)
							{
								num *= 0.5f;
							}
						}
						else
						{
							num *= 0.8f;
						}
					}
				}
				TipoDeCalculoDeEstimulo? lastTipoDeCalculoDeEstimulo = other.m_lastTipoDeCalculoDeEstimulo;
				TipoDeCalculoDeEstimulo? lastTipoDeCalculoDeEstimulo2 = this.m_lastTipoDeCalculoDeEstimulo;
				if (!((lastTipoDeCalculoDeEstimulo.GetValueOrDefault() == lastTipoDeCalculoDeEstimulo2.GetValueOrDefault()) & (lastTipoDeCalculoDeEstimulo != null == (lastTipoDeCalculoDeEstimulo2 != null))))
				{
					if (isdebugLog)
					{
						Debug.Log("REDUCCION DE COOLDONW POR TipoDeCalculoDeEstimulo DIFERENTE", contexto);
						Debug.Log("current: " + this.m_lastTipoDeCalculoDeEstimulo.GetValueOrDefault().ToString() + ", last: " + other.m_lastTipoDeCalculoDeEstimulo.GetValueOrDefault().ToString(), contexto);
					}
					num *= 0.666f;
					if (this.m_lastTipoDeCalculoDeEstimulo != null)
					{
						TipoDeCalculoDeEstimulo value2 = this.m_lastTipoDeCalculoDeEstimulo.Value;
						if (value2 != TipoDeCalculoDeEstimulo.sesionComienza)
						{
							if (value2 != TipoDeCalculoDeEstimulo.sesionEnCurso)
							{
								if (value2 == TipoDeCalculoDeEstimulo.sesionTermina)
								{
									num *= 0.3f;
								}
							}
							else
							{
								num *= 0.7f;
							}
						}
						else
						{
							num *= 0.5f;
						}
					}
				}
				if (this.m_lastReaccion != null && !this.m_lastReaccion.Value.EsPositiva())
				{
					if (isdebugLog)
					{
						Debug.Log("REDUCCION DE COOLDONW POR REACCION NEGATIVA", contexto);
						Debug.Log("current: " + this.m_lastReaccion.GetValueOrDefault().ToString(), contexto);
					}
					num *= 0.8f;
				}
				ParteDelCuerpoHumano? lastParte = other.m_lastParte;
				ParteDelCuerpoHumano? lastParte2 = this.m_lastParte;
				if (!((lastParte.GetValueOrDefault() == lastParte2.GetValueOrDefault()) & (lastParte != null == (lastParte2 != null))))
				{
					if (this.m_lastParte != null && personalidad.EsPrivada(this.m_lastParte.Value, (this.m_lastTipoEstimulo != null) ? this.m_lastTipoEstimulo.Value : TipoDeEstimulo.visual))
					{
						num *= 0.666f;
					}
					if (isdebugLog)
					{
						Debug.Log("REDUCCION DE COOLDONW POR PARTE ESTIMULADA DIFERENTE", contexto);
						Debug.Log("current: " + this.m_lastParte.GetValueOrDefault().ToString() + ", last: " + other.m_lastParte.GetValueOrDefault().ToString(), contexto);
					}
					num *= 0.666f;
				}
				ParteQuePuedeEstimular? lastEstimulante = other.m_lastEstimulante;
				ParteQuePuedeEstimular? lastEstimulante2 = this.m_lastEstimulante;
				if (!((lastEstimulante.GetValueOrDefault() == lastEstimulante2.GetValueOrDefault()) & (lastEstimulante != null == (lastEstimulante2 != null))))
				{
					if (this.m_lastEstimulante != null && this.m_lastEstimulante.Value.EsPrivada())
					{
						num *= 0.666f;
					}
					if (isdebugLog)
					{
						Debug.Log("REDUCCION DE COOLDONW POR PARTE ESTIMULANTE DIFERENTE", contexto);
						Debug.Log("current: " + this.m_lastEstimulante.GetValueOrDefault().ToString() + ", last: " + other.m_lastEstimulante.GetValueOrDefault().ToString(), contexto);
					}
					num *= 0.666f;
				}
				TipoDeEstimulo? lastTipoEstimulo = other.m_lastTipoEstimulo;
				TipoDeEstimulo? lastTipoEstimulo2 = this.m_lastTipoEstimulo;
				if (!((lastTipoEstimulo.GetValueOrDefault() == lastTipoEstimulo2.GetValueOrDefault()) & (lastTipoEstimulo != null == (lastTipoEstimulo2 != null))))
				{
					if (isdebugLog)
					{
						Debug.Log("REDUCCION DE COOLDONW POR TIPO DE ESTIMULO DIFERENTE", contexto);
						Debug.Log("current: " + this.m_lastTipoEstimulo.GetValueOrDefault().ToString() + ", last: " + other.m_lastTipoEstimulo.GetValueOrDefault().ToString(), contexto);
					}
					num *= 0.333f;
				}
				DireccionDeEstimulo? lastDireccionEstimulo = other.m_lastDireccionEstimulo;
				DireccionDeEstimulo? lastDireccionEstimulo2 = this.m_lastDireccionEstimulo;
				if (!((lastDireccionEstimulo.GetValueOrDefault() == lastDireccionEstimulo2.GetValueOrDefault()) & (lastDireccionEstimulo != null == (lastDireccionEstimulo2 != null))))
				{
					if (isdebugLog)
					{
						Debug.Log("REDUCCION DE COOLDONW POR DIRECCION DE ESTIMULO DIFERENTE", contexto);
						Debug.Log("current: " + this.m_lastDireccionEstimulo.GetValueOrDefault().ToString() + ", last: " + other.m_lastDireccionEstimulo.GetValueOrDefault().ToString(), contexto);
					}
					num *= 0.333f;
				}
				return num;
			}

			// Token: 0x04000E96 RID: 3734
			public ReaccionHumana? m_lastReaccion;

			// Token: 0x04000E97 RID: 3735
			public ParteDelCuerpoHumano? m_lastParte;

			// Token: 0x04000E98 RID: 3736
			public ParteQuePuedeEstimular? m_lastEstimulante;

			// Token: 0x04000E99 RID: 3737
			public TipoDeEstimulo? m_lastTipoEstimulo;

			// Token: 0x04000E9A RID: 3738
			public DireccionDeEstimulo? m_lastDireccionEstimulo;

			// Token: 0x04000E9B RID: 3739
			public TipoDeCalculoDeEstimulo? m_lastTipoDeCalculoDeEstimulo;
		}
	}
}
