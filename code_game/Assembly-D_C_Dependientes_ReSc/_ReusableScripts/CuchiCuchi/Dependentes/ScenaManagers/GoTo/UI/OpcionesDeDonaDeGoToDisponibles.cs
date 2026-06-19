using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers.GoTo.UI
{
	// Token: 0x020000F9 RID: 249
	public class OpcionesDeDonaDeGoToDisponibles : GenericOpcionesDeDonaDeKeys<string, OpcionesDeDonaDeGoToDisponibles.CurrentClicked>
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x0001C95D File Offset: 0x0001AB5D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0001C990 File Offset: 0x0001AB90
		protected override void LoadKeys(HashSetList<string> resultado)
		{
			if (!Singleton<GoToScenaManager>.IsInScene)
			{
				return;
			}
			GoToScenaManager instance = Singleton<GoToScenaManager>.instance;
			this.m_CurrentGoTo = instance.CurrentGoTo(this.m_Character.animatorRootMotionTransform, out this.m_CurrentGoToIsTurnedAround, 0.4f, 45f);
			if (this.m_CurrentGoTo != null)
			{
				resultado.Add(this.m_CurrentGoTo.Id);
			}
			for (int i = 0; i < instance.registrados.Count; i++)
			{
				GoToScenaManager.GoTo goTo = instance.registrados[i];
				if (goTo != this.m_CurrentGoTo && goTo.isValid && !goTo.hidden)
				{
					resultado.Add(goTo.Id);
				}
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0001CA35 File Offset: 0x0001AC35
		protected override void LoadedItems(LoaderOpcionesDeDonaBase caller)
		{
			base.LoadedItems(caller);
			this.m_CurrentGoTo = null;
			this.m_CurrentGoToIsTurnedAround = false;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0001CA4C File Offset: 0x0001AC4C
		public override string TextDeKey(string key)
		{
			string text;
			try
			{
				GoToScenaManager instance = Singleton<GoToScenaManager>.instance;
				GoToScenaManager.GoTo goTo = instance.Obtener(key);
				if (this.m_CurrentGoTo != null && goTo == this.m_CurrentGoTo)
				{
					text = instance.turnAroundNombrable.ObtenerNombreDeCurrentLocalization(NombrableResult.firstUpper);
				}
				else
				{
					text = goTo.nombrable.ObtenerNombreDeCurrentLocalization(NombrableResult.firstUpper);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key;
			}
			return text;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0001CAB4 File Offset: 0x0001ACB4
		protected override void OnOpccionCliked(int index, string Key, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			base.OnOpccionCliked(index, Key, button, dona);
			bool flag;
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.CurrentGoTo(this.m_Character.animatorRootMotionTransform, out flag, 0.4f, 45f);
			if (goTo != null && goTo.Id == Key)
			{
				base.lastClicked.esTurnedAround = flag;
				base.lastClicked.esTurnAround = goTo.canTurnAround;
			}
		}

		// Token: 0x040003BC RID: 956
		private Character m_Character;

		// Token: 0x040003BD RID: 957
		private bool m_CurrentGoToIsTurnedAround;

		// Token: 0x040003BE RID: 958
		private GoToScenaManager.GoTo m_CurrentGoTo;

		// Token: 0x020000FA RID: 250
		[Serializable]
		public class CurrentClicked : OpcionesDeDonaCurrentClickedKey<string>
		{
			// Token: 0x040003BF RID: 959
			public bool esTurnAround;

			// Token: 0x040003C0 RID: 960
			public bool esTurnedAround;

			// Token: 0x040003C1 RID: 961
			public bool puedeAplicarsee = true;
		}
	}
}
