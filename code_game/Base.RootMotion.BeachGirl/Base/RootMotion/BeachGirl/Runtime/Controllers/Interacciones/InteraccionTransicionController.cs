using System;
using System.Collections.Generic;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x02000038 RID: 56
	public sealed class InteraccionTransicionController : ControllerColaDePrioridadBase<InteraccionTransicionController.Estado, InteraccionTransicionController.Orden, InteraccionTransicionController.Cola, InteraccionTransicionController, int>
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000262 RID: 610 RVA: 0x0000D348 File Offset: 0x0000B548
		protected override int cantidadDeEstados
		{
			get
			{
				return this.m_updater.cantidadDeLayers;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000D355 File Offset: 0x0000B555
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 10;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0000D359 File Offset: 0x0000B559
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdate2);
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000D364 File Offset: 0x0000B564
		protected override void AwakeUnityEvent()
		{
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.m_InteraccionController = this.GetComponentEnRoot(false);
			if (this.m_InteraccionController == null)
			{
				throw new ArgumentNullException("m_InteraccionController", "m_InteraccionController null reference.");
			}
			this.m_InteraccionesDeCharacter = this.GetComponentEnRoot(false);
			if (this.m_InteraccionesDeCharacter == null)
			{
				throw new ArgumentNullException("m_InteraccionesDeCharacter", "m_InteraccionesDeCharacter null reference.");
			}
			base.AwakeUnityEvent();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000D3EC File Offset: 0x0000B5EC
		public bool Transicionar(InteraccionEstado toExecute, InteractionCallBackHandler toExecuteJustBeforeEjecucionCallBack, int prioridad, ControllerPrioridadConfig priConfig, bool puedePonerEnCola)
		{
			InteraccionTransicionController.Orden orden;
			bool flag;
			bool flag2;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag, toExecute.interactionLayer, prioridad, priConfig, out flag2, ref puedePonerEnCola, false))
			{
				return false;
			}
			InteraccionTransicionController.Orden orden2 = new InteraccionTransicionController.Orden(toExecute, toExecuteJustBeforeEjecucionCallBack, toExecute.interactionLayer, prioridad, 30f, priConfig, false);
			base.Procesar(orden == null, flag, priConfig, orden2, false, false);
			return true;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000D43D File Offset: 0x0000B63D
		protected override InteraccionTransicionController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000D440 File Offset: 0x0000B640
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000D443 File Offset: 0x0000B643
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x040001BA RID: 442
		private IIKUpdater m_updater;

		// Token: 0x040001BB RID: 443
		private InteraccionController m_InteraccionController;

		// Token: 0x040001BC RID: 444
		private IInteraccionesDeCharacter m_InteraccionesDeCharacter;

		// Token: 0x02000130 RID: 304
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<InteraccionTransicionController.Estado, InteraccionTransicionController.Orden, InteraccionTransicionController.Cola, InteraccionTransicionController, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000AFA RID: 2810 RVA: 0x00030854 File Offset: 0x0002EA54
			public Orden(InteraccionEstado toExecute, InteractionCallBackHandler toExecuteJustBeforeEjecucionCallBack, int tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, bool duracionEsFixed = false)
				: base(tipoId, prioridad, duracion, priConfig, duracionEsFixed)
			{
				if (toExecute == null)
				{
					throw new ArgumentNullException("toExecute", "toExecute null reference.");
				}
				this.m_toExecute = toExecute;
				this.m_toExecuteJustBeforeEjecucionCallBack = toExecuteJustBeforeEjecucionCallBack;
				this.m_IKPositionWeightSpeed = 3f;
			}

			// Token: 0x06000AFB RID: 2811 RVA: 0x000308A8 File Offset: 0x0002EAA8
			protected override void OnStart(InteraccionTransicionController dataUpdate)
			{
				IReadOnlyList<Component> readOnlyList = dataUpdate.m_updater.SortedIKsDeLayer(base.tipoId);
				this.m_current = (FullBodyBipedIK)readOnlyList[0];
				this.m_off = (FullBodyBipedIK)readOnlyList[1];
				this.m_controllerOfCurrent = dataUpdate.m_InteraccionController.GetSlaveDeIK(this.m_current, -1);
				this.m_controllerOfOff = dataUpdate.m_InteraccionController.GetSlaveDeIK(this.m_off, -1);
				try
				{
					dataUpdate.m_InteraccionesDeCharacter.GetEjecutandose(base.tipoId, InteraccionTransicionController.Orden.EjecutandoseTEMP);
					for (int i = 0; i < InteraccionTransicionController.Orden.EjecutandoseTEMP.Count; i++)
					{
						InteraccionDeCharacter interaccionDeCharacter = InteraccionTransicionController.Orden.EjecutandoseTEMP[i];
						Component component = dataUpdate.m_updater.IKDeID(interaccionDeCharacter.instancia.lastInteractionSystemID);
						bool flag;
						int num = dataUpdate.m_updater.IndexEnLayerDeIK(component, out flag);
						if (num != 0)
						{
							if (num != 1)
							{
								throw new ArgumentOutOfRangeException(num.ToString());
							}
							this.m_ejecutandoseEnOff = interaccionDeCharacter;
						}
						else
						{
							this.m_ejecutandoseEnCurrent = interaccionDeCharacter;
						}
					}
				}
				finally
				{
					InteraccionTransicionController.Orden.EjecutandoseTEMP.Clear();
				}
				if (this.m_ejecutandoseEnCurrent == null)
				{
					Debug.LogError("transiciones entre interaciones solo es compatible si el main interaction system esta interactuando");
				}
			}

			// Token: 0x06000AFC RID: 2812 RVA: 0x000309D4 File Offset: 0x0002EBD4
			protected override bool UpdateOrden(InteraccionTransicionController dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				if (esPrimerUpdate && this.m_ejecutandoseEnCurrent == null)
				{
					return false;
				}
				if (esPrimerUpdate)
				{
					InteraccionDeCharacter ejecutandoseEnCurrent = this.m_ejecutandoseEnCurrent;
					if (((ejecutandoseEnCurrent != null) ? ejecutandoseEnCurrent.instancia : null) == this.m_toExecute.interaccion)
					{
						return false;
					}
				}
				this.m_estadoActual = this.GetCurrentEstado(dataUpdate);
				InteraccionTransicionController.Orden.Estado estadoActual = this.m_estadoActual;
				return estadoActual - InteraccionTransicionController.Orden.Estado.completed > 1;
			}

			// Token: 0x06000AFD RID: 2813 RVA: 0x00030A3A File Offset: 0x0002EC3A
			protected override void OnDetenidaPorUsuario(InteraccionTransicionController dataUpdate)
			{
			}

			// Token: 0x06000AFE RID: 2814 RVA: 0x00030A3C File Offset: 0x0002EC3C
			protected override bool OnTerminando(InteraccionTransicionController dataUpdate, bool primerUpdate, InteraccionTransicionController.Orden ordenEsperandoDetencion)
			{
				if (primerUpdate)
				{
					this.m_tiempoQueComenzoStop = Time.time;
				}
				if (Time.time - this.m_tiempoQueComenzoStop > 5f)
				{
					Debug.LogError("orden de Transicion fue detenida a la fuerza por tiempo");
					return true;
				}
				bool flag;
				if (this.m_hizoSwitch)
				{
					this.m_off.solver.IKPositionWeight = Mathf.MoveTowards(this.m_off.solver.IKPositionWeight, 1f, base.estadoDeltaTime * this.m_IKPositionWeightSpeed);
					this.m_current.solver.IKPositionWeight = Mathf.MoveTowards(this.m_current.solver.IKPositionWeight, 0f, base.estadoDeltaTime * this.m_IKPositionWeightSpeed);
					flag = this.m_off.solver.IKPositionWeight == 1f && this.m_current.solver.IKPositionWeight == 0f;
				}
				else
				{
					this.m_off.solver.IKPositionWeight = Mathf.MoveTowards(this.m_off.solver.IKPositionWeight, 0f, base.estadoDeltaTime * this.m_IKPositionWeightSpeed);
					this.m_current.solver.IKPositionWeight = Mathf.MoveTowards(this.m_current.solver.IKPositionWeight, 1f, base.estadoDeltaTime * this.m_IKPositionWeightSpeed);
					flag = this.m_current.solver.IKPositionWeight == 1f && this.m_off.solver.IKPositionWeight == 0f;
				}
				bool flag2 = !this.m_ejecutoInteraccion || !this.m_toExecute.AlgunaComenzo() || this.m_toExecute.EstadosTimerWeigthPromedio(1f) >= 0.99f;
				return flag && flag2;
			}

			// Token: 0x06000AFF RID: 2815 RVA: 0x00030C00 File Offset: 0x0002EE00
			protected override void OnTerminada(InteraccionTransicionController dataUpdate, bool abruptamente)
			{
				if (this.m_hizoSwitch)
				{
					this.m_current.solver.IKPositionWeight = 0f;
					this.m_off.solver.IKPositionWeight = 1f;
					return;
				}
				this.m_current.solver.IKPositionWeight = 1f;
				this.m_off.solver.IKPositionWeight = 0f;
			}

			// Token: 0x06000B00 RID: 2816 RVA: 0x00030C6C File Offset: 0x0002EE6C
			private InteraccionTransicionController.Orden.Estado GetCurrentEstado(InteraccionTransicionController dataUpdate)
			{
				switch (this.m_estadoActual)
				{
				case InteraccionTransicionController.Orden.Estado.stopingAnyInteractionOn_Secondary:
					break;
				case InteraccionTransicionController.Orden.Estado.waitingInteractionToStopOn_Secondary:
					if (this.m_controllerOfOff.AlgunaOrndeDeteniendose())
					{
						return InteraccionTransicionController.Orden.Estado.waitingInteractionToStopOn_Secondary;
					}
					if (!this.m_controllerOfOff.AlgunaOrndeEjecutandose())
					{
						return InteraccionTransicionController.Orden.Estado.turningOn_Secondary;
					}
					break;
				case InteraccionTransicionController.Orden.Estado.turningOn_Secondary:
					this.m_off.solver.IKPositionWeight = Mathf.MoveTowards(this.m_off.solver.IKPositionWeight, 1f, base.estadoDeltaTime * this.m_IKPositionWeightSpeed);
					if (this.m_off.solver.IKPositionWeight >= 1f)
					{
						return InteraccionTransicionController.Orden.Estado.startingInteractionOn_Secondary;
					}
					return InteraccionTransicionController.Orden.Estado.turningOn_Secondary;
				case InteraccionTransicionController.Orden.Estado.startingInteractionOn_Secondary:
					if (!this.m_controllerOfOff.InteractuarTodos(this.m_toExecute, false, this.m_toExecuteJustBeforeEjecucionCallBack))
					{
						return InteraccionTransicionController.Orden.Estado.abortar;
					}
					this.m_ejecutoInteraccion = true;
					return InteraccionTransicionController.Orden.Estado.waitingInteractionToMaxUpOn_Secondary;
				case InteraccionTransicionController.Orden.Estado.waitingInteractionToMaxUpOn_Secondary:
					if (this.m_toExecute.EstadosTimerWeigthPromedio(0f) < 0.99f)
					{
						return InteraccionTransicionController.Orden.Estado.waitingInteractionToMaxUpOn_Secondary;
					}
					return InteraccionTransicionController.Orden.Estado.stopingInteractionOn_Main;
				case InteraccionTransicionController.Orden.Estado.stopingInteractionOn_Main:
					goto IL_012E;
				case InteraccionTransicionController.Orden.Estado.waitingInteractionToStopOn_Main:
					if (this.m_controllerOfCurrent.AlgunaOrndeDeteniendose())
					{
						return InteraccionTransicionController.Orden.Estado.waitingInteractionToStopOn_Main;
					}
					if (!this.m_controllerOfCurrent.AlgunaOrndeEjecutandose())
					{
						return InteraccionTransicionController.Orden.Estado.doIkSwitch;
					}
					goto IL_012E;
				case InteraccionTransicionController.Orden.Estado.doIkSwitch:
					dataUpdate.m_updater.SwitchLayerIks(base.tipoId);
					this.m_hizoSwitch = true;
					return InteraccionTransicionController.Orden.Estado.turningOff_Main;
				case InteraccionTransicionController.Orden.Estado.turningOff_Main:
					this.m_current.solver.IKPositionWeight = Mathf.MoveTowards(this.m_current.solver.IKPositionWeight, 0f, base.estadoDeltaTime * this.m_IKPositionWeightSpeed);
					if (this.m_current.solver.IKPositionWeight <= 0f)
					{
						return InteraccionTransicionController.Orden.Estado.completed;
					}
					return InteraccionTransicionController.Orden.Estado.turningOff_Main;
				case InteraccionTransicionController.Orden.Estado.completed:
					return InteraccionTransicionController.Orden.Estado.completed;
				case InteraccionTransicionController.Orden.Estado.abortar:
					return InteraccionTransicionController.Orden.Estado.abortar;
				default:
					throw new ArgumentOutOfRangeException(this.m_estadoActual.ToString());
				}
				if (this.m_ejecutandoseEnOff != null)
				{
					this.m_ejecutandoseEnOff.instancia.Detener(false);
					this.m_ejecutandoseEnOff = null;
					return InteraccionTransicionController.Orden.Estado.stopingAnyInteractionOn_Secondary;
				}
				if (this.m_controllerOfOff.AlgunaOrndeEjecutandose())
				{
					this.m_controllerOfOff.DetenerTodos(false);
					return InteraccionTransicionController.Orden.Estado.stopingAnyInteractionOn_Secondary;
				}
				return InteraccionTransicionController.Orden.Estado.waitingInteractionToStopOn_Secondary;
				IL_012E:
				if (this.m_ejecutandoseEnCurrent != null)
				{
					InteraccionPrimariaBase interaccionPrimariaBase = this.m_ejecutandoseEnCurrent.instancia as InteraccionPrimariaBase;
					if (interaccionPrimariaBase != null)
					{
						interaccionPrimariaBase.FlagToDontRestorePoseOnStop();
					}
					this.m_ejecutandoseEnCurrent.instancia.Detener(false);
					this.m_ejecutandoseEnCurrent = null;
					return InteraccionTransicionController.Orden.Estado.stopingInteractionOn_Main;
				}
				if (this.m_controllerOfCurrent.AlgunaOrndeEjecutandose())
				{
					this.m_controllerOfCurrent.DetenerTodos(false);
					return InteraccionTransicionController.Orden.Estado.stopingInteractionOn_Main;
				}
				return InteraccionTransicionController.Orden.Estado.waitingInteractionToStopOn_Main;
			}

			// Token: 0x04000704 RID: 1796
			private InteraccionEstado m_toExecute;

			// Token: 0x04000705 RID: 1797
			private InteractionCallBackHandler m_toExecuteJustBeforeEjecucionCallBack;

			// Token: 0x04000706 RID: 1798
			private FullBodyBipedIK m_current;

			// Token: 0x04000707 RID: 1799
			private FullBodyBipedIK m_off;

			// Token: 0x04000708 RID: 1800
			private InteractionEffectorControllerSlave m_controllerOfCurrent;

			// Token: 0x04000709 RID: 1801
			private InteractionEffectorControllerSlave m_controllerOfOff;

			// Token: 0x0400070A RID: 1802
			[SerializeField]
			[ReadOnlyUI]
			private InteraccionTransicionController.Orden.Estado m_estadoActual;

			// Token: 0x0400070B RID: 1803
			[SerializeField]
			[ReadOnlyUI]
			private bool m_hizoSwitch;

			// Token: 0x0400070C RID: 1804
			[SerializeField]
			[ReadOnlyUI]
			private bool m_ejecutoInteraccion;

			// Token: 0x0400070D RID: 1805
			[SerializeField]
			private float m_IKPositionWeightSpeed = 1f;

			// Token: 0x0400070E RID: 1806
			[SerializeField]
			[ReadOnlyUI]
			private float m_tiempoQueComenzoStop;

			// Token: 0x0400070F RID: 1807
			[NonSerialized]
			private InteraccionDeCharacter m_ejecutandoseEnCurrent;

			// Token: 0x04000710 RID: 1808
			[NonSerialized]
			private InteraccionDeCharacter m_ejecutandoseEnOff;

			// Token: 0x04000711 RID: 1809
			private static List<InteraccionDeCharacter> EjecutandoseTEMP = new List<InteraccionDeCharacter>();

			// Token: 0x020001D7 RID: 471
			private enum Estado
			{
				// Token: 0x04000A06 RID: 2566
				stopingAnyInteractionOn_Secondary,
				// Token: 0x04000A07 RID: 2567
				waitingInteractionToStopOn_Secondary,
				// Token: 0x04000A08 RID: 2568
				turningOn_Secondary,
				// Token: 0x04000A09 RID: 2569
				startingInteractionOn_Secondary,
				// Token: 0x04000A0A RID: 2570
				waitingInteractionToMaxUpOn_Secondary,
				// Token: 0x04000A0B RID: 2571
				stopingInteractionOn_Main,
				// Token: 0x04000A0C RID: 2572
				waitingInteractionToStopOn_Main,
				// Token: 0x04000A0D RID: 2573
				doIkSwitch,
				// Token: 0x04000A0E RID: 2574
				turningOff_Main,
				// Token: 0x04000A0F RID: 2575
				completed,
				// Token: 0x04000A10 RID: 2576
				abortar
			}
		}

		// Token: 0x02000131 RID: 305
		public sealed class Estado : ControllerColaDePrioridadBase<InteraccionTransicionController.Estado, InteraccionTransicionController.Orden, InteraccionTransicionController.Cola, InteraccionTransicionController, int>.StadoBase
		{
		}

		// Token: 0x02000132 RID: 306
		public sealed class Cola : ControllerColaDePrioridadBase<InteraccionTransicionController.Estado, InteraccionTransicionController.Orden, InteraccionTransicionController.Cola, InteraccionTransicionController, int>.ColasBase
		{
		}
	}
}
