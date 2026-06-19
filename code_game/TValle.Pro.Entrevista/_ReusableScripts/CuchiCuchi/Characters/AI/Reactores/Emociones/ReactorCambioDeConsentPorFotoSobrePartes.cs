using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.AI.Reactores.Emociones
{
	// Token: 0x02000023 RID: 35
	public class ReactorCambioDeConsentPorFotoSobrePartes : ReactorACalculoDeEstimulo<ICalculoDeEstimuloVisual>
	{
		// Token: 0x06000166 RID: 358 RVA: 0x00008334 File Offset: 0x00006534
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_ConsentToHero = this.GetComponentEnRoot(false);
			if (this.m_ConsentToHero == null)
			{
				throw new ArgumentNullException("m_ConsentToHero", "m_ConsentToHero null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_ConsentPorInteraciones = this.GetComponentEnRoot(false);
			if (this.m_ConsentPorInteraciones == null)
			{
				throw new ArgumentNullException("m_ConsentPorInteraciones", "m_ConsentPorInteraciones null reference.");
			}
			this.m_Char = this.GetComponentEnRoot(false);
			if (this.m_Char == null)
			{
				throw new ArgumentNullException("m_Char", "m_Char null reference.");
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00008420 File Offset: 0x00006620
		protected override bool CalculoEsValido(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.tipo != TipoDeCalculoDeEstimulo.frame)
			{
				return false;
			}
			if (calculo.estimulo.tipoDeEstimuloVisual != TipoDeEstimuloVisual.fotografiada)
			{
				return false;
			}
			if (calculo.emocion.reaccion != ReaccionHumana.placer)
			{
				return false;
			}
			if (!this.YaAceptoModelaje())
			{
				return false;
			}
			float num;
			this.m_ConsentNecesario.EsConsentidoMaximoConJerarquia(calculo, out num, null, null);
			return num >= 0.5f;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00008487 File Offset: 0x00006687
		private bool YaAceptoModelaje()
		{
			return MemoriaDeSMAModelosFemeninas.AceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, this.m_Char.ID_UnicoString);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000084A0 File Offset: 0x000066A0
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloVisual calculo)
		{
			if (this.m_ConsentPorInteraciones.alMaximo || this.m_ConsentToHero.valueAtMax)
			{
				return false;
			}
			MapaDePersonalidad personalidad = this.m_Personalidad.currentPersonalidad.personalidad;
			if (personalidad == null)
			{
				return false;
			}
			float num = personalidad.CurrentMaxConsentPorInteraciones() / 2f / (float)ParteDelCuerpoHumanoHelper.partesDeInteraccionFemenina.Count;
			float num2 = Mathf.InverseLerp(90f, 20f, calculo.estimulo.angleDesdePuntoVisual).OutPow(2f);
			if (num2 <= 0f)
			{
				return false;
			}
			float num3 = Mathf.InverseLerp(2f, 0.3f, calculo.estimulo.distancia).OutPow(2f);
			if (num3 <= 0f)
			{
				return false;
			}
			bool flag = false;
			for (int i = 0; i < calculo.estimulo.partesDelCuerpoHumanoEstimuladas.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.estimulo.partesDelCuerpoHumanoEstimuladas[i];
				float num4;
				if (!this.m_addiciones.TryGetValue((int)parteDelCuerpoHumano, out num4))
				{
					num4 = 0f;
					this.m_addiciones.Add((int)parteDelCuerpoHumano, num4);
				}
				if (num4 < 1f)
				{
					float num5 = num2 * num3;
					float num6 = Mathf.Clamp(num5, 0f, 1f - num4);
					if (num6 > 0f)
					{
						this.m_ConsentPorInteraciones.Cambiar(num * num6, calculo);
						this.m_addiciones[(int)parteDelCuerpoHumano] = Mathf.Clamp01(this.m_addiciones[(int)parteDelCuerpoHumano] + num5);
						flag = true;
					}
				}
			}
			return flag;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00008623 File Offset: 0x00006823
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000862A File Offset: 0x0000682A
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x040000D5 RID: 213
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x040000D6 RID: 214
		private ConsentToHero m_ConsentToHero;

		// Token: 0x040000D7 RID: 215
		private Personalidad m_Personalidad;

		// Token: 0x040000D8 RID: 216
		private ConsentPorInteraciones m_ConsentPorInteraciones;

		// Token: 0x040000D9 RID: 217
		private IntKeyFloatValueDictionary m_addiciones = new IntKeyFloatValueDictionary();

		// Token: 0x040000DA RID: 218
		private Character m_Char;
	}
}
