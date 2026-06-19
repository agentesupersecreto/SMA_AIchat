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
	// Token: 0x0200020A RID: 522
	public abstract class CalculoDeEmocionesPorMovimientoDeBones : CalculoDeEstimuloPor<CalculoDeEmocionesPorMovimientoDeBonesResultado, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone>, KeyValuePair<int, EstimuloPorManipulacionDeBone>, CalculoDeEmocionesPorMovimientoDeBonesConfiguracion, MovimientosDeBonesByMainInFrame>, ICalculadorDeEstimuloDeMovimientoDeBones, ICalculadorDeEstimulo<ICalculoDeEstimuloPorMovimientoDeBones>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeEstimulo<CalculoDeEmocionesPorMovimientoDeBonesResultado>, ICalculadorDeEstimuloIgnoradorEnPartesHumanas
	{
		// Token: 0x06000D02 RID: 3330 RVA: 0x0003B60B File Offset: 0x0003980B
		ICalculoDeEstimuloPorMovimientoDeBones ICalculadorDeEstimulo<ICalculoDeEstimuloPorMovimientoDeBones>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x0003B614 File Offset: 0x00039814
		ICalculoDeEstimuloPorMovimientoDeBones ICalculadorDeEstimulo<ICalculoDeEstimuloPorMovimientoDeBones>.GetCalculoEnFrame(int index)
		{
			return base.GetCalculoEnFrame(index);
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000D04 RID: 3332
		protected abstract PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana { get; }

		// Token: 0x06000D05 RID: 3333 RVA: 0x0003B61D File Offset: 0x0003981D
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

		// Token: 0x06000D06 RID: 3334 RVA: 0x0003B658 File Offset: 0x00039858
		protected sealed override bool ItemEsValido(KeyValuePair<int, EstimuloPorManipulacionDeBone> item, int index)
		{
			ParteQuePuedeEstimular key = (ParteQuePuedeEstimular)item.Key;
			return key != ParteQuePuedeEstimular.None && item.Value != null && !this.ignorarSiEstaEn.Contains(item.Value.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana)) && this.EstimuloEsValido(key, item.Value);
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x000066D6 File Offset: 0x000048D6
		protected virtual bool EstimuloEsValido(ParteQuePuedeEstimular estimulanteParte, EstimuloPorManipulacionDeBone estimulo)
		{
			return true;
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public sealed override DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000D09 RID: 3337
		protected abstract float maxEmocionValuePorGrupoMod { get; }

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000D0A RID: 3338
		protected abstract PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo { get; }

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000D0B RID: 3339
		protected abstract FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada { get; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000D0C RID: 3340
		protected abstract DatosDeUmbral datosDeUmbral { get; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000D0D RID: 3341
		protected abstract FloatPorGrupoDicc maxEmocionValuePorGrupo { get; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x0003B6AC File Offset: 0x000398AC
		[Obsolete("", true)]
		public ICalculoDeEstimuloPorMovimientoDeBones calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000D0F RID: 3343 RVA: 0x0003B6AC File Offset: 0x000398AC
		[Obsolete("", true)]
		CalculoDeEmocionesPorMovimientoDeBonesResultado ICalculadorDeEstimulo<CalculoDeEmocionesPorMovimientoDeBonesResultado>.calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0003B6B4 File Offset: 0x000398B4
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloPorMovimientoDeBones> resultado)
		{
			for (int i = 0; i < this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count; i++)
			{
				resultado.Add(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i]);
			}
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x0003B6E9 File Offset: 0x000398E9
		protected sealed override void SortMasFuerteAlMasDebil(List<CalculoDeEmocionesPorMovimientoDeBonesResultado> calculos)
		{
			if (CalculoDeEmocionesPorMovimientoDeBones.comparison == null)
			{
				CalculoDeEmocionesPorMovimientoDeBones.comparison = (CalculoDeEmocionesPorMovimientoDeBonesResultado a, CalculoDeEmocionesPorMovimientoDeBonesResultado b) => -1 * a.data.estado.estimulacionGeneradaEnFrame.CompareTo(b.data.estado.estimulacionGeneradaEnFrame);
			}
			calculos.Sort(CalculoDeEmocionesPorMovimientoDeBones.comparison);
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected sealed override void OnOldDataCleared()
		{
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x0003B724 File Offset: 0x00039924
		protected sealed override void PoblarDataConItem(CalculoDeEmocionesPorMovimientoDeBonesResultado data, KeyValuePair<int, EstimuloPorManipulacionDeBone> item, int index, float deltaTime, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> alldata)
		{
			data.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloPorManipulacionDeBone value = item.Value;
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
			float velocidadRelativaEmulada = value.velocidadRelativaEmulada;
			RangeValueV2 intervaloDeGeneracion = datosDeUmbral2.intervaloDeGeneracion;
			ValorModificable estimulacionQueGenera = datosDeUmbral2.estimulacionQueGenera;
			this.OnPreUmbralCalculo(key, parteDelCuerpoHumano, value, ref velocidadRelativaEmulada, ref intervaloDeGeneracion, ref estimulacionQueGenera);
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			try
			{
				estado = UmbralBasico.Calcular(velocidadRelativaEmulada, deltaTime, UmbralBasico.TipoDeCambio.unico, intervaloDeGeneracion, estimulacionQueGenera.total, datosDeUmbral2.spotBonuses, datosDeUmbral.promedioMod, datosDeUmbral.modPorEncima, datosDeUmbral.modPorDebajo);
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
					velocidadRelativaEmulada.ToString("0.0000"),
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

		// Token: 0x06000D14 RID: 3348 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnDataGenerada(CalculoDeEmocionesPorMovimientoDeBonesResultado data)
		{
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x0003B914 File Offset: 0x00039B14
		protected sealed override void PostPoblarDataConItem(CalculoDeEmocionesPorMovimientoDeBonesResultado data, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> allData)
		{
			this.AlterarDataGenerada(data);
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void AlterarDataGenerada(CalculoDeEmocionesPorMovimientoDeBonesResultado data)
		{
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x000066D6 File Offset: 0x000048D6
		protected sealed override bool DataGeneradaEsValida(CalculoDeEmocionesPorMovimientoDeBonesResultado data, int index)
		{
			return true;
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x0003B91D File Offset: 0x00039B1D
		protected sealed override float PreCalculoDeEstimulo(CalculoDeEmocionesPorMovimientoDeBonesResultado data)
		{
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x0003B930 File Offset: 0x00039B30
		protected override bool MaximoAlcanzado(CalculoDeEmocionesPorMovimientoDeBonesResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
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

		// Token: 0x06000D1A RID: 3354 RVA: 0x0003B9D4 File Offset: 0x00039BD4
		protected sealed override float PostCalculoDeEstimulo(CalculoDeEmocionesPorMovimientoDeBonesResultado data)
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

		// Token: 0x06000D1B RID: 3355 RVA: 0x0003BA29 File Offset: 0x00039C29
		private void AplicarModificadoresDeGeneracion(CalculoDeEmocionesPorMovimientoDeBonesResultado data, GrupoQueCompartenValores parteEstimulada)
		{
			if (this.modEstimuloGeneradoPorGrupoDeParteEstimulada)
			{
				data.data.estado.ModificarGenerado(this.modEstimuloGeneradoPorGrupoDeParteEstimulada[parteEstimulada].valor);
			}
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0003BA59 File Offset: 0x00039C59
		protected override void AplicarMaxValueEmoMods(CalculoDeEmocionesPorMovimientoDeBonesResultado data, bool maximoAlcanzado, float currentEmoValue, float maxEmoValueDeGrupo, out float modificadorDEmocionChange)
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

		// Token: 0x06000D1D RID: 3357
		protected abstract void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorManipulacionDeBone estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada);

		// Token: 0x06000D1E RID: 3358
		protected abstract void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float estimulacionGenerada);

		// Token: 0x06000D1F RID: 3359
		protected abstract void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float maxEmotionValue);

		// Token: 0x06000D20 RID: 3360 RVA: 0x0003BA98 File Offset: 0x00039C98
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloPorMovimientoDeBones calculo)
		{
			CalculoDeEmocionesPorMovimientoDeBonesResultado calculoDeEmocionesPorMovimientoDeBonesResultado;
			bool flag = base.TryInstantiateCalculo(out calculoDeEmocionesPorMovimientoDeBonesResultado);
			calculo = calculoDeEmocionesPorMovimientoDeBonesResultado;
			return flag;
		}

		// Token: 0x040008FF RID: 2303
		[SerializeField]
		private List<ParteDelCuerpoHumano> ignorarSiEstaEn = new List<ParteDelCuerpoHumano>();

		// Token: 0x04000900 RID: 2304
		private static Comparison<CalculoDeEmocionesPorMovimientoDeBonesResultado> comparison;
	}
}
