using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Updater;
using com.ootii.Input;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii.Inputs
{
	// Token: 0x02000167 RID: 359
	[RequireComponent(typeof(UnityInputSource))]
	public class UnityInputSourceEmulable : CustomUpdatedMonobehaviourBase, IEmulableMovementInputs
	{
		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0002887C File Offset: 0x00026A7C
		public ModificableDeFloat xValorPromedio
		{
			get
			{
				return Singleton<PlayerInputProxy>.instance.emulables.xValorPromedio;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060007CE RID: 1998 RVA: 0x00023F85 File Offset: 0x00022185
		public ModificableDeFloat yValorPromedio
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0002888D File Offset: 0x00026A8D
		public ModificableDeFloat zValorPromedio
		{
			get
			{
				return Singleton<PlayerInputProxy>.instance.emulables.zValorPromedio;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x0002889E File Offset: 0x00026A9E
		public ModificableDeBool isGoingFaster
		{
			get
			{
				return Singleton<PlayerInputProxy>.instance.emulables.isGoingFaster;
			}
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x000288AF File Offset: 0x00026AAF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_UnityInputSource = base.GetComponent<UnityInputSource>();
			if (this.m_UnityInputSource == null)
			{
				throw new ArgumentNullException("m_UnityInputSource", "m_UnityInputSource null reference.");
			}
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x000288E4 File Offset: 0x00026AE4
		public override void OnUpdateEvent1()
		{
			this.m_UnityInputSource.emulatedXMovement = Mathf.Clamp(this.xValorPromedio.PromediarSinValor(), -1f, 1f);
			this.m_UnityInputSource.emulatedYMovement = Mathf.Clamp(this.zValorPromedio.PromediarSinValor(), -1f, 1f);
			this.m_UnityInputSource.emulatedIsGoingFaster = this.isGoingFaster.Or(false);
		}

		// Token: 0x04000618 RID: 1560
		private UnityInputSource m_UnityInputSource;
	}
}
