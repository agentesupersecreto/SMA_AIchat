using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.TValle.IU.Runtime.Drawing.Abstracts
{
	// Token: 0x02000159 RID: 345
	public abstract class GenericUserPanelBase : AplicableBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x0002185C File Offset: 0x0001FA5C
		public bool isBinded
		{
			get
			{
				return this.m_Model != null;
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000A24 RID: 2596 RVA: 0x00021867 File Offset: 0x0001FA67
		public object model
		{
			get
			{
				return this.m_Model;
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x0002186F File Offset: 0x0001FA6F
		public object buttonModel
		{
			get
			{
				return this.m_buttonModel;
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x00021877 File Offset: 0x0001FA77
		public IReadOnlyList<BotonElementBase> botones
		{
			get
			{
				return this.m_botones;
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x0002187F File Offset: 0x0001FA7F
		public IUIPanel panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000A28 RID: 2600 RVA: 0x00021887 File Offset: 0x0001FA87
		public bool panelExiste
		{
			get
			{
				return (Object)this.m_panel != null;
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000A29 RID: 2601 RVA: 0x0002189C File Offset: 0x0001FA9C
		public bool isShowing
		{
			get
			{
				if (this.panelExiste && this.isBinded)
				{
					IUIPanel panel = this.m_panel;
					bool? flag;
					if (panel == null)
					{
						flag = null;
					}
					else
					{
						Transform transform = panel.transform;
						if (transform == null)
						{
							flag = null;
						}
						else
						{
							GameObject gameObject = transform.gameObject;
							flag = ((gameObject != null) ? new bool?(gameObject.activeInHierarchy) : null);
						}
					}
					bool? flag2 = flag;
					return flag2.GetValueOrDefault();
				}
				return false;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000A2A RID: 2602
		public abstract Transform target { get; }

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x06000A2B RID: 2603 RVA: 0x0002190C File Offset: 0x0001FB0C
		// (remove) Token: 0x06000A2C RID: 2604 RVA: 0x00021944 File Offset: 0x0001FB44
		public event Action<GenericUserPanelBase> binding;

		// Token: 0x14000059 RID: 89
		// (add) Token: 0x06000A2D RID: 2605 RVA: 0x0002197C File Offset: 0x0001FB7C
		// (remove) Token: 0x06000A2E RID: 2606 RVA: 0x000219B4 File Offset: 0x0001FBB4
		public event Action<GenericUserPanelBase> binded;

		// Token: 0x1400005A RID: 90
		// (add) Token: 0x06000A2F RID: 2607 RVA: 0x000219EC File Offset: 0x0001FBEC
		// (remove) Token: 0x06000A30 RID: 2608 RVA: 0x00021A24 File Offset: 0x0001FC24
		public event Action<GenericUserPanelBase> showed;

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x06000A31 RID: 2609 RVA: 0x00021A5C File Offset: 0x0001FC5C
		// (remove) Token: 0x06000A32 RID: 2610 RVA: 0x00021A94 File Offset: 0x0001FC94
		public event Action<GenericUserPanelBase> hided;

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x06000A33 RID: 2611 RVA: 0x00021ACC File Offset: 0x0001FCCC
		// (remove) Token: 0x06000A34 RID: 2612 RVA: 0x00021B04 File Offset: 0x0001FD04
		public event Action<GenericUserPanelBase> clearing;

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x06000A35 RID: 2613 RVA: 0x00021B3C File Offset: 0x0001FD3C
		// (remove) Token: 0x06000A36 RID: 2614 RVA: 0x00021B74 File Offset: 0x0001FD74
		public event Action<GenericUserPanelBase> cleared;

		// Token: 0x06000A37 RID: 2615 RVA: 0x00021BAC File Offset: 0x0001FDAC
		public bool Bind(object modelo, object buttonModelo = null, DibujadorDynamico.ExtraData extraData = null)
		{
			if (this.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (modelo == null)
			{
				throw new ArgumentNullException("modelo", "modelo null reference.");
			}
			this.Binding();
			Action<GenericUserPanelBase> action = this.binding;
			if (action != null)
			{
				action(this);
			}
			this.m_Model = modelo;
			this.m_buttonModel = buttonModelo;
			if (modelo is ICustomDrawingModel)
			{
				this.m_panel = ((ICustomDrawingModel)modelo).Draw(this.target);
			}
			else
			{
				this.m_panel = DibujadorDynamico.instance.DibujarPanel(modelo, this.target, ref extraData, null, null, null);
			}
			if (this.m_panel == null)
			{
				this.Clear();
				return false;
			}
			if (buttonModelo != null)
			{
				this.m_botones = DibujadorDynamico.instance.AddBotones(buttonModelo, this.m_panel, ref extraData);
			}
			else
			{
				DibujadorDynamico.instance.HideBotonesDePanel(this.m_panel);
			}
			if (modelo is ICustomDrawingModel)
			{
				((ICustomDrawingModel)modelo).SetControlesAPanel(this.m_panel, new UnityAction(this.Clear), new UnityAction(this.Hide));
			}
			else
			{
				DibujadorDynamico.instance.SetControlesAPanel(this.m_panel, modelo, extraData, new UnityAction(this.Clear), new UnityAction(this.Hide));
			}
			DibujadorDynamico.instance.BindPanel(this.m_panel, modelo);
			this.m_cursorHideMod = Singleton<ConfiguracionGeneralDeMouse>.instance.canHideCursorModificableAnd.ObtenerModificadorNotNull(this);
			this.m_cursorOverPanel = Singleton<ConfiguracionGeneralDeInputs>.instance.cursorOverUIElement.ObtenerModificadorNotNull(this);
			this.m_playerInputMod = Singleton<PlayerInputProxy>.instance.activoModificableOverallAND.ObtenerModificadorNotNull(this);
			this.Binded();
			Action<GenericUserPanelBase> action2 = this.binded;
			if (action2 != null)
			{
				action2(this);
			}
			this.Show();
			return true;
		}

		// Token: 0x06000A38 RID: 2616
		protected abstract void Binding();

		// Token: 0x06000A39 RID: 2617
		protected abstract void Binded();

		// Token: 0x06000A3A RID: 2618 RVA: 0x00021D54 File Offset: 0x0001FF54
		public void ActualizarValoresDeModelo()
		{
			this.ActualizarValoresDeModelo(this.m_Model);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00021D62 File Offset: 0x0001FF62
		public void ActualizarValoresDeModelo(object Model)
		{
			if (!this.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (Model is ICustomDrawingModel)
			{
				((ICustomDrawingModel)Model).SetValoresAModelo(this.m_panel);
				return;
			}
			DibujadorDynamico.instance.SetValoresAModelo(Model, this.m_panel);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00021DA0 File Offset: 0x0001FFA0
		public void ActualizarValoresDePanel()
		{
			if (!this.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (this.m_Model is ICustomDrawingModel)
			{
				((ICustomDrawingModel)this.m_Model).SetValoresAPanel(this.m_panel, true);
				return;
			}
			DibujadorDynamico.instance.SetValoresAPanel(this.m_panel, this.m_Model, true);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00021DF7 File Offset: 0x0001FFF7
		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			if (this.m_cursorOverPanel != null)
			{
				this.m_cursorOverPanel.valor.valor = !this.ignorePointerEnter;
			}
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00021E1D File Offset: 0x0002001D
		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (this.m_cursorOverPanel != null)
			{
				this.m_cursorOverPanel.valor.valor = false;
			}
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00021E38 File Offset: 0x00020038
		public virtual void Show()
		{
			IUIPanel panel = this.m_panel;
			if (panel != null)
			{
				panel.transform.gameObject.SetActive(true);
			}
			if (this.m_cursorHideMod != null)
			{
				this.m_cursorHideMod.valor.valor = !this.showCursor;
			}
			if (this.m_playerInputMod != null)
			{
				this.m_playerInputMod.valor.valor = !this.disablePlayerInputs;
			}
			this.Showed();
			Action<GenericUserPanelBase> action = this.showed;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00021EC0 File Offset: 0x000200C0
		public virtual void Hide()
		{
			IUIPanel panel = this.m_panel;
			if (panel != null)
			{
				panel.transform.gameObject.SetActive(false);
			}
			if (this.m_cursorHideMod != null)
			{
				this.m_cursorHideMod.valor.valor = true;
			}
			if (this.m_cursorOverPanel != null)
			{
				this.m_cursorOverPanel.valor.valor = false;
			}
			if (this.m_playerInputMod != null)
			{
				this.m_playerInputMod.valor.valor = true;
			}
			this.Hided();
			Action<GenericUserPanelBase> action = this.hided;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x00021F4B File Offset: 0x0002014B
		protected virtual void Showed()
		{
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00021F4D File Offset: 0x0002014D
		protected virtual void Hided()
		{
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00021F50 File Offset: 0x00020150
		public void Clear()
		{
			if (this.isShowing)
			{
				this.Hide();
			}
			bool flag = false;
			if (this.panelExiste)
			{
				this.Clearing();
				Action<GenericUserPanelBase> action = this.clearing;
				if (action != null)
				{
					action(this);
				}
				Object.Destroy(this.m_panel.transform.gameObject);
				flag = true;
			}
			this.m_panel = null;
			foreach (BotonElementBase botonElementBase in this.m_botones)
			{
				if (botonElementBase != null)
				{
					Object.Destroy(botonElementBase.gameObject);
				}
			}
			this.m_botones.Clear();
			this.m_Model = null;
			this.m_buttonModel = null;
			ModificadorDeBool cursorHideMod = this.m_cursorHideMod;
			if (cursorHideMod != null)
			{
				cursorHideMod.TryRemoverDeOwner(true);
			}
			this.m_cursorHideMod = null;
			ModificadorDeBool playerInputMod = this.m_playerInputMod;
			if (playerInputMod != null)
			{
				playerInputMod.TryRemoverDeOwner(true);
			}
			this.m_playerInputMod = null;
			ModificadorDeBool cursorOverPanel = this.m_cursorOverPanel;
			if (cursorOverPanel != null)
			{
				cursorOverPanel.TryRemoverDeOwner(true);
			}
			this.m_cursorOverPanel = null;
			if (flag)
			{
				this.Cleared();
				Action<GenericUserPanelBase> action2 = this.cleared;
				if (action2 == null)
				{
					return;
				}
				action2(this);
			}
		}

		// Token: 0x06000A44 RID: 2628
		protected abstract void Clearing();

		// Token: 0x06000A45 RID: 2629
		protected abstract void Cleared();

		// Token: 0x06000A46 RID: 2630 RVA: 0x00022080 File Offset: 0x00020280
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.Clear();
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0002208F File Offset: 0x0002028F
		protected sealed override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Show",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x000220A8 File Offset: 0x000202A8
		protected sealed override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Show();
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x000220B6 File Offset: 0x000202B6
		protected sealed override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Hide",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x000220CF File Offset: 0x000202CF
		protected sealed override void OnAplicar3()
		{
			base.OnAplicar3();
			this.Hide();
		}

		// Token: 0x0400042B RID: 1067
		public bool showCursor = true;

		// Token: 0x0400042C RID: 1068
		public bool ignorePointerEnter;

		// Token: 0x0400042D RID: 1069
		public bool disablePlayerInputs;

		// Token: 0x0400042E RID: 1070
		private object m_Model;

		// Token: 0x0400042F RID: 1071
		private object m_buttonModel;

		// Token: 0x04000430 RID: 1072
		[SerializeField]
		[ReadOnlyUI]
		private IUIPanel m_panel;

		// Token: 0x04000431 RID: 1073
		[SerializeField]
		[ReadOnlyUI]
		private List<BotonElementBase> m_botones;

		// Token: 0x04000432 RID: 1074
		[SerializeReference]
		private ModificadorDeBool m_cursorHideMod;

		// Token: 0x04000433 RID: 1075
		[SerializeReference]
		private ModificadorDeBool m_cursorOverPanel;

		// Token: 0x04000434 RID: 1076
		[SerializeReference]
		private ModificadorDeBool m_playerInputMod;
	}
}
