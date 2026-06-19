using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200050A RID: 1290
	public class DecepcionPorToques : CalculoDeEstimuloEnFrameSlaveSegunValorGenerado<PlacerPorToques, CalculoDeEstimuloPorCariciasResultado>, ICalculadorDeEstimuloTactil, ICalculadorDeEstimulo<ICalculoDeEstimuloTactil>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorArregladorDeInstanciasDeEstimulos<ICalculoDeEstimuloTactil>
	{
		// Token: 0x06001F1C RID: 7964 RVA: 0x000756A1 File Offset: 0x000738A1
		ICalculoDeEstimuloTactil ICalculadorDeEstimulo<ICalculoDeEstimuloTactil>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06001F1D RID: 7965 RVA: 0x000756AA File Offset: 0x000738AA
		ICalculoDeEstimuloTactil ICalculadorDeEstimulo<ICalculoDeEstimuloTactil>.GetCalculoEnFrame(int index)
		{
			return base.GetCalculoEnFrame(index);
		}

		// Token: 0x06001F1E RID: 7966 RVA: 0x00003B39 File Offset: 0x00001D39
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloTactil> resultado)
		{
		}

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x06001F1F RID: 7967 RVA: 0x00005F51 File Offset: 0x00004151
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}

		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x06001F20 RID: 7968 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x06001F21 RID: 7969 RVA: 0x00005F51 File Offset: 0x00004151
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x06001F22 RID: 7970 RVA: 0x000756B3 File Offset: 0x000738B3
		[Obsolete("", true)]
		public new bool estimuloExisteEnFrame
		{
			get
			{
				return base.estimuloExisteEnFrame && base.master.emo.valueChangedAmount <= 0f;
			}
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x06001F23 RID: 7971 RVA: 0x000756D9 File Offset: 0x000738D9
		[Obsolete("", true)]
		ICalculoDeEstimuloTactil ICalculadorDeEstimulo<ICalculoDeEstimuloTactil>.calculoMasFuerte
		{
			get
			{
				return base.calculoMasFuerte;
			}
		}

		// Token: 0x06001F24 RID: 7972 RVA: 0x000756E4 File Offset: 0x000738E4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.bocaHole = this.GetComponentEnRoot(false);
			this.vagHole = this.GetComponentEnRoot(false);
			this.anusHole = this.GetComponentEnRoot(false);
			if (this.bocaHole == null)
			{
				throw new ArgumentNullException("bocaHole", "bocaHole null reference.");
			}
			if (this.vagHole == null)
			{
				throw new ArgumentNullException("vagHole", "vagHole null reference.");
			}
			if (this.anusHole == null)
			{
				throw new ArgumentNullException("anusHole", "anusHole null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001F25 RID: 7973 RVA: 0x00075777 File Offset: 0x00073977
		protected override PlacerPorToques LoadMaster()
		{
			return this.m_emocionesDeOwner.placer.GetComponentInChildren<PlacerPorToques>();
		}

		// Token: 0x06001F26 RID: 7974 RVA: 0x0007578C File Offset: 0x0007398C
		protected override bool CalculoEsValido(CalculoDeEstimuloPorCariciasResultado calculo, float generado)
		{
			bool flag = generado <= 0f && calculo.data.estado.rango == UmbralBasico.RangoEstado.porDebajo;
			if (!flag)
			{
				return false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.PartePrincipalEstimulada(false);
			bool flag2 = parteDelCuerpoHumano.EsCoitoOral();
			bool flag3 = parteDelCuerpoHumano.EsCoitoVaginal();
			bool flag4 = parteDelCuerpoHumano.EsCoitoAnal();
			if (flag2 || flag3 || flag4)
			{
				if (flag2 && this.bocaHole.isPenetrated)
				{
					return false;
				}
				if (flag3 && this.vagHole.isPenetrated)
				{
					return false;
				}
				if (flag4 && this.anusHole.isPenetrated)
				{
					return false;
				}
			}
			return flag;
		}

		// Token: 0x06001F27 RID: 7975 RVA: 0x00075816 File Offset: 0x00073A16
		protected override void Convertir(CalculoDeEstimuloPorCariciasResultado entrante, CalculoDeEstimuloPorCariciasResultado resultado)
		{
			entrante.CopiarA(resultado);
		}

		// Token: 0x06001F28 RID: 7976 RVA: 0x00075820 File Offset: 0x00073A20
		protected override CalculoDeEstimuloPorCariciasResultado Comparar(CalculoDeEstimuloPorCariciasResultado a, CalculoDeEstimuloPorCariciasResultado b)
		{
			ref UmbralBasico.Estado estado = a.data.estado;
			UmbralBasico.Estado estado2 = b.data.estado;
			if (estado.offsetMod <= estado2.offsetMod)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06001F29 RID: 7977 RVA: 0x00074140 File Offset: 0x00072340
		protected override bool FrameEsValido(CalculoDeEstimuloPorCariciasResultado calculoElegidoOriginal, float generadoTotal)
		{
			return generadoTotal <= 0f;
		}

		// Token: 0x06001F2A RID: 7978 RVA: 0x00075816 File Offset: 0x00073A16
		protected override void CopiarCalculo(CalculoDeEstimuloPorCariciasResultado original, CalculoDeEstimuloPorCariciasResultado copiaResultado)
		{
			original.CopiarA(copiaResultado);
		}

		// Token: 0x06001F2B RID: 7979 RVA: 0x00075854 File Offset: 0x00073A54
		protected override void PoblarConData(CalculoDeEstimuloPorCariciasResultado calculoElegidoCopia, float deltaTime)
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
		}

		// Token: 0x06001F2C RID: 7980 RVA: 0x000758D4 File Offset: 0x00073AD4
		protected override void ObtenerCambioGenerado(CalculoDeEstimuloPorCariciasResultado calculoElegidoCopia, out float generadoNoLimitado, out float generadoLimitado)
		{
			generadoNoLimitado = (generadoLimitado = calculoElegidoCopia.data.estado.estimulacionGeneradaEnFrame);
		}

		// Token: 0x06001F2D RID: 7981 RVA: 0x000758F8 File Offset: 0x00073AF8
		private float Generada(CalculoDeEstimuloPorCariciasResultado calculoElegidoCopia)
		{
			float num = 1f;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(calculoElegidoCopia.estimulo, calculoElegidoCopia.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), calculoElegidoCopia.data.estimulanteParte, false, null);
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

		// Token: 0x06001F2E RID: 7982 RVA: 0x000742D0 File Offset: 0x000724D0
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Decepcion;
		}

		// Token: 0x06001F2F RID: 7983 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001F30 RID: 7984 RVA: 0x000759C0 File Offset: 0x00073BC0
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloTactil calculo)
		{
			CalculoDeEstimuloPorCariciasResultado calculoDeEstimuloPorCariciasResultado;
			bool flag = base.TryInstantiateCalculo(out calculoDeEstimuloPorCariciasResultado);
			calculo = calculoDeEstimuloPorCariciasResultado;
			return flag;
		}

		// Token: 0x06001F31 RID: 7985 RVA: 0x000759D8 File Offset: 0x00073BD8
		public void FixEstimulosInstancesTypes(ICalculoDeEstimuloTactil original, ICalculoDeEstimuloTactil instanciado)
		{
			base.master.FixEstimulosInstancesTypes(original, instanciado);
		}

		// Token: 0x06001F33 RID: 7987 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001F34 RID: 7988 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001F35 RID: 7989 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001F36 RID: 7990 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001F37 RID: 7991 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001F38 RID: 7992 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400147E RID: 5246
		public float maxGeneracionPorSegundo = 1.111f;

		// Token: 0x0400147F RID: 5247
		public float generacionPorCantidadDeVecesEnOffset = 0.01f;

		// Token: 0x04001480 RID: 5248
		private IBocaHole bocaHole;

		// Token: 0x04001481 RID: 5249
		private IVagHole vagHole;

		// Token: 0x04001482 RID: 5250
		private IAnusHole anusHole;

		// Token: 0x04001483 RID: 5251
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
