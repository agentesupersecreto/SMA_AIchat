using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Updater;
using com.ootii.Input;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii.Inputs
{
	// Token: 0x02000166 RID: 358
	[RequireComponent(typeof(UnityInputSource))]
	public class SincronizarConPlayerInputs : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060007C8 RID: 1992 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00028793 File Offset: 0x00026993
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_UnityInputSource = base.GetComponent<UnityInputSource>();
			if (this.m_UnityInputSource == null)
			{
				throw new ArgumentNullException("m_UnityInputSource", "m_UnityInputSource null reference.");
			}
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x000287C8 File Offset: 0x000269C8
		public override void OnUpdateEvent1()
		{
			if (this.sincronizarMovement)
			{
				this.m_UnityInputSource.IsMovementEnabled = Singleton<PlayerInputProxy>.instance.movementActivado;
			}
			if (this.sincronizarView)
			{
				this.m_UnityInputSource.IsViewEnabled = Singleton<PlayerInputProxy>.instance.viewActivado;
			}
			ConfiguracionGeneralDeInputs.Axis2D viewMovement = Singleton<ConfiguracionGeneralDeInputs>.instance.viewMovement;
			float num = (viewMovement.active ? viewMovement.sensivilidadGeneral : 0f);
			num *= (float)(viewMovement.inverted ? (-1) : 1);
			this.m_UnityInputSource.ViewXMod = num * viewMovement.sensivilidadX;
			this.m_UnityInputSource.ViewYMod = num * viewMovement.sensivilidadY;
		}

		// Token: 0x04000615 RID: 1557
		public bool sincronizarMovement = true;

		// Token: 0x04000616 RID: 1558
		public bool sincronizarView = true;

		// Token: 0x04000617 RID: 1559
		private UnityInputSource m_UnityInputSource;
	}
}
