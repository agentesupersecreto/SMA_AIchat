using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas;
using Assets.TValle.Pro.Entrevista.Tiempo.Runtime.Genetica;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000118 RID: 280
	public abstract class EntrevistaParaCalificarFemaleCharacterFromPool : EntrevistaFemaleCharacterFromPoolOrMemOrDisk
	{
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x00038E29 File Offset: 0x00037029
		public StringKeyFloatValueDictionary flagScoreAparienciaCurrentFemaleV2
		{
			get
			{
				if (!Singleton<PiscinaDeCampaingActual>.IsInScene)
				{
					return null;
				}
				return Singleton<PiscinaDeCampaingActual>.instance.flagScoreAparienciaCurrentFemaleV2;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x00038E3E File Offset: 0x0003703E
		public StringKeyFloatValueDictionary flagScorePersonalidadCurrentFemaleV2
		{
			get
			{
				if (!Singleton<PiscinaDeCampaingActual>.IsInScene)
				{
					return null;
				}
				return Singleton<PiscinaDeCampaingActual>.instance.flagScorePersonalidadCurrentFemaleV2;
			}
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00038E53 File Offset: 0x00037053
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00038E5B File Offset: 0x0003705B
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!Singleton<PanelDeEntrevistaCalificacionGetter>.IsInScene)
			{
				Debug.LogError("scene with PanelDeEntrevistaCalificacion is not loaded", this);
			}
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00038E78 File Offset: 0x00037078
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			if (this.flagScoreAparienciaCurrentFemaleV2 == null || this.flagScorePersonalidadCurrentFemaleV2 == null)
			{
				return null;
			}
			if (this.flagScoreAparienciaCurrentFemaleV2.Count == 0 || this.flagScorePersonalidadCurrentFemaleV2.Count == 0)
			{
				return null;
			}
			return new CustomMonobehaviourBotonConfig
			{
				text = "Calificar",
				editorTimeVisible = false,
				confirmar = true
			};
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x00038ED1 File Offset: 0x000370D1
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			base.CalificarCurrentFemale();
		}
	}
}
