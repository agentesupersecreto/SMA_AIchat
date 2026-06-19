using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts
{
	// Token: 0x02000029 RID: 41
	[Obsolete("usar la version para THS")]
	public abstract class GenericOpcionesDeDonaDeColleccion : AplicableBehaviour, IOpcionesDeDonaProductor
	{
		// Token: 0x06000103 RID: 259
		[Obsolete("", true)]
		public abstract object DataModelDeIndex(int index);

		// Token: 0x06000104 RID: 260
		[Obsolete("", true)]
		public abstract string ModelDeIndex(int index);

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000105 RID: 261
		public abstract int count { get; }

		// Token: 0x06000106 RID: 262
		public abstract bool DibujarIndex(int index);

		// Token: 0x06000107 RID: 263
		public abstract string ObtenerModeloDeIndex(int index);

		// Token: 0x06000108 RID: 264
		public abstract Type ObtenerModeloInstanceTypeDeIndex(int index);

		// Token: 0x06000109 RID: 265
		public abstract string TextDeIndex(int index);

		// Token: 0x0600010A RID: 266
		public abstract bool IndexEsGreyOut(int index);

		// Token: 0x0600010B RID: 267
		public abstract UnityAction OnClickDeIndex(int index);

		// Token: 0x0600010C RID: 268
		public abstract UnityAction<IUIElementoConValor, DonaDeInteraccionBase> OnClickCompletoDeIndex(int index);

		// Token: 0x0600010D RID: 269 RVA: 0x000053DB File Offset: 0x000035DB
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (DonaDeInteraccion.main != null)
			{
				DonaDeInteraccion.main.changingState += this.Main_changingState;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005406 File Offset: 0x00003606
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (DonaDeInteraccion.main != null)
			{
				DonaDeInteraccion.main.changingState -= this.Main_changingState;
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005432 File Offset: 0x00003632
		private void Main_changingState(bool drawing, DonaDeInteraccionBase sender)
		{
			this.OnDonaStateChanged(drawing, sender);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000543C File Offset: 0x0000363C
		protected virtual void OnDonaStateChanged(bool drawing, DonaDeInteraccionBase sender)
		{
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000543E File Offset: 0x0000363E
		protected virtual void LoadingItems(LoaderOpcionesDeDonaBase caller)
		{
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005440 File Offset: 0x00003640
		protected virtual void LoadedItems(LoaderOpcionesDeDonaBase caller)
		{
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00005444 File Offset: 0x00003644
		public IEnumerable<DonaDeInteraccionBase.Item> ObtenerItems(LoaderOpcionesDeDonaBase caller)
		{
			this.LoadingItems(caller);
			IEnumerable<DonaDeInteraccionBase.Item> enumerable;
			try
			{
				List<int> list = new List<int>();
				for (int i = 0; i < this.count; i++)
				{
					if (this.DibujarIndex(i))
					{
						list.Add(i);
					}
				}
				List<DonaDeInteraccionBase.Item> list2 = new List<DonaDeInteraccionBase.Item>(list.Count);
				foreach (int num in list)
				{
					bool flag = this.IndexEsGreyOut(num);
					DonaDeInteraccionBase.Item item = new DonaDeInteraccionBase.Item
					{
						clickedCallback = this.OnClickDeIndex(num),
						clickedCallbackCompleto = this.OnClickCompletoDeIndex(num),
						grayOut = flag,
						hidden = false,
						text = this.TextDeIndex(num),
						modelo = this.ObtenerModeloDeIndex(num),
						modeloInstanceType = this.ObtenerModeloInstanceTypeDeIndex(num)
					};
					list2.Add(item);
				}
				enumerable = list2;
			}
			finally
			{
				this.LoadedItems(caller);
			}
			return enumerable;
		}
	}
}
