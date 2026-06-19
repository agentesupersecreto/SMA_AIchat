using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000033 RID: 51
	public abstract class HoleWallsHitSkin : MultipleProxyHitSkin<CapsuleCollider>, IHoleHitSkin
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00006047 File Offset: 0x00004247
		public sealed override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates1);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x000073FB File Offset: 0x000055FB
		public IHole hole
		{
			get
			{
				return this.m_hole;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00007404 File Offset: 0x00005604
		public void Init<TBodyPartCollider>(IHole hole, Skin VisualSkin, FemalePenetracionTipo tipo) where TBodyPartCollider : BodyPartCollider
		{
			if (hole == null)
			{
				throw new ArgumentNullException("hole", "hole null reference.");
			}
			this.m_hole = hole;
			BodyPartEnum bodyPartEnum;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				bodyPartEnum = BodyPartEnum.anoHole;
				break;
			case FemalePenetracionTipo.vag:
				bodyPartEnum = BodyPartEnum.vagHole;
				break;
			case FemalePenetracionTipo.facial:
				bodyPartEnum = BodyPartEnum.bocaInterno;
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			TBodyPartCollider[] componentsInChildren = ((Component)hole).GetComponentsInChildren<TBodyPartCollider>();
			if (componentsInChildren.Length == 0)
			{
				throw new NotSupportedException();
			}
			List<CapsuleCollider> list = (from c in componentsInChildren.SelectMany((TBodyPartCollider wall) => wall.collidersV2)
				where c is CapsuleCollider
				select c).Cast<CapsuleCollider>().ToList<CapsuleCollider>();
			if (list.Count == 0)
			{
				throw new NotSupportedException();
			}
			base.Init(list, Side.none, bodyPartEnum, this.m_hole.entrada, VisualSkin, MapaSingleton<ConfiguracionGlobal>.instance.layers.penes.ToLayerMask(), QueryTriggerInteraction.Ignore);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00007505 File Offset: 0x00005705
		public sealed override void OnUpdateEvent2()
		{
			this.m_doUpdate = this.m_hole.isPenetrated;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00007518 File Offset: 0x00005718
		protected sealed override bool DetectedColliderIsValid(Collider other)
		{
			return this.m_hole.isPenetrated && this.m_hole.IsPenetratedBy(other);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00007535 File Offset: 0x00005735
		protected sealed override EmulatedHitSkin.ColliderCheckerBase ObtenerCheckDeCollider(CapsuleCollider col)
		{
			return new SingleCapsuleProxyHitSkin.CapsuleCheck(col, 0.003f);
		}

		// Token: 0x040000E8 RID: 232
		private IHole m_hole;
	}
}
