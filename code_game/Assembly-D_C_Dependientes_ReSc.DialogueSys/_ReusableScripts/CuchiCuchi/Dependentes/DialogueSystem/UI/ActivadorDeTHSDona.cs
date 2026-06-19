using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.UI.Runtime.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.Miscellaneous.Activables;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI
{
	// Token: 0x02000028 RID: 40
	public class ActivadorDeTHSDona : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000159 RID: 345 RVA: 0x00006C6D File Offset: 0x00004E6D
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00006C70 File Offset: 0x00004E70
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_usable = base.GetComponent<IUsable>();
			if (this.m_usable == null)
			{
				throw new ArgumentNullException("m_usable", "m_usable null reference.");
			}
			this.m_activator = base.GetComponent<IActivableAndOr>();
			if (this.m_activator == null)
			{
				throw new ArgumentNullException("m_activator", "m_activator null reference.");
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00006CCB File Offset: 0x00004ECB
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_usable.onUsado += this.M_usable_onUsado;
			if (Singleton<MainPanelGameOptions>.existeEnScena)
			{
				this.m_canShowConfigMenu = Singleton<MainPanelGameOptions>.instance.canShowModificable.ObtenerModificadorNotNull(this);
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00006D07 File Offset: 0x00004F07
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_usable.onUsado -= this.M_usable_onUsado;
			ModificadorDeBool canShowConfigMenu = this.m_canShowConfigMenu;
			if (canShowConfigMenu == null)
			{
				return;
			}
			canShowConfigMenu.TryRemoverDeOwner(true);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00006D3C File Offset: 0x00004F3C
		public override void OnUpdateEvent1()
		{
			if (this.flagToEnableConfigPanel)
			{
				this.flagToEnableConfigPanel = false;
				this.ChangeCanShowPanel(true);
			}
			if (!THSDonaController.instance.enUso || this.ownOpciones == null)
			{
				this.flagToEnableConfigPanel = true;
				return;
			}
			if (!THSDonaController.instance.currentUser.transform.IsChildOf(this.ownOpciones.transform))
			{
				return;
			}
			try
			{
				if (!this.m_activator.currentEstado || Singleton<MainDialogueSystemEvents>.instance.enConversacion)
				{
					THSDonaController.instance.StopDrawing();
					this.flagToEnableConfigPanel = true;
				}
				else if (Singleton<PlayerInputProxy>.instance.virtualesUI.canceled || (!Singleton<PlayerInputProxy>.instance.fire2.wasHeldDown && Singleton<PlayerInputProxy>.instance.fire2.clickedUp && Mathf.Abs(Singleton<PlayerInputProxy>.instance.cameraView.MouseXAxis) < 0.1f && Mathf.Abs(Singleton<PlayerInputProxy>.instance.cameraView.MouseYAxis) < 0.1f))
				{
					THSDonaController.instance.EmulateGoBack();
					this.flagToEnableConfigPanel = true;
				}
			}
			finally
			{
				this.ChangeCanShowPanel(false);
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00006E70 File Offset: 0x00005070
		private void ChangeCanShowPanel(bool canShow)
		{
			if (this.m_canShowConfigMenu != null)
			{
				this.m_canShowConfigMenu.valor.valor = canShow;
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00006E8C File Offset: 0x0000508C
		private void M_usable_onUsado(Transform obj)
		{
			if (this.ownOpciones == null || (Singleton<MainPanelGameOptions>.existeEnScena && Singleton<MainPanelGameOptions>.instance.isShowing))
			{
				return;
			}
			this.ChangeCanShowPanel(false);
			this.flagToEnableConfigPanel = false;
			this.ownOpciones.Draw(null);
		}

		// Token: 0x040000B3 RID: 179
		public LoaderDeTHSDona ownOpciones;

		// Token: 0x040000B4 RID: 180
		private IActivableAndOr m_activator;

		// Token: 0x040000B5 RID: 181
		private IUsable m_usable;

		// Token: 0x040000B6 RID: 182
		[SerializeField]
		private ModificadorDeBool m_canShowConfigMenu;

		// Token: 0x040000B7 RID: 183
		[NonSerialized]
		private bool flagToEnableConfigPanel;
	}
}
