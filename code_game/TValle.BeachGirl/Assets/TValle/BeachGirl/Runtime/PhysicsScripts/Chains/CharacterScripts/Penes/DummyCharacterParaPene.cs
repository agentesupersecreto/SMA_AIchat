using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets.TValle.BeachGirl.Runtime.Characteres.Props;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Penes
{
	// Token: 0x0200007C RID: 124
	public class DummyCharacterParaPene : DummyCharacterParaProps, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable, IMaleCharacter, ICharacterUnico, IToyPropCharacter, IPropCharacter, IPertenecibleDeCharacter
	{
		// Token: 0x06000335 RID: 821 RVA: 0x00009C9E File Offset: 0x00007E9E
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_pene == null)
			{
				this.m_pene = base.GetComponentInChildren<Penetrador>(true);
				yield return null;
			}
			yield return base.YieldStartUnityEvent();
			yield break;
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00009CAD File Offset: 0x00007EAD
		public override IPene peneDeCharacter
		{
			get
			{
				return this.m_pene;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00009CB5 File Offset: 0x00007EB5
		public IPene sexualProp
		{
			get
			{
				return this.m_pene;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000338 RID: 824 RVA: 0x00009CBD File Offset: 0x00007EBD
		public override float estatura
		{
			get
			{
				return this.m_pene.worldLength;
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00009CCC File Offset: 0x00007ECC
		public override bool ObjetoEsProp(Transform obj)
		{
			if (base.ObjetoEsProp(obj))
			{
				return true;
			}
			Transform puntoBaseTransform = this.m_pene.penisLinearChain.puntoBaseTransform;
			Transform transform = this.m_pene.penisLinearChain.transform;
			return obj.IsChildOf(transform) || obj.IsChildOf(puntoBaseTransform);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00009D20 File Offset: 0x00007F20
		Transform ICharacterRoot.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00009D28 File Offset: 0x00007F28
		T ICharacterRoot.GetComponentInChildren<T>()
		{
			return base.GetComponentInChildren<T>();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00009D30 File Offset: 0x00007F30
		T ICharacterRoot.GetComponentInParent<T>()
		{
			return base.GetComponentInParent<T>();
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00009D38 File Offset: 0x00007F38
		T ICharacterRoot.GetComponentInParent<T>(bool includeInactive)
		{
			return base.GetComponentInParent<T>(includeInactive);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00009D41 File Offset: 0x00007F41
		T ICharacterRoot.GetComponentInChildren<T>(bool includeInactive)
		{
			return base.GetComponentInChildren<T>(includeInactive);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00009D4A File Offset: 0x00007F4A
		T ICharacterRoot.GetComponent<T>()
		{
			return base.GetComponent<T>();
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00009D52 File Offset: 0x00007F52
		void ICharacterRoot.GetComponentsInChildren<T>(List<T> results)
		{
			base.GetComponentsInChildren<T>(results);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00009D5B File Offset: 0x00007F5B
		void ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive, List<T> result)
		{
			base.GetComponentsInChildren<T>(includeInactive, result);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00009D65 File Offset: 0x00007F65
		T[] ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive)
		{
			return base.GetComponentsInChildren<T>(includeInactive);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00009D6E File Offset: 0x00007F6E
		Coroutine ICharacterRoot.StartCoroutine(IEnumerator routine)
		{
			return base.StartCoroutine(routine);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00009D77 File Offset: 0x00007F77
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00009D7F File Offset: 0x00007F7F
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x040001EC RID: 492
		[SerializeField]
		private Penetrador m_pene;
	}
}
