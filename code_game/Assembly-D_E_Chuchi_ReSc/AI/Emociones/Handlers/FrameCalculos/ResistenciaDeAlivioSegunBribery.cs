using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x02000520 RID: 1312
	public class ResistenciaDeAlivioSegunBribery : CalculoDeEstimuloEnFrame<ResistenciaDeAlivioSegunBribery.Configuracion>
	{
		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x06001FEB RID: 8171 RVA: 0x00004252 File Offset: 0x00002452
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x06001FEC RID: 8172 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x06001FED RID: 8173 RVA: 0x00004252 File Offset: 0x00002452
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06001FEE RID: 8174 RVA: 0x000789C0 File Offset: 0x00076BC0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentCorrupted", "m_ConsentCorrupted null reference.");
			}
			this.m_dolor = this.m_emocionesDeOwner.dolor;
			ICalculadorDeEstimuloOnCalculoCallback[] componentsInChildren = this.m_dolor.GetComponentsInChildren<ICalculadorDeEstimuloOnCalculoCallback>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i] is ICalculadorDeEstimuloConCalculos)
				{
					componentsInChildren[i].generadoFrame += this.CambioDeDolor_calculadoTotalDeFrame;
				}
			}
			this.m_alivio = (Alivio)base.emo;
			this.m_alivioDisMod = this.m_alivio.multiplicadorDeDisminucion.ObtenerModificadorNotNull(this);
			this.m_alivioDisNextMod = this.m_alivio.multiplicadorDeDisminucionNext.ObtenerModificadorNotNull(this);
			this.m_alivio.afterUpdate += this.M_alivio_afterUpdate;
		}

		// Token: 0x06001FEF RID: 8175 RVA: 0x00078AA0 File Offset: 0x00076CA0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_lastAlivioMod = 1f;
			if (this.m_alivioDisMod != null)
			{
				this.m_alivioDisMod.valor.valor = 1f;
			}
			if (this.m_alivioDisNextMod != null)
			{
				this.m_alivioDisNextMod.valor.valor = 1f;
			}
		}

		// Token: 0x06001FF0 RID: 8176 RVA: 0x00078AFC File Offset: 0x00076CFC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			Dolor dolor = this.m_dolor;
			ICalculadorDeEstimuloOnCalculoCallback[] array = ((dolor != null) ? dolor.GetComponentsInChildren<ICalculadorDeEstimuloOnCalculoCallback>() : null);
			if (array != null)
			{
				foreach (ICalculadorDeEstimuloOnCalculoCallback calculadorDeEstimuloOnCalculoCallback in array)
				{
					if (calculadorDeEstimuloOnCalculoCallback != null)
					{
						calculadorDeEstimuloOnCalculoCallback.generadoFrame -= this.CambioDeDolor_calculadoTotalDeFrame;
					}
				}
			}
		}

		// Token: 0x06001FF1 RID: 8177 RVA: 0x00078B50 File Offset: 0x00076D50
		private void CambioDeDolor_calculadoTotalDeFrame(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			if (generadoNoLimitado > 0f)
			{
				ICalculadorDeEstimuloConCalculos calculadorDeEstimuloConCalculos = (ICalculadorDeEstimuloConCalculos)sender;
				if (calculadorDeEstimuloConCalculos.cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil > 0)
				{
					ICalculoDeEstimulo calculoConEstimulosEnFrameMasFuerteAMasDebilBase = calculadorDeEstimuloConCalculos.GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(0);
					this.m_existeEstimuloForzado = this.m_existeEstimuloForzado || this.m_ConsentForzado.EsCorrupted(calculoConEstimulosEnFrameMasFuerteAMasDebilBase);
					this.m_existeEstimulo = true;
				}
			}
		}

		// Token: 0x06001FF2 RID: 8178 RVA: 0x00078BA1 File Offset: 0x00076DA1
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Alivio;
		}

		// Token: 0x06001FF3 RID: 8179 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void Updating(float deltaTime)
		{
		}

		// Token: 0x06001FF4 RID: 8180 RVA: 0x00078BAC File Offset: 0x00076DAC
		protected sealed override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			if (this.m_existeEstimulo)
			{
				this.m_lastAlivioMod = this.config.resistenciaDefectoMod;
				if (this.m_existeEstimuloForzado)
				{
					this.m_alivioDisMod.valor.valor = this.m_lastAlivioMod;
					this.m_alivioDisNextMod.valor.valor = this.m_lastAlivioMod;
				}
			}
		}

		// Token: 0x06001FF5 RID: 8181 RVA: 0x00078C06 File Offset: 0x00076E06
		private void M_alivio_afterUpdate(Emocion obj)
		{
			this.m_existeEstimulo = false;
			this.m_existeEstimuloForzado = false;
			this.m_alivioDisMod.valor.valor = 1f;
			this.m_alivioDisNextMod.valor.valor = 1f;
		}

		// Token: 0x04001504 RID: 5380
		private Dolor m_dolor;

		// Token: 0x04001505 RID: 5381
		private Alivio m_alivio;

		// Token: 0x04001506 RID: 5382
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x04001507 RID: 5383
		[SerializeReference]
		private ModificadorDeFloat m_alivioDisMod;

		// Token: 0x04001508 RID: 5384
		[SerializeReference]
		private ModificadorDeFloat m_alivioDisNextMod;

		// Token: 0x04001509 RID: 5385
		[SerializeField]
		[ReadOnlyUI]
		private float m_lastAlivioMod;

		// Token: 0x0400150A RID: 5386
		private bool m_existeEstimulo;

		// Token: 0x0400150B RID: 5387
		private bool m_existeEstimuloForzado;

		// Token: 0x02000521 RID: 1313
		[Serializable]
		public class Configuracion
		{
			// Token: 0x0400150C RID: 5388
			public float resistenciaDefectoMod = 0.1f;
		}
	}
}
