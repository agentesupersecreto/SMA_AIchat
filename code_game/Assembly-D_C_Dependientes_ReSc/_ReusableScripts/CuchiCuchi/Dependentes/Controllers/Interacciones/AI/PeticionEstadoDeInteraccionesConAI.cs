using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001D9 RID: 473
	public class PeticionEstadoDeInteraccionesConAI : AplicableBehaviour, ICambioDePoseEnFrameDataCollector, ICambioDePoseRegistrador
	{
		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000B2F RID: 2863 RVA: 0x0001F633 File Offset: 0x0001D833
		public override int updateEvent1Index
		{
			get
			{
				return 69;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000B30 RID: 2864 RVA: 0x00037343 File Offset: 0x00035543
		public IReadOnlyList<CambioDePoseData> ejecutadasEnFrame
		{
			get
			{
				return this.m_ejecutadasEnFrame;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000B31 RID: 2865 RVA: 0x0003734B File Offset: 0x0003554B
		public IReadOnlyList<CambioDePoseData> detenidasEnFrame
		{
			get
			{
				return this.m_detenidasEnFrame;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000B32 RID: 2866 RVA: 0x00037353 File Offset: 0x00035553
		public Character character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x0003735B File Offset: 0x0003555B
		// (set) Token: 0x06000B34 RID: 2868 RVA: 0x00037363 File Offset: 0x00035563
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

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x0003736C File Offset: 0x0003556C
		public SiendoPedidoEjecutarPosePorCharacter siendoPedidoEjecutarPosePorCharacter
		{
			get
			{
				return this.m_SiendoPedidoEjecutarPosePorCharacter;
			}
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00037374 File Offset: 0x00035574
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
				this.m_SiendoPedidoEjecutarPosePorCharacter = new SiendoPedidoEjecutarPosePorCharacter(this, this.m_PrioridadesDeObjetoEstimulado);
			}
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x00037429 File Offset: 0x00035629
		private InteraccionDeCharacter Obtener()
		{
			if (this.poseIDFlag == 0)
			{
				return null;
			}
			return this.m_interacciones.ObtenerBase(this.poseIDFlag);
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00037448 File Offset: 0x00035648
		public override void OnUpdateEvent1()
		{
			try
			{
				SiendoPedidoEjecutarPosePorCharacter siendoPedidoEjecutarPosePorCharacter = this.m_SiendoPedidoEjecutarPosePorCharacter;
				if (siendoPedidoEjecutarPosePorCharacter != null)
				{
					siendoPedidoEjecutarPosePorCharacter.Update_();
				}
				this.ResolverPedidos();
			}
			finally
			{
				this.m_detenidasEnFrame.Clear();
				this.m_ejecutadasEnFrame.Clear();
			}
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x00037498 File Offset: 0x00035698
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

		// Token: 0x06000B3A RID: 2874 RVA: 0x000375C4 File Offset: 0x000357C4
		public static void CrearPedido(Character por, bool unaSolaVez, ParteQuePuedeEstimular estimulante, Character own, int poseID, Interaccion inter, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, bool fueConsentido, bool ejecutarAnimacionForzando, bool CambiaPoseActual, bool tryUsarTransicion, float? VelocidadDeCambio, List<CambioDePoseData> targetData)
		{
			if (por == null)
			{
				return;
			}
			if (own == null)
			{
				return;
			}
			if (inter == null)
			{
				return;
			}
			InteraccionPersonalidadData component = inter.GetComponent<InteraccionPersonalidadData>();
			if (component == null)
			{
				return;
			}
			IReadOnlyList<ParteDelCuerpoHumano> readOnlyList;
			IReadOnlyCollection<int> readOnlyCollection;
			component.ObtenerExponiendoPartes(out readOnlyList, out readOnlyCollection, new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.ojos));
			if (readOnlyList.Count == 0)
			{
				Debug.LogError("Siempre debe haber uan parte siendo expuesta para que los pedidos se ejecuten");
				return;
			}
			HumanBodyBones humanBodyBones = readOnlyList.ObtenerLaDeMayorPrioridadCoital(PrioridadesDeObjetoEstimulado, PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor).ParceToHumanBodyBones(Side.R);
			Transform boneTransform = own.bodyAnimator.GetBoneTransform(humanBodyBones);
			CambioDePoseData cambioDePoseData = new CambioDePoseData(por, unaSolaVez, poseID, boneTransform, fueConsentido, ejecutarAnimacionForzando, CambiaPoseActual, tryUsarTransicion, VelocidadDeCambio, estimulante, readOnlyList, readOnlyCollection);
			targetData.Add(cambioDePoseData);
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00037668 File Offset: 0x00035868
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

		// Token: 0x06000B3C RID: 2876 RVA: 0x00036FE4 File Offset: 0x000351E4
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Crear Toggle Pedido De Main"
			};
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00037734 File Offset: 0x00035934
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			if (this.poseIDFlag == 0)
			{
				return;
			}
			this.RegistrarToggle(MainChar.current, true, ParteQuePuedeEstimular.boca, false, false, null, true, false);
		}

		// Token: 0x04000871 RID: 2161
		private List<CambioDePoseData> m_ejecutadasEnFrame = new List<CambioDePoseData>();

		// Token: 0x04000872 RID: 2162
		private List<CambioDePoseData> m_detenidasEnFrame = new List<CambioDePoseData>();

		// Token: 0x04000873 RID: 2163
		public int poseIDFlag;

		// Token: 0x04000874 RID: 2164
		private Character m_character;

		// Token: 0x04000875 RID: 2165
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x04000876 RID: 2166
		private IInteraccionesDeCharacter m_interacciones;

		// Token: 0x04000877 RID: 2167
		private SiendoPedidoEjecutarPosePorCharacter m_SiendoPedidoEjecutarPosePorCharacter;

		// Token: 0x04000878 RID: 2168
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;
	}
}
