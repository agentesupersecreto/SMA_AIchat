using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos
{
	// Token: 0x02000421 RID: 1057
	public abstract class CalculoDeEmocionesPorDesvestidura : CalculoDeEstimuloPor<CalculoDeEstimuloDesvestidoResultado, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir>, KeyValuePair<int, EstimuloPorDesvestir>, CalculoDeEmocionesPorSerDesvestidoConfiguracion, DesvestidurasByMainInFrame>, ICalculadorDeEstimuloPorDesvestir, ICalculadorDeEstimulo<ICalculoDeEstimuloPorDesvestir>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeEstimulo<CalculoDeEstimuloDesvestidoResultado>, ICalculadorDeEstimuloIgnoradorEnPartesHumanas
	{
		// Token: 0x06001731 RID: 5937 RVA: 0x0005EF3E File Offset: 0x0005D13E
		ICalculoDeEstimuloPorDesvestir ICalculadorDeEstimulo<ICalculoDeEstimuloPorDesvestir>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x0005EF47 File Offset: 0x0005D147
		ICalculoDeEstimuloPorDesvestir ICalculadorDeEstimulo<ICalculoDeEstimuloPorDesvestir>.GetCalculoEnFrame(int index)
		{
			return base.GetCalculoEnFrame(index);
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06001733 RID: 5939
		protected abstract PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana { get; }

		// Token: 0x06001734 RID: 5940 RVA: 0x0005EF50 File Offset: 0x0005D150
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

		// Token: 0x06001735 RID: 5941 RVA: 0x0005EF8B File Offset: 0x0005D18B
		protected sealed override bool ItemEsValido(KeyValuePair<int, EstimuloPorDesvestir> item, int index)
		{
			return item.Key != 0 && item.Value != null && !this.ignorarSiEstaEn.Contains(item.Value.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana));
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06001736 RID: 5942 RVA: 0x00004252 File Offset: 0x00002452
		public sealed override DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06001737 RID: 5943
		protected abstract float maxEmocionValuePorGrupoMod { get; }

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06001738 RID: 5944
		protected abstract PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo { get; }

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06001739 RID: 5945
		protected abstract FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada { get; }

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x0600173A RID: 5946
		protected abstract DatosDeUmbral datosDeUmbral { get; }

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x0600173B RID: 5947
		protected abstract FloatPorGrupoDicc maxEmocionValuePorGrupo { get; }

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x0600173C RID: 5948 RVA: 0x0005EFC5 File Offset: 0x0005D1C5
		[Obsolete("", true)]
		public ICalculoDeEstimuloPorDesvestir calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x0600173D RID: 5949 RVA: 0x0005EFC5 File Offset: 0x0005D1C5
		[Obsolete("", true)]
		CalculoDeEstimuloDesvestidoResultado ICalculadorDeEstimulo<CalculoDeEstimuloDesvestidoResultado>.calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x0600173E RID: 5950 RVA: 0x0005EFD0 File Offset: 0x0005D1D0
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloPorDesvestir> resultado)
		{
			for (int i = 0; i < this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count; i++)
			{
				resultado.Add(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i]);
			}
		}

		// Token: 0x0600173F RID: 5951 RVA: 0x0005F005 File Offset: 0x0005D205
		protected sealed override void SortMasFuerteAlMasDebil(List<CalculoDeEstimuloDesvestidoResultado> calculos)
		{
			if (CalculoDeEmocionesPorDesvestidura.comparison == null)
			{
				CalculoDeEmocionesPorDesvestidura.comparison = (CalculoDeEstimuloDesvestidoResultado a, CalculoDeEstimuloDesvestidoResultado b) => -1 * a.data.estado.estimulacionGeneradaEnFrame.CompareTo(b.data.estado.estimulacionGeneradaEnFrame);
			}
			calculos.Sort(CalculoDeEmocionesPorDesvestidura.comparison);
		}

		// Token: 0x06001740 RID: 5952 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnOldDataCleared()
		{
		}

		// Token: 0x06001741 RID: 5953 RVA: 0x0005F040 File Offset: 0x0005D240
		protected sealed override void PoblarDataConItem(CalculoDeEstimuloDesvestidoResultado data, KeyValuePair<int, EstimuloPorDesvestir> item, int index, float deltaTime, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> allitems)
		{
			data.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloPorDesvestir value = item.Value;
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
			float num = 1f;
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

		// Token: 0x06001742 RID: 5954 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnDataGenerada(CalculoDeEstimuloDesvestidoResultado data)
		{
		}

		// Token: 0x06001743 RID: 5955 RVA: 0x0005F230 File Offset: 0x0005D430
		protected override void PostPoblarDataConItem(CalculoDeEstimuloDesvestidoResultado data, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> allData)
		{
			this.AlterarDataGenerada(data);
		}

		// Token: 0x06001744 RID: 5956 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void AlterarDataGenerada(CalculoDeEstimuloDesvestidoResultado data)
		{
		}

		// Token: 0x06001745 RID: 5957 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool DataGeneradaEsValida(CalculoDeEstimuloDesvestidoResultado data, int index)
		{
			return true;
		}

		// Token: 0x06001746 RID: 5958 RVA: 0x0005F239 File Offset: 0x0005D439
		protected sealed override float PreCalculoDeEstimulo(CalculoDeEstimuloDesvestidoResultado data)
		{
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06001747 RID: 5959 RVA: 0x0005F24C File Offset: 0x0005D44C
		protected override bool MaximoAlcanzado(CalculoDeEstimuloDesvestidoResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
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

		// Token: 0x06001748 RID: 5960 RVA: 0x0005F2F0 File Offset: 0x0005D4F0
		protected sealed override float PostCalculoDeEstimulo(CalculoDeEstimuloDesvestidoResultado data)
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

		// Token: 0x06001749 RID: 5961 RVA: 0x0005F348 File Offset: 0x0005D548
		private void AplicarModificadoresDeGeneracion(CalculoDeEstimuloDesvestidoResultado data, GrupoQueCompartenValores parteEstimulada)
		{
			if (this.modEstimuloGeneradoPorGrupoDeParteEstimulada)
			{
				float valor = this.modEstimuloGeneradoPorGrupoDeParteEstimulada[parteEstimulada].valor;
				data.data.estado.ModificarGenerado(valor);
			}
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0005F385 File Offset: 0x0005D585
		protected override void AplicarMaxValueEmoMods(CalculoDeEstimuloDesvestidoResultado data, bool maximoAlcanzado, float currentEmoValue, float maxEmoValueDeGrupo, out float modificadorDEmocionChange)
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

		// Token: 0x0600174B RID: 5963
		protected abstract void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorDesvestir estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada);

		// Token: 0x0600174C RID: 5964
		protected abstract void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorDesvestir estimulo, ref float estimulacionGenerada);

		// Token: 0x0600174D RID: 5965
		protected abstract void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorDesvestir estimulo, ref float maxEmotionValue);

		// Token: 0x0600174E RID: 5966 RVA: 0x0005F3C4 File Offset: 0x0005D5C4
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloPorDesvestir calculo)
		{
			CalculoDeEstimuloDesvestidoResultado calculoDeEstimuloDesvestidoResultado;
			bool flag = base.TryInstantiateCalculo(out calculoDeEstimuloDesvestidoResultado);
			calculo = calculoDeEstimuloDesvestidoResultado;
			return flag;
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04001205 RID: 4613
		[SerializeField]
		private List<ParteDelCuerpoHumano> ignorarSiEstaEn = new List<ParteDelCuerpoHumano>();

		// Token: 0x04001206 RID: 4614
		private static Comparison<CalculoDeEstimuloDesvestidoResultado> comparison;
	}
}
