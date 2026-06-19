using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos
{
	// Token: 0x0200010E RID: 270
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainer)]
	[Serializable]
	public class DetallesDeItemModelo
	{
		// Token: 0x14000038 RID: 56
		// (add) Token: 0x0600080A RID: 2058 RVA: 0x0001C0E0 File Offset: 0x0001A2E0
		// (remove) Token: 0x0600080B RID: 2059 RVA: 0x0001C118 File Offset: 0x0001A318
		public event Action<DetallesDeItemModelo> accion1;

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x0001C14D File Offset: 0x0001A34D
		[ActivatedDelegates(para = "Accion1")]
		public bool isAccion1Enabled
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.ID);
			}
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0001C15D File Offset: 0x0001A35D
		public string GetTittle()
		{
			return this.nombre;
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0001C165 File Offset: 0x0001A365
		public string GetAccion1Label()
		{
			return this.accion1Label;
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0001C16D File Offset: 0x0001A36D
		[Order(3)]
		[BotonDePanelConfirmable(confirmar = true)]
		[LabelDinamico(dinamicoMethodTarget = "GetAccion1Label")]
		[AccionName("ACCION 1 DE DETALLES")]
		[ConfirmablePregunta("Are you sure you want to do this?", "US")]
		public void Accion1()
		{
			Action<DetallesDeItemModelo> action = this.accion1;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0001C180 File Offset: 0x0001A380
		[ConfirmableListener(member = "Accion1")]
		protected bool Accion1ConfirmacionDelegado(out string pregunta)
		{
			if (!string.IsNullOrWhiteSpace(this.accion1ConfirmacionPregunta))
			{
				pregunta = this.accion1ConfirmacionPregunta;
			}
			else
			{
				pregunta = null;
			}
			return true;
		}

		// Token: 0x0400031F RID: 799
		[Ignore]
		public string ID;

		// Token: 0x04000320 RID: 800
		[Ignore]
		public string accion1Label = "Accion 1";

		// Token: 0x04000321 RID: 801
		[Ignore]
		public string accion1ConfirmacionPregunta;

		// Token: 0x04000322 RID: 802
		[Ignore]
		public string nombre = "---";

		// Token: 0x04000323 RID: 803
		[Order(0)]
		[FontProConfigUI(fontSizeMod = 0.75f, alignment = TextAlignmentOptions.Center, fontStyle = FontStyles.Italic)]
		[LayoutConfigUI(heightMod = 0.5f)]
		public string subTitle = "--";

		// Token: 0x04000324 RID: 804
		[Order(1)]
		[TextArea]
		[LayoutConfigUI(height = 150, topPadding = 5, leftPadding = 20)]
		[FontProConfigUI(alignment = TextAlignmentOptions.TopLeft)]
		public string descripcion = "---------------";

		// Token: 0x04000325 RID: 805
		[Order(2)]
		[Modelo]
		public SubDetallesDeItemModelo subDetallesDeItemModelo = new SubDetallesDeItemModelo();
	}
}
