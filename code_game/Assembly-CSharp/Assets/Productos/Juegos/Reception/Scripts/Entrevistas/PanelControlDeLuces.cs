using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Globales;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.UI.Runtime.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x020000A3 RID: 163
	public class PanelControlDeLuces : PanelBaseSingleModel<EntrevistaConfigDeLucesModelo>
	{
		// Token: 0x06000352 RID: 850 RVA: 0x00012390 File Offset: 0x00010590
		protected override void OnShowed()
		{
			base.OnShowed();
			EntrevistaConfigDeLucesModelo.FromCurrentConfig(this.m_model);
			DibujadorDynamico.instance.SetValoresAPanel(base.UIPanel, this.m_model, true);
			this.m_model.RefreshDisables();
			this.m_model.reseting += this.M_model_reseting;
			this.m_model.applying += this.M_model_applying;
			this.m_model.canceling += this.M_model_canceling;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00012418 File Offset: 0x00010618
		protected override void OnHided()
		{
			base.OnHided();
			this.m_model.reseting -= this.M_model_reseting;
			this.m_model.applying -= this.M_model_applying;
			this.m_model.canceling -= this.M_model_canceling;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00012470 File Offset: 0x00010670
		private void M_model_canceling(IConfigModel obj)
		{
			EntrevistaConfigDeLucesModelo.FromCurrentConfig(this.m_model);
			base.ActualizarValoresDePanel();
			if (this.m_model != null)
			{
				((IConfigModel)this.m_model).isDirty = false;
			}
			base.CrearYDibujar(null);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0001249E File Offset: 0x0001069E
		private void M_model_applying(IConfigModel obj)
		{
			base.ActualizarValoresDeModelo();
			EntrevistaConfigDeLucesModelo.SendToConfig(this.m_model);
			Singleton<ConfiguracionDeLucesDeScena>.instance.SaveToDisk();
			this.M_model_canceling(obj);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000124C2 File Offset: 0x000106C2
		private void M_model_reseting(IConfigModel obj)
		{
			EntrevistaConfigDeLucesModelo.FromDefaultConfig(this.m_model);
			base.ActualizarValoresDePanel();
			if (this.m_model != null)
			{
				((IConfigModel)this.m_model).isDirty = true;
			}
		}
	}
}
