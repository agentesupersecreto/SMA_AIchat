using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000477 RID: 1143
	public abstract class CalculoDeEstimuloEnFrame : AplicableBehaviour, ICalculadorDeEstimulo, IComponentAwakeable, IActivable, ICalculadorDeEstimuloOnCalculoCallback
	{
		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06001929 RID: 6441
		public abstract TipoDeEstimulo tipoDeEstimulo { get; }

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x0600192A RID: 6442 RVA: 0x00005F51 File Offset: 0x00004151
		public TipoDeCalculadorDeEstimulo tipo
		{
			get
			{
				return TipoDeCalculadorDeEstimulo.frame;
			}
		}

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x0600192B RID: 6443 RVA: 0x00066CF7 File Offset: 0x00064EF7
		public Emocion emo
		{
			get
			{
				if (this.m_Emo == null)
				{
					this.m_Emo = base.GetComponentInParent<Emocion>();
				}
				return this.m_Emo;
			}
		}

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x0600192C RID: 6444 RVA: 0x00066D19 File Offset: 0x00064F19
		public ReaccionHumana reaccion
		{
			get
			{
				return this.m_Emo.reaccion;
			}
		}

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x0600192D RID: 6445
		[Obsolete("ahora todos los resultado y estados de resultados deben ser registrados", true)]
		public abstract bool puedeSerUsadoPorAI { get; }

		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x0600192E RID: 6446 RVA: 0x00066D26 File Offset: 0x00064F26
		public double prioridad
		{
			get
			{
				return this.baseConfiguracion.prioridad * Emocion.APrioridad(this.m_Emo);
			}
		}

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x0600192F RID: 6447 RVA: 0x0005848D File Offset: 0x0005668D
		// (set) Token: 0x06001930 RID: 6448 RVA: 0x00005AAA File Offset: 0x00003CAA
		bool IActivable.activado
		{
			get
			{
				return base.isActiveAndEnabled;
			}
			set
			{
				base.enabled = value;
			}
		}

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x06001931 RID: 6449 RVA: 0x00066D40 File Offset: 0x00064F40
		// (remove) Token: 0x06001932 RID: 6450 RVA: 0x00066D78 File Offset: 0x00064F78
		public event Action<CalculoDeEstimuloEnFrame, Emocion.EventValueData> updating;

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x06001933 RID: 6451 RVA: 0x00066DB0 File Offset: 0x00064FB0
		// (remove) Token: 0x06001934 RID: 6452 RVA: 0x00066DE8 File Offset: 0x00064FE8
		public event CalculoDeEstimuloEnFrameUpdatedHandler updated;

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x06001935 RID: 6453 RVA: 0x00066E20 File Offset: 0x00065020
		// (remove) Token: 0x06001936 RID: 6454 RVA: 0x00066E58 File Offset: 0x00065058
		public event CalculadorOnCalculadoTotalCallbacksHandler generadoFrame;

		// Token: 0x06001937 RID: 6455 RVA: 0x00066E8D File Offset: 0x0006508D
		[Obsolete("llmado en los override de DoUpdate, pero vuelve y se llama desde Emo_updatingValue, entonces resulta en doble call", true)]
		protected void InvokeCalculadoTotalDeFrame(float generadoNoLimitado, float generadoLimitado)
		{
			CalculadorOnCalculadoTotalCallbacksHandler calculadorOnCalculadoTotalCallbacksHandler = this.generadoFrame;
			if (calculadorOnCalculadoTotalCallbacksHandler == null)
			{
				return;
			}
			calculadorOnCalculadoTotalCallbacksHandler(generadoNoLimitado, generadoLimitado, this);
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x00066EA4 File Offset: 0x000650A4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_Emo == null)
			{
				this.m_Emo = base.GetComponentInParent<Emocion>();
			}
			this.m_emocionesDeOwner = base.GetComponentInParent<EmocionesFemeninas>();
			if (this.m_Emo == null)
			{
				throw new ArgumentNullException("m_Emo", "m_Emo null reference.");
			}
			if (!this.EmocionPadreEsValida(this.m_Emo))
			{
				throw new InvalidOperationException();
			}
			this.m_CoolDown = new CoolDown();
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x00066F1A File Offset: 0x0006511A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Emo.updatingValue += this.Emo_updatingValue;
			this.UpdateCheckers();
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x00066F3F File Offset: 0x0006513F
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_Emo.updatingValue -= this.Emo_updatingValue;
			this.m_IPuedeActualizarseCheckers.Clear();
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x00066F6A File Offset: 0x0006516A
		public void UpdateCheckers()
		{
			this.m_IPuedeActualizarseCheckers.Clear();
			base.GetComponentsInChildren<CalculoDeEstimuloEnFrame.IPuedeActualizarse>(this.m_IPuedeActualizarseCheckers);
		}

		// Token: 0x0600193C RID: 6460
		protected abstract bool EmocionPadreEsValida(Emocion emo);

		// Token: 0x0600193D RID: 6461
		protected abstract float GetNextCoolDown();

		// Token: 0x0600193E RID: 6462 RVA: 0x00066F84 File Offset: 0x00065184
		private void Emo_updatingValue(Emocion.EventValueData obj)
		{
			try
			{
				if (!base.isActiveAndEnabled || this.m_CoolDown.isOn)
				{
					return;
				}
				for (int i = 0; i < this.m_IPuedeActualizarseCheckers.Count; i++)
				{
					if (!this.m_IPuedeActualizarseCheckers[i].puedeActualizarse)
					{
						return;
					}
				}
			}
			finally
			{
				this.Updating(Time.deltaTime);
			}
			Action<CalculoDeEstimuloEnFrame, Emocion.EventValueData> action = this.updating;
			if (action != null)
			{
				action(this, obj);
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 1f;
			this.DoUpdate(ref num, ref num2, ref num3, Time.deltaTime);
			float num4 = num2;
			obj.Add(num4);
			float num5 = this.baseConfiguracion.cambiarValorDeEmocionDespuesDeTiempo * num3;
			if (num4 != 0f)
			{
				if (this.tiempoDeComienzo == null)
				{
					this.tiempoDeComienzo = new float?(Time.time);
				}
				if (Time.time - this.tiempoDeComienzo.Value >= num5)
				{
					this.m_CoolDown.ApplyNext(this.GetNextCoolDown());
				}
				else
				{
					obj.Add(-num4);
				}
				this.tiempoDeTermiando = null;
			}
			else
			{
				if (this.tiempoDeTermiando == null)
				{
					this.tiempoDeTermiando = new float?(Time.time);
				}
				if (Time.time - this.tiempoDeTermiando.Value >= num5 * this.baseConfiguracion.cambiarValorDeEmocionDespuesDeTiempoResetMod)
				{
					this.tiempoDeComienzo = null;
				}
			}
			CalculoDeEstimuloEnFrameUpdatedHandler calculoDeEstimuloEnFrameUpdatedHandler = this.updated;
			if (calculoDeEstimuloEnFrameUpdatedHandler != null)
			{
				calculoDeEstimuloEnFrameUpdatedHandler(this, obj, num, num2);
			}
			CalculadorOnCalculadoTotalCallbacksHandler calculadorOnCalculadoTotalCallbacksHandler = this.generadoFrame;
			if (calculadorOnCalculadoTotalCallbacksHandler != null)
			{
				calculadorOnCalculadoTotalCallbacksHandler(num, num2, this);
			}
			for (int j = 0; j < this.m_todosLosSmooth.Count; j++)
			{
				this.m_todosLosSmooth[j].Update();
			}
		}

		// Token: 0x0600193F RID: 6463
		protected abstract void Updating(float deltaTime);

		// Token: 0x06001940 RID: 6464
		protected abstract void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime);

		// Token: 0x06001941 RID: 6465 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void ModificarCambiarEmocionDespuesDeTiempo()
		{
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x00067154 File Offset: 0x00065354
		protected SmoothFloatsV2 GetSmoothDeParte(int parte)
		{
			SmoothFloatsV2 smoothFloatsV;
			if (!this.m_diccDeSmooths.TryGetValue(parte, out smoothFloatsV))
			{
				smoothFloatsV = new SmoothFloatsV2(0.333f, 0f);
				this.m_diccDeSmooths.Add(parte, smoothFloatsV);
				this.m_todosLosSmooth.Add(smoothFloatsV);
			}
			return smoothFloatsV;
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x0006719B File Offset: 0x0006539B
		protected SmoothFloatsV2 GetSmoothDeParte(ParteQuePuedeEstimular parte)
		{
			return this.GetSmoothDeId((int)parte);
		}

		// Token: 0x06001944 RID: 6468 RVA: 0x000671A4 File Offset: 0x000653A4
		protected SmoothFloatsV2 GetSmoothDeId(int parte)
		{
			SmoothFloatsV2 smoothFloatsV;
			if (!this.m_diccDeSmooths.TryGetValue(parte, out smoothFloatsV))
			{
				smoothFloatsV = new SmoothFloatsV2(0.333f, 0f);
				this.m_diccDeSmooths.Add(parte, smoothFloatsV);
				this.m_todosLosSmooth.Add(smoothFloatsV);
			}
			return smoothFloatsV;
		}

		// Token: 0x06001945 RID: 6469 RVA: 0x000671EC File Offset: 0x000653EC
		protected SmoothFloatsV2 GetSemiSmoothDeId(int parte)
		{
			SmoothFloatsV2 smoothFloatsV;
			if (!this.m_diccDeSmoothsBajos.TryGetValue(parte, out smoothFloatsV))
			{
				smoothFloatsV = new SmoothFloatsV2(0.1f, 0f);
				this.m_diccDeSmoothsBajos.Add(parte, smoothFloatsV);
				this.m_todosLosSmooth.Add(smoothFloatsV);
			}
			return smoothFloatsV;
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x00067234 File Offset: 0x00065434
		protected static void ApplyBufferToEstimulado(ref bool haySignal, float bufferTime, BufferedCoolDown bufferCoolDown, ref UmbralBasico.Estado resultado)
		{
			bufferCoolDown.bufferTime = bufferTime;
			bufferCoolDown.bufferResetTime = bufferTime * 0.25f;
			float num;
			bufferCoolDown.IsBuffered(haySignal, out num);
			if (num >= 0.5f)
			{
				resultado.ModificarGenerado(0f);
				if (num >= 0.75f)
				{
					haySignal = false;
					return;
				}
			}
			else
			{
				float num2 = Mathf.InverseLerp(0.5f, 0f, num);
				resultado.ModificarGenerado(num2);
			}
		}

		// Token: 0x06001948 RID: 6472 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x0600194C RID: 6476 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400130A RID: 4874
		private CoolDown m_CoolDown;

		// Token: 0x0400130B RID: 4875
		private float? tiempoDeComienzo;

		// Token: 0x0400130C RID: 4876
		private float? tiempoDeTermiando;

		// Token: 0x0400130D RID: 4877
		protected Emocion m_Emo;

		// Token: 0x0400130E RID: 4878
		protected EmocionesFemeninas m_emocionesDeOwner;

		// Token: 0x0400130F RID: 4879
		public CalculoDeEstimuloEnFrame.BaseConfiguracion baseConfiguracion = new CalculoDeEstimuloEnFrame.BaseConfiguracion();

		// Token: 0x04001310 RID: 4880
		protected Dictionary<int, SmoothFloatsV2> m_diccDeSmooths = new Dictionary<int, SmoothFloatsV2>();

		// Token: 0x04001311 RID: 4881
		protected Dictionary<int, SmoothFloatsV2> m_diccDeSmoothsBajos = new Dictionary<int, SmoothFloatsV2>();

		// Token: 0x04001312 RID: 4882
		private List<SmoothFloatsV2> m_todosLosSmooth = new List<SmoothFloatsV2>();

		// Token: 0x04001316 RID: 4886
		protected List<CalculoDeEstimuloEnFrame.IPuedeActualizarse> m_IPuedeActualizarseCheckers = new List<CalculoDeEstimuloEnFrame.IPuedeActualizarse>();

		// Token: 0x02000478 RID: 1144
		public interface IPuedeActualizarse
		{
			// Token: 0x17000653 RID: 1619
			// (get) Token: 0x0600194E RID: 6478
			bool puedeActualizarse { get; }
		}

		// Token: 0x02000479 RID: 1145
		[Serializable]
		public class BaseConfiguracion
		{
			// Token: 0x04001317 RID: 4887
			[Range(0f, 1000f)]
			public double prioridad = 1.0;

			// Token: 0x04001318 RID: 4888
			public float cambiarValorDeEmocionDespuesDeTiempo;

			// Token: 0x04001319 RID: 4889
			public float cambiarValorDeEmocionDespuesDeTiempoResetMod = 0.25f;
		}
	}
}
