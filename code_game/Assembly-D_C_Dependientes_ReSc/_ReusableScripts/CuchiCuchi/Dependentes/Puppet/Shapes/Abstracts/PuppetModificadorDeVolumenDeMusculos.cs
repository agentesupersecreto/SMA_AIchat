using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Bones.V2;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Volumenes;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Shapes.Abstracts
{
	// Token: 0x02000121 RID: 289
	public abstract class PuppetModificadorDeVolumenDeMusculos : ModificadorDeVolumenPorShapes
	{
		// Token: 0x060005DF RID: 1503 RVA: 0x00020E38 File Offset: 0x0001F038
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PuppetMaster = this.GetComponentEnRoot(false);
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
			this.m_PuppetPartes = this.GetComponentEnRoot(false);
			if (this.m_PuppetPartes == null)
			{
				throw new ArgumentNullException("m_PuppetPartes", "m_PuppetPartes null reference.");
			}
			if (!this.m_PuppetMaster.initiated || !this.m_PuppetPartes.isStared)
			{
				throw new NotSupportedException();
			}
			this.m_Modificales.cadera = this.m_PuppetPartes.partes.cadera.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.cadera);
			this.m_Modificales.spine1 = this.m_PuppetPartes.partes.spine1.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.spine1);
			this.m_Modificales.spine2 = this.m_PuppetPartes.partes.spine2.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.spine2);
			this.m_Modificales.head = this.m_PuppetPartes.partes.head.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.head);
			this.m_Modificales.brazoL = this.m_PuppetPartes.partes.brazoL.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.brazoL);
			this.m_Modificales.brazoR = this.m_PuppetPartes.partes.brazoR.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.brazoR);
			this.m_Modificales.anteBrazoL = this.m_PuppetPartes.partes.anteBrazoL.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.anteBrazoL);
			this.m_Modificales.anteBrazoR = this.m_PuppetPartes.partes.anteBrazoR.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.anteBrazoR);
			this.m_Modificales.manoL = this.m_PuppetPartes.partes.manoL.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.manoL);
			this.m_Modificales.manoR = this.m_PuppetPartes.partes.manoR.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.manoR);
			this.m_Modificales.piernaL = this.m_PuppetPartes.partes.piernaL.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.piernaL);
			this.m_Modificales.piernaR = this.m_PuppetPartes.partes.piernaR.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.piernaR);
			this.m_Modificales.canillaL = this.m_PuppetPartes.partes.canillaL.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.canillaL);
			this.m_Modificales.canillaR = this.m_PuppetPartes.partes.canillaR.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.canillaR);
			this.m_Modificales.pieL = this.m_PuppetPartes.partes.pieL.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.pieL);
			this.m_Modificales.pieR = this.m_PuppetPartes.partes.pieR.GetComponentInChildren<IModificableDeVolumenDeMusculo>();
			this.m_Modificales.Add(this.m_Modificales.pieR);
			PuppetModificadorDeVolumenDeMusculos.Modificales modificales = this.m_Modificales;
			PuppetPart neck = this.m_PuppetPartes.partes.neck;
			modificales.neck = ((neck != null) ? neck.GetComponentInChildren<IModificableDeVolumenDeMusculo>() : null);
			if (this.m_Modificales.neck != null)
			{
				this.m_Modificales.Add(this.m_Modificales.neck);
			}
			PuppetModificadorDeVolumenDeMusculos.Modificales modificales2 = this.m_Modificales;
			PuppetPart hombroL = this.m_PuppetPartes.partes.hombroL;
			modificales2.hombroL = ((hombroL != null) ? hombroL.GetComponentInChildren<IModificableDeVolumenDeMusculo>() : null);
			if (this.m_Modificales.hombroL != null)
			{
				this.m_Modificales.Add(this.m_Modificales.hombroL);
			}
			PuppetModificadorDeVolumenDeMusculos.Modificales modificales3 = this.m_Modificales;
			PuppetPart hombroR = this.m_PuppetPartes.partes.hombroR;
			modificales3.hombroR = ((hombroR != null) ? hombroR.GetComponentInChildren<IModificableDeVolumenDeMusculo>() : null);
			if (this.m_Modificales.hombroR != null)
			{
				this.m_Modificales.Add(this.m_Modificales.hombroR);
			}
			foreach (ModificadorDeVolumenPorShapes.ModificacionInfo modificacionInfo in this.infos)
			{
				PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo modificacionDeParteInfo = (PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo)modificacionInfo;
				IModificableDeVolumenDeMusculo modificableDeVolumenDeMusculo = this.ModificableDeParte(modificacionDeParteInfo.para);
				modificacionDeParteInfo.Init(this.m_PuppetMaster.targetAnimator, modificableDeVolumenDeMusculo, this);
				if (!modificacionDeParteInfo.isValid)
				{
					Debug.LogError("ModificacionDeParteInfo no es valida.");
				}
			}
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00021370 File Offset: 0x0001F570
		protected IModificableDeVolumenDeMusculo ModificableDeParte(PuppetParte parteEnum)
		{
			switch (parteEnum)
			{
			case PuppetParte.cadera:
				return this.m_Modificales.cadera;
			case PuppetParte.spine1:
				return this.m_Modificales.spine1;
			case PuppetParte.spine2:
				return this.m_Modificales.spine2;
			case PuppetParte.head:
				return this.m_Modificales.head;
			case PuppetParte.brazoL:
				return this.m_Modificales.brazoL;
			case PuppetParte.brazoR:
				return this.m_Modificales.brazoR;
			case PuppetParte.anteBrazoL:
				return this.m_Modificales.anteBrazoL;
			case PuppetParte.anteBrazoR:
				return this.m_Modificales.anteBrazoR;
			case PuppetParte.manoL:
				return this.m_Modificales.manoL;
			case PuppetParte.manoR:
				return this.m_Modificales.manoR;
			case PuppetParte.piernaL:
				return this.m_Modificales.piernaL;
			case PuppetParte.piernaR:
				return this.m_Modificales.piernaR;
			case PuppetParte.canillaL:
				return this.m_Modificales.canillaL;
			case PuppetParte.canillaR:
				return this.m_Modificales.canillaR;
			case PuppetParte.pieL:
				return this.m_Modificales.pieL;
			case PuppetParte.pieR:
				return this.m_Modificales.pieR;
			case PuppetParte.neck:
				return this.m_Modificales.neck;
			case PuppetParte.hombroL:
				return this.m_Modificales.hombroL;
			case PuppetParte.hombroR:
				return this.m_Modificales.hombroR;
			default:
				throw new ArgumentOutOfRangeException(parteEnum.ToString());
			}
		}

		// Token: 0x0400049B RID: 1179
		[SerializeField]
		private PuppetModificadorDeVolumenDeMusculos.Modificales m_Modificales = new PuppetModificadorDeVolumenDeMusculos.Modificales();

		// Token: 0x0400049C RID: 1180
		private PuppetMaster m_PuppetMaster;

		// Token: 0x0400049D RID: 1181
		private PuppetPartes m_PuppetPartes;

		// Token: 0x02000122 RID: 290
		public abstract class ModificacionDeParteInfo : ModificadorDeVolumenPorShapes.ModificacionInfo
		{
			// Token: 0x1700012C RID: 300
			// (get) Token: 0x060005E2 RID: 1506 RVA: 0x000214DD File Offset: 0x0001F6DD
			public override bool isValid
			{
				get
				{
					return base.isValid && this.m_modificable != null && this.m_rootBone != null;
				}
			}

			// Token: 0x060005E3 RID: 1507 RVA: 0x00021500 File Offset: 0x0001F700
			public void Init(Animator anim, IModificableDeVolumenDeMusculo modificable, PuppetModificadorDeVolumenDeMusculos holder)
			{
				RootBone rootBone;
				if (modificable == null)
				{
					rootBone = null;
				}
				else
				{
					Muscle muscle = modificable.muscle;
					if (muscle == null)
					{
						rootBone = null;
					}
					else
					{
						Transform target = muscle.target;
						rootBone = ((target != null) ? target.GetComponentInParent<RootBone>() : null);
					}
				}
				this.m_rootBone = rootBone;
				if (this.m_rootBone == null)
				{
					throw new ArgumentNullException("m_rootBone", "m_rootBone null reference.");
				}
				if (modificable == null)
				{
					throw new ArgumentNullException("modificable", "modificable null reference.");
				}
				this.m_modificable = modificable;
				base.Init(anim, holder);
				if (this.m_modificable.boxModificable != null)
				{
					this.m_BoxMods = new PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.BoxMods();
					this.m_BoxMods.sizeX = this.m_modificable.boxModificable.sizeX.modificable.ObtenerModificadorNotNull(this.m_holder.name + this.normbreDeShape);
					this.m_BoxMods.sizeY = this.m_modificable.boxModificable.sizeY.modificable.ObtenerModificadorNotNull(this.m_holder.name + this.normbreDeShape);
					this.m_BoxMods.sizeZ = this.m_modificable.boxModificable.sizeZ.modificable.ObtenerModificadorNotNull(this.m_holder.name + this.normbreDeShape);
				}
				if (this.m_modificable.sphereModificable != null)
				{
					this.m_SphereMods = new PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.SphereMods();
					this.m_SphereMods.radius = this.m_modificable.sphereModificable.radius.modificable.ObtenerModificadorNotNull(this.m_holder.name + this.normbreDeShape);
				}
				if (this.m_modificable.capsuleModificable != null)
				{
					this.m_CapsuleMods = new PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.CapsuleMods();
					this.m_CapsuleMods.radius = this.m_modificable.capsuleModificable.radius.modificable.ObtenerModificadorNotNull(this.m_holder.name + this.normbreDeShape);
					this.m_CapsuleMods.height = this.m_modificable.capsuleModificable.height.modificable.ObtenerModificadorNotNull(this.m_holder.name + this.normbreDeShape);
				}
			}

			// Token: 0x060005E4 RID: 1508 RVA: 0x00021728 File Offset: 0x0001F928
			protected override void Updated(float mod)
			{
				if (this.m_BoxMods != null)
				{
					if (this.modificarAltura)
					{
						this.m_BoxMods.sizeX.valor.valor = mod;
						this.m_BoxMods.sizeY.valor.valor = mod;
						this.m_BoxMods.sizeZ.valor.valor = mod;
					}
					else if (this.m_rootBone != null)
					{
						if (this.m_rootBone.forwardAxis != RootBone.ForwardAxis.x)
						{
							this.m_BoxMods.sizeX.valor.valor = mod;
						}
						if (this.m_rootBone.forwardAxis != RootBone.ForwardAxis.y)
						{
							this.m_BoxMods.sizeY.valor.valor = mod;
						}
						if (this.m_rootBone.forwardAxis != RootBone.ForwardAxis.z)
						{
							this.m_BoxMods.sizeZ.valor.valor = mod;
						}
					}
				}
				if (this.m_CapsuleMods != null)
				{
					this.m_CapsuleMods.radius.valor.valor = mod;
					if (this.modificarAltura)
					{
						this.m_CapsuleMods.height.valor.valor = mod;
					}
				}
				if (this.m_SphereMods != null)
				{
					this.m_SphereMods.radius.valor.valor = mod;
				}
			}

			// Token: 0x060005E5 RID: 1509 RVA: 0x0002185F File Offset: 0x0001FA5F
			protected override void Destroyed()
			{
				PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.BoxMods boxMods = this.m_BoxMods;
				if (boxMods != null)
				{
					boxMods.Remover();
				}
				PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.SphereMods sphereMods = this.m_SphereMods;
				if (sphereMods != null)
				{
					sphereMods.Remover();
				}
				PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.CapsuleMods capsuleMods = this.m_CapsuleMods;
				if (capsuleMods == null)
				{
					return;
				}
				capsuleMods.Remover();
			}

			// Token: 0x0400049E RID: 1182
			public PuppetParte para;

			// Token: 0x0400049F RID: 1183
			protected RootBone m_rootBone;

			// Token: 0x040004A0 RID: 1184
			private IModificableDeVolumenDeMusculo m_modificable;

			// Token: 0x040004A1 RID: 1185
			protected PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.BoxMods m_BoxMods;

			// Token: 0x040004A2 RID: 1186
			protected PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.SphereMods m_SphereMods;

			// Token: 0x040004A3 RID: 1187
			protected PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo.CapsuleMods m_CapsuleMods;

			// Token: 0x02000123 RID: 291
			public class BoxMods
			{
				// Token: 0x060005E7 RID: 1511 RVA: 0x0002189B File Offset: 0x0001FA9B
				public void Remover()
				{
					ModificadorDeFloat modificadorDeFloat = this.sizeX;
					if (modificadorDeFloat != null)
					{
						modificadorDeFloat.TryRemoverDeOwner(true);
					}
					ModificadorDeFloat modificadorDeFloat2 = this.sizeY;
					if (modificadorDeFloat2 != null)
					{
						modificadorDeFloat2.TryRemoverDeOwner(true);
					}
					ModificadorDeFloat modificadorDeFloat3 = this.sizeZ;
					if (modificadorDeFloat3 == null)
					{
						return;
					}
					modificadorDeFloat3.TryRemoverDeOwner(true);
				}

				// Token: 0x040004A4 RID: 1188
				public ModificadorDeFloat sizeX;

				// Token: 0x040004A5 RID: 1189
				public ModificadorDeFloat sizeY;

				// Token: 0x040004A6 RID: 1190
				public ModificadorDeFloat sizeZ;
			}

			// Token: 0x02000124 RID: 292
			public class SphereMods
			{
				// Token: 0x060005E9 RID: 1513 RVA: 0x000218D5 File Offset: 0x0001FAD5
				public void Remover()
				{
					ModificadorDeFloat modificadorDeFloat = this.radius;
					if (modificadorDeFloat == null)
					{
						return;
					}
					modificadorDeFloat.TryRemoverDeOwner(true);
				}

				// Token: 0x040004A7 RID: 1191
				public ModificadorDeFloat radius;
			}

			// Token: 0x02000125 RID: 293
			public class CapsuleMods
			{
				// Token: 0x060005EB RID: 1515 RVA: 0x000218E9 File Offset: 0x0001FAE9
				public void Remover()
				{
					ModificadorDeFloat modificadorDeFloat = this.radius;
					if (modificadorDeFloat != null)
					{
						modificadorDeFloat.TryRemoverDeOwner(true);
					}
					ModificadorDeFloat modificadorDeFloat2 = this.height;
					if (modificadorDeFloat2 == null)
					{
						return;
					}
					modificadorDeFloat2.TryRemoverDeOwner(true);
				}

				// Token: 0x040004A8 RID: 1192
				public ModificadorDeFloat radius;

				// Token: 0x040004A9 RID: 1193
				public ModificadorDeFloat height;
			}
		}

		// Token: 0x02000126 RID: 294
		[Serializable]
		public class Modificales
		{
			// Token: 0x060005ED RID: 1517 RVA: 0x00021910 File Offset: 0x0001FB10
			public void Add(IModificableDeVolumenDeMusculo item)
			{
				this.m_list.Add(item);
			}

			// Token: 0x1700012D RID: 301
			// (get) Token: 0x060005EE RID: 1518 RVA: 0x0002191E File Offset: 0x0001FB1E
			public IReadOnlyList<IModificableDeVolumenDeMusculo> list
			{
				get
				{
					return this.m_list;
				}
			}

			// Token: 0x040004AA RID: 1194
			[SerializeField]
			private List<Object> m_listDebug = new List<Object>();

			// Token: 0x040004AB RID: 1195
			private List<IModificableDeVolumenDeMusculo> m_list = new List<IModificableDeVolumenDeMusculo>();

			// Token: 0x040004AC RID: 1196
			public IModificableDeVolumenDeMusculo cadera;

			// Token: 0x040004AD RID: 1197
			public IModificableDeVolumenDeMusculo spine1;

			// Token: 0x040004AE RID: 1198
			public IModificableDeVolumenDeMusculo spine2;

			// Token: 0x040004AF RID: 1199
			public IModificableDeVolumenDeMusculo head;

			// Token: 0x040004B0 RID: 1200
			public IModificableDeVolumenDeMusculo brazoL;

			// Token: 0x040004B1 RID: 1201
			public IModificableDeVolumenDeMusculo brazoR;

			// Token: 0x040004B2 RID: 1202
			public IModificableDeVolumenDeMusculo anteBrazoL;

			// Token: 0x040004B3 RID: 1203
			public IModificableDeVolumenDeMusculo anteBrazoR;

			// Token: 0x040004B4 RID: 1204
			public IModificableDeVolumenDeMusculo manoL;

			// Token: 0x040004B5 RID: 1205
			public IModificableDeVolumenDeMusculo manoR;

			// Token: 0x040004B6 RID: 1206
			public IModificableDeVolumenDeMusculo piernaL;

			// Token: 0x040004B7 RID: 1207
			public IModificableDeVolumenDeMusculo piernaR;

			// Token: 0x040004B8 RID: 1208
			public IModificableDeVolumenDeMusculo canillaL;

			// Token: 0x040004B9 RID: 1209
			public IModificableDeVolumenDeMusculo canillaR;

			// Token: 0x040004BA RID: 1210
			public IModificableDeVolumenDeMusculo pieL;

			// Token: 0x040004BB RID: 1211
			public IModificableDeVolumenDeMusculo pieR;

			// Token: 0x040004BC RID: 1212
			public IModificableDeVolumenDeMusculo neck;

			// Token: 0x040004BD RID: 1213
			public IModificableDeVolumenDeMusculo hombroL;

			// Token: 0x040004BE RID: 1214
			public IModificableDeVolumenDeMusculo hombroR;
		}
	}
}
