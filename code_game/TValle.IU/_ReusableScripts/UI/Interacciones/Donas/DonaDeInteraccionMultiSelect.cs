using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Interacciones.Donas
{
	// Token: 0x02000021 RID: 33
	public sealed class DonaDeInteraccionMultiSelect : DonaDeInteraccionBase<DonaDeInteraccionMultiSelect, ToggleElementSinDescripcion>
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x000047E2 File Offset: 0x000029E2
		public static DonaDeInteraccionMultiSelect main
		{
			get
			{
				return DonaDeInteraccionMultiSelect.m_main;
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000047E9 File Offset: 0x000029E9
		protected override void AwakeUnityEvent()
		{
			DonaDeInteraccionMultiSelect.m_main = this;
			base.AwakeUnityEvent();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000047F8 File Offset: 0x000029F8
		public void DrawAceptar(Component user, BotonElementConValor template, DonaDeInteraccionBase.Item configDeItem)
		{
			if (template == null)
			{
				throw new ArgumentNullException("template", "template null reference.");
			}
			if (user != base.currentUser)
			{
				throw new InvalidOperationException("Debe ser el mismo usuario");
			}
			template.gameObject.SetActive(false);
			Vector3 zero = Vector3.zero;
			BotonElementConValor botonElementConValor = Object.Instantiate<BotonElementConValor>(template, this.centroDePuntos, false);
			botonElementConValor.transform.localPosition = zero;
			botonElementConValor.boton.enabled = true;
			if (configDeItem.grayOut)
			{
				Image[] components = botonElementConValor.GetComponents<Image>();
				for (int i = 0; i < components.Length; i++)
				{
					Color gray = Color.gray;
					gray.a = 0.333f;
					components[i].color = gray;
				}
			}
			botonElementConValor.gameObject.SetActive(true);
			IUIElementoConLabel iuielementoConLabel = botonElementConValor;
			if (iuielementoConLabel != null)
			{
				if (configDeItem.grayOut)
				{
					Color color = iuielementoConLabel.label.color;
					color.a = 0.444f;
					iuielementoConLabel.label.color = color;
				}
				iuielementoConLabel.label.text = configDeItem.text;
			}
			if (!string.IsNullOrEmpty(configDeItem.modelo) && configDeItem.modeloInstanceType != null)
			{
				botonElementConValor.Bind(configDeItem.modelo, configDeItem.modeloInstanceType, false);
			}
			this.AddListenersToAcceptButtonInstance(botonElementConValor, configDeItem);
			this.m_clickedCallbackCompletoDeAceptar = configDeItem.clickedCallbackCompleto;
			this.m_aceptarBoton = botonElementConValor;
			base.UpdatePanelAndCursor();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000494D File Offset: 0x00002B4D
		public override void StopDrawing()
		{
			base.StopDrawing();
			if (this.m_aceptarBoton)
			{
				Object.Destroy(this.m_aceptarBoton.gameObject);
			}
			this.m_aceptarBoton = null;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004979 File Offset: 0x00002B79
		protected override void ApplyInitialStateToButtonInstance(ToggleElementSinDescripcion instance, DonaDeInteraccionBase.Item config)
		{
			instance.toggle.enabled = !config.grayOut;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004990 File Offset: 0x00002B90
		protected override void AddListenersToButtonInstance(ToggleElementSinDescripcion instance, DonaDeInteraccionBase.Item config)
		{
			if (config.clickedCallback != null)
			{
				instance.onValueChanged.AddListener(delegate(IUIElementoConValor e)
				{
					config.clickedCallback();
				});
			}
			instance.onValueChanged.AddListener(new UnityAction<IUIElementoConValor>(this.OnClicked));
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000049E8 File Offset: 0x00002BE8
		private void OnClicked(IUIElementoConValor elemento)
		{
			UnityAction<IUIElementoConValor, DonaDeInteraccionBase> unityAction;
			if (this.m_callBacksDeItemsDeDona.TryGetValue(elemento, out unityAction) && unityAction != null)
			{
				unityAction(elemento, this);
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004A10 File Offset: 0x00002C10
		private void AddListenersToAcceptButtonInstance(BotonElementConValor instance, DonaDeInteraccionBase.Item config)
		{
			if (config.clickedCallback != null)
			{
				instance.onClicked.AddListener(config.clickedCallback);
			}
			instance.onClickedElement.AddListener(new UnityAction<IUIBoton>(this.OnClicked));
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004A42 File Offset: 0x00002C42
		private void OnClicked(IUIBoton elemento)
		{
			UnityAction<IUIElementoConValor, DonaDeInteraccionBase> clickedCallbackCompletoDeAceptar = this.m_clickedCallbackCompletoDeAceptar;
			if (clickedCallbackCompletoDeAceptar == null)
			{
				return;
			}
			clickedCallbackCompletoDeAceptar(elemento as IUIElementoConValor, this);
		}

		// Token: 0x04000077 RID: 119
		private static DonaDeInteraccionMultiSelect m_main;

		// Token: 0x04000078 RID: 120
		private UnityAction<IUIElementoConValor, DonaDeInteraccionBase> m_clickedCallbackCompletoDeAceptar;

		// Token: 0x04000079 RID: 121
		[SerializeField]
		[ReadOnlyUI]
		private BotonElementConValor m_aceptarBoton;
	}
}
