using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Globales;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.UI.Runtime.Modelos.Abstracts;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000A9 RID: 169
	[Modelo]
	[Label("Scene Lighting Control", "US", fontStyle = FontStyles.Bold, alignment = TextAlignmentOptions.Top, height = 50)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Panel(tipo = TipoDePanel.scrollableFlotante, height = 500)]
	[Serializable]
	public class EntrevistaConfigDeLucesModelo : ConfigModel, IModeloBindableOnUIPanel, IConfigModel
	{
		// Token: 0x06000381 RID: 897 RVA: 0x000130A8 File Offset: 0x000112A8
		public static void SendToConfig(EntrevistaConfigDeLucesModelo configModel)
		{
			Singleton<ConfiguracionDeLucesDeScena>.instance.current.sunIntensity = MathfExtension.LerpConMedio(0.06666667f, 1f, 15f, Mathf.InverseLerp(1f, 99f, configModel.intensity.sun));
			Singleton<ConfiguracionDeLucesDeScena>.instance.current.indoorPrimariaIntensity = MathfExtension.LerpConMedio(0.033333335f, 1f, 30f, Mathf.InverseLerp(1f, 99f, configModel.intensity.indoorPrimaria));
			Singleton<ConfiguracionDeLucesDeScena>.instance.current.indoorSecondaryIntensity = MathfExtension.LerpConMedio(0.033333335f, 1f, 30f, Mathf.InverseLerp(1f, 99f, configModel.intensity.indoorSegundaria));
			if (Singleton<ConfiguracionDeLucesDeScena>.instance.current.sunIntensity <= 0.06666667f)
			{
				Singleton<ConfiguracionDeLucesDeScena>.instance.current.sunIntensity = 0f;
			}
			if (Singleton<ConfiguracionDeLucesDeScena>.instance.current.indoorPrimariaIntensity <= 0.033333335f)
			{
				Singleton<ConfiguracionDeLucesDeScena>.instance.current.indoorPrimariaIntensity = 0f;
			}
			if (Singleton<ConfiguracionDeLucesDeScena>.instance.current.indoorSecondaryIntensity <= 0.033333335f)
			{
				Singleton<ConfiguracionDeLucesDeScena>.instance.current.indoorSecondaryIntensity = 0f;
			}
			Singleton<ConfiguracionDeLucesDeScena>.instance.current.spotMode = configModel.spotLightAI.mode;
			Singleton<ConfiguracionDeLucesDeScena>.instance.current.spotModeFolloing = configModel.spotLightAI.folloingMode;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00013220 File Offset: 0x00011420
		public static void FromConfig(EntrevistaConfigDeLucesModelo modelo, ConfiguracionDeLucesDeScena.User_Data data)
		{
			modelo.intensity.sun = Mathf.Lerp(1f, 99f, MathfExtension.InverseLerpConMedio(0.06666667f, 1f, 15f, data.sunIntensity));
			modelo.intensity.indoorPrimaria = Mathf.Lerp(1f, 99f, MathfExtension.InverseLerpConMedio(0.033333335f, 1f, 30f, data.indoorPrimariaIntensity));
			modelo.intensity.indoorSegundaria = Mathf.Lerp(1f, 99f, MathfExtension.InverseLerpConMedio(0.033333335f, 1f, 30f, data.indoorSecondaryIntensity));
			modelo.spotLightAI.mode = data.spotMode;
			modelo.spotLightAI.folloingMode = data.spotModeFolloing;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x000132EC File Offset: 0x000114EC
		public unsafe static void FromCurrentConfig(EntrevistaConfigDeLucesModelo modelo)
		{
			ConfiguracionDeLucesDeScena instance = Singleton<ConfiguracionDeLucesDeScena>.instance;
			IConfiguracionDeUsuario configuracionDeUsuario = instance as IConfiguracionDeUsuario;
			if (configuracionDeUsuario != null)
			{
				configuracionDeUsuario.OnGetted();
			}
			EntrevistaConfigDeLucesModelo.FromConfig(modelo, *instance.current);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00013321 File Offset: 0x00011521
		public static void FromDefaultConfig(EntrevistaConfigDeLucesModelo modelo)
		{
			EntrevistaConfigDeLucesModelo.FromConfig(modelo, ConfiguracionDeLucesDeScena.User_Data.@default);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0001332E File Offset: 0x0001152E
		protected override void OnDirtyChanged()
		{
			base.OnDirtyChanged();
			this.RefreshDisables();
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0001333C File Offset: 0x0001153C
		protected override void Binded(IUIPanel to)
		{
			base.Binded(to);
			this.RefreshDisables();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0001334C File Offset: 0x0001154C
		public void RefreshDisables()
		{
			IUIPanel panel = base.panel;
			IUIPanel iuipanel = ((panel != null) ? panel.elementoPorModelo["spotLightAI"] : null) as IUIPanel;
			IUIElementoRefreshable iuielementoRefreshable = ((iuipanel != null) ? iuipanel.elementoPorModelo["folloingMode"] : null) as IUIElementoRefreshable;
			if (iuielementoRefreshable == null)
			{
				return;
			}
			iuielementoRefreshable.Refresh();
		}

		// Token: 0x04000186 RID: 390
		[Modelo]
		public EntrevistaConfigDeLucesModelo.Intensity intensity = new EntrevistaConfigDeLucesModelo.Intensity();

		// Token: 0x04000187 RID: 391
		[Modelo]
		public EntrevistaConfigDeLucesModelo.AI spotLightAI = new EntrevistaConfigDeLucesModelo.AI();

		// Token: 0x02000116 RID: 278
		[Modelo]
		[Label("Intensity", alignment = TextAlignmentOptions.MidlineLeft)]
		[Panel(tipo = TipoDePanel.scrollableFlotante, height = 170)]
		[Serializable]
		public class Intensity
		{
			// Token: 0x040003A2 RID: 930
			[Label("Sunlight ", "US")]
			[Range(1f, 99f)]
			[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
			[DescripcionLocalizado("Value of one, will turn off the light.", "US")]
			public float sun;

			// Token: 0x040003A3 RID: 931
			[Label("Indoor Primary", "US")]
			[Range(1f, 99f)]
			[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
			[DescripcionLocalizado("Value of one, will turn off the light.", "US")]
			public float indoorPrimaria;

			// Token: 0x040003A4 RID: 932
			[Label("Indoor Secondary", "US")]
			[Range(1f, 99f)]
			[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
			[DescripcionLocalizado("Value of one, will turn off the light.", "US")]
			public float indoorSegundaria;
		}

		// Token: 0x02000117 RID: 279
		[Modelo]
		[Label("Spot Light Mode", alignment = TextAlignmentOptions.MidlineLeft)]
		[Panel(tipo = TipoDePanel.scrollableFlotante, height = 160)]
		[Serializable]
		public class AI
		{
			// Token: 0x040003A5 RID: 933
			[Label("Mode", "US")]
			[DesplegableConToolTip]
			public ConfiguracionDeLucesDeScena.ModoDeLuz mode;

			// Token: 0x040003A6 RID: 934
			[Label("Following Mode", "US")]
			[DesplegableConToolTip]
			public ConfiguracionDeLucesDeScena.ModoDeSeguimiento folloingMode = ConfiguracionDeLucesDeScena.ModoDeSeguimiento.chest;
		}
	}
}
