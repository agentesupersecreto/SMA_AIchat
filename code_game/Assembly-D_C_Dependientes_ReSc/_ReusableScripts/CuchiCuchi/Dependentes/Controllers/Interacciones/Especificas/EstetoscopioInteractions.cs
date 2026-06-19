using System;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Miscellaneous.Transforms;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001BE RID: 446
	[Obsolete("hay q actializar", true)]
	public sealed class EstetoscopioInteractions : AplicableBehaviour
	{
		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x00034DBA File Offset: 0x00032FBA
		public IInteraccionesDeCharacter currentUser
		{
			get
			{
				return this.m_currentUser;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000AA9 RID: 2729 RVA: 0x00034DC2 File Offset: 0x00032FC2
		public IIKUpdater currentUserUpdater
		{
			get
			{
				return this.m_currentUserUpdater;
			}
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x00034DCC File Offset: 0x00032FCC
		protected override void AwakeUnityEvent()
		{
			Debug.LogError("Añadir StretchToL y StretchToR", this);
			base.AwakeUnityEvent();
			if (this.piel == null)
			{
				throw new ArgumentNullException("piel", "piel null reference.");
			}
			if (this.copiadorL == null)
			{
				throw new ArgumentNullException("copiadorL", "copiadorL null reference.");
			}
			if (this.copiadorR == null)
			{
				throw new ArgumentNullException("copiadorR", "copiadorR null reference.");
			}
			if (this.copiadorTomarR == null)
			{
				throw new ArgumentNullException("copiadorTomarR", "copiadorTomarR null reference.");
			}
			if (this.interaccionToggleOrejeras == null)
			{
				throw new ArgumentNullException("interaccionDosManos", "interaccionDosManos null reference.");
			}
			if (this.interaccionTomarLector == null)
			{
				throw new ArgumentNullException("interaccionTomarLector", "interaccionTomarLector null reference.");
			}
			if (this.interaccionLectorHaciaAdelante == null)
			{
				throw new ArgumentNullException("interaccionLectorHaciaAdelante", "interaccionLectorHaciaAdelante null reference.");
			}
			if (this.interaccionHacerLectura == null)
			{
				throw new ArgumentNullException("interaccionHacerLectura", "interaccionHacerLectura null reference.");
			}
			this.piel.skinAdded += this.Piel_skinAdded;
			this.piel.skinRemoved += this.Piel_skinRemoved;
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x00034F08 File Offset: 0x00033108
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.piel.skinAdded -= this.Piel_skinAdded;
			this.piel.skinRemoved -= this.Piel_skinRemoved;
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x00034F3F File Offset: 0x0003313F
		private void M_currentUserUpdater_passing(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (IKEventData.id != this.ikIndex)
			{
				return;
			}
			if (PassEventData.index != this.passIndex)
			{
				return;
			}
			this.piel.ActualizarEstado();
			this.UpdateTodo();
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x00034F71 File Offset: 0x00033171
		private void M_currentUserUpdater_physicsIKUpdated(IIKUpdater obj)
		{
			this.piel.ActualizarEstado();
			if (this.updateAfterPhycisIK)
			{
				this.UpdateTodo();
			}
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x00034F8C File Offset: 0x0003318C
		private void UpdateTodo()
		{
			this.piel.ActualizarTransforms();
			this.copiadorL.Copiar();
			this.copiadorR.Copiar();
			this.copiadorTomarR.Copiar();
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x00034FBC File Offset: 0x000331BC
		private void Piel_skinAdded(Skin obj)
		{
			this.m_currentUser = obj.owner.GetComponentEnRoot(false);
			if (this.m_currentUser != null)
			{
				this.interaccionToggleOrejeras.tryEjecutarHandler = new InteraccionTryEjecutarHanlder(this.ToogleOrejerasHandler);
				if (!this.m_currentUser.TryAddInteraction(this.interaccionToggleOrejerasID, this.interaccionToggleOrejeras))
				{
					throw new InvalidOperationException();
				}
				if (!this.m_currentUser.TryAddInteraction(this.interaccionTomarLectorID, this.interaccionTomarLector))
				{
					throw new InvalidOperationException();
				}
				if (!this.m_currentUser.TryAddInteraction(this.interaccionLectorHaciaAdelanteID, this.interaccionLectorHaciaAdelante))
				{
					throw new InvalidOperationException();
				}
				if (!this.m_currentUser.TryAddInteraction(this.interaccionHacerLecturaID, this.interaccionHacerLectura))
				{
					throw new InvalidOperationException();
				}
			}
			this.m_currentUserUpdater = obj.owner.GetComponentEnRoot(false);
			if (this.m_currentUserUpdater == null)
			{
				throw new ArgumentNullException("m_currentUserUpdater", "m_currentUserUpdater null reference.");
			}
			this.m_currentUserUpdater.onSingleIKUpdatingPass1 += this.M_currentUserUpdater_passing;
			this.m_currentUserUpdater.onPhysicsIKUpdated += this.M_currentUserUpdater_physicsIKUpdated;
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x000350D4 File Offset: 0x000332D4
		private void Piel_skinRemoved(Skin obj)
		{
			if (this.m_currentUser != null)
			{
				if (!this.m_currentUser.TryRemoveInteraction(this.interaccionToggleOrejerasID))
				{
					throw new InvalidOperationException();
				}
				if (!this.m_currentUser.TryRemoveInteraction(this.interaccionTomarLectorID))
				{
					throw new InvalidOperationException();
				}
				if (!this.m_currentUser.TryRemoveInteraction(this.interaccionLectorHaciaAdelanteID))
				{
					throw new InvalidOperationException();
				}
				if (!this.m_currentUser.TryRemoveInteraction(this.interaccionHacerLecturaID))
				{
					throw new InvalidOperationException();
				}
				this.m_currentUser = null;
			}
			if (this.m_currentUserUpdater != null)
			{
				this.m_currentUserUpdater.onSingleIKUpdatingPass1 -= this.M_currentUserUpdater_passing;
				this.m_currentUserUpdater.onPhysicsIKUpdated -= this.M_currentUserUpdater_physicsIKUpdated;
				this.m_currentUserUpdater = null;
			}
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x00035191 File Offset: 0x00033391
		private bool ToogleOrejerasHandler(Interaccion interaccion, out int prioridad, out float duracion, out ControllerPrioridadConfig priConfig, out float velocidadMod, out bool usartransiciones)
		{
			prioridad = int.MaxValue;
			duracion = (this.interaccionToggleOrejeras.ObtenerDuracionPorDefecto() * 0.5f + this.piel.timeToChangeState) * this.durationMod;
			priConfig = ControllerPrioridadConfig.interrumpir;
			velocidadMod = 1f;
			usartransiciones = false;
			return true;
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x000351D4 File Offset: 0x000333D4
		public void ToggleState()
		{
			float num = (this.interaccionToggleOrejeras.ObtenerDuracionPorDefecto() * 0.5f + this.piel.timeToChangeState) * this.durationMod;
			this.interaccionToggleOrejeras.Ejecutar(int.MaxValue, num, ControllerPrioridadConfig.interrumpir, 1f, 1f, false);
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00035224 File Offset: 0x00033424
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.ToggleState();
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x00035232 File Offset: 0x00033432
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Toggle Estado",
				editorTimeVisible = false
			};
		}

		// Token: 0x0400080B RID: 2059
		public float durationMod = 1f;

		// Token: 0x0400080C RID: 2060
		public int ikIndex = -1;

		// Token: 0x0400080D RID: 2061
		public int passIndex = -1;

		// Token: 0x0400080E RID: 2062
		public bool updateAfterPhycisIK = true;

		// Token: 0x0400080F RID: 2063
		public EstetoscopioPiel piel;

		// Token: 0x04000810 RID: 2064
		public TrasnformCopiadorManual copiadorL;

		// Token: 0x04000811 RID: 2065
		public TrasnformCopiadorManual copiadorR;

		// Token: 0x04000812 RID: 2066
		public TrasnformCopiadorManual copiadorTomarR;

		// Token: 0x04000813 RID: 2067
		[SerializeField]
		private Interaccion interaccionToggleOrejeras;

		// Token: 0x04000814 RID: 2068
		[SerializeField]
		private int interaccionToggleOrejerasID = 10013;

		// Token: 0x04000815 RID: 2069
		[SerializeField]
		private Interaccion interaccionTomarLector;

		// Token: 0x04000816 RID: 2070
		[SerializeField]
		private int interaccionTomarLectorID = 10014;

		// Token: 0x04000817 RID: 2071
		[SerializeField]
		private Interaccion interaccionLectorHaciaAdelante;

		// Token: 0x04000818 RID: 2072
		[SerializeField]
		private int interaccionLectorHaciaAdelanteID = 10015;

		// Token: 0x04000819 RID: 2073
		[SerializeField]
		private Interaccion interaccionHacerLectura;

		// Token: 0x0400081A RID: 2074
		[SerializeField]
		private int interaccionHacerLecturaID = 10016;

		// Token: 0x0400081B RID: 2075
		private IIKUpdater m_currentUserUpdater;

		// Token: 0x0400081C RID: 2076
		private IInteraccionesDeCharacter m_currentUser;
	}
}
