using System;
using System.Collections.Generic;
using Assets.Base.RootMotion.BeachGirl.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001DA RID: 474
	[RequireComponent(typeof(PoseQueExponePartes))]
	public class PoseQueExponePartesVestidas : CustomMonobehaviour
	{
		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x0003778C File Offset: 0x0003598C
		public IReadOnlyList<ParteDelCuerpoHumano> newPartsBeingExposed
		{
			get
			{
				return this.m_NewPartsBeingExposed;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000B40 RID: 2880 RVA: 0x00037794 File Offset: 0x00035994
		public IReadOnlyList<ParteDelCuerpoHumano> currentPartesSiendoExpuestas
		{
			get
			{
				return this.m_currentPartesSiendoExpuestas;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x0003779C File Offset: 0x0003599C
		public IReadOnlyList<ParteDelCuerpoHumano> sessionPartsBeingExposed
		{
			get
			{
				return this.m_sessionPartsBeingExposed;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000B42 RID: 2882 RVA: 0x000377A4 File Offset: 0x000359A4
		public bool isInSession
		{
			get
			{
				return this.m_resetSessionCoolDown.isOn;
			}
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x000377B4 File Offset: 0x000359B4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PoseQueExponePartes = base.GetComponent<PoseQueExponePartes>();
			if (this.m_PoseQueExponePartes == null)
			{
				throw new ArgumentNullException("m_PoseQueExponePartes", "m_PoseQueExponePartes null reference.");
			}
			this.m_ropaManager = this.GetComponentEnRoot(false);
			if (this.m_ropaManager == null)
			{
				throw new ArgumentNullException("m_ropaManager", "m_ropaManager null reference.");
			}
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x00037818 File Offset: 0x00035A18
		private void updatePartsBeingExposed()
		{
			this.m_PoseQueExponePartes.UpdateCurrentExposingPartes();
			this.m_currentPartesSiendoExpuestas.Clear();
			this.m_currentPartesSiendoExpuestasSet.Clear();
			this.m_ropaManager.TransferirCorregiendoPartesExpuestasSiEstanVestidas(this.m_PoseQueExponePartes.exponiendoPartes, this.m_currentPartesSiendoExpuestas, this.m_currentPartesSiendoExpuestasSet);
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x00037868 File Offset: 0x00035A68
		private void updateLastPartsBeingExposed()
		{
			this.m_lastPartesSiendoExpuestasSet.Clear();
			for (int i = 0; i < this.m_currentPartesSiendoExpuestas.Count; i++)
			{
				this.m_lastPartesSiendoExpuestasSet.Add((int)this.m_currentPartesSiendoExpuestas[i]);
			}
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x000378AE File Offset: 0x00035AAE
		public void UpdateInitialPartsBeingExposed()
		{
			if (this.isInSession)
			{
				Debug.LogError("se intento actualizar las partes expuestas estando en session");
				return;
			}
			this.updatePartsBeingExposed();
			this.updateLastPartsBeingExposed();
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x000378D0 File Offset: 0x00035AD0
		public void UpdateNewPartsBeingExposed()
		{
			if (this.isInSession)
			{
				Debug.LogError("se intento actualizar las partes expuestas estando en session");
				return;
			}
			this.updatePartsBeingExposed();
			this.m_NewPartsBeingExposed.Clear();
			for (int i = 0; i < this.m_currentPartesSiendoExpuestas.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = this.m_currentPartesSiendoExpuestas[i];
				if (!this.m_lastPartesSiendoExpuestasSet.Contains((int)parteDelCuerpoHumano))
				{
					this.m_NewPartsBeingExposed.Add(parteDelCuerpoHumano);
				}
			}
			this.updateLastPartsBeingExposed();
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00037944 File Offset: 0x00035B44
		public void UpdateSessionPartsBeingExposed()
		{
			if (!this.isInSession)
			{
				Debug.LogError("se intento actualizar las session partes expuestas no estando en session");
				return;
			}
			this.updatePartsBeingExposed();
			this.m_sessionPartsBeingExposed.Clear();
			for (int i = 0; i < this.m_currentPartesSiendoExpuestas.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = this.m_currentPartesSiendoExpuestas[i];
				if (!this.m_lastPartesSiendoExpuestasSet.Contains((int)parteDelCuerpoHumano))
				{
					this.m_sessionPartsBeingExposed.Add(parteDelCuerpoHumano);
				}
			}
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x000379B2 File Offset: 0x00035BB2
		public void StartOrStaySession()
		{
			this.m_resetSessionCoolDown.Apply();
			this.UpdateSessionPartsBeingExposed();
			this.m_sessionNeedToEnd = true;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x000379CC File Offset: 0x00035BCC
		public void TryEndSession(bool force)
		{
			if (force)
			{
				this.m_resetSessionCoolDown.Clear();
				this.m_resetSessionCoolDown.SetDefault(0.666f);
				this.m_sessionNeedToEnd = true;
			}
			if (this.m_sessionNeedToEnd && !this.isInSession)
			{
				this.m_sessionNeedToEnd = false;
				this.UpdateInitialPartsBeingExposed();
			}
		}

		// Token: 0x04000879 RID: 2169
		private HashSet<int> m_lastPartesSiendoExpuestasSet = new HashSet<int>();

		// Token: 0x0400087A RID: 2170
		[ReadOnlyUI]
		[SerializeField]
		private List<ParteDelCuerpoHumano> m_currentPartesSiendoExpuestas = new List<ParteDelCuerpoHumano>();

		// Token: 0x0400087B RID: 2171
		private HashSet<int> m_currentPartesSiendoExpuestasSet = new HashSet<int>();

		// Token: 0x0400087C RID: 2172
		[ReadOnlyUI]
		[SerializeField]
		private List<ParteDelCuerpoHumano> m_NewPartsBeingExposed = new List<ParteDelCuerpoHumano>();

		// Token: 0x0400087D RID: 2173
		[ReadOnlyUI]
		[SerializeField]
		private List<ParteDelCuerpoHumano> m_sessionPartsBeingExposed = new List<ParteDelCuerpoHumano>();

		// Token: 0x0400087E RID: 2174
		private IRopaManager m_ropaManager;

		// Token: 0x0400087F RID: 2175
		private PoseQueExponePartes m_PoseQueExponePartes;

		// Token: 0x04000880 RID: 2176
		private CoolDown m_resetSessionCoolDown = new CoolDown(0.666f);

		// Token: 0x04000881 RID: 2177
		private bool m_sessionNeedToEnd;
	}
}
