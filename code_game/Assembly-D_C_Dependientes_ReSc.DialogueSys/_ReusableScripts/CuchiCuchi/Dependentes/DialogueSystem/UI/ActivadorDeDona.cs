using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.UI.Runtime.Globales;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.Miscellaneous.Activables;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI
{
	// Token: 0x02000027 RID: 39
	[Obsolete("usar la version para THS")]
	[RequireComponent(typeof(IUsable))]
	[RequireComponent(typeof(IActivableAndOr))]
	public sealed class ActivadorDeDona : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00006A23 File Offset: 0x00004C23
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00006A28 File Offset: 0x00004C28
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

		// Token: 0x06000154 RID: 340 RVA: 0x00006A83 File Offset: 0x00004C83
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_usable.onUsado += this.M_usable_onUsado;
			if (Singleton<MainPanelGameOptions>.existeEnScena)
			{
				this.m_canShowConfigMenu = Singleton<MainPanelGameOptions>.instance.canShowModificable.ObtenerModificadorNotNull(this);
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00006ABF File Offset: 0x00004CBF
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

		// Token: 0x06000156 RID: 342 RVA: 0x00006AF4 File Offset: 0x00004CF4
		public override void OnUpdateEvent1()
		{
			if (this.flagToEnableConfigPanel)
			{
				this.flagToEnableConfigPanel = false;
				if (this.m_canShowConfigMenu != null)
				{
					this.m_canShowConfigMenu.valor.valor = true;
				}
			}
			if (this.opcionesDeDona == null || !this.opcionesDeDona.isDrawing)
			{
				this.flagToEnableConfigPanel = true;
				return;
			}
			if ((!this.m_activator.currentEstado || Singleton<PlayerInputProxy>.instance.virtualesUI.canceled || (!Singleton<PlayerInputProxy>.instance.fire2.wasHeldDown && Singleton<PlayerInputProxy>.instance.fire2.clickedUp && Mathf.Abs(Singleton<PlayerInputProxy>.instance.cameraView.MouseXAxis) < 0.1f && Mathf.Abs(Singleton<PlayerInputProxy>.instance.cameraView.MouseYAxis) < 0.1f) || Singleton<MainDialogueSystemEvents>.instance.enConversacion) && this.opcionesDeDona.dona.currentUser.transform.IsChildOf(this.opcionesDeDona.transform))
			{
				this.opcionesDeDona.Hide();
				this.flagToEnableConfigPanel = true;
				return;
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00006C08 File Offset: 0x00004E08
		private void M_usable_onUsado(Transform obj)
		{
			if (this.opcionesDeDona == null || (Singleton<MainPanelGameOptions>.existeEnScena && Singleton<MainPanelGameOptions>.instance.isShowing))
			{
				return;
			}
			if (this.m_canShowConfigMenu != null)
			{
				this.m_canShowConfigMenu.valor.valor = false;
			}
			this.flagToEnableConfigPanel = false;
			this.opcionesDeDona.Show();
		}

		// Token: 0x040000AE RID: 174
		public LoaderOpcionesDeDonaBase opcionesDeDona;

		// Token: 0x040000AF RID: 175
		private IActivableAndOr m_activator;

		// Token: 0x040000B0 RID: 176
		private IUsable m_usable;

		// Token: 0x040000B1 RID: 177
		[SerializeField]
		private ModificadorDeBool m_canShowConfigMenu;

		// Token: 0x040000B2 RID: 178
		[NonSerialized]
		private bool flagToEnableConfigPanel;
	}
}
