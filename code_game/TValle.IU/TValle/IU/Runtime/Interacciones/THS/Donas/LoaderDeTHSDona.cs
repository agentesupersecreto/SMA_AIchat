using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Interacciones.Donas;
using InterfaceFields;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000E5 RID: 229
	public class LoaderDeTHSDona : CustomMonobehaviour, IModeloDeTHSDonaProductor
	{
		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x000181C8 File Offset: 0x000163C8
		// (set) Token: 0x060006BD RID: 1725 RVA: 0x000181D5 File Offset: 0x000163D5
		public IModeloDeTHSDonaProductor previus
		{
			get
			{
				return this.m_previus as IModeloDeTHSDonaProductor;
			}
			private set
			{
				this.m_previus = value as Object;
			}
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x000181E3 File Offset: 0x000163E3
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x000181EC File Offset: 0x000163EC
		public THSDonaController.CurrentUserData ObtenerModelo()
		{
			this.Load();
			THSDonaController.CurrentUserData currentUserData2;
			try
			{
				THSDonaController.OnEventoSimpleHandler onEventoSimpleHandler = null;
				THSDonaController.OnEventoSimpleHandler onEventoSimpleHandler2 = null;
				THSDonaController.OnEventoSimpleHandler onEventoSimpleHandler3 = null;
				THSDonaController.OnEventoSimpleHandler onEventoSimpleHandler4 = delegate(THSDonaController.CurrentUserData d, THSDonaController s)
				{
					this.GoBack();
				};
				List<THSDonaController.RadialItemData> list = new List<THSDonaController.RadialItemData>();
				THSDonaController.CurrentUserData currentUserData = new THSDonaController.CurrentUserData();
				currentUserData.user = this;
				currentUserData.config = this.config;
				currentUserData.aceptarText = this.aceptarText;
				for (int i = 0; i < this.m_temp.Count; i++)
				{
					THSDonaController.OnEventoSimpleHandler onEventoSimpleHandler5;
					THSDonaController.OnEventoSimpleHandler onEventoSimpleHandler6;
					THSDonaController.OnEventoSimpleHandler onEventoSimpleHandler7;
					THSDonaController.OnEventoSimpleHandler onEventoSimpleHandler8;
					List<THSDonaController.RadialItemData> list2 = this.m_temp[i].ObtenerModelos(out onEventoSimpleHandler5, out onEventoSimpleHandler6, out onEventoSimpleHandler7, out onEventoSimpleHandler8, this);
					if (onEventoSimpleHandler5 != null)
					{
						onEventoSimpleHandler = (THSDonaController.OnEventoSimpleHandler)Delegate.Combine(onEventoSimpleHandler, onEventoSimpleHandler5);
					}
					if (onEventoSimpleHandler6 != null)
					{
						onEventoSimpleHandler2 = (THSDonaController.OnEventoSimpleHandler)Delegate.Combine(onEventoSimpleHandler2, onEventoSimpleHandler6);
					}
					if (onEventoSimpleHandler7 != null)
					{
						onEventoSimpleHandler3 = (THSDonaController.OnEventoSimpleHandler)Delegate.Combine(onEventoSimpleHandler3, onEventoSimpleHandler7);
					}
					if (onEventoSimpleHandler8 != null)
					{
						onEventoSimpleHandler4 = (THSDonaController.OnEventoSimpleHandler)Delegate.Combine(onEventoSimpleHandler4, onEventoSimpleHandler5);
					}
					list.AddRange(list2);
				}
				currentUserData.onShowed = onEventoSimpleHandler;
				currentUserData.onClosed = onEventoSimpleHandler2;
				currentUserData.onAceptar = onEventoSimpleHandler3;
				currentUserData.onGoBack = onEventoSimpleHandler4;
				currentUserData.radialItemsData = list;
				currentUserData2 = currentUserData;
			}
			finally
			{
				this.UnLoad();
			}
			return currentUserData2;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00018318 File Offset: 0x00016518
		public void DrawFromSelection(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			IModeloDeTHSDonaProductor modeloDeTHSDonaProductor = ((userData != null) ? userData.user : null) as IModeloDeTHSDonaProductor;
			if (modeloDeTHSDonaProductor == null)
			{
				Debug.LogError("current user no es loader, no sera compatible con go back", this);
			}
			this.Draw(modeloDeTHSDonaProductor);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00018350 File Offset: 0x00016550
		public bool Draw(IModeloDeTHSDonaProductor Previus)
		{
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			THSDonaController.CurrentUserData currentUserData = this.ObtenerModelo();
			if (currentUserData == null || currentUserData.radialItemsData.Count == 0)
			{
				return false;
			}
			this.previus = Previus;
			bool flag;
			try
			{
				THSDonaController.instance.Draw(currentUserData);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				this.GoBack();
				flag = false;
			}
			return flag;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x000183C4 File Offset: 0x000165C4
		public void Close()
		{
			THSDonaController.instance.StopDrawing();
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x000183D0 File Offset: 0x000165D0
		public void GoBack()
		{
			if (this.previus == null)
			{
				this.Close();
				return;
			}
			this.previus.Draw(this.previus.previus);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x000183F8 File Offset: 0x000165F8
		public void Inyect(IModeloDeTHSDonaProductorDeItemInfo modelo)
		{
			this.m_inyected.Add(modelo);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00018407 File Offset: 0x00016607
		public void UnInyect(IModeloDeTHSDonaProductorDeItemInfo modelo)
		{
			this.m_inyected.Remove(modelo);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00018418 File Offset: 0x00016618
		private void Load()
		{
			if (this.m_inyected.Count > 0)
			{
				this.m_temp.AddRange(this.m_inyected);
				this.m_temp2 += this.m_inyected.Count;
			}
			LoaderDeTHSDona.LoadFrom(base.transform, this.m_temp);
			foreach (object obj in base.transform)
			{
				LoaderDeTHSDona.LoadFrom((Transform)obj, this.m_temp);
			}
			this.m_temp2 += this.m_temp.Count;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x000184D4 File Offset: 0x000166D4
		private void UnLoad()
		{
			this.m_temp.Clear();
			this.m_temp2 = 0;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x000184E8 File Offset: 0x000166E8
		public void OnCheckGreyOut(EsGreyOutEventArgs args, object sender)
		{
			if (args.esGreyOut)
			{
				return;
			}
			try
			{
				base.transform.GetComponents<ICheckerIsGreyOut>(LoaderDeTHSDona.m_Checkers);
				for (int i = 0; i < LoaderDeTHSDona.m_Checkers.Count; i++)
				{
					ICheckerIsGreyOut checkerIsGreyOut = LoaderDeTHSDona.m_Checkers[i];
					if (((checkerIsGreyOut != null) ? new bool?(checkerIsGreyOut.isGreyOut) : null).GetValueOrDefault(false))
					{
						args.esGreyOut = true;
						return;
					}
				}
				this.Load();
				args.esGreyOut = this.m_temp2 <= 0;
			}
			finally
			{
				LoaderDeTHSDona.m_Checkers.Clear();
				this.UnLoad();
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00018598 File Offset: 0x00016798
		protected static void LoadFrom(Transform target, List<IModeloDeTHSDonaProductorDeItemInfo> result)
		{
			try
			{
				target.GetComponents<IModeloDeTHSDonaProductorDeItemInfo>(LoaderDeTHSDona.m_temp3);
				for (int i = 0; i < LoaderDeTHSDona.m_temp3.Count; i++)
				{
					IModeloDeTHSDonaProductorDeItemInfo modeloDeTHSDonaProductorDeItemInfo = LoaderDeTHSDona.m_temp3[i];
					Behaviour behaviour = modeloDeTHSDonaProductorDeItemInfo as Behaviour;
					if (!(behaviour != null) || behaviour.isActiveAndEnabled)
					{
						result.Add(modeloDeTHSDonaProductorDeItemInfo);
					}
				}
			}
			finally
			{
				LoaderDeTHSDona.m_temp3.Clear();
			}
		}

		// Token: 0x0400028B RID: 651
		public string aceptarText = "Accept";

		// Token: 0x0400028C RID: 652
		[ConstraintType(typeof(IModeloDeTHSDonaProductor), false)]
		[SerializeField]
		private Object m_previus;

		// Token: 0x0400028D RID: 653
		public THSDonaController.CurrentUserData.Config config = new THSDonaController.CurrentUserData.Config();

		// Token: 0x0400028E RID: 654
		private HashSetList<IModeloDeTHSDonaProductorDeItemInfo> m_inyected = new HashSetList<IModeloDeTHSDonaProductorDeItemInfo>();

		// Token: 0x0400028F RID: 655
		private List<IModeloDeTHSDonaProductorDeItemInfo> m_temp = new List<IModeloDeTHSDonaProductorDeItemInfo>();

		// Token: 0x04000290 RID: 656
		private int m_temp2;

		// Token: 0x04000291 RID: 657
		private static List<ICheckerIsGreyOut> m_Checkers = new List<ICheckerIsGreyOut>();

		// Token: 0x04000292 RID: 658
		private static List<IModeloDeTHSDonaProductorDeItemInfo> m_temp3 = new List<IModeloDeTHSDonaProductorDeItemInfo>();
	}
}
