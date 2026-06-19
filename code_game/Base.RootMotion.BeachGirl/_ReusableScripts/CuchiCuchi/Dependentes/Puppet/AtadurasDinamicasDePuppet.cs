using System;
using System.Collections.Generic;
using Assets.Base.Behaviours.Runtime;
using Assets.Base.RootMotion.BeachGirl.Runtime.Ataduras.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x020000FA RID: 250
	public sealed class AtadurasDinamicasDePuppet : CustomUpdatedMonobehaviourBase, IAtadurasDePuppetAI
	{
		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x0002AB81 File Offset: 0x00028D81
		public sealed override int updateEvent1Index
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0002AB84 File Offset: 0x00028D84
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<ICharacter>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_DeteccionDePuntosDeApoyoDePuppet = base.GetComponentInParent<DeteccionDePuntosDeApoyoDePuppet>();
			if (this.m_DeteccionDePuntosDeApoyoDePuppet == null)
			{
				throw new ArgumentNullException("m_DeteccionDePuntosDeApoyoDePuppet", "m_DeteccionDePuntosDeApoyoDePuppet null reference.");
			}
			this.m_AtadurasDePuppetController = this.m_DeteccionDePuntosDeApoyoDePuppet.GetComponentInChildren<AtadurasDePuppetController>();
			if (this.m_AtadurasDePuppetController == null)
			{
				throw new ArgumentNullException("m_AtadurasDePuppetController", "m_AtadurasDePuppetController null reference.");
			}
			this.m_InteractionEffectorController = this.m_DeteccionDePuntosDeApoyoDePuppet.GetComponentInChildren<IInteractionController>();
			if (this.m_InteractionEffectorController == null)
			{
				throw new ArgumentNullException("m_InteractionEffectorController", "m_InteractionEffectorController null reference.");
			}
			this.checkCoolDown.SetDefault(this.checkCoolDown.@default, 0.1f);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0002AC58 File Offset: 0x00028E58
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_AtadurasDePuppetController.enabled && this.m_AtadurasDePuppetController.gameObject.activeInHierarchy)
			{
				this.m_AtadurasDePuppetController.DetenerOrdenes();
			}
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0002AC8B File Offset: 0x00028E8B
		public void Forzar(TipoDeAtaduraDePuppet tipo, float weight)
		{
			this.m_forzandoPuppetToAnim.Add((int)tipo, weight);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0002AC9A File Offset: 0x00028E9A
		public void DejarDeForzar(TipoDeAtaduraDePuppet tipo)
		{
			this.m_forzandoPuppetToAnim.Remove((int)tipo);
			this.m_estabaforzandoPuppetToAnim.Add((int)tipo);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0002ACB6 File Offset: 0x00028EB6
		public void Ignorar(TipoDeAtaduraDePuppet tipo)
		{
			this.m_ignorar.Add((int)tipo);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0002ACC5 File Offset: 0x00028EC5
		public void DejarDeIgnorar(TipoDeAtaduraDePuppet tipo)
		{
			this.m_ignorar.Remove((int)tipo);
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0002ACD4 File Offset: 0x00028ED4
		[Obsolete("hace conflicto con interacciones segundarias", true)]
		public void Forzar(TipoDeMuscleAlQueSePuedeAtar from, TipoDeMuscleAlQueSePuedeAtar to)
		{
			this.m_forzandoPuppetToPuppetFrom.Add((int)from);
			this.m_forzandoPuppetToPuppetTo.Add((int)to);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0002ACF0 File Offset: 0x00028EF0
		[Obsolete("hace conflicto con interacciones segundarias", true)]
		public void DejarDeForzar(TipoDeMuscleAlQueSePuedeAtar tipo)
		{
			int num = this.m_forzandoPuppetToPuppetFrom.IndexOf((int)tipo);
			if (num >= 0)
			{
				this.m_forzandoPuppetToPuppetFrom.RemoveAt(num);
				this.m_forzandoPuppetToPuppetTo.RemoveAt(num);
				this.m_estabaforzandoPuppetToPuppet.Add((int)tipo);
			}
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0002AD34 File Offset: 0x00028F34
		public sealed override void OnUpdateEvent1()
		{
			if (this.checkCoolDown.isOn)
			{
				return;
			}
			this.checkCoolDown.ApplyRandomMod(0.1f);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.piernaL.dos, TipoDeAtaduraDePuppet.pieL);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.piernaR.dos, TipoDeAtaduraDePuppet.pieR);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.piernaL.uno, TipoDeAtaduraDePuppet.rodillaL);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.piernaR.uno, TipoDeAtaduraDePuppet.rodillaR);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.piernaL.zero, TipoDeAtaduraDePuppet.caderaL);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.piernaR.zero, TipoDeAtaduraDePuppet.caderaR);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.brazoL.dos, TipoDeAtaduraDePuppet.manoL);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.brazoR.dos, TipoDeAtaduraDePuppet.manoR);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.brazoL.uno, TipoDeAtaduraDePuppet.codoL);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.brazoR.uno, TipoDeAtaduraDePuppet.codoR);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.brazoL.zero, TipoDeAtaduraDePuppet.hombroL);
			this.UpdatePunto(this.m_DeteccionDePuntosDeApoyoDePuppet.brazoR.zero, TipoDeAtaduraDePuppet.hombroR);
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x0002AE78 File Offset: 0x00029078
		private void UpdatePunto(DeteccionDePuntosDeApoyoBase.PuntoBase punto, TipoDeAtaduraDePuppet tipo)
		{
			bool flag;
			FullBodyBipedEffector fullBodyBipedEffector = AtadurasDePuppetController.TipoAEffector(tipo, out flag);
			float num;
			bool flag2 = this.m_forzandoPuppetToAnim.TryGetValue((int)tipo, out num);
			if (!this.m_ignorar.Contains((int)tipo) && this.m_character.isAlive && ((punto.apoyado && this.m_InteractionEffectorController.PuedeApoyarse(fullBodyBipedEffector, flag)) || flag2))
			{
				Collider contra = punto.contra;
				Rigidbody rigidbody = ((contra != null) ? contra.attachedRigidbody : null);
				Muscle muscle = ((rigidbody == null) ? null : this.m_DeteccionDePuntosDeApoyoDePuppet.puppetMaster.TryGetMuscle(rigidbody));
				this.m_AtadurasDePuppetController.Apoyar(tipo, flag2 ? num : 1f, null, null, muscle);
				return;
			}
			if (!this.m_estabaforzandoPuppetToAnim.Contains((int)tipo))
			{
				this.m_AtadurasDePuppetController.currentStado.DetenerOrdenEnSlot(tipo);
				return;
			}
			this.m_estabaforzandoPuppetToAnim.Remove((int)tipo);
			this.m_AtadurasDePuppetController.currentStado.DetenerOrdenEnSlot(tipo, true);
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0002AF68 File Offset: 0x00029168
		[Obsolete("hace conflicto con interacciones segundarias", true)]
		private void UpdatePunto(TipoDeMuscleAlQueSePuedeAtar from, TipoDeMuscleAlQueSePuedeAtar to)
		{
			if (this.m_character.isAlive)
			{
				this.m_AtadurasDePuppetHaciaMuscleController.Atar(from, to, null, null);
				return;
			}
			if (!this.m_estabaforzandoPuppetToPuppet.Contains((int)from))
			{
				this.m_AtadurasDePuppetHaciaMuscleController.currentStado.DetenerOrdenEnSlot(from);
				return;
			}
			this.m_estabaforzandoPuppetToPuppet.Remove((int)from);
			this.m_AtadurasDePuppetHaciaMuscleController.currentStado.DetenerOrdenEnSlot(from, true);
		}

		// Token: 0x040005CF RID: 1487
		public CoolDown checkCoolDown = new CoolDown(0.666f);

		// Token: 0x040005D0 RID: 1488
		private DeteccionDePuntosDeApoyoDePuppet m_DeteccionDePuntosDeApoyoDePuppet;

		// Token: 0x040005D1 RID: 1489
		private AtadurasDePuppetController m_AtadurasDePuppetController;

		// Token: 0x040005D2 RID: 1490
		[Obsolete("hace conflicto con interacciones segundarias", true)]
		private AtadurasDePuppetHaciaMuscleController m_AtadurasDePuppetHaciaMuscleController;

		// Token: 0x040005D3 RID: 1491
		private IInteractionController m_InteractionEffectorController;

		// Token: 0x040005D4 RID: 1492
		private ICharacter m_character;

		// Token: 0x040005D5 RID: 1493
		private Dictionary<int, float> m_forzandoPuppetToAnim = new Dictionary<int, float>();

		// Token: 0x040005D6 RID: 1494
		private HashSet<int> m_estabaforzandoPuppetToAnim = new HashSet<int>();

		// Token: 0x040005D7 RID: 1495
		private HashSet<int> m_ignorar = new HashSet<int>();

		// Token: 0x040005D8 RID: 1496
		[Obsolete("", true)]
		private List<int> m_forzandoPuppetToPuppetFrom = new List<int>();

		// Token: 0x040005D9 RID: 1497
		[Obsolete("", true)]
		private List<int> m_forzandoPuppetToPuppetTo = new List<int>();

		// Token: 0x040005DA RID: 1498
		[Obsolete("", true)]
		private HashSet<int> m_estabaforzandoPuppetToPuppet = new HashSet<int>();
	}
}
