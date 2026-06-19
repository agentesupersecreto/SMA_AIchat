using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001D5 RID: 469
	public class CambiarEstadoDeInteraccionesConAI : AplicableBehaviour, ICambioDePoseEnFrameDataCollector, ICambioDePoseRegistrador
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000B10 RID: 2832 RVA: 0x0001F633 File Offset: 0x0001D833
		public override int updateEvent1Index
		{
			get
			{
				return 69;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000B11 RID: 2833 RVA: 0x00036C6E File Offset: 0x00034E6E
		public IReadOnlyList<CambioDePoseData> ejecutadasEnFrame
		{
			get
			{
				return this.m_ejecutadasEnFrame;
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000B12 RID: 2834 RVA: 0x00036C76 File Offset: 0x00034E76
		public IReadOnlyList<CambioDePoseData> detenidasEnFrame
		{
			get
			{
				return this.m_detenidasEnFrame;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x00036C7E File Offset: 0x00034E7E
		public Character character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x00036C86 File Offset: 0x00034E86
		public SiendoCambiadoEjecutarPosePorCharacterConManos siendoCambiadoEjecutarPosePorCharacterConManos
		{
			get
			{
				return this.m_SiendoCambiadoEjecutarPosePorCharacterConManos;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x00036C8E File Offset: 0x00034E8E
		public SiendoCambiadoEjecutarPosePorCharacterConVoz siendoCambiadoEjecutarPosePorCharacterConVoz
		{
			get
			{
				return this.m_SiendoCambiadoEjecutarPosePorCharacterConVoz;
			}
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000B16 RID: 2838 RVA: 0x00036C96 File Offset: 0x00034E96
		// (set) Token: 0x06000B17 RID: 2839 RVA: 0x00036C9E File Offset: 0x00034E9E
		public int IDFlag
		{
			get
			{
				return this.poseIDFlag;
			}
			set
			{
				this.poseIDFlag = value;
			}
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x00036CA8 File Offset: 0x00034EA8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_interacciones = this.GetComponentEnRoot(false);
			if (this.m_interacciones != null)
			{
				this.m_SiendoCambiadoEjecutarPosePorCharacterConManos = new SiendoCambiadoEjecutarPosePorCharacterConManos(this, this.m_PrioridadesDeObjetoEstimulado);
				this.m_SiendoCambiadoEjecutarPosePorCharacterConVoz = new SiendoCambiadoEjecutarPosePorCharacterConVoz(this, this.m_PrioridadesDeObjetoEstimulado);
			}
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x00036D6F File Offset: 0x00034F6F
		private InteraccionDeCharacter Obtener()
		{
			if (this.poseIDFlag == 0)
			{
				return null;
			}
			return this.m_interacciones.ObtenerBase(this.poseIDFlag);
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x00036D8C File Offset: 0x00034F8C
		public override void OnUpdateEvent1()
		{
			try
			{
				SiendoCambiadoEjecutarPosePorCharacterConManos siendoCambiadoEjecutarPosePorCharacterConManos = this.m_SiendoCambiadoEjecutarPosePorCharacterConManos;
				if (siendoCambiadoEjecutarPosePorCharacterConManos != null)
				{
					siendoCambiadoEjecutarPosePorCharacterConManos.Update_();
				}
				SiendoCambiadoEjecutarPosePorCharacterConVoz siendoCambiadoEjecutarPosePorCharacterConVoz = this.m_SiendoCambiadoEjecutarPosePorCharacterConVoz;
				if (siendoCambiadoEjecutarPosePorCharacterConVoz != null)
				{
					siendoCambiadoEjecutarPosePorCharacterConVoz.Update_();
				}
				this.ResolverPedidos();
			}
			finally
			{
				this.m_detenidasEnFrame.Clear();
				this.m_ejecutadasEnFrame.Clear();
			}
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x00036DEC File Offset: 0x00034FEC
		private void ResolverPedidos()
		{
			for (int i = 0; i < this.m_detenidasEnFrame.Count; i++)
			{
				CambioDePoseData cambioDePoseData = this.m_detenidasEnFrame[i];
				if (cambioDePoseData.cambiaPoseActual)
				{
					InteraccionDeCharacter interaccionDeCharacter = this.m_interacciones.ObtenerBase(cambioDePoseData.poseID);
					if (interaccionDeCharacter != null && !(interaccionDeCharacter.instancia == null))
					{
						interaccionDeCharacter.instancia.Detener(false);
					}
				}
			}
			for (int j = 0; j < this.m_ejecutadasEnFrame.Count; j++)
			{
				CambioDePoseData cambioDePoseData2 = this.m_ejecutadasEnFrame[j];
				if (cambioDePoseData2.cambiaPoseActual)
				{
					InteraccionDeCharacter interaccionDeCharacter2 = this.m_interacciones.ObtenerBase(cambioDePoseData2.poseID);
					if (interaccionDeCharacter2 != null && !(interaccionDeCharacter2.instancia == null))
					{
						if (cambioDePoseData2.ejecutarAnimacionForzando)
						{
							interaccionDeCharacter2.instancia.ForzarEjecucion(-1f, 1f, 1f, 1f, false, cambioDePoseData2.tryUsarTransicion);
						}
						else if (cambioDePoseData2.fueConsentido)
						{
							interaccionDeCharacter2.instancia.Ejecutar(int.MaxValue, -1f, ControllerPrioridadConfig.interrumpir, 1f, 1f, cambioDePoseData2.tryUsarTransicion);
						}
					}
				}
			}
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x00036F18 File Offset: 0x00035118
		public void RegistrarToggle(Character por, bool unaSolaVez, ParteQuePuedeEstimular estimulante, bool fueConsentido, bool ejecutarAnimacionForzando, float? VelocidadDeCambio, bool CambiaPoseActual = true, bool tryUsarTransicion = false)
		{
			if (this.m_interacciones == null)
			{
				return;
			}
			try
			{
				InteraccionDeCharacter interaccionDeCharacter = this.m_interacciones.ObtenerBase(this.poseIDFlag);
				if (interaccionDeCharacter != null && !(interaccionDeCharacter.instancia == null))
				{
					if (CambiaPoseActual && interaccionDeCharacter.instancia.algunaEstaEjecutandose)
					{
						PeticionEstadoDeInteraccionesConAI.CrearPedido(por, unaSolaVez, estimulante, this.m_character, this.poseIDFlag, interaccionDeCharacter.instancia, this.m_PrioridadesDeObjetoEstimulado, fueConsentido, ejecutarAnimacionForzando, CambiaPoseActual, tryUsarTransicion, VelocidadDeCambio, this.m_detenidasEnFrame);
					}
					else
					{
						PeticionEstadoDeInteraccionesConAI.CrearPedido(por, unaSolaVez, estimulante, this.m_character, this.poseIDFlag, interaccionDeCharacter.instancia, this.m_PrioridadesDeObjetoEstimulado, fueConsentido, ejecutarAnimacionForzando, CambiaPoseActual, tryUsarTransicion, VelocidadDeCambio, this.m_ejecutadasEnFrame);
					}
				}
			}
			finally
			{
				this.poseIDFlag = 0;
			}
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00036FE4 File Offset: 0x000351E4
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Crear Toggle Pedido De Main"
			};
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00037000 File Offset: 0x00035200
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			if (this.poseIDFlag == 0)
			{
				return;
			}
			this.RegistrarToggle(MainChar.current, true, ParteQuePuedeEstimular.manos, false, true, null, true, false);
		}

		// Token: 0x0400085C RID: 2140
		private List<CambioDePoseData> m_ejecutadasEnFrame = new List<CambioDePoseData>();

		// Token: 0x0400085D RID: 2141
		private List<CambioDePoseData> m_detenidasEnFrame = new List<CambioDePoseData>();

		// Token: 0x0400085E RID: 2142
		public int poseIDFlag;

		// Token: 0x0400085F RID: 2143
		private Character m_character;

		// Token: 0x04000860 RID: 2144
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x04000861 RID: 2145
		private IInteraccionesDeCharacter m_interacciones;

		// Token: 0x04000862 RID: 2146
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x04000863 RID: 2147
		private SiendoCambiadoEjecutarPosePorCharacterConManos m_SiendoCambiadoEjecutarPosePorCharacterConManos;

		// Token: 0x04000864 RID: 2148
		private SiendoCambiadoEjecutarPosePorCharacterConVoz m_SiendoCambiadoEjecutarPosePorCharacterConVoz;
	}
}
