using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000F0 RID: 240
	public sealed class InteractionEffectorControllerSlave : ControllerColaDePrioridadBase<InteractionEffectorControllerSlave.Estado, InteractionEffectorControllerSlave.Orden, InteractionEffectorControllerSlave.Cola, InteractionEffectorControllerSlave, FullBodyBipedEffector>
	{
		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00028AD0 File Offset: 0x00026CD0
		public sealed override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060008F9 RID: 2297 RVA: 0x00028AD3 File Offset: 0x00026CD3
		protected override int cantidadDeEstados
		{
			get
			{
				if (this.m_cantidadDeEstados == null)
				{
					this.m_cantidadDeEstados = new int?(typeof(FullBodyBipedEffector).GetEnumCount());
				}
				return this.m_cantidadDeEstados.Value;
			}
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00028B08 File Offset: 0x00026D08
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_AtadurasDePuppetController = this.GetComponentEnRoot(false);
			this.m_puedeUsarAtadurasDePuppet = this.m_AtadurasDePuppetController != null;
			if (!this.m_puedeUsarAtadurasDePuppet)
			{
				ICharacter componentEnRoot = this.GetComponentEnRoot(false);
				if (((componentEnRoot != null) ? new Sexo?(componentEnRoot.sexo) : null).GetValueOrDefault() == Sexo.femenino)
				{
					Debug.LogError("Controllador de effector slave No sera compatible con ataduras de puppet", this);
				}
			}
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00028B84 File Offset: 0x00026D84
		public void Init(InteraccionController owner, FullBodyBipedIK IK, InteractionSystemV3 InteractionSystem)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			if (IK == null)
			{
				throw new ArgumentNullException("IK", "IK null reference.");
			}
			this.m_owner = owner;
			IIKUpdater componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("updater", "updater null reference.");
			}
			this.m_InteractionSystemID = componentEnRoot.IDDeIK(IK);
			this.m_InteractionSystemLayer = componentEnRoot.LayerDeIK(IK);
			if (InteractionSystem == null)
			{
				throw new ArgumentNullException("InteractionSystem", "InteractionSystem null reference.");
			}
			this.m_InteractionSystem = InteractionSystem;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00028C2B File Offset: 0x00026E2B
		public void ActualizarControllador()
		{
			base.ActualizarControlladorManualmente(false);
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00028C34 File Offset: 0x00026E34
		public bool AlgunaEstaInteractuando(InteraccionInfo interaction)
		{
			if (interaction == null)
			{
				return false;
			}
			for (int i = 0; i < interaction.effectorsInteractions.Count; i++)
			{
				InteraccionEffectorParInfo interaccionEffectorParInfo = interaction.effectorsInteractions[i];
				if (interaccionEffectorParInfo.activado && this.EstaInteractuando(interaccionEffectorParInfo.interactionObject, interaccionEffectorParInfo.fullBodyBipedEffector))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00028C88 File Offset: 0x00026E88
		public bool TryGetFreeNotLockedHand(out Side handSide, out FullBodyBipedEffector handEffector)
		{
			if (!this.Interactuando(FullBodyBipedEffector.RightHand))
			{
				handSide = Side.R;
				handEffector = FullBodyBipedEffector.RightHand;
				return true;
			}
			if (!this.Interactuando(FullBodyBipedEffector.LeftHand))
			{
				handSide = Side.L;
				handEffector = FullBodyBipedEffector.LeftHand;
				return true;
			}
			if (!this.IsFijaPorAnimacion(FullBodyBipedEffector.RightHand, true))
			{
				handSide = Side.R;
				handEffector = FullBodyBipedEffector.RightHand;
				return true;
			}
			if (!this.IsFijaPorAnimacion(FullBodyBipedEffector.LeftHand, true))
			{
				handSide = Side.L;
				handEffector = FullBodyBipedEffector.LeftHand;
				return true;
			}
			handSide = Side.L;
			handEffector = FullBodyBipedEffector.LeftHand;
			return false;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00028CE4 File Offset: 0x00026EE4
		public bool PuedeApoyarse(FullBodyBipedEffector fullBodyBipedEffector, bool esExtencion)
		{
			if (!base.isActiveAndEnabled)
			{
				return true;
			}
			InteractionEffectorControllerSlave.Orden orden = base.currentStado[fullBodyBipedEffector];
			if (orden == null || orden.Termino())
			{
				return true;
			}
			if (esExtencion)
			{
				return orden.puedeApoyarseExt;
			}
			return orden.puedeApoyarse;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00028D2C File Offset: 0x00026F2C
		public bool PuedeInterrumpierse(FullBodyBipedEffector fullBodyBipedEffector)
		{
			if (!base.isActiveAndEnabled)
			{
				return false;
			}
			InteractionEffectorControllerSlave.Orden orden = base.currentStado[fullBodyBipedEffector];
			return orden == null || orden.Termino() || orden.priConfig != ControllerPrioridadConfig.interrumpir;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00028D70 File Offset: 0x00026F70
		public bool PuedeTrasladarse(FullBodyBipedEffector fullBodyBipedEffector)
		{
			if (!base.isActiveAndEnabled)
			{
				return true;
			}
			if (this.IsFijaPorAnimacion(fullBodyBipedEffector, true))
			{
				return false;
			}
			InteractionEffectorControllerSlave.Orden orden = base.currentStado[fullBodyBipedEffector];
			return orden == null || orden.Termino() || orden.puedeTrasladarse;
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00028DBC File Offset: 0x00026FBC
		public bool IsFijaPorAnimacion(FullBodyBipedEffector fullBodyBipedEffector, bool OApoyando = true)
		{
			if (!base.isActiveAndEnabled)
			{
				return false;
			}
			InteractionEffectorControllerSlave.Orden orden = base.currentStado[fullBodyBipedEffector];
			return (orden != null && !orden.Termino() && orden.fijaPorAnimacion) || (OApoyando && this.Apoyando(fullBodyBipedEffector));
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00028E04 File Offset: 0x00027004
		private bool Apoyando(FullBodyBipedEffector fullBodyBipedEffector)
		{
			if (!this.m_puedeUsarAtadurasDePuppet)
			{
				return false;
			}
			bool flag;
			switch (fullBodyBipedEffector)
			{
			case FullBodyBipedEffector.Body:
				flag = this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.hombroL) && this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.hombroR) && this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.caderaL) && this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.caderaR);
				break;
			case FullBodyBipedEffector.LeftShoulder:
				flag = this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.hombroL);
				break;
			case FullBodyBipedEffector.RightShoulder:
				flag = this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.hombroR);
				break;
			case FullBodyBipedEffector.LeftThigh:
				flag = this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.caderaL);
				break;
			case FullBodyBipedEffector.RightThigh:
				flag = this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.caderaR);
				break;
			case FullBodyBipedEffector.LeftHand:
				flag = !this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.manoR) && !this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.codoR) && (this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.manoL) || this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.codoL));
				break;
			case FullBodyBipedEffector.RightHand:
				flag = !this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.manoL) && !this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.codoL) && (this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.manoR) || this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.codoR));
				break;
			case FullBodyBipedEffector.LeftFoot:
				flag = this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.pieL) || this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.rodillaL);
				break;
			case FullBodyBipedEffector.RightFoot:
				flag = this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.pieR) || this.m_AtadurasDePuppetController.Apoyando(TipoDeAtaduraDePuppet.rodillaR);
				break;
			default:
				throw new ArgumentOutOfRangeException(fullBodyBipedEffector.ToString());
			}
			return flag;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00028FB4 File Offset: 0x000271B4
		public bool TryStopInteraccion(InteractionObjectV2Base interactionObject, FullBodyBipedEffector effector)
		{
			if (this.EstaInteractuando(interactionObject, effector))
			{
				base.currentStado.DetenerOrdenEnSlot(effector);
			}
			IReadOnlyList<InteractionEffectorControllerSlave.Orden> readOnlyList = base.currentStado.ObtenerOrdenesDeteniendose(effector);
			if (readOnlyList == null || readOnlyList.Count == 0)
			{
				return true;
			}
			bool flag = true;
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				InteractionEffectorControllerSlave.Orden orden = readOnlyList[i];
				if (orden.interactionObject == interactionObject && orden.effector == effector && !this.TryStopOrden(orden))
				{
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00029030 File Offset: 0x00027230
		private bool TryStopOrden(InteractionEffectorControllerSlave.Orden orden)
		{
			if (orden.system == null || orden.interactionObject == null)
			{
				return true;
			}
			if (!this.EjecutandoseEnInteractionSystem(orden))
			{
				return true;
			}
			FullBodyBipedEffector tipoId = orden.tipoId;
			if (orden.system.IsPaused(tipoId))
			{
				orden.system.ResumeInteraction(tipoId);
			}
			return false;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0002908C File Offset: 0x0002728C
		private bool EjecutandoseEnInteractionSystem(InteractionEffectorControllerSlave.Orden orden)
		{
			InteractionSystem system = orden.system;
			FullBodyBipedEffector tipoId = orden.tipoId;
			InteractionObject interactionObject = system.GetInteractionObject(tipoId);
			return interactionObject != null && interactionObject == orden.interactionObject;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x000290C4 File Offset: 0x000272C4
		private bool EjecutandoseEnInteractionSystem(InteractionObjectV2Base interactionObject, FullBodyBipedEffector effector)
		{
			InteractionObject interactionObject2 = this.GetSystem().GetInteractionObject(effector);
			return interactionObject2 != null && interactionObject2 == interactionObject;
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x000290F0 File Offset: 0x000272F0
		private InteractionSystem GetSystem()
		{
			return this.m_InteractionSystem;
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x000290F8 File Offset: 0x000272F8
		public bool InteractuandoCualquiera()
		{
			return base.currentStado.AlgunaEjecutandose();
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00029108 File Offset: 0x00027308
		public bool Interactuando(FullBodyBipedEffector tipoId)
		{
			InteractionEffectorControllerSlave.Orden orden = base.currentStado[tipoId];
			return orden != null && !orden.Termino();
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00029130 File Offset: 0x00027330
		public bool EstaInteractuando(InteractionObjectV2Base interactionObject, FullBodyBipedEffector tipoId)
		{
			if (interactionObject == null)
			{
				return false;
			}
			InteractionEffectorControllerSlave.Orden orden = base.currentStado[tipoId];
			return orden != null && orden.interactionObject == interactionObject && !orden.Termino();
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00029174 File Offset: 0x00027374
		public HumanBodyBones ParseTipoIdToHumanBodyBones(FullBodyBipedEffector tipoId)
		{
			HumanBodyBones humanBodyBones;
			switch (tipoId)
			{
			case FullBodyBipedEffector.Body:
				humanBodyBones = HumanBodyBones.Hips;
				break;
			case FullBodyBipedEffector.LeftShoulder:
				humanBodyBones = HumanBodyBones.LeftUpperArm;
				break;
			case FullBodyBipedEffector.RightShoulder:
				humanBodyBones = HumanBodyBones.RightUpperArm;
				break;
			case FullBodyBipedEffector.LeftThigh:
				humanBodyBones = HumanBodyBones.LeftUpperLeg;
				break;
			case FullBodyBipedEffector.RightThigh:
				humanBodyBones = HumanBodyBones.RightUpperLeg;
				break;
			case FullBodyBipedEffector.LeftHand:
				humanBodyBones = HumanBodyBones.LeftHand;
				break;
			case FullBodyBipedEffector.RightHand:
				humanBodyBones = HumanBodyBones.RightHand;
				break;
			case FullBodyBipedEffector.LeftFoot:
				humanBodyBones = HumanBodyBones.LeftFoot;
				break;
			case FullBodyBipedEffector.RightFoot:
				humanBodyBones = HumanBodyBones.RightFoot;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipoId.ToString());
			}
			return humanBodyBones;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x000291E9 File Offset: 0x000273E9
		public bool InteractuarTodos(InteraccionEstado estado, bool terminarDeInmediato, InteractionCallBackHandler justBeforeEjecucionCallBack = null)
		{
			if (estado == null)
			{
				throw new ArgumentNullException("estado", "estado null reference.");
			}
			return estado.info.isValid && this.interactuarTodos(estado, terminarDeInmediato, justBeforeEjecucionCallBack);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00029218 File Offset: 0x00027418
		private bool interactuarTodos(InteraccionEstado estado, bool terminarDeInmediato, InteractionCallBackHandler justBeforeEjecucionCallBack)
		{
			bool flag2;
			try
			{
				IReadOnlyList<InteraccionEffectorParInfo> effectorsInteractions = estado.info.effectorsInteractions;
				InteraccionStartParams interaccionStartParams = estado.parametros.Modificado(estado.parametrosModificadores);
				for (int i = 0; i < effectorsInteractions.Count; i++)
				{
					InteraccionEstado.EstadoDeEffector estadoDeEffector = estado.estados[i];
					IInteractionObjectPar interactionObjectPar = estado.ParDeEstado(estadoDeEffector);
					if (interactionObjectPar == null)
					{
						return false;
					}
					if (interactionObjectPar.activado)
					{
						if (interactionObjectPar.interactionObject == null)
						{
							return false;
						}
						FullBodyBipedEffector effector = interactionObjectPar.effector;
						InteractionEffectorControllerSlave.Orden orden;
						bool flag;
						if (!this.PuedeInteractuar(out orden, out flag, interactionObjectPar.interactionObject, effector, interaccionStartParams.prioridad, interaccionStartParams.duracion, interaccionStartParams.priConfig, interaccionStartParams.velocidadInMod, interaccionStartParams.velocidadOutMod))
						{
							return false;
						}
						this.m_TEmpInteractuarTodos1.Add(orden);
						this.m_TEmpInteractuarTodos2.Add(flag);
						this.m_paresActivos.Add(estadoDeEffector);
					}
				}
				if (this.m_paresActivos.Count == 0)
				{
					flag2 = false;
				}
				else
				{
					if (estado.detenerDelMismoLayer && !estado.ejecutandose)
					{
						this.DetenerTodos(terminarDeInmediato);
					}
					if (justBeforeEjecucionCallBack != null)
					{
						justBeforeEjecucionCallBack(this.m_InteractionSystemID, this.m_InteractionSystemLayer, ref interaccionStartParams);
					}
					for (int j = 0; j < this.m_paresActivos.Count; j++)
					{
						InteraccionEstado.EstadoDeEffector estadoDeEffector2 = this.m_paresActivos[j];
						IInteractionObjectPar interactionObjectPar2 = estado.ParDeEstado(estadoDeEffector2);
						if (!interactionObjectPar2.activado)
						{
							throw new InvalidOperationException();
						}
						InteractionEffectorControllerSlave.Orden orden2 = this.m_TEmpInteractuarTodos1[j];
						bool flag3 = this.m_TEmpInteractuarTodos2[j];
						if (interactionObjectPar2.interactionObject == null)
						{
							throw new InvalidOperationException();
						}
						FullBodyBipedEffector effector2 = interactionObjectPar2.effector;
						this.Interactuar(orden2, flag3, interactionObjectPar2.interactionObject, effector2, interaccionStartParams.prioridad, interaccionStartParams.duracion, interaccionStartParams.priConfig, interaccionStartParams.initialVelocidadInMod, interaccionStartParams.velocidadInMod, interaccionStartParams.velocidadOutMod, interactionObjectPar2.fijaPorAnimacion, interactionObjectPar2.puedeTrasladarse, interactionObjectPar2.puedeApoyarse, interactionObjectPar2.puedeApoyarseExtencion, terminarDeInmediato, estadoDeEffector2.comenzadaCallBack, estadoDeEffector2.terminadaCallBack);
					}
					flag2 = true;
				}
			}
			finally
			{
				this.m_paresActivos.Clear();
				this.m_TEmpInteractuarTodos1.Clear();
				this.m_TEmpInteractuarTodos2.Clear();
			}
			return flag2;
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00029484 File Offset: 0x00027684
		public void DetenerTodos(bool abruptamente)
		{
			for (int i = 0; i < base.currentStado.Count; i++)
			{
				InteractionEffectorControllerSlave.Orden orden = base.currentStado[i];
				if (orden != null && !orden.TerminoTiempo())
				{
					if (!abruptamente)
					{
						base.currentStado.DetenerOrden(orden);
					}
					else
					{
						base.currentStado.DetenerOrdenAbrutamente(orden);
					}
				}
			}
			if (abruptamente)
			{
				this.m_InteractionSystem.StopInmediatamente();
			}
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x000294EA File Offset: 0x000276EA
		public bool DetenerInteraccion(InteraccionInfo info)
		{
			if (info == null)
			{
				throw new ArgumentNullException("interaction", "interaction null reference.");
			}
			return !info.isValid || this.DetenerTodos(info.effectorsInteractions);
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x00029518 File Offset: 0x00027718
		private bool DetenerTodos(IReadOnlyList<IInteractionObjectPar> paresDeInteracciones)
		{
			bool flag = true;
			for (int i = 0; i < paresDeInteracciones.Count; i++)
			{
				IInteractionObjectPar interactionObjectPar = paresDeInteracciones[i];
				if (interactionObjectPar != null && !(interactionObjectPar.interactionObject == null) && !this.TryStopInteraccion(interactionObjectPar.interactionObject, interactionObjectPar.effector))
				{
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00029568 File Offset: 0x00027768
		private bool PuedeInteractuar(out InteractionEffectorControllerSlave.Orden ordenOcupandoSlot, out bool librePorquePrioridadEsMayor, InteractionObjectV2Base interactionObject, FullBodyBipedEffector tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float velocidadInMod, float velocidadOutMod)
		{
			ordenOcupandoSlot = null;
			librePorquePrioridadEsMayor = false;
			return velocidadInMod > 0f && velocidadOutMod > 0f && !this.m_owner.IsFijaPorAnimacionEnLayers(tipoId, (this.m_InteractionSystemLayer + 1).IKLayerFromToLast(), false) && !base.OrdenAnuladaPorPrioridadBaja(priConfig, tipoId) && !base.EstaOcupadoV2(priConfig, prioridad, tipoId, false, out ordenOcupandoSlot, out librePorquePrioridadEsMayor) && (!base.EntraraACola(ordenOcupandoSlot, librePorquePrioridadEsMayor, priConfig) || base.PuedePonerEnCola(tipoId));
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x000295EC File Offset: 0x000277EC
		private void Interactuar(InteractionEffectorControllerSlave.Orden ordenOcupandoSlot, bool librePorquePrioridadEsMayor, InteractionObjectV2Base interactionObject, FullBodyBipedEffector tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float initialVelocidadInMod, float velocidadInMod, float velocidadOutMod, bool fijaPorAnimacion, bool puedeTrasladarse, bool puedeApoyarse, bool puedeApoyarseExt, bool terminarDeInmediato, Action<InteractionEffectorControllerSlave.Orden> comenzadaCallBack, Action<InteractionEffectorControllerSlave.Orden> terminadaCallBack)
		{
			if (!terminarDeInmediato && base.PuedeAcumularse(ordenOcupandoSlot, priConfig, tipoId) && interactionObject == ordenOcupandoSlot.interactionObject && !ordenOcupandoSlot.flagToStop)
			{
				ordenOcupandoSlot.SetPrioridad(prioridad);
				base.ResusarOrden(ordenOcupandoSlot, duracion, prioridad, comenzadaCallBack, terminadaCallBack);
				return;
			}
			InteractionEffectorControllerSlave.Orden orden = new InteractionEffectorControllerSlave.Orden(this.GetSystem(), interactionObject, tipoId, prioridad, duracion, priConfig, initialVelocidadInMod, velocidadInMod, velocidadOutMod, fijaPorAnimacion, puedeTrasladarse, puedeApoyarse, puedeApoyarseExt, comenzadaCallBack, terminadaCallBack);
			base.Procesar(ordenOcupandoSlot == null, librePorquePrioridadEsMayor, priConfig, orden, terminarDeInmediato, false);
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00029670 File Offset: 0x00027870
		public override FullBodyBipedEffector ParseIndexToTipoId(int index)
		{
			return (FullBodyBipedEffector)index;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00029673 File Offset: 0x00027873
		public override int ParseTipoIdToindex(FullBodyBipedEffector tipoId)
		{
			return (int)tipoId;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00029676 File Offset: 0x00027876
		protected override InteractionEffectorControllerSlave ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x040005A7 RID: 1447
		private int? m_cantidadDeEstados;

		// Token: 0x040005A8 RID: 1448
		private InteractionSystemV3 m_InteractionSystem;

		// Token: 0x040005A9 RID: 1449
		private AtadurasDePuppetController m_AtadurasDePuppetController;

		// Token: 0x040005AA RID: 1450
		[ReadOnlyUI]
		[SerializeField]
		private int m_InteractionSystemID;

		// Token: 0x040005AB RID: 1451
		[ReadOnlyUI]
		[SerializeField]
		private int m_InteractionSystemLayer;

		// Token: 0x040005AC RID: 1452
		[ReadOnlyUI]
		[SerializeField]
		private InteraccionController m_owner;

		// Token: 0x040005AD RID: 1453
		[ReadOnlyUI]
		[SerializeField]
		private bool m_puedeUsarAtadurasDePuppet;

		// Token: 0x040005AE RID: 1454
		private List<InteractionEffectorControllerSlave.Orden> m_TEmpInteractuarTodos1 = new List<InteractionEffectorControllerSlave.Orden>();

		// Token: 0x040005AF RID: 1455
		private List<bool> m_TEmpInteractuarTodos2 = new List<bool>();

		// Token: 0x040005B0 RID: 1456
		private List<InteraccionEstado.EstadoDeEffector> m_paresActivos = new List<InteraccionEstado.EstadoDeEffector>();

		// Token: 0x020001BF RID: 447
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<InteractionEffectorControllerSlave.Estado, InteractionEffectorControllerSlave.Orden, InteractionEffectorControllerSlave.Cola, InteractionEffectorControllerSlave, FullBodyBipedEffector>.OrdenBaseDeControllador, IInteractionOrden, IOrdenDeController
		{
			// Token: 0x06000CF4 RID: 3316 RVA: 0x00039674 File Offset: 0x00037874
			public Orden(InteractionSystem system, InteractionObjectV2Base interactionObject, FullBodyBipedEffector tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float initialVelocidadInMod, float velocidadInMod, float velocidadOutMod, bool fijaPorAnimacion, bool puedeTrasladarse, bool puedeApoyarse, bool puedeApoyarseExt, Action<InteractionEffectorControllerSlave.Orden> comenzadaCallBack, Action<InteractionEffectorControllerSlave.Orden> terminadaCallBack)
				: base(tipoId, prioridad, duracion, priConfig, comenzadaCallBack, terminadaCallBack)
			{
				if (interactionObject == null)
				{
					throw new ArgumentNullException("interactionObject", "interactionObject null reference.");
				}
				if (system == null)
				{
					throw new ArgumentNullException("system", "system null reference.");
				}
				this.m_initialVelocidadInMod = initialVelocidadInMod;
				this.m_velocidadInMod = velocidadInMod;
				this.m_velocidadOutMod = velocidadOutMod;
				this.m_system = system;
				this.m_interactionObject = interactionObject;
				this.fijaPorAnimacion = fijaPorAnimacion;
				this.puedeTrasladarse = puedeTrasladarse;
				this.puedeApoyarse = puedeApoyarse;
				this.puedeApoyarseExt = puedeApoyarseExt;
				this.m_effector = tipoId;
			}

			// Token: 0x17000279 RID: 633
			// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x00039732 File Offset: 0x00037932
			public FullBodyBipedEffector effector
			{
				get
				{
					return this.m_effector;
				}
			}

			// Token: 0x1700027A RID: 634
			// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x0003973A File Offset: 0x0003793A
			public InteractionObjectV2Base interactionObject
			{
				get
				{
					return this.m_interactionObject;
				}
			}

			// Token: 0x1700027B RID: 635
			// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x00039742 File Offset: 0x00037942
			public InteractionSystem system
			{
				get
				{
					return this.m_system;
				}
			}

			// Token: 0x1700027C RID: 636
			// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x0003974A File Offset: 0x0003794A
			// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x00039752 File Offset: 0x00037952
			public bool flagToStop
			{
				get
				{
					return this.m_flagToStop;
				}
				set
				{
					this.m_flagToStop = value;
				}
			}

			// Token: 0x1700027D RID: 637
			// (get) Token: 0x06000CFA RID: 3322 RVA: 0x0003975C File Offset: 0x0003795C
			public float timerWeigth
			{
				get
				{
					if (this.Termino())
					{
						return 0f;
					}
					if (!this.m_InteractionEffector.isPaused)
					{
						return MathfExtension.InverseLerpAlMedio(0f, this.m_interactionObject.firstPauseTime, this.m_interactionObject.length, this.m_InteractionEffector.tiempoEjecutandose);
					}
					return 1f;
				}
			}

			// Token: 0x1700027E RID: 638
			// (get) Token: 0x06000CFB RID: 3323 RVA: 0x000397B5 File Offset: 0x000379B5
			// (set) Token: 0x06000CFC RID: 3324 RVA: 0x000397BD File Offset: 0x000379BD
			bool IInteractionOrden.fijaPorAnimacion
			{
				get
				{
					return this.fijaPorAnimacion;
				}
				set
				{
					this.fijaPorAnimacion = value;
				}
			}

			// Token: 0x1700027F RID: 639
			// (get) Token: 0x06000CFD RID: 3325 RVA: 0x000397C6 File Offset: 0x000379C6
			// (set) Token: 0x06000CFE RID: 3326 RVA: 0x000397CE File Offset: 0x000379CE
			bool IInteractionOrden.puedeTrasladarse
			{
				get
				{
					return this.puedeTrasladarse;
				}
				set
				{
					this.puedeTrasladarse = value;
				}
			}

			// Token: 0x17000280 RID: 640
			// (get) Token: 0x06000CFF RID: 3327 RVA: 0x000397D7 File Offset: 0x000379D7
			// (set) Token: 0x06000D00 RID: 3328 RVA: 0x000397DF File Offset: 0x000379DF
			bool IInteractionOrden.puedeApoyarse
			{
				get
				{
					return this.puedeApoyarse;
				}
				set
				{
					this.puedeApoyarse = value;
				}
			}

			// Token: 0x17000281 RID: 641
			// (get) Token: 0x06000D01 RID: 3329 RVA: 0x000397E8 File Offset: 0x000379E8
			// (set) Token: 0x06000D02 RID: 3330 RVA: 0x000397F0 File Offset: 0x000379F0
			bool IInteractionOrden.puedeApoyarseExt
			{
				get
				{
					return this.puedeApoyarseExt;
				}
				set
				{
					this.puedeApoyarseExt = value;
				}
			}

			// Token: 0x06000D03 RID: 3331 RVA: 0x000397FC File Offset: 0x000379FC
			protected override void OnStart(InteractionEffectorControllerSlave dataUpdate)
			{
				this.m_interactionObject.speedInMod.moded = 1f;
				this.m_interactionObject.speedOutMod.moded = 1f;
				this.m_interactionObject.initialSpeedInMod.moded = this.m_initialVelocidadInMod;
				this.m_InteractionEffector = ((InteractionSystemV3)this.system).GetInteractionEffector(this.m_effector);
			}

			// Token: 0x06000D04 RID: 3332 RVA: 0x00039868 File Offset: 0x00037A68
			protected override bool UpdateOrden(InteractionEffectorControllerSlave dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino() || (!esPrimerUpdate && this.m_flagToStop))
				{
					this.m_flagToStop = false;
					return false;
				}
				if (!esPrimerUpdate)
				{
					this.m_interactionObject.speedInMod.moded = this.m_velocidadInMod;
					this.m_interactionObject.speedOutMod.moded = this.m_velocidadOutMod;
				}
				if (dataUpdate.m_owner.IsFijaPorAnimacionEnLayers(this.m_effector, (dataUpdate.m_InteractionSystemLayer + 1).IKLayerFromToLast(), false))
				{
					return false;
				}
				if (esPrimerUpdate)
				{
					this.system.StartInteraction(this.m_effector, this.m_interactionObject, true);
					return true;
				}
				base.DisminuirPrioridadAcumulativaDelta(0.333f);
				return this.Ejecutandose(dataUpdate);
			}

			// Token: 0x06000D05 RID: 3333 RVA: 0x00039913 File Offset: 0x00037B13
			public bool Ejecutandose(InteractionEffectorControllerSlave dataUpdate)
			{
				return dataUpdate.EjecutandoseEnInteractionSystem(this);
			}

			// Token: 0x06000D06 RID: 3334 RVA: 0x0003991C File Offset: 0x00037B1C
			protected override void OnDetenidaPorUsuario(InteractionEffectorControllerSlave dataUpdate)
			{
			}

			// Token: 0x06000D07 RID: 3335 RVA: 0x0003991E File Offset: 0x00037B1E
			protected override bool OnTerminando(InteractionEffectorControllerSlave dataUpdate, bool primerUpdate, InteractionEffectorControllerSlave.Orden ordenEsperandoDetencion)
			{
				return dataUpdate.TryStopOrden(this);
			}

			// Token: 0x06000D08 RID: 3336 RVA: 0x00039928 File Offset: 0x00037B28
			protected override void OnTerminada(InteractionEffectorControllerSlave dataUpdate, bool abruptamente)
			{
				dataUpdate.TryStopOrden(this);
				this.m_interactionObject.speedInMod.moded = 1f;
				this.m_interactionObject.speedOutMod.moded = 1f;
				this.m_interactionObject.SetDefaultSpeedIfNotInteracting();
				if (abruptamente)
				{
					dataUpdate.m_InteractionSystem.StopInmediatamente(this.effector);
				}
				this.m_flagToStop = false;
				this.m_interactionObject = null;
				this.m_system = null;
			}

			// Token: 0x06000D09 RID: 3337 RVA: 0x0003999B File Offset: 0x00037B9B
			public override bool Termino()
			{
				return base.Termino() || this.m_interactionObject == null || this.system == null;
			}

			// Token: 0x040009BD RID: 2493
			[ReadOnlyUI]
			[SerializeField]
			private InteractionSystem m_system;

			// Token: 0x040009BE RID: 2494
			[ReadOnlyUI]
			[SerializeField]
			private InteractionObjectV2Base m_interactionObject;

			// Token: 0x040009BF RID: 2495
			[ReadOnlyUI]
			[SerializeField]
			private InteractionEffectorV2 m_InteractionEffector;

			// Token: 0x040009C0 RID: 2496
			[ReadOnlyUI]
			[SerializeField]
			private FullBodyBipedEffector m_effector;

			// Token: 0x040009C1 RID: 2497
			[SerializeField]
			private bool m_flagToStop;

			// Token: 0x040009C2 RID: 2498
			public bool fijaPorAnimacion;

			// Token: 0x040009C3 RID: 2499
			public bool puedeTrasladarse;

			// Token: 0x040009C4 RID: 2500
			public bool puedeApoyarse;

			// Token: 0x040009C5 RID: 2501
			public bool puedeApoyarseExt;

			// Token: 0x040009C6 RID: 2502
			[ReadOnlyUI]
			[SerializeField]
			private float m_initialVelocidadInMod = 1f;

			// Token: 0x040009C7 RID: 2503
			[ReadOnlyUI]
			[SerializeField]
			private float m_velocidadInMod = 1f;

			// Token: 0x040009C8 RID: 2504
			[ReadOnlyUI]
			[SerializeField]
			private float m_velocidadOutMod = 1f;
		}

		// Token: 0x020001C0 RID: 448
		public sealed class Estado : ControllerColaDePrioridadBase<InteractionEffectorControllerSlave.Estado, InteractionEffectorControllerSlave.Orden, InteractionEffectorControllerSlave.Cola, InteractionEffectorControllerSlave, FullBodyBipedEffector>.StadoBase
		{
		}

		// Token: 0x020001C1 RID: 449
		public sealed class Cola : ControllerColaDePrioridadBase<InteractionEffectorControllerSlave.Estado, InteractionEffectorControllerSlave.Orden, InteractionEffectorControllerSlave.Cola, InteractionEffectorControllerSlave, FullBodyBipedEffector>.ColasBase
		{
		}
	}
}
