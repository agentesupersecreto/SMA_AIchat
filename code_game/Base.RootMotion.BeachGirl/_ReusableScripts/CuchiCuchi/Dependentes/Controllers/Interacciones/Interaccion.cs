using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000D7 RID: 215
	public abstract class Interaccion : AplicableBehaviour, IInteraccion, InteraccionAddingEvents, InteraccionEstado.InteractionCallBacks
	{
		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060007B8 RID: 1976 RVA: 0x00025069 File Offset: 0x00023269
		public int lastInteractionSystemID
		{
			get
			{
				return this.m_lastInteractionSystemID;
			}
		}

		// Token: 0x14000066 RID: 102
		// (add) Token: 0x060007B9 RID: 1977 RVA: 0x00025074 File Offset: 0x00023274
		// (remove) Token: 0x060007BA RID: 1978 RVA: 0x000250AC File Offset: 0x000232AC
		public event Action<Interaccion> checkingPuedeEjecutarse;

		// Token: 0x14000067 RID: 103
		// (add) Token: 0x060007BB RID: 1979 RVA: 0x000250E4 File Offset: 0x000232E4
		// (remove) Token: 0x060007BC RID: 1980 RVA: 0x0002511C File Offset: 0x0002331C
		public event InteraccionAbortHanlder onPuedeEjecutarse;

		// Token: 0x14000068 RID: 104
		// (add) Token: 0x060007BD RID: 1981 RVA: 0x00025154 File Offset: 0x00023354
		// (remove) Token: 0x060007BE RID: 1982 RVA: 0x0002518C File Offset: 0x0002338C
		public event InteraccionAbortHanlder checkObstacles;

		// Token: 0x14000069 RID: 105
		// (add) Token: 0x060007BF RID: 1983 RVA: 0x000251C4 File Offset: 0x000233C4
		// (remove) Token: 0x060007C0 RID: 1984 RVA: 0x000251FC File Offset: 0x000233FC
		public event InteraccionAbortHanlder onPuedeEjecutarseConParametros;

		// Token: 0x1400006A RID: 106
		// (add) Token: 0x060007C1 RID: 1985 RVA: 0x00025234 File Offset: 0x00023434
		// (remove) Token: 0x060007C2 RID: 1986 RVA: 0x0002526C File Offset: 0x0002346C
		public event Action<Interaccion> checkedPuedeEjecutarse;

		// Token: 0x1400006B RID: 107
		// (add) Token: 0x060007C3 RID: 1987 RVA: 0x000252A4 File Offset: 0x000234A4
		// (remove) Token: 0x060007C4 RID: 1988 RVA: 0x000252DC File Offset: 0x000234DC
		public event Action<Interaccion> justAntesDeEjecutar;

		// Token: 0x1400006C RID: 108
		// (add) Token: 0x060007C5 RID: 1989 RVA: 0x00025314 File Offset: 0x00023514
		// (remove) Token: 0x060007C6 RID: 1990 RVA: 0x0002534C File Offset: 0x0002354C
		public event Action<Interaccion> comenzada;

		// Token: 0x1400006D RID: 109
		// (add) Token: 0x060007C7 RID: 1991 RVA: 0x00025384 File Offset: 0x00023584
		// (remove) Token: 0x060007C8 RID: 1992 RVA: 0x000253BC File Offset: 0x000235BC
		public event Action<Interaccion> justAntesDeDetener;

		// Token: 0x1400006E RID: 110
		// (add) Token: 0x060007C9 RID: 1993 RVA: 0x000253F4 File Offset: 0x000235F4
		// (remove) Token: 0x060007CA RID: 1994 RVA: 0x0002542C File Offset: 0x0002362C
		public event Action<Interaccion> terminada;

		// Token: 0x1400006F RID: 111
		// (add) Token: 0x060007CB RID: 1995 RVA: 0x00025464 File Offset: 0x00023664
		// (remove) Token: 0x060007CC RID: 1996 RVA: 0x0002549C File Offset: 0x0002369C
		public event Action<Interaccion, IInteraccionesDeCharacter> addedTo;

		// Token: 0x14000070 RID: 112
		// (add) Token: 0x060007CD RID: 1997 RVA: 0x000254D4 File Offset: 0x000236D4
		// (remove) Token: 0x060007CE RID: 1998 RVA: 0x0002550C File Offset: 0x0002370C
		public event Action<Interaccion, IInteraccionesDeCharacter> removingFrom;

		// Token: 0x14000071 RID: 113
		// (add) Token: 0x060007CF RID: 1999 RVA: 0x00025544 File Offset: 0x00023744
		// (remove) Token: 0x060007D0 RID: 2000 RVA: 0x0002557C File Offset: 0x0002377C
		public event Action<Interaccion, IInteraccionesDeCharacter> removedFrom;

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x000255B1 File Offset: 0x000237B1
		public InteraccionInfo datosDeParesDeEfecctors
		{
			get
			{
				return this.m_datos;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x000255B9 File Offset: 0x000237B9
		public InteraccionEstado currentEstado
		{
			get
			{
				return this.m_currentEstado;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x000255C4 File Offset: 0x000237C4
		public bool algunaEstaEjecutandose
		{
			get
			{
				IInteractionController user = this.user;
				return user != null && user.AlgunaEstaInteractuando(this.m_datos, this.interactionLayer);
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x000255EF File Offset: 0x000237EF
		public bool ejecutandose
		{
			get
			{
				return this.m_currentEstado.ejecutandose;
			}
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x000255FC File Offset: 0x000237FC
		public bool EsperandoEjecutarse()
		{
			return this.m_currentEstado.EsperandoEjecucion();
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x00025609 File Offset: 0x00023809
		public int interactionLayer
		{
			get
			{
				return this.Tipo;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060007D7 RID: 2007
		public abstract int Tipo { get; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060007D8 RID: 2008
		protected abstract bool detenerTodasDelMismoLayer { get; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060007D9 RID: 2009
		public abstract IInteractionController user { get; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060007DA RID: 2010 RVA: 0x00025611 File Offset: 0x00023811
		public IInteraccionesDeCharacter owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00025619 File Offset: 0x00023819
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_justBeforeEjecucionCallBack = new InteractionCallBackHandler(this.justoAntesDeEjecutarse);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x00025633 File Offset: 0x00023833
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_datos.Init();
			this.m_currentEstado = new InteraccionEstado(this.m_datos, this, this);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x00025659 File Offset: 0x00023859
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Detener(false);
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00025669 File Offset: 0x00023869
		public float ObtenerDuracionPorDefecto()
		{
			return this.m_datos.ObtenerDuracion();
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x00025678 File Offset: 0x00023878
		public void Detener(bool force = false)
		{
			if (!this.algunaEstaEjecutandose && !force)
			{
				return;
			}
			if (!this.AntesDeDetenerse() && !force)
			{
				return;
			}
			Action<Interaccion> action = this.justAntesDeDetener;
			if (action != null)
			{
				action(this);
			}
			this.m_currentEstado.DetenerTodos();
			if (this.printDebug)
			{
				MonoBehaviour.print("Interaccion " + base.name + " detenida.");
			}
			this.DespuesDeDetenerse();
		}

		// Token: 0x060007E0 RID: 2016
		protected abstract bool AntesDeDetenerse();

		// Token: 0x060007E1 RID: 2017
		protected abstract void DespuesDeDetenerse();

		// Token: 0x060007E2 RID: 2018 RVA: 0x000256E4 File Offset: 0x000238E4
		private bool ejecutar(IInteractionController CurrentUser, bool terminarDeInmediatoEjecutandosen)
		{
			bool flag = CurrentUser.InteractuarTodos(this.m_currentEstado, terminarDeInmediatoEjecutandosen, this.m_justBeforeEjecucionCallBack);
			if (flag)
			{
				this.DespuesDeEjecutarse(this.m_currentEstado.parametros);
			}
			if (this.printDebug)
			{
				MonoBehaviour.print("Interaccion " + base.name + " ejecutada.");
			}
			return flag;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0002573C File Offset: 0x0002393C
		public bool EjecutarConHandler()
		{
			if (!base.isActiveAndEnabled)
			{
				return false;
			}
			if (this.tryEjecutarHandler == null)
			{
				return false;
			}
			int num;
			float num2;
			ControllerPrioridadConfig controllerPrioridadConfig;
			float num3;
			bool flag;
			if (!this.tryEjecutarHandler(this, out num, out num2, out controllerPrioridadConfig, out num3, out flag))
			{
				return false;
			}
			InteraccionStartParams interaccionStartParams = new InteraccionStartParams(num, num2, controllerPrioridadConfig, num3, num3, num3, flag);
			return this.puedeEjecutarseConParametros(interaccionStartParams) && this.Ejecutar(num, num2, controllerPrioridadConfig, num3, num3, flag);
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x000257A0 File Offset: 0x000239A0
		public void ForzarEjecucion(float duracion, float initialVelocidadInMod, float velocidadInMod, float velocidadOutMod, bool terminarDeInmediatoEjecutandosen, bool usarTransicionEntreInteracionesEnMismoLayerSiDisponible)
		{
			if (!base.isActiveAndEnabled)
			{
				throw new InvalidOperationException();
			}
			this.OnForzada();
			IInteractionController user = this.user;
			if (user == null)
			{
				throw new InvalidOperationException();
			}
			this.m_currentEstado.interactionLayer = this.interactionLayer;
			this.m_currentEstado.detenerDelMismoLayer = this.detenerTodasDelMismoLayer;
			InteraccionStartParams interaccionStartParams = new InteraccionStartParams(int.MaxValue, duracion, ControllerPrioridadConfig.interrumpir, initialVelocidadInMod, velocidadInMod, velocidadOutMod, usarTransicionEntreInteracionesEnMismoLayerSiDisponible);
			this.m_currentEstado.parametros = interaccionStartParams;
			this.m_currentEstado.parametrosModificadores = this.startConfig.modificadores;
			if (!this.ejecutar(user, terminarDeInmediatoEjecutandosen))
			{
				Debug.LogError("No funciono ForzarEjecucion por alguna razon.");
			}
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00025840 File Offset: 0x00023A40
		public bool EjecutarConEstadoActual()
		{
			if (!base.isActiveAndEnabled)
			{
				return false;
			}
			if (!this.puedeEjecutarseConParametros(this.m_currentEstado.parametros))
			{
				return false;
			}
			IInteractionController user = this.user;
			return user != null && this.ejecutar(user, false);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00025880 File Offset: 0x00023A80
		public bool EjecutarWhile<T_Args>(GlobalUpdater.UpdateType updateType, T_Args argumentos, Func<Interaccion, T_Args, bool> whileDelegate, float interval, int prioridad, float maxDuracion, ControllerPrioridadConfig priConfig, float velocidadMod = 1f)
		{
			if (!this.Ejecutar(prioridad, maxDuracion, priConfig, velocidadMod, velocidadMod, false))
			{
				return false;
			}
			this.RemoveComponents<InteractionExecuteWhile>();
			base.gameObject.AddComponent<InteractionExecuteWhile>().Init<T_Args>(updateType, argumentos, whileDelegate, interval);
			return true;
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x000258B4 File Offset: 0x00023AB4
		public bool Ejecutar(int prioridad, float duracion, ControllerPrioridadConfig priConfig, float velocidadInMod, float velocidadOutMod, bool usarTransicionEntreInteracionesEnMismoLayerSiDisponible)
		{
			if (!base.isActiveAndEnabled)
			{
				return false;
			}
			InteraccionStartParams interaccionStartParams = new InteraccionStartParams(prioridad, duracion, priConfig, velocidadInMod, velocidadInMod, velocidadOutMod, usarTransicionEntreInteracionesEnMismoLayerSiDisponible);
			if (!this.puedeEjecutarseConParametros(interaccionStartParams))
			{
				return false;
			}
			IInteractionController user = this.user;
			if (user == null)
			{
				return false;
			}
			this.m_currentEstado.interactionLayer = this.interactionLayer;
			this.m_currentEstado.detenerDelMismoLayer = this.detenerTodasDelMismoLayer;
			this.m_currentEstado.parametros = interaccionStartParams;
			this.m_currentEstado.parametrosModificadores = this.startConfig.modificadores;
			return this.ejecutar(user, false);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00025940 File Offset: 0x00023B40
		public void EjecutarMaxPrioridadTiempoIndefinido()
		{
			this.Ejecutar(int.MaxValue, -1f, ControllerPrioridadConfig.prioridad, 1f, 1f, true);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00025960 File Offset: 0x00023B60
		public bool PuedeEjecutarseSinObstaculos()
		{
			if (!this.PuedeEjecutarse())
			{
				return false;
			}
			bool flag;
			try
			{
				if (this.checkObstacles != null)
				{
					((Interaccion.IArgs)this.m_onPuedeEjecutarseArgs).Poblar(this);
					this.checkObstacles(this.m_onPuedeEjecutarseArgs, this);
				}
				flag = !this.m_onPuedeEjecutarseArgs.isAborted;
			}
			finally
			{
				((IClearable)this.m_onPuedeEjecutarseArgs).Clear();
			}
			return flag;
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x000259CC File Offset: 0x00023BCC
		public bool PuedeEjecutarse()
		{
			bool flag;
			try
			{
				if (!this.OnPuedeEjecutarse())
				{
					flag = false;
				}
				else
				{
					Action<Interaccion> action = this.checkingPuedeEjecutarse;
					if (action != null)
					{
						action(this);
					}
					try
					{
						if (this.onPuedeEjecutarse != null)
						{
							((Interaccion.IArgs)this.m_onPuedeEjecutarseArgs).Poblar(this);
							this.onPuedeEjecutarse(this.m_onPuedeEjecutarseArgs, this);
						}
					}
					finally
					{
						Action<Interaccion> action2 = this.checkedPuedeEjecutarse;
						if (action2 != null)
						{
							action2(this);
						}
					}
					flag = !this.m_onPuedeEjecutarseArgs.isAborted;
				}
			}
			finally
			{
				((IClearable)this.m_onPuedeEjecutarseArgs).Clear();
			}
			return flag;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00025A70 File Offset: 0x00023C70
		private bool puedeEjecutarseConParametros(InteraccionStartParams parametros)
		{
			if (!this.PuedeEjecutarse())
			{
				return false;
			}
			bool flag;
			try
			{
				if (!this.OnPuedeEjecutarseConParametros(parametros))
				{
					flag = false;
				}
				else
				{
					Action<Interaccion> action = this.checkingPuedeEjecutarse;
					if (action != null)
					{
						action(this);
					}
					try
					{
						if (this.onPuedeEjecutarseConParametros != null)
						{
							((Interaccion.IArgs)this.m_onPuedeEjecutarseArgs).PoblarConParametros(this, parametros);
							this.onPuedeEjecutarseConParametros(this.m_onPuedeEjecutarseArgs, this);
						}
					}
					finally
					{
						Action<Interaccion> action2 = this.checkedPuedeEjecutarse;
						if (action2 != null)
						{
							action2(this);
						}
					}
					flag = !this.m_onPuedeEjecutarseArgs.isAborted;
				}
			}
			finally
			{
				((IClearable)this.m_onPuedeEjecutarseArgs).Clear();
			}
			return flag;
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00025B20 File Offset: 0x00023D20
		protected virtual bool OnPuedeEjecutarse()
		{
			return true;
		}

		// Token: 0x060007ED RID: 2029
		protected abstract void OnForzada();

		// Token: 0x060007EE RID: 2030
		protected abstract bool OnPuedeEjecutarseConParametros(InteraccionStartParams parametros);

		// Token: 0x060007EF RID: 2031
		protected abstract void JustoAntesDeEjecutarse(ref InteraccionStartParams parametros);

		// Token: 0x060007F0 RID: 2032
		protected abstract void DespuesDeEjecutarse(InteraccionStartParams parametros);

		// Token: 0x060007F1 RID: 2033 RVA: 0x00025B23 File Offset: 0x00023D23
		private void justoAntesDeEjecutarse(int id, int layer, ref InteraccionStartParams parametros)
		{
			this.m_lastInteractionSystemID = id;
			Action<Interaccion> action = this.justAntesDeEjecutar;
			if (action != null)
			{
				action(this);
			}
			this.JustoAntesDeEjecutarse(ref parametros);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x00025B48 File Offset: 0x00023D48
		public void FolloweOwnerCharacterPose(bool followScale)
		{
			IInteraccionesDeCharacter owner = this.owner;
			if (((owner != null) ? owner.character : null) != null)
			{
				base.transform.SetPositionAndRotation(this.owner.character.posicion, this.owner.character.rotacion);
				if (followScale)
				{
					float escala = this.owner.character.escala;
					float num = base.transform.lossyScale.Escala();
					float num2 = base.transform.localScale.Escala() * (escala / num);
					base.transform.localScale = new Vector3(num2, num2, num2);
				}
			}
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00025BE1 File Offset: 0x00023DE1
		[Obsolete]
		private void ComienzaOrden(IInteractionOrden orden)
		{
			if (this.printDebug)
			{
				MonoBehaviour.print("Interaccion " + base.name + " comienza.");
			}
			this.Comienza();
			Action<Interaccion> action = this.comenzada;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00025C1C File Offset: 0x00023E1C
		[Obsolete]
		private void TerminaOrden(IInteractionOrden orden)
		{
			if (this.printDebug)
			{
				MonoBehaviour.print("Interaccion " + base.name + " termina.");
			}
			Action<Interaccion> action = this.terminada;
			if (action != null)
			{
				action(this);
			}
			this.Termina();
		}

		// Token: 0x060007F5 RID: 2037
		protected abstract void Comienza();

		// Token: 0x060007F6 RID: 2038
		protected abstract void Termina();

		// Token: 0x060007F7 RID: 2039 RVA: 0x00025C58 File Offset: 0x00023E58
		protected override void OnAplicar()
		{
			base.OnAplicar();
			if (this.Ejecutar(2147483647, 10f, ControllerPrioridadConfig.prioridad, 1f, 1f, false))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00025CB4 File Offset: 0x00023EB4
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			if (this.Ejecutar(2147483647, 60f, ControllerPrioridadConfig.prioridad, 1f, 1f, false))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00025D10 File Offset: 0x00023F10
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			if (this.Ejecutar(2147483647, -1f, ControllerPrioridadConfig.prioridad, 1f, 1f, false))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x00025D6C File Offset: 0x00023F6C
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			if (this.Ejecutar(2147483647, -1f, ControllerPrioridadConfig.prioridad, 1f, 1f, true))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x00025DC8 File Offset: 0x00023FC8
		public sealed override string aplicarButtonString
		{
			get
			{
				return "Ejecutar: interrumpiendo 10 seg";
			}
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00025DCF File Offset: 0x00023FCF
		protected sealed override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Ejecutar: interrumpiendo 60 seg"
			};
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00025DEF File Offset: 0x00023FEF
		protected sealed override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Ejecutar: interrumpiendo Permanente"
			};
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00025E0F File Offset: 0x0002400F
		protected sealed override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Transicionar: Permanente"
			};
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00025E2F File Offset: 0x0002402F
		protected sealed override CustomMonobehaviourBotonConfig Boton6()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Detener"
			};
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00025E4F File Offset: 0x0002404F
		protected override void OnAplicar6()
		{
			base.OnAplicar6();
			this.Detener(true);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00025E5E File Offset: 0x0002405E
		protected virtual void OnAdded(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00025E60 File Offset: 0x00024060
		protected virtual void OnRemoved(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00025E62 File Offset: 0x00024062
		void InteraccionAddingEvents.AddedTo(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			if (interaccionesDeCharacter == null)
			{
				throw new ArgumentNullException("interaccionesDeCharacter", "sominteraccionesDeCharactereObject null reference.");
			}
			this.m_owner = interaccionesDeCharacter;
			this.OnAdded(interaccionesDeCharacter);
			Action<Interaccion, IInteraccionesDeCharacter> action = this.addedTo;
			if (action == null)
			{
				return;
			}
			action(this, interaccionesDeCharacter);
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00025E97 File Offset: 0x00024097
		void InteraccionAddingEvents.RemovingFrom(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			Action<Interaccion, IInteraccionesDeCharacter> action = this.removingFrom;
			if (action == null)
			{
				return;
			}
			action(this, this.m_owner);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00025EB0 File Offset: 0x000240B0
		void InteraccionAddingEvents.RemovedFrom(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			IInteraccionesDeCharacter owner = this.m_owner;
			this.m_owner = null;
			this.OnRemoved(owner);
			Action<Interaccion, IInteraccionesDeCharacter> action = this.removedFrom;
			if (action == null)
			{
				return;
			}
			action(this, owner);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00025EE4 File Offset: 0x000240E4
		void InteraccionEstado.InteractionCallBacks.InteraccionComienza()
		{
			if (this.printDebug)
			{
				MonoBehaviour.print("Interaccion " + base.name + " comienza.");
			}
			this.Comienza();
			Action<Interaccion> action = this.comenzada;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00025F20 File Offset: 0x00024120
		void InteraccionEstado.InteractionCallBacks.InteraccionTermina()
		{
			if (this.printDebug)
			{
				MonoBehaviour.print("Interaccion " + base.name + " termina.");
			}
			Action<Interaccion> action = this.terminada;
			if (action != null)
			{
				action(this);
			}
			this.Termina();
			if (this.loop)
			{
				this.EjecutarConEstadoActual();
			}
		}

		// Token: 0x04000532 RID: 1330
		[SerializeField]
		[ReadOnlyUI]
		private int m_lastInteractionSystemID = -1;

		// Token: 0x04000533 RID: 1331
		public bool printDebug;

		// Token: 0x04000534 RID: 1332
		public bool loop;

		// Token: 0x04000535 RID: 1333
		public Interaccion.StartConfig startConfig = new Interaccion.StartConfig();

		// Token: 0x0400053B RID: 1339
		private Interaccion.AbortingArgs m_onPuedeEjecutarseArgs = new Interaccion.AbortingArgs();

		// Token: 0x04000543 RID: 1347
		[SerializeField]
		protected InteraccionInfo m_datos = new InteraccionInfo();

		// Token: 0x04000544 RID: 1348
		[SerializeField]
		protected InteraccionEstado m_currentEstado;

		// Token: 0x04000545 RID: 1349
		private IInteraccionesDeCharacter m_owner;

		// Token: 0x04000546 RID: 1350
		public InteraccionTryEjecutarHanlder tryEjecutarHandler;

		// Token: 0x04000547 RID: 1351
		private InteractionCallBackHandler m_justBeforeEjecucionCallBack;

		// Token: 0x020001B2 RID: 434
		[Serializable]
		public class StartConfig
		{
			// Token: 0x1700026A RID: 618
			// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x000392D4 File Offset: 0x000374D4
			public InteraccionStartParamsModificadores modificadores
			{
				get
				{
					return new InteraccionStartParamsModificadores
					{
						duracion = this.duracionMod,
						velocidadIn = this.velocidadIn * this.velocidadMod,
						velocidadOut = this.velocidadOut * this.velocidadMod
					};
				}
			}

			// Token: 0x040009A1 RID: 2465
			public float duracionMod = 1f;

			// Token: 0x040009A2 RID: 2466
			public float velocidadMod = 1f;

			// Token: 0x040009A3 RID: 2467
			public float velocidadIn = 1f;

			// Token: 0x040009A4 RID: 2468
			public float velocidadOut = 1f;
		}

		// Token: 0x020001B3 RID: 435
		private interface IArgs
		{
			// Token: 0x06000CC2 RID: 3266
			void Poblar(Interaccion interaccion);

			// Token: 0x06000CC3 RID: 3267
			void PoblarConParametros(Interaccion interaccion, InteraccionStartParams parametros);
		}

		// Token: 0x020001B4 RID: 436
		[Serializable]
		public class Args : IClearable, Interaccion.IArgs
		{
			// Token: 0x1700026B RID: 619
			// (get) Token: 0x06000CC4 RID: 3268 RVA: 0x00039353 File Offset: 0x00037553
			public Interaccion interaccion
			{
				get
				{
					return this.m_Interaccion;
				}
			}

			// Token: 0x1700026C RID: 620
			// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x0003935B File Offset: 0x0003755B
			public bool parametrosEsEmpty
			{
				get
				{
					return this.m_parametrosEsEmpty;
				}
			}

			// Token: 0x1700026D RID: 621
			// (get) Token: 0x06000CC6 RID: 3270 RVA: 0x00039363 File Offset: 0x00037563
			public InteraccionStartParams parametros
			{
				get
				{
					return this.m_parametros;
				}
			}

			// Token: 0x06000CC7 RID: 3271 RVA: 0x0003936B File Offset: 0x0003756B
			protected virtual void OnCleared()
			{
			}

			// Token: 0x06000CC8 RID: 3272 RVA: 0x0003936D File Offset: 0x0003756D
			protected virtual void OnPoblado()
			{
			}

			// Token: 0x06000CC9 RID: 3273 RVA: 0x0003936F File Offset: 0x0003756F
			void IClearable.Clear()
			{
				this.m_Interaccion = null;
				this.m_parametros = default(InteraccionStartParams);
				this.m_parametrosEsEmpty = true;
				this.OnCleared();
			}

			// Token: 0x06000CCA RID: 3274 RVA: 0x00039391 File Offset: 0x00037591
			void Interaccion.IArgs.Poblar(Interaccion interaccion)
			{
				this.m_Interaccion = interaccion;
				this.m_parametrosEsEmpty = true;
				this.OnPoblado();
			}

			// Token: 0x06000CCB RID: 3275 RVA: 0x000393A7 File Offset: 0x000375A7
			void Interaccion.IArgs.PoblarConParametros(Interaccion interaccion, InteraccionStartParams parametros)
			{
				this.m_Interaccion = interaccion;
				this.m_parametros = parametros;
				this.m_parametrosEsEmpty = false;
				this.OnPoblado();
			}

			// Token: 0x040009A5 RID: 2469
			[ReadOnlyUI]
			[SerializeField]
			private Interaccion m_Interaccion;

			// Token: 0x040009A6 RID: 2470
			[ReadOnlyUI]
			[SerializeField]
			private bool m_parametrosEsEmpty;

			// Token: 0x040009A7 RID: 2471
			[ReadOnlyUI]
			[SerializeField]
			private InteraccionStartParams m_parametros;
		}

		// Token: 0x020001B5 RID: 437
		[Serializable]
		public class AbortingArgs : Interaccion.Args
		{
			// Token: 0x1700026E RID: 622
			// (get) Token: 0x06000CCD RID: 3277 RVA: 0x000393CC File Offset: 0x000375CC
			public bool isAborted
			{
				get
				{
					return this.m_aborted;
				}
			}

			// Token: 0x06000CCE RID: 3278 RVA: 0x000393D4 File Offset: 0x000375D4
			public void Abort()
			{
				this.m_aborted = true;
			}

			// Token: 0x06000CCF RID: 3279 RVA: 0x000393DD File Offset: 0x000375DD
			protected override void OnCleared()
			{
				base.OnCleared();
				this.m_aborted = false;
			}

			// Token: 0x040009A8 RID: 2472
			[ReadOnlyUI]
			[SerializeField]
			private bool m_aborted;
		}
	}
}
