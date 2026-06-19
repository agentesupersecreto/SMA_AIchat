using System;
using System.Collections;
using Assets.Base.Plugins.Runtime.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Paneles;
using Assets.TValle.IU.Runtime.Drawing.Paneles;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos
{
	// Token: 0x0200005C RID: 92
	public class JobsUIManager : Singleton<JobsUIManager>, ISMAJobsUIManager
	{
		// Token: 0x14000036 RID: 54
		// (add) Token: 0x0600031A RID: 794 RVA: 0x00011450 File Offset: 0x0000F650
		// (remove) Token: 0x0600031B RID: 795 RVA: 0x00011488 File Offset: 0x0000F688
		public event Action<ISMAJobsUIManager> showMenuKeyReleased;

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600031C RID: 796 RVA: 0x000114BD File Offset: 0x0000F6BD
		public bool floatingMainMenuIsShowing
		{
			get
			{
				return this.m_floatingPanel.isShowing;
			}
		}

		// Token: 0x0600031D RID: 797 RVA: 0x000114CC File Offset: 0x0000F6CC
		protected override void DoAwake()
		{
			base.DoAwake();
			if (this.m_floatingPanel == null)
			{
				throw new ArgumentNullException("m_floatingPanel", "m_floatingPanel null reference.");
			}
			if (this.m_mainCanvasPanel == null)
			{
				throw new ArgumentNullException("m_mainCanvasPanel", "m_mainCanvasPanel null reference.");
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0001151C File Offset: 0x0000F71C
		private void Update()
		{
			if (Singleton<PlayerInputProxy>.instance.virtualesUI.tab && !DialogueManager.IsConversationActive)
			{
				Action<ISMAJobsUIManager> action = this.showMenuKeyReleased;
				if (action != null)
				{
					action(this);
				}
			}
			if (this.m_showObjectives == null && Singleton<GameplayObjectives>.IsInScene)
			{
				this.m_showObjectives = Singleton<GameplayObjectives>.instance.showPanel.ObtenerModificadorNotNull(this);
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00011578 File Offset: 0x0000F778
		public void DrawFloatingMainMenuPanel(object model, out object previousModel, Action onHidden = null)
		{
			if (Singleton<PanelCharacterCompleteInfoGetter>.instance.isShowing || Singleton<CurriculumVitaePanelGetter>.instance.curriculumVitaePanel.isShowing || Singleton<MaleInfoPanelGetter>.instance.panel.isShowing)
			{
				previousModel = null;
				return;
			}
			if (this.m_floatingPanel.isBinded)
			{
				bool flag;
				if (this.m_floatingPanel.CurrentModelObjectAndState(out flag) == model)
				{
					previousModel = null;
					return;
				}
				this.m_floatingPanel.Clear();
			}
			bool flag2;
			object obj = this.m_floatingPanel.CurrentModelObjectAndState(out flag2);
			if (obj != model)
			{
				previousModel = obj;
			}
			else
			{
				previousModel = null;
			}
			this.m_floatingPanel.SetModel(model);
			DibujadorDynamico.ExtraData extraData = new DibujadorDynamico.ExtraData();
			PanelAttribute panelAttribute = new PanelAttribute();
			panelAttribute.height = 650;
			extraData.overrides.AddTo(model, null, panelAttribute, -1);
			extraData.overrides.AddTo(model, null, new UnTittleAttribute(), -1);
			extraData.overrides.AddTo(model, null, new CerrableAttribute
			{
				accion = CerrableAttribute.Accion.destruir
			}, -1);
			if (onHidden != null)
			{
				this.m_floatingPanel.onPanelHidden -= onHidden;
				this.m_floatingPanel.onPanelHidden += onHidden;
			}
			this.m_floatingPanel.CrearYDibujar(extraData);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00011683 File Offset: 0x0000F883
		public void DrawMainMenuPanelOnMainCanvas(object model, out object previousModel)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0001168C File Offset: 0x0000F88C
		public void ShowMainNonPlayerCharacterInfo()
		{
			if (!DialogueManager.IsConversationActive)
			{
				FemaleChar component = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.GetComponent<FemaleChar>();
				if (component != null && !Singleton<PanelCharacterCompleteInfoGetter>.instance.isShowing)
				{
					Singleton<PanelCharacterCompleteInfoGetter>.instance.CrearYDibujar(component);
				}
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000116D8 File Offset: 0x0000F8D8
		public void ShowMainPlayerCharacterInfo()
		{
			if (!DialogueManager.IsConversationActive)
			{
				MaleChar component = AsyncSingleton<JobsManager>.instance.current.mainPlayerCharacter.GetComponent<MaleChar>();
				if (component != null && !Singleton<PanelCharacterCompleteInfoGetter>.instance.isShowing)
				{
					Singleton<PanelCharacterCompleteInfoGetter>.instance.CrearYDibujar(component);
				}
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00011721 File Offset: 0x0000F921
		public void ShowCurrentJobSessionObjetives(bool show, bool force)
		{
			if (this.m_showObjectives != null)
			{
				this.m_showObjectives.valor.valor = show;
			}
			if (force && !show && Singleton<GameplayObjectives>.IsInScene)
			{
				Singleton<GameplayObjectives>.instance.ForceHide();
			}
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00011753 File Offset: 0x0000F953
		public void CloseFloatingPanel()
		{
			this.m_floatingPanel.Clear();
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00011760 File Offset: 0x0000F960
		public void CloseMainCanvasPanel()
		{
			this.m_mainCanvasPanel.Clear();
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00011770 File Offset: 0x0000F970
		public IEnumerator ShowDefaultEndSessionPanel(bool aborted, float income, float activityExpGain, float activityExpTotal, float modelFatigueGain, float modelFatigueTotal, SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnFrom, SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnTo)
		{
			yield return Singleton<ActividadesManager>.instance.ShowDefaultEndSessionPanel(aborted, income, activityExpGain, activityExpTotal, modelFatigueGain, modelFatigueTotal, BuffAndDebuffOnFrom, BuffAndDebuffOnTo);
			yield break;
		}

		// Token: 0x040001D6 RID: 470
		[SerializeField]
		private SingleModelPanel m_floatingPanel;

		// Token: 0x040001D7 RID: 471
		[SerializeField]
		private SingleModelPanel m_mainCanvasPanel;

		// Token: 0x040001D8 RID: 472
		[SerializeReference]
		private ModificadorDeBool m_showObjectives;
	}
}
