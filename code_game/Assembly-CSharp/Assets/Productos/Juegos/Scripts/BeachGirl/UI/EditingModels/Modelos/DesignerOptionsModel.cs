using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x02000091 RID: 145
	[Panel(height = 500)]
	[Modelo]
	[Label("Designer", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Serializable]
	public class DesignerOptionsModel
	{
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060002E7 RID: 743 RVA: 0x000107D4 File Offset: 0x0000E9D4
		// (remove) Token: 0x060002E8 RID: 744 RVA: 0x0001080C File Offset: 0x0000EA0C
		public event Action<DesignerOptionsModel> editApparenceClicked;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060002E9 RID: 745 RVA: 0x00010844 File Offset: 0x0000EA44
		// (remove) Token: 0x060002EA RID: 746 RVA: 0x0001087C File Offset: 0x0000EA7C
		public event Action<DesignerOptionsModel> editOutfitClicked;

		// Token: 0x060002EB RID: 747 RVA: 0x000108B1 File Offset: 0x0000EAB1
		[Label("Retouch her appearance.", "US")]
		[AccionName("EditAppearance")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void EditAppearance()
		{
			Action<DesignerOptionsModel> action = this.editApparenceClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000108C4 File Offset: 0x0000EAC4
		[Label("Retouch her personality.(Under Construction)", "US")]
		[AccionName("EditPersonality")]
		[ClickableLabelDescriptable(confirmar = false, enabled = false)]
		public void EditPersonality()
		{
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000108C6 File Offset: 0x0000EAC6
		[Separador]
		[Label("Edit Outfit.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void EditOutfit()
		{
			Action<DesignerOptionsModel> action = this.editOutfitClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}
	}
}
