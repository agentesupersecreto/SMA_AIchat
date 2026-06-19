using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Interacciones.Donas
{
	// Token: 0x02000026 RID: 38
	[Obsolete("usar el nuevo loader")]
	public sealed class LoaderOpcionesDeDona : LoaderOpcionesDeDonaBase
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00004D55 File Offset: 0x00002F55
		public override bool isDrawing
		{
			get
			{
				return this.m_dona.isDrawing;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00004D62 File Offset: 0x00002F62
		public override DonaDeInteraccionBase dona
		{
			get
			{
				return this.m_dona;
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004D6C File Offset: 0x00002F6C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_dona = DonaDeInteraccion.main;
			if (this.m_dona == null)
			{
				throw new ArgumentNullException("dona", "dona null reference.");
			}
			if (this.m_itemPrefab == null)
			{
				throw new ArgumentNullException("m_itemPrefab", "m_itemPrefab null reference.");
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004DC8 File Offset: 0x00002FC8
		private void Load()
		{
			LoaderOpcionesDeDonaBase.LoadFrom(base.transform, this.m_temp);
			foreach (object obj in base.transform)
			{
				LoaderOpcionesDeDonaBase.LoadFrom((Transform)obj, this.m_temp);
			}
			foreach (IOpcionesDeDonaProductor opcionesDeDonaProductor in this.m_temp)
			{
				this.m_temp2.AddRange(opcionesDeDonaProductor.ObtenerItems(this));
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00004E84 File Offset: 0x00003084
		private void UnLoad()
		{
			this.m_temp.Clear();
			this.m_temp2.Clear();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004E9C File Offset: 0x0000309C
		public void OnCheckGreyOut(EsGreyOutEventArgs args, object sender)
		{
			if (args.esGreyOut)
			{
				return;
			}
			try
			{
				base.transform.GetComponents<ICheckerIsGreyOut>(LoaderOpcionesDeDona.m_Checkers);
				for (int i = 0; i < LoaderOpcionesDeDona.m_Checkers.Count; i++)
				{
					ICheckerIsGreyOut checkerIsGreyOut = LoaderOpcionesDeDona.m_Checkers[i];
					if (((checkerIsGreyOut != null) ? new bool?(checkerIsGreyOut.isGreyOut) : null).GetValueOrDefault(false))
					{
						args.esGreyOut = true;
						return;
					}
				}
				this.Load();
				args.esGreyOut = this.m_temp2.Count == 0;
			}
			finally
			{
				LoaderOpcionesDeDona.m_Checkers.Clear();
				this.UnLoad();
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00004F50 File Offset: 0x00003150
		public override void Show()
		{
			try
			{
				this.Load();
				this.m_dona.Draw(this, this.m_itemPrefab, this.m_temp2);
			}
			finally
			{
				this.UnLoad();
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004F94 File Offset: 0x00003194
		public override void Hide()
		{
			this.m_dona.StopDrawing();
		}

		// Token: 0x04000085 RID: 133
		[SerializeField]
		private BotonElementConValor m_itemPrefab;

		// Token: 0x04000086 RID: 134
		private DonaDeInteraccion m_dona;

		// Token: 0x04000087 RID: 135
		private List<IOpcionesDeDonaProductor> m_temp = new List<IOpcionesDeDonaProductor>();

		// Token: 0x04000088 RID: 136
		private List<DonaDeInteraccionBase.Item> m_temp2 = new List<DonaDeInteraccionBase.Item>();

		// Token: 0x04000089 RID: 137
		private static List<ICheckerIsGreyOut> m_Checkers = new List<ICheckerIsGreyOut>();
	}
}
