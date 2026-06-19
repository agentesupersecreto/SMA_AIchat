using System;
using Assets.Base.BeachGirl.Controladores.Shapes.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x02000121 RID: 289
	public sealed class ModificadorDeShapesDeFemaleSegunRopa : CustomMonobehaviour
	{
		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060006A7 RID: 1703 RVA: 0x0001F238 File Offset: 0x0001D438
		// (remove) Token: 0x060006A8 RID: 1704 RVA: 0x0001F270 File Offset: 0x0001D470
		public event Action<ModificadorDeShapesDeFemaleSegunRopa> pezonesUpdated;

		// Token: 0x060006A9 RID: 1705 RVA: 0x0001F2A8 File Offset: 0x0001D4A8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ArmatureSkins = this.GetComponentEnRoot(false);
			if (this.m_ArmatureSkins == null)
			{
				throw new ArgumentNullException("m_ArmatureSkins", "m_ArmatureSkins null reference.");
			}
			this.m_ControlladorDeShapeDePezonesFlat = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeShapeDePezonesFlat == null)
			{
				throw new ArgumentNullException("m_ControlladorDeShapeDePezonesFlat", "m_ControlladorDeShapeDePezonesFlat null reference.");
			}
			this.m_ControlladorDeShapeDeTipoDePezones = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeShapeDeTipoDePezones == null)
			{
				throw new ArgumentNullException("m_ControlladorDeShapeDeTipoDePezones", "m_ControlladorDeShapeDeTipoDePezones null reference.");
			}
			this.m_ArmatureSkins.skinAdded += this.M_ArmatureSkins_skinAdded;
			this.m_ArmatureSkins.skinRemoved += this.M_ArmatureSkins_skinRemoved;
			this.m_ArmatureSkins.skinHidden += this.M_ArmatureSkins_skinHidden;
			this.m_ArmatureSkins.skinShowed += this.M_ArmatureSkins_skinShowed;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001F398 File Offset: 0x0001D598
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_ArmatureSkins != null)
			{
				this.m_ArmatureSkins.skinAdded -= this.M_ArmatureSkins_skinAdded;
				this.m_ArmatureSkins.skinRemoved -= this.M_ArmatureSkins_skinRemoved;
				this.m_ArmatureSkins.skinHidden -= this.M_ArmatureSkins_skinHidden;
				this.m_ArmatureSkins.skinShowed -= this.M_ArmatureSkins_skinShowed;
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001F418 File Offset: 0x0001D618
		private void M_ArmatureSkins_skinRemoved(ArmatureSkins arg1, Skin arg2)
		{
			PiezaDeRopaBase piezaDeRopaBase = arg2 as PiezaDeRopaBase;
			if (piezaDeRopaBase == null)
			{
				return;
			}
			this.UpdatePezonShapes(piezaDeRopaBase, true);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0001F440 File Offset: 0x0001D640
		private void M_ArmatureSkins_skinHidden(ArmatureSkins arg1, Skin arg2)
		{
			PiezaDeRopaBase piezaDeRopaBase = arg2 as PiezaDeRopaBase;
			if (piezaDeRopaBase == null)
			{
				return;
			}
			this.UpdatePezonShapes(piezaDeRopaBase, true);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0001F468 File Offset: 0x0001D668
		private void M_ArmatureSkins_skinAdded(ArmatureSkins arg1, Skin arg2)
		{
			PiezaDeRopaBase piezaDeRopaBase = arg2 as PiezaDeRopaBase;
			if (piezaDeRopaBase == null)
			{
				return;
			}
			this.UpdatePezonShapes(piezaDeRopaBase, false);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0001F490 File Offset: 0x0001D690
		private void M_ArmatureSkins_skinShowed(ArmatureSkins arg1, Skin arg2)
		{
			PiezaDeRopaBase piezaDeRopaBase = arg2 as PiezaDeRopaBase;
			if (piezaDeRopaBase == null)
			{
				return;
			}
			this.UpdatePezonShapes(piezaDeRopaBase, false);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001F4B8 File Offset: 0x0001D6B8
		public void UpdatePezonShapes(PiezaDeRopaBase ropa, bool removing)
		{
			if (removing)
			{
				this.m_ControlladorDeShapeDeTipoDePezones.modificableGeneral.RemoverModificador(ropa);
				this.m_ControlladorDeShapeDePezonesFlat.GetModificablesDeShape(0).adicionable.RemoverModificador(ropa);
			}
			else
			{
				ModificadorDeFloatBase modificadorDeFloatBase = this.m_ControlladorDeShapeDeTipoDePezones.modificableGeneral.ObtenerModificadorNotNull(ropa);
				float num = Mathf.InverseLerp(0f, 1f, ropa.dataDeRopa.senosConfig.modificadorDeShapeDePezonV2);
				modificadorDeFloatBase.valor.valor = num;
				ModificadorDeFloatBase modificadorDeFloatBase2 = this.m_ControlladorDeShapeDePezonesFlat.GetModificablesDeShape(0).adicionable.ObtenerModificadorNotNull(ropa);
				float num2 = Mathf.Lerp(0f, 100f, Mathf.InverseLerp(0f, -1f, ropa.dataDeRopa.senosConfig.modificadorDeShapeDePezonV2));
				modificadorDeFloatBase2.valor.valor = num2;
			}
			Action<ModificadorDeShapesDeFemaleSegunRopa> action = this.pezonesUpdated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x04000554 RID: 1364
		private ArmatureSkins m_ArmatureSkins;

		// Token: 0x04000555 RID: 1365
		private ControlladorDeShapeDePezonesFlat m_ControlladorDeShapeDePezonesFlat;

		// Token: 0x04000556 RID: 1366
		private ControlladorDeShapeDeTipoDePezones m_ControlladorDeShapeDeTipoDePezones;
	}
}
