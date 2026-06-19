using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000E9 RID: 233
	[RequireComponent(typeof(EmulatedSphereTrigger))]
	public class InteraccionAdderOnRange : InteraccionAdderOnRangeBase<IInteraccionesDeCharacter>
	{
		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x00026761 File Offset: 0x00024961
		public int ID
		{
			get
			{
				if (this.m_ID == null)
				{
					return 0;
				}
				return this.m_ID.GetHashCode();
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x00026778 File Offset: 0x00024978
		public string stringID
		{
			get
			{
				return this.m_ID;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x00026780 File Offset: 0x00024980
		public Interaccion toAdd
		{
			get
			{
				return this.m_Interaccion;
			}
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00026788 File Offset: 0x00024988
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_Interaccion == null)
			{
				throw new ArgumentNullException("m_Interaccion", "m_Interaccion null reference.");
			}
			if (string.IsNullOrWhiteSpace(this.m_ID))
			{
				throw new ArgumentNullException("m_ID", "m_ID null reference.");
			}
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x000267D8 File Offset: 0x000249D8
		protected override void Add(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			int id = this.ID;
			if (interaccionesDeCharacter == null || interaccionesDeCharacter.Contiene(id))
			{
				return;
			}
			interaccionesDeCharacter.TryAddInteraction(id, this.m_Interaccion);
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00026808 File Offset: 0x00024A08
		protected override void Remove(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			int id = this.ID;
			if (interaccionesDeCharacter == null || !interaccionesDeCharacter.Contiene(id))
			{
				return;
			}
			interaccionesDeCharacter.TryRemoveInteraction(id);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00026831 File Offset: 0x00024A31
		protected override ICharacter GetCharacter(IInteraccionesDeCharacter interactable)
		{
			if (interactable == null)
			{
				return null;
			}
			return interactable.character;
		}

		// Token: 0x04000582 RID: 1410
		[Header("Interaccion")]
		[SerializeField]
		private string m_ID;

		// Token: 0x04000583 RID: 1411
		[SerializeField]
		private Interaccion m_Interaccion;
	}
}
