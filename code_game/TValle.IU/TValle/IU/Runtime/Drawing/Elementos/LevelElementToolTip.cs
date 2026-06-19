using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000120 RID: 288
	public class LevelElementToolTip : UIElemento, IUIElementoConDescripcionSimple, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConLabel, IUIElementoRefreshable
	{
		// Token: 0x060008AB RID: 2219 RVA: 0x0001DB62 File Offset: 0x0001BD62
		void IUIElementoRefreshable.Refresh()
		{
			this.RefresItems();
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x0001DB6A File Offset: 0x0001BD6A
		// (set) Token: 0x060008AD RID: 2221 RVA: 0x0001DB77 File Offset: 0x0001BD77
		string IUIElementoConDescripcionSimple.descripcion
		{
			get
			{
				return this.tooltip.infoLeft;
			}
			set
			{
				this.tooltip.infoLeft = value;
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x0001DB85 File Offset: 0x0001BD85
		// (set) Token: 0x060008AF RID: 2223 RVA: 0x0001DB92 File Offset: 0x0001BD92
		float IUIElementoConDescripcionSimple.widthMod
		{
			get
			{
				return this.tooltip.widthMod;
			}
			set
			{
				this.tooltip.widthMod = value;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x0001DBA0 File Offset: 0x0001BDA0
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0001DBA8 File Offset: 0x0001BDA8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.iconPrefab == null)
			{
				throw new ArgumentNullException("iconPrefab", "iconPrefab null reference.");
			}
			if (this.iconsPanel == null)
			{
				throw new ArgumentNullException("iconsPanel", "iconsPanel null reference.");
			}
			if (this.iconPrefab.gameObject.activeSelf)
			{
				this.iconPrefab.gameObject.SetActive(false);
			}
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.tooltip == null)
			{
				throw new ArgumentNullException("tooltip", "tooltip null reference.");
			}
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0001DC56 File Offset: 0x0001BE56
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.RefresItems();
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x0001DC67 File Offset: 0x0001BE67
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.SetValor(initialValue, true);
			}
			this.RefresItems();
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x0001DC8C File Offset: 0x0001BE8C
		public void RefresItems()
		{
			foreach (RectTransform rectTransform in this.m_instantiatedLevelsIcons)
			{
				Object.Destroy(rectTransform.gameObject);
			}
			this.m_instantiatedLevelsIcons.Clear();
			float num = this.m_currentLevel;
			string text = "Current Exp: " + this.m_currentLevel.ToString("0.00") + "/" + this.m_maxLevel.ToString();
			for (int i = 0; i < this.m_maxLevel; i++)
			{
				RectTransform rectTransform2 = Object.Instantiate<RectTransform>(this.iconPrefab, this.iconsPanel, false);
				rectTransform2.anchoredPosition = new Vector2((float)(30 * i), 0f);
				this.m_instantiatedLevelsIcons.Add(rectTransform2);
				float num2;
				if (num >= 1f)
				{
					num2 = 1f;
					num -= 1f;
				}
				else
				{
					num2 = num;
					num = 0f;
				}
				((RectTransform)rectTransform2.GetChild(0)).sizeDelta = new Vector2(Mathf.Lerp(0f, 30f, num2), 30f);
				SimpleTooltip componentInChildren = rectTransform2.GetComponentInChildren<SimpleTooltip>();
				if (componentInChildren == null)
				{
					throw new ArgumentNullException("instanceToolTip", "instanceToolTip null reference.");
				}
				componentInChildren.infoLeft = text;
				string text2 = (this.m_descriptionPerLevel.ContieneIndex(i) ? this.m_descriptionPerLevel[i] : null);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					SimpleTooltip simpleTooltip = componentInChildren;
					simpleTooltip.infoLeft = simpleTooltip.infoLeft + "\n" + text2;
				}
				Color color = (this.m_colorPerLevel.ContieneIndex(i) ? this.m_colorPerLevel[i] : Color.black);
				if (color != Color.black)
				{
					Transform child = rectTransform2.transform.GetChild(0);
					Image image = ((child != null) ? child.GetComponent<Image>() : null);
					if (image != null)
					{
						image.color = color;
					}
				}
				rectTransform2.gameObject.SetActive(true);
			}
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x0001DE90 File Offset: 0x0001C090
		public void SetValor(object valor, bool silenced)
		{
			if (valor == null)
			{
				return;
			}
			if (valor is IMultipleValorElemento<int, float, string[], Color[]>)
			{
				IMultipleValorElemento<int, float, string[], Color[]> multipleValorElemento = (IMultipleValorElemento<int, float, string[], Color[]>)valor;
				this.SetText(multipleValorElemento);
				this.m_descriptionPerLevel = multipleValorElemento.item3;
				this.m_colorPerLevel = multipleValorElemento.item4;
			}
			if (valor is IMultipleValorElemento<int, float, string[]>)
			{
				IMultipleValorElemento<int, float, string[]> multipleValorElemento2 = (IMultipleValorElemento<int, float, string[]>)valor;
				this.SetText(multipleValorElemento2);
				this.m_descriptionPerLevel = multipleValorElemento2.item3;
				return;
			}
			if (valor is IMultipleValorElemento<int, float>)
			{
				this.SetText((IMultipleValorElemento<int, float>)valor);
				this.m_descriptionPerLevel = Array.Empty<string>();
				return;
			}
			throw new NotSupportedException();
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x0001DF17 File Offset: 0x0001C117
		private void SetText(IMultipleValorElemento<int, float> valorCasteado)
		{
			this.m_maxLevel = valorCasteado.item1;
			this.m_currentLevel = valorCasteado.item2;
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0001DF56 File Offset: 0x0001C156
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0001DF5E File Offset: 0x0001C15E
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000372 RID: 882
		public TextMeshProUGUI label;

		// Token: 0x04000373 RID: 883
		public SimpleTooltip tooltip;

		// Token: 0x04000374 RID: 884
		[SerializeField]
		private RectTransform iconPrefab;

		// Token: 0x04000375 RID: 885
		[SerializeField]
		private RectTransform iconsPanel;

		// Token: 0x04000376 RID: 886
		[SerializeField]
		[ReadOnlyUI]
		private int m_maxLevel = 1;

		// Token: 0x04000377 RID: 887
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentLevel;

		// Token: 0x04000378 RID: 888
		[SerializeField]
		[ReadOnlyUI]
		private string[] m_descriptionPerLevel = Array.Empty<string>();

		// Token: 0x04000379 RID: 889
		[SerializeField]
		[ReadOnlyUI]
		private Color[] m_colorPerLevel = Array.Empty<Color>();

		// Token: 0x0400037A RID: 890
		[SerializeField]
		[ReadOnlyUI]
		private List<RectTransform> m_instantiatedLevelsIcons;
	}
}
