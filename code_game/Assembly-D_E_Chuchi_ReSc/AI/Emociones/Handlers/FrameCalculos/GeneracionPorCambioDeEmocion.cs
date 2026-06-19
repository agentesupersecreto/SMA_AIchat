using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200051A RID: 1306
	public sealed class GeneracionPorCambioDeEmocion : CalculoDeEstimuloEnFrame<GeneracionPorCambioDeEmocion.Configuracion>
	{
		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x06001F9F RID: 8095 RVA: 0x00004252 File Offset: 0x00002452
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x06001FA0 RID: 8096 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x06001FA1 RID: 8097 RVA: 0x00006060 File Offset: 0x00004260
		[Obsolete("", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x06001FA2 RID: 8098 RVA: 0x00004252 File Offset: 0x00002452
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x06001FA3 RID: 8099 RVA: 0x00004252 File Offset: 0x00002452
		[Obsolete("", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06001FA4 RID: 8100 RVA: 0x00077CE0 File Offset: 0x00075EE0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_reaccionTarget == ReaccionHumana.None)
			{
				throw new InvalidOperationException();
			}
			this.m_emocionTarget = this.m_emocionesDeOwner.ObtenerEmocion(this.m_reaccionTarget);
			ICalculadorDeEstimuloOnCalculoCallback[] componentsInChildren = this.m_emocionTarget.GetComponentsInChildren<ICalculadorDeEstimuloOnCalculoCallback>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].generadoFrame += this.DisminucionPorAumento_calculadoTotalDeFrame;
			}
		}

		// Token: 0x06001FA5 RID: 8101 RVA: 0x00077D48 File Offset: 0x00075F48
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			Emocion emocionTarget = this.m_emocionTarget;
			ICalculadorDeEstimuloOnCalculoCallback[] array = ((emocionTarget != null) ? emocionTarget.GetComponentsInChildren<ICalculadorDeEstimuloOnCalculoCallback>() : null);
			if (array != null)
			{
				foreach (ICalculadorDeEstimuloOnCalculoCallback calculadorDeEstimuloOnCalculoCallback in array)
				{
					if (calculadorDeEstimuloOnCalculoCallback != null)
					{
						calculadorDeEstimuloOnCalculoCallback.generadoFrame -= this.DisminucionPorAumento_calculadoTotalDeFrame;
					}
				}
			}
		}

		// Token: 0x06001FA6 RID: 8102 RVA: 0x00077D99 File Offset: 0x00075F99
		private void DisminucionPorAumento_calculadoTotalDeFrame(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			this.m_calculadoresEnFrameConvinado += generadoNoLimitado;
		}

		// Token: 0x06001FA7 RID: 8103 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return true;
		}

		// Token: 0x06001FA8 RID: 8104 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void Updating(float deltaTime)
		{
		}

		// Token: 0x06001FA9 RID: 8105 RVA: 0x00077DAC File Offset: 0x00075FAC
		protected sealed override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			try
			{
				float num = this.m_emocionTarget.valueChangedAmountMayorAZero * this.config.cambioPorCambio;
				float num2 = this.m_calculadoresEnFrameConvinado * this.config.cambioPorCambio;
				generadoNoLimitado = (generadoLimitado = (this.m_lastChange = num + num2));
				if (this.config.usarLimites)
				{
					float total = this.m_emocionTarget.value.total;
					if (total >= this.config.limiteMaximo || total <= this.config.limiteMinimo)
					{
						generadoLimitado = 0f;
					}
				}
			}
			finally
			{
				this.m_calculadoresEnFrameConvinado = 0f;
			}
		}

		// Token: 0x040014ED RID: 5357
		[SerializeField]
		private ReaccionHumana m_reaccionTarget;

		// Token: 0x040014EE RID: 5358
		private Emocion m_emocionTarget;

		// Token: 0x040014EF RID: 5359
		private float m_calculadoresEnFrameConvinado;

		// Token: 0x040014F0 RID: 5360
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastChange;

		// Token: 0x0200051B RID: 1307
		[Serializable]
		public class Configuracion
		{
			// Token: 0x040014F1 RID: 5361
			public float cambioPorCambio;

			// Token: 0x040014F2 RID: 5362
			[Header("Limites")]
			public bool usarLimites = true;

			// Token: 0x040014F3 RID: 5363
			[Range(0f, 100f)]
			public float limiteMinimo;

			// Token: 0x040014F4 RID: 5364
			[Range(0f, 100f)]
			public float limiteMaximo = 100f;
		}
	}
}
