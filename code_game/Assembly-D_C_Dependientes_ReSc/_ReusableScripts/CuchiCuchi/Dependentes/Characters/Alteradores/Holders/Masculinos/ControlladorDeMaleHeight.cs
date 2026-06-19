using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Bones.V2;
using Assets._ReusableScripts.Bones.V2.Abstracts;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.Masculinos
{
	// Token: 0x02000293 RID: 659
	public sealed class ControlladorDeMaleHeight : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06001125 RID: 4389 RVA: 0x00050ACE File Offset: 0x0004ECCE
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdate3);
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06001126 RID: 4390 RVA: 0x00050AD6 File Offset: 0x0004ECD6
		public ValorFlotanteBaseLibre alturaModding
		{
			get
			{
				return this.m_alturaModding;
			}
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x00050AE0 File Offset: 0x0004ECE0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_alturaModding.ForceNewValue(1f, false);
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			if (!this.m_character.isAwaken)
			{
				this.m_character.ManualAwake();
			}
			this.m_puppet = this.m_character.GetComponentInChildren<PuppetMaster>();
			this.m_skeletonBoneModding.Init(this.m_character.rootBoneTransform, this);
			ControlladorDeMaleHeight.BoneModding puppetBoneModding = this.m_puppetBoneModding;
			PuppetMaster puppet = this.m_puppet;
			puppetBoneModding.Init((puppet != null) ? puppet.transform : null, this);
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x00050B8C File Offset: 0x0004ED8C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_skeletonBoneModding.Destroy();
			this.m_puppetBoneModding.Destroy();
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x00050BAC File Offset: 0x0004EDAC
		public override void OnUpdateEvent1()
		{
			if (!this.m_updateScalaCoolDown.isOn)
			{
				float num = 1f;
				if (Singleton<ConfiguracionGeneralDeCheats>.instance.appearanceCheatActivated)
				{
					num = Mathf.Clamp(Singleton<ConfiguracionGeneralDeCheats>.instance.current.heroHeight, 0.1f, 10f);
				}
				float num2 = this.m_alturaModding.valorCalculado * num;
				if (this.m_skeletonBoneModding.isValid)
				{
					this.m_skeletonBoneModding.x.valor.valor = num2;
					this.m_skeletonBoneModding.y.valor.valor = num2;
					this.m_skeletonBoneModding.z.valor.valor = num2;
				}
				if (this.m_puppetBoneModding.isValid)
				{
					this.m_puppetBoneModding.x.valor.valor = num2;
					this.m_puppetBoneModding.y.valor.valor = num2;
					this.m_puppetBoneModding.z.valor.valor = num2;
				}
				this.m_updateScalaCoolDown.ApplyNext(0.1f);
			}
		}

		// Token: 0x04000C8A RID: 3210
		private Character m_character;

		// Token: 0x04000C8B RID: 3211
		private PuppetMaster m_puppet;

		// Token: 0x04000C8C RID: 3212
		[SerializeField]
		private ControlladorDeMaleHeight.BoneModding m_skeletonBoneModding = new ControlladorDeMaleHeight.BoneModding();

		// Token: 0x04000C8D RID: 3213
		[SerializeField]
		private ControlladorDeMaleHeight.BoneModding m_puppetBoneModding = new ControlladorDeMaleHeight.BoneModding();

		// Token: 0x04000C8E RID: 3214
		[SerializeField]
		private ValorFlotanteBaseLibre m_alturaModding = new ValorFlotanteBaseLibre();

		// Token: 0x04000C8F RID: 3215
		private CoolDown m_updateScalaCoolDown = new CoolDown();

		// Token: 0x02000294 RID: 660
		[Serializable]
		public class BoneModding
		{
			// Token: 0x0600112B RID: 4395 RVA: 0x00050CEC File Offset: 0x0004EEEC
			public void Init(Transform bone, ControlladorDeMaleHeight controllador)
			{
				if (bone == null)
				{
					return;
				}
				this.m_bone = bone.GetComponentNotNull<BaseBone, BoneHijo>();
				this.x = this.m_bone.modificableDeScalaLocal.x.modificable.ObtenerModificadorNotNull(controllador);
				this.y = this.m_bone.modificableDeScalaLocal.y.modificable.ObtenerModificadorNotNull(controllador);
				this.z = this.m_bone.modificableDeScalaLocal.z.modificable.ObtenerModificadorNotNull(controllador);
				this.m_bone.controlaScalaLocal = true;
			}

			// Token: 0x0600112C RID: 4396 RVA: 0x00050D7E File Offset: 0x0004EF7E
			public void Destroy()
			{
				ModificadorDeFloat modificadorDeFloat = this.x;
				if (modificadorDeFloat != null)
				{
					modificadorDeFloat.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat modificadorDeFloat2 = this.y;
				if (modificadorDeFloat2 != null)
				{
					modificadorDeFloat2.TryRemoverDeOwner(true);
				}
				ModificadorDeFloat modificadorDeFloat3 = this.z;
				if (modificadorDeFloat3 == null)
				{
					return;
				}
				modificadorDeFloat3.TryRemoverDeOwner(true);
			}

			// Token: 0x17000430 RID: 1072
			// (get) Token: 0x0600112D RID: 4397 RVA: 0x00050DB8 File Offset: 0x0004EFB8
			public bool isValid
			{
				get
				{
					return this.m_bone != null;
				}
			}

			// Token: 0x04000C90 RID: 3216
			[SerializeField]
			[ReadOnlyUI]
			private BaseBone m_bone;

			// Token: 0x04000C91 RID: 3217
			public ModificadorDeFloat x;

			// Token: 0x04000C92 RID: 3218
			public ModificadorDeFloat y;

			// Token: 0x04000C93 RID: 3219
			public ModificadorDeFloat z;
		}
	}
}
