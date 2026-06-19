using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000501 RID: 1281
	public class DecepcionPorPenetraciones : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalPenetracion<PlacerPorPenetraciones, CalculoDeEstimuloPorPenetracionHoleResultadoSimple, CalculoDeEstimuloPorPenetracionHoleResultado>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x06001E6B RID: 7787 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06001E6C RID: 7788 RVA: 0x00005F51 File Offset: 0x00004151
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06001E6D RID: 7789 RVA: 0x00074456 File Offset: 0x00072656
		[Obsolete("", true)]
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.calculoMasFuerte
		{
			get
			{
				return base.calculoMasFuerte;
			}
		}

		// Token: 0x06001E6E RID: 7790 RVA: 0x0007445E File Offset: 0x0007265E
		[Obsolete("", true)]
		public override void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloCoitalHole> resultado)
		{
			resultado.Add(base.calculoMasFuerte);
		}

		// Token: 0x06001E6F RID: 7791 RVA: 0x0007446C File Offset: 0x0007266C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001E70 RID: 7792 RVA: 0x00074485 File Offset: 0x00072685
		protected override void Updating(float deltaTime)
		{
			base.Updating(deltaTime);
			this.resultado.Clear();
			this.resultado.Poblar(base.emo, this, TipoDeCalculoDeEstimulo.frame);
		}

		// Token: 0x06001E71 RID: 7793 RVA: 0x00073FE7 File Offset: 0x000721E7
		protected override PlacerPorPenetraciones LoadMaster()
		{
			return this.m_emocionesDeOwner.placer.GetComponentInChildren<PlacerPorPenetraciones>();
		}

		// Token: 0x06001E72 RID: 7794 RVA: 0x000744AC File Offset: 0x000726AC
		protected override bool CalculoEsValido(CalculoDeEstimuloPorPenetracionHoleResultado calculo, float generado)
		{
			return generado <= 0f && calculo.data.penetracion.rango == UmbralBasico.RangoEstado.porDebajo;
		}

		// Token: 0x06001E73 RID: 7795 RVA: 0x000744CC File Offset: 0x000726CC
		protected override void Convertir(CalculoDeEstimuloPorPenetracionHoleResultado entrante, CalculoDeEstimuloPorPenetracionHoleResultadoSimple resultado)
		{
			resultado.Clear();
			entrante.estimulo.CopiarA(resultado.estimulo, false);
			if (entrante.estimulo.tieneCopiaInvertida && entrante.estimuloInvertido != null && resultado.estimuloInvertido != null)
			{
				entrante.estimuloInvertido.CopiarA(resultado.estimuloInvertido, false);
			}
			resultado.data.tag = entrante.data.tag;
			resultado.data.emocion = entrante.data.emocion;
			resultado.data.tipo = entrante.data.tipo;
			resultado.data.estimulanteParte = entrante.data.estimulanteParte;
			resultado.data.estimulanteParteInvertido = entrante.data.estimulanteParteInvertido;
			resultado.data.estado = entrante.data.penetracion;
			resultado.data.calculador = entrante.data.calculador;
		}

		// Token: 0x06001E74 RID: 7796 RVA: 0x000745BC File Offset: 0x000727BC
		protected override CalculoDeEstimuloPorPenetracionHoleResultadoSimple Comparar(CalculoDeEstimuloPorPenetracionHoleResultadoSimple a, CalculoDeEstimuloPorPenetracionHoleResultadoSimple b)
		{
			ref UmbralBasico.Estado estado = a.data.estado;
			UmbralBasico.Estado estado2 = b.data.estado;
			if (estado.offsetMod <= estado2.offsetMod)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06001E75 RID: 7797 RVA: 0x000745F0 File Offset: 0x000727F0
		[Obsolete("siempre va a ser penetracon mas apto", true)]
		private UmbralBasico.Estado MasApto(CalculoDeEstimuloPorPenetracionHoleResultado calculo)
		{
			float offsetMod = calculo.data.penetracion.offsetMod;
			float offsetMod2 = calculo.data.anchura.offsetMod;
			float offsetMod3 = calculo.data.apertura.offsetMod;
			float offsetMod4 = calculo.data.movimiento.offsetMod;
			if (offsetMod <= offsetMod2 && offsetMod <= offsetMod3 && offsetMod <= offsetMod4)
			{
				return calculo.data.penetracion;
			}
			if (offsetMod2 <= offsetMod && offsetMod2 <= offsetMod3 && offsetMod2 <= offsetMod4)
			{
				return calculo.data.anchura;
			}
			if (offsetMod3 <= offsetMod && offsetMod3 <= offsetMod2 && offsetMod3 <= offsetMod4)
			{
				return calculo.data.apertura;
			}
			if (offsetMod4 <= offsetMod && offsetMod4 <= offsetMod2 && offsetMod4 <= offsetMod3)
			{
				return calculo.data.movimiento;
			}
			throw new ArgumentOutOfRangeException("???????");
		}

		// Token: 0x06001E76 RID: 7798 RVA: 0x00074140 File Offset: 0x00072340
		protected override bool FrameEsValido(CalculoDeEstimuloPorPenetracionHoleResultadoSimple calculoElegidoOriginal, float generadoTotal)
		{
			return generadoTotal <= 0f;
		}

		// Token: 0x06001E77 RID: 7799 RVA: 0x0007414D File Offset: 0x0007234D
		protected override void CopiarCalculo(CalculoDeEstimuloPorPenetracionHoleResultadoSimple original, CalculoDeEstimuloPorPenetracionHoleResultadoSimple copiaResultado)
		{
			original.CopiarA(copiaResultado);
		}

		// Token: 0x06001E78 RID: 7800 RVA: 0x000746AC File Offset: 0x000728AC
		protected override void PoblarConData(CalculoDeEstimuloPorPenetracionHoleResultadoSimple calculoElegidoCopia, float deltaTime)
		{
			float num = this.Generada(calculoElegidoCopia);
			calculoElegidoCopia.data.calculador = this;
			calculoElegidoCopia.data.emocion = this.m_Emo;
			UmbralBasico.Estado estado = new UmbralBasico.Estado(ForcedUpdateId.current);
			estado.rango = UmbralBasico.RangoEstado.enRango;
			estado.SetEstimulacionGeneradaEnFrame(num);
			estado.SetEstimulacionGeneradaTotal(num);
			estado.offsetMod = 1f;
			estado.spotScore = SpotScore.enSpot;
			estado.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
			calculoElegidoCopia.data.estado = estado;
			this.resultado.PoblarAdd(calculoElegidoCopia, this.contextoDePrioridadDeParteHumana);
		}

		// Token: 0x06001E79 RID: 7801 RVA: 0x0007473C File Offset: 0x0007293C
		protected override void ObtenerCambioGenerado(CalculoDeEstimuloPorPenetracionHoleResultadoSimple calculoElegidoCopia, out float generadoNoLimitado, out float generadoLimitado)
		{
			generadoNoLimitado = (generadoLimitado = calculoElegidoCopia.data.estado.estimulacionGeneradaEnFrame);
		}

		// Token: 0x06001E7A RID: 7802 RVA: 0x00074760 File Offset: 0x00072960
		private float Generada(CalculoDeEstimuloPorPenetracionHoleResultadoSimple calculoElegidoCopia)
		{
			float num = 1f;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(calculoElegidoCopia.estimulo, calculoElegidoCopia.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), calculoElegidoCopia.data.estimulanteParte, false, null);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced = modificador.advanced;
			if (advanced != null)
			{
				num = advanced.gainModificable.ModificarValor(1f);
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional = modificador.tradicional;
			if (tradicional != null)
			{
				num = tradicional.gainModificable.ModificarValor(1f);
			}
			float num2 = this.maxGeneracionPorSegundo * Time.deltaTime * num;
			float offsetMod = calculoElegidoCopia.data.estado.offsetMod;
			if (offsetMod <= 0f)
			{
				return num2;
			}
			return Mathf.Clamp(1f / offsetMod * this.generacionPorCantidadDeVecesEnOffset * num, 0f, num2);
		}

		// Token: 0x06001E7B RID: 7803 RVA: 0x000742D0 File Offset: 0x000724D0
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Decepcion;
		}

		// Token: 0x06001E7C RID: 7804 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001E7D RID: 7805 RVA: 0x00074828 File Offset: 0x00072A28
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloCoitalHoleSimple calculo)
		{
			CalculoDeEstimuloPorPenetracionHoleResultadoSimple calculoDeEstimuloPorPenetracionHoleResultadoSimple;
			bool flag = base.TryInstantiateCalculo(out calculoDeEstimuloPorPenetracionHoleResultadoSimple);
			calculo = calculoDeEstimuloPorPenetracionHoleResultadoSimple;
			return flag;
		}

		// Token: 0x06001E7E RID: 7806 RVA: 0x00074840 File Offset: 0x00072A40
		public override bool TryInstantiateCalculo(out ICalculoDeEstimuloCoitalHole calculo)
		{
			CalculoDeEstimuloPorPenetracionHoleResultadoSimple calculoDeEstimuloPorPenetracionHoleResultadoSimple;
			bool flag = base.TryInstantiateCalculo(out calculoDeEstimuloPorPenetracionHoleResultadoSimple);
			calculo = calculoDeEstimuloPorPenetracionHoleResultadoSimple;
			return flag;
		}

		// Token: 0x06001E7F RID: 7807 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public override ICalculoDeEstimuloCoital GetCalculos()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001E81 RID: 7809 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001E82 RID: 7810 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001E83 RID: 7811 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001E84 RID: 7812 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001E85 RID: 7813 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001E86 RID: 7814 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400145F RID: 5215
		public float maxGeneracionPorSegundo = 1.111f;

		// Token: 0x04001460 RID: 5216
		public float generacionPorCantidadDeVecesEnOffset = 0.01f;

		// Token: 0x04001461 RID: 5217
		public CalculoDeEstimuloPorPenetracionResultadoSimple resultado;

		// Token: 0x04001462 RID: 5218
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
