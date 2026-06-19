using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x02000087 RID: 135
	[Panel(tipo = TipoDePanel.panel1by1, height = 1000, width = 800)]
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.Midline, color = ColorEnum.white)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Serializable]
	public class DesignerEditApparenceModel : BindableModel
	{
		// Token: 0x06000291 RID: 657 RVA: 0x0000F73E File Offset: 0x0000D93E
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000292 RID: 658 RVA: 0x0000F748 File Offset: 0x0000D948
		// (remove) Token: 0x06000293 RID: 659 RVA: 0x0000F780 File Offset: 0x0000D980
		public event Action<DesignerEditApparenceModel> onDoneClicked;

		// Token: 0x06000294 RID: 660 RVA: 0x0000F7B5 File Offset: 0x0000D9B5
		[Label("Done", "US")]
		[BotonDePanel]
		public void Done()
		{
			Action<DesignerEditApparenceModel> action = this.onDoneClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000F7C8 File Offset: 0x0000D9C8
		protected override void Bindig()
		{
			base.Bindig();
			this.holdersModel.LoadElements();
		}

		// Token: 0x04000114 RID: 276
		[Ignore]
		[NonSerialized]
		public string title = "Apparence";

		// Token: 0x04000116 RID: 278
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public DesignerEditApparenceHoldersModel holdersModel = new DesignerEditApparenceHoldersModel();

		// Token: 0x04000117 RID: 279
		[Modelo]
		[ParentPanelTarget(index = 1)]
		public DesignerEditApparenceAlteratorsModel alteratorsModel = new DesignerEditApparenceAlteratorsModel();
	}
}
