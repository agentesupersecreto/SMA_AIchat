using System;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles.Behaviours
{
	// Token: 0x02000021 RID: 33
	[RequireComponent(typeof(ActividadConMaleAndFemaleCharacter))]
	public class AutoRatingFemaleLogicAdder : CustomMonobehaviour
	{
		// Token: 0x06000155 RID: 341 RVA: 0x00007E26 File Offset: 0x00006026
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ScenaConFemaleChar = base.GetComponent<ActividadConMaleAndFemaleCharacter>();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00007E3A File Offset: 0x0000603A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ScenaConFemaleChar.onScenaAndFemaleCharacterLoaded += this.M_ScenaConFemaleChar_onFemaleLoaded;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00007E59 File Offset: 0x00006059
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_ScenaConFemaleChar != null)
			{
				this.m_ScenaConFemaleChar.onScenaAndFemaleCharacterLoaded -= this.M_ScenaConFemaleChar_onFemaleLoaded;
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00007E87 File Offset: 0x00006087
		private void M_ScenaConFemaleChar_onFemaleLoaded(FemaleChar arg1, ActividadConMaleAndFemaleCharacter arg2)
		{
			arg1.transform.GetChildNotNull("AutoRatingLogic", true).GetComponentNotNull<AutoRatingFemaleLogic>();
		}

		// Token: 0x040000C7 RID: 199
		private ActividadConMaleAndFemaleCharacter m_ScenaConFemaleChar;
	}
}
