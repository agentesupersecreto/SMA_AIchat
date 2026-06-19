using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.TValle.BeachGirl.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000488 RID: 1160
	[TupleElementNames(new string[] { "direccion", "estimulante", "original", null, "invertido", "estimulanteInvertido" })]
	public abstract class CalculoDeEstimuloPorTactilesRecibidos<TData> : CalculoDeEstimuloPor<TData, DictionaryDeEstimulosTactiles, KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>, CalculoDeEstimuloPorCariciasConfig, TouchesByMainInFrame>, ICalculadorDeEstimuloTactil, ICalculadorDeEstimulo<ICalculoDeEstimuloTactil>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorArregladorDeInstanciasDeEstimulos<ICalculoDeEstimuloTactil>, ICalculadorDeEstimulo<CalculoDeEstimuloPorCariciasResultado>, ICalculadorSimulable, ICalculadorDeEstimuloClasificable where TData : CalculoDeEstimuloPorCariciasResultado, IClearable, new()
	{
		// Token: 0x06001A87 RID: 6791 RVA: 0x0006B31C File Offset: 0x0006951C
		ICalculoDeEstimuloTactil ICalculadorDeEstimulo<ICalculoDeEstimuloTactil>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06001A88 RID: 6792 RVA: 0x0006B32A File Offset: 0x0006952A
		ICalculoDeEstimuloTactil ICalculadorDeEstimulo<ICalculoDeEstimuloTactil>.GetCalculoEnFrame(int index)
		{
			return base.GetCalculoEnFrame(index);
		}

		// Token: 0x06001A89 RID: 6793 RVA: 0x0006B31C File Offset: 0x0006951C
		CalculoDeEstimuloPorCariciasResultado ICalculadorDeEstimulo<CalculoDeEstimuloPorCariciasResultado>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06001A8A RID: 6794 RVA: 0x0006B32A File Offset: 0x0006952A
		CalculoDeEstimuloPorCariciasResultado ICalculadorDeEstimulo<CalculoDeEstimuloPorCariciasResultado>.GetCalculoEnFrame(int index)
		{
			return base.GetCalculoEnFrame(index);
		}

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x06001A8B RID: 6795
		protected abstract PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana { get; }

		// Token: 0x06001A8C RID: 6796 RVA: 0x0006B338 File Offset: 0x00069538
		protected override void OnPoolReturningItem(SimplePoolDeClearables<TData> pool, TData itemReturning)
		{
			base.OnPoolReturningItem(pool, itemReturning);
			this.PoolReturnItem(itemReturning.estimulo);
			if (itemReturning.estimuloInvertido != null)
			{
				this.PoolReturnItem(itemReturning.estimuloInvertido);
			}
			itemReturning.SetEstimuloInstance(null, null);
		}

		// Token: 0x06001A8D RID: 6797 RVA: 0x0006B38C File Offset: 0x0006958C
		private void PoolReturnItem(EstimuloTactil estimulo)
		{
			EstimuloTactilDeSemen estimuloTactilDeSemen = estimulo as EstimuloTactilDeSemen;
			if (estimuloTactilDeSemen != null)
			{
				this.m_poolSemen.ReturnItem(estimuloTactilDeSemen);
				return;
			}
			this.m_pool.ReturnItem(estimulo);
		}

		// Token: 0x06001A8E RID: 6798 RVA: 0x0006B3BC File Offset: 0x000695BC
		protected EstimuloTactil ObtenerInstanciaDeEstimuloDesdePool(EstimuloTactil original)
		{
			if (original is EstimuloTactilDeSemen)
			{
				return this.m_poolSemen.GetItem();
			}
			return this.m_pool.GetItem();
		}

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x06001A8F RID: 6799 RVA: 0x00004252 File Offset: 0x00002452
		public sealed override DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x06001A90 RID: 6800 RVA: 0x00005F51 File Offset: 0x00004151
		public sealed override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x06001A91 RID: 6801 RVA: 0x0006B3DD File Offset: 0x000695DD
		[Obsolete("", true)]
		ICalculoDeEstimuloTactil ICalculadorDeEstimulo<ICalculoDeEstimuloTactil>.calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x06001A92 RID: 6802 RVA: 0x0006B3DD File Offset: 0x000695DD
		[Obsolete("", true)]
		CalculoDeEstimuloPorCariciasResultado ICalculadorDeEstimulo<CalculoDeEstimuloPorCariciasResultado>.calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x0006B3EC File Offset: 0x000695EC
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloTactil> resultado)
		{
			for (int i = 0; i < this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count; i++)
			{
				resultado.Add(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i]);
			}
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x0006B428 File Offset: 0x00069628
		public void GetCalculosDelMasFuerteAlMasDebil(IList<CalculoDeEstimuloPorCariciasResultado> resultado)
		{
			for (int i = 0; i < this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count; i++)
			{
				resultado.Add(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i]);
			}
		}

		// Token: 0x06001A95 RID: 6805 RVA: 0x0006B462 File Offset: 0x00069662
		protected sealed override void SortMasFuerteAlMasDebil(List<TData> calculos)
		{
			if (CalculoDeEstimuloPorTactilesRecibidos<TData>.comparison == null)
			{
				CalculoDeEstimuloPorTactilesRecibidos<TData>.comparison = (TData a, TData b) => -1 * a.data.estado.estimulacionGeneradaEnFrame.CompareTo(b.data.estado.estimulacionGeneradaEnFrame);
			}
			calculos.Sort(CalculoDeEstimuloPorTactilesRecibidos<TData>.comparison);
		}

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x06001A96 RID: 6806
		[Obsolete("no tiene sentido si tiene direccionDeEstimulo como miembro, ademas los estimulos dados vienen con las partes invertidas, osea, los calculos no serian los correctos", true)]
		protected abstract bool estimuloEsValidoSiEsEstimuloDado { get; }

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x06001A97 RID: 6807
		protected abstract float bufferParaGenerarEstimulo { get; }

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06001A98 RID: 6808
		protected abstract PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo { get; }

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06001A99 RID: 6809
		protected abstract PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo { get; }

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06001A9A RID: 6810
		protected abstract FloatPorGrupoDicc maxEmocionValuePorGrupo { get; }

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06001A9B RID: 6811
		protected abstract FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante { get; }

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06001A9C RID: 6812
		protected abstract FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada { get; }

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06001A9D RID: 6813
		protected abstract DatosDeUmbral datosDeUmbral { get; }

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06001A9E RID: 6814
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento { get; }

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06001A9F RID: 6815
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion { get; }

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06001AA0 RID: 6816
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Incremento { get; }

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06001AA1 RID: 6817
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Expancion { get; }

		// Token: 0x06001AA2 RID: 6818 RVA: 0x0006B49A File Offset: 0x0006969A
		protected virtual bool EstimuloEsValidoV2(ParteQuePuedeEstimular estimulanteParte, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> par)
		{
			return par.Item1.tipo == this.direccionDeEstimulo;
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x0006B4AF File Offset: 0x000696AF
		protected sealed override DictionaryDeEstimulosTactiles GetEstimulosEnFrame(TouchesByMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.frameTouchesConPrioridad;
		}

		// Token: 0x06001AA4 RID: 6820 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnOldDataCleared()
		{
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x0006B4BC File Offset: 0x000696BC
		protected sealed override bool ItemEsValido([TupleElementNames(new string[] { "direccion", "estimulante", "original", null, "invertido", "estimulanteInvertido" })] KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> item, int index)
		{
			return this.EstimuloEsValidoV2((ParteQuePuedeEstimular)item.Key.Item2, item.Value);
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x0006B4D8 File Offset: 0x000696D8
		protected sealed override void PoblarDataConItem(TData data, [TupleElementNames(new string[] { "direccion", "estimulante", "original", null, "invertido", "estimulanteInvertido" })] KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> item, int index, float deltaTime, DictionaryDeEstimulosTactiles allItems)
		{
			data.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			RangeValueV2 rangeValueV;
			this.PoblarConData(item, data, this.datosDeUmbral, allItems, deltaTime, out rangeValueV, null, false);
			bool flag = data.data.estado.estimulacionGeneradaEnFrame > 0f;
			float num = this.bufferParaGenerarEstimulo * 2f;
			if (num > 0f)
			{
				CalculoDeEstimuloEnFrame.ApplyBufferToEstimulado(ref flag, num, this.m_BufferedCoolDown, ref data.data.estado);
			}
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool DataGeneradaEsValida(TData data, int index)
		{
			return true;
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x0006B566 File Offset: 0x00069766
		protected sealed override float PreCalculoDeEstimulo(TData data)
		{
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06001AA9 RID: 6825 RVA: 0x0006B580 File Offset: 0x00069780
		protected override bool MaximoAlcanzado(TData data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			ParteQuePuedeEstimular estimulanteParte = data.data.estimulanteParte;
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			GrupoQueCompartenValores grupoQueCompartenValores2 = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			if (this.mapaDeParteEstimulanteGrupo)
			{
				grupoQueCompartenValores2 = this.mapaDeParteEstimulanteGrupo.GetGrupoDeParte(estimulanteParte);
			}
			maxEmoValueDeGrupo = 120f;
			if (this.maxEmocionValuePorGrupo)
			{
				maxEmoValueDeGrupo = this.maxEmocionValuePorGrupo[grupoQueCompartenValores].valor;
			}
			this.OnPreLimitarMaxEmocionValue(grupoQueCompartenValores, grupoQueCompartenValores2, estimulanteParte, data.estimulo, ref maxEmoValueDeGrupo);
			maxEmoValueDeGrupo = Mathf.Clamp(maxEmoValueDeGrupo, 0f, 120f);
			return valorDeEmovionActual > maxEmoValueDeGrupo;
		}

		// Token: 0x06001AAA RID: 6826 RVA: 0x0006B648 File Offset: 0x00069848
		protected sealed override float PostCalculoDeEstimulo(TData data)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			ParteQuePuedeEstimular estimulanteParte = data.data.estimulanteParte;
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			GrupoQueCompartenValores grupoQueCompartenValores2 = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			if (this.mapaDeParteEstimulanteGrupo)
			{
				grupoQueCompartenValores2 = this.mapaDeParteEstimulanteGrupo.GetGrupoDeParte(estimulanteParte);
			}
			this.AplicarModificadoresDeGeneracion(data, grupoQueCompartenValores, grupoQueCompartenValores2);
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06001AAB RID: 6827 RVA: 0x0006B6D8 File Offset: 0x000698D8
		private void AplicarModificadoresDeGeneracion(TData data, GrupoQueCompartenValores parteEstimulada, GrupoQueCompartenValores parteEstimulante)
		{
			if (this.modEstimuloGeneradoPorGrupoDeParteEstimulante)
			{
				float valor = this.modEstimuloGeneradoPorGrupoDeParteEstimulante[parteEstimulante].valor;
				data.data.estado.ModificarGenerado(valor);
			}
			if (this.modEstimuloGeneradoPorGrupoDeParteEstimulada)
			{
				float valor2 = this.modEstimuloGeneradoPorGrupoDeParteEstimulada[parteEstimulada].valor;
				data.data.estado.ModificarGenerado(valor2);
			}
		}

		// Token: 0x06001AAC RID: 6828 RVA: 0x0006B750 File Offset: 0x00069950
		public void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, EmocionesFemeninasValues? emocionesValoresMods, out ICalculoDeEstimuloCompleto faseTres)
		{
			float num;
			UmbralBasico.TipoDeCambio tipoDeCambio;
			this.SimularGlobal(estimulante, estimulada, deltaTime, out intervalo, out minGenerado, out maxGenerado, out num, out tipoDeCambio, emocionesValoresMods, out faseTres);
		}

		// Token: 0x06001AAD RID: 6829 RVA: 0x0006B774 File Offset: 0x00069974
		public void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, out float maxEmoValue, out UmbralBasico.TipoDeCambio tipoDeCambio, EmocionesFemeninasValues? emocionesValoresMods)
		{
			ICalculoDeEstimuloCompleto calculoDeEstimuloCompleto;
			this.SimularGlobal(estimulante, estimulada, deltaTime, out intervalo, out minGenerado, out maxGenerado, out maxEmoValue, out tipoDeCambio, emocionesValoresMods, out calculoDeEstimuloCompleto);
		}

		// Token: 0x06001AAE RID: 6830 RVA: 0x0006B798 File Offset: 0x00069998
		public void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, out float maxEmoValue, out UmbralBasico.TipoDeCambio tipoDeCambio, EmocionesFemeninasValues? emocionesValoresMods, out ICalculoDeEstimuloCompleto faseTres)
		{
			bool flag = this.suavizar;
			try
			{
				this.suavizar = false;
				TData tdata = new TData();
				tdata.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
				EstimuloTactil estimuloTactil = new EstimuloTactil();
				estimuloTactil.tipoDeEstimulo = TipoDeEstimulo.tactil;
				estimuloTactil.EstimuloSoloUsaPrioridadesFixed();
				estimuloTactil.AddParteEstimulada(estimulada);
				estimuloTactil.velocidadRelativaEmuladaMaxima = 1f;
				KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> keyValuePair = new KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>(new ValueTuple<int, int>((int)this.direccionDeEstimulo, (int)estimulante), new ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>(estimuloTactil, new ValueTuple<EstimuloTactil, int>(null, 0)));
				this.PoblarConData(keyValuePair, tdata, this.datosDeUmbral, null, deltaTime, out intervalo, emocionesValoresMods, true);
				TData tdata2 = new TData();
				tdata2.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
				EstimuloTactil estimuloTactil2 = new EstimuloTactil();
				estimuloTactil2.tipoDeEstimulo = TipoDeEstimulo.tactil;
				estimuloTactil2.EstimuloSoloUsaPrioridadesFixed();
				estimuloTactil2.AddParteEstimulada(estimulada);
				estimuloTactil2.velocidadRelativaEmuladaMaxima = intervalo.min + 1E-05f;
				KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> keyValuePair2 = new KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>(new ValueTuple<int, int>((int)this.direccionDeEstimulo, (int)estimulante), new ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>(estimuloTactil2, new ValueTuple<EstimuloTactil, int>(null, 0)));
				RangeValueV2 rangeValueV;
				this.PoblarConData(keyValuePair2, tdata2, this.datosDeUmbral, null, deltaTime, out rangeValueV, emocionesValoresMods, true);
				this.PostCalculoDeEstimulo(tdata2);
				minGenerado = tdata2.data.estado;
				TData tdata3 = new TData();
				tdata3.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
				faseTres = tdata3;
				EstimuloTactil estimuloTactil3 = new EstimuloTactil();
				estimuloTactil3.tipoDeEstimulo = TipoDeEstimulo.tactil;
				estimuloTactil3.EstimuloSoloUsaPrioridadesFixed();
				estimuloTactil3.AddParteEstimulada(estimulada);
				estimuloTactil3.velocidadRelativaEmuladaMaxima = Mathf.Lerp(intervalo.min, intervalo.max, this.datosDeUmbral.promedioMod);
				KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> keyValuePair3 = new KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>(new ValueTuple<int, int>((int)this.direccionDeEstimulo, (int)estimulante), new ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>(estimuloTactil3, new ValueTuple<EstimuloTactil, int>(null, 0)));
				RangeValueV2 rangeValueV2;
				this.PoblarConData(keyValuePair3, tdata3, this.datosDeUmbral, null, deltaTime, out rangeValueV2, emocionesValoresMods, true);
				this.PostCalculoDeEstimulo(tdata3);
				maxGenerado = tdata3.data.estado;
				this.MaximoAlcanzado(tdata3, 1f, out maxEmoValue);
				tipoDeCambio = this.ObtenerTipoDeCambio();
			}
			finally
			{
				this.suavizar = flag;
			}
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x0006B9D0 File Offset: 0x00069BD0
		private void PoblarConData([TupleElementNames(new string[] { "direccion", "estimulante", "original", null, "invertido", "estimulanteInvertido" })] KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> keyValuePar, TData resultado, DatosDeUmbral datos, DictionaryDeEstimulosTactiles allItems, float deltaTime, out RangeValueV2 intervalo, EmocionesFemeninasValues? emocionesValoresMods, bool reusarEstimuloInstance = false)
		{
			ParteQuePuedeEstimular item = (ParteQuePuedeEstimular)keyValuePar.Key.Item2;
			ParteQuePuedeEstimular item2 = (ParteQuePuedeEstimular)keyValuePar.Value.Item2.Item2;
			EstimuloTactil item3 = keyValuePar.Value.Item1;
			EstimuloTactil item4 = keyValuePar.Value.Item2.Item1;
			EstimuloTactilDeSemen estimuloTactilDeSemen = item3 as EstimuloTactilDeSemen;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			if (estimuloTactilDeSemen != null && estimuloTactilDeSemen.penetrando != null)
			{
				parteDelCuerpoHumano = estimuloTactilDeSemen.penetrando.Value;
			}
			else
			{
				parteDelCuerpoHumano = item3.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano2 = ParteDelCuerpoHumano.pecho;
			if (item3.tieneCopiaInvertida && item4 != null)
			{
				parteDelCuerpoHumano2 = item4.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			}
			if (item3 == null)
			{
				throw new ArgumentNullException("estimulo", "estimulo null reference.");
			}
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			GrupoQueCompartenValores grupoQueCompartenValores2 = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			if (this.mapaDeParteEstimulanteGrupo)
			{
				grupoQueCompartenValores2 = this.mapaDeParteEstimulanteGrupo.GetGrupoDeParte(item);
			}
			float num = item3.velocidadRelativaEmuladaMaxima;
			if (this.suavizar)
			{
				SmoothFloatsV2 smoothDeParte = base.GetSmoothDeParte(item);
				smoothDeParte.Add(item3.velocidadRelativaEmuladaMaxima);
				num = smoothDeParte.suavizado;
			}
			intervalo = datos.intervaloDeGeneracion;
			ValorModificable estimulacionQueGenera = datos.estimulacionQueGenera;
			if (this.aplicarModsDeIntercalos)
			{
				if (this.modsDeIntervaloPorGrupoEstimulado_Incremento)
				{
					intervalo.Increase(this.modsDeIntervaloPorGrupoEstimulado_Incremento[grupoQueCompartenValores].valor, 0.0001f);
				}
				if (this.modsDeIntervaloPorGrupoEstimulado_Expancion)
				{
					intervalo.Expandir(this.modsDeIntervaloPorGrupoEstimulado_Expancion[grupoQueCompartenValores].valor, 0.0001f);
				}
				if (this.modsDeIntervaloPorGrupoEstimulante_Incremento)
				{
					intervalo.Increase(this.modsDeIntervaloPorGrupoEstimulante_Incremento[grupoQueCompartenValores2].valor, 0.0001f);
				}
				if (this.modsDeIntervaloPorGrupoEstimulante_Expancion)
				{
					intervalo.Expandir(this.modsDeIntervaloPorGrupoEstimulante_Expancion[grupoQueCompartenValores2].valor, 0.0001f);
				}
			}
			this.OnPreUmbralCalculo(item, parteDelCuerpoHumano, item3, ref num, ref intervalo, ref estimulacionQueGenera, ref emocionesValoresMods);
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			try
			{
				estado = UmbralBasico.Calcular(num, deltaTime, this.ObtenerTipoDeCambio(), intervalo, estimulacionQueGenera.total, datos.spotBonuses, datos.promedioMod, datos.modPorEncima, datos.modPorDebajo);
				float estimulacionGeneradaEnFrame = estado.estimulacionGeneradaEnFrame;
				this.OnPostUmbralCalculo(item, item3, ref estimulacionGeneradaEnFrame);
				estado.SetEstimulacionGeneradaEnFrame(estimulacionGeneradaEnFrame);
				estado.SetEstimulacionGeneradaTotal(estimulacionGeneradaEnFrame);
			}
			catch (Exception)
			{
				Debug.LogWarning("Error calculando UmbralBasico de caricias de emocion " + this.m_Emo.GetType().Name);
				throw;
			}
			EstimuloTactil estimuloTactil;
			EstimuloTactil estimuloTactil2;
			if (!reusarEstimuloInstance)
			{
				estimuloTactil = this.ObtenerInstanciaDeEstimuloDesdePool(item3);
				item3.CopiarA(estimuloTactil, false);
				estimuloTactil.OverridePartePrincipalEstimulada(parteDelCuerpoHumano);
				if (item4 != null && item3.tieneCopiaInvertida)
				{
					estimuloTactil2 = this.ObtenerInstanciaDeEstimuloDesdePool(item4);
					item4.CopiarA(estimuloTactil2, false);
					estimuloTactil2.OverridePartePrincipalEstimulada(parteDelCuerpoHumano2);
				}
				else
				{
					estimuloTactil2 = null;
				}
			}
			else
			{
				estimuloTactil = item3;
				estimuloTactil2 = item4;
			}
			resultado.SetEstimuloInstance(estimuloTactil, estimuloTactil2);
			resultado.data.estimulanteParte = item;
			resultado.data.estimulanteParteInvertido = item2;
			resultado.data.estado = estado;
			if (this.config.debugPrint)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"vel:",
					item3.velocidadRelativaEmuladaMaxima.ToString("0.0000"),
					" su:",
					num.ToString("0.0000"),
					" min:",
					intervalo.min.ToString("0.0000"),
					" max:",
					intervalo.max.ToString("0.0000"),
					" lada: ",
					parteDelCuerpoHumano.ToString(),
					"  lante: ",
					item.ToString(),
					" ",
					estado.PrintStr()
				}));
			}
		}

		// Token: 0x06001AB0 RID: 6832
		protected abstract UmbralBasico.TipoDeCambio ObtenerTipoDeCambio();

		// Token: 0x06001AB1 RID: 6833 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnDataGenerada(TData data)
		{
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x0006BDFC File Offset: 0x00069FFC
		protected override void PostPoblarDataConItem(TData data, DictionaryDeEstimulosTactiles allData)
		{
			TipoDeEstimuloTactil tipoDeEstimuloTactil = data.estimulo.ObtenerTipoDeEstimuloTactil(this.contextoDePrioridadDeParteHumana, data.data.estimulanteParte, false);
			data.estimulo.SetTipoDeEstimuloTactil(tipoDeEstimuloTactil);
			if (data.estimulo.tieneCopiaInvertida && data.estimuloInvertido != null)
			{
				data.estimuloInvertido.SetTipoDeEstimuloTactil(data.estimulo.tipoDeEstimuloTactil);
			}
			this.AlterarDataGenerada(data);
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void AlterarDataGenerada(TData data)
		{
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x0006BE88 File Offset: 0x0006A088
		protected override void AplicarMaxValueEmoMods(TData data, bool maximoAlcanzado, float currentEmoValue, float maxEmoValueDeGrupo, out float modificadorDEmocionChange)
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

		// Token: 0x06001AB5 RID: 6837
		protected abstract void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloTactil estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods);

		// Token: 0x06001AB6 RID: 6838
		protected abstract void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float estimulacionGenerada);

		// Token: 0x06001AB7 RID: 6839
		protected abstract void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float maxEmotionValue);

		// Token: 0x06001AB8 RID: 6840 RVA: 0x0006BED8 File Offset: 0x0006A0D8
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloTactil calculo)
		{
			TData tdata;
			bool flag = base.TryInstantiateCalculo(out tdata);
			calculo = tdata;
			return flag;
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x0006BEF8 File Offset: 0x0006A0F8
		public bool TryInstantiateCalculo(out CalculoDeEstimuloPorCariciasResultado calculo)
		{
			TData tdata;
			bool flag = base.TryInstantiateCalculo(out tdata);
			calculo = tdata;
			return flag;
		}

		// Token: 0x06001ABA RID: 6842 RVA: 0x0006BF18 File Offset: 0x0006A118
		public void FixEstimulosInstancesTypes(ICalculoDeEstimuloTactil original, ICalculoDeEstimuloTactil instanciado)
		{
			if (original.estimulo != null && instanciado.estimulo != null && original.estimulo.GetType() != instanciado.estimulo.GetType())
			{
				this.PoolReturnItem(instanciado.estimulo);
				EstimuloTactil estimuloTactil = this.ObtenerInstanciaDeEstimuloDesdePool(original.estimulo);
				EstimuloTactil estimuloInvertido = instanciado.estimuloInvertido;
				instanciado.FixEstimuloInstanceTypes(estimuloTactil, estimuloInvertido);
			}
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001AC1 RID: 6849 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400136C RID: 4972
		private SimplePoolDeClearables<EstimuloTactil> m_pool = new SimplePoolDeClearables<EstimuloTactil>();

		// Token: 0x0400136D RID: 4973
		private SimplePoolDeClearables<EstimuloTactilDeSemen> m_poolSemen = new SimplePoolDeClearables<EstimuloTactilDeSemen>();

		// Token: 0x0400136E RID: 4974
		private static Comparison<TData> comparison;

		// Token: 0x0400136F RID: 4975
		protected bool suavizar = true;

		// Token: 0x04001370 RID: 4976
		public bool aplicarModsDeIntercalos = true;

		// Token: 0x04001371 RID: 4977
		[SerializeField]
		private BufferedCoolDown m_BufferedCoolDown = new BufferedCoolDown();
	}
}
