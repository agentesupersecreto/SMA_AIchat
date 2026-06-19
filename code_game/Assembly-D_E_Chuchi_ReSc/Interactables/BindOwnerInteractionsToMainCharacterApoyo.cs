using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous.Transforms;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x02000176 RID: 374
	[Obsolete("reemplazado por massage controller", true)]
	[RequireComponent(typeof(Interaccion))]
	public class BindOwnerInteractionsToMainCharacterApoyo : CustomMonobehaviour
	{
		// Token: 0x060008D1 RID: 2257 RVA: 0x000286DD File Offset: 0x000268DD
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponent<Interaccion>();
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x000286F1 File Offset: 0x000268F1
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Interaccion.justAntesDeEjecutar += this.M_Interaccion_justAntesDeEjecutar;
			this.m_Interaccion.terminada += this.M_Interaccion_terminada;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00028728 File Offset: 0x00026928
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Interaccion != null)
			{
				this.m_Interaccion.justAntesDeEjecutar -= this.M_Interaccion_justAntesDeEjecutar;
				this.m_Interaccion.terminada -= this.M_Interaccion_terminada;
			}
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00028778 File Offset: 0x00026978
		private void M_Interaccion_justAntesDeEjecutar(Interaccion obj)
		{
			IInteraccionesDeCharacterFemenino interaccionesDeCharacterFemenino = obj.owner as IInteraccionesDeCharacterFemenino;
			if (interaccionesDeCharacterFemenino == null)
			{
				Debug.LogError("se requieren interacciones femeninas");
				return;
			}
			Side side = this.apoyoHandSide;
			InteraccionSegundariaName interaccionSegundariaName;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(this.apoyoSide.ToString());
				}
				interaccionSegundariaName = InteraccionSegundariaName.apoyarHandR;
			}
			else
			{
				interaccionSegundariaName = InteraccionSegundariaName.apoyarHandL;
			}
			SurfacePivotDeInteraction component = interaccionesDeCharacterFemenino.Obtener(interaccionSegundariaName.GetInteractionID()).instancia.GetComponent<SurfacePivotDeInteraction>();
			Transform transform = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.GetComponentInChildren<RecorridoDeMassgeOnMaleBody>().GetApoyo(this.apoyo, this.apoyoSide);
			if (this.m_User != null)
			{
				this.m_User.Clear();
			}
			this.m_User = null;
			this.m_User = new BindOwnerInteractionsToMainCharacterApoyo.User();
			component.superficiePivot.SetPositionAndRotation(transform.position, transform.rotation);
			this.m_User.apoyoFollower = component.superficiePivot.gameObject.AddComponent<MatrixFollower>();
			this.m_User.apoyoFollower.target = transform;
			this.m_User.apoyoFollower.updateEvent = GlobalUpdater.UpdateType.beforeDynamicColliders;
			this.m_User.apoyoFollower.Init();
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00028896 File Offset: 0x00026A96
		private void M_Interaccion_terminada(Interaccion obj)
		{
			if (this.m_User != null)
			{
				this.m_User.Clear();
			}
			this.m_User = null;
		}

		// Token: 0x040006CF RID: 1743
		public PuntoDeApoyoSobreMaleBody apoyo;

		// Token: 0x040006D0 RID: 1744
		public Side apoyoSide;

		// Token: 0x040006D1 RID: 1745
		public Side apoyoHandSide;

		// Token: 0x040006D2 RID: 1746
		private Interaccion m_Interaccion;

		// Token: 0x040006D3 RID: 1747
		[SerializeField]
		private BindOwnerInteractionsToMainCharacterApoyo.User m_User;

		// Token: 0x02000177 RID: 375
		[Serializable]
		public class User
		{
			// Token: 0x060008D7 RID: 2263 RVA: 0x000288B2 File Offset: 0x00026AB2
			public void Clear()
			{
				if (this.apoyoFollower != null)
				{
					Object.Destroy(this.apoyoFollower);
				}
			}

			// Token: 0x040006D4 RID: 1748
			public MatrixFollower apoyoFollower;
		}
	}
}
