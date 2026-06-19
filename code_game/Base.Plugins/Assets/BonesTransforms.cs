using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000BC RID: 188
	public class BonesTransforms
	{
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0001626F File Offset: 0x0001446F
		public bool initiated
		{
			get
			{
				return this.m_initiated;
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060005B5 RID: 1461 RVA: 0x00016278 File Offset: 0x00014478
		// (remove) Token: 0x060005B6 RID: 1462 RVA: 0x000162B0 File Offset: 0x000144B0
		public event Action onInitiated;

		// Token: 0x060005B7 RID: 1463 RVA: 0x000162E8 File Offset: 0x000144E8
		public DatosDeBoneBase Obtener(Transform bone)
		{
			DatosDeBoneBase datosDeBoneBase;
			if (this.m_boneADatos.TryGetValue(bone, out datosDeBoneBase))
			{
				return datosDeBoneBase;
			}
			return null;
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00016308 File Offset: 0x00014508
		public DatosDeBoneBase Obtener(HumanBodyBones bone)
		{
			DatosDeBoneBase datosDeBoneBase;
			if (this.m_boneEnumADatos.TryGetValue((int)bone, out datosDeBoneBase))
			{
				return datosDeBoneBase;
			}
			return null;
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00016328 File Offset: 0x00014528
		public bool Contiene(HumanBodyBones bone)
		{
			return this.m_boneEnumADatos.ContainsKey((int)bone);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00016338 File Offset: 0x00014538
		public void Init(Animator anim, IAnimatorCharacter character)
		{
			this.eyeL.Init(anim, HumanBodyBones.LeftEye);
			this.eyeR.Init(anim, HumanBodyBones.RightEye);
			this.head.Init(anim, HumanBodyBones.Head);
			this.handL.Init(anim, HumanBodyBones.LeftHand);
			this.handR.Init(anim, HumanBodyBones.RightHand);
			this.neck.Init(anim, HumanBodyBones.Neck);
			this.legL.Init(anim, HumanBodyBones.LeftUpperLeg);
			this.legR.Init(anim, HumanBodyBones.RightUpperLeg);
			this.canillaL.Init(anim, HumanBodyBones.LeftLowerLeg);
			this.canillaR.Init(anim, HumanBodyBones.RightLowerLeg);
			this.footL.Init(anim, HumanBodyBones.LeftFoot);
			this.footR.Init(anim, HumanBodyBones.RightFoot);
			this.shoulderL.Init(anim, HumanBodyBones.LeftShoulder);
			this.shoulderR.Init(anim, HumanBodyBones.RightShoulder);
			this.armsL.Init(anim, HumanBodyBones.LeftUpperArm);
			this.armsR.Init(anim, HumanBodyBones.RightUpperArm);
			this.foreArmsL.Init(anim, HumanBodyBones.LeftLowerArm);
			this.foreArmsR.Init(anim, HumanBodyBones.RightLowerArm);
			this.hips.Init(anim, HumanBodyBones.Hips);
			this.spine.Init(anim, HumanBodyBones.Spine);
			this.chest.Init(anim, HumanBodyBones.Chest);
			this.jaw.Init(anim, HumanBodyBones.Jaw);
			this.m_boneADatos = new Dictionary<Transform, DatosDeBoneBase>();
			this.m_boneADatos.Add(this.eyeL.transform, this.eyeL);
			this.m_boneADatos.Add(this.eyeR.transform, this.eyeR);
			this.m_boneADatos.Add(this.head.transform, this.head);
			this.m_boneADatos.Add(this.handL.transform, this.handL);
			this.m_boneADatos.Add(this.handR.transform, this.handR);
			this.m_boneADatos.Add(this.neck.transform, this.neck);
			this.m_boneADatos.Add(this.legL.transform, this.legL);
			this.m_boneADatos.Add(this.legR.transform, this.legR);
			this.m_boneADatos.Add(this.canillaL.transform, this.canillaL);
			this.m_boneADatos.Add(this.canillaR.transform, this.canillaR);
			this.m_boneADatos.Add(this.footL.transform, this.footL);
			this.m_boneADatos.Add(this.footR.transform, this.footR);
			this.m_boneADatos.Add(this.shoulderL.transform, this.shoulderL);
			this.m_boneADatos.Add(this.shoulderR.transform, this.shoulderR);
			this.m_boneADatos.Add(this.armsL.transform, this.armsL);
			this.m_boneADatos.Add(this.armsR.transform, this.armsR);
			this.m_boneADatos.Add(this.foreArmsL.transform, this.foreArmsL);
			this.m_boneADatos.Add(this.foreArmsR.transform, this.foreArmsR);
			this.m_boneADatos.Add(this.hips.transform, this.hips);
			this.m_boneADatos.Add(this.spine.transform, this.spine);
			this.m_boneADatos.Add(this.chest.transform, this.chest);
			this.m_boneADatos.Add(this.jaw.transform, this.jaw);
			this.m_boneEnumADatos = new Dictionary<int, DatosDeBoneBase>();
			this.m_boneEnumADatos.Add((int)this.eyeL.humanBodyBone, this.eyeL);
			this.m_boneEnumADatos.Add((int)this.eyeR.humanBodyBone, this.eyeR);
			this.m_boneEnumADatos.Add((int)this.head.humanBodyBone, this.head);
			this.m_boneEnumADatos.Add((int)this.handL.humanBodyBone, this.handL);
			this.m_boneEnumADatos.Add((int)this.handR.humanBodyBone, this.handR);
			this.m_boneEnumADatos.Add((int)this.neck.humanBodyBone, this.neck);
			this.m_boneEnumADatos.Add((int)this.legL.humanBodyBone, this.legL);
			this.m_boneEnumADatos.Add((int)this.legR.humanBodyBone, this.legR);
			this.m_boneEnumADatos.Add((int)this.canillaL.humanBodyBone, this.canillaL);
			this.m_boneEnumADatos.Add((int)this.canillaR.humanBodyBone, this.canillaR);
			this.m_boneEnumADatos.Add((int)this.footL.humanBodyBone, this.footL);
			this.m_boneEnumADatos.Add((int)this.footR.humanBodyBone, this.footR);
			this.m_boneEnumADatos.Add((int)this.shoulderL.humanBodyBone, this.shoulderL);
			this.m_boneEnumADatos.Add((int)this.shoulderR.humanBodyBone, this.shoulderR);
			this.m_boneEnumADatos.Add((int)this.armsL.humanBodyBone, this.armsL);
			this.m_boneEnumADatos.Add((int)this.armsR.humanBodyBone, this.armsR);
			this.m_boneEnumADatos.Add((int)this.foreArmsL.humanBodyBone, this.foreArmsL);
			this.m_boneEnumADatos.Add((int)this.foreArmsR.humanBodyBone, this.foreArmsR);
			this.m_boneEnumADatos.Add((int)this.hips.humanBodyBone, this.hips);
			this.m_boneEnumADatos.Add((int)this.spine.humanBodyBone, this.spine);
			this.m_boneEnumADatos.Add((int)this.chest.humanBodyBone, this.chest);
			this.m_boneEnumADatos.Add((int)this.jaw.humanBodyBone, this.jaw);
			IMapaDeHuesosDeCharacter mapaDeHuesos = character.mapaDeHuesos;
			if (mapaDeHuesos != null)
			{
				if (!string.IsNullOrWhiteSpace(mapaDeHuesos.tongue01))
				{
					this.lenguaBase.Init(anim, mapaDeHuesos.tongue01, mapaDeHuesos);
					this.m_boneADatos.Add(this.lenguaBase.transform, this.lenguaBase);
				}
				if (mapaDeHuesos.ContieneHueso("LabiosEntrada", anim))
				{
					this.bocaEntrada.Init(anim, "LabiosEntrada", mapaDeHuesos);
					this.m_boneADatos.Add(this.bocaEntrada.transform, this.bocaEntrada);
				}
				if (mapaDeHuesos.ContieneHueso("Pelvis", anim))
				{
					this.pelvis.Init(anim, "Pelvis", mapaDeHuesos);
					this.m_boneADatos.Add(this.pelvis.transform, this.pelvis);
				}
			}
			this.m_lista = this.m_boneADatos.Values.ToList<DatosDeBoneBase>();
			this.m_initiated = true;
			Action action = this.onInitiated;
			if (action != null)
			{
				action();
			}
			this.onInitiated = null;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00016A4C File Offset: 0x00014C4C
		public void OnPostAnimaciones()
		{
			for (int i = 0; i < this.m_lista.Count; i++)
			{
				this.m_lista[i].OnPostAnimation();
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00016A80 File Offset: 0x00014C80
		public void OnPostProcesadoDeAnimaciones()
		{
			for (int i = 0; i < this.m_lista.Count; i++)
			{
				this.m_lista[i].OnPostProcesado();
			}
		}

		// Token: 0x0400015B RID: 347
		private Dictionary<Transform, DatosDeBoneBase> m_boneADatos;

		// Token: 0x0400015C RID: 348
		private Dictionary<int, DatosDeBoneBase> m_boneEnumADatos;

		// Token: 0x0400015D RID: 349
		[NonSerialized]
		private List<DatosDeBoneBase> m_lista;

		// Token: 0x0400015E RID: 350
		public DatosDeHumanBone eyeL = new DatosDeHumanBone();

		// Token: 0x0400015F RID: 351
		public DatosDeHumanBone eyeR = new DatosDeHumanBone();

		// Token: 0x04000160 RID: 352
		public DatosDeHumanBone head = new DatosDeHumanBone();

		// Token: 0x04000161 RID: 353
		public DatosDeNeck neck = new DatosDeNeck();

		// Token: 0x04000162 RID: 354
		public DatosDeHumanBone handR = new DatosDeHumanBone();

		// Token: 0x04000163 RID: 355
		public DatosDeHumanBone handL = new DatosDeHumanBone();

		// Token: 0x04000164 RID: 356
		public DatosDeHumanBone legR = new DatosDeHumanBone();

		// Token: 0x04000165 RID: 357
		public DatosDeHumanBone legL = new DatosDeHumanBone();

		// Token: 0x04000166 RID: 358
		public DatosDeHumanBone canillaR = new DatosDeHumanBone();

		// Token: 0x04000167 RID: 359
		public DatosDeHumanBone canillaL = new DatosDeHumanBone();

		// Token: 0x04000168 RID: 360
		public DatosDeHumanBone foreArmsR = new DatosDeHumanBone();

		// Token: 0x04000169 RID: 361
		public DatosDeHumanBone foreArmsL = new DatosDeHumanBone();

		// Token: 0x0400016A RID: 362
		public DatosDeHumanBone footR = new DatosDeHumanBone();

		// Token: 0x0400016B RID: 363
		public DatosDeHumanBone footL = new DatosDeHumanBone();

		// Token: 0x0400016C RID: 364
		public DatosDeHumanBone armsR = new DatosDeHumanBone();

		// Token: 0x0400016D RID: 365
		public DatosDeHumanBone armsL = new DatosDeHumanBone();

		// Token: 0x0400016E RID: 366
		public DatosDeHumanBone shoulderR = new DatosDeHumanBone();

		// Token: 0x0400016F RID: 367
		public DatosDeHumanBone shoulderL = new DatosDeHumanBone();

		// Token: 0x04000170 RID: 368
		public DatosDeHumanBone hips = new DatosDeHumanBone();

		// Token: 0x04000171 RID: 369
		public DatosDeNoHumanBone pelvis = new DatosDeNoHumanBone();

		// Token: 0x04000172 RID: 370
		public DatosDeHumanBone spine = new DatosDeHumanBone();

		// Token: 0x04000173 RID: 371
		public DatosDeHumanBone chest = new DatosDeHumanBone();

		// Token: 0x04000174 RID: 372
		public DatosDeJaw jaw = new DatosDeJaw();

		// Token: 0x04000175 RID: 373
		public DatosDeLengua lenguaBase = new DatosDeLengua();

		// Token: 0x04000176 RID: 374
		public DatosDeNoHumanBone bocaEntrada = new DatosDeNoHumanBone();

		// Token: 0x04000177 RID: 375
		[SerializeField]
		[ReadOnlyUI]
		private bool m_initiated;
	}
}
