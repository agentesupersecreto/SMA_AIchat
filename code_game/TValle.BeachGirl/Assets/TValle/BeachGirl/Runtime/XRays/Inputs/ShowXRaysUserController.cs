using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Clases;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.XRays.Inputs
{
	// Token: 0x0200005F RID: 95
	[RequireComponent(typeof(XRaysParaFemaleCharacter))]
	public sealed class ShowXRaysUserController : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00003C49 File Offset: 0x00001E49
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00003C51 File Offset: 0x00001E51
		public ModificableDeBool puedeMostrarXRaysAND
		{
			get
			{
				return this.m_puedeMostrarXRaysAND;
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00003C59 File Offset: 0x00001E59
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_XRaysParaFemaleCharacter = base.GetComponent<XRaysParaFemaleCharacter>();
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00003C70 File Offset: 0x00001E70
		public sealed override void OnUpdateEvent1()
		{
			InputProxyVirtuales characterActions = Singleton<PlayerInputProxy>.instance.characterActions;
			if (characterActions.tooled9)
			{
				if (this.m_puedeMostrarXRaysAND.And(true))
				{
					this.m_XRaysParaFemaleCharacter.ChangePelvis(false, -1);
					this.m_XRaysParaFemaleCharacter.ToggleBoca();
				}
				else
				{
					this.m_XRaysParaFemaleCharacter.ChangePelvis(false, -1);
					this.m_XRaysParaFemaleCharacter.ChangeBoca(false);
				}
			}
			if (characterActions.tooled10)
			{
				if (this.m_puedeMostrarXRaysAND.And(true))
				{
					this.m_XRaysParaFemaleCharacter.ChangeBoca(false);
					this.m_XRaysParaFemaleCharacter.TogglePelvis();
					return;
				}
				this.m_XRaysParaFemaleCharacter.ChangePelvis(false, -1);
				this.m_XRaysParaFemaleCharacter.ChangeBoca(false);
			}
		}

		// Token: 0x04000111 RID: 273
		private XRaysParaFemaleCharacter m_XRaysParaFemaleCharacter;

		// Token: 0x04000112 RID: 274
		[SerializeField]
		private ModificableDeBool m_puedeMostrarXRaysAND = new ModificableDeBool(true);
	}
}
