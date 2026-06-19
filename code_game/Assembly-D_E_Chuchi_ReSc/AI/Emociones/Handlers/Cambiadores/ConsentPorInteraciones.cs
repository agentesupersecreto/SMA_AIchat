using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores
{
	// Token: 0x02000537 RID: 1335
	public sealed class ConsentPorInteraciones : CalculoDeEstimuloEnFrame, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x060020D7 RID: 8407 RVA: 0x0007AFC1 File Offset: 0x000791C1
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI4);
			}
		}

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x060020D8 RID: 8408 RVA: 0x0007AFCA File Offset: 0x000791CA
		public bool alMaximo
		{
			get
			{
				return this.m_alMaximo;
			}
		}

		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x060020D9 RID: 8409 RVA: 0x0007AFD2 File Offset: 0x000791D2
		public BufferDeMaxValue maxValueBuffer
		{
			get
			{
				return this.m_BufferDeMaxValue;
			}
		}

		// Token: 0x060020DA RID: 8410 RVA: 0x0007AFDC File Offset: 0x000791DC
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
			this.m_consentPorSessiones = this.m_ConsentToHero.sumadorDeValor.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x0007B05C File Offset: 0x0007925C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat consentPorSessiones = this.m_consentPorSessiones;
			if (consentPorSessiones != null)
			{
				consentPorSessiones.TryRemoverDeOwner(true);
			}
			this.m_consentPorSessiones = null;
		}

		// Token: 0x060020DC RID: 8412 RVA: 0x0007B080 File Offset: 0x00079280
		public void Cambiar(float valor, ICalculoDeEstimuloCompleto calculoEntrante)
		{
			MapaDePersonalidad personalidad = this.m_Personalidad.currentPersonalidad.personalidad;
			if (personalidad == null)
			{
				return;
			}
			float num = personalidad.CurrentMaxConsentPorInteraciones();
			ModificadorDeFloat consentPorSessiones = this.m_consentPorSessiones;
			consentPorSessiones.valor.valor = consentPorSessiones.valor.valor + this.m_ConsentToHero.SimularAumento(valor);
			this.m_consentPorSessiones.valor.valor = Mathf.Clamp(this.m_consentPorSessiones.valor.valor, 0f, num);
			ICalculoDeInteracionEstimulanteConEstado calculoDeInteracionEstimulanteConEstado;
			if (valor > 0f && calculoEntrante != null && ConsentPorInteraciones.TryGetCalculoResultSegunCalculador(this.m_resultadosSegunCalculadores, calculoEntrante, out calculoDeInteracionEstimulanteConEstado))
			{
				(calculoEntrante as ICopiableA).CopiarA(calculoDeInteracionEstimulanteConEstado);
				for (int i = 0; i < calculoEntrante.cantidadDeEstados; i++)
				{
					UmbralBasico.Estado estado;
					calculoEntrante.GetEstadoCopia(i, out estado);
					estado.SobreEscribirEstimulacionGeneradaEnFrame(valor, valor, 1f);
					calculoDeInteracionEstimulanteConEstado.SobreEscribirEstado(i, ref estado);
				}
				calculoDeInteracionEstimulanteConEstado.emocion = this.m_ConsentToHero;
				calculoDeInteracionEstimulanteConEstado.producidoPor = this;
				this.m_pedidos.Add(new ValueTuple<ICalculoDeInteracionEstimulanteConEstado, float>(calculoDeInteracionEstimulanteConEstado, valor));
			}
		}

		// Token: 0x060020DD RID: 8413 RVA: 0x0007B178 File Offset: 0x00079378
		public override void OnUpdateEvent1()
		{
			MapaDePersonalidad personalidad = this.m_Personalidad.currentPersonalidad.personalidad;
			if (personalidad != null)
			{
				float num = personalidad.CurrentMaxConsentPorInteraciones();
				if (!this.m_alMaximo)
				{
					this.m_consentPorSessiones.valor.valor = Mathf.Clamp(this.m_consentPorSessiones.valor.valor, 0f, num);
					if (this.m_consentPorSessiones.valor.valor == num)
					{
						this.m_alMaximo = true;
						this.m_BufferDeMaxValue.OnMaxValue();
					}
				}
				else
				{
					this.m_consentPorSessiones.valor.valor = num;
				}
			}
			this.m_BufferDeMaxValue.DoUpdate();
		}

		// Token: 0x170008CB RID: 2251
		// (get) Token: 0x060020DE RID: 8414 RVA: 0x00004252 File Offset: 0x00002452
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x170008CC RID: 2252
		// (get) Token: 0x060020DF RID: 8415 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x060020E0 RID: 8416 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x060020E1 RID: 8417 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x060020E2 RID: 8418 RVA: 0x0007B21C File Offset: 0x0007941C
		public int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil
		{
			get
			{
				return this.m_calculosEnFrameMasFuerteADebil.Count;
			}
		}

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x060020E3 RID: 8419 RVA: 0x0007B21C File Offset: 0x0007941C
		public int cantidadDeCalculosEnFrame
		{
			get
			{
				return this.m_calculosEnFrameMasFuerteADebil.Count;
			}
		}

		// Token: 0x060020E4 RID: 8420 RVA: 0x0007B22C File Offset: 0x0007942C
		private static bool TryGetCalculoResultSegunCalculador(Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> m_resultadosSegunCalculadores, ICalculoDeEstimulo calculoEntrante, out ICalculoDeInteracionEstimulanteConEstado resultado)
		{
			ICalculadorDeEstimuloConCalculos calculadorDeEstimuloConCalculos = (calculoEntrante.producidoPorSegundario as ICalculadorDeEstimuloConCalculos) ?? (calculoEntrante.producidoPor as ICalculadorDeEstimuloConCalculos);
			resultado = null;
			if (calculadorDeEstimuloConCalculos == null)
			{
				return false;
			}
			ICalculoDeEstimulo calculoDeEstimulo;
			if (!m_resultadosSegunCalculadores.TryGetValue(calculadorDeEstimuloConCalculos, out resultado) && calculadorDeEstimuloConCalculos.TryInstantiateCalculoBase(out calculoDeEstimulo) && calculoDeEstimulo is ICopiableA && calculoDeEstimulo is ICalculoDeInteracionEstimulanteConEstado && calculoDeEstimulo is IClearable)
			{
				resultado = (ICalculoDeInteracionEstimulanteConEstado)calculoDeEstimulo;
				m_resultadosSegunCalculadores.Add(calculadorDeEstimuloConCalculos, resultado);
				((IClearable)resultado).Clear();
			}
			return resultado != null;
		}

		// Token: 0x060020E5 RID: 8421 RVA: 0x0007B2AA File Offset: 0x000794AA
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is ConsentToHero;
		}

		// Token: 0x060020E6 RID: 8422 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x060020E7 RID: 8423 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void Updating(float deltaTime)
		{
		}

		// Token: 0x060020E8 RID: 8424 RVA: 0x0007B2B8 File Offset: 0x000794B8
		protected override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			for (int i = 0; i < this.m_calculosEnFrameMasFuerteADebil.Count; i++)
			{
				IClearable clearable = this.m_calculosEnFrameMasFuerteADebil[i] as IClearable;
				if (clearable != null)
				{
					clearable.Clear();
				}
			}
			this.m_calculosEnFrameMasFuerteADebil.Clear();
			for (int j = 0; j < this.m_pedidos.Count; j++)
			{
				ValueTuple<ICalculoDeInteracionEstimulanteConEstado, float> valueTuple = this.m_pedidos[j];
				this.m_calculosEnFrameMasFuerteADebil.Add(valueTuple.Item1);
			}
			this.m_pedidos.Clear();
		}

		// Token: 0x060020E9 RID: 8425 RVA: 0x0007B341 File Offset: 0x00079541
		public ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index)
		{
			return this.m_calculosEnFrameMasFuerteADebil[index];
		}

		// Token: 0x060020EA RID: 8426 RVA: 0x0007B341 File Offset: 0x00079541
		public ICalculoDeEstimulo GetCalculoEnFrameBase(int index)
		{
			return this.m_calculosEnFrameMasFuerteADebil[index];
		}

		// Token: 0x060020EB RID: 8427 RVA: 0x0007639F File Offset: 0x0007459F
		public bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo)
		{
			calculo = null;
			return false;
		}

		// Token: 0x060020ED RID: 8429 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x060020EE RID: 8430 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x060020EF RID: 8431 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x060020F0 RID: 8432 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x060020F1 RID: 8433 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060020F2 RID: 8434 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04001565 RID: 5477
		[SerializeField]
		[ReadOnlyUI]
		private bool m_alMaximo;

		// Token: 0x04001566 RID: 5478
		[SerializeField]
		private BufferDeMaxValue m_BufferDeMaxValue = new BufferDeMaxValue();

		// Token: 0x04001567 RID: 5479
		[SerializeField]
		private ModificadorDeFloat m_consentPorSessiones;

		// Token: 0x04001568 RID: 5480
		private Personalidad m_Personalidad;

		// Token: 0x04001569 RID: 5481
		private ConsentToHero m_ConsentToHero;

		// Token: 0x0400156A RID: 5482
		private Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado> m_resultadosSegunCalculadores = new Dictionary<ICalculadorDeEstimulo, ICalculoDeInteracionEstimulanteConEstado>();

		// Token: 0x0400156B RID: 5483
		[SerializeReference]
		private List<ICalculoDeInteracionEstimulanteConEstado> m_calculosEnFrameMasFuerteADebil = new List<ICalculoDeInteracionEstimulanteConEstado>();

		// Token: 0x0400156C RID: 5484
		private List<ValueTuple<ICalculoDeInteracionEstimulanteConEstado, float>> m_pedidos = new List<ValueTuple<ICalculoDeInteracionEstimulanteConEstado, float>>();
	}
}
