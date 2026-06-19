using System;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Interacciones.Donas
{
	// Token: 0x02000020 RID: 32
	public sealed class DonaDeInteraccion : DonaDeInteraccionBase<DonaDeInteraccion, BotonElementConValor>
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x0000474B File Offset: 0x0000294B
		public static DonaDeInteraccion main
		{
			get
			{
				return DonaDeInteraccion.m_main;
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004752 File Offset: 0x00002952
		protected override void AwakeUnityEvent()
		{
			DonaDeInteraccion.m_main = this;
			base.AwakeUnityEvent();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004760 File Offset: 0x00002960
		protected override void ApplyInitialStateToButtonInstance(BotonElementConValor instance, DonaDeInteraccionBase.Item config)
		{
			instance.boton.enabled = !config.grayOut;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004776 File Offset: 0x00002976
		protected override void AddListenersToButtonInstance(BotonElementConValor instance, DonaDeInteraccionBase.Item config)
		{
			if (config.clickedCallback != null)
			{
				instance.onClicked.AddListener(config.clickedCallback);
			}
			instance.onClickedElement.AddListener(new UnityAction<IUIBoton>(this.OnClicked));
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000047A8 File Offset: 0x000029A8
		private void OnClicked(IUIBoton botton)
		{
			UnityAction<IUIElementoConValor, DonaDeInteraccionBase> unityAction;
			if (this.m_callBacksDeItemsDeDona.TryGetValue((IUIElementoConValor)botton, out unityAction) && unityAction != null)
			{
				unityAction((IUIElementoConValor)botton, this);
			}
		}

		// Token: 0x04000076 RID: 118
		private static DonaDeInteraccion m_main;
	}
}
