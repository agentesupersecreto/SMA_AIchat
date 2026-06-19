using System;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000064 RID: 100
	public class HandHitSkin : NonSkinnedHitSkin<HandHitSkin.Colliders>
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x0000A498 File Offset: 0x00008698
		public CreadorDeCollidersParaManos credorDeColliders
		{
			get
			{
				return this.m_Creador;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x0000A4A0 File Offset: 0x000086A0
		public sealed override BodyPartEnum parte
		{
			get
			{
				switch (this.m_side)
				{
				case Side.none:
				case Side.F:
				case Side.B:
					throw new InvalidOperationException();
				case Side.L:
					return BodyPartEnum.mano_L;
				case Side.R:
					return BodyPartEnum.mano_R;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000A4E1 File Offset: 0x000086E1
		public sealed override Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000A4E9 File Offset: 0x000086E9
		public virtual void Init(Side handSide, Skin VisualSkin, IHandBoneMap handBonesMap)
		{
			if (handBonesMap == null)
			{
				throw new ArgumentNullException("handBonesMap", "handBonesMap null reference.");
			}
			this.Init(handSide, Vector3.forward, VisualSkin, handBonesMap);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000A50C File Offset: 0x0000870C
		public virtual void Init(Side handSide, Skin VisualSkin)
		{
			this.Init(handSide, Vector3.forward, VisualSkin, null);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000A51C File Offset: 0x0000871C
		public virtual void Init(Side handSide, Vector3 localForward, Skin VisualSkin, IHandBoneMap handBonesMap = null)
		{
			Transform transform;
			HitPartEnum hitPartEnum;
			CreadorDeCollidersParaManos.Side side;
			switch (handSide)
			{
			case Side.none:
			case Side.F:
			case Side.B:
				throw new InvalidOperationException();
			case Side.L:
				transform = base.owner.animator.GetBoneTransform(HumanBodyBones.LeftHand);
				hitPartEnum = HitPartEnum.mano_L;
				side = CreadorDeCollidersParaManos.Side.l;
				break;
			case Side.R:
				transform = base.owner.animator.GetBoneTransform(HumanBodyBones.RightHand);
				hitPartEnum = HitPartEnum.mano_R;
				side = CreadorDeCollidersParaManos.Side.r;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			this.m_side = handSide;
			this.m_Creador = new CreadorDeCollidersParaManos(side, base.owner.animator, this, transform, null);
			this.m_Creador.overrideUpdateEvent = new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onDynamicColliders);
			this.m_Creador.handBonesMap = handBonesMap;
			this.m_Creador.localForward = localForward;
			this.m_Creador.localMedidas = this.localMedidas;
			this.m_Creador.Crear();
			base.colliders.Init(this);
			this.Init(hitPartEnum, transform, VisualSkin);
			this.m_Creador.Follow();
		}

		// Token: 0x040001C1 RID: 449
		[SerializeField]
		private CreadorDeCollidersParaManos m_Creador;

		// Token: 0x040001C2 RID: 450
		[ReadOnlyUI]
		[SerializeField]
		private Side m_side;

		// Token: 0x040001C3 RID: 451
		public HandHitSkin.Medidas localMedidas = new HandHitSkin.Medidas();

		// Token: 0x02000065 RID: 101
		[Serializable]
		public class Colliders : NonSkinnedHitSkinBase.BaseColliders
		{
			// Token: 0x060002BB RID: 699 RVA: 0x0000A620 File Offset: 0x00008820
			public void Init(HandHitSkin owner)
			{
				this.colliders = owner.m_Creador.colliders;
			}

			// Token: 0x040001C4 RID: 452
			public CreadorDeCollidersParaManos.Colliders colliders;
		}

		// Token: 0x02000066 RID: 102
		[Serializable]
		public class Medidas : CreadorDeCollidersParaManos.Medidas
		{
			// Token: 0x060002BD RID: 701 RVA: 0x0000A634 File Offset: 0x00008834
			public Medidas()
			{
				this.handAncho = 0.02f;
				this.thumbProximal = 0.022f;
				this.thumbIntermediate = 0.016f;
				this.thumbDistal = 0.011f;
				this.indexProximal = 0.012f;
				this.indexIntermediate = 0.009f;
				this.indexDistal = 0.008f;
				this.middleProximal = 0.013f;
				this.middleIntermediate = 0.01f;
				this.middleDistal = 0.0085f;
				this.ringProximal = 0.012f;
				this.ringIntermediate = 0.009f;
				this.ringDistal = 0.008f;
				this.littleProximal = 0.011f;
				this.littleIntermediate = 0.007f;
				this.littleDistal = 0.006f;
			}
		}
	}
}
