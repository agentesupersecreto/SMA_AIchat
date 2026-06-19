using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x02000178 RID: 376
	[Obsolete("reemplazado por massage controller", true)]
	[RequireComponent(typeof(Interaccion))]
	public class BindOwnerInteractionsToMainCharacterRecorridoApoyo : CustomMonobehaviour
	{
		// Token: 0x060008D9 RID: 2265 RVA: 0x000288CD File Offset: 0x00026ACD
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponent<Interaccion>();
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000288E1 File Offset: 0x00026AE1
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Interaccion.justAntesDeEjecutar += this.M_Interaccion_justAntesDeEjecutar;
			this.m_Interaccion.terminada += this.M_Interaccion_terminada;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00028918 File Offset: 0x00026B18
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Interaccion != null)
			{
				this.m_Interaccion.justAntesDeEjecutar -= this.M_Interaccion_justAntesDeEjecutar;
				this.m_Interaccion.terminada -= this.M_Interaccion_terminada;
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00028968 File Offset: 0x00026B68
		private void M_Interaccion_justAntesDeEjecutar(Interaccion obj)
		{
			IInteraccionesDeCharacterFemenino interaccionesDeCharacterFemenino = obj.owner as IInteraccionesDeCharacterFemenino;
			if (interaccionesDeCharacterFemenino == null)
			{
				Debug.LogError("se requieren interacciones femeninas");
				return;
			}
			Side side = this.recorridoHandSide;
			InteraccionSegundariaName interaccionSegundariaName;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(this.recorridoHandSide.ToString());
				}
				interaccionSegundariaName = InteraccionSegundariaName.massageStartHandR;
			}
			else
			{
				interaccionSegundariaName = InteraccionSegundariaName.massageStartHandL;
			}
			SurfacePivotDeInteraction component = interaccionesDeCharacterFemenino.Obtener(interaccionSegundariaName.GetInteractionID()).instancia.GetComponent<SurfacePivotDeInteraction>();
			InteraccionRootRecorridoCircular interaccionRootRecorridoCircular = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.GetComponentInChildren<RecorridoDeMassgeOnMaleBody>().GetRecorrido(this.recorrido, this.recorridoSide);
			if (this.m_User != null)
			{
				this.m_User.Clear();
			}
			this.m_User = null;
			this.m_User = new BindOwnerInteractionsToMainCharacterRecorridoApoyo.User();
			this.m_User.recorrido = interaccionRootRecorridoCircular;
			this.m_User.recorrido.targetTransform = component.superficiePivot;
			this.m_User.recorrido.Init(null, null);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00028A55 File Offset: 0x00026C55
		private void M_Interaccion_terminada(Interaccion obj)
		{
			if (this.m_User != null)
			{
				this.m_User.Clear();
			}
			this.m_User = null;
		}

		// Token: 0x040006D5 RID: 1749
		public RecorridoDeMassgeOnMaleBody.Recorrido recorrido;

		// Token: 0x040006D6 RID: 1750
		public Side recorridoSide;

		// Token: 0x040006D7 RID: 1751
		public Side recorridoHandSide;

		// Token: 0x040006D8 RID: 1752
		private Interaccion m_Interaccion;

		// Token: 0x040006D9 RID: 1753
		[SerializeField]
		private BindOwnerInteractionsToMainCharacterRecorridoApoyo.User m_User;

		// Token: 0x02000179 RID: 377
		[Serializable]
		public class User
		{
			// Token: 0x060008DF RID: 2271 RVA: 0x00028A71 File Offset: 0x00026C71
			public void Clear()
			{
				if (this.recorrido != null)
				{
					this.recorrido.enabled = false;
					this.recorrido.targetTransform = null;
				}
			}

			// Token: 0x040006DA RID: 1754
			public InteraccionRootRecorridoCircular recorrido;
		}
	}
}
