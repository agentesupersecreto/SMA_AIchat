using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000037 RID: 55
	public abstract class PanelBase : AplicableBehaviour, IPanelOfModel
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00005EFB File Offset: 0x000040FB
		public bool dibujando
		{
			get
			{
				return this.isShowing;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00005F03 File Offset: 0x00004103
		[Obsolete("", true)]
		public GenericUserPanelBase genericUserPanel
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0600016C RID: 364
		protected abstract object ObtenerModeloAUsar(bool esParaDibujar);

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00005F06 File Offset: 0x00004106
		protected IUIPanel UIPanel
		{
			get
			{
				return this.m_userPanelV2.panel;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00005F13 File Offset: 0x00004113
		public bool canShow
		{
			get
			{
				return this.m_canShowModificable.And(this.m_canShow);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00005F26 File Offset: 0x00004126
		public ModificableDeBool canShowModificable
		{
			get
			{
				return this.m_canShowModificable;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000170 RID: 368 RVA: 0x00005F30 File Offset: 0x00004130
		// (remove) Token: 0x06000171 RID: 369 RVA: 0x00005F68 File Offset: 0x00004168
		public event Action<PanelBase> onHiddenBase;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000172 RID: 370 RVA: 0x00005FA0 File Offset: 0x000041A0
		// (remove) Token: 0x06000173 RID: 371 RVA: 0x00005FD8 File Offset: 0x000041D8
		public event Action onPanelHidden;

		// Token: 0x06000174 RID: 372 RVA: 0x00006010 File Offset: 0x00004210
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_userPanelV2 = base.GetComponent<GenericUserPanelBase>();
			this.m_userPanelV2.binding += this.M_userPanel_binding;
			this.m_userPanelV2.binded += this.M_userPanel_binded;
			this.m_userPanelV2.showed += this.M_userPanel_showed;
			this.m_userPanelV2.hided += this.M_userPanel_hided;
			this.m_userPanelV2.clearing += this.M_userPanel_clearing;
			this.m_userPanelV2.cleared += this.M_userPanel_cleared;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000060B9 File Offset: 0x000042B9
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_dibujarOnStart)
			{
				this.CrearYDibujar(null);
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000060D0 File Offset: 0x000042D0
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_userPanelV2 != null)
			{
				this.m_userPanelV2.binding -= this.M_userPanel_binding;
				this.m_userPanelV2.binded -= this.M_userPanel_binded;
				this.m_userPanelV2.showed -= this.M_userPanel_showed;
				this.m_userPanelV2.hided -= this.M_userPanel_hided;
				this.m_userPanelV2.cleared -= this.M_userPanel_cleared;
				this.m_userPanelV2.cleared -= this.M_userPanel_cleared;
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000617F File Offset: 0x0000437F
		private void M_userPanel_binding(GenericUserPanelBase obj)
		{
			this.OnBinding();
			IModeloBindableOnUIPanel modeloBindableOnUIPanel = this.ObtenerModeloAUsar(false) as IModeloBindableOnUIPanel;
			if (modeloBindableOnUIPanel == null)
			{
				return;
			}
			modeloBindableOnUIPanel.Bindig();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000619D File Offset: 0x0000439D
		private void M_userPanel_binded(GenericUserPanelBase obj)
		{
			this.OnBinded();
			IModeloBindableOnUIPanel modeloBindableOnUIPanel = this.ObtenerModeloAUsar(false) as IModeloBindableOnUIPanel;
			if (modeloBindableOnUIPanel == null)
			{
				return;
			}
			modeloBindableOnUIPanel.Binded(obj.panel);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000061C1 File Offset: 0x000043C1
		private void M_userPanel_showed(GenericUserPanelBase obj)
		{
			this.OnShowed();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000061C9 File Offset: 0x000043C9
		private void M_userPanel_hided(GenericUserPanelBase obj)
		{
			this.OnHided();
			Action<PanelBase> action = this.onHiddenBase;
			if (action != null)
			{
				action(this);
			}
			Action action2 = this.onPanelHidden;
			if (action2 == null)
			{
				return;
			}
			action2();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000061F3 File Offset: 0x000043F3
		private void M_userPanel_clearing(GenericUserPanelBase obj)
		{
			this.OnClearing();
			IModeloBindableOnUIPanel modeloBindableOnUIPanel = this.ObtenerModeloAUsar(false) as IModeloBindableOnUIPanel;
			if (modeloBindableOnUIPanel == null)
			{
				return;
			}
			modeloBindableOnUIPanel.Clearing();
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00006211 File Offset: 0x00004411
		private void M_userPanel_cleared(GenericUserPanelBase obj)
		{
			this.OnCleared();
			IModeloBindableOnUIPanel modeloBindableOnUIPanel = this.ObtenerModeloAUsar(false) as IModeloBindableOnUIPanel;
			if (modeloBindableOnUIPanel == null)
			{
				return;
			}
			modeloBindableOnUIPanel.Cleared();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00006230 File Offset: 0x00004430
		public void DisableRaycaster(float duration)
		{
			GraphicRaycaster componentInChildren = base.GetComponentInChildren<GraphicRaycaster>();
			if (componentInChildren != null)
			{
				componentInChildren.enabled = false;
				if (duration > 0f)
				{
					if (this.m_ReEnableRaycasterRutine != null)
					{
						base.StopCoroutine(this.m_ReEnableRaycasterRutine);
					}
					this.m_ReEnableRaycasterRutine = base.StartCoroutine(this.ReEnableRaycasterRutine(duration, componentInChildren));
				}
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00006284 File Offset: 0x00004484
		public void EnableRaycaster()
		{
			if (this.m_ReEnableRaycasterRutine != null)
			{
				base.StopCoroutine(this.m_ReEnableRaycasterRutine);
			}
			GraphicRaycaster componentInChildren = base.GetComponentInChildren<GraphicRaycaster>();
			if (componentInChildren != null)
			{
				componentInChildren.enabled = true;
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000062BC File Offset: 0x000044BC
		private IEnumerator ReEnableRaycasterRutine(float duration, GraphicRaycaster raycaster)
		{
			WaitForSeconds waitForSeconds = new WaitForSeconds(duration);
			yield return waitForSeconds;
			if (raycaster != null)
			{
				raycaster.enabled = true;
			}
			this.m_ReEnableRaycasterRutine = null;
			yield break;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000062D9 File Offset: 0x000044D9
		protected virtual void OnBinding()
		{
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000062DB File Offset: 0x000044DB
		protected virtual void OnBinded()
		{
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000062DD File Offset: 0x000044DD
		protected virtual void OnShowed()
		{
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000062DF File Offset: 0x000044DF
		protected virtual void OnHided()
		{
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000062E1 File Offset: 0x000044E1
		protected virtual void OnClearing()
		{
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000062E3 File Offset: 0x000044E3
		protected virtual void OnCleared()
		{
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000062E5 File Offset: 0x000044E5
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Dibujar",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000062FE File Offset: 0x000044FE
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.CrearYDibujar(null);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000630D File Offset: 0x0000450D
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar Modelo",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00006326 File Offset: 0x00004526
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.ActualizarValoresDeModelo();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00006334 File Offset: 0x00004534
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar Panel",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000634D File Offset: 0x0000454D
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			this.ActualizarValoresDePanel();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000635B File Offset: 0x0000455B
		protected override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Clear",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00006374 File Offset: 0x00004574
		protected override void OnAplicar5()
		{
			base.OnAplicar5();
			this.Clear();
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00006382 File Offset: 0x00004582
		public bool isShowing
		{
			get
			{
				return this.m_userPanelV2.isShowing;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600018F RID: 399 RVA: 0x0000638F File Offset: 0x0000458F
		public bool isBinded
		{
			get
			{
				return this.m_userPanelV2.isBinded;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000639C File Offset: 0x0000459C
		GenericUserPanelBase IPanelOfModel.genericUserPanel
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x000063A4 File Offset: 0x000045A4
		protected int? ClearSubModelo(object subModelo, IUIPanel panelDeSubModelo, IUIPanel parentPanel)
		{
			int? num = null;
			IModeloBindableOnUIPanel modeloBindableOnUIPanel = subModelo as IModeloBindableOnUIPanel;
			if (modeloBindableOnUIPanel != null)
			{
				modeloBindableOnUIPanel.Clearing();
			}
			Object @object;
			if (panelDeSubModelo == null)
			{
				@object = null;
			}
			else
			{
				Transform transform = panelDeSubModelo.transform;
				@object = ((transform != null) ? transform.gameObject : null);
			}
			if (@object != null)
			{
				num = new int?(panelDeSubModelo.transform.GetSiblingIndex());
				Object.Destroy(panelDeSubModelo.transform.gameObject);
			}
			if (modeloBindableOnUIPanel != null)
			{
				modeloBindableOnUIPanel.Cleared();
			}
			return num;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000641C File Offset: 0x0000461C
		protected void SaveScrollValue(string subPanelFieldName)
		{
			IUIPanel iuipanel = null;
			IUIElemento iuielemento;
			if (this.UIPanel.elementoPorModelo.TryGetValue(subPanelFieldName, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			if (iuipanel != null)
			{
				if (!this.m_scrollValuesDePanels.ContainsKey(subPanelFieldName))
				{
					Dictionary<string, float> scrollValuesDePanels = this.m_scrollValuesDePanels;
					Scrollbar scrollbar = iuipanel.scrollbar;
					scrollValuesDePanels.Add(subPanelFieldName, ((scrollbar != null) ? new float?(scrollbar.value) : null).GetValueOrDefault(1f));
					return;
				}
				Dictionary<string, float> scrollValuesDePanels2 = this.m_scrollValuesDePanels;
				Scrollbar scrollbar2 = iuipanel.scrollbar;
				scrollValuesDePanels2[subPanelFieldName] = ((scrollbar2 != null) ? new float?(scrollbar2.value) : null).GetValueOrDefault(1f);
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000064CC File Offset: 0x000046CC
		protected void LoadScrollValue(string subPanelFieldName, int waitFrames)
		{
			IUIPanel iuipanel = null;
			IUIElemento iuielemento;
			if (this.UIPanel.elementoPorModelo.TryGetValue(subPanelFieldName, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.StartCoroutine(this.LoadScrollValueRutine(iuipanel, subPanelFieldName, waitFrames));
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00006507 File Offset: 0x00004707
		private IEnumerator LoadScrollValueRutine(IUIPanel subPane, string subPanelFieldName, int waitFrames)
		{
			WaitForEndOfFrame w = new WaitForEndOfFrame();
			int num;
			for (int i = 0; i < waitFrames; i = num + 1)
			{
				yield return w;
				num = i;
			}
			float num2;
			if (subPane != null && this.m_scrollValuesDePanels.TryGetValue(subPanelFieldName, out num2) && subPane.scrollbar != null)
			{
				subPane.scrollbar.value = num2;
			}
			yield break;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000652C File Offset: 0x0000472C
		protected void ReDrawSubModelo(object subModel, string subPanelFieldName, ref IUIPanel panelDeSubModelo, IUIPanel parentPanel, Transform targetPanel)
		{
			int? num = null;
			if (panelDeSubModelo != null)
			{
				num = this.ClearSubModelo(subModel, panelDeSubModelo, parentPanel);
			}
			if (subModel == null)
			{
				return;
			}
			IModeloBindableOnUIPanel modeloBindableOnUIPanel = subModel as IModeloBindableOnUIPanel;
			DibujadorDynamico.ExtraData extraData = null;
			if (modeloBindableOnUIPanel != null)
			{
				modeloBindableOnUIPanel.Bindig();
			}
			panelDeSubModelo = DibujadorDynamico.instance.DibujarPanel(subModel, targetPanel, ref extraData, null, null, num);
			if (panelDeSubModelo == null)
			{
				return;
			}
			DibujadorDynamico.instance.AddBotones(subModel, panelDeSubModelo, ref extraData);
			DibujadorDynamico.instance.SetControlesAPanel(panelDeSubModelo, subModel, extraData, null, null);
			DibujadorDynamico.instance.BindSubPanel(panelDeSubModelo, parentPanel, subPanelFieldName);
			parentPanel.ReplaceElemento(panelDeSubModelo);
			if (modeloBindableOnUIPanel != null)
			{
				modeloBindableOnUIPanel.Binded(panelDeSubModelo);
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000065C3 File Offset: 0x000047C3
		public void Clear()
		{
			this.m_userPanelV2.Clear();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000065D0 File Offset: 0x000047D0
		public void Show()
		{
			this.m_userPanelV2.Show();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000065DD File Offset: 0x000047DD
		public void Hide()
		{
			this.m_userPanelV2.Hide();
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000065EC File Offset: 0x000047EC
		public void CrearYDibujar(DibujadorDynamico.ExtraData extraData = null)
		{
			if (this.m_negarSiEstaEnConversacion && DialogueManager.IsConversationActive)
			{
				this.Clear();
				return;
			}
			if (!this.m_canShowModificable.And(this.CanShow()))
			{
				return;
			}
			if (this.isBinded)
			{
				this.Clear();
			}
			this.m_lastDrawnModel = this.ObtenerModeloAUsar(true);
			this.m_userPanelV2.Bind(this.m_lastDrawnModel, this.m_lastDrawnModel, extraData);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00006657 File Offset: 0x00004857
		public virtual bool CanShow()
		{
			return this.canShow;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00006660 File Offset: 0x00004860
		public object CurrentModelObjectAndState(out bool changed)
		{
			object obj = this.ObtenerModeloAUsar(false);
			changed = this.m_lastModel != obj;
			this.m_lastModel = obj;
			return this.m_lastModel;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00006690 File Offset: 0x00004890
		public object GetLastDrawModel()
		{
			return this.m_lastDrawnModel;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00006698 File Offset: 0x00004898
		public void ActualizarValoresDeModelo()
		{
			if (!this.isBinded)
			{
				return;
			}
			this.m_userPanelV2.ActualizarValoresDeModelo();
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000066AE File Offset: 0x000048AE
		public void ActualizarValoresDeModelo(object Model)
		{
			if (!this.isBinded)
			{
				return;
			}
			this.m_userPanelV2.ActualizarValoresDeModelo(Model);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000066C5 File Offset: 0x000048C5
		public void ActualizarValoresDePanel()
		{
			if (!this.isBinded)
			{
				return;
			}
			this.m_userPanelV2.ActualizarValoresDePanel();
		}

		// Token: 0x040000B8 RID: 184
		[SerializeField]
		protected bool m_negarSiEstaEnConversacion;

		// Token: 0x040000B9 RID: 185
		[SerializeField]
		protected bool m_dibujarOnStart;

		// Token: 0x040000BA RID: 186
		[SerializeField]
		private bool m_canShow = true;

		// Token: 0x040000BB RID: 187
		[NonSerialized]
		private object m_lastModel;

		// Token: 0x040000BC RID: 188
		private GenericUserPanelBase m_userPanelV2;

		// Token: 0x040000BD RID: 189
		[SerializeField]
		private ModificableDeBool m_canShowModificable = new ModificableDeBool(true);

		// Token: 0x040000C0 RID: 192
		private Dictionary<string, float> m_scrollValuesDePanels = new Dictionary<string, float>();

		// Token: 0x040000C1 RID: 193
		[NonSerialized]
		private object m_lastDrawnModel;

		// Token: 0x040000C2 RID: 194
		private Coroutine m_ReEnableRaycasterRutine;
	}
}
