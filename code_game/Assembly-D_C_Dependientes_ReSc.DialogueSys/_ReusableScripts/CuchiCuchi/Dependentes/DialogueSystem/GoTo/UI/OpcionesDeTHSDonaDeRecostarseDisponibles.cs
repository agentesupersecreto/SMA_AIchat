using System;
using System.Collections.Generic;
using Assets.Base.Controllers.Runtime;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.GoTo.UI
{
	// Token: 0x0200004A RID: 74
	public abstract class OpcionesDeTHSDonaDeRecostarseDisponibles : GenericOpcionesDeTHSDonaDeKeys<int>
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000240 RID: 576
		protected abstract OpcionesDeTHSDonaDeRecostarseDisponibles.Tipo tipo { get; }

		// Token: 0x06000241 RID: 577 RVA: 0x0000C22C File Offset: 0x0000A42C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_controller = this.GetComponentEnRoot(false);
			if (this.m_controller == null)
			{
				throw new ArgumentNullException("m_controller", "m_controller null reference.");
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000C298 File Offset: 0x0000A498
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			List<FemaleAnimatedRecostarseIDs> temp = OpcionesDeTHSDonaDeRecostarseDisponibles.m_TEMP;
			try
			{
				IRecostableConFemaleAnimPose recostableConFemaleAnimPose = this.m_controller.currentRecostableOnRange as IRecostableConFemaleAnimPose;
				OpcionesDeTHSDonaDeRecostarseDisponibles.Tipo tipo = this.tipo;
				if (tipo != OpcionesDeTHSDonaDeRecostarseDisponibles.Tipo.next)
				{
					if (tipo != OpcionesDeTHSDonaDeRecostarseDisponibles.Tipo.prev)
					{
						throw new ArgumentOutOfRangeException(this.tipo.ToString());
					}
					if (recostableConFemaleAnimPose == null)
					{
						if (this.m_controller.animatedPoseID.EsRecostadaAnim())
						{
							resultado.Add(0);
						}
						return;
					}
					recostableConFemaleAnimPose.GetPrevius(this.m_controller.animatedPoseID, ref temp);
				}
				else
				{
					if (recostableConFemaleAnimPose == null)
					{
						return;
					}
					recostableConFemaleAnimPose.GetNext(this.m_controller.animatedPoseID, ref temp);
				}
				for (int i = 0; i < temp.Count; i++)
				{
					FemaleAnimatedRecostarseIDs femaleAnimatedRecostarseIDs = temp[i];
					resultado.Add((int)femaleAnimatedRecostarseIDs);
				}
			}
			finally
			{
				OpcionesDeTHSDonaDeRecostarseDisponibles.m_TEMP.Clear();
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000C37C File Offset: 0x0000A57C
		protected override int KeyDeItemKey(string key, int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000C38C File Offset: 0x0000A58C
		protected override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index].ToString();
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000C3B0 File Offset: 0x0000A5B0
		protected override string TextDeKey(int key)
		{
			string text;
			try
			{
				text = TextoLocalizadoAttribute.Localizado<FemaleAnimatedRecostarseIDs>((FemaleAnimatedRecostarseIDs)key, "US").FirstLetterOrDefaultToUpperCaseOthersToLower();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key.ToString();
			}
			return text;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000C3F4 File Offset: 0x0000A5F4
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.isSelected = false;
			this.selectedAnimID = FemaleAnimatedRecostarseIDs.None;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000C40C File Offset: 0x0000A60C
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			this.isSelected = true;
			this.selectedAnimID = (FemaleAnimatedRecostarseIDs)this.m_dibujando[sender.id];
		}

		// Token: 0x040000ED RID: 237
		protected Character m_Character;

		// Token: 0x040000EE RID: 238
		private FemaleAnimController m_controller;

		// Token: 0x040000EF RID: 239
		public bool isSelected;

		// Token: 0x040000F0 RID: 240
		public FemaleAnimatedRecostarseIDs selectedAnimID;

		// Token: 0x040000F1 RID: 241
		private static List<FemaleAnimatedRecostarseIDs> m_TEMP = new List<FemaleAnimatedRecostarseIDs>();

		// Token: 0x0200008E RID: 142
		public enum Tipo
		{
			// Token: 0x040001AD RID: 429
			next,
			// Token: 0x040001AE RID: 430
			prev
		}
	}
}
