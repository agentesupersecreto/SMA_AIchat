using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004FE RID: 1278
	public class DecepcionPorPenetracionAnchura : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalAnchura<PlacerPorPenetraciones, CalculoDeEstimuloPorPenetracionHoleResultadoAnchura, CalculoDeEstimuloPorPenetracionHoleResultado>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x06001E3E RID: 7742 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x06001E3F RID: 7743 RVA: 0x00005F51 File Offset: 0x00004151
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x06001E40 RID: 7744 RVA: 0x00073F89 File Offset: 0x00072189
		[Obsolete("", true)]
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.calculoMasFuerte
		{
			get
			{
				return base.calculoMasFuerte;
			}
		}

		// Token: 0x06001E41 RID: 7745 RVA: 0x00073F91 File Offset: 0x00072191
		[Obsolete("", true)]
		public override void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloCoitalHole> resultado)
		{
			resultado.Add(base.calculoMasFuerte);
		}

		// Token: 0x06001E42 RID: 7746 RVA: 0x00073F9F File Offset: 0x0007219F
		[Obsolete("", true)]
		public override ICalculoDeEstimuloCoital GetCalculos()
		{
			return this.resultado;
		}

		// Token: 0x06001E43 RID: 7747 RVA: 0x00073FA7 File Offset: 0x000721A7
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001E44 RID: 7748 RVA: 0x00073FC0 File Offset: 0x000721C0
		protected override void Updating(float deltaTime)
		{
			base.Updating(deltaTime);
			this.resultado.Clear();
			this.resultado.Poblar(base.emo, this, TipoDeCalculoDeEstimulo.frame);
		}

		// Token: 0x06001E45 RID: 7749 RVA: 0x00073FE7 File Offset: 0x000721E7
		protected override PlacerPorPenetraciones LoadMaster()
		{
			return this.m_emocionesDeOwner.placer.GetComponentInChildren<PlacerPorPenetraciones>();
		}

		// Token: 0x06001E46 RID: 7750 RVA: 0x00073FF9 File Offset: 0x000721F9
		protected override bool CalculoEsValido(CalculoDeEstimuloPorPenetracionHoleResultado calculo, float generado)
		{
			return generado <= 0f && calculo.data.profundidad.rango == UmbralBasico.RangoEstado.porDebajo;
		}

		// Token: 0x06001E47 RID: 7751 RVA: 0x0007401C File Offset: 0x0007221C
		protected override void Convertir(CalculoDeEstimuloPorPenetracionHoleResultado entrante, CalculoDeEstimuloPorPenetracionHoleResultadoAnchura resultado)
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
			resultado.data.estado = entrante.data.profundidad;
			resultado.data.calculador = entrante.data.calculador;
		}

		// Token: 0x06001E48 RID: 7752 RVA: 0x0007410C File Offset: 0x0007230C
		protected override CalculoDeEstimuloPorPenetracionHoleResultadoAnchura Comparar(CalculoDeEstimuloPorPenetracionHoleResultadoAnchura a, CalculoDeEstimuloPorPenetracionHoleResultadoAnchura b)
		{
			ref UmbralBasico.Estado estado = a.data.estado;
			UmbralBasico.Estado estado2 = b.data.estado;
			if (estado.offsetMod <= estado2.offsetMod)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06001E49 RID: 7753 RVA: 0x00074140 File Offset: 0x00072340
		protected override bool FrameEsValido(CalculoDeEstimuloPorPenetracionHoleResultadoAnchura calculoElegidoOriginal, float generadoTotal)
		{
			return generadoTotal <= 0f;
		}

		// Token: 0x06001E4A RID: 7754 RVA: 0x0007414D File Offset: 0x0007234D
		protected override void CopiarCalculo(CalculoDeEstimuloPorPenetracionHoleResultadoAnchura original, CalculoDeEstimuloPorPenetracionHoleResultadoAnchura copiaResultado)
		{
			original.CopiarA(copiaResultado);
		}

		// Token: 0x06001E4B RID: 7755 RVA: 0x00074158 File Offset: 0x00072358
		protected override void PoblarConData(CalculoDeEstimuloPorPenetracionHoleResultadoAnchura calculoElegidoCopia, float deltaTime)
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

		// Token: 0x06001E4C RID: 7756 RVA: 0x000741E8 File Offset: 0x000723E8
		protected override void ObtenerCambioGenerado(CalculoDeEstimuloPorPenetracionHoleResultadoAnchura calculoElegidoCopia, out float generadoNoLimitado, out float generadoLimitado)
		{
			generadoNoLimitado = (generadoLimitado = calculoElegidoCopia.data.estado.estimulacionGeneradaEnFrame);
		}

		// Token: 0x06001E4D RID: 7757 RVA: 0x0007420C File Offset: 0x0007240C
		private float Generada(CalculoDeEstimuloPorPenetracionHoleResultadoAnchura calculoElegidoCopia)
		{
			float num = 1f;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(calculoElegidoCopia.estimulo, calculoElegidoCopia.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), calculoElegidoCopia.data.estimulanteParte, false, new SensitiveFemaleHoleType?(SensitiveFemaleHoleType.walls));
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

		// Token: 0x06001E4E RID: 7758 RVA: 0x000742D0 File Offset: 0x000724D0
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Decepcion;
		}

		// Token: 0x06001E4F RID: 7759 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001E50 RID: 7760 RVA: 0x000742DC File Offset: 0x000724DC
		public override bool TryInstantiateCalculo(out ICalculoDeEstimuloCoitalHole calculo)
		{
			CalculoDeEstimuloPorPenetracionHoleResultadoAnchura calculoDeEstimuloPorPenetracionHoleResultadoAnchura;
			bool flag = base.TryInstantiateCalculo(out calculoDeEstimuloPorPenetracionHoleResultadoAnchura);
			calculo = calculoDeEstimuloPorPenetracionHoleResultadoAnchura;
			return flag;
		}

		// Token: 0x06001E52 RID: 7762 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001E53 RID: 7763 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001E54 RID: 7764 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001E55 RID: 7765 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001E56 RID: 7766 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001E57 RID: 7767 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400145B RID: 5211
		public float maxGeneracionPorSegundo = 0.55555f;

		// Token: 0x0400145C RID: 5212
		public float generacionPorCantidadDeVecesEnOffset = 0.01f;

		// Token: 0x0400145D RID: 5213
		public CalculoDeEstimuloPorPenetracionResultadoAnchura resultado;

		// Token: 0x0400145E RID: 5214
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
