using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI
{
	// Token: 0x02000049 RID: 73
	public abstract class OpcionesDeTHSDonaDeGoToDisponibles : GenericOpcionesDeTHSDonaDeKeys<string>
	{
		// Token: 0x06000238 RID: 568 RVA: 0x0000BFFC File Offset: 0x0000A1FC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_FemaleAnimController = this.GetComponentEnRoot(false);
			if (this.m_FemaleAnimController == null)
			{
				throw new ArgumentNullException("m_FemaleAnimController", "m_FemaleAnimController null reference.");
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000C068 File Offset: 0x0000A268
		protected override void LoadKeys(HashSetList<string> resultado)
		{
			if (!Singleton<GoToScenaManager>.IsInScene)
			{
				return;
			}
			if (!this.m_FemaleAnimController.PuedeEjecutarseGOTO())
			{
				return;
			}
			GoToScenaManager instance = Singleton<GoToScenaManager>.instance;
			this.m_CurrentGoTo = instance.CurrentGoTo(this.m_Character.animatorRootMotionTransform, out this.m_CurrentGoToIsTurnedAround, 0.4f, 45f);
			if (this.m_CurrentGoTo != null && this.m_FemaleAnimController.animatedPoseID == FemaleAnimatedPoseIDs.None && this.m_CurrentGoTo.canTurnAround)
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

		// Token: 0x0600023A RID: 570 RVA: 0x0000C135 File Offset: 0x0000A335
		protected sealed override string KeyDeItemKey(string key, int index)
		{
			return this.KeyDeIndex(index);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000C13E File Offset: 0x0000A33E
		protected sealed override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000C14C File Offset: 0x0000A34C
		protected override string TextDeKey(string key)
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

		// Token: 0x0600023D RID: 573 RVA: 0x0000C1B4 File Offset: 0x0000A3B4
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.esTurnedAround = false;
			this.esTurnAround = false;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000C1CC File Offset: 0x0000A3CC
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			bool flag;
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.CurrentGoTo(this.m_Character.animatorRootMotionTransform, out flag, 0.4f, 45f);
			if (goTo != null && goTo.Id == sender.key)
			{
				this.esTurnedAround = flag;
				this.esTurnAround = goTo.canTurnAround;
			}
		}

		// Token: 0x040000E7 RID: 231
		protected Character m_Character;

		// Token: 0x040000E8 RID: 232
		private bool m_CurrentGoToIsTurnedAround;

		// Token: 0x040000E9 RID: 233
		private GoToScenaManager.GoTo m_CurrentGoTo;

		// Token: 0x040000EA RID: 234
		private FemaleAnimController m_FemaleAnimController;

		// Token: 0x040000EB RID: 235
		public bool esTurnedAround;

		// Token: 0x040000EC RID: 236
		public bool esTurnAround;
	}
}
