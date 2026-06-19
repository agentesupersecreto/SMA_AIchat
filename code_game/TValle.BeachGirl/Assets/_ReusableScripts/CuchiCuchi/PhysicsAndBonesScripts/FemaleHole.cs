using System;
using System.Collections.Generic;
using Assets.Base.Joints;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000E2 RID: 226
	[Obsolete("", true)]
	public abstract class FemaleHole : Circular8BoneChain, IFemaleHole, IHole, IPenetrable, IComponentStartable, IPhysicsHole
	{
		// Token: 0x1700039E RID: 926
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x0001CF15 File Offset: 0x0001B115
		public sealed override ICharacter owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x0001CF1D File Offset: 0x0001B11D
		public IFemaleChar femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0001CF25 File Offset: 0x0001B125
		public Character characterOwner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x0001CF2D File Offset: 0x0001B12D
		IFemaleChar IFemaleHole.femaleChar
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0001CF35 File Offset: 0x0001B135
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_owner = base.GetComponentInParent<Character>();
			this.m_FemaleChar = this.m_owner as IFemaleChar;
			if (this.m_FemaleChar == null)
			{
				throw new ArgumentNullException("m_FemaleChar", "m_FemaleChar null reference.");
			}
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0001CF74 File Offset: 0x0001B174
		public void ObtenerHolesCollidersDelCharExcluyendo(List<Collider> result, IHole hole)
		{
			if (hole == null)
			{
				result.AddRange(this.m_FemaleChar.vagColliders);
				result.AddRange(this.m_FemaleChar.anusColliders);
				result.AddRange(this.m_FemaleChar.bocaColliders);
				return;
			}
			if (hole != this.m_FemaleChar.vagHole && this.m_FemaleChar.vagColliders != null)
			{
				result.AddRange(this.m_FemaleChar.vagColliders);
			}
			if (hole != this.m_FemaleChar.anusHole && this.m_FemaleChar.anusColliders != null)
			{
				result.AddRange(this.m_FemaleChar.anusColliders);
			}
			if (hole != this.m_FemaleChar.bocaHole && this.m_FemaleChar.bocaColliders != null)
			{
				result.AddRange(this.m_FemaleChar.bocaColliders);
			}
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0001D044 File Offset: 0x0001B244
		GameObject IHole.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x040004CA RID: 1226
		private Character m_owner;

		// Token: 0x040004CB RID: 1227
		private IFemaleChar m_FemaleChar;
	}
}
