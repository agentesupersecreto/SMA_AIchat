using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Interacciones.Donas
{
	// Token: 0x020000E7 RID: 231
	public abstract class DonaDeInteraccionBase<T_DonaDeInteraccion, T_Button> : DonaDeInteraccionBase where T_DonaDeInteraccion : DonaDeInteraccionBase<T_DonaDeInteraccion, T_Button> where T_Button : UIElemento, IUIElementoConValor
	{
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00018EEF File Offset: 0x000170EF
		public override bool isDrawing
		{
			get
			{
				return this.m_drawing.Count > 0;
			}
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00018EFF File Offset: 0x000170FF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.centroDePuntos == null)
			{
				throw new ArgumentNullException("centroDePuntos", "centroDePuntos null reference.");
			}
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00018F28 File Offset: 0x00017128
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_canShowConfigGeneralMod = Singleton<ConfiguracionGeneralDeVentanasPrincipales>.instance.canShowConfigPanel.ObtenerModificadorNotNull(this);
			ConfiguracionGeneralDeMouse instance = Singleton<ConfiguracionGeneralDeMouse>.instance;
			this.m_canHideCursor = ((instance != null) ? instance.canHideCursorModificableAnd.ObtenerModificadorNotNull(this) : null);
			this.UpdatePanelAndCursor();
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00018F74 File Offset: 0x00017174
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.StopDrawing();
			ModificadorDeBool canShowConfigGeneralMod = this.m_canShowConfigGeneralMod;
			if (canShowConfigGeneralMod != null)
			{
				canShowConfigGeneralMod.TryRemoverDeOwner(true);
			}
			ModificadorDeBool canHideCursor = this.m_canHideCursor;
			if (canHideCursor != null)
			{
				canHideCursor.TryRemoverDeOwner(true);
			}
			this.m_canShowConfigGeneralMod = null;
			this.m_canHideCursor = null;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00018FC4 File Offset: 0x000171C4
		public override void StopDrawing()
		{
			this.m_currentUser = null;
			if (this.m_drawing.Count > 0)
			{
				base.OnStateChanging(false);
			}
			foreach (T_Button t_Button in this.m_drawing)
			{
				Object.Destroy(t_Button.gameObject);
			}
			this.m_drawing.Clear();
			this.m_callBacksDeItemsDeDona.Clear();
			this.UpdatePanelAndCursor();
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00019058 File Offset: 0x00017258
		public void Draw(Component user, T_Button template, IReadOnlyList<DonaDeInteraccionBase.Item> items)
		{
			if (template == null)
			{
				throw new ArgumentNullException("template", "template null reference.");
			}
			template.gameObject.SetActive(false);
			this.StopDrawing();
			if (items.Count == 0)
			{
				return;
			}
			if (items.Count > 0)
			{
				base.OnStateChanging(true);
			}
			float num = this.distanceFromCenter + (float)items.Count * this.distancePerItem;
			num = Mathf.Clamp(num, this.distanceFromCenter, this.distanceFromCenter * 2.5f);
			for (int i = 0; i < items.Count; i++)
			{
				DonaDeInteraccionBase.Item item = items[i];
				Vector3 vector = Quaternion.AngleAxis(base.angleOfIndex(items.Count, i), this.forward) * this.up * num;
				T_Button t_Button = Object.Instantiate<T_Button>(template, this.centroDePuntos, false);
				t_Button.transform.localPosition = vector;
				this.ApplyInitialStateToButtonInstance(t_Button, item);
				if (item.grayOut)
				{
					Image[] components = t_Button.GetComponents<Image>();
					for (int j = 0; j < components.Length; j++)
					{
						Color gray = Color.gray;
						gray.a = 0.333f;
						components[j].color = gray;
					}
				}
				t_Button.gameObject.SetActive(true);
				IUIElementoConLabel iuielementoConLabel = t_Button as IUIElementoConLabel;
				if (iuielementoConLabel != null)
				{
					if (item.grayOut)
					{
						Color color = iuielementoConLabel.label.color;
						color.a = 0.444f;
						iuielementoConLabel.label.color = color;
					}
					iuielementoConLabel.label.text = item.text;
				}
				if (!string.IsNullOrEmpty(item.modelo) && item.modeloInstanceType != null)
				{
					t_Button.Bind(item.modelo, item.modeloInstanceType, false);
				}
				this.AddListenersToButtonInstance(t_Button, item);
				if (item.clickedCallbackCompleto != null)
				{
					this.m_callBacksDeItemsDeDona.Add(t_Button, item.clickedCallbackCompleto);
				}
				this.m_drawing.Add(t_Button);
			}
			this.m_currentUser = user;
			this.UpdatePanelAndCursor();
		}

		// Token: 0x060006E5 RID: 1765
		protected abstract void ApplyInitialStateToButtonInstance(T_Button instance, DonaDeInteraccionBase.Item config);

		// Token: 0x060006E6 RID: 1766
		protected abstract void AddListenersToButtonInstance(T_Button instance, DonaDeInteraccionBase.Item config);

		// Token: 0x060006E7 RID: 1767 RVA: 0x0001927C File Offset: 0x0001747C
		protected void UpdatePanelAndCursor()
		{
			if (this.isDrawing)
			{
				if (this.m_canShowConfigGeneralMod != null)
				{
					this.m_canShowConfigGeneralMod.valor.valor = false;
				}
				if (this.m_canHideCursor != null)
				{
					this.m_canHideCursor.valor.valor = false;
					return;
				}
			}
			else
			{
				if (this.m_canShowConfigGeneralMod != null)
				{
					this.m_canShowConfigGeneralMod.valor.valor = true;
				}
				if (this.m_canHideCursor != null)
				{
					this.m_canHideCursor.valor.valor = true;
				}
			}
		}

		// Token: 0x0400029D RID: 669
		[ReadOnlyUI]
		[SerializeField]
		protected List<T_Button> m_drawing = new List<T_Button>();
	}
}
