using System;
using System.Linq;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones
{
	// Token: 0x02000039 RID: 57
	public sealed class InteracionMalePrimariaExterna : InteraccionMalePrimariaBase
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600026B RID: 619 RVA: 0x0000D44E File Offset: 0x0000B64E
		public override IInteractionController user
		{
			get
			{
				return this.m_User;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600026C RID: 620 RVA: 0x0000D456 File Offset: 0x0000B656
		protected override bool detenerTodasDelMismoLayer
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000D459 File Offset: 0x0000B659
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!this.m_datos.isValid)
			{
				Debug.LogWarning(base.name + " Interaccion, no tiene datos validos");
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000D484 File Offset: 0x0000B684
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
						bool flag2 = base.Ejecutar(prioridad, duracion, priConfig, 1f, 1f, false);
						if (!flag2)
						{
							this.m_User = null;
						}
						flag = flag2;
					}
				}
			}
			finally
			{
				this.m_User = user;
			}
			return flag;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000D4F8 File Offset: 0x0000B6F8
		protected override void OnAdded(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			base.OnAdded(interaccionesDeCharacter);
			this.m_User = interaccionesDeCharacter.character.GetComponentInChildren<IInteractionController>(false);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000D513 File Offset: 0x0000B713
		protected override void OnRemoved(IInteraccionesDeCharacter interaccionesDeCharacter)
		{
			base.OnRemoved(interaccionesDeCharacter);
			this.m_User = null;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000D524 File Offset: 0x0000B724
		protected override void OnAplicar()
		{
			if (this.m_User == null)
			{
				this.m_User = this.GetMaleFromScene();
			}
			if (this.TryEjecutarOn((Component)this.m_User, 2147483647, 10f, ControllerPrioridadConfig.prioridad))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000D590 File Offset: 0x0000B790
		protected override void OnAplicar2()
		{
			if (this.m_User == null)
			{
				this.m_User = this.GetMaleFromScene();
			}
			if (this.TryEjecutarOn((Component)this.m_User, 2147483647, 60f, ControllerPrioridadConfig.prioridad))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000D5FC File Offset: 0x0000B7FC
		protected override void OnAplicar3()
		{
			if (this.m_User == null)
			{
				this.m_User = this.GetMaleFromScene();
			}
			if (this.TryEjecutarOn((Component)this.m_User, 2147483647, 600f, ControllerPrioridadConfig.prioridad))
			{
				Debug.Log("ejecutando: " + base.name);
				return;
			}
			Debug.LogWarning("falla ejecutando: " + base.name);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000D668 File Offset: 0x0000B868
		private IInteractionController GetMaleFromScene()
		{
			Animator animator = Object.FindObjectsOfType<Animator>().FirstOrDefault(delegate(Animator a)
			{
				ICharacter componentEnRoot = a.GetComponentEnRoot(false);
				return componentEnRoot != null && componentEnRoot.sexo == Sexo.masculino;
			});
			if (animator == null)
			{
				return null;
			}
			return animator.GetComponentEnRoot(false);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000D6B1 File Offset: 0x0000B8B1
		protected sealed override void DespuesDeDetenerse()
		{
			base.DespuesDeDetenerse();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000D6B9 File Offset: 0x0000B8B9
		protected sealed override bool AntesDeDetenerse()
		{
			return true;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000D6BC File Offset: 0x0000B8BC
		protected override void OnForzada()
		{
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000D6BE File Offset: 0x0000B8BE
		protected sealed override bool OnPuedeEjecutarseConParametros(InteraccionStartParams parametros)
		{
			return true;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000D6C1 File Offset: 0x0000B8C1
		protected override void JustoAntesDeEjecutarse(ref InteraccionStartParams parametros)
		{
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000D6C3 File Offset: 0x0000B8C3
		protected sealed override void DespuesDeEjecutarse(InteraccionStartParams parametros)
		{
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000D6C8 File Offset: 0x0000B8C8
		protected override void Comienza()
		{
			this.m_ejecutandoseUser = this.user;
			ICharacter componentInParent = ((Component)this.user).GetComponentInParent<ICharacter>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("@char", "@char null reference.");
			}
			if (this.trasladarUser && (!ExtendedMonoBehaviour.AlmostEqual(base.transform.position, componentInParent.posicion, 0.001f) || !ExtendedMonoBehaviour.AlmostEqual(base.transform.rotation, componentInParent.rotacion, 0.1f)))
			{
				componentInParent.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			}
			base.Comienza();
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000D769 File Offset: 0x0000B969
		protected override void Termina()
		{
			base.Termina();
			this.m_ejecutandoseUser = null;
		}

		// Token: 0x040001BD RID: 445
		public bool trasladarUser = true;

		// Token: 0x040001BE RID: 446
		[SerializeField]
		private IInteractionController m_User;

		// Token: 0x040001BF RID: 447
		[ReadOnlyUI]
		[SerializeField]
		private IInteractionController m_ejecutandoseUser;
	}
}
