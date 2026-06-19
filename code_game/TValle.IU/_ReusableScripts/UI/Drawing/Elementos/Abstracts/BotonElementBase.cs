using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x02000098 RID: 152
	public abstract class BotonElementBase : UIElemento, IUIElementoActivable, IUIElemento, IUIElementoRefreshable, IUIBoton
	{
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x000145E4 File Offset: 0x000127E4
		bool IUIElementoActivable.isActivated
		{
			get
			{
				Button boton = this.m_boton;
				return ((boton != null) ? new bool?(boton.interactable) : null).GetValueOrDefault();
			}
		}

		// Token: 0x17000183 RID: 387
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x00014618 File Offset: 0x00012818
		bool IUIElementoActivable.activatedInitialState
		{
			set
			{
				if (base.isBinded)
				{
					throw new NotSupportedException();
				}
				if (this.m_boton != null)
				{
					this.m_boton.interactable = value;
				}
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x00014642 File Offset: 0x00012842
		OnClickedEvent IUIBoton.onClicked
		{
			get
			{
				return this.onClicked;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x0001464A File Offset: 0x0001284A
		OnClickedBotonEvent IUIBoton.onClickedElement
		{
			get
			{
				return this.onClickedElement;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00014652 File Offset: 0x00012852
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x0001465A File Offset: 0x0001285A
		public IReadOnlyList<Func<bool>> canBeActivatedDelegates { get; set; }

		// Token: 0x060004F1 RID: 1265 RVA: 0x00014664 File Offset: 0x00012864
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_boton == null)
			{
				throw new ArgumentNullException("m_boton", "m_boton null reference.");
			}
			this.m_boton.onClick.AddListener(new UnityAction(this.OnElementoClicked));
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000146B2 File Offset: 0x000128B2
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.Refresh();
			}
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x000146CB File Offset: 0x000128CB
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_boton != null)
			{
				this.m_boton.onClick.RemoveListener(new UnityAction(this.OnElementoClicked));
			}
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x000146FF File Offset: 0x000128FF
		protected void CallEvents()
		{
			OnClickedEvent onClickedEvent = this.onClicked;
			if (onClickedEvent != null)
			{
				onClickedEvent.Invoke();
			}
			OnClickedBotonEvent onClickedBotonEvent = this.onClickedElement;
			if (onClickedBotonEvent == null)
			{
				return;
			}
			onClickedBotonEvent.Invoke(this);
		}

		// Token: 0x060004F5 RID: 1269
		protected abstract void OnElementoClicked();

		// Token: 0x060004F6 RID: 1270 RVA: 0x00014724 File Offset: 0x00012924
		public void Refresh()
		{
			if (this.canBeActivatedDelegates != null && this.canBeActivatedDelegates.Count > 0)
			{
				bool flag = true;
				for (int i = 0; i < this.canBeActivatedDelegates.Count; i++)
				{
					Func<bool> func = this.canBeActivatedDelegates[i];
					bool? flag2 = ((func != null) ? new bool?(func()) : null);
					if (flag2 != null)
					{
						flag = flag2.Value && flag;
					}
				}
				if (this.m_boton != null)
				{
					this.m_boton.interactable = flag;
				}
			}
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x000147D0 File Offset: 0x000129D0
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x000147D8 File Offset: 0x000129D8
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040001E9 RID: 489
		[SerializeField]
		protected Button m_boton;

		// Token: 0x040001EA RID: 490
		public OnClickedEvent onClicked = new OnClickedEvent();

		// Token: 0x040001EB RID: 491
		public OnClickedBotonEvent onClickedElement = new OnClickedBotonEvent();
	}
}
