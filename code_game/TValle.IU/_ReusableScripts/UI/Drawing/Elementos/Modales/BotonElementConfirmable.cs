using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using TMPro;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Modales
{
	// Token: 0x02000096 RID: 150
	public class BotonElementConfirmable : BotonElementBase, IUIElementoConAccionName, IUIElemento, IUIElementoConfirmable, IUIElementoConLabel
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00014206 File Offset: 0x00012406
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.labelV2;
			}
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0001420E File Offset: 0x0001240E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.labelV2 == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x00014234 File Offset: 0x00012434
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x0001423C File Offset: 0x0001243C
		string IUIElementoConAccionName.accionName
		{
			get
			{
				return this.confirmableAccionName;
			}
			set
			{
				this.confirmableAccionName = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x00014245 File Offset: 0x00012445
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x0001424D File Offset: 0x0001244D
		bool IUIElementoConfirmable.confirmar
		{
			get
			{
				return this.confirmableV2;
			}
			set
			{
				this.confirmableV2 = value;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00014256 File Offset: 0x00012456
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x0001425E File Offset: 0x0001245E
		string IUIElementoConfirmable.confirmarText
		{
			get
			{
				return this.confirmableText;
			}
			set
			{
				this.confirmableText = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00014267 File Offset: 0x00012467
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x0001426F File Offset: 0x0001246F
		ConfirmacionHandler IUIElementoConfirmable.confirmarDelegate
		{
			get
			{
				return this.m_confirmacionDelegado;
			}
			set
			{
				this.m_confirmacionDelegado = value;
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00014278 File Offset: 0x00012478
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.Clear();
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00014287 File Offset: 0x00012487
		private void Clear()
		{
			if (Singleton<ModalWindow>.IsInScene)
			{
				Singleton<ModalWindow>.instance.Clear(this.m_confirmancoPanel);
			}
			this.m_confirmancoPanel = null;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000142A7 File Offset: 0x000124A7
		private void OnConfirmado(bool eraConfirmable)
		{
			if (eraConfirmable)
			{
				this.Clear();
			}
			if (this.m_confirmancoPanel != null && this.m_confirmancoPanel.userNoQuiereVerNuevamente)
			{
				Singleton<ModalWindow>.instance.IgnorandoConfirmacion(this.confirmableAccionName);
			}
			base.CallEvents();
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x000142E8 File Offset: 0x000124E8
		protected override void OnElementoClicked()
		{
			try
			{
				string text = null;
				bool flag = this.confirmableV2 && Singleton<ModalWindow>.IsInScene && !Singleton<ModalWindow>.instance.EstaIgnorandoConfirmacion(this.confirmableAccionName) && (this.m_confirmacionDelegado == null || this.m_confirmacionDelegado(out text));
				if (flag)
				{
					this.Clear();
					this.m_confirmancoPanel = Singleton<ModalWindow>.instance.MostrarConfirmacion();
					if (!string.IsNullOrWhiteSpace(text))
					{
						this.m_confirmancoPanel.pregunta.text = text;
					}
					else if (!string.IsNullOrWhiteSpace(this.confirmableText))
					{
						this.m_confirmancoPanel.pregunta.text = this.confirmableText;
					}
					this.m_confirmancoPanel.accionName = this.confirmableAccionName;
					this.m_confirmancoPanel.aceptar.onClick.AddListener(delegate
					{
						this.OnConfirmado(true);
					});
					this.m_confirmancoPanel.cancelar.onClick.AddListener(delegate
					{
						this.Clear();
					});
					if (string.IsNullOrWhiteSpace(this.confirmableAccionName))
					{
						this.m_confirmancoPanel.noMostrarOtraVezToggle.interactable = false;
					}
				}
				else
				{
					this.OnConfirmado(flag);
				}
			}
			catch (Exception ex)
			{
				Singleton<ModalWindow>.instance.Clear<ConfirmacionMiembros>();
				Debug.LogException(ex, this);
				this.Clear();
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00014448 File Offset: 0x00012648
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00014450 File Offset: 0x00012650
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040001DF RID: 479
		public TextMeshProUGUI labelV2;

		// Token: 0x040001E0 RID: 480
		public bool confirmableV2;

		// Token: 0x040001E1 RID: 481
		public string confirmableText;

		// Token: 0x040001E2 RID: 482
		public string confirmableAccionName;

		// Token: 0x040001E3 RID: 483
		[SerializeField]
		[ReadOnlyUI]
		private ConfirmacionMiembros m_confirmancoPanel;

		// Token: 0x040001E4 RID: 484
		private ConfirmacionHandler m_confirmacionDelegado;
	}
}
