using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Handlers
{
	// Token: 0x020000F4 RID: 244
	[RequireComponent(typeof(Interaccion))]
	public class InteractionExecuteWhile : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x00029910 File Offset: 0x00027B10
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.m_updateType);
			}
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0002991D File Offset: 0x00027B1D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponent<Interaccion>();
			base.SetManualStart();
			base.SetInicializable();
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x00029940 File Offset: 0x00027B40
		public void Init<T_Args>(GlobalUpdater.UpdateType updateType, T_Args argumentos, Func<Interaccion, T_Args, bool> whileDelegate, float interval)
		{
			if (base.isInitiated)
			{
				throw new InvalidOperationException("handler YA estaba iniciado");
			}
			if (this.m_Interaccion == null)
			{
				throw new ArgumentNullException("interaccion", "interaccion null reference.");
			}
			if (whileDelegate == null)
			{
				throw new ArgumentNullException("whileDelegate", "whileDelegate null reference.");
			}
			if (whileDelegate.Target == null)
			{
				throw new ArgumentNullException("Target", "delegado NO puede ser anonimo.");
			}
			this.m_updateType = updateType;
			this.m_CoolDown = new CoolDown(interval);
			this.m_iterator = this.InteractionExecuteWhileCoroutine<T_Args>(this.m_Interaccion, argumentos, whileDelegate);
			this.m_CoolDown.Apply();
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x000299E8 File Offset: 0x00027BE8
		public override void OnUpdateEvent1()
		{
			if (this.m_CoolDown.isOn)
			{
				return;
			}
			this.m_CoolDown.Apply();
			if (!this.m_iterator.MoveNext() || !this.m_iterator.Current)
			{
				if (this.debugLog)
				{
					Debug.Log("Deteniendo interaccion y destruyendo handler", this);
				}
				Interaccion interaccion = this.m_Interaccion;
				if (interaccion != null)
				{
					interaccion.Detener(false);
				}
				Object.Destroy(this);
			}
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00029A53 File Offset: 0x00027C53
		private IEnumerator<bool> InteractionExecuteWhileCoroutine<T_Args>(Interaccion interaccion, T_Args argumentos, Func<Interaccion, T_Args, bool> whileDelegate)
		{
			for (;;)
			{
				if (!((interaccion != null) ? new bool?(interaccion.ejecutandose) : null).GetValueOrDefault())
				{
					if (this.debugLog)
					{
						Debug.Log("Interaccion NO puede seguir ejecutando: Interaccion es null", this);
					}
					yield return false;
				}
				if (whileDelegate.Target == null)
				{
					if (this.debugLog)
					{
						Debug.Log("Interaccion NO puede seguir ejecutando: Target es null", this);
					}
					yield return false;
				}
				bool flag = whileDelegate(interaccion, argumentos);
				if (this.debugLog)
				{
					if (!flag)
					{
						Debug.Log("Interaccion NO puede seguir ejecutando: Delegado NO lo permitio", this);
					}
					else
					{
						Debug.Log("Interaccion SI puede seguir ejecutando: Delegado SI lo permitio", this);
					}
				}
				yield return flag;
			}
			yield break;
		}

		// Token: 0x040005B9 RID: 1465
		public bool debugLog;

		// Token: 0x040005BA RID: 1466
		[ReadOnlyUI]
		[SerializeField]
		private GlobalUpdater.UpdateType m_updateType;

		// Token: 0x040005BB RID: 1467
		private Interaccion m_Interaccion;

		// Token: 0x040005BC RID: 1468
		[ReadOnlyUI]
		[SerializeField]
		private CoolDown m_CoolDown;

		// Token: 0x040005BD RID: 1469
		private IEnumerator<bool> m_iterator;
	}
}
