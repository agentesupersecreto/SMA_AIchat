using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000133 RID: 307
	public class ToggleElementSinDescripcion : UIElemento, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConLabel
	{
		// Token: 0x1700027F RID: 639
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x0001E2E1 File Offset: 0x0001C4E1
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x0001E2E9 File Offset: 0x0001C4E9
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0001E2F4 File Offset: 0x0001C4F4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.toggle == null)
			{
				throw new ArgumentNullException("toggle", "toggle null reference.");
			}
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0001E343 File Offset: 0x0001C543
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnValueChanged));
			}
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0001E372 File Offset: 0x0001C572
		public virtual void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnValueChanged));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0001E3AA File Offset: 0x0001C5AA
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnValueChanged));
			}
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0001E3DD File Offset: 0x0001C5DD
		public object GetValor()
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			return this.toggle.isOn;
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x0001E400 File Offset: 0x0001C600
		public void SetValor(object valor, bool silenced)
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (silenced)
			{
				this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnValueChanged));
			}
			try
			{
				this.toggle.isOn = Convert.ToBoolean(valor);
			}
			finally
			{
				if (silenced)
				{
					this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnValueChanged));
				}
			}
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x0001E480 File Offset: 0x0001C680
		private void _OnValueChanged(bool value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0001E4A6 File Offset: 0x0001C6A6
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0001E4AE File Offset: 0x0001C6AE
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400038E RID: 910
		public TextMeshProUGUI label;

		// Token: 0x0400038F RID: 911
		public Toggle toggle;

		// Token: 0x04000390 RID: 912
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}
