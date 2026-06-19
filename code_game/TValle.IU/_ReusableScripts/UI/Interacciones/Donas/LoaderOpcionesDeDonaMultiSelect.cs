using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Interacciones.Donas
{
	// Token: 0x02000027 RID: 39
	[Obsolete("usar el nuevo loader")]
	public sealed class LoaderOpcionesDeDonaMultiSelect : LoaderOpcionesDeDonaBase
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00004FCB File Offset: 0x000031CB
		public override bool isDrawing
		{
			get
			{
				return this.m_dona.isDrawing;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00004FD8 File Offset: 0x000031D8
		public override DonaDeInteraccionBase dona
		{
			get
			{
				return this.m_dona;
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004FE0 File Offset: 0x000031E0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_dona = DonaDeInteraccionMultiSelect.main;
			if (this.m_dona == null)
			{
				throw new ArgumentNullException("dona", "dona null reference.");
			}
			if (this.m_itemPrefab == null)
			{
				throw new ArgumentNullException("m_itemPrefab", "m_itemPrefab null reference.");
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000503C File Offset: 0x0000323C
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
			LoaderOpcionesDeDonaBase.LoadFrom(base.transform, ref this.m_tempAcceptar);
			if (this.m_tempAcceptar == null)
			{
				foreach (object obj2 in base.transform)
				{
					LoaderOpcionesDeDonaBase.LoadFrom((Transform)obj2, ref this.m_tempAcceptar);
				}
			}
			IOpcionesDeDonaAcceptProductor tempAcceptar = this.m_tempAcceptar;
			this.m_tempAcceptarConfig = ((tempAcceptar != null) ? tempAcceptar.ObtenerItem(this) : null);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00005174 File Offset: 0x00003374
		private void UnLoad()
		{
			this.m_tempAcceptar = null;
			this.m_tempAcceptarConfig = null;
			this.m_temp.Clear();
			this.m_temp2.Clear();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000519C File Offset: 0x0000339C
		public void OnCheckGreyOut(EsGreyOutEventArgs args, object sender)
		{
			if (args.esGreyOut)
			{
				return;
			}
			try
			{
				base.transform.GetComponents<ICheckerIsGreyOut>(LoaderOpcionesDeDonaMultiSelect.m_Checkers);
				for (int i = 0; i < LoaderOpcionesDeDonaMultiSelect.m_Checkers.Count; i++)
				{
					ICheckerIsGreyOut checkerIsGreyOut = LoaderOpcionesDeDonaMultiSelect.m_Checkers[i];
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
				LoaderOpcionesDeDonaMultiSelect.m_Checkers.Clear();
				this.UnLoad();
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005250 File Offset: 0x00003450
		public override void Show()
		{
			try
			{
				this.Load();
				this.m_dona.Draw(this, this.m_itemPrefab, this.m_temp2);
				if (this.m_tempAcceptarConfig != null)
				{
					this.m_dona.DrawAceptar(this, this.m_aceptarPrefab, this.m_tempAcceptarConfig);
				}
			}
			finally
			{
				this.UnLoad();
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000052B4 File Offset: 0x000034B4
		public override void Hide()
		{
			this.m_dona.StopDrawing();
		}

		// Token: 0x0400008A RID: 138
		[SerializeField]
		private ToggleElementSinDescripcion m_itemPrefab;

		// Token: 0x0400008B RID: 139
		[SerializeField]
		private BotonElementConValor m_aceptarPrefab;

		// Token: 0x0400008C RID: 140
		private DonaDeInteraccionMultiSelect m_dona;

		// Token: 0x0400008D RID: 141
		private IOpcionesDeDonaAcceptProductor m_tempAcceptar;

		// Token: 0x0400008E RID: 142
		private DonaDeInteraccionBase.Item m_tempAcceptarConfig;

		// Token: 0x0400008F RID: 143
		private List<IOpcionesDeDonaProductor> m_temp = new List<IOpcionesDeDonaProductor>();

		// Token: 0x04000090 RID: 144
		private List<DonaDeInteraccionBase.Item> m_temp2 = new List<DonaDeInteraccionBase.Item>();

		// Token: 0x04000091 RID: 145
		private static List<ICheckerIsGreyOut> m_Checkers = new List<ICheckerIsGreyOut>();
	}
}
