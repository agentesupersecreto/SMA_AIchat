using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using TMPro;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000013 RID: 19
	[Label("Female Rating", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.Midline)]
	[IconPanelControl(listiner = "RedoAutoRating", toolTip = "Re Apply Auto Ratings (if possible)")]
	[HelpPanelControl(listiner = "ShowGuide")]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Panel(height = 950, width = 410)]
	[Modelo]
	[Serializable]
	public class EstrevistaRatingModelo
	{
		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060000DA RID: 218 RVA: 0x00005364 File Offset: 0x00003564
		// (remove) Token: 0x060000DB RID: 219 RVA: 0x0000539C File Offset: 0x0000359C
		public event Action<EstrevistaRatingModelo> onDoneClicked;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060000DC RID: 220 RVA: 0x000053D4 File Offset: 0x000035D4
		// (remove) Token: 0x060000DD RID: 221 RVA: 0x0000540C File Offset: 0x0000360C
		public event Action<EstrevistaRatingModelo> onConfirmarDone;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x060000DE RID: 222 RVA: 0x00005444 File Offset: 0x00003644
		// (remove) Token: 0x060000DF RID: 223 RVA: 0x0000547C File Offset: 0x0000367C
		public event Action<EstrevistaRatingModelo> onRedoAutoRating;

		// Token: 0x060000E0 RID: 224 RVA: 0x000054B1 File Offset: 0x000036B1
		[Obsolete("", true)]
		public float Score()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000054B8 File Offset: 0x000036B8
		[Label("Done", "US")]
		[BotonDePanelConfirmable(confirmar = true)]
		[AccionName("LeaveWithoutRating")]
		[ConfirmablePregunta("<B>Do you want to return without giving a rating?</B>\n<i><size=11>It is Ok To Ignore, the minimum score will be assigned automatically.</size></i>", "US")]
		public void Done()
		{
			Action<EstrevistaRatingModelo> action = this.onDoneClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000054CB File Offset: 0x000036CB
		[ConfirmableListener(member = "Done")]
		public bool ConfirmarDone(out string msg)
		{
			msg = null;
			Action<EstrevistaRatingModelo> action = this.onConfirmarDone;
			if (action != null)
			{
				action(this);
			}
			return this.aparienciaFisica.isDefaultValues || this.personalidad.isDefaultValues;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000054FC File Offset: 0x000036FC
		public void ShowGuide()
		{
			InfoDialog modalPanel = Singleton<ModalWindow>.instance.MostrarBigInfoDialog();
			modalPanel.pregunta.text = "<B><color=green>Good</color> Rating Practices:</B>\n-ONE IS NOT THE MINIMUM RATING, ZERO is the minimum rating, rate with ZERO traits that you do NOT like.\n-DO NOT Rate with MORE THAN ZERO traits that YOU DO NOT WANT to see in future generations.\n-DO score with 10 traits what you consider ideal or perfect.\n\n<B><color=red>Bad</color> Rating Practices:</B>\n-High scores for traits when these don't meet your criteria (participation trophy points)\n-Low Rating traits that DO meet your criteria. Ex: \"She has nice breasts, but since she is a bitch, I'll put zero on her breast slider.\"\n-Ratings of one or two when in reality the player does NOT consider these traits attractive. Ex: \"I don't like her breasts, but since I'm a nice guy, I'll score her breasts with two\".";
			modalPanel.aceptar.onClick.AddListener(delegate
			{
				if (Singleton<ModalWindow>.IsInScene)
				{
					Singleton<ModalWindow>.instance.Clear(modalPanel);
				}
			});
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005555 File Offset: 0x00003755
		public void RedoAutoRating()
		{
			Action<EstrevistaRatingModelo> action = this.onRedoAutoRating;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0400007A RID: 122
		[Modelo]
		[PanelLayout(alturaMinima = 535f, alturaPreferida = 535f)]
		[Label("Physical Appearance Score", "US", fontStyle = FontStyles.Italic, alignment = TextAlignmentOptions.MidlineLeft)]
		public EstrevistaCalificacionAparienciaFisicaModelo aparienciaFisica;

		// Token: 0x0400007B RID: 123
		[Modelo]
		[PanelLayout(alturaMinima = 270f, alturaPreferida = 270f)]
		[Label("Personality Score", "US", fontStyle = FontStyles.Italic, alignment = TextAlignmentOptions.MidlineLeft)]
		public EstrevistaCalificacionPersonalidadModelo personalidad;
	}
}
