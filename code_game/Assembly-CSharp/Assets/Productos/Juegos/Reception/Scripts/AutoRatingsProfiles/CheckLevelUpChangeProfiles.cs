using System;
using Assets.Productos.Juegos.Reception.Scripts.Genetica.Eventos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x020000C7 RID: 199
	[Obsolete("Now on, ther will be only a single pool", true)]
	[RequireComponent(typeof(PiscinasDeEventosDeEntrevista))]
	public class CheckLevelUpChangeProfiles : CustomMonobehaviour
	{
		// Token: 0x060004D0 RID: 1232 RVA: 0x000185D8 File Offset: 0x000167D8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PiscinasDeEventosDeEntrevista = base.GetComponent<PiscinasDeEventosDeEntrevista>();
			this.m_PiscinasDeEventosDeEntrevista.leveledUp += this.M_PiscinasDeEventosDeEntrevista_leveledUp;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00018603 File Offset: 0x00016803
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_PiscinasDeEventosDeEntrevista.leveledUp -= this.M_PiscinasDeEventosDeEntrevista_leveledUp;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00018624 File Offset: 0x00016824
		private void M_PiscinasDeEventosDeEntrevista_leveledUp(int obj)
		{
			if (obj > 0 && obj <= 10 && Singleton<AutoRatings>.IsInScene && Singleton<AutoRatings>.instance.AutoRatingFaltantePorConfig(obj))
			{
				Singleton<ModalWindow>.instance.MostrarBajaPrioridad(delegate
				{
					ConfirmacionMiembros dialog = Singleton<ModalWindow>.instance.MostrarConfirmacion();
					dialog.SetPreguntaText("You've just gained a level. Do you wish to configure the new group's AutoRating profile?");
					dialog.noMostrarOtraVezToggle.interactable = false;
					dialog.cancelar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(dialog);
					});
					dialog.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(dialog);
						Singleton<AutoRatings>.instance.OpenEditorDeGrupos();
					});
				});
			}
		}

		// Token: 0x0400023B RID: 571
		private PiscinasDeEventosDeEntrevista m_PiscinasDeEventosDeEntrevista;
	}
}
