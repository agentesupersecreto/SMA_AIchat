using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000AA RID: 170
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTitle")]
	[FontProConfigUI(fontStyle = FontStyles.Bold, alignment = TextAlignmentOptions.Midline)]
	[Panel(height = 375, width = 450, tipo = TipoDePanel.scrollableFlotante)]
	[Serializable]
	public class EntrevistaMainMenuModelo : IModeloBindableOnUIPanel
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000389 RID: 905 RVA: 0x000133C0 File Offset: 0x000115C0
		// (remove) Token: 0x0600038A RID: 906 RVA: 0x000133F8 File Offset: 0x000115F8
		public event Action<EntrevistaMainMenuModelo> startClicked;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600038B RID: 907 RVA: 0x00013430 File Offset: 0x00011630
		// (remove) Token: 0x0600038C RID: 908 RVA: 0x00013468 File Offset: 0x00011668
		public event Action<EntrevistaMainMenuModelo> continueClicked;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600038D RID: 909 RVA: 0x000134A0 File Offset: 0x000116A0
		// (remove) Token: 0x0600038E RID: 910 RVA: 0x000134D8 File Offset: 0x000116D8
		public event Action<EntrevistaMainMenuModelo> singleClicked;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600038F RID: 911 RVA: 0x00013510 File Offset: 0x00011710
		// (remove) Token: 0x06000390 RID: 912 RVA: 0x00013548 File Offset: 0x00011748
		public event Action<EntrevistaMainMenuModelo> designerClicked;

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0001357D File Offset: 0x0001177D
		// (set) Token: 0x06000392 RID: 914 RVA: 0x00013585 File Offset: 0x00011785
		[ActivatedDelegates(para = "Continue")]
		public bool existeSavedGame
		{
			get
			{
				return this.m_existeSavedGame;
			}
			set
			{
				this.m_existeSavedGame = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000393 RID: 915 RVA: 0x0001358E File Offset: 0x0001178E
		// (set) Token: 0x06000394 RID: 916 RVA: 0x00013591 File Offset: 0x00011791
		[ActivatedDelegates(para = "SingleInterview")]
		public bool existenCharacters
		{
			get
			{
				return false;
			}
			set
			{
				this.m_existenCharacters = value;
			}
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0001359A File Offset: 0x0001179A
		[Label("Continue", "US")]
		[ClickableLabel(confirmar = false, enabled = true)]
		public void Continue()
		{
			Action<EntrevistaMainMenuModelo> action = this.continueClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x000135AD File Offset: 0x000117AD
		[Label("Start", "US")]
		[ClickableLabel(confirmar = false, enabled = true)]
		public void Start()
		{
			Action<EntrevistaMainMenuModelo> action = this.startClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000397 RID: 919 RVA: 0x000135C0 File Offset: 0x000117C0
		[Label("Designer (Beta)", "US")]
		[ClickableLabel(confirmar = false)]
		public void DesignerInterview()
		{
			Action<EntrevistaMainMenuModelo> action = this.designerClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x000135D3 File Offset: 0x000117D3
		[Label("Single Interview (Under Reconstruction)", "US")]
		[ClickableLabel(confirmar = false, enabled = false)]
		public void SingleInterview()
		{
			Action<EntrevistaMainMenuModelo> action = this.singleClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x000135E6 File Offset: 0x000117E6
		[Separador]
		[Label("Profile Editor", "US")]
		[ClickableLabel(confirmar = false)]
		public void ProfileEditor()
		{
			Singleton<SimplifiedAutoRatings>.instance.OpenEditor(null);
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600039A RID: 922 RVA: 0x000135F4 File Offset: 0x000117F4
		IUIPanel IModeloBindableOnUIPanel.panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000135FC File Offset: 0x000117FC
		void IModeloBindableOnUIPanel.Bindig()
		{
			int num;
			this.existeSavedGame = GlobalSingletonV2<MemoriaJson>.instance.ExisteDefaultFile(out num);
			this.m_existenCharacters = SaveLoadJson.ExistenCharacters();
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00013626 File Offset: 0x00011826
		void IModeloBindableOnUIPanel.Binded(IUIPanel to)
		{
			this.m_panel = to;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0001362F File Offset: 0x0001182F
		void IModeloBindableOnUIPanel.Clearing()
		{
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00013631 File Offset: 0x00011831
		void IModeloBindableOnUIPanel.Cleared()
		{
			this.m_panel = null;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0001363C File Offset: 0x0001183C
		public string GetTitle()
		{
			return string.Concat(new string[]
			{
				"Some Modeling Agency <color=#800000ff><i><size=-8>",
				MapaSingleton<ConfiguracionGlobal>.instance.buildVersionA,
				".",
				MapaSingleton<ConfiguracionGlobal>.instance.buildVersionB.ToString(),
				"</size></i></color>"
			});
		}

		// Token: 0x0400018C RID: 396
		[SerializeField]
		private bool m_existeSavedGame;

		// Token: 0x0400018D RID: 397
		[SerializeField]
		private bool m_existenCharacters;

		// Token: 0x0400018E RID: 398
		private IUIPanel m_panel;
	}
}
