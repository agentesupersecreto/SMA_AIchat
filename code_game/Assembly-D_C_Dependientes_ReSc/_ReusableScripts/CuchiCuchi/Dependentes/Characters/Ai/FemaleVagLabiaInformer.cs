using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Chains.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Ai
{
	// Token: 0x020002A8 RID: 680
	[Obsolete]
	public class FemaleVagLabiaInformer : FemaleInformer, IZonaErogenaInformer
	{
		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x0600119B RID: 4507 RVA: 0x00053D58 File Offset: 0x00051F58
		public float frameMovement
		{
			get
			{
				if (!this.estabilizado)
				{
					return 0f;
				}
				return this.m_VagLabiaController.l.collector.stepData.localCenterMovement + this.m_VagLabiaController.r.collector.stepData.localCenterMovement;
			}
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x0600119C RID: 4508 RVA: 0x00023905 File Offset: 0x00021B05
		public ZonaErogenaSensibilidad sensibilidad
		{
			get
			{
				return ZonaErogenaSensibilidad.muyAlta;
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x0600119D RID: 4509 RVA: 0x000066E1 File Offset: 0x000048E1
		public ZonaErogenaPrivacidad privacidad
		{
			get
			{
				return ZonaErogenaPrivacidad.alta;
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x0600119E RID: 4510 RVA: 0x00053DA8 File Offset: 0x00051FA8
		public ZonaErogenaMaxPlacer maxPlacer
		{
			get
			{
				return ZonaErogenaMaxPlacer.alto;
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x0600119F RID: 4511 RVA: 0x00053DAC File Offset: 0x00051FAC
		public ZonaErogenaUbicacion ubicacion
		{
			get
			{
				return ZonaErogenaUbicacion.entrepierna;
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x060011A0 RID: 4512 RVA: 0x00053DAF File Offset: 0x00051FAF
		public Vector3 worldPosition
		{
			get
			{
				return this.m_VagController.vagHoleController.hole.centroDePuntos.position;
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x060011A1 RID: 4513 RVA: 0x00053DCB File Offset: 0x00051FCB
		public Vector3 worldNormal
		{
			get
			{
				return this.m_VagController.vagHoleController.hole.worldOutHoleDirection;
			}
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x00053DE4 File Offset: 0x00051FE4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_VagLabiaController = this.m_FemaleChar.GetComponentInChildren<VagLabiaController>();
			this.m_VagController = this.m_FemaleChar.GetComponentInChildren<VagController>();
			if (this.m_VagLabiaController == null)
			{
				throw new ArgumentNullException("m_VagLabiaController", "m_VagLabiaController null reference.");
			}
			if (this.m_VagController == null)
			{
				throw new ArgumentNullException("m_VagController", "m_VagController null reference.");
			}
			GlobalUpdater.instancia.Invokar(delegate
			{
				this.estabilizado = true;
			}, 2f);
		}

		// Token: 0x04000CFA RID: 3322
		private VagLabiaController m_VagLabiaController;

		// Token: 0x04000CFB RID: 3323
		private VagController m_VagController;

		// Token: 0x04000CFC RID: 3324
		private bool estabilizado;
	}
}
