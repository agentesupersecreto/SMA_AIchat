using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles.UI
{
	// Token: 0x0200001F RID: 31
	[LabelLocalizado("Profile Editor", "US")]
	[Modelo]
	[Panel(tipo = TipoDePanel.autoRatingPortraitEditor)]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[HelpPanelControl(listiner = "ShowGuide")]
	[Serializable]
	public class AutoRatingProfileModel : BindableModel
	{
		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000139 RID: 313 RVA: 0x00007164 File Offset: 0x00005364
		// (remove) Token: 0x0600013A RID: 314 RVA: 0x0000719C File Offset: 0x0000539C
		public event Action<IUIElementoConValor, AutoRatingProfileModel> onChanged;

		// Token: 0x0600013B RID: 315 RVA: 0x000071D1 File Offset: 0x000053D1
		[ModelValueChangedListener(escucharTodosLosElementosAnteriores = true)]
		public void OnModelChanged(IUIElementoConValor elemento)
		{
			Action<IUIElementoConValor, AutoRatingProfileModel> action = this.onChanged;
			if (action == null)
			{
				return;
			}
			action(elemento, this);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000071E8 File Offset: 0x000053E8
		public void ShowGuide()
		{
			InfoDialog modalPanel = Singleton<ModalWindow>.instance.MostrarBigInfoDialog();
			modalPanel.pregunta.text = "Create or load a profile for the upcoming campaign; the higher the campaign tier, the closer the models will resemble the profile.";
			modalPanel.aceptar.onClick.AddListener(delegate
			{
				if (Singleton<ModalWindow>.IsInScene)
				{
					Singleton<ModalWindow>.instance.Clear(modalPanel);
				}
			});
		}

		// Token: 0x040000C0 RID: 192
		[Ignore]
		public int modo;

		// Token: 0x040000C1 RID: 193
		[Modelo]
		[Panel(tipo = TipoDePanel.nestedContainer)]
		public object fieldsDeModo;
	}
}
