using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables.Penetradores
{
	// Token: 0x02000182 RID: 386
	[Obsolete("reemplazado por handjob controller", true)]
	[RequireComponent(typeof(Interaccion))]
	public class BindInteractionsExternaToCharacterRecorridoLinearDePenetrador : CustomMonobehaviour
	{
		// Token: 0x0600091E RID: 2334 RVA: 0x00029085 File Offset: 0x00027285
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponent<Interaccion>();
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00029099 File Offset: 0x00027299
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Interaccion.justAntesDeEjecutar += this.M_Interaccion_justAntesDeEjecutar;
			this.m_Interaccion.terminada += this.M_Interaccion_terminada;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x000290D0 File Offset: 0x000272D0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Interaccion != null)
			{
				this.m_Interaccion.justAntesDeEjecutar -= this.M_Interaccion_justAntesDeEjecutar;
				this.m_Interaccion.terminada -= this.M_Interaccion_terminada;
			}
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00029120 File Offset: 0x00027320
		private void M_Interaccion_justAntesDeEjecutar(Interaccion obj)
		{
			if (!(obj.owner is IInteraccionesDeCharacterFemenino))
			{
				Debug.LogError("se requieren interacciones femeninas");
				return;
			}
			SurfaceAndCenterPivotDeInteraction component = this.m_Interaccion.GetComponent<SurfaceAndCenterPivotDeInteraction>();
			InteraccionRootRecorridoLinear interaccionRootRecorridoLinear = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.GetComponentInChildren<RecorridoDeLinearesOnMaleBody>().GetRecorrido(this.recorrido, this.recorridoSide);
			RecorridoLinearDePenetrador component2 = interaccionRootRecorridoLinear.GetComponent<RecorridoLinearDePenetrador>();
			if (this.m_User != null)
			{
				this.m_User.Clear(this);
			}
			this.m_User = null;
			this.m_User = new BindInteractionsExternaToCharacterRecorridoLinearDePenetrador.User();
			this.m_User.recorridoLinearDePenetrador = component2;
			this.m_User.recorrido = interaccionRootRecorridoLinear;
			this.m_User.pivots = component;
			this.m_User.recorrido.targetTransform = component.centerPivot;
			this.m_User.coroutine = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.lateUpdateAfterPupetMaster, this, this.UpdateSurfacePointRutine(this.m_User), null);
			this.m_User.recorrido.Init(null, null);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00029210 File Offset: 0x00027410
		private void M_Interaccion_terminada(Interaccion obj)
		{
			if (this.m_User != null)
			{
				this.m_User.Clear(this);
			}
			this.m_User = null;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0002922D File Offset: 0x0002742D
		private IEnumerator UpdateSurfacePointRutine(BindInteractionsExternaToCharacterRecorridoLinearDePenetrador.User user)
		{
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(0.33f.Random(0.2f));
			for (;;)
			{
				float escala = this.m_Interaccion.owner.character.escala;
				user.pivots.centerPivot.localScale = Vector3.one * escala;
				float num = user.recorridoLinearDePenetrador.penetrador.worldMaxWidth * 0.5f / escala;
				user.pivots.surfacePivot.localPosition = new Vector3(0f, 0f, num);
				yield return w;
			}
			yield break;
		}

		// Token: 0x04000711 RID: 1809
		public RecorridoDeLinearesOnMaleBody.Recorrido recorrido;

		// Token: 0x04000712 RID: 1810
		public Side recorridoSide;

		// Token: 0x04000713 RID: 1811
		public Side recorridoHandSide;

		// Token: 0x04000714 RID: 1812
		private Interaccion m_Interaccion;

		// Token: 0x04000715 RID: 1813
		[SerializeField]
		private BindInteractionsExternaToCharacterRecorridoLinearDePenetrador.User m_User;

		// Token: 0x02000183 RID: 387
		[Serializable]
		public class User
		{
			// Token: 0x06000925 RID: 2341 RVA: 0x00029244 File Offset: 0x00027444
			public void Clear(MonoBehaviour owner)
			{
				if (this.coroutine != null)
				{
					this.coroutine.Stop();
					this.coroutine = null;
				}
				if (this.recorrido != null)
				{
					this.recorrido.enabled = false;
					this.recorrido.targetTransform = null;
					this.recorrido = null;
				}
				this.pivots = null;
				this.recorridoLinearDePenetrador = null;
			}

			// Token: 0x04000716 RID: 1814
			public RecorridoLinearDePenetrador recorridoLinearDePenetrador;

			// Token: 0x04000717 RID: 1815
			public InteraccionRootRecorridoLinear recorrido;

			// Token: 0x04000718 RID: 1816
			public GlobalUpdater.Corrutina coroutine;

			// Token: 0x04000719 RID: 1817
			public SurfaceAndCenterPivotDeInteraction pivots;
		}
	}
}
