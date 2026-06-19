using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts
{
	// Token: 0x0200000A RID: 10
	public abstract class ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> : AplicableBehaviour, IControllerColaDePrioridad where T_estado : ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.StadoBase, new() where T_orden : ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.OrdenBaseDeControllador where T_cola : ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.ColasBase, new()
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002757 File Offset: 0x00000957
		[Obsolete("remplazado con updateTypeAutomatico", true)]
		protected GlobalUpdater.UpdateType updateType
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002760 File Offset: 0x00000960
		protected virtual GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002776 File Offset: 0x00000976
		public virtual int cantidadMaximaEnCola
		{
			get
			{
				return 10;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003A RID: 58
		protected abstract int cantidadDeEstados { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000277C File Offset: 0x0000097C
		public sealed override int updateEvent1Index
		{
			get
			{
				if (this.updateTypeAutomatico != null)
				{
					return (int)this.updateTypeAutomatico.Value;
				}
				return -1;
			}
		}

		// Token: 0x17000012 RID: 18
		public T_ordenTypoId this[int i]
		{
			get
			{
				return this.ParseIndexToTipoId(i);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000027B2 File Offset: 0x000009B2
		public int CountDeTipos
		{
			get
			{
				return this.cantidadDeEstados;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000027BA File Offset: 0x000009BA
		public T_estado currentStado
		{
			get
			{
				return this.m_currentStado;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000027C2 File Offset: 0x000009C2
		public T_cola currentCola
		{
			get
			{
				return this.m_cola;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000027CA File Offset: 0x000009CA
		public T_orden justProcesedOrder
		{
			get
			{
				return this.m_justProcesedOrder;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000027D4 File Offset: 0x000009D4
		protected override void AwakeUnityEvent()
		{
			this.debugVerOrdenes = this.debugVerOrdenes && Application.isEditor;
			base.AwakeUnityEvent();
			this.m_currentStado.Init(this, this.cantidadDeEstados);
			this.m_cola.Init(this, this.cantidadDeEstados);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000282B File Offset: 0x00000A2B
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_currentStado.ForzarDetenerOrdenes();
		}

		// Token: 0x06000043 RID: 67
		public abstract T_ordenTypoId ParseIndexToTipoId(int index);

		// Token: 0x06000044 RID: 68
		public abstract int ParseTipoIdToindex(T_ordenTypoId tipoId);

		// Token: 0x06000045 RID: 69
		protected abstract T_updateData ObtenerUpdateData();

		// Token: 0x06000046 RID: 70 RVA: 0x00002844 File Offset: 0x00000A44
		public sealed override void OnUpdateEvent1()
		{
			if (this.updateTypeAutomatico == null)
			{
				throw new InvalidOperationException();
			}
			this.DoUpdate(GlobalUpdater.instancia.isFixedUpdate);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002877 File Offset: 0x00000A77
		public bool OrdenEstaTerminando(IOrdenDeController orden)
		{
			return this.m_currentStado.OrdenEstaTerminando(orden);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000288A File Offset: 0x00000A8A
		public bool TryDetenerOrden(IOrdenDeController orden)
		{
			return this.m_currentStado.TryDetenerOrden(orden);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000289D File Offset: 0x00000A9D
		public bool AlgunaOrndeEjecutandose()
		{
			return this.m_currentStado.AlgunaEjecutandose();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000028AF File Offset: 0x00000AAF
		public bool AlgunaOrndeDeteniendose()
		{
			return this.m_currentStado.ExisteAlgunaOrdenDeteniendose();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000028C4 File Offset: 0x00000AC4
		protected void ActualizarControlladorManualmente(bool isFixedStep)
		{
			if (this.updateTypeAutomatico != null)
			{
				throw new InvalidOperationException("la actualizacion del cotrollador " + base.name + "es automatica");
			}
			this.DoUpdate(isFixedStep);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002904 File Offset: 0x00000B04
		public bool VerificarSiPuedeEjecutarse(out T_orden ordenOcupandoSlot, out bool librePorquePrioridadEsMayor, T_ordenTypoId tipoId, int prioridad, ControllerPrioridadConfig priConfig, out bool entraraACola, ref bool puedePonerEnCola, bool inclusive = false)
		{
			ordenOcupandoSlot = default(T_orden);
			librePorquePrioridadEsMayor = false;
			entraraACola = false;
			if (this.OrdenAnuladaPorPrioridadBaja(priConfig, tipoId))
			{
				return false;
			}
			if (!this.EstaOcupadoV2(priConfig, prioridad, tipoId, inclusive, out ordenOcupandoSlot, out librePorquePrioridadEsMayor))
			{
				return true;
			}
			if (this.EntraraACola(ordenOcupandoSlot, librePorquePrioridadEsMayor, priConfig))
			{
				if (!puedePonerEnCola)
				{
					return false;
				}
				puedePonerEnCola = this.PuedePonerEnCola(tipoId);
				if (!puedePonerEnCola)
				{
					return false;
				}
				entraraACola = true;
			}
			return true;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000296E File Offset: 0x00000B6E
		protected bool EntraraACola(T_orden ordenOcupandoSlot, bool librePorquePrioridadEsMayor, ControllerPrioridadConfig priConfig)
		{
			return priConfig != ControllerPrioridadConfig.interrumpir && ordenOcupandoSlot != null && !librePorquePrioridadEsMayor;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002984 File Offset: 0x00000B84
		protected bool PuedeAcumularseORevivir(T_orden ordenOcupandoSlot, out T_orden ordenAReusar, ControllerPrioridadConfig priConfig, T_ordenTypoId tipoId, out ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden)
		{
			if (ordenOcupandoSlot == null)
			{
				T_orden t_orden;
				if (this.currentStado.ExisteOrdenDeteniendoseRevivible(tipoId, out t_orden) && this.PuedeReusarse(t_orden, priConfig, tipoId))
				{
					ordenAReusar = t_orden;
					tipoDeReUsoDeOrden = ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden.revivida;
					return true;
				}
			}
			else if (this.PuedeAcumularse(ordenOcupandoSlot, priConfig, tipoId))
			{
				ordenAReusar = ordenOcupandoSlot;
				tipoDeReUsoDeOrden = ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden.actualizada;
				return true;
			}
			ordenAReusar = default(T_orden);
			tipoDeReUsoDeOrden = ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden.actualizada;
			return false;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000029F0 File Offset: 0x00000BF0
		protected void AcumularseORevivir(T_orden ordenAReusar, float duracion, int prioridad, ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden, Action<T_orden> comenzadaCallBack = null, Action<T_orden> terminadaCallBack = null)
		{
			if (ordenAReusar == null)
			{
				throw new ArgumentNullException("ordenAReusar", "ordenAReusar null reference.");
			}
			if (tipoDeReUsoDeOrden == ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden.revivida && !this.currentStado.TryRevivirOrden(ordenAReusar))
			{
				throw new NotSupportedException("Orden no se puedo revivir");
			}
			this.ResusarOrden(ordenAReusar, duracion, prioridad, comenzadaCallBack, terminadaCallBack);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002A48 File Offset: 0x00000C48
		protected bool PuedeAcumularse(T_orden ordenOcupandoSlot, ControllerPrioridadConfig priConfig, T_ordenTypoId tipoId)
		{
			return ordenOcupandoSlot != null && this.ParseTipoIdToindex(ordenOcupandoSlot.tipoId) == this.ParseTipoIdToindex(tipoId) && !ordenOcupandoSlot.Termino() && priConfig == ordenOcupandoSlot.priConfig;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002A98 File Offset: 0x00000C98
		protected bool PuedeReusarse(T_orden ordenDeteniendose, ControllerPrioridadConfig priConfig, T_ordenTypoId tipoId)
		{
			return ordenDeteniendose != null && this.ParseTipoIdToindex(ordenDeteniendose.tipoId) == this.ParseTipoIdToindex(tipoId) && ordenDeteniendose.stared && priConfig == ordenDeteniendose.priConfig;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002AE8 File Offset: 0x00000CE8
		protected void AñadirDuracionAOrden(T_orden ordenOcupandoSlot, float duracion)
		{
			try
			{
				if (ordenOcupandoSlot != null)
				{
					if (!ordenOcupandoSlot.permanente)
					{
						if (duracion >= 0f)
						{
							if (!ordenOcupandoSlot.stared)
							{
								ordenOcupandoSlot.AñadirTiempo(Mathf.Max(duracion - ordenOcupandoSlot.duracion, 0.0001f), false);
							}
							else
							{
								ordenOcupandoSlot.AñadirTiempo(Mathf.Max(duracion - ordenOcupandoSlot.tiempoRestante, 0.0001f), false);
							}
						}
						else
						{
							ordenOcupandoSlot.AñadirTiempo(float.MinValue, false);
						}
					}
					else if (duracion >= 0f)
					{
						ordenOcupandoSlot.AñadirTiempo(duracion, false);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Error añadiendo tiempo", this);
				Debug.LogException(ex, this);
				throw ex;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002BBC File Offset: 0x00000DBC
		protected void ResusarOrden(T_orden ordenOcupandoSlot, float duracionToAdd, int prioridad, Action<T_orden> comenzadaCallBack = null, Action<T_orden> terminadaCallBack = null)
		{
			try
			{
				ordenOcupandoSlot.SetPrioridad(prioridad);
				this.AñadirDuracionAOrden(ordenOcupandoSlot, duracionToAdd);
				if (ordenOcupandoSlot.stared)
				{
					ordenOcupandoSlot.WasReused();
				}
				ordenOcupandoSlot.SetCallBacks(comenzadaCallBack, terminadaCallBack);
				this.m_justProcesedOrder = ordenOcupandoSlot;
			}
			catch (Exception ex)
			{
				Debug.LogError("Error añadiendo tiempo", this);
				Debug.LogException(ex, this);
				throw ex;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002C30 File Offset: 0x00000E30
		[Obsolete("dividido en dos", true)]
		protected void AñadirTiempoAOrdenEjecutandose(T_orden ordenOcupandoSlot, float duracion, Action<T_orden> comenzadaCallBack = null, Action<T_orden> terminadaCallBack = null)
		{
			try
			{
				if (ordenOcupandoSlot != null)
				{
					if (!ordenOcupandoSlot.permanente)
					{
						if (duracion >= 0f)
						{
							if (!ordenOcupandoSlot.stared)
							{
								ordenOcupandoSlot.AñadirTiempo(Mathf.Max(duracion - ordenOcupandoSlot.duracion, 0.0001f), false);
							}
							else
							{
								ordenOcupandoSlot.AñadirTiempo(Mathf.Max(duracion - ordenOcupandoSlot.tiempoRestante, 0.0001f), false);
							}
						}
						else
						{
							ordenOcupandoSlot.AñadirTiempo(float.MinValue, false);
						}
					}
					else if (duracion >= 0f)
					{
						ordenOcupandoSlot.AñadirTiempo(duracion, false);
					}
					ordenOcupandoSlot.WasReused();
					ordenOcupandoSlot.SetCallBacks(comenzadaCallBack, terminadaCallBack);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Error añadiendo tiempo", this);
				Debug.LogException(ex, this);
				throw ex;
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002D1C File Offset: 0x00000F1C
		public bool DetenerOrdenDeTipo(T_ordenTypoId tipoId)
		{
			return this.m_currentStado.DetenerOrdenEnSlot(tipoId);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002D30 File Offset: 0x00000F30
		private void DoUpdate(bool isFixedStep)
		{
			this.m_justProcesedOrder = default(T_orden);
			if (!this.m_puedeActualizarse)
			{
				return;
			}
			this.ControllerUpdating();
			T_updateData t_updateData = this.ObtenerUpdateData();
			this.m_cola.Update(t_updateData, this.m_currentStado);
			this.enColaDeteniendo = this.m_currentStado.UpdateTerminandoOrndenes(t_updateData);
			this.m_currentStado.UpdateDeltaTime(isFixedStep);
			this.m_currentStado.Update(t_updateData, false, (this.debugVerOrdenes && Application.isEditor) ? this.m_debugOrdenes : null);
			this.enCola = this.m_cola.Update(t_updateData, this.m_currentStado);
			this.ControllerUpdated();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002DEC File Offset: 0x00000FEC
		protected virtual void ControllerUpdating()
		{
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002DEE File Offset: 0x00000FEE
		protected virtual void ControllerUpdated()
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002DF0 File Offset: 0x00000FF0
		public ControllerPrioridadConfig TipoDePrioridadDeTipoDeOrden(T_ordenTypoId tipo)
		{
			T_orden t_orden;
			if (this.TipoDeOrdenEstaLibre(tipo, out t_orden))
			{
				return ControllerPrioridadConfig.none;
			}
			return t_orden.priConfig;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002E18 File Offset: 0x00001018
		public bool TipoDeOrdenEstaLibrePrioridad(T_ordenTypoId tipo, int prioridad, bool inclusive, out T_orden orden, out bool librePorPrioridad)
		{
			if (prioridad < 0)
			{
				inclusive = true;
			}
			T_orden t_orden;
			if (this.TipoDeOrdenEstaLibre(tipo, out t_orden))
			{
				orden = default(T_orden);
				librePorPrioridad = false;
				return true;
			}
			librePorPrioridad = false;
			orden = t_orden;
			if (inclusive)
			{
				if (orden.prioridad <= prioridad)
				{
					librePorPrioridad = true;
					return true;
				}
			}
			else if (orden.prioridad < prioridad)
			{
				librePorPrioridad = true;
				return true;
			}
			return false;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002E84 File Offset: 0x00001084
		public bool TipoDeOrdenEstaLibrePrioridad(T_ordenTypoId tipo, int prioridad, bool inclusive)
		{
			T_orden t_orden;
			bool flag;
			return this.TipoDeOrdenEstaLibrePrioridad(tipo, prioridad, inclusive, out t_orden, out flag);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002EA0 File Offset: 0x000010A0
		public bool TipoDeOrdenEstaLibrePrioridad(T_ordenTypoId tipo, int prioridad, bool inclusive, out bool librePorPrioridad)
		{
			T_orden t_orden;
			return this.TipoDeOrdenEstaLibrePrioridad(tipo, prioridad, inclusive, out t_orden, out librePorPrioridad);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002EBC File Offset: 0x000010BC
		public bool TipoDeOrdenEstaLibre(T_ordenTypoId tipo)
		{
			T_orden t_orden;
			return this.TipoDeOrdenEstaLibre(tipo, out t_orden);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002ED4 File Offset: 0x000010D4
		public bool TipoDeOrdenFueInterrumpida(T_ordenTypoId tipo, out T_orden orden)
		{
			int num = this.ParseTipoIdToindex(tipo);
			orden = this.m_currentStado[num];
			return orden != null && !orden.Termino() && orden.priConfig == ControllerPrioridadConfig.interrumpir;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002F2C File Offset: 0x0000112C
		public bool TipoDeOrdenFueInterrumpida(T_ordenTypoId tipo)
		{
			T_orden t_orden;
			return this.TipoDeOrdenFueInterrumpida(tipo, out t_orden);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002F44 File Offset: 0x00001144
		public bool TipoDeOrdenEstaLibre(T_ordenTypoId tipo, out T_orden orden)
		{
			int num = this.ParseTipoIdToindex(tipo);
			orden = this.m_currentStado[num];
			return orden == null || orden.Termino();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002F8B File Offset: 0x0000118B
		protected bool OrdenAnuladaPorPrioridadBaja(ControllerPrioridadConfig prio, T_ordenTypoId tipo)
		{
			return prio == ControllerPrioridadConfig.baja && !this.TipoDeOrdenEstaLibre(tipo);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002F9D File Offset: 0x0000119D
		protected bool OrdenAnuladaPorPrioridadBaja(ControllerPrioridadConfig prio, T_ordenTypoId tipo, out T_orden ocupando)
		{
			ocupando = default(T_orden);
			return prio == ControllerPrioridadConfig.baja && !this.TipoDeOrdenEstaLibre(tipo, out ocupando);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002FB8 File Offset: 0x000011B8
		protected bool EstaOcupadoV2(ControllerPrioridadConfig prio, int prioridad, T_ordenTypoId tipo, bool inclusive, out T_orden ocupando, out bool librePorquePrioridadEsMayor)
		{
			bool flag = !this.TipoDeOrdenEstaLibrePrioridad(tipo, prioridad, inclusive, out ocupando, out librePorquePrioridadEsMayor);
			if (prio == ControllerPrioridadConfig.interrumpir)
			{
				if (ocupando != null)
				{
					librePorquePrioridadEsMayor = false;
				}
				return false;
			}
			return flag;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002FF0 File Offset: 0x000011F0
		protected bool OrdenAnuladaPorPrioridadMenor(ControllerPrioridadConfig prio, int prioridad, T_ordenTypoId tipo, bool inclusive, out T_orden ocupando, out bool librePorPrioridad)
		{
			ocupando = default(T_orden);
			librePorPrioridad = false;
			return prio == ControllerPrioridadConfig.prioridad && !this.TipoDeOrdenEstaLibrePrioridad(tipo, prioridad, inclusive, out ocupando, out librePorPrioridad);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003018 File Offset: 0x00001218
		protected bool PuedePonerEnCola(T_ordenTypoId typoId)
		{
			int num = this.ParseTipoIdToindex(typoId);
			return this.m_cola.colas[num].Count < this.cantidadMaximaEnCola;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000304C File Offset: 0x0000124C
		protected void Procesar(bool libre, bool librePorPrioridad, ControllerPrioridadConfig priConfig, T_orden o, bool interrumpirOrdenAbrutamente, bool debugLog = false)
		{
			if (o == null)
			{
				throw new ArgumentNullException("o", "o null reference.");
			}
			if (libre || librePorPrioridad || priConfig == ControllerPrioridadConfig.interrumpir)
			{
				this.Inyectar(o, interrumpirOrdenAbrutamente);
				if (debugLog)
				{
					string text = "Orden de tipo: ";
					T_ordenTypoId t_ordenTypoId = o.tipoId;
					Debug.Log(text + t_ordenTypoId.ToString() + " fue Forzada.");
				}
			}
			else
			{
				this.Enqueue(o);
				if (debugLog)
				{
					string text2 = "Orden de tipo: ";
					T_ordenTypoId t_ordenTypoId = o.tipoId;
					Debug.Log(text2 + t_ordenTypoId.ToString() + " fue Enqueue.");
				}
			}
			this.m_justProcesedOrder = o;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000030FB File Offset: 0x000012FB
		protected virtual void OnOrderBeforePrimerUpdate(T_orden orden)
		{
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000030FD File Offset: 0x000012FD
		public void ForzarDetenerOrdenes()
		{
			this.m_currentStado.ForzarDetenerOrdenes();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000310F File Offset: 0x0000130F
		public void DetenerOrdenes()
		{
			this.m_currentStado.DetenerOrdenes();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003124 File Offset: 0x00001324
		public void Enqueue(T_orden nuevaOrden)
		{
			nuevaOrden.SetController(this);
			int num = this.ParseTipoIdToindex(nuevaOrden.tipoId);
			Queue<T_orden> queue = this.m_cola.colas[num];
			if (queue.Count >= this.cantidadMaximaEnCola)
			{
				throw new InvalidOperationException("muchos objetos en cola en " + base.name + ", limite es " + this.cantidadMaximaEnCola.ToString());
			}
			queue.Enqueue(nuevaOrden);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000319E File Offset: 0x0000139E
		public void Inyectar(T_orden nuevaOrden, bool interrumpirOrdenAbrutamente)
		{
			nuevaOrden.SetController(this);
			this.m_currentStado.InyectarOrden(nuevaOrden, interrumpirOrdenAbrutamente);
		}

		// Token: 0x04000012 RID: 18
		public bool debugVerOrdenes;

		// Token: 0x04000013 RID: 19
		[SerializeField]
		private List<T_orden> m_debugOrdenes = new List<T_orden>();

		// Token: 0x04000014 RID: 20
		[SerializeField]
		[ReadOnlyUI]
		protected bool m_puedeActualizarse = true;

		// Token: 0x04000015 RID: 21
		[ReadOnlyUI]
		public int enCola;

		// Token: 0x04000016 RID: 22
		[ReadOnlyUI]
		public int enColaDeteniendo;

		// Token: 0x04000017 RID: 23
		private T_estado m_currentStado = new T_estado();

		// Token: 0x04000018 RID: 24
		private T_cola m_cola = new T_cola();

		// Token: 0x04000019 RID: 25
		private T_orden m_justProcesedOrder;

		// Token: 0x02000021 RID: 33
		public class ColasBase
		{
			// Token: 0x060000E1 RID: 225 RVA: 0x0000402C File Offset: 0x0000222C
			public void Init(ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> parent, int cantidadDeEstados)
			{
				this.m_parent = parent;
				this.m_colas = new Queue<T_orden>[cantidadDeEstados];
				for (int i = 0; i < this.m_colas.Length; i++)
				{
					this.m_colas[i] = new Queue<T_orden>();
				}
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x060000E2 RID: 226 RVA: 0x0000406C File Offset: 0x0000226C
			public Queue<T_orden>[] colas
			{
				get
				{
					return this.m_colas;
				}
			}

			// Token: 0x060000E3 RID: 227 RVA: 0x00004074 File Offset: 0x00002274
			public bool RemoverTodas()
			{
				bool flag = false;
				for (int i = 0; i < this.m_colas.Length; i++)
				{
					Queue<T_orden> queue = this.m_colas[i];
					if (queue != null && queue.Count > 0)
					{
						foreach (T_orden t_orden in queue)
						{
							T_orden t_orden2 = t_orden;
							if (t_orden2 != null)
							{
								t_orden2.OnOrdenCancelada();
							}
						}
						flag = true;
						queue.Clear();
					}
				}
				return flag;
			}

			// Token: 0x060000E4 RID: 228 RVA: 0x00004100 File Offset: 0x00002300
			public T_orden Peek(int index)
			{
				if (!this.m_colas.ContieneIndex(index))
				{
					return default(T_orden);
				}
				Queue<T_orden> queue = this.m_colas[index];
				if (queue.Count == 0)
				{
					return default(T_orden);
				}
				return queue.Peek();
			}

			// Token: 0x060000E5 RID: 229 RVA: 0x00004148 File Offset: 0x00002348
			public int Update(T_updateData dataUpdate, T_estado currentStado)
			{
				int num = 0;
				for (int i = 0; i < this.m_colas.Length; i++)
				{
					Queue<T_orden> queue = this.m_colas[i];
					if (queue != null && queue.Count > 0)
					{
						if (queue.Count >= 100)
						{
							string[] array = new string[6];
							array[0] = "Cola en controllador ";
							array[1] = this.m_parent.name;
							array[2] = " de tipo: ";
							int num2 = 3;
							T_ordenTypoId t_ordenTypoId = this.m_parent.ParseIndexToTipoId(i);
							array[num2] = t_ordenTypoId.ToString();
							array[4] = " es anormalmente alto: ";
							array[5] = this.m_colas.Length.ToString();
							Debug.LogWarning(string.Concat(array), this.m_parent);
						}
						if (currentStado.SlotIsFree(i))
						{
							currentStado.SetSlot(queue.Dequeue());
						}
					}
					num += queue.Count;
				}
				return num;
			}

			// Token: 0x060000E6 RID: 230 RVA: 0x0000422C File Offset: 0x0000242C
			public bool TryRemove(T_orden orden)
			{
				int num = this.m_parent.ParseTipoIdToindex(orden.tipoId);
				Queue<T_orden> queue = this.m_colas[num];
				if (queue.Contains(orden))
				{
					queue = new Queue<T_orden>(queue.Where((T_orden s) => s != orden));
					this.m_colas[num] = queue;
					T_orden t_orden = orden;
					if (t_orden != null)
					{
						t_orden.OnOrdenCancelada();
					}
					return true;
				}
				return false;
			}

			// Token: 0x04000083 RID: 131
			private ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> m_parent;

			// Token: 0x04000084 RID: 132
			private Queue<T_orden>[] m_colas;
		}

		// Token: 0x02000022 RID: 34
		public class StadoBase
		{
			// Token: 0x060000E8 RID: 232 RVA: 0x000042BB File Offset: 0x000024BB
			public void Init(ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> parent, int cantidadDeEstados)
			{
				this.m_parent = parent;
				this.m_ordenes = new T_orden[cantidadDeEstados];
				this.m_ultimasOrdenes = new T_orden[cantidadDeEstados];
				this.m_ordenesDeteniendose = new List<T_orden>[cantidadDeEstados];
			}

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x060000E9 RID: 233 RVA: 0x000042E8 File Offset: 0x000024E8
			public IReadOnlyList<T_orden> ordenes
			{
				get
				{
					return this.m_ordenes;
				}
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x060000EA RID: 234 RVA: 0x000042F0 File Offset: 0x000024F0
			public float selfDeltaTime
			{
				get
				{
					return this.m_deltaTime;
				}
			}

			// Token: 0x060000EB RID: 235 RVA: 0x000042F8 File Offset: 0x000024F8
			public bool OrdenEstaTerminando(IOrdenDeController orden)
			{
				if (!orden.Termino())
				{
					return false;
				}
				List<T_orden> list = this.m_ordenesDeteniendose[orden.tipoId];
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] == orden)
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x060000EC RID: 236 RVA: 0x00004340 File Offset: 0x00002540
			public bool TryDetenerOrden(IOrdenDeController orden)
			{
				T_orden t_orden = orden as T_orden;
				if (t_orden == null)
				{
					return false;
				}
				if (this.m_ordenes[orden.tipoId] != orden)
				{
					return false;
				}
				this.Detener(orden.tipoId, t_orden, true, false);
				return true;
			}

			// Token: 0x060000ED RID: 237 RVA: 0x00004390 File Offset: 0x00002590
			public void ObtenerOrdenesDeteniendose(T_ordenTypoId tipoId, List<T_orden> resultado)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				resultado.AddRange(this.m_ordenesDeteniendose[num]);
			}

			// Token: 0x060000EE RID: 238 RVA: 0x000043B8 File Offset: 0x000025B8
			public T_orden ObtenerLastOrdenesDeteniendose(T_ordenTypoId tipoId)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				List<T_orden> list = this.m_ordenesDeteniendose[num];
				if (list == null || list.Count == 0)
				{
					return default(T_orden);
				}
				return list[0];
			}

			// Token: 0x060000EF RID: 239 RVA: 0x000043F8 File Offset: 0x000025F8
			public IReadOnlyList<T_orden> ObtenerOrdenesDeteniendose(T_ordenTypoId tipoId)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				return this.m_ordenesDeteniendose[num];
			}

			// Token: 0x060000F0 RID: 240 RVA: 0x0000441C File Offset: 0x0000261C
			internal List<T_orden> obtenerOrdenesDeteniendose(T_ordenTypoId tipoId)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				return this.m_ordenesDeteniendose[num];
			}

			// Token: 0x060000F1 RID: 241 RVA: 0x00004440 File Offset: 0x00002640
			public bool ExisteAlgunaOrdenDeteniendose()
			{
				for (int i = 0; i < this.m_ordenes.Length; i++)
				{
					T_orden t_orden;
					if (this.ExisteOrdenDeteniendose(this.m_parent.ParseIndexToTipoId(i), out t_orden))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x060000F2 RID: 242 RVA: 0x0000447C File Offset: 0x0000267C
			public bool ExisteOrdenDeteniendose(T_ordenTypoId tipoId, out T_orden deteniendose)
			{
				deteniendose = default(T_orden);
				List<T_orden> list = this.obtenerOrdenesDeteniendose(tipoId);
				if (list == null || list.Count == 0)
				{
					return false;
				}
				deteniendose = list[0];
				return deteniendose != null;
			}

			// Token: 0x060000F3 RID: 243 RVA: 0x000044C4 File Offset: 0x000026C4
			public bool ExisteOrdenDeteniendoseRevivible(T_ordenTypoId tipoId, out T_orden deteniendose)
			{
				deteniendose = default(T_orden);
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				if (this.m_ordenes[num] != null)
				{
					return false;
				}
				List<T_orden> list = this.obtenerOrdenesDeteniendose(tipoId);
				if (list == null || list.Count == 0)
				{
					return false;
				}
				deteniendose = list[0];
				return deteniendose != null && !deteniendose.finalizada && !deteniendose.cancelada;
			}

			// Token: 0x060000F4 RID: 244 RVA: 0x00004548 File Offset: 0x00002748
			public bool TryRevivirOrden(T_orden revivida)
			{
				if (revivida == null || revivida.finalizada || revivida.cancelada)
				{
					return false;
				}
				int num = this.m_parent.ParseTipoIdToindex(revivida.tipoId);
				if (this.m_ordenes[num] != null)
				{
					return false;
				}
				List<T_orden> list = this.obtenerOrdenesDeteniendose(revivida.tipoId);
				if (list == null || list.Count == 0 || !list.Contains(revivida))
				{
					return false;
				}
				list.Remove(revivida);
				this.m_ordenes[num] = revivida;
				return true;
			}

			// Token: 0x060000F5 RID: 245 RVA: 0x000045E4 File Offset: 0x000027E4
			public bool TryDejarDeDetenerPrimerOrden(T_ordenTypoId tipoId, out T_orden revivida)
			{
				revivida = default(T_orden);
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				if (this.m_ordenes[num] != null)
				{
					return false;
				}
				List<T_orden> list = this.obtenerOrdenesDeteniendose(tipoId);
				if (list == null || list.Count == 0)
				{
					return false;
				}
				revivida = list[0];
				list.Remove(revivida);
				this.m_ordenes[num] = revivida;
				return true;
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000465C File Offset: 0x0000285C
			public int Count
			{
				get
				{
					return this.m_ordenes.Length;
				}
			}

			// Token: 0x17000029 RID: 41
			public T_orden this[int i]
			{
				get
				{
					if (i < 0 || i + 1 > this.m_ordenes.Length)
					{
						return default(T_orden);
					}
					return this.m_ordenes[i];
				}
			}

			// Token: 0x1700002A RID: 42
			public T_orden this[T_ordenTypoId i]
			{
				get
				{
					int num = this.m_parent.ParseTipoIdToindex(i);
					return this[num];
				}
			}

			// Token: 0x060000F9 RID: 249 RVA: 0x000046C0 File Offset: 0x000028C0
			public T_orden GetLastOrdenOf(T_ordenTypoId tipoId, bool clean = true)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				T_orden t_orden = this.m_ultimasOrdenes[num];
				if (clean)
				{
					this.m_ultimasOrdenes[num] = default(T_orden);
				}
				return t_orden;
			}

			// Token: 0x060000FA RID: 250 RVA: 0x00004700 File Offset: 0x00002900
			public bool AlgunaEjecutandose()
			{
				for (int i = 0; i < this.m_ordenes.Length; i++)
				{
					T_orden t_orden = this.m_ordenes[i];
					if (t_orden != null && !t_orden.Termino() && t_orden.stared)
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x060000FB RID: 251 RVA: 0x00004754 File Offset: 0x00002954
			public bool Ejecutandose(T_ordenTypoId tipoId)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				T_orden t_orden = this.m_ordenes[num];
				return t_orden != null && !t_orden.Termino() && t_orden.stared;
			}

			// Token: 0x060000FC RID: 252 RVA: 0x000047A0 File Offset: 0x000029A0
			public bool Ejecutandose(T_ordenTypoId tipoId, out T_orden orden)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				orden = this.m_ordenes[num];
				return orden != null && !orden.Termino() && orden.stared;
			}

			// Token: 0x060000FD RID: 253 RVA: 0x000047F8 File Offset: 0x000029F8
			public T_orden FirstOrDefaultEjecutandose()
			{
				for (int i = 0; i < this.m_ordenes.Length; i++)
				{
					T_orden t_orden = this.m_ordenes[i];
					if (t_orden != null && !t_orden.Termino() && t_orden.stared)
					{
						return t_orden;
					}
				}
				return default(T_orden);
			}

			// Token: 0x060000FE RID: 254 RVA: 0x00004854 File Offset: 0x00002A54
			public void EjecutarEnEjecutandose(Action<T_orden> accion)
			{
				for (int i = 0; i < this.m_ordenes.Length; i++)
				{
					T_orden t_orden = this.m_ordenes[i];
					if (t_orden != null && !t_orden.Termino() && t_orden.stared)
					{
						accion(t_orden);
					}
				}
			}

			// Token: 0x060000FF RID: 255 RVA: 0x000048AC File Offset: 0x00002AAC
			public void UpdateDeltaTime(bool isFixedStep)
			{
				if (isFixedStep)
				{
					this.m_deltaTime = Time.fixedDeltaTime;
				}
				else
				{
					this.m_deltaTime = Mathf.Clamp(Time.time - this.m_lastTimeUpdated, 1E-06f, float.MaxValue);
				}
				this.m_lastFrame = Time.frameCount;
				this.m_lastTimeUpdated = Time.time;
			}

			// Token: 0x06000100 RID: 256 RVA: 0x00004900 File Offset: 0x00002B00
			public void Update(T_updateData dataUpdate, bool segundario, List<T_orden> ordenesActuales = null)
			{
				if (ordenesActuales != null && ordenesActuales.Count > 0)
				{
					ordenesActuales.Clear();
				}
				for (int i = 0; i < this.m_ordenes.Length; i++)
				{
					T_orden t_orden = this.m_ordenes[i];
					if (t_orden != null)
					{
						bool flag;
						if (!segundario)
						{
							flag = !this.UpdateOrden(t_orden, i, dataUpdate);
						}
						else
						{
							if (!t_orden.stared)
							{
								goto IL_0070;
							}
							flag = !this.UpdateOrden2(t_orden, i, dataUpdate);
						}
						if (flag)
						{
							this.Detener(i, t_orden, false, false);
						}
						else if (ordenesActuales != null)
						{
							ordenesActuales.Add(t_orden);
						}
					}
					IL_0070:;
				}
			}

			// Token: 0x06000101 RID: 257 RVA: 0x0000498C File Offset: 0x00002B8C
			public int UpdateTerminandoOrndenes(T_updateData dataUpdate)
			{
				int num = 0;
				for (int i = 0; i < this.m_ordenesDeteniendose.Length; i++)
				{
					List<T_orden> list = this.m_ordenesDeteniendose[i];
					if (list != null && list.Count >= 100)
					{
						string[] array = new string[6];
						array[0] = "Ordenes Deteniendose en controllador ";
						array[1] = this.m_parent.name;
						array[2] = " de tipo: ";
						int num2 = 3;
						T_ordenTypoId t_ordenTypoId = this.m_parent.ParseIndexToTipoId(i);
						array[num2] = t_ordenTypoId.ToString();
						array[4] = " es anormalmente alto: ";
						array[5] = list.Count.ToString();
						Debug.LogWarning(string.Concat(array), this.m_parent);
					}
					num += this.UpdateTerminandoOrndenes(list, dataUpdate, this.m_ordenes[i]);
				}
				return num;
			}

			// Token: 0x06000102 RID: 258 RVA: 0x00004A50 File Offset: 0x00002C50
			private int UpdateTerminandoOrndenes(List<T_orden> ordennesDeTipo, T_updateData dataUpdate, T_orden esperando)
			{
				if (ordennesDeTipo == null)
				{
					return 0;
				}
				for (int i = ordennesDeTipo.Count - 1; i >= 0; i--)
				{
					ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls ordenInternalCalls = ordennesDeTipo[i];
					if (ordenInternalCalls.OnOrdenTerminando(dataUpdate, false, esperando))
					{
						ordenInternalCalls.OnOrdenTerminada(dataUpdate, false);
						ordennesDeTipo.RemoveAt(i);
					}
				}
				return ordennesDeTipo.Count;
			}

			// Token: 0x06000103 RID: 259 RVA: 0x00004AA4 File Offset: 0x00002CA4
			protected bool OrdenDebeEsperarDetencion(T_orden orden, int index, T_updateData dataUpdate)
			{
				List<T_orden> list = this.m_ordenesDeteniendose[index];
				return list != null && list.Count > 0;
			}

			// Token: 0x06000104 RID: 260 RVA: 0x00004AC8 File Offset: 0x00002CC8
			protected bool UpdateOrden(T_orden orden, int index, T_updateData dataUpdate)
			{
				return orden != null && (this.OrdenDebeEsperarDetencion(orden, index, dataUpdate) || orden.Update(dataUpdate, this.m_parent));
			}

			// Token: 0x06000105 RID: 261 RVA: 0x00004AF3 File Offset: 0x00002CF3
			protected bool UpdateOrden2(T_orden orden, int index, T_updateData dataUpdate)
			{
				return orden != null && (this.OrdenDebeEsperarDetencion(orden, index, dataUpdate) || orden.Update2(dataUpdate, this.m_parent));
			}

			// Token: 0x06000106 RID: 262 RVA: 0x00004B20 File Offset: 0x00002D20
			public void DetenerOrdenAbrutamente(T_orden orden)
			{
				if (orden == null)
				{
					throw new ArgumentNullException("orden", "orden null reference.");
				}
				int num = this.m_parent.ParseTipoIdToindex(orden.tipoId);
				if (this.m_ordenes[num] != orden)
				{
					throw new InvalidOperationException();
				}
				this.Detener(num, orden, true, true);
			}

			// Token: 0x06000107 RID: 263 RVA: 0x00004B88 File Offset: 0x00002D88
			public void DetenerOrden(T_orden orden)
			{
				if (orden == null)
				{
					throw new ArgumentNullException("orden", "orden null reference.");
				}
				int num = this.m_parent.ParseTipoIdToindex(orden.tipoId);
				if (this.m_ordenes[num] != orden)
				{
					throw new InvalidOperationException();
				}
				this.Detener(num, orden, true, false);
			}

			// Token: 0x06000108 RID: 264 RVA: 0x00004BF0 File Offset: 0x00002DF0
			public bool TryDetenerOrden(T_orden orden, bool abrutamente = false)
			{
				if (orden == null)
				{
					throw new ArgumentNullException("orden", "orden null reference.");
				}
				int num = this.m_parent.ParseTipoIdToindex(orden.tipoId);
				if (this.m_ordenes[num] != orden)
				{
					return false;
				}
				this.Detener(num, orden, true, abrutamente);
				return true;
			}

			// Token: 0x06000109 RID: 265 RVA: 0x00004C54 File Offset: 0x00002E54
			private void Detener(int index, T_orden orden, bool detenidaPorUser = true, bool abrutamente = false)
			{
				if (orden == null)
				{
					return;
				}
				this.m_ordenes[index] = default(T_orden);
				this.m_ultimasOrdenes[index] = orden;
				ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls ordenInternalCalls = orden;
				T_updateData t_updateData = this.m_parent.ObtenerUpdateData();
				if (detenidaPorUser)
				{
					ordenInternalCalls.OnOrdenDetenidaPorUsuario(t_updateData);
				}
				T_orden t_orden = this.m_parent.m_cola.Peek(index);
				if (!abrutamente && !ordenInternalCalls.OnOrdenTerminando(t_updateData, true, t_orden))
				{
					List<T_orden> list = this.m_ordenesDeteniendose[index];
					if (list == null)
					{
						list = new List<T_orden>();
						this.m_ordenesDeteniendose[index] = list;
					}
					list.Add(orden);
					return;
				}
				ordenInternalCalls.OnOrdenTerminada(t_updateData, abrutamente);
			}

			// Token: 0x0600010A RID: 266 RVA: 0x00004D00 File Offset: 0x00002F00
			public bool DetenerOrdenEnSlot(T_ordenTypoId tipoId, bool interrumpirOrdenAbrutamente)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				T_orden t_orden = this.m_ordenes[num];
				if (t_orden != null)
				{
					if (interrumpirOrdenAbrutamente)
					{
						this.DetenerOrdenAbrutamente(t_orden);
					}
					else
					{
						this.DetenerOrden(t_orden);
					}
					return true;
				}
				return false;
			}

			// Token: 0x0600010B RID: 267 RVA: 0x00004D48 File Offset: 0x00002F48
			public bool DetenerOrdenEnSlot(T_ordenTypoId tipoId)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				T_orden t_orden = this.m_ordenes[num];
				if (t_orden != null)
				{
					this.DetenerOrden(t_orden);
					return true;
				}
				return false;
			}

			// Token: 0x0600010C RID: 268 RVA: 0x00004D84 File Offset: 0x00002F84
			public void ForzarDetenerOrdenes()
			{
				for (int i = 0; i < this.m_ordenes.Length; i++)
				{
					T_orden t_orden = this.m_ordenes[i];
					if (t_orden != null)
					{
						this.DetenerOrdenAbrutamente(t_orden);
					}
				}
			}

			// Token: 0x0600010D RID: 269 RVA: 0x00004DC0 File Offset: 0x00002FC0
			public void DetenerOrdenes()
			{
				for (int i = 0; i < this.m_ordenes.Length; i++)
				{
					T_orden t_orden = this.m_ordenes[i];
					if (t_orden != null)
					{
						this.DetenerOrden(t_orden);
					}
				}
			}

			// Token: 0x0600010E RID: 270 RVA: 0x00004DFC File Offset: 0x00002FFC
			public void InyectarOrden(T_orden nuevaOrden, bool interrumpirOrdenAbrutamente)
			{
				if (nuevaOrden == null)
				{
					throw new ArgumentNullException("nuevaOrden", "nuevaOrden null reference.");
				}
				this.DetenerOrdenEnSlot(nuevaOrden.tipoId, interrumpirOrdenAbrutamente);
				if (interrumpirOrdenAbrutamente)
				{
					List<T_orden> list = this.obtenerOrdenesDeteniendose(nuevaOrden.tipoId);
					if (list != null && list.Count > 0)
					{
						T_updateData t_updateData = this.m_parent.ObtenerUpdateData();
						for (int i = list.Count - 1; i >= 0; i--)
						{
							list[i].OnOrdenTerminada(t_updateData, interrumpirOrdenAbrutamente);
							list.RemoveAt(i);
						}
					}
				}
				int num = this.m_parent.ParseTipoIdToindex(nuevaOrden.tipoId);
				this.m_ordenes[num] = nuevaOrden;
			}

			// Token: 0x0600010F RID: 271 RVA: 0x00004EB4 File Offset: 0x000030B4
			public bool SlotIsFree(T_ordenTypoId tipoId)
			{
				int num = this.m_parent.ParseTipoIdToindex(tipoId);
				return this.SlotIsFree(num);
			}

			// Token: 0x06000110 RID: 272 RVA: 0x00004ED8 File Offset: 0x000030D8
			public bool SlotIsFree(int index)
			{
				T_orden t_orden = this.m_ordenes[index];
				return t_orden == null || t_orden.Termino();
			}

			// Token: 0x06000111 RID: 273 RVA: 0x00004F08 File Offset: 0x00003108
			public void SetSlot(T_orden nuevaOrden)
			{
				if (nuevaOrden == null)
				{
					throw new ArgumentNullException("nuevaOrden", "nuevaOrden null reference.");
				}
				if (!this.SlotIsFree(nuevaOrden.tipoId))
				{
					throw new InvalidOperationException();
				}
				int num = this.m_parent.ParseTipoIdToindex(nuevaOrden.tipoId);
				this.m_ordenes[num] = nuevaOrden;
			}

			// Token: 0x04000085 RID: 133
			private ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> m_parent;

			// Token: 0x04000086 RID: 134
			[SerializeField]
			private T_orden[] m_ordenes;

			// Token: 0x04000087 RID: 135
			[SerializeField]
			private T_orden[] m_ultimasOrdenes;

			// Token: 0x04000088 RID: 136
			private List<T_orden>[] m_ordenesDeteniendose;

			// Token: 0x04000089 RID: 137
			private int m_lastFrame;

			// Token: 0x0400008A RID: 138
			private float m_lastTimeUpdated;

			// Token: 0x0400008B RID: 139
			private float m_deltaTime;
		}

		// Token: 0x02000023 RID: 35
		private interface IOrdenInternalCalls
		{
			// Token: 0x06000113 RID: 275
			bool Update(T_updateData dataUpdate, ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> controller);

			// Token: 0x06000114 RID: 276
			bool Update2(T_updateData dataUpdate, ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> controller);

			// Token: 0x06000115 RID: 277
			bool OnOrdenTerminando(T_updateData dataUpdate, bool primerUpdate, T_orden ordenEsperandoDetencion);

			// Token: 0x06000116 RID: 278
			void OnOrdenTerminada(T_updateData dataUpdate, bool abruptamente);

			// Token: 0x06000117 RID: 279
			void OnOrdenCancelada();

			// Token: 0x06000118 RID: 280
			void OnOrdenDetenidaPorUsuario(T_updateData dataUpdate);

			// Token: 0x06000119 RID: 281
			void SetController(ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> controller);
		}

		// Token: 0x02000024 RID: 36
		public abstract class OrdenBaseDeControllador : ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls, IOrdenDeController
		{
			// Token: 0x0600011A RID: 282 RVA: 0x00004F72 File Offset: 0x00003172
			public OrdenBaseDeControllador(T_ordenTypoId tipoId, Action<T_orden> comenzadaCallBack, Action<T_orden> terminadaCallBack)
				: this(tipoId, -1, -1f, ControllerPrioridadConfig.baja, comenzadaCallBack, terminadaCallBack)
			{
			}

			// Token: 0x0600011B RID: 283 RVA: 0x00004F84 File Offset: 0x00003184
			public OrdenBaseDeControllador(T_ordenTypoId tipoId, float duracion, Action<T_orden> comenzadaCallBack, Action<T_orden> terminadaCallBack)
				: this(tipoId, -1, duracion, ControllerPrioridadConfig.baja, comenzadaCallBack, terminadaCallBack)
			{
			}

			// Token: 0x0600011C RID: 284 RVA: 0x00004F93 File Offset: 0x00003193
			public OrdenBaseDeControllador(T_ordenTypoId tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, Action<T_orden> comenzadaCallBack, Action<T_orden> terminadaCallBack)
				: this(tipoId, prioridad, duracion, priConfig, false)
			{
				this.m_comienzadaCallBack = comenzadaCallBack;
				this.m_terminadaCallBack = terminadaCallBack;
			}

			// Token: 0x0600011D RID: 285 RVA: 0x00004FB1 File Offset: 0x000031B1
			public OrdenBaseDeControllador(T_ordenTypoId tipoId, float duracion)
				: this(tipoId, -1, duracion, ControllerPrioridadConfig.baja, false)
			{
			}

			// Token: 0x0600011E RID: 286 RVA: 0x00004FC0 File Offset: 0x000031C0
			public OrdenBaseDeControllador(T_ordenTypoId tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, bool duracionEsFixed = false)
			{
				this.m_tipoId = tipoId;
				this.SetPrioridad(prioridad);
				this.m_duracion = duracion;
				this.m_priConfig = priConfig;
				this.m_duracionEsFixed = duracionEsFixed;
			}

			// Token: 0x0600011F RID: 287 RVA: 0x00005018 File Offset: 0x00003218
			public void SetPrioridad(int prioridad)
			{
				this.m_prioridad = prioridad;
				this.m_initialPrioridad = prioridad;
			}

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000120 RID: 288 RVA: 0x00005035 File Offset: 0x00003235
			public float estadoDeltaTime
			{
				get
				{
					return this.m_controller.m_currentStado.selfDeltaTime;
				}
			}

			// Token: 0x06000121 RID: 289 RVA: 0x0000504C File Offset: 0x0000324C
			public void WasReused()
			{
				if (!this.stared)
				{
					Debug.LogError("No es compatible, Reusar una orden q no ha comenzado. tipo: " + typeof(T_orden).Name);
				}
				if (this.m_finalizada)
				{
					Debug.LogError("No es compatible, Reusar una orden q ha finalizado. tipo: " + typeof(T_orden).Name);
				}
				if (this.m_cancelada)
				{
					Debug.LogError("No es compatible, Reusar una orden q ha sid cancelada. tipo: " + typeof(T_orden).Name);
				}
				this.OnWasReused();
			}

			// Token: 0x06000122 RID: 290 RVA: 0x000050D1 File Offset: 0x000032D1
			protected virtual void OnWasReused()
			{
			}

			// Token: 0x06000123 RID: 291 RVA: 0x000050D4 File Offset: 0x000032D4
			public void SetCallBacks(Action<T_orden> comienzada, Action<T_orden> terminada)
			{
				if (comienzada != null)
				{
					this.m_flagReCallComienza = true;
					this.m_comienzadaCallBack = (Action<T_orden>)Delegate.Remove(this.m_comienzadaCallBack, comienzada);
					this.m_comienzadaCallBack = (Action<T_orden>)Delegate.Combine(this.m_comienzadaCallBack, comienzada);
				}
				if (terminada != null)
				{
					this.m_terminadaCallBack = (Action<T_orden>)Delegate.Remove(this.m_terminadaCallBack, terminada);
					this.m_terminadaCallBack = (Action<T_orden>)Delegate.Combine(this.m_terminadaCallBack, terminada);
				}
			}

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x06000124 RID: 292 RVA: 0x0000514A File Offset: 0x0000334A
			public bool cancelada
			{
				get
				{
					return this.m_cancelada;
				}
			}

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x06000125 RID: 293 RVA: 0x00005152 File Offset: 0x00003352
			public bool permanente
			{
				get
				{
					return this.m_duracion < 0f;
				}
			}

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x06000126 RID: 294 RVA: 0x00005161 File Offset: 0x00003361
			public bool stared
			{
				get
				{
					return !this.m_firstUpdate;
				}
			}

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x06000127 RID: 295 RVA: 0x0000516C File Offset: 0x0000336C
			public bool firstUpdate
			{
				get
				{
					return this.m_firstUpdate;
				}
			}

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x06000128 RID: 296 RVA: 0x00005174 File Offset: 0x00003374
			public bool finalizada
			{
				get
				{
					return this.m_finalizada;
				}
			}

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x06000129 RID: 297 RVA: 0x0000517C File Offset: 0x0000337C
			public T_orden anterior
			{
				get
				{
					return this.m_anterior;
				}
			}

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x0600012A RID: 298 RVA: 0x00005184 File Offset: 0x00003384
			public T_ordenTypoId tipoId
			{
				get
				{
					return this.m_tipoId;
				}
			}

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x0600012B RID: 299 RVA: 0x0000518C File Offset: 0x0000338C
			public int prioridad
			{
				get
				{
					if (this.m_priConfig == ControllerPrioridadConfig.interrumpir)
					{
						return int.MaxValue;
					}
					return this.m_prioridad;
				}
			}

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x0600012C RID: 300 RVA: 0x000051A3 File Offset: 0x000033A3
			// (set) Token: 0x0600012D RID: 301 RVA: 0x000051AB File Offset: 0x000033AB
			public ControllerPrioridadConfig priConfig
			{
				get
				{
					return this.m_priConfig;
				}
				set
				{
					this.m_priConfig = value;
				}
			}

			// Token: 0x17000035 RID: 53
			// (get) Token: 0x0600012E RID: 302 RVA: 0x000051B4 File Offset: 0x000033B4
			public float duracion
			{
				get
				{
					return this.m_duracion;
				}
			}

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x0600012F RID: 303 RVA: 0x000051BC File Offset: 0x000033BC
			public float startTime
			{
				get
				{
					if (!this.stared)
					{
						throw new InvalidOperationException("no se puede saber el tiempo restante de una orden q no ha comenzado");
					}
					return this.m_startTime;
				}
			}

			// Token: 0x17000037 RID: 55
			// (get) Token: 0x06000130 RID: 304 RVA: 0x000051D7 File Offset: 0x000033D7
			public float unscaledStartTime
			{
				get
				{
					if (!this.stared)
					{
						throw new InvalidOperationException("no se puede saber el tiempo restante de una orden q no ha comenzado");
					}
					return this.m_unscaledStartTime;
				}
			}

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x06000131 RID: 305 RVA: 0x000051F2 File Offset: 0x000033F2
			public float currentUnscaledTime
			{
				get
				{
					return Time.unscaledTime - this.unscaledStartTime;
				}
			}

			// Token: 0x17000039 RID: 57
			// (get) Token: 0x06000132 RID: 306 RVA: 0x00005200 File Offset: 0x00003400
			public float currentTime
			{
				get
				{
					return Time.time - this.startTime;
				}
			}

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x06000133 RID: 307 RVA: 0x0000520E File Offset: 0x0000340E
			public float currentTimeMod
			{
				get
				{
					if (this.permanente || this.m_duracion == 0f)
					{
						return Mathf.InverseLerp(0f, 0.5f, this.currentTime);
					}
					return Mathf.Clamp01(this.currentTime / this.m_duracion);
				}
			}

			// Token: 0x1700003B RID: 59
			// (get) Token: 0x06000134 RID: 308 RVA: 0x0000524D File Offset: 0x0000344D
			public float tiempoRestante
			{
				get
				{
					if (!this.stared)
					{
						throw new InvalidOperationException("no se puede saber el tiempo restante de una orden q no ha comenzado");
					}
					if (this.permanente)
					{
						throw new InvalidOperationException("no se puede saber el tiempo restante de una orden permanente");
					}
					return this.startTime + this.m_duracion - Time.time;
				}
			}

			// Token: 0x1700003C RID: 60
			// (get) Token: 0x06000135 RID: 309 RVA: 0x00005288 File Offset: 0x00003488
			IOrdenDeController IOrdenDeController.anterior
			{
				get
				{
					return this.anterior;
				}
			}

			// Token: 0x1700003D RID: 61
			// (get) Token: 0x06000136 RID: 310 RVA: 0x00005295 File Offset: 0x00003495
			int IOrdenDeController.tipoId
			{
				get
				{
					return this.m_controller.ParseTipoIdToindex(this.tipoId);
				}
			}

			// Token: 0x06000137 RID: 311 RVA: 0x000052A8 File Offset: 0x000034A8
			void ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls.SetController(ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> controller)
			{
				this.m_controller = controller;
			}

			// Token: 0x06000138 RID: 312 RVA: 0x000052B1 File Offset: 0x000034B1
			protected virtual bool EsperandoFrameParaComenzar(T_updateData dataUpdate)
			{
				return false;
			}

			// Token: 0x06000139 RID: 313 RVA: 0x000052B4 File Offset: 0x000034B4
			bool ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls.Update(T_updateData dataUpdate, ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> controller)
			{
				if ((this.m_firstUpdate || this.m_flagReCallComienza) && this.EsperandoFrameParaComenzar(dataUpdate))
				{
					return true;
				}
				bool firstUpdate = this.m_firstUpdate;
				if (firstUpdate)
				{
					this.m_firstUpdate = false;
					this.m_startTime = Time.time;
					this.m_unscaledStartTime = Time.unscaledTime;
					this.m_anterior = controller.m_currentStado.GetLastOrdenOf(this.m_tipoId, true);
					controller.OnOrderBeforePrimerUpdate((T_orden)((object)this));
					this.OnStart(dataUpdate);
				}
				if (firstUpdate || this.m_flagReCallComienza)
				{
					this.m_flagReCallComienza = false;
					Action<T_orden> comienzadaCallBack = this.m_comienzadaCallBack;
					this.m_comienzadaCallBack = null;
					if (comienzadaCallBack != null)
					{
						comienzadaCallBack((T_orden)((object)this));
					}
				}
				return this.UpdateOrden(dataUpdate, firstUpdate);
			}

			// Token: 0x0600013A RID: 314 RVA: 0x0000536B File Offset: 0x0000356B
			bool ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls.Update2(T_updateData dataUpdate, ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> controller)
			{
				if (!this.stared)
				{
					throw new InvalidOperationException();
				}
				return this.UpdateOrden2(dataUpdate);
			}

			// Token: 0x0600013B RID: 315 RVA: 0x00005382 File Offset: 0x00003582
			void ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls.OnOrdenDetenidaPorUsuario(T_updateData dataUpdate)
			{
				this.OnDetenidaPorUsuario(dataUpdate);
			}

			// Token: 0x0600013C RID: 316 RVA: 0x0000538B File Offset: 0x0000358B
			void ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls.OnOrdenCancelada()
			{
				this.ClearFields();
				this.m_cancelada = true;
			}

			// Token: 0x0600013D RID: 317 RVA: 0x0000539A File Offset: 0x0000359A
			bool ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls.OnOrdenTerminando(T_updateData dataUpdate, bool primerUpdate, T_orden ordenEsperandoDetencion)
			{
				return this.OnTerminando(dataUpdate, primerUpdate, ordenEsperandoDetencion);
			}

			// Token: 0x0600013E RID: 318 RVA: 0x000053A5 File Offset: 0x000035A5
			void ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.IOrdenInternalCalls.OnOrdenTerminada(T_updateData dataUpdate, bool abruptamente)
			{
				this.OnTerminada(dataUpdate, abruptamente);
				Action<T_orden> terminadaCallBack = this.m_terminadaCallBack;
				this.m_terminadaCallBack = null;
				if (terminadaCallBack != null)
				{
					terminadaCallBack((T_orden)((object)this));
				}
				this.ClearFields();
				this.m_finalizada = true;
			}

			// Token: 0x0600013F RID: 319 RVA: 0x000053DC File Offset: 0x000035DC
			private void ClearFields()
			{
				this.m_firstUpdate = true;
				this.m_startTime = float.MinValue;
				this.m_unscaledStartTime = float.MinValue;
				this.m_priConfig = (ControllerPrioridadConfig)0;
				this.m_tipoId = default(T_ordenTypoId);
				this.m_prioridad = 0;
				this.m_duracion = 0f;
				this.m_anterior = default(T_orden);
			}

			// Token: 0x06000140 RID: 320 RVA: 0x00005437 File Offset: 0x00003637
			public void Detener(bool abrutamente = false)
			{
				this.m_controller.m_cola.TryRemove((T_orden)((object)this));
				this.m_controller.m_currentStado.TryDetenerOrden((T_orden)((object)this), abrutamente);
			}

			// Token: 0x06000141 RID: 321 RVA: 0x00005474 File Offset: 0x00003674
			public float ObtenerCurrentTimeMod(float dismuirDuracion)
			{
				float num = this.m_duracion - dismuirDuracion;
				if (num <= 0f)
				{
					return Mathf.InverseLerp(0f, 0.5f, this.currentTime);
				}
				return Mathf.Clamp01(this.currentTime / num);
			}

			// Token: 0x06000142 RID: 322 RVA: 0x000054B8 File Offset: 0x000036B8
			protected void ChangeDuracion(float nuevaDuracion)
			{
				if (this.m_duracionEsFixed)
				{
					throw new NotSupportedException();
				}
				if (this.m_duracion < 0f)
				{
					throw new NotSupportedException("no se puede cambiar duracion a orden permanente");
				}
				if (nuevaDuracion < 0f)
				{
					throw new InvalidOperationException("no se puede convertir ornden en orden permanente");
				}
				this.m_duracion = nuevaDuracion;
			}

			// Token: 0x06000143 RID: 323 RVA: 0x00005505 File Offset: 0x00003705
			protected void EsperarFrame()
			{
				if (this.usarUnscaledTime)
				{
					throw new NotSupportedException();
				}
				this.m_startTime += this.estadoDeltaTime;
			}

			// Token: 0x06000144 RID: 324 RVA: 0x00005528 File Offset: 0x00003728
			public void AñadirTiempo(float añadido, bool normalizar = true)
			{
				if (this.m_duracionEsFixed)
				{
					throw new NotSupportedException();
				}
				if (añadido <= 0f)
				{
					this.m_duracion = -1f;
					return;
				}
				if (this.permanente)
				{
					this.m_duracion = añadido;
					return;
				}
				if (!this.stared || !normalizar)
				{
					this.m_duracion += añadido;
					return;
				}
				float currentTimeMod = this.currentTimeMod;
				if (currentTimeMod < 0f || currentTimeMod > 1f)
				{
					return;
				}
				float num = añadido;
				float num2 = ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId>.OrdenBaseDeControllador.RecalcularStartTimeParaConservarCurrentMod(this.m_duracion, Time.time, currentTimeMod, ref num);
				if (float.IsInfinity(num2) || num2 <= 0f)
				{
					return;
				}
				this.m_duracion = num + this.m_duracion;
				this.m_unscaledStartTime += num2 - this.m_startTime;
				this.m_startTime = num2;
			}

			// Token: 0x06000145 RID: 325 RVA: 0x000055EA File Offset: 0x000037EA
			private static float RecalcularStartTimeParaConservarCurrentMod(float duration, float currentTime, float modDeseado, ref float timeAdded)
			{
				if (modDeseado < 0f || modDeseado > 1f)
				{
					throw new InvalidOperationException();
				}
				timeAdded /= 1f - modDeseado;
				return currentTime - (duration + timeAdded) * modDeseado;
			}

			// Token: 0x06000146 RID: 326 RVA: 0x00005616 File Offset: 0x00003816
			protected void DisminuirPrioridadDeltaTime(float timeToZero)
			{
				this.m_prioridad = (int)Mathf.MoveTowards((float)this.m_prioridad, 0f, Time.deltaTime * (float)this.m_initialPrioridad * (1f / timeToZero));
			}

			// Token: 0x06000147 RID: 327 RVA: 0x00005645 File Offset: 0x00003845
			protected void DisminuirPrioridadAcumulativaDelta(float speed)
			{
				this.m_prioridad = (int)Mathf.MoveTowards((float)this.m_prioridad, 0f, Time.deltaTime * (float)this.m_prioridad * speed);
			}

			// Token: 0x06000148 RID: 328 RVA: 0x0000566E File Offset: 0x0000386E
			protected void DisminuirPrioridadNoAcumulativaDelta(float speed)
			{
				this.m_prioridad = (int)Mathf.MoveTowards((float)this.m_prioridad, 0f, Time.deltaTime * (float)this.m_initialPrioridad * speed);
			}

			// Token: 0x06000149 RID: 329
			protected abstract bool UpdateOrden(T_updateData dataUpdate, bool esPrimerUpdate);

			// Token: 0x0600014A RID: 330 RVA: 0x00005697 File Offset: 0x00003897
			protected virtual bool UpdateOrden2(T_updateData dataUpdate)
			{
				return false;
			}

			// Token: 0x0600014B RID: 331
			protected abstract void OnDetenidaPorUsuario(T_updateData dataUpdate);

			// Token: 0x0600014C RID: 332
			protected abstract bool OnTerminando(T_updateData dataUpdate, bool primerUpdate, T_orden ordenEsperandoDetencion);

			// Token: 0x0600014D RID: 333
			protected abstract void OnTerminada(T_updateData dataUpdate, bool abruptamente);

			// Token: 0x0600014E RID: 334
			protected abstract void OnStart(T_updateData dataUpdate);

			// Token: 0x0600014F RID: 335 RVA: 0x0000569A File Offset: 0x0000389A
			public bool TerminoTiempo()
			{
				return !this.permanente && this.currentTime > this.m_duracion;
			}

			// Token: 0x06000150 RID: 336 RVA: 0x000056B4 File Offset: 0x000038B4
			public bool TerminoUnscaledTiempo()
			{
				return !this.permanente && this.currentUnscaledTime > this.m_duracion;
			}

			// Token: 0x06000151 RID: 337 RVA: 0x000056CE File Offset: 0x000038CE
			public virtual bool Termino()
			{
				if (this.finalizada || this.cancelada)
				{
					return true;
				}
				if (!this.stared)
				{
					return false;
				}
				if (!this.usarUnscaledTime)
				{
					return this.TerminoTiempo();
				}
				return this.TerminoUnscaledTiempo();
			}

			// Token: 0x0400008C RID: 140
			public bool usarUnscaledTime;

			// Token: 0x0400008D RID: 141
			[NonSerialized]
			protected readonly bool m_duracionEsFixed;

			// Token: 0x0400008E RID: 142
			[SerializeField]
			private ControllerPrioridadConfig m_priConfig;

			// Token: 0x0400008F RID: 143
			[SerializeField]
			private T_ordenTypoId m_tipoId;

			// Token: 0x04000090 RID: 144
			[SerializeField]
			private int m_prioridad;

			// Token: 0x04000091 RID: 145
			[SerializeField]
			private int m_initialPrioridad;

			// Token: 0x04000092 RID: 146
			[SerializeField]
			private float m_duracion;

			// Token: 0x04000093 RID: 147
			[SerializeField]
			private float m_startTime = float.MinValue;

			// Token: 0x04000094 RID: 148
			[SerializeField]
			private float m_unscaledStartTime = float.MinValue;

			// Token: 0x04000095 RID: 149
			[NonSerialized]
			private T_orden m_anterior;

			// Token: 0x04000096 RID: 150
			[NonSerialized]
			private bool m_finalizada;

			// Token: 0x04000097 RID: 151
			[NonSerialized]
			private bool m_firstUpdate = true;

			// Token: 0x04000098 RID: 152
			[NonSerialized]
			private bool m_cancelada;

			// Token: 0x04000099 RID: 153
			private ControllerColaDePrioridadBase<T_estado, T_orden, T_cola, T_updateData, T_ordenTypoId> m_controller;

			// Token: 0x0400009A RID: 154
			private Action<T_orden> m_comienzadaCallBack;

			// Token: 0x0400009B RID: 155
			private Action<T_orden> m_terminadaCallBack;

			// Token: 0x0400009C RID: 156
			[NonSerialized]
			private bool m_flagReCallComienza;
		}
	}
}
