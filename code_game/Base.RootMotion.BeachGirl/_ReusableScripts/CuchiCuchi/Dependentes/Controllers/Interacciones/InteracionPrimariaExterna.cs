using System;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000EF RID: 239
	public sealed class InteracionPrimariaExterna : InteraccionPrimariaBase
	{
		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0002874F File Offset: 0x0002694F
		protected override bool detenerTodasDelMismoLayer
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060008E5 RID: 2277 RVA: 0x00028752 File Offset: 0x00026952
		public sealed override IInteractionController user
		{
			get
			{
				return this.m_User;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0002875A File Offset: 0x0002695A
		protected override AnimController animController
		{
			get
			{
				return this.m_animController;
			}
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00028762 File Offset: 0x00026962
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!this.m_datos.isValid)
			{
				Debug.LogWarning(base.name + " Interaccion, no tiene datos validos");
			}
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0002878C File Offset: 0x0002698C
		public bool TryEjecutarOn(Component other, int prioridad, float duracion, ControllerPrioridadConfig priConfig)
		{
			IInteractionController user = this.m_User;
			bool flag;
			try
			{
				ICharacterRoot componentInParent = other.GetComponentInParent<ICharacterRoot>();
				if (componentInParent == null)
				{
					flag = false;
				}
				else
				{
					IInteractionController componentInChildren = componentInParent.GetComponentInChildren<IInteractionController>(false);
					if (componentInChildren == null)
					{
						flag = false;
					}
					else
					{
						this.m_User = componentInChildren;
						if (componentInParent.GetComponentInChildren<AnimController>(false) == null)
						{
							flag = false;
						}
						else
						{
							bool flag2 = base.Ejecutar(prioridad, duracion, priConfig, 1f, 1f, false);
							if (!flag2)
							{
								this.m_User = null;
							}
							flag = flag2;
						}
					}
				}
			}
			finally
			{
				this.m_User = user;
			}
			return flag;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00028814 File Offset: 0x00026A14
		protected override void OnAdded(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			base.OnAdded(interaccionesDeCharacter);
			this.m_User = interaccionesDeCharacter.character.GetComponentInChildren<IInteractionController>(false);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0002882F File Offset: 0x00026A2F
		protected override void OnRemoved(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			base.OnRemoved(interaccionesDeCharacter);
			this.m_User = null;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00028840 File Offset: 0x00026A40
		protected override void OnAplicar()
		{
			if (this.m_User == null)
			{
				this.m_User = this.GetFemaleFromScene();
			}
			if (this.TryEjecutarOn((Component)this.m_User, 2147483647, 10f, ControllerPrioridadConfig.prioridad))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x000288AC File Offset: 0x00026AAC
		protected override void OnAplicar2()
		{
			if (this.m_User == null)
			{
				this.m_User = this.GetFemaleFromScene();
			}
			if (this.TryEjecutarOn((Component)this.m_User, 2147483647, 60f, ControllerPrioridadConfig.prioridad))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00028918 File Offset: 0x00026B18
		protected override void OnAplicar3()
		{
			if (this.m_User == null)
			{
				this.m_User = this.GetFemaleFromScene();
			}
			if (this.TryEjecutarOn((Component)this.m_User, 2147483647, 600f, ControllerPrioridadConfig.prioridad))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00028984 File Offset: 0x00026B84
		private IInteractionController GetFemaleFromScene()
		{
			Animator animator = Object.FindObjectsOfType<Animator>().FirstOrDefault(delegate(Animator a)
			{
				ICharacter componentEnRoot = a.GetComponentEnRoot(false);
				return componentEnRoot != null && componentEnRoot.sexo == Sexo.femenino;
			});
			if (animator == null)
			{
				return null;
			}
			return animator.GetComponentInChildren<IInteractionController>();
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x000289CC File Offset: 0x00026BCC
		protected sealed override void DespuesDeDetenerse()
		{
			base.DespuesDeDetenerse();
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x000289D4 File Offset: 0x00026BD4
		protected sealed override bool AntesDeDetenerse()
		{
			return true;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x000289D7 File Offset: 0x00026BD7
		protected override void OnForzada()
		{
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x000289D9 File Offset: 0x00026BD9
		protected sealed override bool OnPuedeEjecutarseConParametros(InteraccionStartParams parametros)
		{
			return true;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x000289DC File Offset: 0x00026BDC
		protected override void JustoAntesDeEjecutarse(ref InteraccionStartParams parametros)
		{
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x000289DE File Offset: 0x00026BDE
		protected sealed override void DespuesDeEjecutarse(InteraccionStartParams parametros)
		{
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x000289E0 File Offset: 0x00026BE0
		protected override void Comienza()
		{
			this.m_ejecutandoseUser = this.user;
			ICharacter componentInParent = ((Component)this.user).GetComponentInParent<ICharacter>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("@char", "@char null reference.");
			}
			this.m_animController = componentInParent.GetComponentInChildren<AnimController>();
			if (this.m_animController == null)
			{
				throw new ArgumentNullException("m_animController", "m_animController null reference.");
			}
			if (this.trasladarUser && (!ExtendedMonoBehaviour.AlmostEqual(base.transform.position, componentInParent.posicion, 0.001f) || !ExtendedMonoBehaviour.AlmostEqual(base.transform.rotation, componentInParent.rotacion, 0.1f)))
			{
				componentInParent.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			}
			base.Comienza();
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00028AAB File Offset: 0x00026CAB
		protected override void Termina()
		{
			base.Termina();
			this.m_animController = null;
			this.m_ejecutandoseUser = null;
		}

		// Token: 0x040005A3 RID: 1443
		public bool trasladarUser = true;

		// Token: 0x040005A4 RID: 1444
		[SerializeField]
		private IInteractionController m_User;

		// Token: 0x040005A5 RID: 1445
		private AnimController m_animController;

		// Token: 0x040005A6 RID: 1446
		[ReadOnlyUI]
		[SerializeField]
		private IInteractionController m_ejecutandoseUser;
	}
}
