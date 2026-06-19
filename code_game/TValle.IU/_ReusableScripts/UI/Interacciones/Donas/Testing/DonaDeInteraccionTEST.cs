using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Interacciones.Donas.Testing
{
	// Token: 0x02000028 RID: 40
	[RequireComponent(typeof(DonaDeInteraccion))]
	public class DonaDeInteraccionTEST : AplicableCustomMonobehaviour
	{
		// Token: 0x060000FF RID: 255 RVA: 0x000052EC File Offset: 0x000034EC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_dona = base.GetComponent<DonaDeInteraccion>();
			if (this.m_dona == null)
			{
				throw new ArgumentNullException("m_dona", "m_dona null reference.");
			}
			if (this.prefab == null)
			{
				throw new ArgumentNullException("prefab", "prefab null reference.");
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005347 File Offset: 0x00003547
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "dibujar",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005360 File Offset: 0x00003560
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			List<DonaDeInteraccionBase.Item> list = new List<DonaDeInteraccionBase.Item>(this.toTest);
			for (int i = 0; i < list.Count; i++)
			{
				int index = i;
				list[i].clickedCallbackCompleto = delegate(IUIElementoConValor b, DonaDeInteraccionBase d)
				{
					Debug.Log("Test: " + index.ToString());
				};
			}
			this.m_dona.Draw(this, this.prefab, list);
		}

		// Token: 0x04000092 RID: 146
		public BotonElementConValor prefab;

		// Token: 0x04000093 RID: 147
		public List<DonaDeInteraccionBase.Item> toTest = new List<DonaDeInteraccionBase.Item>();

		// Token: 0x04000094 RID: 148
		private DonaDeInteraccion m_dona;
	}
}
