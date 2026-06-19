using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts
{
	// Token: 0x02000203 RID: 515
	public abstract class CalculoDeEmocionesPorCambioDePose : CalculoDeEstimuloPor<CalculoDeEstimuloCambioDePoseResultado, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose>, KeyValuePair<int, EstimuloPorCambiarPose>, CalculoDeEmocionesPorCambioDePoseConfiguracion, CambiosDePoseByMainInFrame>, ICalculadorDeEstimuloDeCambioDePose, ICalculadorDeEstimulo<ICalculoDeEstimuloPorCambioDePose>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeEstimulo<CalculoDeEstimuloCambioDePoseResultado>, ICalculadorDeEstimuloIgnoradorEnPartesHumanas
	{
		// Token: 0x06000CA3 RID: 3235 RVA: 0x0003AC4D File Offset: 0x00038E4D
		ICalculoDeEstimuloPorCambioDePose ICalculadorDeEstimulo<ICalculoDeEstimuloPorCambioDePose>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x0003AC56 File Offset: 0x00038E56
		ICalculoDeEstimuloPorCambioDePose ICalculadorDeEstimulo<ICalculoDeEstimuloPorCambioDePose>.GetCalculoEnFrame(int index)
		{
			return base.GetCalculoEnFrame(index);
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000CA5 RID: 3237
		protected abstract PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana { get; }

		// Token: 0x06000CA6 RID: 3238 RVA: 0x0003AC5F File Offset: 0x00038E5F
		public void IgnorarParteHumana(ParteDelCuerpoHumano parte, bool ignorar)
		{
			if (ignorar)
			{
				if (!this.ignorarSiEstaEn.Contains(parte))
				{
					this.ignorarSiEstaEn.Add(parte);
					return;
				}
			}
			else
			{
				while (this.ignorarSiEstaEn.Contains(parte))
				{
					this.ignorarSiEstaEn.Remove(parte);
				}
			}
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x0003AC9C File Offset: 0x00038E9C
		protected sealed override bool ItemEsValido(KeyValuePair<int, EstimuloPorCambiarPose> item, int index)
		{
			ParteQuePuedeEstimular key = (ParteQuePuedeEstimular)item.Key;
			return key != ParteQuePuedeEstimular.None && item.Value != null && !this.ignorarSiEstaEn.Contains(item.Value.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana)) && this.EstimuloEsValido(key, item.Value);
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x000066D6 File Offset: 0x000048D6
		protected virtual bool EstimuloEsValido(ParteQuePuedeEstimular estimulanteParte, EstimuloPorCambiarPose estimulo)
		{
			return true;
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public sealed override DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000CAA RID: 3242
		protected abstract float maxEmocionValuePorGrupoMod { get; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000CAB RID: 3243
		protected abstract PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo { get; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000CAC RID: 3244
		protected abstract FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada { get; }

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000CAD RID: 3245
		protected abstract DatosDeUmbral datosDeUmbral { get; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000CAE RID: 3246
		protected abstract FloatPorGrupoDicc maxEmocionValuePorGrupo { get; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x0003ACF0 File Offset: 0x00038EF0
		[Obsolete("", true)]
		public ICalculoDeEstimuloPorCambioDePose calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x0003ACF0 File Offset: 0x00038EF0
		[Obsolete("", true)]
		CalculoDeEstimuloCambioDePoseResultado ICalculadorDeEstimulo<CalculoDeEstimuloCambioDePoseResultado>.calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x0003ACF8 File Offset: 0x00038EF8
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloPorCambioDePose> resultado)
		{
			for (int i = 0; i < this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count; i++)
			{
				resultado.Add(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i]);
			}
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0003AD2D File Offset: 0x00038F2D
		protected sealed override void SortMasFuerteAlMasDebil(List<CalculoDeEstimuloCambioDePoseResultado> calculos)
		{
			if (CalculoDeEmocionesPorCambioDePose.comparison == null)
			{
				CalculoDeEmocionesPorCambioDePose.comparison = (CalculoDeEstimuloCambioDePoseResultado a, CalculoDeEstimuloCambioDePoseResultado b) => -1 * a.data.estado.estimulacionGeneradaEnFrame.CompareTo(b.data.estado.estimulacionGeneradaEnFrame);
			}
			calculos.Sort(CalculoDeEmocionesPorCambioDePose.comparison);
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected sealed override void OnOldDataCleared()
		{
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x0003AD68 File Offset: 0x00038F68
		protected sealed override void PoblarDataConItem(CalculoDeEstimuloCambioDePoseResultado data, KeyValuePair<int, EstimuloPorCambiarPose> item, int index, float deltaTime, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> allitems)
		{
			data.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloPorCambiarPose value = item.Value;
			ParteDelCuerpoHumano parteDelCuerpoHumano = value.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			ParteQuePuedeEstimular key = (ParteQuePuedeEstimular)item.Key;
			DatosDeUmbral datosDeUmbral = this.datosDeUmbral;
			if (value == null)
			{
				throw new ArgumentNullException("estimulo", "estimulo null reference.");
			}
			if (datosDeUmbral == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			DatosDeUmbral datosDeUmbral2 = datosDeUmbral;
			float num = (value.cambioManualmente ? value.velocidadRelativaEmulada : 1f);
			RangeValueV2 intervaloDeGeneracion = datosDeUmbral2.intervaloDeGeneracion;
			ValorModificable estimulacionQueGenera = datosDeUmbral2.estimulacionQueGenera;
			this.OnPreUmbralCalculo(key, parteDelCuerpoHumano, value, ref num, ref intervaloDeGeneracion, ref estimulacionQueGenera);
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			try
			{
				estado = UmbralBasico.Calcular(num, deltaTime, UmbralBasico.TipoDeCambio.unico, intervaloDeGeneracion, estimulacionQueGenera.total, datosDeUmbral2.spotBonuses, datosDeUmbral.promedioMod, datosDeUmbral.modPorEncima, datosDeUmbral.modPorDebajo);
				float estimulacionGeneradaEnFrame = estado.estimulacionGeneradaEnFrame;
				this.OnPostUmbralCalculo(key, value, ref estimulacionGeneradaEnFrame);
				estado.SetEstimulacionGeneradaEnFrame(estimulacionGeneradaEnFrame);
				estado.SetEstimulacionGeneradaTotal(estimulacionGeneradaEnFrame);
			}
			catch (Exception)
			{
				Debug.LogWarning("Error calculando UmbralBasico de emocion " + this.m_Emo.GetType().Name);
				throw;
			}
			value.CopiarA(data.estimulo, false);
			data.data.estimulanteParte = key;
			data.data.estado = estado;
			if (this.config.debugPrint)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					" su:",
					num.ToString("0.0000"),
					" min:",
					intervaloDeGeneracion.min.ToString("0.0000"),
					" max:",
					intervaloDeGeneracion.max.ToString("0.0000"),
					" lada: ",
					parteDelCuerpoHumano.ToString(),
					" ",
					estado.PrintStr()
				}));
			}
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnDataGenerada(CalculoDeEstimuloCambioDePoseResultado data)
		{
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0003AF68 File Offset: 0x00039168
		protected sealed override void PostPoblarDataConItem(CalculoDeEstimuloCambioDePoseResultado data, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> allData)
		{
			this.AlterarDataGenerada(data);
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void AlterarDataGenerada(CalculoDeEstimuloCambioDePoseResultado data)
		{
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x000066D6 File Offset: 0x000048D6
		protected sealed override bool DataGeneradaEsValida(CalculoDeEstimuloCambioDePoseResultado data, int index)
		{
			return true;
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x0003AF71 File Offset: 0x00039171
		protected sealed override float PreCalculoDeEstimulo(CalculoDeEstimuloCambioDePoseResultado data)
		{
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x0003AF84 File Offset: 0x00039184
		protected override bool MaximoAlcanzado(CalculoDeEstimuloCambioDePoseResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			ParteQuePuedeEstimular estimulanteParte = data.data.estimulanteParte;
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			maxEmoValueDeGrupo = 120f;
			if (this.maxEmocionValuePorGrupo)
			{
				maxEmoValueDeGrupo = this.maxEmocionValuePorGrupo[grupoQueCompartenValores].valor;
			}
			maxEmoValueDeGrupo *= this.maxEmocionValuePorGrupoMod;
			this.OnPreLimitarMaxEmocionValue(grupoQueCompartenValores, estimulanteParte, data.estimulo, ref maxEmoValueDeGrupo);
			maxEmoValueDeGrupo = Mathf.Clamp(maxEmoValueDeGrupo, 0f, 120f);
			return valorDeEmovionActual > maxEmoValueDeGrupo;
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x0003B028 File Offset: 0x00039228
		protected sealed override float PostCalculoDeEstimulo(CalculoDeEstimuloCambioDePoseResultado data)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			this.AplicarModificadoresDeGeneracion(data, grupoQueCompartenValores);
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0003B07D File Offset: 0x0003927D
		private void AplicarModificadoresDeGeneracion(CalculoDeEstimuloCambioDePoseResultado data, GrupoQueCompartenValores parteEstimulada)
		{
			if (this.modEstimuloGeneradoPorGrupoDeParteEstimulada)
			{
				data.data.estado.ModificarGenerado(this.modEstimuloGeneradoPorGrupoDeParteEstimulada[parteEstimulada].valor);
			}
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0003B0AD File Offset: 0x000392AD
		protected override void AplicarMaxValueEmoMods(CalculoDeEstimuloCambioDePoseResultado data, bool maximoAlcanzado, float currentEmoValue, float maxEmoValueDeGrupo, out float modificadorDEmocionChange)
		{
			if (maximoAlcanzado)
			{
				modificadorDEmocionChange = 0f;
			}
			else
			{
				modificadorDEmocionChange = Mathf.InverseLerp(maxEmoValueDeGrupo, maxEmoValueDeGrupo * 0.9f, currentEmoValue).OutPow(3f);
			}
			data.data.estado.SetPostModificador(modificadorDEmocionChange);
		}

		// Token: 0x06000CBE RID: 3262
		protected abstract void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorCambiarPose estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada);

		// Token: 0x06000CBF RID: 3263
		protected abstract void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorCambiarPose estimulo, ref float estimulacionGenerada);

		// Token: 0x06000CC0 RID: 3264
		protected abstract void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorCambiarPose estimulo, ref float maxEmotionValue);

		// Token: 0x06000CC1 RID: 3265 RVA: 0x0003B0EC File Offset: 0x000392EC
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloPorCambioDePose calculo)
		{
			CalculoDeEstimuloCambioDePoseResultado calculoDeEstimuloCambioDePoseResultado;
			bool flag = base.TryInstantiateCalculo(out calculoDeEstimuloCambioDePoseResultado);
			calculo = calculoDeEstimuloCambioDePoseResultado;
			return flag;
		}

		// Token: 0x040008EA RID: 2282
		[SerializeField]
		private List<ParteDelCuerpoHumano> ignorarSiEstaEn = new List<ParteDelCuerpoHumano>();

		// Token: 0x040008EB RID: 2283
		private static Comparison<CalculoDeEstimuloCambioDePoseResultado> comparison;
	}
}
