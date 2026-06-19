using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200047D RID: 1149
	public abstract class CalculoDeEstimuloPorPenetracionRecibidaBase<TData, TResult> : CalculoDeEstimuloEnFrame<CalculoDeEstimuloPorPenetracionConfig, PenetracionesByMainInFrame>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeEstimulo<CalculoDeEstimuloPorPenetracionHoleResultado>, ICalculadorDeEstimuloClasificable, ICalculadorSimulable, ICalculadorDeEstimuloOnCalculoCallbacksCoitales<CalculoDeEstimuloPorPenetracionHoleResultado>, ICalculadorDeEstimuloOnCalculoCallbacksCoitalProfundidad<CalculoDeEstimuloPorPenetracionHoleResultado>, ICalculadorDeEstimuloOnCalculoCallbacksCoitalPenetracion<CalculoDeEstimuloPorPenetracionHoleResultado>, ICalculadorDeEstimuloOnCalculoCallbacksCoitalAnchura<CalculoDeEstimuloPorPenetracionHoleResultado> where TData : CalculoDeEstimuloPorPenetracionHoleResultado, IClearable, new() where TResult : CalculoDeEstimuloPorPenetracionResultado<TData>, IClearable, new()
	{
		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x0600198B RID: 6539 RVA: 0x00067940 File Offset: 0x00065B40
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				return this.m_masFuerteAMasDebil.Count;
			}
		}

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x0600198C RID: 6540 RVA: 0x0006794D File Offset: 0x00065B4D
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				return this.m_dataGenerada.Count;
			}
		}

		// Token: 0x0600198D RID: 6541 RVA: 0x0006795A File Offset: 0x00065B5A
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			return this.m_masFuerteAMasDebil[index];
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x0006796D File Offset: 0x00065B6D
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.m_dataGenerada[index];
		}

		// Token: 0x0600198F RID: 6543 RVA: 0x0006795A File Offset: 0x00065B5A
		public ICalculoDeEstimuloCoitalHole GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return this.m_masFuerteAMasDebil[index];
		}

		// Token: 0x06001990 RID: 6544 RVA: 0x0006796D File Offset: 0x00065B6D
		public ICalculoDeEstimuloCoitalHole GetCalculoEnFrame(int index)
		{
			return this.m_dataGenerada[index];
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x0006795A File Offset: 0x00065B5A
		CalculoDeEstimuloPorPenetracionHoleResultado ICalculadorDeEstimulo<CalculoDeEstimuloPorPenetracionHoleResultado>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return this.m_masFuerteAMasDebil[index];
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x0006796D File Offset: 0x00065B6D
		CalculoDeEstimuloPorPenetracionHoleResultado ICalculadorDeEstimulo<CalculoDeEstimuloPorPenetracionHoleResultado>.GetCalculoEnFrame(int index)
		{
			return this.m_dataGenerada[index];
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x00067980 File Offset: 0x00065B80
		public bool TryInstantiateCalculo(out CalculoDeEstimuloPorPenetracionHoleResultado calculo)
		{
			calculo = new CalculoDeEstimuloPorPenetracionHoleResultado();
			return true;
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x0006798C File Offset: 0x00065B8C
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			ICalculoDeEstimuloCoitalHole calculoDeEstimuloCoitalHole;
			bool flag = this.TryInstantiateCalculo(out calculoDeEstimuloCoitalHole);
			calculo = calculoDeEstimuloCoitalHole;
			return flag;
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x00067980 File Offset: 0x00065B80
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloCoitalHole calculo)
		{
			calculo = new CalculoDeEstimuloPorPenetracionHoleResultado();
			return true;
		}

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06001996 RID: 6550
		protected abstract PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana { get; }

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06001997 RID: 6551 RVA: 0x00005F51 File Offset: 0x00004151
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x14000065 RID: 101
		// (add) Token: 0x06001998 RID: 6552 RVA: 0x000679A4 File Offset: 0x00065BA4
		// (remove) Token: 0x06001999 RID: 6553 RVA: 0x000679DC File Offset: 0x00065BDC
		public event CalculadorOnCalculadoCallbacksHandler<CalculoDeEstimuloPorPenetracionHoleResultado> calculadoDeEstimulo;

		// Token: 0x14000066 RID: 102
		// (add) Token: 0x0600199A RID: 6554 RVA: 0x00067A14 File Offset: 0x00065C14
		// (remove) Token: 0x0600199B RID: 6555 RVA: 0x00067A4C File Offset: 0x00065C4C
		public event CalculadorOnCalculadoCallbacksHandler<CalculoDeEstimuloPorPenetracionHoleResultado> calculadoDeEstimuloPorProfundidad;

		// Token: 0x14000067 RID: 103
		// (add) Token: 0x0600199C RID: 6556 RVA: 0x00067A84 File Offset: 0x00065C84
		// (remove) Token: 0x0600199D RID: 6557 RVA: 0x00067ABC File Offset: 0x00065CBC
		public event CalculadorOnCalculadoTotalCallbacksHandler calculadoTotalDeFramePorProfundidad;

		// Token: 0x14000068 RID: 104
		// (add) Token: 0x0600199E RID: 6558 RVA: 0x00067AF4 File Offset: 0x00065CF4
		// (remove) Token: 0x0600199F RID: 6559 RVA: 0x00067B2C File Offset: 0x00065D2C
		public event CalculadorOnCalculadoCallbacksHandler<CalculoDeEstimuloPorPenetracionHoleResultado> calculadoDeEstimuloPorPenetracion;

		// Token: 0x14000069 RID: 105
		// (add) Token: 0x060019A0 RID: 6560 RVA: 0x00067B64 File Offset: 0x00065D64
		// (remove) Token: 0x060019A1 RID: 6561 RVA: 0x00067B9C File Offset: 0x00065D9C
		public event CalculadorOnCalculadoTotalCallbacksHandler calculadoTotalDeFramePorPenetracion;

		// Token: 0x1400006A RID: 106
		// (add) Token: 0x060019A2 RID: 6562 RVA: 0x00067BD4 File Offset: 0x00065DD4
		// (remove) Token: 0x060019A3 RID: 6563 RVA: 0x00067C0C File Offset: 0x00065E0C
		public event CalculadorOnCalculadoCallbacksHandler<CalculoDeEstimuloPorPenetracionHoleResultado> calculadoDeEstimuloPorAnchura;

		// Token: 0x1400006B RID: 107
		// (add) Token: 0x060019A4 RID: 6564 RVA: 0x00067C44 File Offset: 0x00065E44
		// (remove) Token: 0x060019A5 RID: 6565 RVA: 0x00067C7C File Offset: 0x00065E7C
		public event CalculadorOnCalculadoTotalCallbacksHandler calculadoTotalDeFramePorAnchura;

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x060019A6 RID: 6566 RVA: 0x00004252 File Offset: 0x00002452
		public DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x060019A7 RID: 6567 RVA: 0x0003AB0E File Offset: 0x00038D0E
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.coital;
			}
		}

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x060019A8 RID: 6568 RVA: 0x00067CB1 File Offset: 0x00065EB1
		[Obsolete("ahora todos los resultado y estados de resultados deben ser registrados", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				return this.m_Resultado.existeEstimulo;
			}
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x060019A9 RID: 6569 RVA: 0x00067CC3 File Offset: 0x00065EC3
		[Obsolete("", true)]
		public CalculoDeEstimuloPorPenetracionHoleResultado calculoMasFuerte
		{
			get
			{
				this.UpdateMasFuerte();
				return this.m_masFuerte.valor;
			}
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x060019AA RID: 6570 RVA: 0x00067CD6 File Offset: 0x00065ED6
		[Obsolete("", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				return this.calculoMasFuerte;
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x060019AB RID: 6571 RVA: 0x00067CC3 File Offset: 0x00065EC3
		[Obsolete("", true)]
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.calculoMasFuerte
		{
			get
			{
				this.UpdateMasFuerte();
				return this.m_masFuerte.valor;
			}
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x060019AC RID: 6572 RVA: 0x00067CC3 File Offset: 0x00065EC3
		[Obsolete("", true)]
		CalculoDeEstimuloPorPenetracionHoleResultado ICalculadorDeEstimulo<CalculoDeEstimuloPorPenetracionHoleResultado>.calculoMasFuerte
		{
			get
			{
				this.UpdateMasFuerte();
				return this.m_masFuerte.valor;
			}
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x00067CDE File Offset: 0x00065EDE
		[Obsolete("", true)]
		ICalculoDeEstimuloCoital ICalculadorDeEstimuloCoital.GetCalculos()
		{
			return this.m_Resultado;
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x060019AE RID: 6574
		protected abstract DatosDeUmbral datosDeUmbralPenetracion { get; }

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x060019AF RID: 6575
		protected abstract FloatPorGrupoDicc maxEmocionValuePorGrupo { get; }

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x060019B0 RID: 6576
		protected abstract PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo { get; }

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x060019B1 RID: 6577
		protected abstract PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo { get; }

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x060019B2 RID: 6578
		protected abstract FloatPorGrupoDicc parteEstimulante_EmocionGeneradaModPorGrupo { get; }

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x060019B3 RID: 6579
		protected abstract FloatPorGrupoDicc parteEstimulada_EmocionGeneradaModPorGrupo { get; }

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x060019B4 RID: 6580
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Velocidad { get; }

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x060019B5 RID: 6581
		protected abstract FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Velocidad { get; }

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x060019B6 RID: 6582 RVA: 0x00006060 File Offset: 0x00004260
		[Obsolete("realisticamente, con lo q seeste penetrando no deberia modificar los intervalos", true)]
		protected FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Incremento
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x060019B7 RID: 6583 RVA: 0x00006060 File Offset: 0x00004260
		[Obsolete("realisticamente, con lo q seeste penetrando no deberia modificar los intervalos", true)]
		protected FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Expancion
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x00067CEC File Offset: 0x00065EEC
		[Obsolete("", true)]
		private void UpdateMasFuerte()
		{
			if (!this.m_masFuerte.id.IsCurrent())
			{
				ICalculoDeEstimuloCoitalHole calculoDeEstimuloCoitalHole;
				this.GetMasFuerte(out calculoDeEstimuloCoitalHole, this.m_calculosTEMP);
				this.m_masFuerte.valor = (CalculoDeEstimuloPorPenetracionHoleResultado)calculoDeEstimuloCoitalHole;
				for (int i = 0; i < this.m_calculosTEMP.Count; i++)
				{
					this.m_masFuerteAMasDebil.Add((TData)((object)this.m_calculosTEMP[i]));
				}
				this.m_masFuerte.id = ForcedUpdateId.current;
			}
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x00067D6C File Offset: 0x00065F6C
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<CalculoDeEstimuloPorPenetracionHoleResultado> resultado)
		{
			for (int i = 0; i < this.m_masFuerteAMasDebil.Count; i++)
			{
				resultado.Add(this.m_masFuerteAMasDebil[i]);
			}
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x00067DA8 File Offset: 0x00065FA8
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloCoitalHole> resultado)
		{
			for (int i = 0; i < this.m_masFuerteAMasDebil.Count; i++)
			{
				resultado.Add(this.m_masFuerteAMasDebil[i]);
			}
		}

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x060019BB RID: 6587 RVA: 0x00067DE2 File Offset: 0x00065FE2
		public TResult resultado
		{
			get
			{
				return this.m_Resultado;
			}
		}

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x060019BC RID: 6588 RVA: 0x00067DEA File Offset: 0x00065FEA
		public List<TData> dataGenerada
		{
			get
			{
				return this.m_dataGenerada;
			}
		}

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x060019BD RID: 6589 RVA: 0x00067DF2 File Offset: 0x00065FF2
		public List<TData> masFuerteAMasDebil
		{
			get
			{
				return this.m_masFuerteAMasDebil;
			}
		}

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x060019BE RID: 6590
		protected abstract float bufferParaGenerarEstimuloPorPenetracion { get; }

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x060019BF RID: 6591 RVA: 0x00004252 File Offset: 0x00002452
		public bool esGolpe
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x00067DFA File Offset: 0x00065FFA
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.ClearOldData();
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x00067E09 File Offset: 0x00066009
		protected sealed override void Updating(float deltaTime)
		{
			this.ClearOldData();
		}

		// Token: 0x060019C2 RID: 6594 RVA: 0x00067E14 File Offset: 0x00066014
		protected sealed override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			if (!this.m_EstimuloByMainInFrame.estimulosInFrame)
			{
				return;
			}
			if (!this.generar)
			{
				return;
			}
			try
			{
				this.m_EstimuloByMainInFrame.ObtenerPenetraciones(this.m_PeneTemp);
				this.GenerarData(this.m_PeneTemp, deltaTime);
				float num;
				float num2;
				float num3;
				float num4;
				float num5;
				float num6;
				this.Calcular(out generadoNoLimitado, out generadoLimitado, out num, out num2, out num3, out num4, out num5, out num6);
				CalculadorOnCalculadoTotalCallbacksHandler calculadorOnCalculadoTotalCallbacksHandler = this.calculadoTotalDeFramePorPenetracion;
				if (calculadorOnCalculadoTotalCallbacksHandler != null)
				{
					calculadorOnCalculadoTotalCallbacksHandler(num, num2, this);
				}
				CalculadorOnCalculadoTotalCallbacksHandler calculadorOnCalculadoTotalCallbacksHandler2 = this.calculadoTotalDeFramePorProfundidad;
				if (calculadorOnCalculadoTotalCallbacksHandler2 != null)
				{
					calculadorOnCalculadoTotalCallbacksHandler2(num3, num4, this);
				}
				CalculadorOnCalculadoTotalCallbacksHandler calculadorOnCalculadoTotalCallbacksHandler3 = this.calculadoTotalDeFramePorAnchura;
				if (calculadorOnCalculadoTotalCallbacksHandler3 != null)
				{
					calculadorOnCalculadoTotalCallbacksHandler3(num5, num6, this);
				}
			}
			finally
			{
				this.m_PeneTemp.Clear();
			}
		}

		// Token: 0x060019C3 RID: 6595
		protected abstract bool ItemEsValido(PenetracionesByMainInFrame.Penetracion item, int index);

		// Token: 0x060019C4 RID: 6596 RVA: 0x00067EC8 File Offset: 0x000660C8
		private void ClearOldData()
		{
			this.m_Resultado.Clear();
			this.m_Resultado.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			if (this.m_dataGenerada.Count > 0)
			{
				this.m_masFuerteAMasDebil.Clear();
			}
			for (int i = 0; i < this.m_dataGenerada.Count; i++)
			{
				this.m_pool.ReturnItem(this.m_dataGenerada[i]);
			}
			for (int j = 0; j < this.m_dataNoGenerada.Count; j++)
			{
				this.m_pool.ReturnItem(this.m_dataNoGenerada[j]);
			}
			if (this.m_dataGenerada.Count > 0)
			{
				this.m_dataGenerada.Clear();
			}
			if (this.m_dataNoGenerada.Count > 0)
			{
				this.m_dataNoGenerada.Clear();
			}
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x00067FA4 File Offset: 0x000661A4
		private void GenerarData(IList<PenetracionesByMainInFrame.Penetracion> penetraciones, float deltaTime)
		{
			for (int i = 0; i < penetraciones.Count; i++)
			{
				PenetracionesByMainInFrame.Penetracion penetracion = penetraciones[i];
				if (this.ItemEsValido(penetracion, i))
				{
					TData item = this.m_pool.GetItem();
					item.Poblar(this.m_Emo, this);
					item.data.tipo = TipoDeCalculoDeEstimulo.frame;
					bool flag = this.PoblarConData(penetracion, item, deltaTime);
					this.PostPoblarDataConItem(item, penetraciones);
					float num = 0f;
					if (item.data.penetracion.rango != UmbralBasico.RangoEstado.sinEstimulo)
					{
						num = item.data.penetracion.estimulacionGeneradaEnFrame;
						CalculadorOnCalculadoCallbacksHandler<CalculoDeEstimuloPorPenetracionHoleResultado> calculadorOnCalculadoCallbacksHandler = this.calculadoDeEstimuloPorPenetracion;
						if (calculadorOnCalculadoCallbacksHandler != null)
						{
							calculadorOnCalculadoCallbacksHandler(item, num, this);
						}
					}
					float num2 = 0f;
					if (item.data.profundidad.rango != UmbralBasico.RangoEstado.sinEstimulo)
					{
						num2 = item.data.profundidad.estimulacionGeneradaEnFrame;
						CalculadorOnCalculadoCallbacksHandler<CalculoDeEstimuloPorPenetracionHoleResultado> calculadorOnCalculadoCallbacksHandler2 = this.calculadoDeEstimuloPorProfundidad;
						if (calculadorOnCalculadoCallbacksHandler2 != null)
						{
							calculadorOnCalculadoCallbacksHandler2(item, num2, this);
						}
					}
					float num3 = 0f;
					if (item.data.anchura.rango != UmbralBasico.RangoEstado.sinEstimulo)
					{
						num3 = item.data.anchura.estimulacionGeneradaEnFrame;
						CalculadorOnCalculadoCallbacksHandler<CalculoDeEstimuloPorPenetracionHoleResultado> calculadorOnCalculadoCallbacksHandler3 = this.calculadoDeEstimuloPorAnchura;
						if (calculadorOnCalculadoCallbacksHandler3 != null)
						{
							calculadorOnCalculadoCallbacksHandler3(item, num3, this);
						}
					}
					float num4 = 0f;
					if (item.data.anchura.rango != UmbralBasico.RangoEstado.sinEstimulo || item.data.apertura.rango != UmbralBasico.RangoEstado.sinEstimulo || item.data.movimiento.rango != UmbralBasico.RangoEstado.sinEstimulo || item.data.penetracion.rango != UmbralBasico.RangoEstado.sinEstimulo || item.data.profundidad.rango != UmbralBasico.RangoEstado.sinEstimulo)
					{
						num4 += num3;
						num4 += item.data.apertura.estimulacionGeneradaEnFrame;
						num4 += item.data.movimiento.estimulacionGeneradaEnFrame;
						num4 += num;
						num4 += num2;
						CalculadorOnCalculadoCallbacksHandler<CalculoDeEstimuloPorPenetracionHoleResultado> calculadorOnCalculadoCallbacksHandler4 = this.calculadoDeEstimulo;
						if (calculadorOnCalculadoCallbacksHandler4 != null)
						{
							calculadorOnCalculadoCallbacksHandler4(item, num4, this);
						}
					}
					if (!flag)
					{
						this.m_dataNoGenerada.Add(item);
					}
					else
					{
						this.m_dataGenerada.Add(item);
						this.m_Resultado.PoblarAdd(item, this.contextoDePrioridadDeParteHumana);
						if (num4 > 0f)
						{
							this.m_masFuerteAMasDebil.Add(item);
						}
					}
				}
			}
			this.m_masFuerteAMasDebil.Sort(CalculoDeEstimuloPorPenetracionRecibidaBase<TData, TResult>.comparison);
		}

		// Token: 0x060019C6 RID: 6598 RVA: 0x0006823C File Offset: 0x0006643C
		private bool PoblarConData(PenetracionesByMainInFrame.Penetracion penetracion, TData resultado, float deltaTime)
		{
			ParteQuePuedeEstimular estimulanteParte = penetracion.estimulanteParte;
			ParteDelCuerpoHumano parteDelCuerpoHumano = penetracion.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			if (penetracion.estimulo == null)
			{
				throw new ArgumentNullException("estimulo", "estimulo null reference.");
			}
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
			resultado.data.estimulanteParte = estimulanteParte;
			penetracion.estimulo.CopiarA(resultado.estimulo, false);
			if (penetracion.estimulo.tieneCopiaInvertida && penetracion.estimuloInverted != null && resultado.estimuloInvertido != null)
			{
				resultado.data.estimulanteParteInvertido = penetracion.estimulanteParteInvertida;
				penetracion.estimuloInverted.CopiarA(resultado.estimuloInvertido, false);
			}
			return this.PoblarConData(grupoQueCompartenValores, grupoQueCompartenValores2, deltaTime, penetracion, resultado);
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x00068334 File Offset: 0x00066534
		private void PostPoblarDataConItem(TData data, IList<PenetracionesByMainInFrame.Penetracion> allData)
		{
			TipoDeEstimuloCoital tipoDeEstimuloCoital = data.data.estimulanteParte.ObtenerTipoDeEstimuloCoital();
			data.estimulo.tipoDeEstimuloCoital = tipoDeEstimuloCoital;
			if (data.estimulo.tieneCopiaInvertida && data.estimuloInvertido != null)
			{
				data.estimuloInvertido.tipoDeEstimuloCoital = tipoDeEstimuloCoital;
			}
			IPenetrableProp penetrableProp = data.estimulo.penetradoPor as IPenetrableProp;
			if (penetrableProp != null)
			{
				data.estimulo.tipoDeProp = penetrableProp.tipoDeProp;
			}
			this.AlterarDataGenerada(data);
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void AlterarDataGenerada(TData data)
		{
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x000683D0 File Offset: 0x000665D0
		private void Calcular(out float generadoNoLimitado, out float generadoLimitado, out float porPenetracionNoLimitado, out float porPenetracionLimitado, out float porProfundidadNoLimitado, out float porProfundidadLimitado, out float porAnchuraNoLimitado, out float porAnchuraLimitado)
		{
			porPenetracionNoLimitado = (porPenetracionLimitado = 0f);
			porProfundidadNoLimitado = (porProfundidadLimitado = 0f);
			porAnchuraNoLimitado = (porAnchuraLimitado = 0f);
			generadoNoLimitado = (generadoLimitado = 0f);
			float total = this.m_Emo.value.total;
			for (int i = 0; i < this.m_dataGenerada.Count; i++)
			{
				TData tdata = this.m_dataGenerada[i];
				ParteDelCuerpoHumano parteDelCuerpoHumano = tdata.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
				ParteQuePuedeEstimular estimulanteParte = tdata.data.estimulanteParte;
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
				float num = this.CalcularSubResultado(grupoQueCompartenValores, grupoQueCompartenValores2, tdata);
				float estimulacionGeneradaEnFrame = tdata.data.penetracion.estimulacionGeneradaEnFrame;
				float estimulacionGeneradaEnFrame2 = tdata.data.profundidad.estimulacionGeneradaEnFrame;
				float estimulacionGeneradaEnFrame3 = tdata.data.anchura.estimulacionGeneradaEnFrame;
				porPenetracionNoLimitado += estimulacionGeneradaEnFrame;
				porProfundidadNoLimitado += estimulacionGeneradaEnFrame2;
				porAnchuraNoLimitado += estimulacionGeneradaEnFrame3;
				generadoNoLimitado += num;
				float num2;
				if (this.MaximoAlcanzado(tdata, grupoQueCompartenValores, grupoQueCompartenValores2, tdata.estimulo, total, out num2))
				{
					tdata.data.penetracion.SetPostModificador(0f);
					tdata.data.apertura.SetPostModificador(0f);
					tdata.data.movimiento.SetPostModificador(0f);
					tdata.data.profundidad.SetPostModificador(0f);
					tdata.data.anchura.SetPostModificador(0f);
				}
				else
				{
					float num3 = Mathf.InverseLerp(num2, num2 * 0.9f, total);
					tdata.data.penetracion.SetPostModificador(num3);
					tdata.data.apertura.SetPostModificador(num3);
					tdata.data.movimiento.SetPostModificador(num3);
					tdata.data.profundidad.SetPostModificador(num3);
					tdata.data.anchura.SetPostModificador(num3);
					generadoLimitado += num;
					porPenetracionLimitado += estimulacionGeneradaEnFrame;
					porProfundidadLimitado += estimulacionGeneradaEnFrame2;
					porAnchuraLimitado += estimulacionGeneradaEnFrame3;
				}
			}
		}

		// Token: 0x060019CA RID: 6602 RVA: 0x00068688 File Offset: 0x00066888
		protected virtual bool MaximoAlcanzado(TData data, GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, EstimuloPenetrante estimulo, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			return this.MaximoAlcanzado(grupoDeParte, grupoDeParteEstimulante, estimulo, valorDeEmovionActual, out maxEmoValueDeGrupo);
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x00068698 File Offset: 0x00066898
		protected bool MaximoAlcanzado(GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, EstimuloPenetrante estimulo, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			maxEmoValueDeGrupo = 120f;
			if (this.maxEmocionValuePorGrupo)
			{
				maxEmoValueDeGrupo = this.maxEmocionValuePorGrupo[grupoDeParte].valor;
			}
			this.OnPreLimitarMaxEmocionValue(grupoDeParte, grupoDeParteEstimulante, estimulo, ref maxEmoValueDeGrupo);
			maxEmoValueDeGrupo = Mathf.Clamp(maxEmoValueDeGrupo, 0f, 120f);
			return valorDeEmovionActual > maxEmoValueDeGrupo;
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x000686F5 File Offset: 0x000668F5
		protected virtual float CalcularSubResultado(GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, TData d)
		{
			return 0f + this.CalcularDeEstado(grupoDeParte, grupoDeParteEstimulante, ref d.data.penetracion);
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x00068715 File Offset: 0x00066915
		protected float CalcularDeEstado(GrupoQueCompartenValores estimuladoGrupo, GrupoQueCompartenValores estimulanteGrupo, ref UmbralBasico.Estado estado)
		{
			if (estado.estimulacionGeneradaEnFrame <= 0f)
			{
				return 0f;
			}
			this.AplicarModificadoresDeGeneracion(ref estado, estimuladoGrupo, estimulanteGrupo);
			return estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x060019CE RID: 6606 RVA: 0x0006873C File Offset: 0x0006693C
		protected void AplicarModificadoresDeGeneracion(ref UmbralBasico.Estado estado, GrupoQueCompartenValores parteEstimulada, GrupoQueCompartenValores parteEstimulante)
		{
			if (this.parteEstimulante_EmocionGeneradaModPorGrupo)
			{
				estado.ModificarGenerado(this.parteEstimulante_EmocionGeneradaModPorGrupo[parteEstimulante].valor);
			}
			if (this.parteEstimulada_EmocionGeneradaModPorGrupo)
			{
				estado.ModificarGenerado(this.parteEstimulada_EmocionGeneradaModPorGrupo[parteEstimulada].valor);
			}
		}

		// Token: 0x060019CF RID: 6607 RVA: 0x00068794 File Offset: 0x00066994
		protected virtual bool PoblarConData(GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, float deltaTime, PenetracionesByMainInFrame.Penetracion penetracion, TData resultado)
		{
			if (this.generarPorPenetracion)
			{
				EmocionesFemeninasValues emocionesFemeninasValues = default(EmocionesFemeninasValues);
				RangeValueV2 rangeValueV;
				bool flag = this.PoblarPenetracionData(grupoDeParte, deltaTime, penetracion, ref resultado.data.penetracion, out rangeValueV, this.datosDeUmbralPenetracion, ref emocionesFemeninasValues, true);
				float num = this.bufferParaGenerarEstimuloPorPenetracion * 2f;
				if (num > 0f)
				{
					CalculoDeEstimuloEnFrame.ApplyBufferToEstimulado(ref flag, num, this.m_BufferedCoolDownDePenetracion, ref resultado.data.profundidad);
				}
				return flag;
			}
			return false;
		}

		// Token: 0x060019D0 RID: 6608 RVA: 0x00068810 File Offset: 0x00066A10
		public RangeValueV2 ObtenerRangoDeMotion(FemalePenetracionTipo tipo, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			RangeValueV2 rangeValueV;
			this.SimularPenetracion(tipo, 1f, out rangeValueV, ref emocionesValoresMods);
			return rangeValueV;
		}

		// Token: 0x060019D1 RID: 6609 RVA: 0x00068830 File Offset: 0x00066A30
		public void SimularPenetracion(FemalePenetracionTipo tipo, float timeSpanSeconds, out RangeValueV2 intervalo, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			bool debugPrint = this.config.debugPrint;
			if (!this.config.debugPrintSimulated)
			{
				this.config.debugPrint = false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
				break;
			case FemalePenetracionTipo.vag:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
				break;
			case FemalePenetracionTipo.facial:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.bocaInterno;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			PenetracionesByMainInFrame.Penetracion penetracion = new PenetracionesByMainInFrame.Penetracion(true);
			penetracion.tipo = tipo;
			EstimuloPenetrante estimuloPenetrante = new EstimuloPenetrante();
			estimuloPenetrante.EstimuloSoloUsaPrioridadesFixed();
			estimuloPenetrante.tipoDeEstimulo = TipoDeEstimulo.coital;
			penetracion.SetEstimuloInstance(estimuloPenetrante, null, ParteQuePuedeEstimular.None, ParteQuePuedeEstimular.None);
			estimuloPenetrante.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante.velocidadDeCambios = new PenetrationInfoLocal
			{
				profundidadHoleLocal = 1f,
				profundidadPeneLocal = 1f
			};
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			this.PoblarPenetracionData(grupoQueCompartenValores, timeSpanSeconds, penetracion, ref estado, out intervalo, this.datosDeUmbralPenetracion, ref emocionesValoresMods, false);
			this.config.debugPrint = debugPrint;
		}

		// Token: 0x060019D2 RID: 6610 RVA: 0x00068940 File Offset: 0x00066B40
		public void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, EmocionesFemeninasValues? emocionesValoresMods, out ICalculoDeEstimuloCompleto faseTres)
		{
			FemalePenetracionTipo femalePenetracionTipo;
			if (estimulada != ParteDelCuerpoHumano.bocaInterno)
			{
				if (estimulada != ParteDelCuerpoHumano.ano)
				{
					if (estimulada != ParteDelCuerpoHumano.vag)
					{
						throw new ArgumentOutOfRangeException(estimulada.ToString());
					}
					femalePenetracionTipo = FemalePenetracionTipo.vag;
				}
				else
				{
					femalePenetracionTipo = FemalePenetracionTipo.anus;
				}
			}
			else
			{
				femalePenetracionTipo = FemalePenetracionTipo.facial;
			}
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos();
			float num;
			PenetracionesByMainInFrame.Penetracion penetracion;
			this.SimularPenetracion(estimulante, femalePenetracionTipo, deltaTime, out intervalo, out minGenerado, out maxGenerado, out num, ref emocionesFemeninasValues, out penetracion);
			TData item = this.m_pool.GetItem();
			faseTres = item;
			this.PoblarConData(penetracion, item, deltaTime);
			this.PostPoblarDataConItem(item, null);
		}

		// Token: 0x060019D3 RID: 6611 RVA: 0x000689E0 File Offset: 0x00066BE0
		public void SimularPenetracion(ParteQuePuedeEstimular estimulante, FemalePenetracionTipo tipo, float timeSpanSeconds, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, out float maxEmoValue, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			PenetracionesByMainInFrame.Penetracion penetracion;
			this.SimularPenetracion(estimulante, tipo, timeSpanSeconds, out intervalo, out minGenerado, out maxGenerado, out maxEmoValue, ref emocionesValoresMods, out penetracion);
		}

		// Token: 0x060019D4 RID: 6612 RVA: 0x00068A04 File Offset: 0x00066C04
		public void SimularPenetracion(ParteQuePuedeEstimular estimulante, FemalePenetracionTipo tipo, float timeSpanSeconds, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, out float maxEmoValue, ref EmocionesFemeninasValues emocionesValoresMods, out PenetracionesByMainInFrame.Penetracion penetracion)
		{
			bool debugPrint = this.config.debugPrint;
			if (!this.config.debugPrintSimulated)
			{
				this.config.debugPrint = false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
				break;
			case FemalePenetracionTipo.vag:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
				break;
			case FemalePenetracionTipo.facial:
				parteDelCuerpoHumano = ParteDelCuerpoHumano.bocaInterno;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			GrupoQueCompartenValores grupoQueCompartenValores2 = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			if (this.mapaDeParteEstimulanteGrupo)
			{
				grupoQueCompartenValores2 = this.mapaDeParteEstimulanteGrupo.GetGrupoDeParte(estimulante);
			}
			penetracion = new PenetracionesByMainInFrame.Penetracion(true);
			penetracion.tipo = tipo;
			EstimuloPenetrante estimuloPenetrante = new EstimuloPenetrante();
			estimuloPenetrante.EstimuloSoloUsaPrioridadesFixed();
			estimuloPenetrante.tipoDeEstimulo = TipoDeEstimulo.coital;
			penetracion.SetEstimuloInstance(estimuloPenetrante, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante.AddParteEstimulada(parteDelCuerpoHumano);
			estimuloPenetrante.velocidadDeCambios = new PenetrationInfoLocal
			{
				profundidadHoleLocal = 1f,
				profundidadPeneLocal = 1f
			};
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			this.PoblarPenetracionData(grupoQueCompartenValores, timeSpanSeconds, penetracion, ref estado, out intervalo, this.datosDeUmbralPenetracion, ref emocionesValoresMods, false);
			EstimuloPenetrante estimuloPenetrante2 = new EstimuloPenetrante();
			estimuloPenetrante2.EstimuloSoloUsaPrioridadesFixed();
			estimuloPenetrante2.tipoDeEstimulo = TipoDeEstimulo.coital;
			penetracion.SetEstimuloInstance(estimuloPenetrante2, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante2.AddParteEstimulada(parteDelCuerpoHumano);
			float num = intervalo.min + 1E-05f;
			estimuloPenetrante2.velocidadDeCambios = new PenetrationInfoLocal
			{
				profundidadHoleLocal = num,
				profundidadPeneLocal = num
			};
			minGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV;
			this.PoblarPenetracionData(grupoQueCompartenValores, timeSpanSeconds, penetracion, ref minGenerado, out rangeValueV, this.datosDeUmbralPenetracion, ref emocionesValoresMods, false);
			this.AplicarModificadoresDeGeneracion(ref minGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			EstimuloPenetrante estimuloPenetrante3 = new EstimuloPenetrante();
			estimuloPenetrante3.EstimuloSoloUsaPrioridadesFixed();
			estimuloPenetrante3.tipoDeEstimulo = TipoDeEstimulo.coital;
			penetracion.SetEstimuloInstance(estimuloPenetrante3, null, estimulante, ParteQuePuedeEstimular.None);
			estimuloPenetrante3.AddParteEstimulada(parteDelCuerpoHumano);
			float num2 = Mathf.Lerp(intervalo.min, intervalo.max, this.datosDeUmbralPenetracion.promedioMod);
			estimuloPenetrante3.velocidadDeCambios = new PenetrationInfoLocal
			{
				profundidadHoleLocal = num2,
				profundidadPeneLocal = num2
			};
			maxGenerado = default(UmbralBasico.Estado);
			RangeValueV2 rangeValueV2;
			this.PoblarPenetracionData(grupoQueCompartenValores, timeSpanSeconds, penetracion, ref maxGenerado, out rangeValueV2, this.datosDeUmbralPenetracion, ref emocionesValoresMods, false);
			this.AplicarModificadoresDeGeneracion(ref maxGenerado, grupoQueCompartenValores, grupoQueCompartenValores2);
			this.MaximoAlcanzado(grupoQueCompartenValores, grupoQueCompartenValores2, estimuloPenetrante3, 1f, out maxEmoValue);
			this.config.debugPrint = debugPrint;
		}

		// Token: 0x060019D5 RID: 6613 RVA: 0x00068C70 File Offset: 0x00066E70
		private bool PoblarPenetracionData(GrupoQueCompartenValores estimuladoGrupo, float deltaTime, PenetracionesByMainInFrame.Penetracion penetracion, ref UmbralBasico.Estado resultado, out RangeValueV2 intervalo, DatosDeUmbral datos, ref EmocionesFemeninasValues emocionesValoresMods, bool suavizar = true)
		{
			float num = penetracion.estimulo.velocidadDeCambios.profundidadHoleLocal;
			if (num < 0f)
			{
				num = 0f;
			}
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			float num2;
			if (suavizar)
			{
				ParteQuePuedeEstimular estimulanteParte = penetracion.estimulanteParte;
				SmoothFloatsV2 smoothDeId = base.GetSmoothDeId((int)(estimulanteParte * (ParteQuePuedeEstimular)(penetracion.tipo + 1)));
				smoothDeId.Add(num);
				num2 = smoothDeId.suavizado;
			}
			else
			{
				num2 = num;
			}
			intervalo = datos.intervaloDeGeneracion;
			ValorModificable estimulacionQueGenera = datos.estimulacionQueGenera;
			if (this.aplicarModsDeIntervalos)
			{
				if (this.modsDeIntervaloPorGrupoEstimulado_Incremento_Velocidad)
				{
					intervalo.Increase(this.modsDeIntervaloPorGrupoEstimulado_Incremento_Velocidad[estimuladoGrupo].valor, 0.0001f);
				}
				if (this.modsDeIntervaloPorGrupoEstimulado_Expancion_Velocidad)
				{
					intervalo.Expandir(this.modsDeIntervaloPorGrupoEstimulado_Expancion_Velocidad[estimuladoGrupo].valor, 0.0001f);
				}
			}
			this.OnPreUmbralCalculoPenetracion(penetracion, ref num2, ref intervalo, ref estimulacionQueGenera, ref emocionesValoresMods);
			try
			{
				resultado = UmbralBasico.Calcular(num2, deltaTime, UmbralBasico.TipoDeCambio.porSegundo, intervalo, estimulacionQueGenera.total, datos.spotBonuses, datos.promedioMod, datos.modPorEncima, datos.modPorDebajo);
			}
			catch (Exception)
			{
				Debug.LogWarning("Error calculando UmbralBasico de penetracion  de emocion " + this.m_Emo.GetType().Name);
				throw;
			}
			float num3 = resultado.estimulacionGeneradaEnFrame;
			this.OnPostUmbralCalculoPenetracion(penetracion, ref num3);
			num3 = Mathf.Clamp(num3, 0f, float.MaxValue);
			resultado.SetEstimulacionGeneradaEnFrame(num3);
			resultado.SetEstimulacionGeneradaTotal(num3);
			if (this.config.debugPrint && this.config.debugPrintPenetracion && (!this.config.debugPrintSoloGenerada || (this.config.debugPrintSoloGenerada && num3 > 0f)))
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"vel:",
					num.ToString("0.0000"),
					" su:",
					num2.ToString("0.0000"),
					" min:",
					intervalo.min.ToString("0.0000"),
					" max:",
					intervalo.max.ToString("0.0000"),
					" ",
					resultado.PrintStr()
				}));
			}
			return resultado.estimulacionGeneradaEnFrame > 0f;
		}

		// Token: 0x060019D6 RID: 6614
		protected abstract void OnPreUmbralCalculoPenetracion(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues emocionesValoresMods);

		// Token: 0x060019D7 RID: 6615
		protected abstract void OnPostUmbralCalculoPenetracion(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada);

		// Token: 0x060019D8 RID: 6616
		protected abstract void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, EstimuloPenetrante estimulo, ref float maxEmotionValue);

		// Token: 0x060019DB RID: 6619 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x060019DC RID: 6620 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x060019DE RID: 6622 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400132C RID: 4908
		[Obsolete("", true)]
		private CalculoDeEstimuloPorPenetracionRecibidaBase<TData, TResult>.masFuerte m_masFuerte;

		// Token: 0x0400132D RID: 4909
		protected const int penetrationIndex = 1;

		// Token: 0x0400132E RID: 4910
		[Header("Basica")]
		public bool aplicarModsDeIntervalos = true;

		// Token: 0x0400132F RID: 4911
		[Obsolete("", true)]
		private List<ICalculoDeEstimuloCoitalHole> m_calculosTEMP = new List<ICalculoDeEstimuloCoitalHole>();

		// Token: 0x04001330 RID: 4912
		[SerializeField]
		protected TResult m_Resultado = new TResult();

		// Token: 0x04001331 RID: 4913
		public bool generar = true;

		// Token: 0x04001332 RID: 4914
		public bool generarPorPenetracion = true;

		// Token: 0x04001333 RID: 4915
		private List<PenetracionesByMainInFrame.Penetracion> m_PeneTemp = new List<PenetracionesByMainInFrame.Penetracion>();

		// Token: 0x04001334 RID: 4916
		protected SimplePoolDeClearables<TData> m_pool = new SimplePoolDeClearables<TData>();

		// Token: 0x04001335 RID: 4917
		protected List<TData> m_dataGenerada = new List<TData>();

		// Token: 0x04001336 RID: 4918
		protected List<TData> m_dataNoGenerada = new List<TData>();

		// Token: 0x04001337 RID: 4919
		protected List<TData> m_masFuerteAMasDebil = new List<TData>();

		// Token: 0x04001338 RID: 4920
		[SerializeField]
		private BufferedCoolDown m_BufferedCoolDownDePenetracion = new BufferedCoolDown();

		// Token: 0x04001339 RID: 4921
		private static Comparison<TData> comparison = (TData x, TData y) => y.estimuloGeneradoEnFrame.CompareTo(x.estimuloGeneradoEnFrame);

		// Token: 0x0200047E RID: 1150
		[Obsolete("", true)]
		private struct masFuerte
		{
			// Token: 0x0400133A RID: 4922
			public ForcedUpdateId id;

			// Token: 0x0400133B RID: 4923
			public CalculoDeEstimuloPorPenetracionHoleResultado valor;
		}
	}
}
