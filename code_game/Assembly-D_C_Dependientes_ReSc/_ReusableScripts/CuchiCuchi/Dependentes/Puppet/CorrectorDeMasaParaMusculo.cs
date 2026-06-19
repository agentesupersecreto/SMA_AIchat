using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x0200010E RID: 270
	[RequireComponent(typeof(PuppetPart))]
	public class CorrectorDeMasaParaMusculo : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600054B RID: 1355 RVA: 0x0001F294 File Offset: 0x0001D494
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuppetMusclePropMods = base.GetComponentInParent<PuppetMusclePropMods>();
			if (this.m_PuppetMusclePropMods == null)
			{
				throw new ArgumentNullException("m_PuppetMusclePropMods", "m_PuppetMusclePropMods null reference.");
			}
			this.m_ScaleChangedBroadcaster = this.GetComponentNotNull<ScaleChangedBroadcaster>();
			this.m_ScaleChangedBroadcaster.AddTarget(base.transform, false);
			this.m_VolumenChangedBroadCaster = this.GetComponentNotNull<VolumenChangedBroadCaster>();
			this.m_parte = base.GetComponent<PuppetPart>();
			this.m_parte.onInitiated += this.M_parte_onInitiated;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0001F320 File Offset: 0x0001D520
		private void M_parte_onInitiated(object obj)
		{
			PuppetMusclePropMods.PropModificables propModificables = this.m_PuppetMusclePropMods.Obtener(this.m_parte.muscle);
			if (propModificables == null)
			{
				throw new ArgumentNullException("propModificable", "propModificable null reference.");
			}
			this.m_massMod = propModificables.modificables.muscleMass.ObtenerModificadorNotNull(this);
			switch (this.m_VolumenChangedBroadCaster.tipoDeCollider)
			{
			case VolumenChangedBroadCaster.TipoDeCollider.box:
				this.m_defaultVolumen = ExtendedMonoBehaviour.Volumen((BoxCollider)this.m_parte.muscle.colliders[0]);
				return;
			case VolumenChangedBroadCaster.TipoDeCollider.sphere:
				this.m_defaultVolumen = ExtendedMonoBehaviour.Volumen((SphereCollider)this.m_parte.muscle.colliders[0]);
				return;
			case VolumenChangedBroadCaster.TipoDeCollider.capsule:
				this.m_defaultVolumen = ExtendedMonoBehaviour.Volumen((CapsuleCollider)this.m_parte.muscle.colliders[0]);
				return;
			default:
				throw new ArgumentOutOfRangeException(this.m_VolumenChangedBroadCaster.tipoDeCollider.ToString());
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001F415 File Offset: 0x0001D615
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_ScaleChangedBroadcaster.ScaleChanged += this.M_ScaleChangedBroadcaster_ScaleChanged;
			this.m_VolumenChangedBroadCaster.volumenChanged += this.M_VolumenChangedBroadCaster_volumenChanged;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0001F44B File Offset: 0x0001D64B
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_ScaleChangedBroadcaster.ScaleChanged -= this.M_ScaleChangedBroadcaster_ScaleChanged;
			this.m_VolumenChangedBroadCaster.volumenChanged -= this.M_VolumenChangedBroadCaster_volumenChanged;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0001F482 File Offset: 0x0001D682
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat massMod = this.m_massMod;
			if (massMod == null)
			{
				return;
			}
			massMod.TryRemoverDeOwner(true);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001F4A0 File Offset: 0x0001D6A0
		public void CalculeAndSetMass()
		{
			if (!this.m_parte.isInitiated)
			{
				return;
			}
			float num;
			switch (this.m_VolumenChangedBroadCaster.tipoDeCollider)
			{
			case VolumenChangedBroadCaster.TipoDeCollider.box:
				num = ExtendedMonoBehaviour.Volumen((BoxCollider)this.m_parte.muscle.colliders[0]);
				break;
			case VolumenChangedBroadCaster.TipoDeCollider.sphere:
				num = ExtendedMonoBehaviour.Volumen((SphereCollider)this.m_parte.muscle.colliders[0]);
				break;
			case VolumenChangedBroadCaster.TipoDeCollider.capsule:
				num = ExtendedMonoBehaviour.Volumen((CapsuleCollider)this.m_parte.muscle.colliders[0]);
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_VolumenChangedBroadCaster.tipoDeCollider.ToString());
			}
			float num2 = num / this.m_defaultVolumen;
			if (num2 >= 1f)
			{
				this.m_massMod.valor.valor = Mathf.Lerp(1f, num2, this.weigthSumando);
				return;
			}
			this.m_massMod.valor.valor = Mathf.Lerp(1f, num2, this.weigthRestando);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0001F5AB File Offset: 0x0001D7AB
		private void M_VolumenChangedBroadCaster_volumenChanged(VolumenChangedBroadCaster.TipoDeCollider tipo, Collider collider)
		{
			this.CalculeAndSetMass();
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001F5AB File Offset: 0x0001D7AB
		private void M_ScaleChangedBroadcaster_ScaleChanged(ScaleChangedBroadcaster.Target target)
		{
			this.CalculeAndSetMass();
		}

		// Token: 0x04000450 RID: 1104
		public float weigthSumando = 1f;

		// Token: 0x04000451 RID: 1105
		public float weigthRestando = 1f;

		// Token: 0x04000452 RID: 1106
		private PuppetMusclePropMods m_PuppetMusclePropMods;

		// Token: 0x04000453 RID: 1107
		private ScaleChangedBroadcaster m_ScaleChangedBroadcaster;

		// Token: 0x04000454 RID: 1108
		private VolumenChangedBroadCaster m_VolumenChangedBroadCaster;

		// Token: 0x04000455 RID: 1109
		private PuppetPart m_parte;

		// Token: 0x04000456 RID: 1110
		[SerializeField]
		[ReadOnlyUI]
		private float m_defaultVolumen;

		// Token: 0x04000457 RID: 1111
		[SerializeField]
		private ModificadorDeFloat m_massMod;
	}
}
