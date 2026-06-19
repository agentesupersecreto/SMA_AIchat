using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000507 RID: 1287
	public class DecepcionPorPenetracionProfundidad : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalProfunda<PlacerPorPenetraciones, CalculoDeEstimuloPorPenetracionHoleResultadoProfunda, CalculoDeEstimuloPorPenetracionHoleResultado>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x06001EEF RID: 7919 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x06001EF0 RID: 7920 RVA: 0x00005F51 File Offset: 0x00004151
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x06001EF1 RID: 7921 RVA: 0x000752AD File Offset: 0x000734AD
		[Obsolete("", true)]
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.calculoMasFuerte
		{
			get
			{
				return base.calculoMasFuerte;
			}
		}

		// Token: 0x06001EF2 RID: 7922 RVA: 0x000752B5 File Offset: 0x000734B5
		[Obsolete("", true)]
		public override void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloCoitalHole> resultado)
		{
			resultado.Add(base.calculoMasFuerte);
		}

		// Token: 0x06001EF3 RID: 7923 RVA: 0x000752C3 File Offset: 0x000734C3
		[Obsolete("", true)]
		public override ICalculoDeEstimuloCoital GetCalculos()
		{
			return this.resultado;
		}

		// Token: 0x06001EF4 RID: 7924 RVA: 0x000752CB File Offset: 0x000734CB
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001EF5 RID: 7925 RVA: 0x000752E4 File Offset: 0x000734E4
		protected override void Updating(float deltaTime)
		{
			base.Updating(deltaTime);
			this.resultado.Clear();
			this.resultado.Poblar(base.emo, this, TipoDeCalculoDeEstimulo.frame);
		}

		// Token: 0x06001EF6 RID: 7926 RVA: 0x00073FE7 File Offset: 0x000721E7
		protected override PlacerPorPenetraciones LoadMaster()
		{
			return this.m_emocionesDeOwner.placer.GetComponentInChildren<PlacerPorPenetraciones>();
		}

		// Token: 0x06001EF7 RID: 7927 RVA: 0x00073FF9 File Offset: 0x000721F9
		protected override bool CalculoEsValido(CalculoDeEstimuloPorPenetracionHoleResultado calculo, float generado)
		{
			return generado <= 0f && calculo.data.profundidad.rango == UmbralBasico.RangoEstado.porDebajo;
		}

		// Token: 0x06001EF8 RID: 7928 RVA: 0x0007530C File Offset: 0x0007350C
		protected override void Convertir(CalculoDeEstimuloPorPenetracionHoleResultado entrante, CalculoDeEstimuloPorPenetracionHoleResultadoProfunda resultado)
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

		// Token: 0x06001EF9 RID: 7929 RVA: 0x000753FC File Offset: 0x000735FC
		protected override CalculoDeEstimuloPorPenetracionHoleResultadoProfunda Comparar(CalculoDeEstimuloPorPenetracionHoleResultadoProfunda a, CalculoDeEstimuloPorPenetracionHoleResultadoProfunda b)
		{
			ref UmbralBasico.Estado estado = a.data.estado;
			UmbralBasico.Estado estado2 = b.data.estado;
			if (estado.offsetMod <= estado2.offsetMod)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06001EFA RID: 7930 RVA: 0x00074140 File Offset: 0x00072340
		protected override bool FrameEsValido(CalculoDeEstimuloPorPenetracionHoleResultadoProfunda calculoElegidoOriginal, float generadoTotal)
		{
			return generadoTotal <= 0f;
		}

		// Token: 0x06001EFB RID: 7931 RVA: 0x0007414D File Offset: 0x0007234D
		protected override void CopiarCalculo(CalculoDeEstimuloPorPenetracionHoleResultadoProfunda original, CalculoDeEstimuloPorPenetracionHoleResultadoProfunda copiaResultado)
		{
			original.CopiarA(copiaResultado);
		}

		// Token: 0x06001EFC RID: 7932 RVA: 0x00075430 File Offset: 0x00073630
		protected override void PoblarConData(CalculoDeEstimuloPorPenetracionHoleResultadoProfunda calculoElegidoCopia, float deltaTime)
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

		// Token: 0x06001EFD RID: 7933 RVA: 0x000754C0 File Offset: 0x000736C0
		protected override void ObtenerCambioGenerado(CalculoDeEstimuloPorPenetracionHoleResultadoProfunda calculoElegidoCopia, out float generadoNoLimitado, out float generadoLimitado)
		{
			generadoNoLimitado = (generadoLimitado = calculoElegidoCopia.data.estado.estimulacionGeneradaEnFrame);
		}

		// Token: 0x06001EFE RID: 7934 RVA: 0x000754E4 File Offset: 0x000736E4
		private float Generada(CalculoDeEstimuloPorPenetracionHoleResultadoProfunda calculoElegidoCopia)
		{
			float num = 1f;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(calculoElegidoCopia.estimulo, calculoElegidoCopia.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), calculoElegidoCopia.data.estimulanteParte, false, new SensitiveFemaleHoleType?(SensitiveFemaleHoleType.bottom));
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional = modificador.tradicional;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced = modificador.advanced;
			if (advanced != null)
			{
				num = advanced.gainModificable.ModificarValor(1f);
			}
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

		// Token: 0x06001EFF RID: 7935 RVA: 0x000742D0 File Offset: 0x000724D0
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Decepcion;
		}

		// Token: 0x06001F00 RID: 7936 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x000755A8 File Offset: 0x000737A8
		public override bool TryInstantiateCalculo(out ICalculoDeEstimuloCoitalHole calculo)
		{
			CalculoDeEstimuloPorPenetracionHoleResultadoProfunda calculoDeEstimuloPorPenetracionHoleResultadoProfunda;
			bool flag = base.TryInstantiateCalculo(out calculoDeEstimuloPorPenetracionHoleResultadoProfunda);
			calculo = calculoDeEstimuloPorPenetracionHoleResultadoProfunda;
			return flag;
		}

		// Token: 0x06001F03 RID: 7939 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001F04 RID: 7940 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001F05 RID: 7941 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001F06 RID: 7942 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001F07 RID: 7943 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001F08 RID: 7944 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400147A RID: 5242
		public float maxGeneracionPorSegundo = 0.55555f;

		// Token: 0x0400147B RID: 5243
		public float generacionPorCantidadDeVecesEnOffset = 0.01f;

		// Token: 0x0400147C RID: 5244
		public CalculoDeEstimuloPorPenetracionResultadoProfunda resultado;

		// Token: 0x0400147D RID: 5245
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
