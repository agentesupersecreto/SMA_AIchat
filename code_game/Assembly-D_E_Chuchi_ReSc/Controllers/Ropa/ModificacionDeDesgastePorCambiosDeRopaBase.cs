using System;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Ropa
{
	// Token: 0x0200024A RID: 586
	[RequireComponent(typeof(IHoleDesgastable))]
	public abstract class ModificacionDeDesgastePorCambiosDeRopaBase : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000D1E RID: 3358 RVA: 0x0003C4CC File Offset: 0x0003A6CC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_desgastable = base.GetComponent<IHoleDesgastable>();
			this.m_ArmatureSkins = this.GetComponentEnRoot(false);
			if (this.m_ArmatureSkins == null)
			{
				throw new ArgumentNullException("m_ArmatureSkins", "m_ArmatureSkins null reference.");
			}
			this.m_ArmatureSkins.skinAdded += this.M_ArmatureSkins_skinAdded;
			this.m_ArmatureSkins.skinShowed += this.M_ArmatureSkins_skinAdded;
			this.m_ArmatureSkins.skinRemoved += this.M_ArmatureSkins_skinRemoved;
			this.m_ArmatureSkins.skinHidden += this.M_ArmatureSkins_skinRemoved;
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0003C574 File Offset: 0x0003A774
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_ArmatureSkins)
			{
				this.m_ArmatureSkins.skinAdded -= this.M_ArmatureSkins_skinAdded;
				this.m_ArmatureSkins.skinShowed -= this.M_ArmatureSkins_skinAdded;
				this.m_ArmatureSkins.skinRemoved -= this.M_ArmatureSkins_skinRemoved;
				this.m_ArmatureSkins.skinHidden -= this.M_ArmatureSkins_skinRemoved;
			}
		}

		// Token: 0x06000D20 RID: 3360
		protected abstract float ObtenerModificacionDeDesgaste(PiezaDeRopaBase pieza);

		// Token: 0x06000D21 RID: 3361 RVA: 0x0003C5F4 File Offset: 0x0003A7F4
		private void M_ArmatureSkins_skinAdded(ArmatureSkins arg1, Skin arg2)
		{
			PiezaDeRopaBase piezaDeRopaBase = arg2 as PiezaDeRopaBase;
			if (piezaDeRopaBase == null)
			{
				return;
			}
			this.m_desgastable.anchura.modificable.ObtenerModificadorNotNull(arg2).valor.valor = this.ObtenerModificacionDeDesgaste(piezaDeRopaBase);
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x0003C639 File Offset: 0x0003A839
		private void M_ArmatureSkins_skinRemoved(ArmatureSkins arg1, Skin arg2)
		{
			if (arg2 as PiezaDeRopaBase == null)
			{
				return;
			}
			this.m_desgastable.anchura.modificable.RemoverModificador(arg2);
		}

		// Token: 0x04000B07 RID: 2823
		private IHoleDesgastable m_desgastable;

		// Token: 0x04000B08 RID: 2824
		private ArmatureSkins m_ArmatureSkins;
	}
}
